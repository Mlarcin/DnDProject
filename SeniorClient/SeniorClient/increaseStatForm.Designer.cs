namespace SeniorClient
{
    partial class increaseStatForm
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
            this.selectLabel = new System.Windows.Forms.Label();
            this.statBox1 = new System.Windows.Forms.ComboBox();
            this.statBox2 = new System.Windows.Forms.ComboBox();
            this.firstChoice = new System.Windows.Forms.Label();
            this.secondchoice = new System.Windows.Forms.Label();
            this.sendStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(118, 77);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(182, 13);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Select the stats you\'d like to increase";
            // 
            // statBox1
            // 
            this.statBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statBox1.FormattingEnabled = true;
            this.statBox1.Items.AddRange(new object[] {
            "Strength",
            "Dexterity",
            "Constitution",
            "Wisdom",
            "Intelligence",
            "Charisma"});
            this.statBox1.Location = new System.Drawing.Point(61, 174);
            this.statBox1.Name = "statBox1";
            this.statBox1.Size = new System.Drawing.Size(121, 21);
            this.statBox1.TabIndex = 1;
            // 
            // statBox2
            // 
            this.statBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statBox2.FormattingEnabled = true;
            this.statBox2.Items.AddRange(new object[] {
            "Strength",
            "Dexterity",
            "Constitution",
            "Wisdom",
            "Intelligence",
            "Charisma"});
            this.statBox2.Location = new System.Drawing.Point(222, 174);
            this.statBox2.Name = "statBox2";
            this.statBox2.Size = new System.Drawing.Size(121, 21);
            this.statBox2.TabIndex = 2;
            // 
            // firstChoice
            // 
            this.firstChoice.AutoSize = true;
            this.firstChoice.Location = new System.Drawing.Point(93, 145);
            this.firstChoice.Name = "firstChoice";
            this.firstChoice.Size = new System.Drawing.Size(62, 13);
            this.firstChoice.TabIndex = 3;
            this.firstChoice.Text = "First Choice";
            // 
            // secondchoice
            // 
            this.secondchoice.AutoSize = true;
            this.secondchoice.Location = new System.Drawing.Point(242, 145);
            this.secondchoice.Name = "secondchoice";
            this.secondchoice.Size = new System.Drawing.Size(80, 13);
            this.secondchoice.TabIndex = 4;
            this.secondchoice.Text = "Second Choice";
            // 
            // sendStats
            // 
            this.sendStats.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sendStats.Location = new System.Drawing.Point(166, 221);
            this.sendStats.Name = "sendStats";
            this.sendStats.Size = new System.Drawing.Size(75, 23);
            this.sendStats.TabIndex = 5;
            this.sendStats.Text = "Send Stats";
            this.sendStats.UseVisualStyleBackColor = true;
            this.sendStats.Click += new System.EventHandler(this.sendStats_Click);
            // 
            // increaseStatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 335);
            this.Controls.Add(this.sendStats);
            this.Controls.Add(this.secondchoice);
            this.Controls.Add(this.firstChoice);
            this.Controls.Add(this.statBox2);
            this.Controls.Add(this.statBox1);
            this.Controls.Add(this.selectLabel);
            this.Name = "increaseStatForm";
            this.Text = "increaseStatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.ComboBox statBox1;
        private System.Windows.Forms.ComboBox statBox2;
        private System.Windows.Forms.Label firstChoice;
        private System.Windows.Forms.Label secondchoice;
        private System.Windows.Forms.Button sendStats;
    }
}