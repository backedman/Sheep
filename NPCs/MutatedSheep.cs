﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sheep.NPCs
{
    public class MutatedSheep : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutated Sheep");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 32;
            npc.damage = 20; 
            npc.defense = 17;
            npc.lifeMax = 70;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 90f;
            npc.knockBackResist = 0.5f;
            aiType = NPCID.Unicorn;
            npc.aiStyle = 26;
            animationType = 3;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.2f;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            base.ScaleExpertStats(numPlayers, bossLifeScale);
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SheepBone"), Main.rand.Next(2, 5)); //mob has chance of dropping 2-4 SheepBone
           
            if(Main.rand.Next(0,2) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MutantGoo"), Main.rand.Next(1,2)); //mob has chance of dropping 1 Mutant Goo
            }
        }
            public override void OnHitPlayer(Player target, int damage, bool crit)
            {
                target.AddBuff(mod.BuffType("WooledUp"), 400, true); //if player is hit, add WooledUp debuff for 400 ticks
            }
            
    }
}
