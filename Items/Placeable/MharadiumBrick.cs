using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Placeable
{
    public class MharadiumBrick : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Brick";
            item.width = 12;
            item.height = 12;
            item.toolTip = "A brick made out of pure Mharadium";
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;

            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("MharadiumBrick");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(null, "MharadiumOre");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
