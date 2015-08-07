namespace TileEditor
{
    partial class newClassForm
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
            this.skillPanel = new System.Windows.Forms.Panel();
            this.existingClassComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.staTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.agiTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dexTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.strTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.spellPanel = new System.Windows.Forms.Panel();
            this.swordCheckBox1 = new System.Windows.Forms.CheckBox();
            this.swordCheckBox2 = new System.Windows.Forms.CheckBox();
            this.daggerCheckBox = new System.Windows.Forms.CheckBox();
            this.staffCheckBox = new System.Windows.Forms.CheckBox();
            this.axeCheckBox1 = new System.Windows.Forms.CheckBox();
            this.heavyCheckBox = new System.Windows.Forms.CheckBox();
            this.mediumCheckBox = new System.Windows.Forms.CheckBox();
            this.lightCheckBox = new System.Windows.Forms.CheckBox();
            this.leatherCheckBox = new System.Windows.Forms.CheckBox();
            this.clothCheckBox = new System.Windows.Forms.CheckBox();
            this.axeCheckBox2 = new System.Windows.Forms.CheckBox();
            this.bowCheckBox = new System.Windows.Forms.CheckBox();
            this.harpCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // skillPanel
            // 
            this.skillPanel.Location = new System.Drawing.Point(17, 263);
            this.skillPanel.Name = "skillPanel";
            this.skillPanel.Size = new System.Drawing.Size(354, 408);
            this.skillPanel.TabIndex = 0;
            // 
            // existingClassComboBox
            // 
            this.existingClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.existingClassComboBox.FormattingEnabled = true;
            this.existingClassComboBox.Location = new System.Drawing.Point(766, 12);
            this.existingClassComboBox.Name = "existingClassComboBox";
            this.existingClassComboBox.Size = new System.Drawing.Size(256, 21);
            this.existingClassComboBox.TabIndex = 69;
            this.existingClassComboBox.TabStop = false;
            this.existingClassComboBox.SelectedIndexChanged += new System.EventHandler(this.existingClassComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1107, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Armor Equippable";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(1122, 10);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 64;
            this.newButton.TabStop = false;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1122, 193);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 63;
            this.removeButton.TabStop = false;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1122, 104);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 56;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(979, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Weapons Equippable";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Skills";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Sta";
            // 
            // staTextBox
            // 
            this.staTextBox.Location = new System.Drawing.Point(101, 205);
            this.staTextBox.Name = "staTextBox";
            this.staTextBox.Size = new System.Drawing.Size(41, 20);
            this.staTextBox.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Agi";
            // 
            // agiTextBox
            // 
            this.agiTextBox.Location = new System.Drawing.Point(101, 179);
            this.agiTextBox.Name = "agiTextBox";
            this.agiTextBox.Size = new System.Drawing.Size(41, 20);
            this.agiTextBox.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Dex";
            // 
            // dexTextBox
            // 
            this.dexTextBox.Location = new System.Drawing.Point(101, 153);
            this.dexTextBox.Name = "dexTextBox";
            this.dexTextBox.Size = new System.Drawing.Size(41, 20);
            this.dexTextBox.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Str";
            // 
            // strTextBox
            // 
            this.strTextBox.Location = new System.Drawing.Point(101, 127);
            this.strTextBox.Name = "strTextBox";
            this.strTextBox.Size = new System.Drawing.Size(41, 20);
            this.strTextBox.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Attributes 1 - 10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Name";
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Location = new System.Drawing.Point(101, 12);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(284, 20);
            this.classNameTextBox.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Spells";
            // 
            // spellPanel
            // 
            this.spellPanel.Location = new System.Drawing.Point(415, 263);
            this.spellPanel.Name = "spellPanel";
            this.spellPanel.Size = new System.Drawing.Size(371, 408);
            this.spellPanel.TabIndex = 72;
            // 
            // swordCheckBox1
            // 
            this.swordCheckBox1.AutoSize = true;
            this.swordCheckBox1.Location = new System.Drawing.Point(982, 264);
            this.swordCheckBox1.Name = "swordCheckBox1";
            this.swordCheckBox1.Size = new System.Drawing.Size(73, 17);
            this.swordCheckBox1.TabIndex = 73;
            this.swordCheckBox1.Text = "1H Sword";
            this.swordCheckBox1.UseVisualStyleBackColor = true;
            // 
            // swordCheckBox2
            // 
            this.swordCheckBox2.AutoSize = true;
            this.swordCheckBox2.Location = new System.Drawing.Point(982, 287);
            this.swordCheckBox2.Name = "swordCheckBox2";
            this.swordCheckBox2.Size = new System.Drawing.Size(73, 17);
            this.swordCheckBox2.TabIndex = 74;
            this.swordCheckBox2.Text = "2H Sword";
            this.swordCheckBox2.UseVisualStyleBackColor = true;
            // 
            // daggerCheckBox
            // 
            this.daggerCheckBox.AutoSize = true;
            this.daggerCheckBox.Location = new System.Drawing.Point(982, 310);
            this.daggerCheckBox.Name = "daggerCheckBox";
            this.daggerCheckBox.Size = new System.Drawing.Size(61, 17);
            this.daggerCheckBox.TabIndex = 75;
            this.daggerCheckBox.Text = "Dagger";
            this.daggerCheckBox.UseVisualStyleBackColor = true;
            // 
            // staffCheckBox
            // 
            this.staffCheckBox.AutoSize = true;
            this.staffCheckBox.Location = new System.Drawing.Point(982, 333);
            this.staffCheckBox.Name = "staffCheckBox";
            this.staffCheckBox.Size = new System.Drawing.Size(48, 17);
            this.staffCheckBox.TabIndex = 76;
            this.staffCheckBox.Text = "Staff";
            this.staffCheckBox.UseVisualStyleBackColor = true;
            // 
            // axeCheckBox1
            // 
            this.axeCheckBox1.AutoSize = true;
            this.axeCheckBox1.Location = new System.Drawing.Point(982, 356);
            this.axeCheckBox1.Name = "axeCheckBox1";
            this.axeCheckBox1.Size = new System.Drawing.Size(61, 17);
            this.axeCheckBox1.TabIndex = 77;
            this.axeCheckBox1.Text = "1H Axe";
            this.axeCheckBox1.UseVisualStyleBackColor = true;
            // 
            // heavyCheckBox
            // 
            this.heavyCheckBox.AutoSize = true;
            this.heavyCheckBox.Location = new System.Drawing.Point(1110, 264);
            this.heavyCheckBox.Name = "heavyCheckBox";
            this.heavyCheckBox.Size = new System.Drawing.Size(57, 17);
            this.heavyCheckBox.TabIndex = 78;
            this.heavyCheckBox.Text = "Heavy";
            this.heavyCheckBox.UseVisualStyleBackColor = true;
            // 
            // mediumCheckBox
            // 
            this.mediumCheckBox.AutoSize = true;
            this.mediumCheckBox.Location = new System.Drawing.Point(1110, 287);
            this.mediumCheckBox.Name = "mediumCheckBox";
            this.mediumCheckBox.Size = new System.Drawing.Size(63, 17);
            this.mediumCheckBox.TabIndex = 79;
            this.mediumCheckBox.Text = "Medium";
            this.mediumCheckBox.UseVisualStyleBackColor = true;
            // 
            // lightCheckBox
            // 
            this.lightCheckBox.AutoSize = true;
            this.lightCheckBox.Location = new System.Drawing.Point(1110, 310);
            this.lightCheckBox.Name = "lightCheckBox";
            this.lightCheckBox.Size = new System.Drawing.Size(49, 17);
            this.lightCheckBox.TabIndex = 80;
            this.lightCheckBox.Text = "Light";
            this.lightCheckBox.UseVisualStyleBackColor = true;
            // 
            // leatherCheckBox
            // 
            this.leatherCheckBox.AutoSize = true;
            this.leatherCheckBox.Location = new System.Drawing.Point(1110, 333);
            this.leatherCheckBox.Name = "leatherCheckBox";
            this.leatherCheckBox.Size = new System.Drawing.Size(62, 17);
            this.leatherCheckBox.TabIndex = 81;
            this.leatherCheckBox.Text = "Leather";
            this.leatherCheckBox.UseVisualStyleBackColor = true;
            // 
            // clothCheckBox
            // 
            this.clothCheckBox.AutoSize = true;
            this.clothCheckBox.Location = new System.Drawing.Point(1110, 356);
            this.clothCheckBox.Name = "clothCheckBox";
            this.clothCheckBox.Size = new System.Drawing.Size(50, 17);
            this.clothCheckBox.TabIndex = 82;
            this.clothCheckBox.Text = "Cloth";
            this.clothCheckBox.UseVisualStyleBackColor = true;
            // 
            // axeCheckBox2
            // 
            this.axeCheckBox2.AutoSize = true;
            this.axeCheckBox2.Location = new System.Drawing.Point(982, 379);
            this.axeCheckBox2.Name = "axeCheckBox2";
            this.axeCheckBox2.Size = new System.Drawing.Size(61, 17);
            this.axeCheckBox2.TabIndex = 83;
            this.axeCheckBox2.Text = "2H Axe";
            this.axeCheckBox2.UseVisualStyleBackColor = true;
            // 
            // bowCheckBox
            // 
            this.bowCheckBox.AutoSize = true;
            this.bowCheckBox.Location = new System.Drawing.Point(982, 402);
            this.bowCheckBox.Name = "bowCheckBox";
            this.bowCheckBox.Size = new System.Drawing.Size(47, 17);
            this.bowCheckBox.TabIndex = 84;
            this.bowCheckBox.Text = "Bow";
            this.bowCheckBox.UseVisualStyleBackColor = true;
            // 
            // harpCheckBox
            // 
            this.harpCheckBox.AutoSize = true;
            this.harpCheckBox.Location = new System.Drawing.Point(982, 425);
            this.harpCheckBox.Name = "harpCheckBox";
            this.harpCheckBox.Size = new System.Drawing.Size(49, 17);
            this.harpCheckBox.TabIndex = 85;
            this.harpCheckBox.Text = "Harp";
            this.harpCheckBox.UseVisualStyleBackColor = true;
            // 
            // newClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 676);
            this.Controls.Add(this.harpCheckBox);
            this.Controls.Add(this.bowCheckBox);
            this.Controls.Add(this.axeCheckBox2);
            this.Controls.Add(this.clothCheckBox);
            this.Controls.Add(this.leatherCheckBox);
            this.Controls.Add(this.lightCheckBox);
            this.Controls.Add(this.mediumCheckBox);
            this.Controls.Add(this.heavyCheckBox);
            this.Controls.Add(this.axeCheckBox1);
            this.Controls.Add(this.staffCheckBox);
            this.Controls.Add(this.daggerCheckBox);
            this.Controls.Add(this.swordCheckBox2);
            this.Controls.Add(this.swordCheckBox1);
            this.Controls.Add(this.spellPanel);
            this.Controls.Add(this.skillPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.existingClassComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.staTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.agiTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dexTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.strTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classNameTextBox);
            this.Name = "newClassForm";
            this.Text = "Class Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion





        private System.Windows.Forms.ComboBox existingClassComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox staTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox agiTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dexTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox strTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel skillPanel;
        private System.Windows.Forms.Panel spellPanel;
        private System.Windows.Forms.CheckBox swordCheckBox1;
        private System.Windows.Forms.CheckBox swordCheckBox2;
        private System.Windows.Forms.CheckBox daggerCheckBox;
        private System.Windows.Forms.CheckBox staffCheckBox;
        private System.Windows.Forms.CheckBox axeCheckBox1;
        private System.Windows.Forms.CheckBox heavyCheckBox;
        private System.Windows.Forms.CheckBox mediumCheckBox;
        private System.Windows.Forms.CheckBox lightCheckBox;
        private System.Windows.Forms.CheckBox leatherCheckBox;
        private System.Windows.Forms.CheckBox clothCheckBox;
        private System.Windows.Forms.CheckBox axeCheckBox2;
        private System.Windows.Forms.CheckBox bowCheckBox;
        private System.Windows.Forms.CheckBox harpCheckBox;
    }
}