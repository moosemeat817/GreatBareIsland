using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace GreatBareIsland
{
    public static class ObjectUtilities
    {
        // Cache for GameObject lookups to avoid repeated Find() calls
        private static Dictionary<string, GameObject> gameObjectCache = new Dictionary<string, GameObject>();

        // Clear cache when scene changes
        public static void ClearCache()
        {
            gameObjectCache.Clear();
        }

        // Cached GameObject.Find with fallback
        private static GameObject FindCached(string path)
        {
            if (gameObjectCache.TryGetValue(path, out GameObject cached) && cached != null)
                return cached;

            GameObject found = GameObject.Find(path);
            if (found != null)
                gameObjectCache[path] = found;

            return found;
        }

        // Utility method to disable game objects
        public static void DisableGameObjects(string[] objectPaths)
        {
            if (objectPaths == null || objectPaths.Length == 0)
                return;

            int disabledCount = 0;
            foreach (string path in objectPaths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                GameObject obj = FindCached(path);
                if (obj != null)
                {
                    obj.SetActive(false);
                    disabledCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Disabled {disabledCount} objects");
        }

        // Utility method for safely disabling objects (doesn't warn if not found)
        public static void SafeDisable(string objectPath)
        {
            if (string.IsNullOrEmpty(objectPath))
                return;

            GameObject obj = FindCached(objectPath);
            if (obj != null)
                obj.SetActive(false);
        }

        // Utility method to disable children by index
        public static void DisableChildrenByIndex(string parentPath, int[] childIndices)
        {
            if (string.IsNullOrEmpty(parentPath) || childIndices == null || childIndices.Length == 0)
                return;

            GameObject parent = FindCached(parentPath);
            if (parent == null)
                return;

            Transform parentTransform = parent.transform;
            int childCount = parentTransform.childCount;

            foreach (int index in childIndices)
            {
                if (index >= 0 && index < childCount)
                {
                    Transform child = parentTransform.GetChild(index);
                    if (child != null)
                        child.gameObject.SetActive(false);
                }
            }
        }

        // Helper method to disable children by index for ALL objects matching a name
        public static void DisableChildrenByIndexForAllMatching(string objectName, int[] childIndices)
        {
            if (string.IsNullOrEmpty(objectName) || childIndices == null || childIndices.Length == 0)
                return;

            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            int processedCount = 0;

            foreach (GameObject obj in allObjects)
            {
                if (obj.name != objectName)
                    continue;

                Transform objTransform = obj.transform;
                int childCount = objTransform.childCount;

                foreach (int index in childIndices)
                {
                    if (index >= 0 && index < childCount)
                    {
                        Transform child = objTransform.GetChild(index);
                        if (child != null)
                            child.gameObject.SetActive(false);
                    }
                }
                processedCount++;
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Disabled children for {processedCount} instances of '{objectName}'");
        }

        // Utility method to enable children by index
        public static void EnableChildrenByIndex(string parentPath, int[] childIndices)
        {
            if (string.IsNullOrEmpty(parentPath) || childIndices == null || childIndices.Length == 0)
                return;

            GameObject parent = FindCached(parentPath);
            if (parent == null)
                return;

            Transform parentTransform = parent.transform;
            int childCount = parentTransform.childCount;

            foreach (int index in childIndices)
            {
                if (index >= 0 && index < childCount)
                {
                    Transform child = parentTransform.GetChild(index);
                    if (child != null)
                        child.gameObject.SetActive(true);
                }
            }
        }

        // Utility method to reposition child spawners by index
        public static void RepositionChildSpawners(string parentPath, string childName, Dictionary<int, (Vector3 position, Vector3 rotation)> indexPositions, string objectType = "spawners")
        {
            if (string.IsNullOrEmpty(parentPath) || string.IsNullOrEmpty(childName) || indexPositions == null || indexPositions.Count == 0)
                return;

            GameObject parent = FindCached(parentPath);
            if (parent == null)
                return;

            Transform parentTransform = parent.transform;
            int childCount = parentTransform.childCount;
            int repositionedCount = 0;

            foreach (var entry in indexPositions)
            {
                int index = entry.Key;
                if (index < 0 || index >= childCount)
                    continue;

                Transform child = parentTransform.GetChild(index);
                if (child != null && child.name.Contains(childName))
                {
                    child.SetPositionAndRotation(
                        entry.Value.position,
                        Quaternion.Euler(entry.Value.rotation)
                    );
                    repositionedCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Repositioned {repositionedCount} {objectType}");
        }

        // Overloaded version with scale support
        public static void RepositionChildSpawners(string parentPath, string childName, Dictionary<int, (Vector3 position, Vector3 rotation, Vector3? scale)> indexPositions, string objectType = "spawners")
        {
            if (string.IsNullOrEmpty(parentPath) || string.IsNullOrEmpty(childName) || indexPositions == null || indexPositions.Count == 0)
                return;

            GameObject parent = FindCached(parentPath);
            if (parent == null)
                return;

            Transform parentTransform = parent.transform;
            int childCount = parentTransform.childCount;
            int repositionedCount = 0;

            foreach (var entry in indexPositions)
            {
                int index = entry.Key;
                if (index < 0 || index >= childCount)
                    continue;

                Transform child = parentTransform.GetChild(index);
                if (child != null && child.name.Contains(childName))
                {
                    child.SetPositionAndRotation(
                        entry.Value.position,
                        Quaternion.Euler(entry.Value.rotation)
                    );

                    if (entry.Value.scale.HasValue)
                        child.localScale = entry.Value.scale.Value;

                    repositionedCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Repositioned {repositionedCount} {objectType}");
        }

        // Basic utility method to reposition objects (position and rotation only)
        public static void RepositionObjects(Dictionary<string, (Vector3 position, Vector3 rotation)> objects, string objectType = "objects")
        {
            if (objects == null || objects.Count == 0)
                return;

            int repositionedCount = 0;
            foreach (var obj in objects)
            {
                if (string.IsNullOrEmpty(obj.Key))
                    continue;

                GameObject gameObj = FindCached(obj.Key);
                if (gameObj != null)
                {
                    gameObj.transform.SetPositionAndRotation(
                        obj.Value.position,
                        Quaternion.Euler(obj.Value.rotation)
                    );
                    repositionedCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Repositioned {repositionedCount} {objectType}");
        }

        // Overloaded utility method to reposition objects with optional scaling
        public static void RepositionObjects(Dictionary<string, (Vector3 position, Vector3 rotation, Vector3? scale)> objects, string objectType = "objects")
        {
            if (objects == null || objects.Count == 0)
                return;

            int repositionedCount = 0;
            foreach (var obj in objects)
            {
                if (string.IsNullOrEmpty(obj.Key))
                    continue;

                GameObject gameObj = FindCached(obj.Key);
                if (gameObj != null)
                {
                    gameObj.transform.SetPositionAndRotation(
                        obj.Value.position,
                        Quaternion.Euler(obj.Value.rotation)
                    );

                    if (obj.Value.scale.HasValue)
                        gameObj.transform.localScale = obj.Value.scale.Value;

                    repositionedCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Repositioned {repositionedCount} {objectType}");
        }

        // Utility method to disable game objects by name containing a substring
        public static void DisableObjectsByNameContains(string nameContains)
        {
            if (string.IsNullOrEmpty(nameContains))
                return;

            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            int disabledCount = 0;

            foreach (GameObject obj in allObjects)
            {
                if (obj.name.Contains(nameContains))
                {
                    obj.SetActive(false);
                    disabledCount++;
                }
            }

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Disabled {disabledCount} objects containing '{nameContains}'");
        }

        // Clone management utility - matches Shortcuts mod pattern
        public static void CreateCloneIfNotExists(GameObject original, string cloneName, Vector3 position,
            Quaternion rotation, Vector3? scale = null)
        {
            if (original == null)
                return;

            // Check cache first
            if (gameObjectCache.ContainsKey(cloneName) && gameObjectCache[cloneName] != null)
                return;

            // Check scene
            if (GameObject.Find(cloneName) != null)
                return;

            GameObject clone = UnityEngine.Object.Instantiate(original, position, rotation);
            //UnityEngine.Object.DontDestroyOnLoad(clone);

            if (scale.HasValue)
                clone.transform.localScale = scale.Value;

            clone.name = cloneName;

            // Cache the clone
            gameObjectCache[cloneName] = clone;

            //if (Settings.options.Debug)
                MelonLogger.Msg($"[ObjectUtils] Created clone: {cloneName}");
        }
    }
}