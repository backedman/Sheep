using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Sheep.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BoneGreaves : ModItem
    { 
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoes made from the fluffiest creatures alive.");
            DisplayName.SetDefault("Wool Greaves");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.defense = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SheepBone", 15);
            recipe.AddIngredient(null, "Wool", 10);
            recipe.AddTile(TileID.WorkBenches); //can be crafted on work benches
            recipe.SetResult(this); //you need thi
            recipe.AddRecipe();
        }
    }
}
