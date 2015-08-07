using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TileEngine;




namespace TileEditor
{

    using Image = System.Drawing.Image;

    public partial class Form1 : Form
    {
        const int MaxFillCells = 2000;
        
        string[] imageExtensions = new string[]
        {
            ".jpg", ".png", ".tng",
        };

        int maxWidth = 0, maxHeight = 0;

        SpriteBatch spriteBatch;

        Texture2D tileTexture, collisionTexture, treasureChestTexture, doorTexture;
        
        Camera camera = new Camera();

        TileLayer currentLayer;

        int cellX, cellY;

        Vector2 rememberSpot = new Vector2(-1);

        bool leftClick = false;
        bool rightClick = false;
        bool wheelBack = false;
        bool wheelForward = false;

        TileMap tileMap = new TileMap();

        int fillCounter = MaxFillCells;

        Dictionary<string, TileLayer> layerDict = new Dictionary<string, TileLayer>();
        Dictionary<string, Texture2D> textureDict = new Dictionary<string, Texture2D>();
        Dictionary<string, Image> previewDict = new Dictionary<string, Image>();

        public GraphicsDevice GraphicsDevice
        {
            get { return tileDisplay1.GraphicsDevice; }
        }

        public Form1()
        {
            InitializeComponent();

            tileDisplay1.OnInitialize += new EventHandler(tileDisplay1_OnInitialize);
            tileDisplay1.OnDraw += new EventHandler(tileDisplay1_OnDraw);

            Application.Idle += delegate { tileDisplay1.Invalidate(); };

            hScrollBar1.ValueChanged += new EventHandler(hScrollBar1_ValueChanged);
            vScrollBar1.ValueChanged += new EventHandler(vScrollBar1_ValueChanged);

            openFileDialog1.Filter = "Map File |*.map";
            saveFileDialog1.Filter = "Map File |*.map";

            layerListBox.MouseWheel += new MouseEventHandler(layerListBox_MouseWheel);
            textureListBox.MouseWheel += new MouseEventHandler(textureListBox_MouseWheel);
            

            Mouse.WindowHandle = tileDisplay1.Handle;    
        }

        void tileDisplay1_OnInitialize(object sender, EventArgs e)
        {      
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tileTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/tile.png").BaseStream);
            collisionTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/CollisionBlank.png").BaseStream);
            treasureChestTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/treasurechest.png").BaseStream);
            doorTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/door.png").BaseStream);
        }

        void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            tileDisplay1.Invalidate();
        }

