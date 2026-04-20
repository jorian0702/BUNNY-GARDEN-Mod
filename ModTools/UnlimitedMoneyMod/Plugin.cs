using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace UnlimitedMoneyMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            Logger.LogInfo($"[UnlimitedMoneyMod] Loading...");

            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Logger.LogInfo($"[UnlimitedMoneyMod] All patches applied successfully!");
        }
    }

    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "com.jorian.unlimitedmoney";
        public const string PLUGIN_NAME = "Unlimited Money Mod";
        public const string PLUGIN_VERSION = "1.0.0";
    }
}
