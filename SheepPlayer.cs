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

namespace Sheep
{
    
    public class SheepPlayer : ModPlayer
    {
        Random rnd = new Random();
        public bool WooledUp = false;
        public static bool sheepimmunity = false;
        public static bool sheephalfimmunity = false;
        public static bool sheeparmored = false;
        public int[] WooledUpDuration;
        private static int WooledUpcounter = 350;
        public static bool check = true;
        private static float WooledUpDecay = (float)Math.Sqrt(WooledUpcounter);
        public override void ResetEffects()
        {
            WooledUp = false;
        }
        
        public override void PostUpdateMiscEffects()
        {
            
           if(WooledUp == true && sheepimmunity == false)
           {
               

               if (sheephalfimmunity == false)
               {
                    player.moveSpeed = (float)(0.5*rnd.NextDouble()+.5);//(int)Math.Pow(WooledUpcounter, 1/3);
                    player.maxRunSpeed = (float)(0.1*rnd.NextDouble()+.1);  //(int)Math.Pow(WooledUpcounter, 1 / 3);
                    player.accRunSpeed = (float)(0.8*rnd.NextDouble()+.8);  //(int)Math.Pow(WooledUpcounter, 1 / 3);
                    player.jump = rnd.Next(0,1);
               }
               else if (sheephalfimmunity == true)
               {
                   player.moveSpeed = (float)(1.5*rnd.NextDouble());
                    player.maxRunSpeed = (float)(0.3*rnd.NextDouble());
                    player.accRunSpeed = (float)(0.24 * rnd.NextDouble());
                    player.jump = rnd.Next(1,2);
               }
           }
        }
        public bool HasSheepitemCheck()
        {
            if (player.HasItem(mod.ItemType("Bone Pickaxe")) == true)
            {
                return true;
            }
            else
            {
                return false;
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
        public static bool HasSheepitem
        {
            get
            {
                return HasSheepitem;
            }
        }
    }
}
/*	public void AddBuff(int type, int time1, bool quiet = true)
		{
			if (this.buffImmune[type])
			{
				return;
			}
			int num = time1;
			if (Main.expertMode && this.whoAmI == Main.myPlayer && BuffLoader.LongerExpertDebuff(type))
			{
				num = (int)(Main.expertDebuffTime * (float)num);
			}
			if (!quiet && Main.netMode == 1)
			{
				bool flag = true;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == type)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					NetMessage.SendData(55, -1, -1, null, this.whoAmI, (float)type, (float)num, 0f, 0, 0, 0);
				}
			}
			int num2 = -1;
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] == type)
				{
					if (!BuffLoader.ReApply(type, this, num, j))
					{
						if (type == 94)
						{
							this.buffTime[j] += num;
							if (this.buffTime[j] > Player.manaSickTimeMax)
							{
								this.buffTime[j] = Player.manaSickTimeMax;
								return;
							}
						}
						else if (this.buffTime[j] < num)
						{
							this.buffTime[j] = num;
						}
					}
					return;
				}
			}
			if (Main.vanityPet[type] || Main.lightPet[type])
			{
				for (int k = 0; k < 22; k++)
				{
					if (Main.vanityPet[type] && Main.vanityPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
					if (Main.lightPet[type] && Main.lightPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
				}
			}
			while (num2 == -1)
			{
				int num3 = -1;
				for (int l = 0; l < 22; l++)
				{
					if (!Main.debuff[this.buffType[l]])
					{
						num3 = l;
						break;
					}
				}
				if (num3 == -1)
				{
					return;
				}
				for (int m = num3; m < 22; m++)
				{
					if (this.buffType[m] == 0)
					{
						num2 = m;
						break;
					}
				}
				if (num2 == -1)
				{
					this.DelBuff(num3);
				}
			}
			this.buffType[num2] = type;
			this.buffTime[num2] = num;
			if (Main.meleeBuff[type])
			{
				for (int n = 0; n < 22; n++)
				{
					if (n != num2 && Main.meleeBuff[this.buffType[n]])
					{
						this.DelBuff(n);
					}
				}
			}
		}
        **/
