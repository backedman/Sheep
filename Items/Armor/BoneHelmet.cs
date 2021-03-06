﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Sheep.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BoneHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The helmet made from the fluffiest creature alive");
            DisplayName.SetDefault("Wool Helmet");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BoneChestplate") && legs.type == mod.ItemType("BoneGreaves");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Immune to cold debuffs";
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Frostburn] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SheepBone", 15);
            recipe.AddIngredient(null, "Wool", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

