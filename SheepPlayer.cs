﻿using System;
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

namespace Sheep
{

    public class SheepPlayer : ModPlayer
    {
        Random rnd = new Random();
        public bool WooledUp = false;
        public bool PurpleWooledUp = false;
        public bool RedWooledUp = false;
        public static bool sheepimmunity = false;
        public static bool sheephalfimmunity = false;




        public override void ResetEffects()
        {
            WooledUp = false;
            PurpleWooledUp = false;
            RedWooledUp = false;
        }



        public override void PostUpdateMiscEffects()
        {
            if (WooledUp == true && sheepimmunity == false)
            {
                if (sheephalfimmunity == false)
                {
                    player.moveSpeed = 0.5f;
                    player.maxRunSpeed = 0.1f;
                    player.accRunSpeed = 1.6f;
                    player.jump = 0;
                }
                else if (sheephalfimmunity == true)
                {
                    player.moveSpeed = 0.75f;
                    player.maxRunSpeed = 0.5f;
                    player.accRunSpeed = 2.0f;
                    player.jump = (int)1;
                }
            }
        }
        public override void UpdateBadLifeRegen()
        {
            if (PurpleWooledUp == true)
            {
                player.lifeRegen -= 10 + (int)(player.statLifeMax / 25);
            }
            if (RedWooledUp == true)
            {
                player.lifeRegen -= 7 + (int)(player.statLife / 15);
            }
        }



        //public override void PostUpdateMiscEffects()
        //{
        //    if (WooledUp == true && sheepimmunity == false)
        //    {
        //        if (sheephalfimmunity == false)
        //        {
        //            player.moveSpeed = 0.5f;
        //            player.maxRunSpeed = 0.1f;
        //            player.accRunSpeed = 1.6f;
        //            player.jump = 0;
        //        }
        //        else if (sheephalfimmunity == true)
        //        {
        //            player.moveSpeed = 0.75f;
        //            player.maxRunSpeed = 0.5f;
        //            player.accRunSpeed = 2.0f;
        //            player.jump = (int)1;
        //        }
        //    }
        //}
    }
}


