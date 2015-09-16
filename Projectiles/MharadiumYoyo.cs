using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Mharadium.Projectiles
{
    public class MharadiumYoyo : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Mharadium Yoyo";
            projectile.width = 16;
            projectile.height = 16;

            projectile.extraUpdates = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 99;
            projectile.melee = true;
            projectile.scale = 1;
        }
    }
}
