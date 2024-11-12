using System;
using BepInEx;
using HarmonyLib;

namespace Mod_Kumi_no_spawn;

[BepInPlugin("yom.mods.kuminospawn", "Kumi no Spawn", "0.0.1")]
public class KumiNoSpawn : BaseUnityPlugin
{
  private void Start()
    {
        Logger.LogInfo("Kumi no Spawn loaded");
        var harmony = new Harmony("yom.mods.kuminospawn");
        harmony.PatchAll();
        Logger.LogInfo("Kumi no Spawn loaded");
    }
}

[HarmonyPatch(typeof(Card), nameof(Card.Evalue), typeof(int))]
public class CharaEnemyPatch
{
  static bool Prefix(ref int __result, int ele)
    {
        Msg.SayRaw("Evalue: " + ele);
        if (ele == 665)
        {
             return false;
        }
        return true;
    }
}