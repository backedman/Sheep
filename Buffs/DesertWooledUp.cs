using Sheep.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace Sheep.Buffs
{
    public class DesertWooledUp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Desert Wool'd Up!");
            Description.SetDefault("The wool is too thin to impair your movement, but it is coarse and iritating");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SheepPlayer>().DesertWooledUp = true;
        }
    }
}