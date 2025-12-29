using PokemonPartySimulator.Data_Access_Layer;
using PokemonPartySimulator.Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PokemonPartySimulator.Business_Logic_Layer
{
    internal static class TeamManager
    {
        // 查寶可夢名字 (UI 顯示需要，但 TeamMember 表沒存)
        internal static string GetPokemonNameByID(int id)
        {
            string sql = "SELECT Name_CH FROM PokemonData WHERE PokemonID = @ID";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter("@ID", id));
            return dt.Rows.Count > 0 ? dt.Rows[0]["Name_CH"].ToString() : "Unknown";
        }

        // 查招式名字
        internal static string GetMoveNameByID(int id)
        {
            if (id == 0) return "(無)";
            string sql = "SELECT Name_CH FROM Move WHERE MoveID = @ID";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter("@ID", id));
            return dt.Rows.Count > 0 ? dt.Rows[0]["Name_CH"].ToString() : "Error";
        }

        // 查隊伍名
        internal static string GetTeamNameByID(int id)
        {
            string sql = "SELECT TeamName FROM Team WHERE TeamID = @ID";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter("@ID", id));
            return dt.Rows.Count > 0 ? dt.Rows[0]["TeamName"].ToString() : "Unknown";
        }

        // 一次抓出整個隊伍的「物件化」資料
        internal static List<TeamMember> GetTeamMembers(int teamID)
        {
            List<TeamMember> list = new List<TeamMember>();
            string sql = "SELECT * FROM TeamMember WHERE TeamID = @ID ORDER BY SlotIndex";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter("@ID", teamID));

            foreach (DataRow row in dt.Rows)
            {
                // 使用 SqlMapper 進行翻譯 (DataRow -> 物件)
                TeamMember member = SqlMapper.ToTeamMember(row);
                // 補上物件沒存的名字
                member.Name = GetPokemonNameByID(member.PokemonID);
                list.Add(member);
            }
            return list;
        }
        // 修改後的 SaveTeam，接收：隊伍名稱, 舊 ID (如有), 成員清單
        internal static int SaveTeam(string teamName, int? loadedTeamID, TeamMember[] members)
        {
            int teamIDToUse = -1;
            string connStr = Properties.Settings.Default.PokemonPartySimulatorConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. 處理 Team 主表
                    if (loadedTeamID.HasValue)
                    {
                        // 【編輯模式】
                        string sqlUpdateTeam = "UPDATE Team SET TeamName = @Name WHERE TeamID = @TID";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdateTeam, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", teamName);
                            cmd.Parameters.AddWithValue("@TID", loadedTeamID.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 刪除舊成員
                        string sqlDeleteMembers = "DELETE FROM TeamMember WHERE TeamID = @TID";
                        using (SqlCommand cmd = new SqlCommand(sqlDeleteMembers, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TID", loadedTeamID.Value);
                            cmd.ExecuteNonQuery();
                        }
                        teamIDToUse = loadedTeamID.Value;
                    }
                    else
                    {
                        // 【新增模式】
                        string sqlInsertTeam = "INSERT INTO Team (TeamName, CreatedDate) VALUES (@Name, GETDATE()); SELECT SCOPE_IDENTITY();";
                        using (SqlCommand cmd = new SqlCommand(sqlInsertTeam, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", teamName);
                            object result = cmd.ExecuteScalar();
                            teamIDToUse = Convert.ToInt32(result);
                        }
                    }

                    // 2. 處理成員表 (寫入新數據)
                    string sqlInsertMember = @"
                INSERT INTO TeamMember (TeamID, SlotIndex, PokemonID, Move1_ID, Move2_ID, Move3_ID, Move4_ID, Item, Ability) 
                VALUES (@TeamID, @SlotIndex, @PID, @M1, @M2, @M3, @M4, @Item, @Ability);";

                    foreach (var m in members)
                    {
                        // 排除空位
                        if (m == null || m.PokemonID <= 0) continue;

                        using (SqlCommand cmd = new SqlCommand(sqlInsertMember, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TeamID", teamIDToUse);
                            cmd.Parameters.AddWithValue("@SlotIndex", m.SlotIndex);
                            cmd.Parameters.AddWithValue("@PID", m.PokemonID);
                            cmd.Parameters.AddWithValue("@M1", m.Move1_ID);
                            cmd.Parameters.AddWithValue("@M2", m.Move2_ID);
                            cmd.Parameters.AddWithValue("@M3", m.Move3_ID);
                            cmd.Parameters.AddWithValue("@M4", m.Move4_ID);
                            cmd.Parameters.AddWithValue("@Item", (object)m.ItemID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Ability", (object)m.AbilityID ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return teamIDToUse;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // 這裡不跳 MessageBox，而是把錯誤丟回去給 UI 層處理
                    throw new Exception("資料庫交易失敗，已回溯資料。詳細原因：" + ex.Message);
                }
            }
        }

        // 1. 回傳型別改為 Pokemon 物件
        internal static Pokemon GetPokemonByID(int id)
        {
            string sql = "SELECT * FROM PokemonData WHERE PokemonID = @ID";
            DataTable dt = DBHelper.GetDataTable(sql, new SqlParameter("@ID", id));

            if (dt.Rows.Count > 0)
            {
                // 2. 使用你的翻譯官 (SqlMapper) 將這一列資料轉成完整的物件
                // 這樣你拿到的物件裡面就有：名字、Type1、Type2、種族值等所有資訊
                return SqlMapper.ToPokemon(dt.Rows[0]);
            }

            return null; // 找不到就回傳 null
        }
    }
}