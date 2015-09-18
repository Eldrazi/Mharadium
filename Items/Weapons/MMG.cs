using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Mharadium.Items.Weapons
{
    public class MMG : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "M.M.G.";
            item.width = 62;
            item.height = 26;
            item.toolTip = "Only true heroes can handle its power!";
            item.toolTip2 = "50% chance not to consume ammo.";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.damage = 130;
            item.crit += 20;

            item.ranged = true;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.autoReuse = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.useSound = 40;
            item.shoot = 10;
            item.shootSpeed = 12F;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 relativeCenter = player.RotatedRelativePoint(player.MountedCenter, true);

            float num5 = player.inventory[player.selectedItem].shootSpeed * item.scale;
            Vector2 vector2_3 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - relativeCenter;
            if ((double)player.gravDir == -1.0)
                vector2_3.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - relativeCenter.Y;
            Vector2 vector2_4 = Vector2.Normalize(vector2_3);
            if (float.IsNaN(vector2_4.X) || float.IsNaN(vector2_4.Y))
                vector2_4 = -Vector2.UnitY;
            vector2_4 *= num5;
            item.velocity = vector2_4;

            float rotationOffset = 8;
            int positionOffset = 2;
            Vector2 projectilePos = player.Center + new Vector2(0, Main.rand.Next(-positionOffset, positionOffset + 1));
            Vector2 spinningpoint = Vector2.Normalize(item.velocity) * rotationOffset;
            spinningpoint = Utils.RotatedBy(spinningpoint, Main.rand.NextDouble() * 0.196349546313286 - 0.0981747731566429, new Vector2());
            if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
                spinningpoint = -Vector2.UnitY;

            float angle = (float)Math.Atan(speedY / speedX); // No projectilePos, otherwise the bullets will freak out.
            Vector2 vector2 = new Vector2(projectilePos.X + 80F * (float)Math.Cos(angle), projectilePos.Y + 80F * (float)Math.Sin(angle));
            float mouseX = Main.mouseX + Main.screenPosition.X;
            if (mouseX < projectilePos.X)
            {
                vector2 = new Vector2(projectilePos.X - 80F * (float)Math.Cos(angle), projectilePos.Y - 80F * (float)Math.Sin(angle));
            }

            position = vector2;
            speedX = spinningpoint.X * 3; // * 3 for faster bullet speed.
            speedY = spinningpoint.Y * 3; // * 3 for faster bullet speed.
            return true; // Spawn the bullet with the changed position and rotation.
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(0, 2) == 0) // 50% chance not to consume ammo.
                return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            return true;// return base.UseItem(player);
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
