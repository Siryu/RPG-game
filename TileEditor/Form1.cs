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


        const int MaxFillCells = 1000;
        
        string[] imageExtensions = new string[]
        {
            ".jpg", ".png", ".tng",
        };

        int maxWidth = 0, maxHeight = 0;

        SpriteBatch spriteBatch;

        Texture2D tileTexture, collisionTexture;
        
        Camera camera = new Camera();

        TileLayer currentLayer;

        //CollisionLayer collisionLayer = null;

        int cellX, cellY;

        bool mouseDown = false;

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

            Mouse.WindowHandle = tileDisplay1.Handle;             
        }

        void tileDisplay1_OnInitialize(object sender, EventArgs e)
        {      
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tileTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/tile.png").BaseStream);
            collisionTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/CollisionBlank.png").BaseStream);                        
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
            mouseDown = true;
        }

        private void tileDisplay1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
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

                    if (mouseDown)
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
                layer.Draw(spriteBatch, camera);

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
            {
                spriteBatch.Begin();
                for (int y = 0; y < tileMap.CollisionLayer.Height; y++)
                {
                    for (int x = 0; x < tileMap.CollisionLayer.Width; x++)
                    {
                        if (tileMap.CollisionLayer.GetCellIndex(x, y) == 0)
                        {
                            spriteBatch.Draw(
                            collisionTexture,
                            new Rectangle(
                                x * Engine.TileWidth - (int)camera.Position.X,
                                y * Engine.TileHeight - (int)camera.Position.Y,
                                Engine.TileWidth,
                                Engine.TileHeight),
                                 new Color(new Vector4(1f, 0f, 0f, 0.01f)));
                        }
                    }
                }
                spriteBatch.End();
            }

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
                
                AdjustScrollBars();
             }
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

                    textureListBox.Items.Add(filename);
                    textureDict.Add(filename, texture);
                    previewDict.Add(filename, image);
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                contentPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            else
                Close();
        }
    }
}
