using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    /// <summary>
    /// Can not implement halfing mana sickness. Not possible in any way, since Mana sickness is a (de)buff of it's own.
    /// </summary>
    public class MharadiumHealthBand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Health Band";
            item.width = 28;
            item.height = 20;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.lifeRegen *= 10; // Extreme mana regen.

            player.lifeMagnet = true; // Attracts heart from a longer distance.
            player.pStone = true; // Adds Philosopher's Stone effect.
            player.AddBuff(BuffID.Lifeforce, 2); // Adds the LifeForce buff.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.RegenerationPotion);
            recipe.AddIngredient(ItemID.SuperHealingPotion, 5);
            recipe.AddIngredient(ItemID.HeartreachPotion);
            recipe.AddIngredient(ItemID.LifeforcePotion);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
            recipe.AddTile(null, "MharadiumAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
