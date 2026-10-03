using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace MapSizeConfigurator;

[BepInPlugin(PluginGuid, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class MapSizeConfigurator : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    internal const string PluginGuid = "com.theblackvoid.mapsizeconfigurator";
    private readonly Harmony _harmony = new(PluginGuid);
    public static ConfigEntry<float> MapSizeMultiplier;

    private void Awake()
    {
        Logger = base.Logger;
        InitConfig();
        try
        {
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
        }
    }

    private void InitConfig()
    {
        MapSizeMultiplier = Config.Bind("General", "Map Size Multiplier", 2.0f,
            new ConfigDescription("Scales the size of the map.", new AcceptableValueRange<float>(0.5f, 2.0f)));
    }
}
