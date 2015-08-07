using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace TileEngine
{
    public class CollisionLayer
    {
        int[,] map;

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Height
        {
            get { return map.GetLength(0); }
        }

        public CollisionLayer(int width, int height)
        {
            map = new int[height, width];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[y, x] = -1;
        }

        public void Save(string filename)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("CollisionLayer");
            doc.AppendChild(rootElement);

            XmlElement layoutElement = doc.CreateElement("Layout");
            rootElement.AppendChild(layoutElement);

            XmlAttribute widthAttr = doc.CreateAttribute("Width");
            widthAttr.Value = Width.ToString();
            XmlAttribute heightAttr = doc.CreateAttribute("Height");
            heightAttr.Value = Height.ToString();
            layoutElement.Attributes.Append(widthAttr);
            layoutElement.Attributes.Append(heightAttr);

            for (int y = 0; y < Height; y++)
            {
                layoutElement.InnerXml += "\r\n\t ";

                for (int x = 0; x < Width; x++)
                {
                    layoutElement.InnerText += map[y, x].ToString() + " ";
                }
            }

            layoutElement.InnerXml += "\r\n";

            doc.Save(filename);
        }

        public static CollisionLayer FromFile(string filename)
        {
            CollisionLayer collisionLayer;
            List<int> tempLayout = new List<int>();
            int width = 0;
            int height = 0;

            XmlTextReader reader = new XmlTextReader(filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Layout")
                    {
                        List<int> row = new List<int>();
                        width = int.Parse(reader["Width"]);
                        height = int.Parse(reader["Height"]);

                        reader.Read();

                        string[] cells = reader.Value.Split(' ');

                        foreach (string c in cells)
                        {
                            if (!string.IsNullOrEmpty(c))
                            {
                                if (c.Contains("\r\n"))
                                    continue;

                                tempLayout.Add(int.Parse(c));
                            }
                        }
                    }
                }
            }
            reader.Close();

            collisionLayer = new CollisionLayer(width, height);
            
            int next = 0;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    collisionLayer.SetCellIndex(x, y, tempLayout[next]);
                    next++;
                }

            return collisionLayer;
        }
              
        public void SetCellIndex(int x, int y, int cellIndex)
        {
            map[y, x] = cellIndex;
        }

        public int GetCellIndex(int x, int y)
        {
            if (y < Height && x < Width)
                return map[y, x];
            return -1;
        }
        
        public void SetCellIndex(Point point, int cellIndex)
        {
            map[point.Y, point.X] = cellIndex;
        }

        public int GetCellIndex(Point point)
        {
            return map[point.Y, point.X];
        }

        public void RemoveIndex(int existingIndex)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (map[y, x] == existingIndex)
                        map[y, x] = -1;
                    else if (map[y, x] > existingIndex)
                        map[y, x]--;
                }
            }
        }

        public void ReplaceIndex(int existingIndex, int newIndex)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (map[y, x] == existingIndex)
                        map[y, x] = newIndex;
                }
            }
        }

        public int ShowLayer(AnimatedSprite animSprite, int original)
        {
            Point cell = Engine.ConvertPositionToCell(animSprite.Origin);

            int colIndex = GetCellIndex(cell);

            if (colIndex < 50)
                return original;
            else
                return colIndex;
        }
        
        
        
        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D collisionTexture)
        {  
            spriteBatch.Begin();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (GetCellIndex(x, y) == 0)
                    {
                        spriteBatch.Draw(
                            collisionTexture,
                            new Rectangle(
                                x * Engine.TileWidth - (int)camera.Position.X,
                                y * Engine.TileHeight - (int)camera.Position.Y,
                                Engine.TileWidth,
                                Engine.TileHeight),
                            new Color(new Vector4(1f, 0f, 0f, 0f)));
                    }

                    if (GetCellIndex(x, y) >= 50)
                    {
                        spriteBatch.Draw(
                            collisionTexture,
                            new Rectangle(
                                x * Engine.TileWidth - (int)camera.Position.X,
                                y * Engine.TileHeight - (int)camera.Position.Y,
                                Engine.TileWidth,
                                Engine.TileHeight),
                            new Color(new Vector4(0f, 1f, 0f, 0f)));
                    }
                }
            }
            spriteBatch.End();
        }
    }
}
