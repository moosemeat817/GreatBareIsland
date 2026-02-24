using Il2CppTLD.Gameplay;
using Il2CppTLD.Gameplay.Tunable;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine.Rendering.PostProcessing;
using ModData;
using HarmonyLib;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GreatBareIsland
{
    public class Main : MelonMod
    {
        private static readonly Dictionary<string, System.Action<string>> SceneHandlers = new Dictionary<string, System.Action<string>>
        {
            { "AirfieldRegion", (s) =>  LGBManager.ModifyForsakenAirfield() },
            { "BlackrockRegion", (s) => LGBManager.ModifyBlackrock() },
            { "CanneryRegion", (s) =>  LGBManager.ModifyBleakInlet()  },
            { "CoastalRegion", (s) => LGBManager.ModifyCoastalHighway() },
            { "LakeRegion", (s) =>  LGBManager.ModifyMysteryLake() },
            { "LakeRegion_SANDBOX", (s) => LGBManager.ModifyMysteryLake_SANDBOX() },
            { "MountainTownRegion", (s) => LGBManager.ModifyMountainTown() },
            { "MountainTownRegion_SANDBOX", (s) => LGBManager.ModifyMountainTown_SANDBOX() },
            { "RuralRegion", (s) => LGBManager.ModifyPleasantValley() },
            { "RuralRegion_SANDBOX", (s) =>  LGBManager.ModifyPleasantValley_SANDBOX() },
            { "WhalingStationRegion", (s) => LGBManager.ModifyDesolationPoint() }
        };

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("[GreatBareIsland] Initializing Great Bare Island Mod");
            try
            {
                Settings.OnLoad();
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"[GreatBareIsland] Failed to load settings: {ex.Message}");
            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (GameManager.IsMainMenuActive())
            {

                ObjectUtilities.ClearCache();
          }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName) || !Settings.options.greatBare)
                return;

            // Clear cache at start of each scene load
            ObjectUtilities.ClearCache();


            // Process terrain FIRST (synchronous, uses scene objects)
            //if (Settings.options.Debug)
                MelonLogger.Msg($"[GreatBareIsland] Processing terrain for scene: {sceneName}");





            // Process scene-specific handlers
            if (SceneHandlers.TryGetValue(sceneName, out var handler))
            {
                try
                {
                    //if (Settings.options.Debug)
                        MelonLogger.Msg($"[GreatBareIsland] Executing handler for scene: {sceneName}");

                    handler.Invoke(sceneName);
                }
                catch (System.Exception ex)
                {
                    MelonLogger.Error($"[GreatBareIsland] Error in handler for {sceneName}: {ex.Message}\n{ex.StackTrace}");
                }
            }
            /*
            else if (Settings.options.Debug)
            {
                MelonLogger.Msg($"[GreatBareIsland] No handler defined for scene: {sceneName}");
            }
            */
        }


    }
}