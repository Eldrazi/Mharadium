using System;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Mharadium.Items
{
    /// <summary>
    /// Minion knockback not yet integrated, since this isn't available from ModItem yet.
    /// </summary>
    public class SatansSpell : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Satan's Spell";
            item.width = 15;
            item.height = 15;
            item.toolTip = "WIP";
            item.rare = 9;
            item.accessory = true;

            item.defense = 75; 
        }

        public override void UpdateEquip(Player player)
        {
            if (player.name == "Miniek" || player.name == "miniek" || player.name == "Eldrazi" || player.name == "eldrazi")
            {
                // I do not know if there is any other way of implementing percentages, so I did it like this for now.
                player.meleeDamage += (player.meleeDamage / 100) * 30;
                player.magicDamage += (player.magicDamage / 100) * 30;
                player.rangedDamage += (player.rangedDamage / 100) * 30;

                player.minionDamage += (player.minionDamage / 100) * 40;
                player.maxMinions += 8;

                player.moveSpeed += (player.moveSpeed / 100) * 30;
                player.pickSpeed += (player.pickSpeed / 100) * 50;
                player.tileSpeed += (player.tileSpeed / 100) * 50;

                player.lifeRegen += 100; // Insane health regen.
                player.manaRegen += 100; // Insane mana regen.
            }
            else
            {
                player.AddBuff(BuffID.OnFire, 2); // NOPE!
            }
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
