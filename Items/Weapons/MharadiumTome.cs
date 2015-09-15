using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    public class MharadiumTome : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Tome";
            item.width = 28;
            item.height = 30;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.useSound = 4;
            item.useStyle = 4;
            item.useTurn = true;
            item.useAnimation = 30;
            item.useTime = 15;
            item.mana = 5;
        }

        public override bool UseItem(Player player)
        {
            player.HealEffect(5); // Heals the player for 5 HP.
            return true; // Return true, because the item has an effect.
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
