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
    public partial class SwitchMapForm : Form
    {
        string[] imageExtensions = new string[]
        {
            ".jpg", ".png", ".tng",
        };

        public bool OKPressed = false;

        public Vector2 spotSelected;

        public string selectedMap;
        
        Texture2D tileTexture, treasureChestTexture, doorTexture;

        SpriteBatch spriteBatch;

        Camera camera = new Camera();

        TileLayer currentLayer;

        int cellX, cellY;
                
        bool leftClick = false;

        TileMap tileMap = new TileMap();

        private GraphicsDevice GraphicsDevice
        {
            get { return tempTileDisplay.GraphicsDevice; }
        }

        public SwitchMapForm()
        {
            InitializeComponent();

            Application.Idle += delegate { tempTileDisplay.Invalidate(); };

            spotSelected.X = -1;
            spotSelected.Y = -1;

            tempTileDisplay.OnInitialize += new EventHandler(tempTileDisplay_OnInitialize);
            tempTileDisplay.OnDraw += new EventHandler(tempTileDisplay_OnDraw);

            openFileDialog1.Filter = "Map File |*.map";

            Mouse.WindowHandle = tempTileDisplay.Handle;    
        }

        private void tempTileDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftClick = true;
        }

        private void tempTileDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftClick = false;
        }

        void tempTileDisplay_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/tile.png").BaseStream);
            treasureChestTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/treasurechest.png").BaseStream);
            doorTexture = Texture2D.FromStream(GraphicsDevice, new StreamReader("content/door.png").BaseStream);
        }

        void tempTileDisplay_OnDraw(object sender, EventArgs e)
        {
            camera.Position.X = 0;
            camera.Position.Y = 0;

            int mx = Mouse.GetState().X;
            int my = Mouse.GetState().Y;

            if (currentLayer != null)
            {
                if (mx >= 0 && mx < tempTileDisplay.Width &&
                my >= 0 && my < tempTileDisplay.Height)
                {
                    cellX = mx / Engine.TileWidth;
                    cellY = my / Engine.TileHeight;

                    cellX = (int)MathHelper.Clamp(cellX, 0, currentLayer.Width - 1);
                    cellY = (int)MathHelper.Clamp(cellY, 0, currentLayer.Height - 1);

                    if (leftClick)
                    {
                        spotSelected.X = cellX;
                        spotSelected.Y = cellY;
                    }
                }
            }
            Render();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OKPressed = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OKPressed = false;
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Map File|*.map";
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = Form1.cP.Text + "\\Maps";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {      
                string[] textureNames;
                string[] tileLayerNames;
                string[] collisionLayerNames;
                
                string filename = openFileDialog1.FileName;
                string path = Path.GetDirectoryName(openFileDialog1.FileName);
                string foldername = filename.Replace(path + "\\", "");
                foldername = foldername.Replace(".map", "");

                fileTextBox.Text = "\\Maps\\" + foldername + "\\" + foldername + ".map";
                selectedMap = fileTextBox.Text;
                               
                tileMap.FromFile(filename, out tileLayerNames, out collisionLayerNames);

                foreach (string tileLayerName in tileLayerNames)
                {
                    TileLayer layer = TileLayer.FromFile((path + "\\" + tileLayerName), out textureNames);
                    tileMap.Layers.Add(layer);

                    foreach (string textureName in textureNames)
                    {
                        string fullPath = Form1.cP.Text + "\\" + textureName;

                        Texture2D tex = Texture2D.FromStream(GraphicsDevice, new StreamReader(fullPath).BaseStream);
                        layer.AddTexture(tex);
                    }
                }

                foreach (string collisionLayerName in collisionLayerNames)
                {
                    CollisionLayer clayer = CollisionLayer.FromFile(path + "\\" + collisionLayerName);
                    tileMap.CollisionLayer = clayer;
                }
                                
            }
            currentLayer = tileMap.Layers[0];
        }

        private void Render()
        {
            GraphicsDevice.Clear(Color.Black);

            if(currentLayer != null)
            {
                foreach (TileLayer layer in tileMap.Layers)
                {
                    layer.Draw(spriteBatch, camera, treasureChestTexture, doorTexture);

                    spriteBatch.Begin();

                    if (layer == tileMap.Layers[0])
                    {
                        for (int y = 0; y < layer.Height; y++)
                        {
                            for (int x = 0; x < layer.Width; x++)
                            {                               
                                spriteBatch.Draw(
                                tileTexture,
                                new Rectangle(
                                    x * Engine.TileWidth - (int)camera.Position.X,
                                    y * Engine.TileHeight - (int)camera.Position.Y,
                                    Engine.TileWidth,
                                    Engine.TileHeight),
                                     new Color(new Vector4(1f, 1f, 1f, 1f)));
                            }
                        }
                    }
                    spriteBatch.End();
                }
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

            if (spotSelected.X != -1 && spotSelected.Y != -1)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(
                    tileTexture,
                    new Rectangle(
                        (int)spotSelected.X * Engine.TileWidth - (int)camera.Position.X,
                        (int)spotSelected.Y * Engine.TileHeight - (int)camera.Position.Y,
                        Engine.TileWidth,
                        Engine.TileHeight),
                    Color.Red);
                spriteBatch.End();
            }
        }
    }
}
