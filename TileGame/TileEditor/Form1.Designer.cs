namespace TileEditor
{
    partial class Form1
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTileMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollisionLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustSizeOfMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustSizeOfMapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contentPathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.drawRadioButton = new System.Windows.Forms.RadioButton();
            this.eraseRadioButton = new System.Windows.Forms.RadioButton();
            this.layerListBox = new System.Windows.Forms.ListBox();
            this.addLayerButton = new System.Windows.Forms.Button();
            this.removeLayerButton = new System.Windows.Forms.Button();
            this.textureListBox = new System.Windows.Forms.ListBox();
            this.addTextureButton = new System.Windows.Forms.Button();
            this.removeTextureButton = new System.Windows.Forms.Button();
            this.texturePreviewBox = new System.Windows.Forms.PictureBox();
            this.fillCheckBox = new System.Windows.Forms.CheckBox();
            this.alphaSlider = new System.Windows.Forms.TrackBar();
            this.collisionButtonAdd = new System.Windows.Forms.RadioButton();
            this.collisionButtonRemove = new System.Windows.Forms.RadioButton();
            this.RightClickOnMapMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEntranceToBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExitToBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEnemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTreasureChestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDoorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnimatedItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickOnChestMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeChestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickOnDoorMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeDoorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileDisplay1 = new TileEditor.TileDisplay();
            this.addPathToNextMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaSlider)).BeginInit();
            this.RightClickOnMapMenuStrip.SuspendLayout();
            this.RightClickOnChestMenuStrip.SuspendLayout();
            this.RightClickOnDoorMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(917, 27);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 661);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Visible = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(0, 688);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(928, 17);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.adjustSizeOfMapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTileMapToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTileMapToolStripMenuItem
            // 
            this.newTileMapToolStripMenuItem.Name = "newTileMapToolStripMenuItem";
            this.newTileMapToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.newTileMapToolStripMenuItem.Text = "New Tile Map";
            this.newTileMapToolStripMenuItem.Click += new System.EventHandler(this.newTileMapToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllLayersToolStripMenuItem,
            this.showGridToolStripMenuItem,
            this.showCollisionLayerToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // showAllLayersToolStripMenuItem
            // 
            this.showAllLayersToolStripMenuItem.CheckOnClick = true;
            this.showAllLayersToolStripMenuItem.Name = "showAllLayersToolStripMenuItem";
            this.showAllLayersToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showAllLayersToolStripMenuItem.Text = "Show All Layers";
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.Checked = true;
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            // 
            // showCollisionLayerToolStripMenuItem
            // 
            this.showCollisionLayerToolStripMenuItem.CheckOnClick = true;
            this.showCollisionLayerToolStripMenuItem.Name = "showCollisionLayerToolStripMenuItem";
            this.showCollisionLayerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showCollisionLayerToolStripMenuItem.Text = "Show Collision";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponsToolStripMenuItem,
            this.armorToolStripMenuItem,
            this.consumablesToolStripMenuItem,
            this.classesToolStripMenuItem,
            this.skillsToolStripMenuItem,
            this.spellsToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // weaponsToolStripMenuItem
            // 
            this.weaponsToolStripMenuItem.Name = "weaponsToolStripMenuItem";
            this.weaponsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.weaponsToolStripMenuItem.Text = "Weapons";
            this.weaponsToolStripMenuItem.Click += new System.EventHandler(this.weaponsToolStripMenuItem_Click);
            // 
            // armorToolStripMenuItem
            // 
            this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
            this.armorToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.armorToolStripMenuItem.Text = "Armor";
            this.armorToolStripMenuItem.Click += new System.EventHandler(this.armorToolStripMenuItem_Click);
            // 
            // consumablesToolStripMenuItem
            // 
            this.consumablesToolStripMenuItem.Name = "consumablesToolStripMenuItem";
            this.consumablesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.consumablesToolStripMenuItem.Text = "Consumables";
            this.consumablesToolStripMenuItem.Click += new System.EventHandler(this.consumablesToolStripMenuItem_Click);
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.classesToolStripMenuItem.Text = "Classes";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.classesToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.skillsToolStripMenuItem.Text = "Skills";
            // 
            // spellsToolStripMenuItem
            // 
            this.spellsToolStripMenuItem.Name = "spellsToolStripMenuItem";
            this.spellsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.spellsToolStripMenuItem.Text = "Spells";
            // 
            // adjustSizeOfMapToolStripMenuItem
            // 
            this.adjustSizeOfMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustSizeOfMapToolStripMenuItem1});
            this.adjustSizeOfMapToolStripMenuItem.Name = "adjustSizeOfMapToolStripMenuItem";
            this.adjustSizeOfMapToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.adjustSizeOfMapToolStripMenuItem.Text = "Size Adjust";
            // 
            // adjustSizeOfMapToolStripMenuItem1
            // 
            this.adjustSizeOfMapToolStripMenuItem1.Name = "adjustSizeOfMapToolStripMenuItem1";
            this.adjustSizeOfMapToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.adjustSizeOfMapToolStripMenuItem1.Text = "Adjust Size of Map";
            this.adjustSizeOfMapToolStripMenuItem1.Click += new System.EventHandler(this.adjustSizeOfMapToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contentPathTextBox
            // 
            this.contentPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPathTextBox.Location = new System.Drawing.Point(937, 27);
            this.contentPathTextBox.Name = "contentPathTextBox";
            this.contentPathTextBox.ReadOnly = true;
            this.contentPathTextBox.Size = new System.Drawing.Size(282, 20);
            this.contentPathTextBox.TabIndex = 4;
            // 
            // drawRadioButton
            // 
            this.drawRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawRadioButton.AutoSize = true;
            this.drawRadioButton.Checked = true;
            this.drawRadioButton.Location = new System.Drawing.Point(937, 53);
            this.drawRadioButton.Name = "drawRadioButton";
            this.drawRadioButton.Size = new System.Drawing.Size(50, 17);
            this.drawRadioButton.TabIndex = 6;
            this.drawRadioButton.TabStop = true;
            this.drawRadioButton.Text = "Draw";
            this.drawRadioButton.UseVisualStyleBackColor = true;
            // 
            // eraseRadioButton
            // 
            this.eraseRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eraseRadioButton.AutoSize = true;
            this.eraseRadioButton.Location = new System.Drawing.Point(937, 76);
            this.eraseRadioButton.Name = "eraseRadioButton";
            this.eraseRadioButton.Size = new System.Drawing.Size(52, 17);
            this.eraseRadioButton.TabIndex = 6;
            this.eraseRadioButton.Text = "Erase";
            this.eraseRadioButton.UseVisualStyleBackColor = true;
            // 
            // layerListBox
            // 
            this.layerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.layerListBox.FormattingEnabled = true;
            this.layerListBox.Location = new System.Drawing.Point(937, 149);
            this.layerListBox.Name = "layerListBox";
            this.layerListBox.Size = new System.Drawing.Size(282, 95);
            this.layerListBox.TabIndex = 7;
            this.layerListBox.SelectedIndexChanged += new System.EventHandler(this.layerListBox_SelectedIndexChanged);
            // 
            // addLayerButton
            // 
            this.addLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLayerButton.Location = new System.Drawing.Point(988, 250);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(75, 23);
            this.addLayerButton.TabIndex = 8;
            this.addLayerButton.Text = "Add";
            this.addLayerButton.UseVisualStyleBackColor = true;
            this.addLayerButton.Click += new System.EventHandler(this.addLayerButton_Click);
            // 
            // removeLayerButton
            // 
            this.removeLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLayerButton.Location = new System.Drawing.Point(1114, 250);
            this.removeLayerButton.Name = "removeLayerButton";
            this.removeLayerButton.Size = new System.Drawing.Size(75, 23);
            this.removeLayerButton.TabIndex = 8;
            this.removeLayerButton.Text = "Remove";
            this.removeLayerButton.UseVisualStyleBackColor = true;
            this.removeLayerButton.Click += new System.EventHandler(this.removeLayerButton_Click);
            // 
            // textureListBox
            // 
            this.textureListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textureListBox.FormattingEnabled = true;
            this.textureListBox.Location = new System.Drawing.Point(937, 281);
            this.textureListBox.Name = "textureListBox";
            this.textureListBox.Size = new System.Drawing.Size(282, 134);
            this.textureListBox.TabIndex = 7;
            this.textureListBox.SelectedIndexChanged += new System.EventHandler(this.textureListBox_SelectedIndexChanged);
            // 
            // addTextureButton
            // 
            this.addTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextureButton.Location = new System.Drawing.Point(988, 421);
            this.addTextureButton.Name = "addTextureButton";
            this.addTextureButton.Size = new System.Drawing.Size(75, 23);
            this.addTextureButton.TabIndex = 8;
            this.addTextureButton.Text = "Add";
            this.addTextureButton.UseVisualStyleBackColor = true;
            this.addTextureButton.Click += new System.EventHandler(this.addTextureButton_Click);
            // 
            // removeTextureButton
            // 
            this.removeTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeTextureButton.Location = new System.Drawing.Point(1114, 421);
            this.removeTextureButton.Name = "removeTextureButton";
            this.removeTextureButton.Size = new System.Drawing.Size(75, 23);
            this.removeTextureButton.TabIndex = 8;
            this.removeTextureButton.Text = "Remove";
            this.removeTextureButton.UseVisualStyleBackColor = true;
            this.removeTextureButton.Click += new System.EventHandler(this.removeTextureButton_Click);
            // 
            // texturePreviewBox
            // 
            this.texturePreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.texturePreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.texturePreviewBox.Location = new System.Drawing.Point(963, 449);
            this.texturePreviewBox.Name = "texturePreviewBox";
            this.texturePreviewBox.Size = new System.Drawing.Size(256, 256);
            this.texturePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.texturePreviewBox.TabIndex = 9;
            this.texturePreviewBox.TabStop = false;
            // 
            // fillCheckBox
            // 
            this.fillCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillCheckBox.AutoSize = true;
            this.fillCheckBox.Location = new System.Drawing.Point(1181, 53);
            this.fillCheckBox.Name = "fillCheckBox";
            this.fillCheckBox.Size = new System.Drawing.Size(38, 17);
            this.fillCheckBox.TabIndex = 10;
            this.fillCheckBox.Text = "Fill";
            this.fillCheckBox.UseVisualStyleBackColor = true;
            // 
            // alphaSlider
            // 
            this.alphaSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaSlider.Location = new System.Drawing.Point(949, 98);
            this.alphaSlider.Maximum = 100;
            this.alphaSlider.Name = "alphaSlider";
            this.alphaSlider.Size = new System.Drawing.Size(270, 45);
            this.alphaSlider.TabIndex = 11;
            this.alphaSlider.TickFrequency = 5;
            this.alphaSlider.Value = 100;
            this.alphaSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // collisionButtonAdd
            // 
            this.collisionButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collisionButtonAdd.AutoSize = true;
            this.collisionButtonAdd.Location = new System.Drawing.Point(1031, 53);
            this.collisionButtonAdd.Name = "collisionButtonAdd";
            this.collisionButtonAdd.Size = new System.Drawing.Size(85, 17);
            this.collisionButtonAdd.TabIndex = 6;
            this.collisionButtonAdd.Text = "Collision Add";
            this.collisionButtonAdd.UseVisualStyleBackColor = true;
            // 
            // collisionButtonRemove
            // 
            this.collisionButtonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collisionButtonRemove.AutoSize = true;
            this.collisionButtonRemove.Location = new System.Drawing.Point(1031, 76);
            this.collisionButtonRemove.Name = "collisionButtonRemove";
            this.collisionButtonRemove.Size = new System.Drawing.Size(106, 17);
            this.collisionButtonRemove.TabIndex = 6;
            this.collisionButtonRemove.Text = "Collision Remove";
            this.collisionButtonRemove.UseVisualStyleBackColor = true;
            // 
            // RightClickOnMapMenuStrip
            // 
            this.RightClickOnMapMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntranceToBuildingToolStripMenuItem,
            this.addExitToBuildingToolStripMenuItem,
            this.addNPCToolStripMenuItem,
            this.addEnemyToolStripMenuItem,
            this.addTreasureChestToolStripMenuItem,
            this.addDoorToolStripMenuItem,
            this.addAnimatedItemToolStripMenuItem,
            this.addPathToNextMapToolStripMenuItem});
            this.RightClickOnMapMenuStrip.Name = "contextMenuStrip1";
            this.RightClickOnMapMenuStrip.Size = new System.Drawing.Size(207, 202);
            // 
            // addEntranceToBuildingToolStripMenuItem
            // 
            this.addEntranceToBuildingToolStripMenuItem.Name = "addEntranceToBuildingToolStripMenuItem";
            this.addEntranceToBuildingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addEntranceToBuildingToolStripMenuItem.Text = "Add Entrance to Building";
            this.addEntranceToBuildingToolStripMenuItem.Click += new System.EventHandler(this.addEntranceToBuildingToolStripMenuItem_Click);
            // 
            // addExitToBuildingToolStripMenuItem
            // 
            this.addExitToBuildingToolStripMenuItem.Name = "addExitToBuildingToolStripMenuItem";
            this.addExitToBuildingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addExitToBuildingToolStripMenuItem.Text = "Add Exit to Building";
            this.addExitToBuildingToolStripMenuItem.Click += new System.EventHandler(this.addExitToBuildingToolStripMenuItem_Click);
            // 
            // addNPCToolStripMenuItem
            // 
            this.addNPCToolStripMenuItem.Name = "addNPCToolStripMenuItem";
            this.addNPCToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addNPCToolStripMenuItem.Text = "Add NPC";
            // 
            // addEnemyToolStripMenuItem
            // 
            this.addEnemyToolStripMenuItem.Name = "addEnemyToolStripMenuItem";
            this.addEnemyToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addEnemyToolStripMenuItem.Text = "Add Enemy";
            // 
            // addTreasureChestToolStripMenuItem
            // 
            this.addTreasureChestToolStripMenuItem.Name = "addTreasureChestToolStripMenuItem";
            this.addTreasureChestToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addTreasureChestToolStripMenuItem.Text = "Add Treasure Chest";
            this.addTreasureChestToolStripMenuItem.Click += new System.EventHandler(this.addTreasureChestToolStripMenuItem_Click);
            // 
            // addDoorToolStripMenuItem
            // 
            this.addDoorToolStripMenuItem.Name = "addDoorToolStripMenuItem";
            this.addDoorToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addDoorToolStripMenuItem.Text = "Add Door";
            this.addDoorToolStripMenuItem.Click += new System.EventHandler(this.addDoorToolStripMenuItem_Click);
            // 
            // addAnimatedItemToolStripMenuItem
            // 
            this.addAnimatedItemToolStripMenuItem.Name = "addAnimatedItemToolStripMenuItem";
            this.addAnimatedItemToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addAnimatedItemToolStripMenuItem.Text = "Add Animated Item";
            // 
            // RightClickOnChestMenuStrip
            // 
            this.RightClickOnChestMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeChestToolStripMenuItem});
            this.RightClickOnChestMenuStrip.Name = "RightClickOnChestMenuStrip";
            this.RightClickOnChestMenuStrip.Size = new System.Drawing.Size(151, 26);
            // 
            // removeChestToolStripMenuItem
            // 
            this.removeChestToolStripMenuItem.Name = "removeChestToolStripMenuItem";
            this.removeChestToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeChestToolStripMenuItem.Text = "Remove Chest";
            this.removeChestToolStripMenuItem.Click += new System.EventHandler(this.removeChestToolStripMenuItem_Click);
            // 
            // RightClickOnDoorMenuStrip
            // 
            this.RightClickOnDoorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDoorToolStripMenuItem});
            this.RightClickOnDoorMenuStrip.Name = "RightClickOnItemMenuStrip";
            this.RightClickOnDoorMenuStrip.Size = new System.Drawing.Size(147, 26);
            // 
            // removeDoorToolStripMenuItem
            // 
            this.removeDoorToolStripMenuItem.Name = "removeDoorToolStripMenuItem";
            this.removeDoorToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removeDoorToolStripMenuItem.Text = "Remove Door";
            this.removeDoorToolStripMenuItem.Click += new System.EventHandler(this.removeDoorToolStripMenuItem_Click);
            // 
            // tileDisplay1
            // 
            this.tileDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileDisplay1.Location = new System.Drawing.Point(0, 44);
            this.tileDisplay1.Name = "tileDisplay1";
            this.tileDisplay1.Size = new System.Drawing.Size(914, 644);
            this.tileDisplay1.TabIndex = 0;
            this.tileDisplay1.Text = "tileDisplay1";
            this.tileDisplay1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tileDisplay1_MouseDown);
            this.tileDisplay1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tileDisplay1_MouseUp);
            this.tileDisplay1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.tileDisplay1_MouseWheel);
            // 
            // addPathToNextMapToolStripMenuItem
            // 
            this.addPathToNextMapToolStripMenuItem.Name = "addPathToNextMapToolStripMenuItem";
            this.addPathToNextMapToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addPathToNextMapToolStripMenuItem.Text = "Add Path to Next Map";
            this.addPathToNextMapToolStripMenuItem.Click += new System.EventHandler(this.addPathToNextMapToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 717);
            this.Controls.Add(this.alphaSlider);
            this.Controls.Add(this.fillCheckBox);
            this.Controls.Add(this.texturePreviewBox);
            this.Controls.Add(this.removeTextureButton);
            this.Controls.Add(this.removeLayerButton);
            this.Controls.Add(this.addTextureButton);
            this.Controls.Add(this.addLayerButton);
            this.Controls.Add(this.textureListBox);
            this.Controls.Add(this.layerListBox);
            this.Controls.Add(this.collisionButtonRemove);
            this.Controls.Add(this.eraseRadioButton);
            this.Controls.Add(this.collisionButtonAdd);
            this.Controls.Add(this.drawRadioButton);
            this.Controls.Add(this.contentPathTextBox);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.tileDisplay1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TileEngine Super Tile Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaSlider)).EndInit();
            this.RightClickOnMapMenuStrip.ResumeLayout(false);
            this.RightClickOnChestMenuStrip.ResumeLayout(false);
            this.RightClickOnDoorMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TileDisplay tileDisplay1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTileMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox contentPathTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton drawRadioButton;
        private System.Windows.Forms.RadioButton eraseRadioButton;
        private System.Windows.Forms.ListBox layerListBox;
        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.Button removeLayerButton;
        private System.Windows.Forms.ListBox textureListBox;
        private System.Windows.Forms.Button addTextureButton;
        private System.Windows.Forms.Button removeTextureButton;
        private System.Windows.Forms.PictureBox texturePreviewBox;
        private System.Windows.Forms.CheckBox fillCheckBox;
        private System.Windows.Forms.TrackBar alphaSlider;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.RadioButton collisionButtonAdd;
        private System.Windows.Forms.RadioButton collisionButtonRemove;
        private System.Windows.Forms.ToolStripMenuItem showCollisionLayerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightClickOnMapMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addEntranceToBuildingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExitToBuildingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEnemyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTreasureChestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDoorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnimatedItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightClickOnChestMenuStrip;
        private System.Windows.Forms.ContextMenuStrip RightClickOnDoorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeDoorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeChestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustSizeOfMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustSizeOfMapToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addPathToNextMapToolStripMenuItem;
    }
}

