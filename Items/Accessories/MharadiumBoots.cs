﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    public class MharadiumBoots : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Boots";
            item.width = 34;
            item.height = 28;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.moveSpeed *= 1.5F; // Increases move speed by 50%.
            player.noFallDmg = true; // Negate any fall damage.
            player.waterWalk = true; // Walk on liquids.
            player.lavaMax += 600; // 10 seconds of lava immunity.
            player.dash = 1; // Grants the ability to dash once.
            player.jumpBoost = true; // Allows the player to jump higher.
            player.doubleJumpCloud = true; // Allows double jumping.
            player.accRunSpeed = 10f; // Extra run speed max.
            player.moveSpeed += 0.15f; // Extra move speed.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LightningBoots);
            recipe.AddIngredient(ItemID.BlueHorseshoeBalloon);
            recipe.AddIngredient(ItemID.Tabi);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(null, "MharadiumBar", 5);
            recipe.AddTile(null, "MharadiumAnvil");
            // Add 5 Mharadium Bars and Mharadium Anvil
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
