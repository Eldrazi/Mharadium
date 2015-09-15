using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    public class MharadiumBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Bullet";
            item.width = 8;
            item.height = 8;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.maxStack = 999;
            item.rare = 10;

            item.ranged = true;
            item.consumable = true;
            item.damage = 40;
            item.knockBack = 4.5F;
            item.shootSpeed = 5F;
            item.shoot = mod.ProjectileType("MharadiumBullet");
            item.ammo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this, 999);
            recipe.AddRecipe();
        }
    }
}
