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
    public class Shockwave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shockwave");
        }
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 56;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 60;
            projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.damage = 30;
        }


        //public Shockwave(Vector2 loc, Vector2 vector) {

        //    //int type = mod.ProjectileType("ShockWave");
        //    //Projectile.NewProjectile(loc, vector, type, projectile.damage, 2f, 255);
        //}

       public override void AI()           //this make that the projectile will face the corect way
       {
                
       }
       public override void OnHitPlayer(Player target, int damage, bool crit)
       {
           //target.AddBuff(mod.BuffType("WooledUp"), 350, true);
       }
    } 
}
