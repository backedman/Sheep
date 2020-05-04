using Sheep.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace Sheep.Buffs
{
    public class RedWooledUp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Red Wool'd Up!");
            Description.SetDefault("You are ensnared by barbed threads of wool!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SheepPlayer>().RedWooledUp = true;
        }
    }
}