using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace TileContent
{
    [ContentTypeWriter]
    public class TileMapWriter : ContentTypeWriter<TileMapContent>
    {
        protected override void Write(ContentWriter output, TileMapContent value)
        {
            output.WriteExternalReference<CollisionLayerContent>(value.CollisionLayer);
            output.Write(value.TileLayers.Count);
            foreach (ExternalReference<TileLayerContent> layer in value.TileLayers)
                output.WriteExternalReference<TileLayerContent>(layer);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "TileEngine.TileMapReader, TileEngine";
        }
    }
}
