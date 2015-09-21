using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    public class MharadiumMagicBall : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Magic Ball";
            item.width = 24;
            item.height = 24;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.manaRegen *= 10; // Extreme mana regen.
            player.manaCost -= 0.2f; // -20% mana cost.

            // Crystal Ball effects.
            player.AddBuff(BuffID.Clairvoyance, 2);
            // Mana Flower effects.
            player.manaCost -= 0.08f; // -8% mana cost.
            player.manaFlower = true;
            // Magic Power Potion effects.
            player.magicDamage += 0.20f;
            // Celestial Cuffs effects.
            player.manaMagnet = true;
            player.magicCuffs = true;
            // Celestial Emblem effects.
            player.magicDamage += 0.15f;
            // Sorcerer Emblem effects.
            player.magicDamage += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.ManaFlower);
            recipe.AddIngredient(ItemID.SuperManaPotion, 5);
            recipe.AddIngredient(ItemID.MagicPowerPotion);
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddIngredient(ItemID.ManaRegenerationPotion);
            recipe.AddIngredient(ItemID.ManaCrystal, 10);
            recipe.AddIngredient(ItemID.CelestialCuffs);
            recipe.AddIngredient(ItemID.CelestialEmblem);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddIngredient(null, "MharadiumBar", 5);
            recipe.AddTile(null, "MharadiumAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
