using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    public class MharadiumBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Bow";
            item.width = 12;
            item.height = 28;
            item.toolTip = "Only true heroes can handle its power!";
            item.toolTip2 = "50% chance not to consume ammo.";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.useStyle = 5;
            item.useAnimation = 30;
            item.useTime = 15;
            item.shoot = 1;
            item.useAmmo = 1;
            item.useSound = 5;
            item.damage = 200;
            item.shootSpeed = 10f;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(0, 2) == 0) // 50% chance not to consume ammo.
                return false;
            return true;
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
