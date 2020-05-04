using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Sheep.Projectiles;

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
            item.maxStack = 20;
            item.damage = 1;
            item.useStyle = 1;
            item.shootSpeed = 20f;
            item.value = 300;
            item.width = 20;
            item.height = 40;
            item.rare = 2;
            item.consumable = true;
            item.noMelee = true;
            item.useTime = 15;//The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 15;//The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = 1;
            item.autoReuse = false;
            item.thrown = true;
            item.shoot = ProjectileType<MutagenProjectile>();
        }

        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("SpeedSheep"));
            return !alreadySpawned;
        }

        /*public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
                ItemTarget = target.TypeName;
                if(ItemTarget.Equals("Mutated Sheep"))
                {
                    target.life = 0;
                    NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("SpeedSheep"));
                }   
        }
        */
        //public override bool UseItem(Player player)
        //{
        //    if (ItemTarget.Equals("Mutated Sheep"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SheepBone", 18);
            recipe.AddIngredient(null, "MutantGoo", 3);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
