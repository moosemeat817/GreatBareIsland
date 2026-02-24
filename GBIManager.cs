using Il2CppTLD.Gameplay;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GreatBareIsland
{
    public static class LGBManager
    {


        public static void ModifyForsakenAirfield()
        {
            MelonCoroutines.Start(ModifyForsakenAirfieldCoroutine());
        }

        private static IEnumerator ModifyForsakenAirfieldCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Scene_Art/Blackrock_structures/STRSPAWN_CampTrailerB_Prefab").active = false;

                GameObject.Find("Scene_Art/Blackrock_SmallStructures/STR_CampTrailerDBase_Prefab").active = false;
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying ForsakenAirfield: {ex.Message}");
            }
        }


        public static void ModifyBlackrock()
        {
            MelonCoroutines.Start(ModifyBlackrockCoroutine());
        }

        private static IEnumerator ModifyBlackrockCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Scene_Art/Blackrock_structures/STRSPAWN_CampTrailerB_Prefab").active = false;

                GameObject.Find("Scene_Art/Blackrock_SmallStructures/STR_CampTrailerDBase_Prefab").active = false;

                ObjectUtilities.DisableChildrenByIndex("Scene_Art/Blackrock_Logs", new int[] { 28, 29, 32, 33 });

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying Blackrock: {ex.Message}");
            }
        }



        public static void ModifyBleakInlet()
        {
            MelonCoroutines.Start(ModifyBleakInletCoroutine());
        }

        private static IEnumerator ModifyBleakInletCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {

                GameObject.Find("Art/Docks/STRSPAWN_CampTrailerD_Prefab").active = false;

                GameObject.Find("Art/Structures/Trailers1/STRSPAWN_CampTrailerB_Prefab").active = false;

                GameObject.Find("Art/Structures/Trailers1/STRSPAWN_CampTrailerC_Prefab").active = false;

                GameObject.Find("Art/Structures/Trailers2/STRSPAWN_CampTrailerE_Prefab").active = false;

                GameObject.Find("Art/Structures/Houses/STR_WoodCabinA_Prefab").active = false;

                GameObject.Find("Art/Structures/WoodsCabin/STR_WoodCabinC_Prefab").active = false;

                GameObject.Find("Art/Structures/Houses/STR_LakeCabinABurnt_Prefab").transform.SetPositionAndRotation(new Vector3(170.48f, 29.74f, -432.9301f), Quaternion.Euler(new Vector3(-0, 348f, 0)));

                GameObject.Find("Art/Structures/Houses/STR_LakeCabinBBurnt_Prefab").transform.SetPositionAndRotation(new Vector3(670.8633F, 105.3F, 426.7797f), Quaternion.Euler(new Vector3(-0, 51.6359f, 0)));


                //GameObject.Find("Art/Structures/Trailers2/STR_CampTrailerBBurnt_Collidable_Prefab").transform.SetPositionAndRotation(new Vector3(-642.8597f, 34.49f, -73.3582f), Quaternion.Euler(new Vector3(-0, 152.1455f, 0)));
                GameObject.Find("Art/Docks/OBJ_PicnicBenchA_Prefab").active = false;

                RepositionBurnedTrailers();

                //ObjectUtilities.RepositionChildSpawners("Design/RandomSpawnStructures/RandomBurnedHouses", new int[] { 0, 1, 2, 3 });

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying CanneryRegion: {ex.Message}");
            }
        }

        private static void RepositionBurnedTrailers()
        {
            var trailerPositions = new Dictionary<int, (Vector3 position, Vector3 rotation)>
            {
                { 2, (new Vector3(-642.8597f, 34.49f, -73.3582f), new Vector3(-0, 152.1455f, 0)) },
                { 3, (new Vector3(-746.6644f, 35.95f, -387.7806f), new Vector3(0, 199.4072f, 0)) }

            };
            ObjectUtilities.RepositionChildSpawners("Art/Structures/Trailers2", "STR_CampTrailerBBurnt_Collidable_Prefab", trailerPositions, "trailerPositions");
        }


        public static void ModifyCoastalHighway()
        {
            MelonCoroutines.Start(ModifyCoastalHighwayCoroutine());
        }

        private static IEnumerator ModifyCoastalHighwayCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses", new int[] { 0, 1, 2, 3 });

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/TownNorth", new int[] { 0, 1, 3, 5 });

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/TownNorth/TownNorth2", new int[] { 0, 1, 2, 3, 4 });

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/TownNorth/TownNorth4", new int[] { 0, 1, 2, 3, 4 });

                ObjectUtilities.EnableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses", new int[] { 5 });

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings", new int[] { 0 });

                ObjectUtilities.EnableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings", new int[] { 1 });

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings/Nightmare_burnt", new int[] { 14 });

                ObjectUtilities.DisableChildrenByIndex("Art/Structure_Group/", new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14 });


                GameObject.Find("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings/Nightmare_burnt/STR_LakeCabinCBurnt_Prefab (1)").transform.SetPositionAndRotation(new Vector3(-711.4696f, 27.22f, 662.4203f), Quaternion.Euler(new Vector3(-0, 57.9232f, 0)));
                GameObject.Find("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings/Nightmare_burnt/STR_LakeCabinCBurnt_Prefab (1)").gameObject.transform.localScale = new Vector3(1.1f, 1f, 1.5f);
                GameObject.Find("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings/Nightmare_burnt/STR_LakeCabinCBurnt_Prefab (2)").transform.SetPositionAndRotation(new Vector3(-689.8749f, 26.92f, 675.8708f), Quaternion.Euler(new Vector3(-0, 60.2545f, 0)));
                GameObject.Find("Design/RandomSpawnStructures/RandomBurnedHouses/Nightmare_Burned_Buildings/Nightmare_burnt/STR_LakeCabinCBurnt_Prefab (2)").gameObject.transform.localScale = new Vector3(1.1f, 1f, 1f);


                GameObject.Find("Design/RandomSpawnStructures/RandomBurnedHouses/TownNorth/TownNorth4/STR_HouseExteriorEBurnt_Prefab").transform.SetPositionAndRotation(new Vector3(723.9202f, 24.33f, 585.8109f), Quaternion.Euler(new Vector3(-0, 26.8572f, 0)));
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying CoastalRegion: {ex.Message}");
            }
        }



        public static void ModifyDesolationPoint()
        {
            MelonCoroutines.Start(ModifyDesolationPointCoroutine());
        }

        private static IEnumerator ModifyDesolationPointCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Art/AuoroaLights").active = false;
                GameObject.Find("Art/Structures/STRSPAWN_CampTrailerD_Prefab").active = false;
                GameObject.Find("Art/Structures/TrailerSShape").active = false;

                GameObject.Find("Art/Structures/STR_HouseExteriorABurnt_Prefab").active = true;
                GameObject.Find("Art/Structures/STR_HouseExteriorABurnt_Prefab").transform.SetPositionAndRotation(new Vector3(1027.41f, 18.37f, 1230.449f), Quaternion.Euler(new Vector3(-0, 88.9371f, 0)));
                

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying WhalingStationRegion: {ex.Message}");
            }
        }




        public static void ModifyMountainTown()
        {
            MelonCoroutines.Start(ModifyMountainTownCoroutine());
        }

        private static IEnumerator ModifyMountainTownCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Art/Structures/Town/Houses_AlwaysHere/STRSPAWN_HouseExteriorFMilton_Prefab_3").active = false;

                GameObject.Find("Art/Structures/STRSPAWN_HouseExteriorHMilton_Prefab").active = false;

                GameObject.Find("Art/Structures/STRSPAWN_CampTrailerB_Prefab").active = false;



                GameObject.Find("Art/HermitCabin/STRSPAWN_CabinAExterior_Damaged_Prefab").active = true;
                ObjectUtilities.DisableChildrenByIndex("Art/HermitCabin/STRSPAWN_CabinAExterior_Damaged_Prefab", new int[] { 3 });
                GameObject.Find("Art/HermitCabin/STRSPAWN_CabinAExterior_Damaged_Prefab").transform.SetPositionAndRotation(new Vector3(1000.167f, 358.269f, 2301.13f), Quaternion.Euler(new Vector3(-0, 218.653f, 0)));


            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying MountainTownRegion: {ex.Message}");
            }
        }

        public static void ModifyMountainTown_SANDBOX()
        {
            MelonCoroutines.Start(ModifyMountainTown_SANDBOXCoroutine());
        }

        private static IEnumerator ModifyMountainTown_SANDBOXCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Design/Houses_Random/RandomSpawnObjectBase").active = false;
                GameObject.Find("Design/Houses_Random/RandomHouseGroup1").active = true;
                GameObject.Find("Design/Houses_Random/RandomHouseGroup2").active = true;
                GameObject.Find("Design/Houses_Random/RandomHouseGroup3").active = false;

                ObjectUtilities.DisableChildrenByIndex("Design/Houses_Random/RandomHouseGroup1", new int[] { 5, 6, 7, 8, 10, 12, 14 });
                ObjectUtilities.DisableChildrenByIndex("Design/Houses_Random/RandomHouseGroup2", new int[] { 0, 2, 4, 6, 9, 11, 15, 16 });

                GameObject.Find("Design/Houses_Random/RandomHouseGroup2/STR_HouseExteriorE2MiltonBurnt_Prefab (3)").transform.SetPositionAndRotation(new Vector3(986.976f, 280.4906f, 1554.239f), Quaternion.Euler(new Vector3(-0, 303.0397f, 0)));

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying MountainTownRegion_SANDBOX: {ex.Message}");
            }
        }





        public static void ModifyMysteryLake()
        {
            MelonCoroutines.Start(ModifyMysteryLakeCoroutine());
        }

        private static IEnumerator ModifyMysteryLakeCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                ObjectUtilities.DisableChildrenByIndex("Art/Structures", new int[] { 4, 5, 6, 7, 8, 9 });
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying LakeRegion: {ex.Message}");
            }
        }


        public static void ModifyMysteryLake_SANDBOX()
        {
            MelonCoroutines.Start(ModifyMysteryLake_SANDBOXCoroutine());
        }

        private static IEnumerator ModifyMysteryLake_SANDBOXCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/RandomSpawnObjectBase_lakeCabins").active = false;
                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins_oldsave").active = false;
                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins1").active = true;
                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins2").active = true;
                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins3").active = true;

                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins1", new int[] { 1, 2, 3 });
                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins2", new int[] { 2, 3 });
                ObjectUtilities.DisableChildrenByIndex("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins3", new int[] { 2, 3 });


                GameObject.Find("Design/RandomSpawnStructures/RandomBurned/LakeCabins/LakeCabins1/STR_LakeCabinFBurnt_Prefab").transform.SetPositionAndRotation(new Vector3(1675.027f, 18.3027f, 292.7808f), Quaternion.Euler(new Vector3(-0, 92f, 0)));

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying LakeRegion_SANDBOX: {ex.Message}");
            }
        }





        public static void ModifyPleasantValley()
        {
            MelonCoroutines.Start(ModifyPleasantValleyCoroutine());
        }

        private static IEnumerator ModifyPleasantValleyCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Art/Structures_Group/Town/Updated Location Name").active = false;
                GameObject.Find("Art/Structures_Group/BurnedForest/Update Location Name/notForMisery/STRSPAWN_LakeCabinA_Prefab").active = false;
                GameObject.Find("Art/Structures_Group/NorthFarmLands/BurnedCabins/STR_LakeCabinBBurnt_Prefab").transform.SetPositionAndRotation(new Vector3(2343.602f, 53.18f, 2205.377f), Quaternion.Euler(new Vector3(-0, 189.5934f, 0)));
                GameObject.Find("Art/Structures_Group/NorthFarmLands/BurnedCabins/STR_LakeCabinABurnt_Prefab").transform.SetPositionAndRotation(new Vector3(2312.992f, 52.6773f, 2269.904f), Quaternion.Euler(new Vector3(-0, 335.9886f, 0)));
                GameObject.Find("Art/Structures_Group/NorthFarmLands/BurnedCabins/STR_LakeCabinABurnt_Prefab").gameObject.transform.localScale = new Vector3(1.1f, 1f, 1.04f);

                GameObject.Find("Art/Structures_Group/DerelictFarm/OBJ_CabinExteriorDamagedB_Prefab").transform.SetPositionAndRotation(new Vector3(2293.073f, 52.15f, 2246.402f), Quaternion.Euler(new Vector3(-0, 46f, 0)));
                GameObject.Find("Art/Structures_Group/DerelictFarm/OBJ_CabinExteriorRoofDamagedB_Prefab").transform.SetPositionAndRotation(new Vector3(2298.035f, 53.05f, 2252.817f), Quaternion.Euler(new Vector3(17.5455f, 207f, 15.0001f)));

                GameObject.Find("Art/Structures_Group/NorthFarmLands/STR_HouseExteriorBBurnt_Prefab").transform.SetPositionAndRotation(new Vector3(2287.516f, 54.27f, 2256.392f), Quaternion.Euler(new Vector3(-0, 317.631f, 0)));
                GameObject.Find("Art/Structures_Group/NorthFarmLands/STR_HouseExteriorBBurnt_Prefab").gameObject.transform.localScale = new Vector3(.9f, .9f, .9f);

                GameObject.Find("Art/Structures_Group/Old Cabins/OBJ_CabinExteriorRoofDamagedA_Prefab").transform.SetPositionAndRotation(new Vector3(2452.997f, 53.661f, 2420.336f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Art/Structures_Group/Old Cabins/OBJ_CabinExteriorRoofDamagedB_Prefab").transform.SetPositionAndRotation(new Vector3(2452.997f, 53.461f, 2409.598f), Quaternion.Euler(new Vector3(342f, 0, 354f)));

            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying RuralRegion: {ex.Message}");
            }
        }



        public static void ModifyPleasantValley_SANDBOX()
        {
            MelonCoroutines.Start(ModifyPleasantValley_SANDBOXCoroutine());
        }

        private static IEnumerator ModifyPleasantValley_SANDBOXCoroutine()
        {
            yield return new WaitForSeconds(0.2f);

            try
            {
                GameObject.Find("Design/RandomSpawnStructures/notForMisery").active = false;
                GameObject.Find("Design/RandomSpawnStructures/Misery").active = false;
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying PleasantValley_SANDBOX: {ex.Message}");
            }
        }      

    }
}