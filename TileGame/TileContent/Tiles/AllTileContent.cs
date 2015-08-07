using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using TileContent;

namespace TileContent
{
    public class TileMapContent
    {
        public ExternalReference<CollisionLayerContent> CollisionLayer;
        public List<ExternalReference<TileLayerContent>> TileLayers =
            new List<ExternalReference<TileLayerContent>>();
    }

    public class CollisionLayerContent
    {
        public int[,] Layout;
    }

    public class TileLayerContent
    {
        public Collection<TileLayerTextureContent> Textures =
            new Collection<TileLayerTextureContent>();

        public Collection<TileLayerPropertyContent> Properties =
            new Collection<TileLayerPropertyContent>();

        public int[,] Layout;

        public Collection<TileLayerTreasureChests> TreasureChests =
           new Collection<TileLayerTreasureChests>();

        public Collection<TileLayerDoors> Doors =
            new Collection<TileLayerDoors>();
    }

    public class TileLayerTextureContent
    {
        public ExternalReference<TextureContent> Texture;
        public int Index;
    }

    public class TileLayerPropertyContent
    {
        public string Name;
        public string Value;
    }

    public class TileLayerTreasureChests
    {
        public int LocationX;
        public int LocationY;
        public string Type;
        public string Item;
        public int Quantity;
    }

    public class TileLayerDoors
    {
        public int LocationX;
        public int LocationY;
    }
}
