using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    public class MharadiumEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Emblem";
            item.width = 28;
            item.height = 28;
            item.toolTip = "Only true heroes can handle its power!";
            item.toolTip2 = "Gives +30% damage output, grants extra knockback and all attacks set enemies on fire.";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player)
        {
            player.meleeDamage *= 1.3F;
            player.magicDamage *= 1.3F;
            player.minionDamage *= 1.3F;
            player.thrownDamage *= 1.3F;
            player.rangedDamage *= 1.3F;

            player.AddBuff(BuffID.WeaponImbueFire, 2);
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
