using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;

namespace Mharadium.NPCs.Boss
{
    public class Thrasher : ModNPC
    {
        private int currentAI = -1;

        public override void SetDefaults()
        {
            npc.name = "Thrasher";
            npc.width = 15;
            npc.height = 38;
            npc.damage = 300;
            npc.defense = 75;
            npc.lifeMax = 125000;
            npc.soundHit = 2;
            npc.soundKilled = 2;
            npc.knockBackResist = 0F;
            npc.value = Item.sellPrice(5, 0, 0, 0);
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.boss = true;
            music = 24;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];

            /*if (npc.life >= (npc.lifeMax / 2)) // If the Thrasher has more than half it's health left.
            {
                if (npc.life < (npc.lifeMax / 2))
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    currentAI = 1;
                }
            }
            else // If the Thrasher has less than half it's health
            {*/
                if (currentAI < 0) // First time in rage mode.
                {
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    npc.ai[3] = 0;
                    currentAI = 0;
                }

                if (currentAI <= 3)
                {
                    if ((double)npc.ai[2] != 0.0 && (double)npc.ai[3] != 0.0)
                    {
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                        for (int i = 0; i < 50; ++i)
                        {
                            int dustID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 174, 0.0F, 0.0F, 100, new Color(), 1.5F);
                            Main.dust[dustID].velocity *= 3F;
                            Main.dust[dustID].noGravity = true;
                        }
                        npc.position.X = (float)(npc.ai[2] * 16 - (npc.width / 2) + 8);
                        npc.position.Y = npc.ai[3] * 16 - npc.height;
                        npc.velocity.X = 0.0F;
                        npc.velocity.Y = 0.0F;
                        npc.ai[2] = 0.0F;
                        npc.ai[3] = 0.0F;
                        Main.PlaySound(2, npc.position, 8);
                        for (int i = 0; i < 50; ++i)
                        {
                            int dustID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 174, 0.0F, 0.0F, 100, new Color(), 1.5F);
                            Main.dust[dustID].velocity *= 3F;
                            Main.dust[dustID].noGravity = true;
                        }
                    }
                    ++npc.ai[0];

                    if ((double)npc.ai[0] == 20.0 || (double)npc.ai[0] == 60.0 || (double)npc.ai[0] == 100.0)
                    {
                        npc.ai[1] = 30f;
                        npc.netUpdate = true;
                    }

                    if ((double)npc.ai[0] >= 120.0 && Main.netMode != 1)
                    {
                        npc.ai[0] = 1F;
                        npc.ai[1] = -1;
                        currentAI++;
                        Teleport();

                        if (currentAI > 3)
                        {
                            npc.ai[0] = 0;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            npc.ai[3] = 0;
                        }
                    }
                    if ((double)npc.ai[1] > 0.0) // Shooting
                    {
                        --npc.ai[1];
                        if (npc.ai[1] == 25.0F)
                        {
                            if (Main.netMode != 1)
                            {
                                float num1 = 10F;
                                Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5F, npc.position.Y); // The center of this npc.
                                float dirX = player.position.X + player.width * 0.5F - vector2.X; // The direction over the X axis.
                                float dirY = player.position.Y + player.height * 0.5F - vector2.Y; // The direction over the Y axis.

                                float angle = (float)Math.Sqrt((double)dirX * (double)dirX + (double)dirY * (double)dirY); // Get the angle towards the target.
                                float num7 = num1 / angle;
                                float speedX = dirX * num7;
                                float speedY = dirY * num7;
                                int damage = 40;
                                int type = mod.ProjectileType("MharadiumInferno");
                                int projID = Projectile.NewProjectile(vector2.X, vector2.Y, speedX, speedY, type, damage, 0.0F, Main.myPlayer);
                                Main.projectile[projID].timeLeft = 300;
                                npc.localAI[0] = 0.0f;
                            }
                        }
                    }
                }
                else if (currentAI == 4)
                {
                    ++npc.ai[0];

                    if (npc.ai[0] >= 50)
                    {
                        npc.velocity *= 4F;
                        if ((double)npc.velocity.X > 8)
                            npc.velocity.X = 8F;
                        if ((double)npc.velocity.Y > 8)
                            npc.velocity.Y = 8F;
                        if ((double)npc.velocity.X < -8)
                            npc.velocity.X = -8F;
                        if ((double)npc.velocity.Y < -8)
                            npc.velocity.Y = -8F;
                        npc.netUpdate = true;
                        ++npc.ai[1]; // Count the dashes.
                        npc.ai[0] = 0;
                    }
                }
            //}

            if (Main.rand.Next(2) != 0)
                return;
            int ID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 174, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, new Color(), 1f);
            Main.dust[ID].noGravity = true;
            Main.dust[ID].velocity *= 0.4f;
            Dust dust = Main.dust[ID];
            dust.velocity.Y = dust.velocity.Y - 0.7f;
        }

        private void Teleport()
        {
            int targetTilePosX = (int)Main.player[npc.target].position.X / 16;
            int targetTilePosY = (int)Main.player[npc.target].position.Y / 16;
            int npcTilePosX = (int)npc.position.X / 16;
            int npcTilePosY = (int)npc.position.Y / 16;
            int num5 = 35; // The random range to which the npc teleports.
            int num6 = 0;
            bool flag1 = false;
            if ((double)Math.Abs(npc.position.X - Main.player[npc.target].position.X) + (double)Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000.0)
            {
                num6 = 100;
                flag1 = true;
            }
            while (!flag1 && num6 < 100)
            {
                ++num6;
                int X = Main.rand.Next(targetTilePosX - num5, targetTilePosX + num5);
                for (int Y = Main.rand.Next(targetTilePosY - num5, targetTilePosY + num5); Y < targetTilePosY + num5; ++Y)
                {
                    if ((Y < targetTilePosY - 4 || Y > targetTilePosY + 4 || (X < targetTilePosX - 4 || X > targetTilePosX + 4)) &&
                        (Y < npcTilePosY - 1 || Y > npcTilePosY + 1 || (X < npcTilePosX - 1 || X > npcTilePosX + 1)) && Main.tile[X, Y].nactive())
                    {
                        bool flag2 = true;
                        if (Main.tile[X, Y].lava()) // Do not teleport inside lava.
                            flag2 = false;
                        if (flag2 && !Collision.SolidTiles(X - 1, X + 1, Y - 4, Y - 1))
                        {
                            npc.ai[1] = 20f;
                            npc.ai[2] = (float)X;
                            npc.ai[3] = (float)Y;
                            flag1 = true;
                            break;
                        }
                    }
                }
            }
            npc.netUpdate = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = 0;
            npc.spriteDirection = npc.direction;
        }
    }
}
