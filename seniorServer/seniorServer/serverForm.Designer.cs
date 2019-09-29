namespace seniorServer
{
    partial class serverForm
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
            this.playersBox = new System.Windows.Forms.CheckedListBox();
            this.chatReadBox = new System.Windows.Forms.TextBox();
            this.sendChatBtn = new System.Windows.Forms.Button();
            this.chatTypeBox = new System.Windows.Forms.TextBox();
            this.playerCount = new System.Windows.Forms.Label();
            this.sendStuffBtn = new System.Windows.Forms.Button();
            this.sendingBox = new System.Windows.Forms.ComboBox();
            this.resourceLabel = new System.Windows.Forms.Label();
            this.directLabel = new System.Windows.Forms.Label();
            this.directNumber = new System.Windows.Forms.TextBox();
            this.diceLabel = new System.Windows.Forms.Label();
            this.diceRollDice = new System.Windows.Forms.TextBox();
            this.diceRollSides = new System.Windows.Forms.TextBox();
            this.dLabel = new System.Windows.Forms.Label();
            this.checkTypeBox = new System.Windows.Forms.ComboBox();
            this.checkText = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.itemNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemDamDice = new System.Windows.Forms.TextBox();
            this.itemDamNumb = new System.Windows.Forms.TextBox();
            this.itemDamage = new System.Windows.Forms.Label();
            this.armorTextBox = new System.Windows.Forms.TextBox();
            this.armorLabel = new System.Windows.Forms.Label();
            this.dexBasedCheck = new System.Windows.Forms.CheckBox();
            this.sendItem = new System.Windows.Forms.Button();
            this.rollDieBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.modLabel = new System.Windows.Forms.Label();
            this.modTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // playersBox
            // 
            this.playersBox.FormattingEnabled = true;
            this.playersBox.Location = new System.Drawing.Point(401, 349);
            this.playersBox.Name = "playersBox";
            this.playersBox.Size = new System.Drawing.Size(120, 94);
            this.playersBox.TabIndex = 0;
            // 
            // chatReadBox
            // 
            this.chatReadBox.Location = new System.Drawing.Point(12, 349);
            this.chatReadBox.Multiline = true;
            this.chatReadBox.Name = "chatReadBox";
            this.chatReadBox.ReadOnly = true;
            this.chatReadBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatReadBox.Size = new System.Drawing.Size(383, 65);
            this.chatReadBox.TabIndex = 1;
            // 
            // sendChatBtn
            // 
            this.sendChatBtn.Location = new System.Drawing.Point(320, 420);
            this.sendChatBtn.Name = "sendChatBtn";
            this.sendChatBtn.Size = new System.Drawing.Size(75, 23);
            this.sendChatBtn.TabIndex = 2;
            this.sendChatBtn.Text = "Chat";
            this.sendChatBtn.UseVisualStyleBackColor = true;
            this.sendChatBtn.Click += new System.EventHandler(this.sendChatBtn_Click);
            // 
            // chatTypeBox
            // 
            this.chatTypeBox.Location = new System.Drawing.Point(12, 422);
            this.chatTypeBox.Name = "chatTypeBox";
            this.chatTypeBox.Size = new System.Drawing.Size(302, 20);
            this.chatTypeBox.TabIndex = 3;
            // 
            // playerCount
            // 
            this.playerCount.AutoSize = true;
            this.playerCount.Location = new System.Drawing.Point(12, 13);
            this.playerCount.Name = "playerCount";
            this.playerCount.Size = new System.Drawing.Size(0, 13);
            this.playerCount.TabIndex = 4;
            // 
            // sendStuffBtn
            // 
            this.sendStuffBtn.Location = new System.Drawing.Point(259, 261);
            this.sendStuffBtn.Name = "sendStuffBtn";
            this.sendStuffBtn.Size = new System.Drawing.Size(120, 23);
            this.sendStuffBtn.TabIndex = 5;
            this.sendStuffBtn.Text = "Send to players";
            this.sendStuffBtn.UseVisualStyleBackColor = true;
            this.sendStuffBtn.Click += new System.EventHandler(this.sendStuffBtn_Click);
            // 
            // sendingBox
            // 
            this.sendingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sendingBox.FormattingEnabled = true;
            this.sendingBox.Items.AddRange(new object[] {
            "Damage",
            "Healing",
            "Experience Points",
            "Gold",
            "Check"});
            this.sendingBox.Location = new System.Drawing.Point(12, 262);
            this.sendingBox.Name = "sendingBox";
            this.sendingBox.Size = new System.Drawing.Size(121, 21);
            this.sendingBox.TabIndex = 6;
            // 
            // resourceLabel
            // 
            this.resourceLabel.AutoSize = true;
            this.resourceLabel.Location = new System.Drawing.Point(32, 246);
            this.resourceLabel.Name = "resourceLabel";
            this.resourceLabel.Size = new System.Drawing.Size(72, 13);
            this.resourceLabel.TabIndex = 7;
            this.resourceLabel.Text = "Thing to send";
            // 
            // directLabel
            // 
            this.directLabel.AutoSize = true;
            this.directLabel.Location = new System.Drawing.Point(164, 246);
            this.directLabel.Name = "directLabel";
            this.directLabel.Size = new System.Drawing.Size(75, 13);
            this.directLabel.TabIndex = 8;
            this.directLabel.Text = "Direct Number";
            // 
            // directNumber
            // 
            this.directNumber.Location = new System.Drawing.Point(149, 263);
            this.directNumber.Name = "directNumber";
            this.directNumber.Size = new System.Drawing.Size(100, 20);
            this.directNumber.TabIndex = 9;
            // 
            // diceLabel
            // 
            this.diceLabel.AutoSize = true;
            this.diceLabel.Location = new System.Drawing.Point(47, 32);
            this.diceLabel.Name = "diceLabel";
            this.diceLabel.Size = new System.Drawing.Size(50, 13);
            this.diceLabel.TabIndex = 10;
            this.diceLabel.Text = "Dice Roll";
            // 
            // diceRollDice
            // 
            this.diceRollDice.Location = new System.Drawing.Point(31, 48);
            this.diceRollDice.Name = "diceRollDice";
            this.diceRollDice.Size = new System.Drawing.Size(30, 20);
            this.diceRollDice.TabIndex = 11;
            // 
            // diceRollSides
            // 
            this.diceRollSides.Location = new System.Drawing.Point(88, 48);
            this.diceRollSides.Name = "diceRollSides";
            this.diceRollSides.Size = new System.Drawing.Size(30, 20);
            this.diceRollSides.TabIndex = 12;
            // 
            // dLabel
            // 
            this.dLabel.AutoSize = true;
            this.dLabel.Location = new System.Drawing.Point(67, 52);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(15, 13);
            this.dLabel.TabIndex = 13;
            this.dLabel.Text = "D";
            // 
            // checkTypeBox
            // 
            this.checkTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkTypeBox.FormattingEnabled = true;
            this.checkTypeBox.Items.AddRange(new object[] {
            "Athletics",
            "Strength Saving Throw",
            "Acrobatics",
            "Sleight of Hand",
            "Stealth",
            "Dexterity Saving Throw",
            "Constitution Saving Throw",
            "Arcana",
            "History",
            "Nature",
            "Religion",
            "Intelligence Saving Throw",
            "Animal Handling",
            "Insight",
            "Medicine",
            "Perception",
            "Survival",
            "Wisdom Saving Throw",
            "Deception",
            "Intimidation",
            "Performance",
            "Persusasion",
            "Charisma Saving Throw"});
            this.checkTypeBox.Location = new System.Drawing.Point(12, 309);
            this.checkTypeBox.Name = "checkTypeBox";
            this.checkTypeBox.Size = new System.Drawing.Size(121, 21);
            this.checkTypeBox.TabIndex = 16;
            // 
            // checkText
            // 
            this.checkText.AutoSize = true;
            this.checkText.Location = new System.Drawing.Point(32, 293);
            this.checkText.Name = "checkText";
            this.checkText.Size = new System.Drawing.Size(65, 13);
            this.checkText.TabIndex = 17;
            this.checkText.Text = "Check Type";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(32, 186);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(58, 13);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Item Name";
            // 
            // itemNameText
            // 
            this.itemNameText.Location = new System.Drawing.Point(15, 202);
            this.itemNameText.Name = "itemNameText";
            this.itemNameText.Size = new System.Drawing.Size(100, 20);
            this.itemNameText.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "D";
            // 
            // itemDamDice
            // 
            this.itemDamDice.Location = new System.Drawing.Point(206, 202);
            this.itemDamDice.Name = "itemDamDice";
            this.itemDamDice.Size = new System.Drawing.Size(30, 20);
            this.itemDamDice.TabIndex = 22;
            // 
            // itemDamNumb
            // 
            this.itemDamNumb.Location = new System.Drawing.Point(149, 202);
            this.itemDamNumb.Name = "itemDamNumb";
            this.itemDamNumb.Size = new System.Drawing.Size(30, 20);
            this.itemDamNumb.TabIndex = 21;
            // 
            // itemDamage
            // 
            this.itemDamage.AutoSize = true;
            this.itemDamage.Location = new System.Drawing.Point(164, 186);
            this.itemDamage.Name = "itemDamage";
            this.itemDamage.Size = new System.Drawing.Size(70, 13);
            this.itemDamage.TabIndex = 24;
            this.itemDamage.Text = "Item Damage";
            // 
            // armorTextBox
            // 
            this.armorTextBox.Location = new System.Drawing.Point(259, 202);
            this.armorTextBox.Name = "armorTextBox";
            this.armorTextBox.Size = new System.Drawing.Size(100, 20);
            this.armorTextBox.TabIndex = 26;
            this.armorTextBox.Text = "0";
            // 
            // armorLabel
            // 
            this.armorLabel.AutoSize = true;
            this.armorLabel.Location = new System.Drawing.Point(288, 186);
            this.armorLabel.Name = "armorLabel";
            this.armorLabel.Size = new System.Drawing.Size(34, 13);
            this.armorLabel.TabIndex = 25;
            this.armorLabel.Text = "Armor";
            // 
            // dexBasedCheck
            // 
            this.dexBasedCheck.AutoSize = true;
            this.dexBasedCheck.Location = new System.Drawing.Point(365, 202);
            this.dexBasedCheck.Name = "dexBasedCheck";
            this.dexBasedCheck.Size = new System.Drawing.Size(106, 17);
            this.dexBasedCheck.TabIndex = 27;
            this.dexBasedCheck.Text = "Dexterity Based?";
            this.dexBasedCheck.UseVisualStyleBackColor = true;
            // 
            // sendItem
            // 
            this.sendItem.Location = new System.Drawing.Point(477, 199);
            this.sendItem.Name = "sendItem";
            this.sendItem.Size = new System.Drawing.Size(87, 23);
            this.sendItem.TabIndex = 28;
            this.sendItem.Text = "Send Item";
            this.sendItem.UseVisualStyleBackColor = true;
            this.sendItem.Click += new System.EventHandler(this.sendItem_Click);
            // 
            // rollDieBtn
            // 
            this.rollDieBtn.Location = new System.Drawing.Point(35, 74);
            this.rollDieBtn.Name = "rollDieBtn";
            this.rollDieBtn.Size = new System.Drawing.Size(75, 23);
            this.rollDieBtn.TabIndex = 29;
            this.rollDieBtn.Text = "Roll Dice";
            this.rollDieBtn.UseVisualStyleBackColor = true;
            this.rollDieBtn.Click += new System.EventHandler(this.rollDieBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(315, 125);
            this.textBox1.TabIndex = 30;
            // 
            // NotesLabel
            // 
            this.NotesLabel.AutoSize = true;
            this.NotesLabel.Location = new System.Drawing.Point(250, 10);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(71, 13);
            this.NotesLabel.TabIndex = 31;
            this.NotesLabel.Text = "Private Notes";
            // 
            // modLabel
            // 
            this.modLabel.AutoSize = true;
            this.modLabel.Location = new System.Drawing.Point(164, 32);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(44, 13);
            this.modLabel.TabIndex = 32;
            this.modLabel.Text = "Modifier";
            // 
            // modTextBox
            // 
            this.modTextBox.Location = new System.Drawing.Point(170, 52);
            this.modTextBox.Name = "modTextBox";
            this.modTextBox.Size = new System.Drawing.Size(30, 20);
            this.modTextBox.TabIndex = 33;
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 455);
            this.Controls.Add(this.modTextBox);
            this.Controls.Add(this.modLabel);
            this.Controls.Add(this.NotesLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rollDieBtn);
            this.Controls.Add(this.sendItem);
            this.Controls.Add(this.dexBasedCheck);
            this.Controls.Add(this.armorTextBox);
            this.Controls.Add(this.armorLabel);
            this.Controls.Add(this.itemDamage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemDamDice);
            this.Controls.Add(this.itemDamNumb);
            this.Controls.Add(this.itemNameText);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.checkText);
            this.Controls.Add(this.checkTypeBox);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.diceRollSides);
            this.Controls.Add(this.diceRollDice);
            this.Controls.Add(this.diceLabel);
            this.Controls.Add(this.directNumber);
            this.Controls.Add(this.directLabel);
            this.Controls.Add(this.resourceLabel);
            this.Controls.Add(this.sendingBox);
            this.Controls.Add(this.sendStuffBtn);
            this.Controls.Add(this.playerCount);
            this.Controls.Add(this.chatTypeBox);
            this.Controls.Add(this.sendChatBtn);
            this.Controls.Add(this.chatReadBox);
            this.Controls.Add(this.playersBox);
            this.Name = "serverForm";
            this.Text = "Server Form";
            this.Load += new System.EventHandler(this.serverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox playersBox;
        private System.Windows.Forms.TextBox chatReadBox;
        private System.Windows.Forms.Button sendChatBtn;
        private System.Windows.Forms.TextBox chatTypeBox;
        private System.Windows.Forms.Label playerCount;
        private System.Windows.Forms.Button sendStuffBtn;
        private System.Windows.Forms.ComboBox sendingBox;
        private System.Windows.Forms.Label resourceLabel;
        private System.Windows.Forms.Label directLabel;
        private System.Windows.Forms.TextBox directNumber;
        private System.Windows.Forms.Label diceLabel;
        private System.Windows.Forms.TextBox diceRollDice;
        private System.Windows.Forms.TextBox diceRollSides;
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.ComboBox checkTypeBox;
        private System.Windows.Forms.Label checkText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox itemNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemDamDice;
        private System.Windows.Forms.TextBox itemDamNumb;
        private System.Windows.Forms.Label itemDamage;
        private System.Windows.Forms.TextBox armorTextBox;
        private System.Windows.Forms.Label armorLabel;
        private System.Windows.Forms.CheckBox dexBasedCheck;
        private System.Windows.Forms.Button sendItem;
        private System.Windows.Forms.Button rollDieBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label NotesLabel;
        private System.Windows.Forms.Label modLabel;
        private System.Windows.Forms.TextBox modTextBox;
    }
}

