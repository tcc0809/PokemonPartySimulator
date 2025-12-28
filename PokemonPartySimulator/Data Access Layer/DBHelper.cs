using PokemonPartySimulator.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonPartySimulator.Data_Access_Layer
{
    internal class DBHelper
    {
        // 1. 取得連線字串
        // 因為有用 TableAdapter，VS 已經把連線字串存在 Properties.Settings 裡了
        // 這樣就不用複製貼上一長串連線字串
        private static string ConnStr = Properties.Settings.Default.PokemonPartySimulatorConnectionString;

        // 2. 建立一個「靜態方法 (static)」
        // 這樣你在別的地方只要打 DBHelper.GetDataTable(...) 就可以直接用，不用 new DBHelper()
        internal static DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        //params 的主要作用是提供一種 「語法糖 (Syntactic Sugar)」，讓你在呼叫方法時，可以更彈性、更簡潔地傳遞參數。
        //它的功能是：
        //1. 接受陣列：你可以傳遞一個完整的 SqlParameter[] 陣列給它。
        //2. 接受多個單獨參數：你也可以直接傳遞多個單獨的 SqlParameter 實例，C# 編譯器會自動幫你把這些單獨的參數包裝成一個陣列。
        //3. 接受零個參數：你也可以不傳任何東西，此時 C# 會傳遞一個長度為零的空陣列。
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 如果有參數 (例如 @PID)，就加進去
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // 使用 DataAdapter 自動開關連線並填入資料
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // 發生錯誤時跳出視窗
                MessageBox.Show("資料庫讀取錯誤：\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 回傳空的 DataTable 防止程式崩潰
                return new DataTable();
            }

            return dt;
        }


        /// <summary>
        /// 執行 SQL 查詢並回傳第一行第一列的值 (例如 SELECT COUNT(*) 或 SCOPE_IDENTITY())
        /// </summary>
        /// <param name="sql">要執行的 SQL 語句</param>
        /// <param name="parameters">SQL 參數</param>
        /// <returns>回傳一個 object，需要轉型</returns>
        internal static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            object result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Clear();
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        conn.Open(); // ExecuteScalar 需要手動開啟連線
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExecuteScalar 執行失敗：\n" + ex.Message, "錯誤");
            }
            return result;
        }

        /// <summary>
        /// 執行 INSERT, UPDATE, DELETE 等非查詢語句
        /// </summary>
        /// <param name="sql">要執行的 SQL 語句</param>
        /// <param name="parameters">SQL 參數</param>
        /// <returns>回傳受影響的行數</returns>
        internal static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Clear();
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        conn.Open();
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExecuteNonQuery 執行失敗：\n" + ex.Message, "錯誤");
            }
            return affectedRows;
        }
        internal static string GetPokemonNameByID(int id)
        {
            DataTable dt = DBHelper.GetDataTable("SELECT Name_CH FROM PokemonData WHERE PokemonID = @ID", new SqlParameter("@ID", id));
            return dt.Rows.Count > 0 ? dt.Rows[0]["Name_CH"].ToString() : "Unknown";
        }
        internal static void DeleteTeam(int deleteTeamID)
        {

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string sqlDelMembers = "DELETE FROM TeamMember WHERE TeamID = @ID";
                    string sqlDelTeam = "DELETE FROM Team WHERE TeamID = @ID";

                    // 每次執行都給它一個新的 SqlParameter 物件
                    using (SqlCommand cmd1 = new SqlCommand(sqlDelMembers, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@ID", deleteTeamID);
                        cmd1.ExecuteNonQuery();
                    }

                    // 4. 執行第二個指令
                    using (SqlCommand cmd2 = new SqlCommand(sqlDelTeam, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@ID", deleteTeamID);
                        cmd2.ExecuteNonQuery();
                    }

                    MessageBox.Show("隊伍已刪除");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("ExecuteNonQuery 執行失敗：\n" + ex.Message, "錯誤");
                }

            }
        }
    }
}
