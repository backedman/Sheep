using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Sheep
{

    public class SheepPlayer : ModPlayer
    {
        Random rnd = new Random();
        public bool WooledUp = false;
        public bool PurpleWooledUp = false;
        public bool RedWooledUp = false;
        public bool DesertWooledUp = false;
        public bool sheepimmunity = false;
        public bool sheephalfimmunity = false;
        public int counter = 0;

        public int debufftimer(int multiplier)
        {
            if (sheephalfimmunity)
            {
                return (int)(multiplier * 0.5);
            }
            return multiplier * 1;
            
        }

        public int spawnDust(Player player,  int redValue, int greenValue, int blueValue)
        {
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = new Vector2(player.position.X, player.position.Y - 50);
            int dust = Dust.NewDust(position, 47, 47, mod.DustType("WooledUpDust"), 0f, 0f, 3, new Color(redValue, greenValue, blueValue), 2.171053f);
            return dust;
            
      
        }



        public override void ResetEffects()
        {
            WooledUp = false;
            PurpleWooledUp = false;
            RedWooledUp = false;
            DesertWooledUp = false;
        }

        public void WooledUpforEverythingElse()
        {

            if (sheepimmunity == false)
            {
                if (sheephalfimmunity == false)
                {
                    player.slowFall = false;
                    player.moveSpeed = 0.5f;
                    player.maxRunSpeed = 0.1f;
                    player.accRunSpeed = 1.6f;
                    player.jump = 0;
                    player.slowFall = false;
                    //player.wingTimeMax = 10;
                    player.wingTime = 0;
                    //counter++;
                    //if (counter % 5 == 0)
                    //{
                    //    player.velocity = player.velocity / 5;
                    //}


                }
                else if (sheephalfimmunity == true)
                {

                    player.moveSpeed = 0.75f;
                    player.maxRunSpeed = 0.8f;
                    player.accRunSpeed = 2.0f;
                    player.jump = -3;
                    player.wingTime = 0;
                    //player.slowFall = false;


                }
            }
        }

        public override void PostUpdateMiscEffects()
        {

            
            
            if (WooledUp == true && sheepimmunity == false)
            {
                WooledUpforEverythingElse();
                if (Main.rand.NextFloat() < 0.4342105f)
                {
                    spawnDust(player, 250, 250, 250);
                }
            }
            
        }
        public override void UpdateBadLifeRegen()
        {
            
            if (sheepimmunity == false)
            {

                
                if (PurpleWooledUp == true)
                {
                  
                    WooledUpforEverythingElse();

                    if (sheephalfimmunity == true)
                    {
                    }


                    player.lifeRegen -= (int)( 5 + player.statLifeMax / 35 * (50/(50+ player.statDefense)) );
                    
                    if (Main.rand.NextFloat() < 0.4342105f)
                    {
                        spawnDust(player, 150, 0, 150);
                    }
                }
                if (RedWooledUp == true) //crimson sheep's debuff
                {
                    WooledUpforEverythingElse();
                    if (sheephalfimmunity == true)
                    {
                    }

                    player.lifeRegen -= (int)((5 + player.statLife / 25) - (player.statDefense / 4)) * (50 / (50 + player.statDefense));
                    
                    
                    if (Main.rand.NextFloat() < 0.4342105f)
                    {
                        spawnDust(player, 158, 75, 67);
                    }
                }
                if (DesertWooledUp)
                {
                    
                    player.lifeRegen -= 2;
                }
            }
        }

        }
    }


