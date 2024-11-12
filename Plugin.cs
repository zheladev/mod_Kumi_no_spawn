using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Mod_Kumi_no_spawn;

[BepInPlugin("yom.mods.kuminospawn", "Kumi no Spawn", "1.0.0")]
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
        if (ele == 665)
        {
            __result = 0;
             return false;
        }
        __result = ele;
        return true;
    }
}