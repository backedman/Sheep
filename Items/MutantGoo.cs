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
        public class MutantGoo : ModItem
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Mutant Goo");
                Tooltip.SetDefault("Goo from Mutant Sheep... from another time");
            }
            public override void SetDefaults()
            {
                item.maxStack = 99;
                item.value = 50;
                item.width = 10;
                item.height = 20;
                item.rare = 1;
            }
            
        }
}

