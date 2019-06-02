using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentPatcher;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace JACPBridge
{
    public class Mod : StardewModdingAPI.Mod
    {
        private IJsonAssetsApi ja;
        private IContentPatcherAPI cp;

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            var jaMod = Helper.ModRegistry.Get("spacechase0.JsonAssets").Manifest;

            ja = Helper.ModRegistry.GetApi<IJsonAssetsApi>("spacechase0.JsonAssets");
            cp = Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            cp.RegisterToken(jaMod, "ObjectId", this.Token_ObjectId);
            cp.RegisterToken(jaMod, "BigCraftableId", this.Token_BigCraftableId);
            cp.RegisterToken(jaMod, "CropId", this.Token_CropId);
            cp.RegisterToken(jaMod, "FruitTreeId", this.Token_FruitTreeId);
            cp.RegisterToken(jaMod, "HatId", this.Token_HatId);
            cp.RegisterToken(jaMod, "WeaponId", this.Token_WeaponId);
        }

        private string[] Token_ObjectId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllObjectIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetObjectId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }

        private string[] Token_BigCraftableId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllBigCraftableIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetBigCraftableId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }

        private string[] Token_CropId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllCropIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetCropId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }

        private string[] Token_FruitTreeId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllFruitTreeIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetFruitTreeId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }

        private string[] Token_HatId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllHatIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetHatId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }

        private string[] Token_WeaponId(ITokenString input)
        {
            if (input == null)
                return ja.GetAllWeaponIds().Values.Select((i) => i.ToString()).ToArray<string>();

            var str = input.Value;
            int id = ja.GetWeaponId(str);
            if (id == -1)
                return new string[] { };
            return new[] { id.ToString() };
        }
    }
}
