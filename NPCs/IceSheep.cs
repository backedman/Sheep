﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sheep.NPCs
{
    public class IceSheep : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Sheep");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 20;
            npc.damage = 1;
            npc.defense = 25;
            npc.lifeMax = 15;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 120f; //money drop
            npc.knockBackResist = .7f; //kbr
            npc.aiStyle = 26; //acts like unicorn
            aiType = NPCID.Unicorn; //acts like a unicorn
            animationType = 3;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneSnow)
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SheepBone"), Main.rand.Next(2, 5));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Wool"), Main.rand.Next(3, 5));
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Chilled, 200, true);
            target.AddBuff(mod.BuffType("WooledUp"), 200, true);
        }
    }
}
