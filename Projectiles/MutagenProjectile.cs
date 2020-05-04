using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sheep.Projectiles
{
    public class MutagenProjectile : ModProjectile
    {
        private string ItemTarget = "";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MutagenProjectile");
        }
        public override void SetDefaults()
        {

            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.damage = 6;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ItemTarget = target.TypeName;
            if (ItemTarget.Equals("Mutated Sheep"))
            {
                target.life = 0;
                NPC.NewNPC((int)target.position.X, (int)target.position.Y, mod.NPCType("SpeedSheep"));
            }
        }
      
    }
}
