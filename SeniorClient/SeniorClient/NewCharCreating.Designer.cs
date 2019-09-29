namespace SeniorClient
{
    partial class NewCharCreating
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
            this.label1 = new System.Windows.Forms.Label();
            this.raceBox = new System.Windows.Forms.ComboBox();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.CharRaceLabel = new System.Windows.Forms.Label();
            this.CharClassLabel = new System.Windows.Forms.Label();
            this.FirstChoiceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To begin, select your characters race and class. Give them a name too!";
            // 
            // raceBox
            // 
            this.raceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceBox.FormattingEnabled = true;
            this.raceBox.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Halfling",
            "Human",
            "Dragonborn",
            "Gnome",
            "Half-Elf",
            "Half-Orc",
            "Tiefling"});
            this.raceBox.Location = new System.Drawing.Point(58, 177);
            this.raceBox.Name = "raceBox";
            this.raceBox.Size = new System.Drawing.Size(121, 21);
            this.raceBox.TabIndex = 1;
            // 
            // classBox
            // 
            this.classBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classBox.FormattingEnabled = true;
            this.classBox.Items.AddRange(new object[] {
            "Bard",
            "Barbarian",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Warlock",
            "Wizard"});
            this.classBox.Location = new System.Drawing.Point(233, 177);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(121, 21);
            this.classBox.TabIndex = 2;
            // 
            // CharRaceLabel
            // 
            this.CharRaceLabel.AutoSize = true;
            this.CharRaceLabel.Location = new System.Drawing.Point(100, 156);
            this.CharRaceLabel.Name = "CharRaceLabel";
            this.CharRaceLabel.Size = new System.Drawing.Size(33, 13);
            this.CharRaceLabel.TabIndex = 3;
            this.CharRaceLabel.Text = "Race";
            // 
            // CharClassLabel
            // 
            this.CharClassLabel.AutoSize = true;
            this.CharClassLabel.Location = new System.Drawing.Point(281, 156);
            this.CharClassLabel.Name = "CharClassLabel";
            this.CharClassLabel.Size = new System.Drawing.Size(32, 13);
            this.CharClassLabel.TabIndex = 4;
            this.CharClassLabel.Text = "Class";
            // 
            // FirstChoiceButton
            // 
            this.FirstChoiceButton.Location = new System.Drawing.Point(172, 273);
            this.FirstChoiceButton.Name = "FirstChoiceButton";
            this.FirstChoiceButton.Size = new System.Drawing.Size(75, 23);
            this.FirstChoiceButton.TabIndex = 5;
            this.FirstChoiceButton.Text = "Continue";
            this.FirstChoiceButton.UseVisualStyleBackColor = true;
            this.FirstChoiceButton.Click += new System.EventHandler(this.FirstChoiceButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(157, 226);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 7;
            // 
            // NewCharCreating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 321);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FirstChoiceButton);
            this.Controls.Add(this.CharClassLabel);
            this.Controls.Add(this.CharRaceLabel);
            this.Controls.Add(this.classBox);
            this.Controls.Add(this.raceBox);
            this.Controls.Add(this.label1);
            this.Name = "NewCharCreating";
            this.Text = "New Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox raceBox;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.Label CharRaceLabel;
        private System.Windows.Forms.Label CharClassLabel;
        private System.Windows.Forms.Button FirstChoiceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
    }
}