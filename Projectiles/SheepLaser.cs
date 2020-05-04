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
    public class SheepLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sheep Laser");
        }
        public override void SetDefaults()
        {

            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = 0;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.damage = 0;
            
            
        }
       


       public override void AI()           
        {
           
           
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("WooledUp"), 120, true);
            
        }
    } 
}
