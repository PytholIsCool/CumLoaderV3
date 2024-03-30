using HexedBase.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using VRC.DataModel;
using VRC.Localization;
using VRC.UI.Elements.Controls;

namespace Starborn.API
{
    internal class StarbornPopups
    {
        private static VRCInputField inputfield;
        private static GameObject Object;
        public enum KeyBoardType{Standard,Numeric,Search}
        public static void InputPopup(string Title, Action<string> EndString, Action<string> RealTimeString = null, Action OnClose = null, KeyBoardType keyBoardType = KeyBoardType.Standard, string Placeholder = "Enter Text", string OkButton = "OK", string CancelButton = "Cancel", bool MultiLine = true, int CharLimit = 0, bool KeepOpen = false, bool ReadOnly = false)
        {
            if (inputfield == null)
            {
                Object = new GameObject("Starbron.Core_KeyBoard");
                UnityEngine.Object.DontDestroyOnLoad(Object);
                inputfield = Object.AddComponent<VRCInputField>();
            }
            try
            {
                KeyboardData keyboardData = new KeyboardData();
                KeyboardData keyboardData2 = keyboardData.Method_Public_KeyboardData_LocalizableString_LocalizableString_String_LocalizableString_LocalizableString_0(Title.ReturnLocalizableString(), Placeholder.ReturnLocalizableString(), "", OkButton.ReturnLocalizableString(), CancelButton.ReturnLocalizableString());
                KeyboardData keyboardData3 = keyboardData2.Method_Public_KeyboardData_Action_1_String_Action_1_String_Action_Boolean_PDM_0(RealTimeString, EndString, OnClose, KeepOpen);
                KeyboardData keyboardData4 = keyboardData3.Method_Public_KeyboardData_EnumPublicSealedvaStNuSe4vUnique_Boolean_PDM_0((EnumPublicSealedvaStNuSe4vUnique)keyBoardType, param_2: true);
                KeyboardData keyboardData5 = keyboardData4.Method_Public_KeyboardData_InputType_ContentType_Int32_Boolean_Boolean_InterfacePublicAbstractBoStVoAc1VoAcSt1BoUnique_PDM_0(TMP_InputField.InputType.Standard, TMP_InputField.ContentType.Standard, CharLimit, MultiLine, ReadOnly);
                keyboardData5._isWorldKeyboard = true;
                inputfield._keyboardData = keyboardData5;
                inputfield.Method_Private_Void_0();
            }
            catch
            {
            }
        }

        private static UserEventCarouselManager _activeCarousel;
        private static UserEventCarouselManager activeCarousel
        {
            get
            {
                if (_activeCarousel == null) _activeCarousel = Resources.FindObjectsOfTypeAll<UserEventCarouselManager>()?[0];
                return _activeCarousel;
            }
        }

        public static void HudMessage(string Text, Sprite icon = null)
        {
            if (activeCarousel == null) return;
            activeCarousel.Method_Private_Void_LocalizableString_Sprite_0(Text.ReturnLocalizableString(), icon);
        }

        public static void HudToast(string content, string description = null, Sprite icon = null, float duration = 5f)
        {
            VRCUiManager.field_Private_Static_VRCUiManager_0.field_Private_MonoBehaviourPublicObnoObmousCaObhuGaCaUnique_0.notification.Method_Public_Void_Sprite_LocalizableString_LocalizableString_Single_Object1PublicTYBoTYUnique_1_Boolean_0(icon, content.ReturnLocalizableString(), description.ReturnLocalizableString(), duration);
        }

    }
}
