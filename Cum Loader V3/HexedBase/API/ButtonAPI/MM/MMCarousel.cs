﻿using HexedBase.API;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using WorldAPI;
using Object = UnityEngine.Object;



public class MMCarousel : WorldPage {
    public int Pageint { get; private set; }
    public Image ImageComp { get; private set; }
    public Transform LogOutBtn { get; private set; }
    public Transform ExitBtn { get; private set; }
    public Transform BarContents { get; private set; }


    private static bool Preped;

    private static void PrePrepMenu() {
        Preped = true;
        APIBase.MMMCarouselPageTemplate.GetComponent<UIPage>().Method_Public_Void_Boolean_EnumNPublicSealedvaNoLeRiBoIn6vUnique_0(true, UIPage.EnumNPublicSealedvaNoLeRiBoIn6vUnique.None); // open the menu so its made
        APIBase.MMMCarouselPageTemplate.GetComponent<Canvas>().enabled = false;
        APIBase.MMMCarouselPageTemplate.GetComponent<CanvasGroup>().enabled = false;
        APIBase.MMMCarouselPageTemplate.GetComponent<GraphicRaycaster>().enabled = false;

        VRCUiManager.field_Private_Static_VRCUiManager_0?.transform.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_Settings").GetComponent<Button>().onClick.AddListener(new System.Action(() => {
            APIBase.MMMCarouselPageTemplate.GetComponent<Canvas>().enabled = true;
            APIBase.MMMCarouselPageTemplate.GetComponent<CanvasGroup>().enabled = true;
            APIBase.MMMCarouselPageTemplate.GetComponent<GraphicRaycaster>().enabled = true;
        }));
    }

    public MMCarousel(string menuName, string HeaderText, Sprite Icon = null) {
        if (!APIBase.IsReady())
            throw new NullReferenceException("Object Search had FAILED!");

        if (!Preped) PrePrepMenu();
        var region = 0; 

        try
        {
            transform = (gameObject = Object.Instantiate(APIBase.MMMCarouselPageTemplate, APIBase.MMMCarouselPageTemplate.transform.parent)).transform;
            gameObject.name = menuName;
            MenuName = menuName;
            Page = gameObject.GetComponent<UIPage>();
            var GuidName = menuName + Guid.NewGuid();

            Page.field_Public_String_0 = GuidName;
            (Page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>()).Add(Page);

            region++;
            QMUtils.GetMainMenuStateControllerInstance.field_Private_Dictionary_2_String_UIPage_0.Add(GuidName, Page);
            var list = QMUtils.GetMainMenuStateControllerInstance.field_Public_Il2CppReferenceArray_1_UIPage_0.ToList();
            list.Add(Page);
            QMUtils.GetMainMenuStateControllerInstance.field_Public_Il2CppReferenceArray_1_UIPage_0 = list.ToArray();
            Pageint = QMUtils.GetMainMenuStateControllerInstance.field_Public_Il2CppReferenceArray_1_UIPage_0.Count;
            region++;

            Page.GetComponent<Canvas>().enabled = true;
            Page.GetComponent<CanvasGroup>().enabled = true;
            Page.GetComponent<UIPage>().enabled = true;
            Page.GetComponent<GraphicRaycaster>().enabled = true;
            var scrolNav = gameObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation");
            scrolNav.GetComponent<VRC.UI.Elements.Controls.ScrollRectEx>().field_Public_Boolean_0 = true;
            scrolNav.transform.Find("Viewport/VerticalLayoutGroup").GetComponent<Canvas>().enabled = true;
            scrolNav.transform.Find("Viewport/VerticalLayoutGroup").GetComponent<GraphicRaycaster>().enabled = true;
            scrolNav.transform.Find("ScrollRect_Content").GetComponent<VRC.UI.Elements.Controls.ScrollRectEx>().field_Public_Boolean_0 = true;
            scrolNav.transform.Find("ScrollRect_Content/Header_MM_H2/RightItemContainer/Field_MM_TextSearchField").gameObject.active = false;
            //scrolNav.transform.Find("ScrollRect_Content/Viewport").GetComponent<RectMask2DEx>().field_Public_Boolean_0 = true; // Fixes the items falling off of the Menu
            //scrolNav.transform.Find("Viewport").GetComponent<RectMask2DEx>().field_Public_Boolean_0 = true; // Fixes the items falling off of the Menu

            region++;
            ImageComp = scrolNav.transform.Find("Viewport/VerticalLayoutGroup/DynamicSidePanel_Header/Icon").GetComponent<Image>();
            ImageComp.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f); //  
            ImageComp.transform.localPosition = new Vector3(88.5f, -50, 0);

            if (Icon != null) {
                ImageComp.sprite = Icon;
                ImageComp.overrideSprite = Icon;
            } else ImageComp.gameObject.SetActive(false);
            region++;


            var textt = scrolNav.transform.Find("Viewport/VerticalLayoutGroup/DynamicSidePanel_Header/Text_Name").GetComponent<TextMeshProUGUI>();
            textt.text = HeaderText;
            textt.overflowMode = TextOverflowModes.Overflow;
            textt.autoSizeTextContainer = true;
            textt.enableAutoSizing = true;
            textt.richText = true;
            
            region++;
            (MenuContents = scrolNav.transform.Find("ScrollRect_Content/Viewport/VerticalLayoutGroup")).DestroyChildren();
            (BarContents = scrolNav.transform.Find("Viewport/VerticalLayoutGroup")).DestroyChildren(a => a.name != "DynamicSidePanel_Header");
            region++;

            LogOutBtn = scrolNav.transform.Find("Viewport/VerticalLayoutGroup/DynamicSidePanel_Header/Button_Logout");
            ExitBtn = scrolNav.transform.Find("Viewport/VerticalLayoutGroup/DynamicSidePanel_Header/Button_Exit");
            LogOutBtn.gameObject.active = false;
            ExitBtn.gameObject.active = false;

            gameObject.SetActive(false); // Set it off, as we had to enable the page comps, that shows the page, and it will be overlapping - but the controller fixes it when u select and deselect the menu
        }
        catch (Exception ex) {
            throw new Exception("Exception Caught When Making Page At Region: " + region + "\n\n" + ex);
        }
    }

    public void SetExtraButtons(string text1, Action listener1, string toolTip1, string text2, Action listener2, // Honestly this is pretty bad and i got lazy 7-7
        string toolTip2, Sprite sprite1 = null, Sprite sprite2 = null) 
    {
        sprite1 = sprite1 != null ? sprite1 : APIBase.DefaultButtonSprite;
        sprite2 = sprite2 != null ? sprite2 : APIBase.DefaultButtonSprite;

        ((LogOutBtn.GetComponent<Button>()).onClick = new Button.ButtonClickedEvent()).AddListener(listener1);
        LogOutBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>()._localizableString = toolTip1.ReturnLocalizableString();
        LogOutBtn.gameObject.active = true;
        Apply(LogOutBtn, text1, sprite1);

        ((ExitBtn.GetComponent<Button>()).onClick = new Button.ButtonClickedEvent()).AddListener(listener2);
        ExitBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>()._localizableString = toolTip2.ReturnLocalizableString();
        ExitBtn.gameObject.active = true;
        Apply(ExitBtn, text2, sprite2);


        void Apply(Transform btn, string text, Sprite icom) {
            foreach (var obj in btn.GetComponentsInChildren<TextMeshProUGUIEx>()) {
                obj.prop_String_0 = text;
                obj.richText = true;
            }
            foreach (var obj in btn.GetComponentsInChildren<Image>()) {
                if (obj.name != "Icon") continue;
                obj.sprite = icom;
            }
        }
    }

    public void OpenMenu() {
        gameObject.SetActive(true);
        QMUtils.GetMainMenuStateControllerInstance.Method_Public_Void_String_ObjectPublicStBoAc1ObObUnique_Boolean_EnumNPublicSealedvaNoLeRiBoIn6vUnique_0(Page.field_Public_String_0, null, true, UIPage.EnumNPublicSealedvaNoLeRiBoIn6vUnique.Right);
        OnMenuOpen?.Invoke();
    }
}