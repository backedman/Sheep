using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sheep.NPCs
{
    public class SheepZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Standing Zombie Sheep");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 24;
            npc.height = 38;
            npc.damage = 10;
            npc.defense = 7;
            npc.lifeMax = 50;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.6f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("WooledUp"), 300, true);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SheepBone"), Main.rand.Next(2, 5));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Wool"), Main.rand.Next(0, 2));
        }
    }
}
