using System;

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
    }
}
