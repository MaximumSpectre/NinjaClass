using NinjaClass.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Projectiles.Hardmode;

namespace NinjaClass.Items.Weapons.Hardmode
{
	// This class handles everything for our custom damage class
	// Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
	public class NightTerror : NinjaItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = 15f;
			item.damage = 40;
			item.knockBack = 0.1f;
			item.useStyle = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.rare = 3;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.crit = 4;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 5);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<NightTerrorProjectile>();
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Cavity"), 1);
            recipe.AddIngredient(mod.ItemType("StingingNettle"), 1);
			recipe.AddIngredient(mod.ItemType("SearingEdge"), 1);
            recipe.AddIngredient(mod.ItemType("Saiyonara"), 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Gingivitis"), 1);
            recipe.AddIngredient(mod.ItemType("StingingNettle"), 1);
			recipe.AddIngredient(mod.ItemType("SearingEdge"), 1);
            recipe.AddIngredient(mod.ItemType("Saiyonara"), 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		// By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
		// We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work
		}

		// As a modder, you could also opt to make these overrides also sealed. Up to the modder
	}
}
