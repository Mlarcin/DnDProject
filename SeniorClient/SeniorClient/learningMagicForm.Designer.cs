namespace SeniorClient
{
    partial class learningMagicForm
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
            this.FlavorLabel = new System.Windows.Forms.Label();
            this.spellBox = new System.Windows.Forms.ComboBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.learnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FlavorLabel
            // 
            this.FlavorLabel.AutoSize = true;
            this.FlavorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlavorLabel.Location = new System.Drawing.Point(12, 51);
            this.FlavorLabel.Name = "FlavorLabel";
            this.FlavorLabel.Size = new System.Drawing.Size(493, 20);
            this.FlavorLabel.TabIndex = 0;
            this.FlavorLabel.Text = "Your mastery of magic grows, allowing you to learn more incantations";
            // 
            // spellBox
            // 
            this.spellBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellBox.FormattingEnabled = true;
            this.spellBox.Location = new System.Drawing.Point(57, 109);
            this.spellBox.Name = "spellBox";
            this.spellBox.Size = new System.Drawing.Size(121, 21);
            this.spellBox.TabIndex = 1;
            this.spellBox.SelectedValueChanged += new System.EventHandler(this.spellBox_SelectedValueChanged);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(225, 109);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionBox.Size = new System.Drawing.Size(256, 150);
            this.DescriptionBox.TabIndex = 2;
            // 
            // learnButton
            // 
            this.learnButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.learnButton.Location = new System.Drawing.Point(71, 190);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(79, 26);
            this.learnButton.TabIndex = 3;
            this.learnButton.Text = "Learn Magic!";
            this.learnButton.UseVisualStyleBackColor = true;
            this.learnButton.Click += new System.EventHandler(this.learnButton_Click);
            // 
            // learningMagicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 296);
            this.Controls.Add(this.learnButton);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.spellBox);
            this.Controls.Add(this.FlavorLabel);
            this.Name = "learningMagicForm";
            this.Text = "learningMagicForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FlavorLabel;
        private System.Windows.Forms.ComboBox spellBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Button learnButton;
    }
}