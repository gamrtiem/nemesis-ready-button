using BepInEx;
using IL.RoR2.UI;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using RoR2.UI;
using UnityEngine.UI;
using CharacterSelectController = On.RoR2.UI.CharacterSelectController;

namespace NemesisReady
{
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class NemesisReady : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "icebro";
        public const string PluginName = "nemesisready";
        public const string PluginVersion = "1.0.0";
        
        //private HUD hud = null;

        public void Awake()
        {
            Log.Init(Logger);

            On.RoR2.UI.CharacterSelectController.Awake += nemesisReadyAwake;
            //On.RoR2.UI.HUD.Update+= hudupdate;
            //On.RoR2.UI.HUD.Awake+= hudawawke;
        }

        private void nemesisReadyAwake(CharacterSelectController.orig_Awake orig, RoR2.UI.CharacterSelectController self)
        {
            orig(self);
            var readyButton = GameObject.Find("ReadyButton");
            if (readyButton) // i heart nullchecks !!
            {
                Log.Info("found !!");
                readyButton.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
            else
            {
                Log.Error("umm .,,. where is the ready button ,.,.,.,.,");
            }
        }
        
        /*private void hudawawke(On.RoR2.UI.HUD.orig_Awake orig, HUD self)
        {
            orig(self); // Don't forget to call this, or the vanilla / other mods' codes will not execute!
            hud = self;
            GameObject myObject = new GameObject("GameObjectName");
            myObject.transform.SetParent(hud.mainContainer.transform);
            RectTransform rectTransform = myObject.AddComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
            
            myObject.AddComponent<Image>();
            myObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("textures/itemicons/texBearIcon");
            // Utilize the ResourcesAPI from R2API to load your image!

            
        }



        private void hudupdate(On.RoR2.UI.HUD.orig_Update orig, RoR2.UI.HUD self)
        {
            orig(self);

        }
        // The Update() method is run on every frame of the game.
        private void Update()
        {
            var findthatready = GameObject.Find("ReadyButton");
            if (findthatready)
            {
                Log.Info("found !!");
                findthatready.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
        }*/
    }
}
