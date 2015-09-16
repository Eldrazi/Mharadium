using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Mharadium.Items.Weapons
{
    public class MharadiumBlaster : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Blaster";
            item.width = 36;
            item.height = 26;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.damage = 360;
            item.crit += 25;

            item.ranged = true;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 5;
            item.autoReuse = false;
            item.noMelee = true;
            item.knockBack = 4;
            item.useSound = 41;
            item.shoot = 14;
            item.shootSpeed = 13F;
            item.scale = 0.85f;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float angle = (float)Math.Atan(speedY / speedX);
            Vector2 vector2 = new Vector2(position.X + 55F * (float)Math.Cos(angle), position.Y + 55F * (float)Math.Sin(angle));
            float mouseX = Main.mouseX + Main.screenPosition.X;
            if (mouseX < vector2.X)
            {
                vector2 = new Vector2(position.X - 55F * (float)Math.Cos(angle), position.Y - 55F * (float)Math.Sin(angle));
            }

            position = vector2;
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 30);
            target.AddBuff(BuffID.Ichor, 30);
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
