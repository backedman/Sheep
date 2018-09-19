using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sheep.NPCs
{
    public class CorruptedSheep : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted Sheep");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 20;
            npc.damage = 15;
            npc.defense = 30;
            npc.lifeMax = 25;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 110f; //money drop
            npc.knockBackResist = 4.0f; //kbr
            npc.aiStyle = 26; //acts like unicorn
            aiType = NPCID.Unicorn; //acts like a unicorn
            animationType = 3;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (SheepNPC.InForest(this.npc))
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
            }
            else
            {
                return 0;
            }
        }


        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SheepBone"), Main.rand.Next(4, 6));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Wool"), Main.rand.Next(5, 7));
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {

            target.AddBuff(mod.BuffType("WooledUp"), 250, true);
            target.AddBuff(mod.BuffType("PurpleWooledUp"), 250, true);
        }
    }
}