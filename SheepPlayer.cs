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
        public static bool sheepimmunity = false;
        public static bool sheephalfimmunity = false;
        public int counter = 0;

        public int spawnDust(Player player,  int redValue, int greenValue, int blueValue)
        {
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = new Vector2(player.position.X, player.position.Y - 50);
            int dust = Dust.NewDust(position, 47, 68, mod.DustType("WooledUpDust"), 0f, 0f, 3, new Color(redValue, greenValue, blueValue), 2.171053f);
            return dust;
            
      
        }



        public override void ResetEffects()
        {
            WooledUp = false;
            PurpleWooledUp = false;
            RedWooledUp = false;
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
                    player.maxRunSpeed = 0.5f;
                    player.accRunSpeed = 2.0f;
                    player.jump = -2;
                    //player.slowFall = false;


                }
            }
        }

        public override void PostUpdateMiscEffects()
        {

            
            
            if (WooledUp == true && sheepimmunity == false)
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
                    player.maxRunSpeed = 0.5f;
                    player.accRunSpeed = 2.0f;
                    player.jump = -2;
                    //player.slowFall = false;
                    
                    
                }
                if (Main.rand.NextFloat() < 0.4342105f)
                {
                    spawnDust(player, 250, 250, 250);
                }
            }
            //else if (DesertWooledUp)
            //{
            //    if (sheephalfimmunity == false)
            //    {
            //        player.moveSpeed = 0.8f;
            //        player.maxRunSpeed = 0.16f;
            //        player.accRunSpeed = 2.9f;
            //        player.jump = 0;
            //    }
            //    else if (sheephalfimmunity == true)
            //    {
            //        player.moveSpeed = .9f;
            //        player.maxRunSpeed = 0.18f;
            //        player.accRunSpeed = 2.88f;
            //        player.jump = (int)1;
            //    }
            //}
        }
        public override void UpdateBadLifeRegen()
        {
            
            if (sheepimmunity == false)
            {

                
                if (PurpleWooledUp == true)
                {
                    counter++;
                    WooledUpforEverythingElse();
                    if (!(sheephalfimmunity))
                    {
                       
                            player.lifeRegen -=  (int)(player.statLifeMax / 20) - player.statDefense/2;
                        
                    }
                    else if (sheephalfimmunity)
                    {
                        player.lifeRegen -= (int)((10 + (player.statLifeMax /25)));
                    }
                    if (Main.rand.NextFloat() < 0.4342105f)
                    {
                        spawnDust(player, 150, 0, 150);
                    }
                }
                if (RedWooledUp == true)
                {
                    WooledUpforEverythingElse();
                    if (!(sheephalfimmunity))
                    {
                        player.lifeRegen -= (int)  (player.statLife / 10);
                    }
                    else if (sheephalfimmunity)
                    {
                        player.lifeRegen -= (int)((3.5 + (player.statLife / 10)) * 0.5);
                    }
                    if (Main.rand.NextFloat() < 0.4342105f)
                    {
                        spawnDust(player, 158, 75, 67);
                    }
                }
                if (DesertWooledUp)
                {
                    WooledUpforEverythingElse();
                    player.lifeRegen -= 2;
                }
            }
        }

        }
    }


