namespace TileEditor
{
    partial class newConsumableForm
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
            this.reviveComboBox = new System.Windows.Forms.ComboBox();
            this.existingConsumableComboBox = new System.Windows.Forms.ComboBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.imageFileTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.HPRegenTextBox = new System.Windows.Forms.TextBox();
            this.MPTextBox = new System.Windows.Forms.TextBox();
            this.HPTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.consumablePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MPRegenTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lifeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.consumablePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // reviveComboBox
            // 
            this.reviveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reviveComboBox.FormattingEnabled = true;
            this.reviveComboBox.Location = new System.Drawing.Point(80, 222);
            this.reviveComboBox.MaxDropDownItems = 2;
            this.reviveComboBox.Name = "reviveComboBox";
            this.reviveComboBox.Size = new System.Drawing.Size(55, 21);
            this.reviveComboBox.TabIndex = 6;
            // 
            // existingConsumableComboBox
            // 
            this.existingConsumableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.existingConsumableComboBox.FormattingEnabled = true;
            this.existingConsumableComboBox.Location = new System.Drawing.Point(357, 10);
            this.existingConsumableComboBox.Name = "existingConsumableComboBox";
            this.existingConsumableComboBox.Size = new System.Drawing.Size(256, 21);
            this.existingConsumableComboBox.TabIndex = 82;
            this.existingConsumableComboBox.TabStop = false;
            this.existingConsumableComboBox.SelectedIndexChanged += new System.EventHandler(this.existingConsumableComboBox_SelectedIndexChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(276, 10);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 81;
            this.browseButton.TabStop = false;
            this.browseButton.Text = "Browse ...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imageFileTextBox
            // 
            this.imageFileTextBox.Location = new System.Drawing.Point(80, 10);
            this.imageFileTextBox.Name = "imageFileTextBox";
            this.imageFileTextBox.ReadOnly = true;
            this.imageFileTextBox.Size = new System.Drawing.Size(190, 20);
            this.imageFileTextBox.TabIndex = 80;
            this.imageFileTextBox.TabStop = false;
            this.imageFileTextBox.TextChanged += new System.EventHandler(this.imageFileTextBox_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(276, 234);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 79;
            this.newButton.TabStop = false;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(276, 417);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 78;
            this.removeButton.TabStop = false;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(276, 328);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // HPRegenTextBox
            // 
            this.HPRegenTextBox.Location = new System.Drawing.Point(80, 115);
            this.HPRegenTextBox.Name = "HPRegenTextBox";
            this.HPRegenTextBox.Size = new System.Drawing.Size(41, 20);
            this.HPRegenTextBox.TabIndex = 4;
            // 
            // MPTextBox
            // 
            this.MPTextBox.Location = new System.Drawing.Point(80, 89);
            this.MPTextBox.Name = "MPTextBox";
            this.MPTextBox.Size = new System.Drawing.Size(41, 20);
            this.MPTextBox.TabIndex = 3;
            // 
            // HPTextBox
            // 
            this.HPTextBox.Location = new System.Drawing.Point(80, 63);
            this.HPTextBox.Name = "HPTextBox";
            this.HPTextBox.Size = new System.Drawing.Size(41, 20);
            this.HPTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(80, 37);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(165, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // consumablePictureBox
            // 
            this.consumablePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.consumablePictureBox.Location = new System.Drawing.Point(251, 35);
            this.consumablePictureBox.Name = "consumablePictureBox";
            this.consumablePictureBox.Size = new System.Drawing.Size(100, 100);
            this.consumablePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.consumablePictureBox.TabIndex = 77;
            this.consumablePictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 86;
            this.label14.Text = "HP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 85;
            this.label12.Text = "Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "MP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "HP Regen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "MP Regen";
            // 
            // MPRegenTextBox
            // 
            this.MPRegenTextBox.Location = new System.Drawing.Point(80, 144);
            this.MPRegenTextBox.Name = "MPRegenTextBox";
            this.MPRegenTextBox.Size = new System.Drawing.Size(41, 20);
            this.MPRegenTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "Revive";
            // 
            // lifeTextBox
            // 
            this.lifeTextBox.Location = new System.Drawing.Point(80, 246);
            this.lifeTextBox.Name = "lifeTextBox";
            this.lifeTextBox.Size = new System.Drawing.Size(41, 20);
            this.lifeTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Life %";
            // 
            // newConsumableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 446);
            this.Controls.Add(this.lifeTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MPRegenTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reviveComboBox);
            this.Controls.Add(this.existingConsumableComboBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imageFileTextBox);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.HPRegenTextBox);
            this.Controls.Add(this.MPTextBox);
            this.Controls.Add(this.HPTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.consumablePictureBox);
            this.Name = "newConsumableForm";
            this.Text = "Consumable Database";
            ((System.ComponentModel.ISupportInitialize)(this.consumablePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox reviveComboBox;
        private System.Windows.Forms.ComboBox existingConsumableComboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox imageFileTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox HPRegenTextBox;
        private System.Windows.Forms.TextBox MPTextBox;
        private System.Windows.Forms.TextBox HPTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.PictureBox consumablePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MPRegenTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lifeTextBox;
        private System.Windows.Forms.Label label6;
    }
}