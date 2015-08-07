using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.Reflection;

namespace TileEngine
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TileLayerSavedPropertyAttribute : Attribute
    {
    }

    public class TileLayer
    {
        List<Door> doors = new List<Door>();
        List<TreasureChest> chests = new List<TreasureChest>();
        List<Passage> passages = new List<Passage>();
        List<Texture2D> tileTextures = new List<Texture2D>();
        int[,] map;
        float alpha = 1f;

        [TileLayerSavedProperty]
        public float Alpha
        {
            get { return alpha; }
            set
            {
                alpha = MathHelper.Clamp(value, 0f, 1f);
            }
        }

        public int WidthInPixels
        {
            get
            {
                return Width * Engine.TileWidth;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return Height * Engine.TileHeight;
            }
        }

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Height
        {
            get { return map.GetLength(0); }
        }
           
        public TileLayer(int width, int height)
        {
            map = new int[height, width];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[y, x] = -1;
        }

        public TileLayer(int[,] existingMap)
        {
            map = (int[,])existingMap.Clone();
        }

        public int IsUsingTexture(Texture2D texture)
        {
            if (tileTextures.Contains(texture))
                return tileTextures.IndexOf(texture);

            return -1;
        }

        public List<TreasureChest> ListofChests
        {
            get { return chests; }
        }

        public List<Door> ListofDoors
        {
            get { return doors; }
        }

        public List<Passage> ListofPassagestoNewMap
        {
            get { return passages; }
        }

        public List<Texture2D> ListofTextures
        {
            get { return tileTextures; }
        }
        
        public void Save(string filename, string[] textureNames)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("TileLayer");
            doc.AppendChild(rootElement);

            XmlElement textureElement = doc.CreateElement("Textures");
            rootElement.AppendChild(textureElement);

            for (int i = 0; i < textureNames.Length; i++)
            {
                string t = textureNames[i];

                XmlElement tElement = doc.CreateElement("Texture");
                XmlAttribute tAttr = doc.CreateAttribute("File");
                tAttr.Value = t;
                XmlAttribute tAttr2 = doc.CreateAttribute("ID");
                tAttr2.Value = i.ToString();

                tElement.Attributes.Append(tAttr);
                tElement.Attributes.Append(tAttr2);

                textureElement.AppendChild(tElement);
            }

            PropertyInfo[] properties = typeof(TileLayer).GetProperties();

            List<PropertyInfo> propertiesToSave = new List<PropertyInfo>();

            foreach (PropertyInfo p in properties)
            {
                object[] attributes = p.GetCustomAttributes(typeof(TileLayerSavedPropertyAttribute), false);

                if (attributes.Length > 0)
                    propertiesToSave.Add(p);
            }

            XmlElement propertiesElement = doc.CreateElement("Properties");
            rootElement.AppendChild(propertiesElement);

            foreach (PropertyInfo p in propertiesToSave)
            {
                XmlElement pElement = doc.CreateElement(p.Name);
                pElement.InnerText = p.GetValue(this, null).ToString();

                propertiesElement.AppendChild(pElement);
            }

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

            XmlElement tcsElement = doc.CreateElement("TreasureChests");
            rootElement.AppendChild(tcsElement);

            foreach (TreasureChest chest in chests)
            {
                XmlElement chestsElement = doc.CreateElement("TreasureChest");
                tcsElement.AppendChild(chestsElement);
                XmlAttribute locXAttr = doc.CreateAttribute("LocationX");
                locXAttr.Value = chest.Postition.X.ToString();
                XmlAttribute locYAttr = doc.CreateAttribute("LocationY");
                locYAttr.Value = chest.Postition.Y.ToString();
                chestsElement.Attributes.Append(locXAttr);
                chestsElement.Attributes.Append(locYAttr);
                XmlElement contentElement = doc.CreateElement("Content");
                chestsElement.AppendChild(contentElement);
                XmlAttribute typeAttr = doc.CreateAttribute("ItemType");
                typeAttr.Value = chest.ItemType;
                XmlAttribute itemAttr = doc.CreateAttribute("Item");
                itemAttr.Value = chest.Item;
                XmlAttribute quantityAttr = doc.CreateAttribute("Quantity");
                quantityAttr.Value = chest.Quantity.ToString();
                contentElement.Attributes.Append(typeAttr);
                contentElement.Attributes.Append(itemAttr);
                contentElement.Attributes.Append(quantityAttr);
            }

            XmlElement drElement = doc.CreateElement("Doors");
            rootElement.AppendChild(drElement);

            foreach (Door door in doors)
            {
                XmlElement doorsElement = doc.CreateElement("Door");
                drElement.AppendChild(doorsElement);
                XmlAttribute locaXAttr = doc.CreateAttribute("LocationX");
                locaXAttr.Value = door.Postition.X.ToString();
                XmlAttribute locaYAttr = doc.CreateAttribute("LocationY");
                locaYAttr.Value = door.Postition.Y.ToString();
                doorsElement.Attributes.Append(locaXAttr);
                doorsElement.Attributes.Append(locaYAttr);
            }
            doc.Save(filename);
        }

        public static TileLayer FromFile(string filename, out string[] textureNameArray)
        {
            TileLayer tileLayer;
            List<string> textureNames = new List<string>();

            tileLayer = ProcessFile(filename, textureNames);

            textureNameArray = textureNames.ToArray();

            return tileLayer;
        }

 
        private static TileLayer ProcessFile(string filename, List<string> textureNames)
        {
            TileLayer tileLayer;
            List<TreasureChest> treasurech = new List<TreasureChest>();
            List<Door> dooor = new List<Door>();
            List<int> tempLayout = new List<int>();
            Dictionary<string, string> properties = new Dictionary<string, string>();
            int width = 0;
            int height = 0;

            XmlTextReader reader = new XmlTextReader(filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Texture")
                    {
                        string file = reader["File"];
                        textureNames.Add(file);
                    }

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


                    if (reader.Name == "Properties")
                    {
                        reader.Read();
                        string key = reader.Name;
                        string value = reader.ReadInnerXml();

                        properties.Add(key, value);
                    }

                    if (reader.Name == "TreasureChest")
                    {
                        TreasureChest tc = new TreasureChest();
                        tc.Postition.X = float.Parse(reader["LocationX"]);
                        tc.Postition.Y = float.Parse(reader["LocationY"]);
                        reader.Read();
                        tc.ItemType = reader["ItemType"];
                        tc.Item = reader["Item"];
                        tc.Quantity = int.Parse(reader["Quantity"]);
                        tc.Animations.Add("Closed", new FrameAnimation(1, 32, 48, 0, 0));
                        tc.CurrentAnimationName = "Closed";
                        treasurech.Add(tc);
                    }

                    if (reader.Name == "Door")
                    {
                        Door d = new Door();
                        d.Postition.X = float.Parse(reader["LocationX"]);
                        d.Postition.Y = float.Parse(reader["LocationY"]);
                        d.Animations.Add("Closed", new FrameAnimation(1, 96, 64, 0, 0));
                        d.CurrentAnimationName = "Closed";
                        dooor.Add(d);
                    }
                }
            }
            reader.Close();

            tileLayer = new TileLayer(width, height);
            int next = 0;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    tileLayer.SetCellIndex(x, y, tempLayout[next]);
                    next++;
                }


            foreach (KeyValuePair<string, string> property in properties)
            {
               switch (property.Key)
               {
                   case "Alpha":
                       tileLayer.Alpha = float.Parse(property.Value);
                       break;
               }
            }

            foreach (TreasureChest trech in treasurech)
            {
                tileLayer.chests.Add(trech);
            }

            foreach (Door d in dooor)
            {
                tileLayer.doors.Add(d);
            }

            return tileLayer;
       }
              
        public void LoadTileTextures(ContentManager content, params string[] textureNames)
        {
            Texture2D texture;

            foreach (string textureName in textureNames)
            {
                texture = content.Load<Texture2D>(textureName);
                tileTextures.Add(texture);
            }
        }

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public void RemoveTexture(Texture2D texture)
        {
            RemoveIndex(tileTextures.IndexOf(texture));
            tileTextures.Remove(texture);
        }

        public void AddChest(Vector2 position, string itemType, int quantity, string item)
        {
            TreasureChest tC = new TreasureChest();
            tC.Postition = position;
            tC.ItemType = itemType;
            tC.Item = item;
            tC.Animations.Add("Closed", new FrameAnimation(1, 32, 48, 0, 0));
            tC.Animations.Add("Openening", new FrameAnimation(2, 32, 48, 0, 96));
            tC.Animations.Add("Open", new FrameAnimation(1, 32, 48, 0, 144));
            tC.CurrentAnimationName = "Closed";
            if (quantity > 0)
                tC.Quantity = quantity;
            else
                tC.Quantity = 1;
            chests.Add(tC);
        }

        public void AddChest(TreasureChest chest)
        {
            chests.Add(chest);
        }

        public TreasureChest ContainsChest(Vector2 check)
        {
            foreach (TreasureChest chest in chests)
                if (chest.Postition == check)
                {
                    return chest;
                }
            return null;     
        }

        public void RemoveChestContents(Vector2 check)
        { 
            foreach (TreasureChest chest in chests)
                if (chest.Postition == check)
                {
                    chest.Item = null;
                    break;
                }
        }

        public void RemoveChest(Vector2 check)
        {
            foreach (TreasureChest chest in chests)
                if (chest.Postition == check)
                {
                    chests.Remove(chest);
                    break;
                }
        }

        public void AddDoor(Vector2 position)
        {
            Door door = new Door();
            door.Animations.Add("Closed", new FrameAnimation(1, 96, 64, 0, 0));
            FrameAnimation Opening = new FrameAnimation(4, 96, 64, 0, 0);
            Opening.FramesPerSecond = 5;
            door.Animations.Add("Opening", Opening);
            door.Animations.Add("Open", new FrameAnimation(1, 96, 64, 0, 192));
            door.CurrentAnimationName = "Closed";
            door.Postition = position;
            doors.Add(door);
        }

        public void AddDoor(Door door)
        {
            doors.Add(door);
        }

        public Door ContainsDoor(Vector2 check)
        {
            foreach (Door d in doors)
                if (d.Postition == check)
                {
                    return d;
                }
            return null;
        }

        public void RemoveDoor(Vector2 check)
        {
            foreach (Door d in doors)
                if (d.Postition == check)
                {
                    doors.Remove(d);
                    break;
                }
        }

        public void AddPassageToNewMap(string selectedMap, Vector2 spotSelected, Vector2 originalCell)
        {
            Passage passage = new Passage();
            passage.SelectedMap = selectedMap;
            passage.OriginalSpot = originalCell;
            passage.NewSpawnSpot = spotSelected;
            passages.Add(passage);
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

        public void Draw(SpriteBatch batch, Camera camera, Texture2D treasureChestTexture, Texture2D doorTexture)
        {
            batch.Begin(
                SpriteSortMode.Texture,
                BlendState.AlphaBlend,
                null, null, null, null,
                camera.TransformMatrix);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];

                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];

                    batch.Draw(
                        texture,
                        new Rectangle(
                            x * Engine.TileWidth,
                            y * Engine.TileHeight,
                            Engine.TileWidth,
                            Engine.TileHeight),
                        new Color(new Vector4(1f, 1f, 1f, Alpha)));                   
                }
            }
            batch.End();

            batch.Begin(SpriteSortMode.Texture,
                        BlendState.AlphaBlend,
                        null, null, null, null,
                        camera.TransformMatrix);
            foreach (TreasureChest treasurechest in chests)
            {
                FrameAnimation animation = treasurechest.CurrentAnimation;

                if (animation != null)
                    batch.Draw(
                        treasureChestTexture,
                        new Rectangle(
                        (int)treasurechest.Postition.X * Engine.TileWidth, 
                        (int)treasurechest.Postition.Y * Engine.TileHeight,
                        Engine.TileWidth,
                        Engine.TileHeight),
                        animation.CurrentRect,
                        Color.White);

            }

            foreach (Door door in doors)
            {
                FrameAnimation animation = door.CurrentAnimation;

                if (animation != null)
                    batch.Draw(
                        doorTexture,
                        new Rectangle(
                        (int)door.Postition.X * Engine.TileWidth,
                        (int)door.Postition.Y * Engine.TileHeight,
                        Engine.TileWidth,
                        Engine.TileHeight),
                        animation.CurrentRect,
                        Color.White);

            }
            batch.End();         
        }

        public void Draw(SpriteBatch batch, Camera camera, Point min, Point max, Texture2D treasureChestTexture, Texture2D doorTexture)
        {
            batch.Begin(
                SpriteSortMode.Texture,
                BlendState.AlphaBlend,
                null, null, null, null,
                camera.TransformMatrix);

            min.X = (int)Math.Max(min.X, 0);
            min.Y = (int)Math.Max(min.Y, 0);
            max.X = (int)Math.Min(max.X, Width);
            max.Y = (int)Math.Min(max.Y, Height);


            for (int x = min.X; x < max.X; x++)
            {
                for (int y = min.Y; y < max.Y; y++)
                {
                    int textureIndex = map[y, x];

                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];

                    batch.Draw(
                        texture,
                        new Rectangle(
                            x * Engine.TileWidth,
                            y * Engine.TileHeight,
                            Engine.TileWidth,
                            Engine.TileHeight),
                        new Color(new Vector4(1f, 1f, 1f, Alpha)));
                }
            }

            batch.End();

            batch.Begin(SpriteSortMode.Texture,
                        BlendState.AlphaBlend,
                        null, null, null, null,
                        camera.TransformMatrix);

            foreach (TreasureChest treasurechest in chests)
            {
                FrameAnimation animation = treasurechest.CurrentAnimation;

                if (animation != null)
                    batch.Draw(
                        treasureChestTexture,
                        new Rectangle(
                        (int)treasurechest.Postition.X * Engine.TileWidth,
                        (int)treasurechest.Postition.Y * Engine.TileHeight,
                        Engine.TileWidth,
                        Engine.TileHeight),
                        animation.CurrentRect,
                        Color.White);

            }

            foreach (Door door in doors)
            {
                FrameAnimation animation = door.CurrentAnimation;

                if (animation != null)
                    batch.Draw(
                        doorTexture,
                        new Rectangle(
                        (int)door.Postition.X * Engine.TileWidth,
                        (int)door.Postition.Y * Engine.TileHeight,
                        Engine.TileWidth,
                        Engine.TileHeight),
                        animation.CurrentRect,
                        Color.White);

            }

            batch.End();
        }
    }
}