        void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            tileDisplay1.Invalidate();
        }

        void tileDisplay1_OnDraw(object sender, EventArgs e)
        {
            Logic();
            Render();
        }

        public void FillCell(int x, int y, int desiredIndex)
        {
            int oldIndex = currentLayer.GetCellIndex(x, y);

            if (desiredIndex == oldIndex || fillCounter == 0)
                return;

            fillCounter--;
            currentLayer.SetCellIndex(x, y, desiredIndex);

            if (x > 0 && currentLayer.GetCellIndex(x - 1, y) == oldIndex)
                FillCell(x - 1, y, desiredIndex); 
            if (x < currentLayer.Width - 1 && currentLayer.GetCellIndex(x + 1, y) == oldIndex)
                FillCell(x + 1, y, desiredIndex);
            if (y > 0 && currentLayer.GetCellIndex(x, y - 1) == oldIndex)
                FillCell(x, y - 1, desiredIndex);
            if (y < currentLayer.Height - 1 && currentLayer.GetCellIndex(x, y + 1) == oldIndex)
                FillCell(x, y + 1, desiredIndex);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (currentLayer != null)
                currentLayer.Alpha = (float)alphaSlider.Value / 100f;
        }

        private void tileDisplay1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftClick = true;
            if (e.Button == MouseButtons.Right)
                rightClick = true;
        }

        private void tileDisplay1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftClick = false;
            if (e.Button == MouseButtons.Right)
                rightClick = false;
        }

        private void tileDisplay1_MouseWheel(object sender, MouseEventArgs e)
        {            
            if (e.Delta > 0 && Engine.TileHeight <= 128)
            {
                wheelBack = true;
                wheelForward = false;
            }
            else if (-e.Delta > 0 && Engine.TileHeight >= 8)
            {
                wheelBack = false;
                wheelForward = true;
            }
        }

        private void textureListBox_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs hme = e as HandledMouseEventArgs;

            if (hme != null)
            {
                tileDisplay1_MouseWheel(sender, e);
                hme.Handled = true;
            }
        }

        private void layerListBox_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs hme = e as HandledMouseEventArgs;

            if (hme != null)
            {
                tileDisplay1_MouseWheel(sender, e);
                hme.Handled = true;
            }
        }

        private void Logic()
        {
            camera.Position.X = hScrollBar1.Value * Engine.TileWidth;
            camera.Position.Y = vScrollBar1.Value * Engine.TileHeight;

            int mx = Mouse.GetState().X;
            int my = Mouse.GetState().Y;          

            if (currentLayer != null)
            {
                if (mx >= 0 && mx < tileDisplay1.Width &&
                my >= 0 && my < tileDisplay1.Height)
                {
                    cellX = mx / Engine.TileWidth;
                    cellY = my / Engine.TileHeight;

                    cellX += hScrollBar1.Value;
                    cellY += vScrollBar1.Value;

                    cellX = (int)MathHelper.Clamp(cellX, 0, currentLayer.Width - 1);
                    cellY = (int)MathHelper.Clamp(cellY, 0, currentLayer.Height - 1);

                    if (wheelBack)
                    {
                        Engine.TileHeight += 5;
                        Engine.TileWidth += 5;
                        AdjustScrollBars();
                        wheelBack = false;
                    }

                    if (wheelForward)
                    {
                        Engine.TileHeight -= 5;
                        Engine.TileWidth -= 5;
                        AdjustScrollBars();
                        wheelForward = false;
                    }

                    if (rightClick)
                    {
                        rememberSpot = new Vector2(cellX, cellY);
                       
                        if (currentLayer.ContainsChest(rememberSpot) == null && currentLayer.ContainsDoor(rememberSpot) == null)
                            RightClickOnMapMenuStrip.Show(MousePosition);

                        else if (currentLayer.ContainsChest(rememberSpot) != null && currentLayer.ContainsDoor(rememberSpot) == null)
                            RightClickOnChestMenuStrip.Show(MousePosition);

                        else if (currentLayer.ContainsChest(rememberSpot) == null && currentLayer.ContainsDoor(rememberSpot) != null)
                            RightClickOnDoorMenuStrip.Show(MousePosition);
                    }
                    
                    
                    if (leftClick)
                    {
                        if (drawRadioButton.Checked && textureListBox.SelectedItem != null)
                        {
                            Texture2D texture = textureDict[textureListBox.SelectedItem as string];

                            int index = currentLayer.IsUsingTexture(texture);

                            if (index == -1)
                            {
                                currentLayer.AddTexture(texture);
                                index = currentLayer.IsUsingTexture(texture);
                            }

                            if (fillCheckBox.Checked)
                            {
                                fillCounter = MaxFillCells;
                                FillCell(cellX, cellY, index);
                            }
                            else
                                currentLayer.SetCellIndex(cellX, cellY, index);
                        }
                        
                        else if (eraseRadioButton.Checked)
                        {
                            if (fillCheckBox.Checked)
                            {
                                fillCounter = MaxFillCells;
                                FillCell(cellX, cellY, -1);
                            }
                            else
                                currentLayer.SetCellIndex(cellX, cellY, -1);
                        }
                        
                        else if (collisionButtonAdd.Checked && tileMap.CollisionLayer != null)
                        {
                            tileMap.CollisionLayer.SetCellIndex(cellX, cellY, 0);
                        }

                        else if (collisionButtonRemove.Checked && tileMap.CollisionLayer != null)
                        {
                            tileMap.CollisionLayer.SetCellIndex(cellX, cellY, -1);
                        }
                    }
                }
                else
                {
                    cellX = cellY = -1;
                }
            }
       }

        private void Render()
        {
            GraphicsDevice.Clear(Color.Black);

            foreach (TileLayer layer in tileMap.Layers)
            {
                layer.Draw(spriteBatch, camera, treasureChestTexture, doorTexture);

                spriteBatch.Begin();

                if (showGridToolStripMenuItem.Checked && layer == currentLayer)
                {
                    for (int y = 0; y < layer.Height; y++)
                    {
                        for (int x = 0; x < layer.Width; x++)
                        {
                            if (layer.GetCellIndex(x, y) == -1)
                            {
                                spriteBatch.Draw(
                                tileTexture,
                                new Rectangle(
                                    x * Engine.TileWidth - (int)camera.Position.X,
                                    y * Engine.TileHeight - (int)camera.Position.Y,
                                    Engine.TileWidth,
                                    Engine.TileHeight),
                                     new Color(new Vector4(1f,1f,1f,1f)));
                            }
                        }
                    }
                }
                spriteBatch.End();

                if (!showAllLayersToolStripMenuItem.Checked && layer == currentLayer)
                    break;
            }

            if (tileMap.CollisionLayer != null && showCollisionLayerToolStripMenuItem.Checked)
                tileMap.CollisionLayer.Draw(spriteBatch, camera, collisionTexture);
                            
            if (currentLayer != null)
            {
                if (cellX != -1 && cellY != -1)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(
                        tileTexture,
                        new Rectangle(
                            cellX * Engine.TileWidth - (int)camera.Position.X,
                            cellY * Engine.TileHeight - (int)camera.Position.Y,
                            Engine.TileWidth,
                            Engine.TileHeight),
                        Color.Blue);
                    spriteBatch.End();
                }
            }
        }

        private void newTileMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            currentLayer = null;

            foreach (string layer in layerListBox.Items)
            {
                layerDict.Remove(layer);
                names.Add(layer);                
            }

            foreach (string layer in names)
                layerListBox.Items.Remove(layer);
            names = new List<string>();

            foreach (string texture in textureListBox.Items)
            {
                textureDict.Remove(texture);
                previewDict.Remove(texture);
                names.Add(texture);
            }

            foreach (string texture in names)
                textureListBox.Items.Remove(texture);
            tileMap = new TileMap();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Map File |*.map";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(openFileDialog1.FileName);

                string[] textureNames;
                string[] tileLayerNames;
                string[] collisionLayerNames;

                tileMap.FromFile(openFileDialog1.FileName, out tileLayerNames, out collisionLayerNames);
                
                foreach (string tileLayerName in tileLayerNames)
                {
                    TileLayer layer = TileLayer.FromFile(path + "\\" + tileLayerName, out textureNames);

                    layerDict.Add(tileLayerName.Replace(".layer", ""), layer);
                    tileMap.Layers.Add(layer);
                    layerListBox.Items.Add(tileLayerName.Replace(".layer", ""));
                    
                    foreach (string textureName in textureNames)
                    {
                        if (textureDict.ContainsKey(textureName))
                        {
                            layer.AddTexture(textureDict[textureName]);
                            continue;
                        }

                        string fullPath = contentPathTextBox.Text + "/" + textureName;

                        foreach (string ext in imageExtensions)
                        {
                            if (File.Exists(fullPath + ext))
                            {
                                fullPath += ext;
                                break;
                            }
                        }

                        Texture2D tex = Texture2D.FromStream(GraphicsDevice, new StreamReader(fullPath).BaseStream);
                        Image image = Image.FromFile(fullPath);
                        textureDict.Add(textureName, tex);
                        previewDict.Add(textureName, image);
                        textureListBox.Items.Add(textureName);
                        layer.AddTexture(tex);
                    }
                }

                foreach (string collisionLayerName in collisionLayerNames)
                {
                    tileMap.CollisionLayer = CollisionLayer.FromFile(path + "\\" + collisionLayerName);
                }
                
                AdjustScrollBars();
            }
        }

        private void AdjustScrollBars()
        {
            if (tileMap.GetWidthInPixels() > tileDisplay1.Width)
            {
                maxWidth = (int)Math.Max(tileMap.GetWidth(), maxWidth);

                hScrollBar1.Visible = true;
                hScrollBar1.Minimum = 0;
                hScrollBar1.Maximum = maxWidth;
            }
            else
            {
                maxWidth = 0;
                hScrollBar1.Visible = false;
            }

            if (tileMap.GetHeightInPixels() > tileDisplay1.Height)
            {
                maxHeight = (int)Math.Max(tileMap.GetHeight(), maxHeight);

                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 0;
                vScrollBar1.Maximum = maxHeight;
            }
            else
            {
                maxHeight = 0;
                vScrollBar1.Visible = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layerListBox.SelectedItem != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Dictionary<string, TileLayer>.KeyCollection layerNames = layerDict.Keys;
                    string savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    
                    foreach (string layerName in layerNames)
                    {
                        TileLayer tileLayer = layerDict[layerName];

                        Dictionary<int, string> utilizedTextures = new Dictionary<int, string>();

                        foreach (string textureName in textureListBox.Items)
                        {
                            int index = tileLayer.IsUsingTexture(textureDict[textureName]);

                            if (index != -1)
                            {
                                utilizedTextures.Add(index, textureName);
                            }
                        }

                        List<string> utilizedTextureList = new List<string>();

                        for (int i = 0; i < utilizedTextures.Count; i++)
                            utilizedTextureList.Add(utilizedTextures[i]);

                        tileLayer.Save(savePath + "\\" + layerName + ".layer", utilizedTextureList.ToArray());
                    }
                    saveFileDialog1.FileName = saveFileDialog1.FileName.Replace(".map", ".collayer");

                    tileMap.CollisionLayer.Save(saveFileDialog1.FileName);

                    saveFileDialog1.FileName = saveFileDialog1.FileName.Replace(".collayer", ".map");

                    tileMap.Save(saveFileDialog1.FileName, layerDict);
                
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textureListBox.SelectedItem != null)
            {
                texturePreviewBox.Image = previewDict[textureListBox.SelectedItem as string];
            }
        }

        private void layerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerListBox.SelectedItem != null)
            {
                currentLayer = layerDict[layerListBox.SelectedItem as string];
                alphaSlider.Value = (int)(currentLayer.Alpha * 100);
            }
        }

        private void addLayerButton_Click(object sender, EventArgs e)
        {
            if (tileMap.Layers.Count == 0)
            {
                newLayerForm form = new newLayerForm();

                form.ShowDialog();

                if (form.OKPressed)
                {
                    TileLayer tileLayer = new TileLayer(
                        int.Parse(form.width.Text),
                        int.Parse(form.height.Text));

                    layerDict.Add(form.name.Text, tileLayer);
                    tileMap.Layers.Add(tileLayer);
                    layerListBox.Items.Add(form.name.Text);

                    if (tileMap.CollisionLayer == null)
                    {
                        tileMap.CollisionLayer = new CollisionLayer(
                            int.Parse(form.width.Text),
                            int.Parse(form.height.Text));
                    }
                }
            }

            else
            {
                newLayerForm2 form = new newLayerForm2();

                form.ShowDialog();

                if (form.OKPressed)
                {
                    TileLayer tileLayer = new TileLayer(
                        tileMap.Layers[0].Width,
                        tileMap.Layers[0].Height);

                    layerDict.Add(form.name.Text, tileLayer);
                    tileMap.Layers.Add(tileLayer);
                    layerListBox.Items.Add(form.name.Text);

                    if (tileMap.CollisionLayer == null)
                    {
                        tileMap.CollisionLayer = new CollisionLayer(
                            tileMap.Layers[0].Width,
                            tileMap.Layers[0].Height);
                    }
                }
            }
            AdjustScrollBars();            
        }

        private void removeLayerButton_Click(object sender, EventArgs e)
        {
            if (currentLayer != null)
            {
                string filename = layerListBox.SelectedItem as string;

                layerListBox.Items.Remove(layerListBox.SelectedItem);
                layerDict.Remove(filename);
                tileMap.Layers.Remove(currentLayer);

                if (layerListBox.Items.Count == 0)
                    tileMap.CollisionLayer = null;

                currentLayer = null;

                AdjustScrollBars();
            }
        }

        private void addTextureButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Image|*.jpg|PNG Image|*.png|TGA Image|*.tga";
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = contentPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fullFilename in openFileDialog1.FileNames)
                {
                   
                    string filename = fullFilename;

                    Texture2D texture = Texture2D.FromStream(GraphicsDevice, new StreamReader(filename).BaseStream);
                    Image image = Image.FromFile(filename);

                    filename = filename.Replace(contentPathTextBox.Text + "\\", "");

                    if (!textureDict.ContainsKey(filename))
                    {
                        textureListBox.Items.Add(filename);
                        textureDict.Add(filename, texture);
                        previewDict.Add(filename, image);
                    }
                }
            }

        }

        private void removeTextureButton_Click(object sender, EventArgs e)
        {
            if (textureListBox.SelectedItem != null)
            {
                string textureName = textureListBox.SelectedItem as string;

                foreach (TileLayer layer in tileMap.Layers)
                {
                    if (layer.IsUsingTexture(textureDict[textureName]) != -1)
                    {
                        layer.RemoveTexture(textureDict[textureName]);
                    }

                    textureDict.Remove(textureName);
                    previewDict.Remove(textureName);
                    textureListBox.Items.Remove(textureListBox.SelectedItem);

                    texturePreviewBox.Image = null;
                }
            }
        }

        private void addPathToNextMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int hmapblocks = Engine.TileHeight;
            int wmapblocks = Engine.TileWidth;
            float camerapositionx = camera.Position.X;
            float camerapositiony = camera.Position.Y;
            Engine.TileHeight = 16;
            Engine.TileWidth = 16;
            SwitchMapForm form = new SwitchMapForm();

            form.ShowDialog();

            if (form.OKPressed == true)
                currentLayer.AddPassageToNewMap(form.selectedMap, form.spotSelected, rememberSpot);
     
            Engine.TileHeight = hmapblocks;
            Engine.TileWidth = wmapblocks;
            camera.Position.X = camerapositionx;
            camera.Position.Y = camerapositiony;
            Mouse.WindowHandle = tileDisplay1.Handle;  
        }  

        private void addEntranceToBuildingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int layercount = tileMap.Layers.IndexOf(currentLayer) + 50;
            tileMap.CollisionLayer.SetCellIndex((int)rememberSpot.X, (int)rememberSpot.Y, layercount);
        }

        private void addExitToBuildingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tileMap.CollisionLayer.SetCellIndex((int)rememberSpot.X, (int)rememberSpot.Y, 50);
        }

        private void addTreasureChestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newTreasureChestForm form = new newTreasureChestForm();

            form.ShowDialog();
            
            if (form.OKPressed)
            {
                tileMap.CollisionLayer.SetCellIndex((int)rememberSpot.X, (int)rememberSpot.Y, 0);
                currentLayer.AddChest(rememberSpot, form.isItem, form.quantity, form.boxItem);
            }
        }

        private void removeChestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentLayer.RemoveChest(rememberSpot);
        }  
  
        private void addDoorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tileMap.CollisionLayer.SetCellIndex((int)rememberSpot.X, (int)rememberSpot.Y, 0);
            currentLayer.AddDoor(rememberSpot);
        }

        private void removeDoorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentLayer.RemoveDoor(rememberSpot);
        }

        public static TextBox cP = new TextBox();

        private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            newWeaponForm form = new newWeaponForm();
            
            form.ShowDialog();
        }

        private void armorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newArmorForm form = new newArmorForm();

            form.ShowDialog();
        }

        private void consumablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newConsumableForm form = new newConsumableForm();

            form.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                contentPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            else
                Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cP = contentPathTextBox;     
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newClassForm form = new newClassForm();

            form.ShowDialog();
        }

        private void adjustSizeOfMapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sizeForm form = new sizeForm();
            form.ShowDialog();
            TileMap tempTileMap = new TileMap();
            TileLayer templayer;
            CollisionLayer tempcolllayer;

            if (form.OKPressed)
            {
                tempTileMap = new TileMap();
                if (int.Parse(form.leftNegTextBox.Text) > 0 || int.Parse(form.leftPosTextBox.Text) > 0 ||
                    int.Parse(form.upNegTextBox.Text) > 0 || int.Parse(form.upPosTextBox.Text) > 0)
                {
                    foreach (TileLayer layer in tileMap.Layers)
                    {
                        templayer = new TileLayer(layer.Width + int.Parse(form.leftPosTextBox.Text) -
                            int.Parse(form.leftNegTextBox.Text), layer.Height + int.Parse(form.upPosTextBox.Text) -
                            int.Parse(form.upNegTextBox.Text));

                        for (int x = 0; x < templayer.Width; x++)
                        {
                            for (int y = 0; y < templayer.Height; y++)
                            {
                                if (y < int.Parse(form.upPosTextBox.Text) - int.Parse(form.upNegTextBox.Text) || x < int.Parse(form.leftPosTextBox.Text) - int.Parse(form.leftNegTextBox.Text))
                                    templayer.SetCellIndex(x, y, -1);
                                else
                                    templayer.SetCellIndex(x, y, layer.GetCellIndex(x - int.Parse(form.leftPosTextBox.Text) + int.Parse(form.leftNegTextBox.Text),
                                        y - int.Parse(form.upPosTextBox.Text) + int.Parse(form.upNegTextBox.Text)));
                            }
                        }
                        foreach (Texture2D textures in layer.ListofTextures)
                        {
                            templayer.AddTexture(textures);
                        }

                        foreach (TreasureChest chest in layer.ListofChests)
                        {
                            chest.Postition.X += int.Parse(form.leftPosTextBox.Text) - int.Parse(form.leftNegTextBox.Text);
                            chest.Postition.Y += int.Parse(form.upPosTextBox.Text) - int.Parse(form.upNegTextBox.Text);
                            if (chest.Postition.X > templayer.Width || chest.Postition.Y > templayer.Height)
                                continue;
                            templayer.AddChest(chest);
                        }

                        foreach (Door door in layer.ListofDoors)
                        {
                            door.Postition.X += int.Parse(form.leftPosTextBox.Text) - int.Parse(form.leftNegTextBox.Text);
                            door.Postition.Y += int.Parse(form.upPosTextBox.Text) - int.Parse(form.upNegTextBox.Text);
                            if (door.Postition.X > templayer.Width || door.Postition.Y > templayer.Height)
                                continue;
                            templayer.AddDoor(door);
                        }
                        tempTileMap.Layers.Add(templayer);
                    }
                    tempcolllayer = new CollisionLayer(tileMap.CollisionLayer.Width + int.Parse(form.leftPosTextBox.Text) -
                          int.Parse(form.leftNegTextBox.Text), tileMap.CollisionLayer.Height + int.Parse(form.upPosTextBox.Text) -
                          int.Parse(form.upNegTextBox.Text));
                    for (int x = 0; x < tempcolllayer.Width; x++)
                    {
                        for (int y = 0; y < tempcolllayer.Height; y++)
                        {
                            if (y < int.Parse(form.upPosTextBox.Text) - int.Parse(form.upNegTextBox.Text) || x < int.Parse(form.leftPosTextBox.Text) - int.Parse(form.leftNegTextBox.Text))
                                tempcolllayer.SetCellIndex(x, y, -1);
                            else
                                tempcolllayer.SetCellIndex(x, y, tileMap.CollisionLayer.GetCellIndex(x - int.Parse(form.leftPosTextBox.Text) + int.Parse(form.leftNegTextBox.Text),
                                    y - int.Parse(form.upPosTextBox.Text) + int.Parse(form.upNegTextBox.Text)));
                        }
                    }
                    tempTileMap.CollisionLayer = tempcolllayer;
                    tileMap = tempTileMap;
                    Dictionary<string, TileLayer> templayerdict = new Dictionary<string, TileLayer>();
                    int count = 0;
                    foreach (string layer in layerDict.Keys)
                    {
                        templayerdict.Add(layer, tileMap.Layers[count]);
                        count++;
                    }
                    layerDict = templayerdict;
                    currentLayer = null;
                    layerListBox.SelectedItem = null;
                }


                if (int.Parse(form.rightNegTextBox.Text) > 0 || int.Parse(form.rightPosTextBox.Text) > 0 ||
                    int.Parse(form.downNegTextBox.Text) > 0 || int.Parse(form.downPosTextBox.Text) > 0)
                {
                    tempTileMap = new TileMap();
                    foreach (TileLayer layer in tileMap.Layers)
                    {
                        templayer = new TileLayer(layer.Width + int.Parse(form.rightPosTextBox.Text) -
                            int.Parse(form.rightNegTextBox.Text), layer.Height + int.Parse(form.downPosTextBox.Text) -
                            int.Parse(form.downNegTextBox.Text));

                        for (int x = 0; x < templayer.Width; x++)
                        {
                            for (int y = 0; y < templayer.Height; y++)
                            {
                                templayer.SetCellIndex(x, y, layer.GetCellIndex(x, y));
                            }
                        }

                        foreach (Texture2D textures in layer.ListofTextures)
                        {
                            templayer.AddTexture(textures);
                        }

                        foreach (TreasureChest chest in layer.ListofChests)
                        {
                            if (chest.Postition.X > templayer.Width || chest.Postition.Y > templayer.Height)
                                continue;
                            templayer.AddChest(chest);
                        }

                        foreach (Door door in layer.ListofDoors)
                        {
                            if (door.Postition.X > templayer.Width || door.Postition.Y > templayer.Height)
                                continue;
                            templayer.AddDoor(door);
                        }
                        tempTileMap.Layers.Add(templayer);
                    }

                    tempcolllayer = new CollisionLayer(tileMap.CollisionLayer.Width + int.Parse(form.rightPosTextBox.Text) -
                            int.Parse(form.rightNegTextBox.Text), tileMap.CollisionLayer.Height + int.Parse(form.downPosTextBox.Text) -
                            int.Parse(form.downNegTextBox.Text));
                    for (int y = 0; y < tempcolllayer.Height; y++)
                    {
                        for (int x = 0; x < tempcolllayer.Width; x++)
                        {
                            tempcolllayer.SetCellIndex(x, y, tileMap.CollisionLayer.GetCellIndex(x, y));
                        }
                    }
                    tempTileMap.CollisionLayer = tempcolllayer;
                    tileMap = tempTileMap;
                    Dictionary<string, TileLayer> templayerdict = new Dictionary<string, TileLayer>();
                    int count = 0;
                    foreach (string layer in layerDict.Keys)
                    {
                        templayerdict.Add(layer, tileMap.Layers[count]);
                        count++;
                    }
                    layerDict = templayerdict;
                    currentLayer = null;
                    layerListBox.SelectedItem = null;
                }
            }
        }
    }
}
