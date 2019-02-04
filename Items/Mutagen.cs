using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sheep.Items
{
    public class Mutagen : ModItem
    {
        public string ItemTarget = "";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutagen");
            Tooltip.SetDefault("Don't hit the mutated sheeps, unless you're a mad scientist. Then, by all means, hit them ( ps rip PETA 20-no one cares - 2018.");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.damage = 1;
            item.value = 300;
            item.width = 10;
            item.height = 20;
            item.rare = 2;
            item.consumable = true;
            item.melee = true;
            item.useTime = 15;//The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 15;//The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = 1;
            item.autoReuse = false;
        }

        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("SpedSheep"));
            return !alreadySpawned;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
                ItemTarget = target.TypeName;
        }
        public override bool UseItem(Player player)
        {
            if (ItemTarget.Equals("Mutated Sheep"))
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Sped Sheep"));
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SheepBone", 18);
            recipe.AddIngredient(null, "MutantGoo", 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
