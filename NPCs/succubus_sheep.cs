//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace Sheep.NPCs
//{
//    public class succubus_sheep : ModNPC
//    {
//        public override void SetStaticDefaults()
//        {
//            npc.width = 38;
//            npc.height = 20;
//            npc.damage = 40;
//            npc.defense = 5;
//            npc.lifeMax = 25;
//            npc.HitSound = SoundID.NPCHit1;
//            npc.DeathSound = SoundID.NPCDeath2;
//            npc.value = 90f; //money drop
//            npc.knockBackResist = 1.0f; //kbr
//            npc.aiStyle = 26; //acts like unicorn
//            aiType = NPCID.Pixie; //acts like a unicorn
//            animationType = NPCID.Pixie;
//        }
//        public override float SpawnChance(NPCSpawnInfo spawnInfo)
//        {
//            return SpawnCondition.Underworld.Chance * 0.02f;
//        }
//        public override void NPCLoot()
//        {
//            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("10Gold"), Main.rand.Next(0,1));
//        }

//    }
//}
