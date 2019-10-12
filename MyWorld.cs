﻿using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;


namespace ChestImplants {
	class ChestStufferGenPass : GenPass {
		public ChestStufferGenPass() : base( "ChestImplants: Stuff Chests", 1f ) { }


		////////////////

		public override void Apply( GenerationProgress progress ) {
			for( int i=0; i<Main.chest.Length; i++ ) {
				Chest mychest = Main.chest[i];
				if( mychest == null || ChestImplantStuffer.IsChestEmpty(mychest) ) { continue; }

				ChestImplantStuffer.StuffChest( mychest );

				progress.Value = (float)i / (float)Main.chest.Length;
			}
		}
	}




	class ChestImplantsWorld : ModWorld {
		public override void ModifyWorldGenTasks( List<GenPass> tasks, ref float totalWeight ) {
			tasks.Add( new ChestStufferGenPass() );
		}
	}
}