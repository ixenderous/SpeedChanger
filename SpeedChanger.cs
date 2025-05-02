using MelonLoader;
using BTD_Mod_Helper;
using SpeedChanger;
using BTD_Mod_Helper.Api.Helpers;
using System;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

[assembly: MelonInfo(typeof(SpeedChanger.SpeedChanger), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SpeedChanger;

public class SpeedChanger : BloonsTD6Mod
{
    private int _speedPower = 0;
    private const int MaxSpeedPower = 7;
    private const int MinSpeedPower = -7;
    private const int MinSpeedPowerNonSandbox = 0;

    private int SpeedPower
    {
        get => _speedPower;
        set
        {
            bool isSandbox = InGame.instance != null && InGameData.CurrentGame != null && InGameData.CurrentGame.IsSandbox;
            int minPower = isSandbox ? MinSpeedPower : MinSpeedPowerNonSandbox;

            int clampedValue = Math.Clamp(value, minPower, MaxSpeedPower);
            if (_speedPower != clampedValue)
            {
                _speedPower = clampedValue;
                double speed = Math.Pow(2, _speedPower);
                TimeHelper.OverrideFastForwardTimeScale = speed;
                if (Settings.LogSpeed)
                {
                    MelonLogger.Msg($"Speed set to {speed}x");
                }
            }
        }
    }

    public override void OnApplicationStart()
    {
        ModHelper.Msg<SpeedChanger>("SpeedChanger loaded!");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (InGame.instance == null || PopupScreen.instance == null || PopupScreen.instance.IsPopupActive()) return;

        int newSpeedPower = _speedPower;
        if (Settings.Slow.JustPressed()) newSpeedPower--;
        if (Settings.Fast.JustPressed()) newSpeedPower++;
        if (Settings.Reset.JustPressed()) newSpeedPower = 0;

        SpeedPower = newSpeedPower;
    }
}