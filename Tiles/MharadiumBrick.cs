using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Tiles
{
    class MharadiumBrick : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("MharadiumBrick");
            mapColor = new Color(200, 200, 200);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.7f;
            g = 0.5f;
            b = 0.3f;
        }
    }
}
