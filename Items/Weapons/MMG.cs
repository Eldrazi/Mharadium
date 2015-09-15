using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mharadium.Items.Weapons
{
    public class MMG : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "M.M.G.";
            item.width = 62;
            item.height = 26;
            item.toolTip = "Only true heroes can handle its power!";
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 10;

            item.damage = 130;
            item.crit += 20;

            item.ranged = true;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.autoReuse = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.useSound = 40;
            item.shoot = 10;
            item.shootSpeed = 12F;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 30);
            target.AddBuff(BuffID.Ichor, 30);
            base.OnHitNPC(player, target, damage, knockBack, crit);
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
