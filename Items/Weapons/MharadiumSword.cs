using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    /// <summary>
    /// Not yet finished!
    /// </summary>
    public class MharadiumSword : ModItem
    {
        private int currentSwing = 0;

        public override void SetDefaults()
        {
            item.name = "Mharadium Sword";
            item.width = 56;
            item.height = 56;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.damage = 700;
            item.crit += 25;

            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.autoReuse = true;
            item.melee = true;
            item.useTurn = true;
            item.knockBack = 6.5F;
            item.scale = 1.1F;

            item.shoot = mod.ProjectileType("DevilsBeam");
            item.shootSpeed = 12F; // The speed at which the projectile will travel.

            item.useSound = 1;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 30);
            target.AddBuff(BuffID.Ichor, 30);
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }

        /// <summary>
        /// To be implemented.
        /// </summary>
        public override bool UseItem(Player player)
        {
            currentSwing++;
            if (currentSwing % 2 == 0)
            {
                return true;
            }
            return false;
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
