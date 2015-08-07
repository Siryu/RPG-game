using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.IO;

namespace TileEngine
{
    public class TileMap
    {
        public List<TileLayer> Layers = new List<TileLayer>();
        public CollisionLayer CollisionLayer;

        public int GetWidthInPixels()
        {
            return GetWidth() * Engine.TileWidth;
        }

        public int GetHeightInPixels()
        {
            return GetHeight() * Engine.TileHeight;
        }
        
        public int GetWidth()
        {
            int width = -10000;

            foreach (TileLayer layer in Layers)
                width = (int)Math.Max(width, layer.Width);

            return width;
        }

        public int GetHeight()
        {
            int height = -10000;

            foreach (TileLayer layer in Layers)
                height = (int)Math.Max(height, layer.Height);

            return height;
        }

        public void Save(string filename, Dictionary<string, TileLayer> layers)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("Map");
            doc.AppendChild(rootElement);

            string noPath = Path.GetFileName(filename);
            XmlElement cLayer = doc.CreateElement("CollisionLayer");
            rootElement.AppendChild(cLayer);
            noPath = noPath.Replace(".map", ".collayer");
            cLayer.InnerText = noPath;
            
            Dictionary<string, TileLayer>.KeyCollection layerNames = layers.Keys;
            
            foreach (string layerName in layerNames)
            {
                XmlElement tLayer = doc.CreateElement("TileLayer");
                rootElement.AppendChild(tLayer);
                tLayer.InnerText = layerName + ".layer";
            }

            doc.Save(filename);
        }

        public void FromFile(string filename, out string[] layerNameArray, out string[] collisionNameArray)
        {
            List<string> layerNames = new List<string>();
            List<string> collisionNames = new List<string>();
            
            XmlTextReader reader = new XmlTextReader(filename);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "CollisionLayer")
                    {
                        collisionNames.Add(reader.ReadInnerXml());
                    }

                    if (reader.Name == "TileLayer")
                    {
                        layerNames.Add(reader.ReadInnerXml());
                    }
                }
            }
            reader.Close();

            collisionNameArray = collisionNames.ToArray();
            layerNameArray = layerNames.ToArray();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, int layerIndex, Texture2D treasureChestTexture, Texture2D doorTexture)
        {
            Point min = Engine.ConvertPositionToCell(camera.Position);
            Point max = Engine.ConvertPositionToCell(
                camera.Position + new Vector2(
                    spriteBatch.GraphicsDevice.Viewport.Width + Engine.TileWidth,
                    spriteBatch.GraphicsDevice.Viewport.Height + Engine.TileHeight));

            if (layerIndex > 50)
            {
                int lI = layerIndex - 50;
                Layers[lI].Draw(spriteBatch, camera, min, max, treasureChestTexture, doorTexture);
            }

            else
            {
                foreach (TileLayer layer in Layers)
                    layer.Draw(spriteBatch, camera, min, max, treasureChestTexture, doorTexture);
            }            
        }
    }
}
