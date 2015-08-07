using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using System.Xml;

namespace TileContent
{
    [ContentProcessor(DisplayName = "Tile Layer Processor")]
    public class TileLayerProcessor : ContentProcessor<XmlDocument, TileLayerContent>
    {
        public override TileLayerContent Process(XmlDocument input, ContentProcessorContext context)
        {
            TileLayerContent layer = new TileLayerContent();

            foreach (XmlNode node in input.DocumentElement.ChildNodes)
            {
                if (node.Name == "Textures")
                {
                    foreach (XmlNode textureNode in node.ChildNodes)
                    {
                        string file = textureNode.Attributes["File"].Value;
                        int index = int.Parse(textureNode.Attributes["ID"].Value);

                        TileLayerTextureContent textureContent = new TileLayerTextureContent();

                        OpaqueDataDictionary data = new OpaqueDataDictionary();
                        data.Add("GenerateMipmaps", true);
                        textureContent.Texture = context.BuildAsset<TextureContent, TextureContent>(
                            new ExternalReference<TextureContent>(file),
                            "TextureProcessor", data, "TextureImporter", file);
                        textureContent.Index = index;

                        layer.Textures.Add(textureContent);
                    }
                }
                else if (node.Name == "Properties")
                {
                    foreach (XmlNode propertyNode in node.ChildNodes)
                    {
                        TileLayerPropertyContent propContent = new TileLayerPropertyContent();
                        propContent.Name = propertyNode.Name;
                        propContent.Value = propertyNode.InnerText;
                        layer.Properties.Add(propContent);
                    }
                }
                else if (node.Name == "Layout")
                {
                    int width = int.Parse(node.Attributes["Width"].Value);
                    int height = int.Parse(node.Attributes["Height"].Value);

                    layer.Layout = new int[height, width];

                    string layout = node.InnerText;

                    string[] lines = layout.Split('\r', '\n');

                    int row = 0;

                    foreach (string line in lines)
                    {
                        string realLine = line.Trim();

                        if (string.IsNullOrEmpty(realLine))
                            continue;

                        string[] cells = realLine.Split(' ');

                        for (int x = 0; x < width; x++)
                        {
                            int cellIndex = int.Parse(cells[x]);

                            layer.Layout[row, x] = cellIndex;
                        }

                        row++;
                    }
                }

                else if (node.Name == "TreasureChests")
                {
                    foreach (XmlNode chestNode in node.ChildNodes)
                    {
                        TileLayerTreasureChests chestContent = new TileLayerTreasureChests();
                        chestContent.LocationX = int.Parse(chestNode.Attributes["LocationX"].Value);
                        chestContent.LocationY = int.Parse(chestNode.Attributes["LocationY"].Value);
                        chestContent.Type = chestNode.FirstChild.Attributes["ItemType"].Value;
                        chestContent.Item = chestNode.FirstChild.Attributes["Item"].Value;
                        chestContent.Quantity = int.Parse(chestNode.FirstChild.Attributes["Quantity"].Value);
                        layer.TreasureChests.Add(chestContent);
                    }
                }

                else if (node.Name == "Doors")
                {
                    foreach (XmlNode doorNode in node.ChildNodes)
                    {
                        TileLayerDoors doorContent = new TileLayerDoors();
                        doorContent.LocationX = int.Parse(doorNode.Attributes["LocationX"].Value);
                        doorContent.LocationY = int.Parse(doorNode.Attributes["LocationY"].Value);
                        layer.Doors.Add(doorContent);
                    }

                }
            }
            
            return layer;
        }
    }
}