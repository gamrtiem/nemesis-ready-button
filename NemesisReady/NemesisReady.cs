using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.UI;
using CharacterSelectController = On.RoR2.UI.CharacterSelectController;
using RiskOfOptions;
using RiskOfOptions.Options;

namespace NemesisReady
{
    [BepInDependency("com.rune580.riskofoptions")]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    
    public class NemesisReady : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "icebro";
        public const string PluginName = "nemesisready";
        public const string PluginVersion = "1.0.0";
        
        public void Awake()
        {
            Log.Init(Logger);
            
            ConfigEntry<Color> buttonColor = Config.Bind("color",
                "ready button color",
                Color.red,
                "nemesis ready button color ,,..,,.,"); 

            ModSettingsManager.AddOption(new ColorOption(buttonColor));
            
            CharacterSelectController.Awake += (orig, self) =>
            {
                orig(self);
                var readyButton = GameObject.Find("ReadyButton");
                if (readyButton) // i heart nullchecks !!
                {
                    readyButton.GetComponent<Image>().color = new Color32((byte)(buttonColor.Value.r * 255), (byte)(buttonColor.Value.g * 255), (byte)(buttonColor.Value.b * 255), (byte)(buttonColor.Value.a * 255));
                }
                else
                {
                    Log.Error("umm .,,. where is the ready button ,.,.,.,.,");
                }
            };
        }
        
    }
}
