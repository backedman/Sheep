using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sheep.Projectiles;

namespace Sheep.NPCs.Bosses.SpeedSheep
{
    public class SpeedSheep : ModNPC
    {
        private Player player;
        private float speed;
        private int countdown;
        private bool startedJumpToPound = false;
        private int groundPoundCountdown = 0;
        private int groundPoundNumber = 0;
        private Vector2 jumpVectorBase = new Vector2(0f, 0f);
        private int timer = 0;
        private int stuckCounter = 0;
        public bool alive;
        public bool reachedhere;
        private int buffer = 0;
        private int gptimer = 1;
        private int timesincedash = 61;
        Vector2 lastPosition = new Vector2(0f, 0f);
        Vector2[] playerCenter;
        int[] ai2 = new int[2];
        Vector2 playerPos;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Speed Sheep");
            
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 300;
            npc.height = 225;
            npc.damage = 30;
            npc.defense = 10;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 10000f;
            npc.knockBackResist = -4f;
            npc.aiStyle = 26;
            animationType = 3;
            
            npc.npcSlots = 2f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true; // Not hurt by lava
            npc.noGravity = false; // Not affected by gravity
            npc.noTileCollide = false; // Will not collide with the tiles. 
            
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.Boss1;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("WooledUp"), 400, true);

        }
        private float MagnitudeLaser(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        private float MagnitudeBody(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
            
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                   return;
                }
              }
        }

        private float getHypotenuse() {
            return (float)Math.Sqrt(Math.Pow((player.Center.X - npc.Center.X), 2) + Math.Pow((player.Center.Y- npc.Center.Y), 2));
              
        }

        private void Shoot()
        {
            int type = mod.ProjectileType("SheepLaser");
            Vector2 vector = 15 * (new Vector2(player.Center.X, player.Center.Y) - npc.Center) / getHypotenuse();
            Projectile.NewProjectile(npc.Center, vector, type, (int) 8.4 , 2f, 255);
            npc.ai[1] = 150f;
        }

        private void Dash()
        {
            npc.noTileCollide = true;
            Vector2 velocity = new Vector2(player.Center.X, player.Center.Y - (Math.Abs(player.Center.X - npc.Center.X))/2) * 0.015f - npc.Center * 0.015f;
            npc.velocity += velocity;
            ai2[0] = 625;
        }

        private void JumpToGroundPound()
        {
            npc.noTileCollide = true;
            jumpVectorBase = new Vector2(player.Center.X, player.Center.Y - 500) - npc.Center;    
            Vector2 velocity = jumpVectorBase * (1+timer/60) / Math.Max(24, Math.Abs(player.Center.X - npc.Center.X)/30);
            timer++;
            npc.velocity = velocity;
                
            if (npc.position.X <= playerPos.X + 20 && npc.position.X +npc.width/2 >= playerPos.X+player.width-20 && npc.position.Y < player.position.Y-500 || timer > 180)
            {
                timer = 0;
                jumpVectorBase = new Vector2(0f, 0f);
                groundPoundCountdown = 120;
                GroundPound(); 
            }     
          
        }
        private void GroundPound()
        {
            npc.velocity = new Vector2(0, 100f * (1+ gptimer/120) );
            gptimer++;
            npc.noTileCollide = true;

            if (npc.position.Y + npc.height >= player.position.Y + player.height)
            {
                gptimer = 1;
                groundPoundCountdown = 0;
                Shockwave();
                buffer = 120;
                npc.noTileCollide = false;

                startedJumpToPound = false;
                if (groundPoundNumber == 3) {
                    ai2[1] = (int) (npc.life*1.4f)+20;
                    groundPoundNumber = 0;
                }
                else if (npc.life < npc.lifeMax/4)
                {
                    ai2[1] = 20;
                    groundPoundNumber += 1;
                }
                else if (npc.life < npc.lifeMax/2)
                    ai2[1] = 600;
                else
                    ai2[1] = 1000; 
            }
           
        }
        private void Shockwave()
        {
            int type = mod.ProjectileType("Shockwave");
            Vector2 velocityRight = new Vector2(5,0);
            Vector2 velocityLeft = new Vector2(-5, 0);
            Projectile.NewProjectile(new Vector2(npc.position.X + npc.width - 28, npc.position.Y + npc.height - 56 ), velocityRight, type, 0, 2f, 255);
            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y + npc.height - 56), velocityLeft, type, 0, 2f, 255);
        }

        public override void AI()
        {
            if (alive != true)
            {
                alive = true;
            }

            //buffer--;
            //if (buffer <= 0)
            //{
                Target(); // Sets the Player Target

                DespawnHandler(); // Handles if the NPC should despawn.

            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            ai2[0]--;
            
            if (npc.ai[1] <= 0f)
            {
                Shoot();
            }

            if (ai2[0] <= 0f && startedJumpToPound == false && groundPoundCountdown == 0 || Math.Abs(player.position.X - Math.Abs(npc.position.X + npc.width / 2)) > 400 && ai2[0] < 312)
            {
                Dash();
                timesincedash = 0;
            }
            timesincedash++;
            if(timesincedash > 20)
            {
                npc.noTileCollide = false;
            }
            
            if  (lastPosition == npc.position)
                stuckCounter++;
            else
                stuckCounter = 0;
            lastPosition = npc.position;
            if(stuckCounter == 6)
            {
                ai2[1] = 0;
            }
            if (Main.expertMode && npc.life <= npc.lifeMax/2 || stuckCounter == 6)
                {
                    ai2[1]--;
                if (ai2[1] <= 0f)
                {
                    if (startedJumpToPound == false)
                    {

                        startedJumpToPound = true;
                    }
                    if (groundPoundCountdown == 0) { 
                        playerPos = player.position;
                        JumpToGroundPound();
                    }
                    else
                        GroundPound();
                           
                    }
                }
          //  }
            //else
            //    npc.velocity = lastPosition;

        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax + 500 * numPlayers);

        }
        private void Target()
        {
            player = Main.player[npc.target]; // This will get the player target.
        }
    }
}
