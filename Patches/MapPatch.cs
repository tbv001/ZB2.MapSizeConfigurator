using HarmonyLib;
using UnityEngine;

namespace MapSizeConfigurator.Patches;

[HarmonyPatch(typeof(Map))]
internal static class MapPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Map.StartMapGeneration))]
    private static void ConfigureMapSize(Map __instance)
    {
        __instance.defMapSize.x = Mathf.RoundToInt(__instance.defMapSize.x * MapSizeConfigurator.MapSizeMultiplier.Value);
        __instance.defMapSize.y = Mathf.RoundToInt(__instance.defMapSize.y * MapSizeConfigurator.MapSizeMultiplier.Value);
    }
}
