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

    [ContentProcessor(DisplayName = "Tile Map Processor")]
    public class TileMapProcessor : ContentProcessor<XmlDocument, TileMapContent>
    {
        public override TileMapContent Process(XmlDocument input, ContentProcessorContext context)
        {
            TileMapContent map = new TileMapContent();
            
            XmlNode colLayer = input.GetElementsByTagName("CollisionLayer")[0];
            if (colLayer != null)
            {
                map.CollisionLayer = context.BuildAsset<XmlDocument, CollisionLayerContent>(
                    new ExternalReference<XmlDocument>(colLayer.InnerText), "CollisionLayerProcessor");
            }
            XmlNodeList tileLayers = input.GetElementsByTagName("TileLayer");
            foreach (XmlNode layer in tileLayers)
            {
                map.TileLayers.Add(
                    context.BuildAsset<XmlDocument, TileLayerContent>(
                    new ExternalReference<XmlDocument>(layer.InnerText), "TileLayerProcessor"));
                    
            }

            return map;
        }
    }
}