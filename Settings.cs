using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

namespace SpeedChanger
{
    public class Settings : ModSettings
    {
        public static readonly ModSettingBool LogSpeed = new(true)
        {
            description = "Disable this to stop the 'Speed set to x' messages"
        };

        public static readonly ModSettingBool SlowmoOutsideSandbox = new(false)
        {
            displayName = "Slowmo Outside of Sandbox",
            description = "When enabled, speed can be set to below 1x outside of sandbox mode"
        };
        
        public static readonly ModSettingHotkey Slow = new(UnityEngine.KeyCode.LeftBracket);
        public static readonly ModSettingHotkey Fast = new(UnityEngine.KeyCode.RightBracket);
        public static readonly ModSettingHotkey Reset = new(UnityEngine.KeyCode.Backslash);
    }
}