namespace TileEditor
{
    partial class newTreasureChestForm
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
            this.consumableComboBox = new System.Windows.Forms.ComboBox();
            this.WeaponComboBox = new System.Windows.Forms.ComboBox();
            this.ArmorComboBox = new System.Windows.Forms.ComboBox();
            this.goldTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.consumableQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consumableComboBox
            // 
            this.consumableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consumableComboBox.FormattingEnabled = true;
            this.consumableComboBox.Location = new System.Drawing.Point(77, 66);
            this.consumableComboBox.Name = "consumableComboBox";
            this.consumableComboBox.Size = new System.Drawing.Size(256, 21);
            this.consumableComboBox.TabIndex = 3;
            this.consumableComboBox.SelectedIndexChanged += new System.EventHandler(this.consumableComboBox_SelectedIndexChanged);
            // 
            // WeaponComboBox
            // 
            this.WeaponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeaponComboBox.FormattingEnabled = true;
            this.WeaponComboBox.Location = new System.Drawing.Point(77, 12);
            this.WeaponComboBox.Name = "WeaponComboBox";
            this.WeaponComboBox.Size = new System.Drawing.Size(256, 21);
            this.WeaponComboBox.TabIndex = 1;
            this.WeaponComboBox.SelectedIndexChanged += new System.EventHandler(this.WeaponComboBox_SelectedIndexChanged);
            // 
            // ArmorComboBox
            // 
            this.ArmorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArmorComboBox.FormattingEnabled = true;
            this.ArmorComboBox.Location = new System.Drawing.Point(77, 39);
            this.ArmorComboBox.Name = "ArmorComboBox";
            this.ArmorComboBox.Size = new System.Drawing.Size(256, 21);
            this.ArmorComboBox.TabIndex = 2;
            this.ArmorComboBox.SelectedIndexChanged += new System.EventHandler(this.ArmorComboBox_SelectedIndexChanged);
            // 
            // goldTextBox
            // 
            this.goldTextBox.Location = new System.Drawing.Point(228, 93);
            this.goldTextBox.Name = "goldTextBox";
            this.goldTextBox.Size = new System.Drawing.Size(105, 20);
            this.goldTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Gold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Weapon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Armor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Consumable";
            // 
            // consumableQuantityTextBox
            // 
            this.consumableQuantityTextBox.Location = new System.Drawing.Point(391, 67);
            this.consumableQuantityTextBox.Name = "consumableQuantityTextBox";
            this.consumableQuantityTextBox.Size = new System.Drawing.Size(30, 20);
            this.consumableQuantityTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Quantity";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(265, 119);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(346, 119);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 6;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // newTreasureChestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 152);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.consumableQuantityTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goldTextBox);
            this.Controls.Add(this.ArmorComboBox);
            this.Controls.Add(this.WeaponComboBox);
            this.Controls.Add(this.consumableComboBox);
            this.Name = "newTreasureChestForm";
            this.Text = "newTreasureChestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox consumableComboBox;
        private System.Windows.Forms.ComboBox WeaponComboBox;
        private System.Windows.Forms.ComboBox ArmorComboBox;
        private System.Windows.Forms.TextBox goldTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox consumableQuantityTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelbutton;
    }
}