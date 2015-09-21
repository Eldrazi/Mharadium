using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Accessories
{
    public class MharadiumSuperPowers : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mharadium Super Powers";
            item.width = 24;
            item.height = 24;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;
            item.accessory = true;

            item.defense = 20;
        }

        public override void UpdateAccessory(Player player)
        {
            #region Boots Buffs
            player.moveSpeed *= 1.5F; // Increases move speed by 50%.
            player.noFallDmg = true; // Negate any fall damage.
            player.waterWalk = true; // Walk on liquids.
            player.lavaMax += 600; // 10 seconds of lava immunity.
            player.dash = 1; // Grants the ability to dash once.
            player.jumpBoost = true; // Allows the player to jump higher.
            player.doubleJumpCloud = true; // Allows double jumping.
            player.accRunSpeed = 10f; // Extra run speed max.
            player.moveSpeed += 0.15f; // Extra move speed.
            #endregion
            #region Shield Buffs
            player.starCloak = true; // Causes stars to fall when damaged.
            player.longInvince = true; // Extends the invincibility time after being hit.
            player.lavaRose = true; // Reduces damage taken from lava.
            player.fireWalk = true; // Prevents damage from Hellstone and Meteorite blocks.
            player.endurance += 0.2f; // Blocks 20% of incomming damage.
            player.AddBuff(BuffID.PaladinsShield, 2); // Adds the Paladins Shield buff.
            player.AddBuff(BuffID.IceBarrier, 2);
            #endregion
            #region Emblem Buffs
            player.meleeDamage *= 1.3F;
            player.magicDamage *= 1.3F;
            player.minionDamage *= 1.3F;
            player.thrownDamage *= 1.3F;
            player.rangedDamage *= 1.3F;

            player.AddBuff(BuffID.WeaponImbueFire, 2);
            #endregion
            #region Magic Ball Buffs
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
            #endregion
            #region Health Band Buffs
            player.lifeRegen *= 10; // Extreme mana regen.

            player.lifeMagnet = true; // Attracts heart from a longer distance.
            player.AddBuff(BuffID.Lifeforce, 2); // Adds the LifeForce buff.
            #endregion
            player.AddBuff(BuffID.Inferno, 2); // Adds the Inferno buff.
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
