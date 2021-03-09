using System;
using Harmony;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace FarmWarpsPatch
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            //send monitor to patch for logging
            Patch.initialize(Monitor);

            //setup harmony
            var harmony = HarmonyInstance.Create(this.ModManifest.UniqueID);

            //patch island obelisk warp
            harmony.Patch(
               original: AccessTools.Method(typeof(StardewValley.Locations.IslandWest), nameof(StardewValley.Locations.IslandWest.performAction)),
               prefix: new HarmonyMethod(typeof(Patch), nameof(Patch.island_performAction_prefix))
            );
        }
    }
}