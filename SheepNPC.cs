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
using Microsoft.Xna.Framework;
namespace Sheep
{
    public class SheepNPC : GlobalNPC
    {
         public bool WooledUp;

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public static bool InForest(NPC npc)   
        {
            Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
            int tileX = (int)(player.Center.X / 16f);
            int tileY = (int)(player.Center.Y / 16f);
            bool inSky = (double)tileY < Main.worldSurface * (Main.hardMode ? 0.44999998807907104 : 0.34999999403953552);

            if (tileY < Main.worldSurface && !inSky && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow
               && !player.ZoneDesert && !player.ZoneGlowshroom && !player.ZoneMeteor && !player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula
               && !player.ZoneTowerStardust)
            {
                //In the Forest
                return true;
            }

            return false;
        }

        public int spawnDust(Vector2 position, int redValue, int greenValue, int blueValue)
        {
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

            int dust = Dust.NewDust(position, 47, 68, mod.DustType("WooledUpDust"), 0f, 0f, 3, new Color(redValue, greenValue, blueValue), 2.171053f);
            return dust;


        }

        //public override void AI(NPC npc)
        //{

        //    if (WooledUp)
        //    {
        //        npc.velocity = new Vector2(0,10f);
        //       // spawnDust(npc.position, 250, 250, 250);
        //    }
        //}

        public override void ResetEffects(NPC npc)
        {
            WooledUp = false;
        }
        public override void PostAI(NPC npc)
        {

            if (WooledUp && npc.boss == false)
            {
                npc.velocity *= 0.95f;
                spawnDust(npc.position, 250, 250, 250);
            }
        }

        private void SpawnDust(Vector2 position, int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
}
