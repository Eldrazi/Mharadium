using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    public class MharadiumSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Spear";
            item.width = 40;
            item.height = 40;
            item.toolTip = "Only some can handle its great powers.";
            item.rare = 10;

            item.value = Item.sellPrice(5, 0, 0, 0);

            item.useStyle = 5;
            item.useAnimation = 22;
            item.useTime = 22;
            item.shootSpeed = 5.6F;
            item.knockBack = 6.4F;
            item.damage = 270;
            item.scale = 1.1f;
            item.useSound = 1;
            item.shoot = mod.ProjectileType("MharadiumSpear");
            item.rare = 10;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
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
