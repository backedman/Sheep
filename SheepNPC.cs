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

namespace Sheep
{
    public class SheepNPC : GlobalNPC
    { 
      public static float SpawnInForest(NPC npc,float chance)
        {
            Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
            int tileX = (int)(player.Center.X / 16f);
            int tileY = (int)(player.Center.Y / 16f);
            bool inSky = (double)tileY < Main.worldSurface * (Main.hardMode ? 0.44999998807907104 : 0.34999999403953552);
            if (tileY < Main.worldSurface && !inSky && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneDesert && !player.ZoneGlowshroom)
            {
                //In the Forest
                if (!player.ZoneMeteor && !player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust)
                {
                    //Strictly no other biomes
                    return chance;
                }
                else
                {
                    return 0;
                }
            }
            else return 0;
        }
    }
}
