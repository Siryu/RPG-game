using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace TileEngine
{

    public class TileMapReader : ContentTypeReader<TileMap>
    {
        protected override TileMap Read(ContentReader input, TileMap existingInstance)
        {
            TileMap map = new TileMap();

            map.CollisionLayer = input.ReadExternalReference<CollisionLayer>();

            int numLayers = input.ReadInt32();
            for (int i = 0; i < numLayers; i++)
                map.Layers.Add(input.ReadExternalReference<TileLayer>());

            return map;
        }
    }
}
