using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium
{
    public class Mharadium : Mod
    {
        public override void SetModInfo(out string name, ref ModProperties properties)
        {
            name = "Mharadium";
            properties.Autoload = true;
            properties.AutoloadGores = true;
            properties.AutoloadSounds = true;
        }

        public static bool IsInHell(Vector2 position)
        {
            return (position.Y / 16) > (Main.maxTilesY - 200);
        }
    }
}
