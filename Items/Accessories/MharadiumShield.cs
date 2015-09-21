using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    public class MharadiumShield : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            //equips.Add(EquipType.Shield);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Mharadium Shield";
            item.width = 28;
            item.height = 28;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;

            item.defense = 20;
        }

        public override void UpdateAccessory(Player player)
        {
            player.starCloak = true; // Causes stars to fall when damaged.
            player.longInvince = true; // Extends the invincibility time after being hit.
            player.lavaRose = true; // Reduces damage taken from lava.
            player.fireWalk = true; // Prevents damage from Hellstone and Meteorite blocks.
            player.endurance += 0.2f; // Blocks 20% of incomming damage.
            player.AddBuff(BuffID.PaladinsShield, 2); // Adds the Paladins Shield buff.
            player.AddBuff(BuffID.IceBarrier, 2);
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
