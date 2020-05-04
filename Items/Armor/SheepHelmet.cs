using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Sheep.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    
    public class SheepHelmet : ModItem
    {
        private bool armorset;
        private Player player;

   

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The helmet made from the soft material in the ground");
            DisplayName.SetDefault("Sheep Helmet");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 1;
            
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            if(body.type == mod.ItemType("SheepChestplate") && legs.type == mod.ItemType("SheepGreaves"))
            {
                armorset = true;               
            }
            else
            {
                FullSet(false);
                armorset = false;
            }
            return armorset;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("Wooledup debuff effect reduction \n" +
                               "2 Armor");
            player.GetModPlayer<SheepPlayer>().sheephalfimmunity = true;
            player.statDefense += 2;
            {

            }
        }
        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            this.player = player;
        }
        

        
        private void FullSet(bool b)
        {
            if (player != null)
            {
                player.GetModPlayer<SheepPlayer>().sheephalfimmunity = b;
            }
        }         
      
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SheepBar", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}