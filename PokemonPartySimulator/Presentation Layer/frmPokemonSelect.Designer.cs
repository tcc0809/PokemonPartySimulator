namespace PokemonPartySimulator.Presentation_Layer
{
    partial class frmPokemonSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label pokemonIDLabel;
            System.Windows.Forms.Label name_ENLabel;
            System.Windows.Forms.Label name_CHLabel;
            System.Windows.Forms.Label type1Label;
            System.Windows.Forms.Label type2Label;
            System.Windows.Forms.Label base_TotalLabel;
            System.Windows.Forms.Label hPLabel;
            System.Windows.Forms.Label attackLabel;
            System.Windows.Forms.Label defenseLabel;
            System.Windows.Forms.Label specialLabel;
            System.Windows.Forms.Label speedLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPokemonSelect));
            this.pokemonIDTextBox = new System.Windows.Forms.TextBox();
            this.pokemonDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pokemonPartySimulatorDataSet = new PokemonPartySimulator.PokemonPartySimulatorDataSet();
            this.name_ENTextBox = new System.Windows.Forms.TextBox();
            this.name_CHTextBox = new System.Windows.Forms.TextBox();
            this.txtType1 = new System.Windows.Forms.TextBox();
            this.txtType2 = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.LayoutPanelPS = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxLarge = new System.Windows.Forms.PictureBox();
            this.imageListPokemon = new System.Windows.Forms.ImageList(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.pnlHP = new System.Windows.Forms.Panel();
            this.pnlATK = new System.Windows.Forms.Panel();
            this.pnlDEF = new System.Windows.Forms.Panel();
            this.pnlSP = new System.Windows.Forms.Panel();
            this.pnlSpeed = new System.Windows.Forms.Panel();
            this.labTotal = new System.Windows.Forms.Label();
            this.labHP = new System.Windows.Forms.Label();
            this.labATK = new System.Windows.Forms.Label();
            this.labDEF = new System.Windows.Forms.Label();
            this.labSP = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.pokemonDataTableAdapter = new PokemonPartySimulator.PokemonPartySimulatorDataSetTableAdapters.PokemonDataTableAdapter();
            this.btnJoinTeam = new System.Windows.Forms.Button();
            this.labLargeName = new System.Windows.Forms.Label();
            pokemonIDLabel = new System.Windows.Forms.Label();
            name_ENLabel = new System.Windows.Forms.Label();
            name_CHLabel = new System.Windows.Forms.Label();
            type1Label = new System.Windows.Forms.Label();
            type2Label = new System.Windows.Forms.Label();
            base_TotalLabel = new System.Windows.Forms.Label();
            hPLabel = new System.Windows.Forms.Label();
            attackLabel = new System.Windows.Forms.Label();
            defenseLabel = new System.Windows.Forms.Label();
            specialLabel = new System.Windows.Forms.Label();
            speedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPartySimulatorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // pokemonIDLabel
            // 
            pokemonIDLabel.AutoSize = true;
            pokemonIDLabel.Location = new System.Drawing.Point(841, 101);
            pokemonIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pokemonIDLabel.Name = "pokemonIDLabel";
            pokemonIDLabel.Size = new System.Drawing.Size(79, 16);
            pokemonIDLabel.TabIndex = 1;
            pokemonIDLabel.Text = "Pokemon ID:";
            // 
            // name_ENLabel
            // 
            name_ENLabel.AutoSize = true;
            name_ENLabel.Location = new System.Drawing.Point(841, 175);
            name_ENLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            name_ENLabel.Name = "name_ENLabel";
            name_ENLabel.Size = new System.Drawing.Size(65, 16);
            name_ENLabel.TabIndex = 3;
            name_ENLabel.Text = "Name EN:";
            // 
            // name_CHLabel
            // 
            name_CHLabel.AutoSize = true;
            name_CHLabel.Location = new System.Drawing.Point(841, 138);
            name_CHLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            name_CHLabel.Name = "name_CHLabel";
            name_CHLabel.Size = new System.Drawing.Size(65, 16);
            name_CHLabel.TabIndex = 5;
            name_CHLabel.Text = "Name CH:";
            // 
            // type1Label
            // 
            type1Label.AutoSize = true;
            type1Label.Location = new System.Drawing.Point(841, 212);
            type1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            type1Label.Name = "type1Label";
            type1Label.Size = new System.Drawing.Size(45, 16);
            type1Label.TabIndex = 7;
            type1Label.Text = "Type1:";
            // 
            // type2Label
            // 
            type2Label.AutoSize = true;
            type2Label.Location = new System.Drawing.Point(841, 249);
            type2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            type2Label.Name = "type2Label";
            type2Label.Size = new System.Drawing.Size(45, 16);
            type2Label.TabIndex = 9;
            type2Label.Text = "Type2:";
            // 
            // base_TotalLabel
            // 
            base_TotalLabel.AutoSize = true;
            base_TotalLabel.Location = new System.Drawing.Point(841, 288);
            base_TotalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            base_TotalLabel.Name = "base_TotalLabel";
            base_TotalLabel.Size = new System.Drawing.Size(68, 16);
            base_TotalLabel.TabIndex = 11;
            base_TotalLabel.Text = "Base Total:";
            // 
            // hPLabel
            // 
            hPLabel.AutoSize = true;
            hPLabel.Location = new System.Drawing.Point(841, 325);
            hPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            hPLabel.Name = "hPLabel";
            hPLabel.Size = new System.Drawing.Size(26, 16);
            hPLabel.TabIndex = 13;
            hPLabel.Text = "HP:";
            // 
            // attackLabel
            // 
            attackLabel.AutoSize = true;
            attackLabel.Location = new System.Drawing.Point(841, 362);
            attackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            attackLabel.Name = "attackLabel";
            attackLabel.Size = new System.Drawing.Size(45, 16);
            attackLabel.TabIndex = 15;
            attackLabel.Text = "Attack:";
            // 
            // defenseLabel
            // 
            defenseLabel.AutoSize = true;
            defenseLabel.Location = new System.Drawing.Point(841, 400);
            defenseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            defenseLabel.Name = "defenseLabel";
            defenseLabel.Size = new System.Drawing.Size(56, 16);
            defenseLabel.TabIndex = 17;
            defenseLabel.Text = "Defense:";
            // 
            // specialLabel
            // 
            specialLabel.AutoSize = true;
            specialLabel.Location = new System.Drawing.Point(841, 437);
            specialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            specialLabel.Name = "specialLabel";
            specialLabel.Size = new System.Drawing.Size(51, 16);
            specialLabel.TabIndex = 19;
            specialLabel.Text = "Special:";
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Location = new System.Drawing.Point(841, 474);
            speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new System.Drawing.Size(47, 16);
            speedLabel.TabIndex = 21;
            speedLabel.Text = "Speed:";
            // 
            // pokemonIDTextBox
            // 
            this.pokemonIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "PokemonID", true));
            this.pokemonIDTextBox.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pokemonIDTextBox.Location = new System.Drawing.Point(926, 97);
            this.pokemonIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pokemonIDTextBox.Name = "pokemonIDTextBox";
            this.pokemonIDTextBox.Size = new System.Drawing.Size(156, 27);
            this.pokemonIDTextBox.TabIndex = 2;
            // 
            // pokemonDataBindingSource
            // 
            this.pokemonDataBindingSource.DataMember = "PokemonData";
            this.pokemonDataBindingSource.DataSource = this.pokemonPartySimulatorDataSet;
            // 
            // pokemonPartySimulatorDataSet
            // 
            this.pokemonPartySimulatorDataSet.DataSetName = "PokemonPartySimulatorDataSet";
            this.pokemonPartySimulatorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // name_ENTextBox
            // 
            this.name_ENTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Name_EN", true));
            this.name_ENTextBox.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name_ENTextBox.Location = new System.Drawing.Point(926, 171);
            this.name_ENTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.name_ENTextBox.Name = "name_ENTextBox";
            this.name_ENTextBox.Size = new System.Drawing.Size(156, 27);
            this.name_ENTextBox.TabIndex = 4;
            // 
            // name_CHTextBox
            // 
            this.name_CHTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Name_CH", true));
            this.name_CHTextBox.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name_CHTextBox.Location = new System.Drawing.Point(926, 134);
            this.name_CHTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.name_CHTextBox.Name = "name_CHTextBox";
            this.name_CHTextBox.Size = new System.Drawing.Size(156, 27);
            this.name_CHTextBox.TabIndex = 6;
            // 
            // txtType1
            // 
            this.txtType1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Type1", true));
            this.txtType1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtType1.Location = new System.Drawing.Point(926, 208);
            this.txtType1.Margin = new System.Windows.Forms.Padding(4);
            this.txtType1.Name = "txtType1";
            this.txtType1.Size = new System.Drawing.Size(156, 27);
            this.txtType1.TabIndex = 8;
            // 
            // txtType2
            // 
            this.txtType2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Type2", true));
            this.txtType2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtType2.Location = new System.Drawing.Point(926, 245);
            this.txtType2.Margin = new System.Windows.Forms.Padding(4);
            this.txtType2.Name = "txtType2";
            this.txtType2.Size = new System.Drawing.Size(156, 27);
            this.txtType2.TabIndex = 10;
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(229, 112);
            this.cbType.Margin = new System.Windows.Forms.Padding(4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(170, 32);
            this.cbType.TabIndex = 23;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(68, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 40);
            this.label1.TabIndex = 26;
            this.label1.Text = "屬性選擇";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(68, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 40);
            this.label3.TabIndex = 28;
            this.label3.Text = "文字搜尋";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSearch.Location = new System.Drawing.Point(229, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 33);
            this.txtSearch.TabIndex = 29;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // LayoutPanelPS
            // 
            this.LayoutPanelPS.AutoScroll = true;
            this.LayoutPanelPS.Location = new System.Drawing.Point(71, 151);
            this.LayoutPanelPS.Name = "LayoutPanelPS";
            this.LayoutPanelPS.Size = new System.Drawing.Size(526, 345);
            this.LayoutPanelPS.TabIndex = 30;
            // 
            // pictureBoxLarge
            // 
            this.pictureBoxLarge.Location = new System.Drawing.Point(604, 151);
            this.pictureBoxLarge.Name = "pictureBoxLarge";
            this.pictureBoxLarge.Size = new System.Drawing.Size(212, 345);
            this.pictureBoxLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLarge.TabIndex = 31;
            this.pictureBoxLarge.TabStop = false;
            // 
            // imageListPokemon
            // 
            this.imageListPokemon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPokemon.ImageStream")));
            this.imageListPokemon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPokemon.Images.SetKeyName(0, "1.png");
            this.imageListPokemon.Images.SetKeyName(1, "2.png");
            this.imageListPokemon.Images.SetKeyName(2, "3.png");
            this.imageListPokemon.Images.SetKeyName(3, "4.png");
            this.imageListPokemon.Images.SetKeyName(4, "5.png");
            this.imageListPokemon.Images.SetKeyName(5, "6.png");
            this.imageListPokemon.Images.SetKeyName(6, "7.png");
            this.imageListPokemon.Images.SetKeyName(7, "8.png");
            this.imageListPokemon.Images.SetKeyName(8, "9.png");
            this.imageListPokemon.Images.SetKeyName(9, "10.png");
            this.imageListPokemon.Images.SetKeyName(10, "11.png");
            this.imageListPokemon.Images.SetKeyName(11, "12.png");
            this.imageListPokemon.Images.SetKeyName(12, "13.png");
            this.imageListPokemon.Images.SetKeyName(13, "14.png");
            this.imageListPokemon.Images.SetKeyName(14, "15.png");
            this.imageListPokemon.Images.SetKeyName(15, "16.png");
            this.imageListPokemon.Images.SetKeyName(16, "17.png");
            this.imageListPokemon.Images.SetKeyName(17, "18.png");
            this.imageListPokemon.Images.SetKeyName(18, "19.png");
            this.imageListPokemon.Images.SetKeyName(19, "20.png");
            this.imageListPokemon.Images.SetKeyName(20, "21.png");
            this.imageListPokemon.Images.SetKeyName(21, "22.png");
            this.imageListPokemon.Images.SetKeyName(22, "23.png");
            this.imageListPokemon.Images.SetKeyName(23, "24.png");
            this.imageListPokemon.Images.SetKeyName(24, "25.png");
            this.imageListPokemon.Images.SetKeyName(25, "26.png");
            this.imageListPokemon.Images.SetKeyName(26, "27.png");
            this.imageListPokemon.Images.SetKeyName(27, "28.png");
            this.imageListPokemon.Images.SetKeyName(28, "29.png");
            this.imageListPokemon.Images.SetKeyName(29, "30.png");
            this.imageListPokemon.Images.SetKeyName(30, "31.png");
            this.imageListPokemon.Images.SetKeyName(31, "32.png");
            this.imageListPokemon.Images.SetKeyName(32, "33.png");
            this.imageListPokemon.Images.SetKeyName(33, "34.png");
            this.imageListPokemon.Images.SetKeyName(34, "35.png");
            this.imageListPokemon.Images.SetKeyName(35, "36.png");
            this.imageListPokemon.Images.SetKeyName(36, "37.png");
            this.imageListPokemon.Images.SetKeyName(37, "38.png");
            this.imageListPokemon.Images.SetKeyName(38, "39.png");
            this.imageListPokemon.Images.SetKeyName(39, "40.png");
            this.imageListPokemon.Images.SetKeyName(40, "41.png");
            this.imageListPokemon.Images.SetKeyName(41, "42.png");
            this.imageListPokemon.Images.SetKeyName(42, "43.png");
            this.imageListPokemon.Images.SetKeyName(43, "44.png");
            this.imageListPokemon.Images.SetKeyName(44, "45.png");
            this.imageListPokemon.Images.SetKeyName(45, "46.png");
            this.imageListPokemon.Images.SetKeyName(46, "47.png");
            this.imageListPokemon.Images.SetKeyName(47, "48.png");
            this.imageListPokemon.Images.SetKeyName(48, "49.png");
            this.imageListPokemon.Images.SetKeyName(49, "50.png");
            this.imageListPokemon.Images.SetKeyName(50, "51.png");
            this.imageListPokemon.Images.SetKeyName(51, "52.png");
            this.imageListPokemon.Images.SetKeyName(52, "53.png");
            this.imageListPokemon.Images.SetKeyName(53, "54.png");
            this.imageListPokemon.Images.SetKeyName(54, "55.png");
            this.imageListPokemon.Images.SetKeyName(55, "56.png");
            this.imageListPokemon.Images.SetKeyName(56, "57.png");
            this.imageListPokemon.Images.SetKeyName(57, "58.png");
            this.imageListPokemon.Images.SetKeyName(58, "59.png");
            this.imageListPokemon.Images.SetKeyName(59, "60.png");
            this.imageListPokemon.Images.SetKeyName(60, "61.png");
            this.imageListPokemon.Images.SetKeyName(61, "62.png");
            this.imageListPokemon.Images.SetKeyName(62, "63.png");
            this.imageListPokemon.Images.SetKeyName(63, "64.png");
            this.imageListPokemon.Images.SetKeyName(64, "65.png");
            this.imageListPokemon.Images.SetKeyName(65, "66.png");
            this.imageListPokemon.Images.SetKeyName(66, "67.png");
            this.imageListPokemon.Images.SetKeyName(67, "68.png");
            this.imageListPokemon.Images.SetKeyName(68, "69.png");
            this.imageListPokemon.Images.SetKeyName(69, "70.png");
            this.imageListPokemon.Images.SetKeyName(70, "71.png");
            this.imageListPokemon.Images.SetKeyName(71, "72.png");
            this.imageListPokemon.Images.SetKeyName(72, "73.png");
            this.imageListPokemon.Images.SetKeyName(73, "74.png");
            this.imageListPokemon.Images.SetKeyName(74, "75.png");
            this.imageListPokemon.Images.SetKeyName(75, "76.png");
            this.imageListPokemon.Images.SetKeyName(76, "77.png");
            this.imageListPokemon.Images.SetKeyName(77, "78.png");
            this.imageListPokemon.Images.SetKeyName(78, "79.png");
            this.imageListPokemon.Images.SetKeyName(79, "80.png");
            this.imageListPokemon.Images.SetKeyName(80, "81.png");
            this.imageListPokemon.Images.SetKeyName(81, "82.png");
            this.imageListPokemon.Images.SetKeyName(82, "83.png");
            this.imageListPokemon.Images.SetKeyName(83, "84.png");
            this.imageListPokemon.Images.SetKeyName(84, "85.png");
            this.imageListPokemon.Images.SetKeyName(85, "86.png");
            this.imageListPokemon.Images.SetKeyName(86, "87.png");
            this.imageListPokemon.Images.SetKeyName(87, "88.png");
            this.imageListPokemon.Images.SetKeyName(88, "89.png");
            this.imageListPokemon.Images.SetKeyName(89, "90.png");
            this.imageListPokemon.Images.SetKeyName(90, "91.png");
            this.imageListPokemon.Images.SetKeyName(91, "92.png");
            this.imageListPokemon.Images.SetKeyName(92, "93.png");
            this.imageListPokemon.Images.SetKeyName(93, "94.png");
            this.imageListPokemon.Images.SetKeyName(94, "95.png");
            this.imageListPokemon.Images.SetKeyName(95, "96.png");
            this.imageListPokemon.Images.SetKeyName(96, "97.png");
            this.imageListPokemon.Images.SetKeyName(97, "98.png");
            this.imageListPokemon.Images.SetKeyName(98, "99.png");
            this.imageListPokemon.Images.SetKeyName(99, "100.png");
            this.imageListPokemon.Images.SetKeyName(100, "101.png");
            this.imageListPokemon.Images.SetKeyName(101, "102.png");
            this.imageListPokemon.Images.SetKeyName(102, "103.png");
            this.imageListPokemon.Images.SetKeyName(103, "104.png");
            this.imageListPokemon.Images.SetKeyName(104, "105.png");
            this.imageListPokemon.Images.SetKeyName(105, "106.png");
            this.imageListPokemon.Images.SetKeyName(106, "107.png");
            this.imageListPokemon.Images.SetKeyName(107, "108.png");
            this.imageListPokemon.Images.SetKeyName(108, "109.png");
            this.imageListPokemon.Images.SetKeyName(109, "110.png");
            this.imageListPokemon.Images.SetKeyName(110, "111.png");
            this.imageListPokemon.Images.SetKeyName(111, "112.png");
            this.imageListPokemon.Images.SetKeyName(112, "113.png");
            this.imageListPokemon.Images.SetKeyName(113, "114.png");
            this.imageListPokemon.Images.SetKeyName(114, "115.png");
            this.imageListPokemon.Images.SetKeyName(115, "116.png");
            this.imageListPokemon.Images.SetKeyName(116, "117.png");
            this.imageListPokemon.Images.SetKeyName(117, "118.png");
            this.imageListPokemon.Images.SetKeyName(118, "119.png");
            this.imageListPokemon.Images.SetKeyName(119, "120.png");
            this.imageListPokemon.Images.SetKeyName(120, "121.png");
            this.imageListPokemon.Images.SetKeyName(121, "122.png");
            this.imageListPokemon.Images.SetKeyName(122, "123.png");
            this.imageListPokemon.Images.SetKeyName(123, "124.png");
            this.imageListPokemon.Images.SetKeyName(124, "125.png");
            this.imageListPokemon.Images.SetKeyName(125, "126.png");
            this.imageListPokemon.Images.SetKeyName(126, "127.png");
            this.imageListPokemon.Images.SetKeyName(127, "128.png");
            this.imageListPokemon.Images.SetKeyName(128, "129.png");
            this.imageListPokemon.Images.SetKeyName(129, "130.png");
            this.imageListPokemon.Images.SetKeyName(130, "131.png");
            this.imageListPokemon.Images.SetKeyName(131, "132.png");
            this.imageListPokemon.Images.SetKeyName(132, "133.png");
            this.imageListPokemon.Images.SetKeyName(133, "134.png");
            this.imageListPokemon.Images.SetKeyName(134, "135.png");
            this.imageListPokemon.Images.SetKeyName(135, "136.png");
            this.imageListPokemon.Images.SetKeyName(136, "137.png");
            this.imageListPokemon.Images.SetKeyName(137, "138.png");
            this.imageListPokemon.Images.SetKeyName(138, "139.png");
            this.imageListPokemon.Images.SetKeyName(139, "140.png");
            this.imageListPokemon.Images.SetKeyName(140, "141.png");
            this.imageListPokemon.Images.SetKeyName(141, "142.png");
            this.imageListPokemon.Images.SetKeyName(142, "143.png");
            this.imageListPokemon.Images.SetKeyName(143, "144.png");
            this.imageListPokemon.Images.SetKeyName(144, "145.png");
            this.imageListPokemon.Images.SetKeyName(145, "146.png");
            this.imageListPokemon.Images.SetKeyName(146, "147.png");
            this.imageListPokemon.Images.SetKeyName(147, "148.png");
            this.imageListPokemon.Images.SetKeyName(148, "149.png");
            this.imageListPokemon.Images.SetKeyName(149, "150.png");
            this.imageListPokemon.Images.SetKeyName(150, "151.png");
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 1;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.Maroon;
            this.pnlTotal.Location = new System.Drawing.Point(926, 284);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(1, 23);
            this.pnlTotal.TabIndex = 32;
            // 
            // pnlHP
            // 
            this.pnlHP.BackColor = System.Drawing.Color.Maroon;
            this.pnlHP.Location = new System.Drawing.Point(926, 321);
            this.pnlHP.Name = "pnlHP";
            this.pnlHP.Size = new System.Drawing.Size(1, 23);
            this.pnlHP.TabIndex = 33;
            // 
            // pnlATK
            // 
            this.pnlATK.BackColor = System.Drawing.Color.Maroon;
            this.pnlATK.Location = new System.Drawing.Point(926, 358);
            this.pnlATK.Name = "pnlATK";
            this.pnlATK.Size = new System.Drawing.Size(1, 23);
            this.pnlATK.TabIndex = 34;
            // 
            // pnlDEF
            // 
            this.pnlDEF.BackColor = System.Drawing.Color.Maroon;
            this.pnlDEF.Location = new System.Drawing.Point(926, 396);
            this.pnlDEF.Name = "pnlDEF";
            this.pnlDEF.Size = new System.Drawing.Size(1, 23);
            this.pnlDEF.TabIndex = 35;
            // 
            // pnlSP
            // 
            this.pnlSP.BackColor = System.Drawing.Color.Maroon;
            this.pnlSP.Location = new System.Drawing.Point(926, 433);
            this.pnlSP.Name = "pnlSP";
            this.pnlSP.Size = new System.Drawing.Size(1, 23);
            this.pnlSP.TabIndex = 36;
            // 
            // pnlSpeed
            // 
            this.pnlSpeed.BackColor = System.Drawing.Color.Maroon;
            this.pnlSpeed.Location = new System.Drawing.Point(926, 470);
            this.pnlSpeed.Name = "pnlSpeed";
            this.pnlSpeed.Size = new System.Drawing.Size(1, 23);
            this.pnlSpeed.TabIndex = 37;
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.BackColor = System.Drawing.Color.Transparent;
            this.labTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Base_Total", true));
            this.labTotal.Location = new System.Drawing.Point(929, 288);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(0, 16);
            this.labTotal.TabIndex = 38;
            // 
            // labHP
            // 
            this.labHP.AutoSize = true;
            this.labHP.BackColor = System.Drawing.Color.Transparent;
            this.labHP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "HP", true));
            this.labHP.Location = new System.Drawing.Point(929, 325);
            this.labHP.Name = "labHP";
            this.labHP.Size = new System.Drawing.Size(0, 16);
            this.labHP.TabIndex = 39;
            // 
            // labATK
            // 
            this.labATK.AutoSize = true;
            this.labATK.BackColor = System.Drawing.Color.Transparent;
            this.labATK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Attack", true));
            this.labATK.Location = new System.Drawing.Point(929, 362);
            this.labATK.Name = "labATK";
            this.labATK.Size = new System.Drawing.Size(0, 16);
            this.labATK.TabIndex = 40;
            // 
            // labDEF
            // 
            this.labDEF.AutoSize = true;
            this.labDEF.BackColor = System.Drawing.Color.Transparent;
            this.labDEF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Defense", true));
            this.labDEF.Location = new System.Drawing.Point(929, 399);
            this.labDEF.Name = "labDEF";
            this.labDEF.Size = new System.Drawing.Size(0, 16);
            this.labDEF.TabIndex = 41;
            // 
            // labSP
            // 
            this.labSP.AutoSize = true;
            this.labSP.BackColor = System.Drawing.Color.Transparent;
            this.labSP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Special", true));
            this.labSP.Location = new System.Drawing.Point(929, 436);
            this.labSP.Name = "labSP";
            this.labSP.Size = new System.Drawing.Size(0, 16);
            this.labSP.TabIndex = 42;
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.BackColor = System.Drawing.Color.Transparent;
            this.labSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Speed", true));
            this.labSpeed.Location = new System.Drawing.Point(929, 473);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(0, 16);
            this.labSpeed.TabIndex = 43;
            // 
            // pokemonDataTableAdapter
            // 
            this.pokemonDataTableAdapter.ClearBeforeFill = true;
            // 
            // btnJoinTeam
            // 
            this.btnJoinTeam.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnJoinTeam.Location = new System.Drawing.Point(604, 502);
            this.btnJoinTeam.Name = "btnJoinTeam";
            this.btnJoinTeam.Size = new System.Drawing.Size(212, 60);
            this.btnJoinTeam.TabIndex = 44;
            this.btnJoinTeam.Text = "加入隊伍";
            this.btnJoinTeam.UseVisualStyleBackColor = true;
            this.btnJoinTeam.Click += new System.EventHandler(this.btnJoinTeam_Click);
            // 
            // labLargeName
            // 
            this.labLargeName.AutoSize = true;
            this.labLargeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pokemonDataBindingSource, "Name_CH", true));
            this.labLargeName.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labLargeName.Location = new System.Drawing.Point(620, 104);
            this.labLargeName.Name = "labLargeName";
            this.labLargeName.Size = new System.Drawing.Size(178, 30);
            this.labLargeName.TabIndex = 45;
            this.labLargeName.Text = "labLargeName";
            this.labLargeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPokemonSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1147, 600);
            this.Controls.Add(this.labLargeName);
            this.Controls.Add(this.btnJoinTeam);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.labSP);
            this.Controls.Add(this.labDEF);
            this.Controls.Add(this.labATK);
            this.Controls.Add(this.labHP);
            this.Controls.Add(this.labTotal);
            this.Controls.Add(this.pnlSpeed);
            this.Controls.Add(this.pnlSP);
            this.Controls.Add(this.pnlDEF);
            this.Controls.Add(this.pnlATK);
            this.Controls.Add(this.pnlHP);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.pictureBoxLarge);
            this.Controls.Add(this.LayoutPanelPS);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(pokemonIDLabel);
            this.Controls.Add(this.pokemonIDTextBox);
            this.Controls.Add(name_ENLabel);
            this.Controls.Add(this.name_ENTextBox);
            this.Controls.Add(name_CHLabel);
            this.Controls.Add(this.name_CHTextBox);
            this.Controls.Add(type1Label);
            this.Controls.Add(this.txtType1);
            this.Controls.Add(type2Label);
            this.Controls.Add(this.txtType2);
            this.Controls.Add(base_TotalLabel);
            this.Controls.Add(hPLabel);
            this.Controls.Add(attackLabel);
            this.Controls.Add(defenseLabel);
            this.Controls.Add(specialLabel);
            this.Controls.Add(speedLabel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPokemonSelect";
            this.Text = "frmPokemonSelect";
            this.Load += new System.EventHandler(this.frmPokemonSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pokemonDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPartySimulatorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLarge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PokemonPartySimulatorDataSet pokemonPartySimulatorDataSet;
        private System.Windows.Forms.BindingSource pokemonDataBindingSource;
        private PokemonPartySimulatorDataSetTableAdapters.PokemonDataTableAdapter pokemonDataTableAdapter;
        private System.Windows.Forms.TextBox pokemonIDTextBox;
        private System.Windows.Forms.TextBox name_ENTextBox;
        private System.Windows.Forms.TextBox name_CHTextBox;
        private System.Windows.Forms.TextBox txtType1;
        private System.Windows.Forms.TextBox txtType2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanelPS;
        private System.Windows.Forms.PictureBox pictureBoxLarge;
        private System.Windows.Forms.ImageList imageListPokemon;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Panel pnlHP;
        private System.Windows.Forms.Panel pnlATK;
        private System.Windows.Forms.Panel pnlDEF;
        private System.Windows.Forms.Panel pnlSP;
        private System.Windows.Forms.Panel pnlSpeed;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Label labHP;
        private System.Windows.Forms.Label labATK;
        private System.Windows.Forms.Label labDEF;
        private System.Windows.Forms.Label labSP;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Button btnJoinTeam;
        private System.Windows.Forms.Label labLargeName;
    }
}