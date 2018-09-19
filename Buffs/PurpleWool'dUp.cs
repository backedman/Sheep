using Sheep.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace Sheep.Buffs
{
    public class PurpleWooledUp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Purple Wool'd Up!");
            Description.SetDefault("You feel the wool slowly corrupting you!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SheepPlayer>(mod).PurpleWooledUp = true;
        }
    }
}