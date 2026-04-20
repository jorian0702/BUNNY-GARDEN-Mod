using HarmonyLib;
using GB.Game;

namespace UnlimitedMoneyMod
{
    [HarmonyPatch(typeof(GameData), "SpendMoney")]
    public static class SpendMoneyPatch
    {
        /// <summary>
        /// Intercepts SpendMoney and replaces it with AddMoney instead.
        /// When the game tries to take money, we give money instead.
        /// </summary>
        static bool Prefix(GameData __instance, int x, bool immediate)
        {
            __instance.AddMoney(x, immediate);
            Plugin.Log.LogInfo($"[UnlimitedMoney] SpendMoney intercepted: +{x} (was -{x})");
            return false;
        }
    }

    [HarmonyPatch(typeof(GameData), "GetMoney")]
    public static class GetMoneyPatch
    {
        /// <summary>
        /// After GetMoney returns, if value is low, force-set to a high amount.
        /// This ensures money checks always pass.
        /// </summary>
        static void Postfix(GameData __instance, ref int __result)
        {
            if (__result < 9999999)
            {
                var field = AccessTools.Field(typeof(GameData), "m_money");
                field.SetValue(__instance, 9999999);
                __result = 9999999;
            }
        }
    }

    [HarmonyPatch(typeof(GameData), "Initialize")]
    public static class InitializePatch
    {
        /// <summary>
        /// After game initialization, set starting money to max.
        /// </summary>
        static void Postfix(GameData __instance)
        {
            var moneyField = AccessTools.Field(typeof(GameData), "m_money");
            moneyField.SetValue(__instance, 9999999);

            var moneyUIField = AccessTools.Field(typeof(GameData), "m_moneyForUI");
            var reactiveProperty = moneyUIField.GetValue(__instance);
            if (reactiveProperty != null)
            {
                var valueProp = AccessTools.Property(reactiveProperty.GetType(), "Value");
                valueProp.SetValue(reactiveProperty, 9999999);
            }

            Plugin.Log.LogInfo("[UnlimitedMoney] Starting money set to 9,999,999!");
        }
    }
}
