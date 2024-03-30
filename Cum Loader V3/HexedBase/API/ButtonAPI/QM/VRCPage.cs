using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Menus;
using WorldAPI;
using Object = UnityEngine.Object;


public class VRCPage : WorldPage {
    public bool IsRoot { get; set; } // This should be fine to edit

    public static VRCPage lastOpenedPage { get; private set; }

    public TextMeshProUGUI pageTitleText;
    public RectMask2D menuMask;

    private GameObject extButtonGameObject;

    public VRCPage(string pageTitle, bool root = false, bool backButton = true, bool expandButton = false, Action expandButtonAction = null, string expandButtonTooltip = "", Sprite expandButtonSprite = null, bool preserveColor = false, bool fix = true)
    {
        if (!APIBase.IsReady()) throw new Exception();
        if (APIBase.MenuPage == null) {
            Logs.Error("Fatal Error: ButtonAPI.menuPageBase Is Null!");
            return;
        }

        var region = 0; 
        MenuName = "WorldMenu_" + pageTitle + Guid.NewGuid();
        IsRoot = root;

        try {
            var gameObject = Object.Instantiate(APIBase.MenuPage, APIBase.MenuPage.transform.parent);
            gameObject.name = MenuName;
            gameObject.transform.SetSiblingIndex(5);
            gameObject.gameObject.active = false;

            region++;
            Object.DestroyImmediate(gameObject.GetOrAddComponent<LaunchPadQMMenu>());
            Page = gameObject.gameObject.AddComponent<UIPage>();
            region++;

            Page.field_Public_String_0 = MenuName;
            Page.field_Private_Boolean_1 = true;
            Page.field_Protected_MenuStateController_0 = QMUtils.GetMenuStateControllerInstance;
            Page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page.field_Private_List_1_UIPage_0.Add(Page);

            region++;
            QMUtils.GetMenuStateControllerInstance.field_Private_Dictionary_2_String_UIPage_0.Add(MenuName, Page);
            if (root) {
                var list = QMUtils.GetMenuStateControllerInstance.field_Public_Il2CppReferenceArray_1_UIPage_0.ToList();
                list.Add(Page);
                QMUtils.GetMenuStateControllerInstance.field_Public_Il2CppReferenceArray_1_UIPage_0 = list.ToArray();
            }
            region++;

            MenuContents = gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            MenuContents.GetComponent<VerticalLayoutGroup>().childControlHeight = true;
            MenuContents.DestroyChildren();

            region++;
            pageTitleText = gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
            pageTitleText.fontSize = 54.7f;
            pageTitleText.text = pageTitle;
            pageTitleText.richText = true;
            region++;

            var backButtonGameObject = gameObject.transform.GetChild(0).Find("LeftItemContainer/Button_Back").gameObject;
            backButtonGameObject.SetActive(backButton);
            (backButtonGameObject.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent()).AddListener(new Action(() => {
                if (IsRoot) QMUtils.GetMenuStateControllerInstance.Method_Public_Void_String_ObjectPublicStBoAc1ObObUnique_Boolean_EnumNPublicSealedvaNoLeRiBoIn6vUnique_0("QuickMenuDashboard", null, false, UIPage.EnumNPublicSealedvaNoLeRiBoIn6vUnique.Right);
                else Page.Method_Protected_Virtual_New_Void_0();
            }));

            region++;
            extButtonGameObject = gameObject.transform.GetChild(0).Find("RightItemContainer/Button_QM_Expand").gameObject;
            extButtonGameObject.SetActive(expandButton);
            extButtonGameObject.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            if (expandButtonAction != null)
                extButtonGameObject.GetComponentInChildren<Button>().onClick.AddListener(expandButtonAction);
            
            if (expandButtonSprite != null) {
                extButtonGameObject.GetComponentInChildren<Image>().sprite = expandButtonSprite;
                extButtonGameObject.GetComponentInChildren<Image>().overrideSprite = expandButtonSprite;
                if (preserveColor) {
                    extButtonGameObject.GetComponentInChildren<Image>().color = Color.white;
                    extButtonGameObject.GetComponentInChildren<StyleElement>(true).enabled = false;
                }
            }
            region++;

            menuMask = MenuContents.parent.gameObject.GetOrAddComponent<RectMask2D>();
            menuMask.enabled = true;
            gameObject.transform.Find("ScrollRect").GetOrAddComponent<ScrollRect>().enabled = true;
            gameObject.transform.Find("ScrollRect").GetOrAddComponent<ScrollRect>().verticalScrollbar = gameObject.transform.Find("ScrollRect/Scrollbar").GetOrAddComponent<Scrollbar>();
            gameObject.transform.Find("ScrollRect").GetOrAddComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
            gameObject.DestroyChildren(where => where.name != "ScrollRect" && where.name != "Header_H1");
            region++;

            gameObject.transform.Find("ScrollRect/Viewport").GetComponent<RectMask2DEx>().prop_Boolean_0 = true; // Fixes the items falling off of the QM
            gameObject.transform.Find("ScrollRect").GetComponent<VRC.UI.Elements.Controls.ScrollRectEx>().field_Public_Boolean_0 = true; // Fixes the items falling off of the QM

            region++;
            Page.GetComponent<Canvas>().enabled = true; // Fix for Late Menu Creation
            Page.GetComponent<CanvasGroup>().enabled = true; // Fix for Late Menu Creation
            Page.GetComponent<UIPage>().enabled = true; // Fix for Late Menu Creation
            Page.GetComponent<GraphicRaycaster>().enabled = true; // Fix for Late Menu Creation
        }
        catch (Exception ex) {
            throw new Exception("Exception Caught When Making Page At Region: " + region + "\n\n" + ex);
        }
    }

    public void AddExtButton(Action onClick, string tooltip, Sprite icon)
    {
        var obj = Object.Instantiate(extButtonGameObject, extButtonGameObject.transform.parent);
        obj.SetActive(true);
        obj.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
        obj.GetComponentInChildren<Button>().onClick.AddListener(onClick);
        obj.GetComponentInChildren<Image>().sprite = icon;
        obj.GetComponentInChildren<Image>().overrideSprite = icon;
    }


    public void OpenMenu()
    {
        Page.gameObject.active = true;
        QMUtils.GetMenuStateControllerInstance.Method_Public_Void_String_ObjectPublicStBoAc1ObObUnique_Boolean_EnumNPublicSealedvaNoLeRiBoIn6vUnique_0(Page.field_Public_String_0, null, false, UIPage.EnumNPublicSealedvaNoLeRiBoIn6vUnique.Right);
        OnMenuOpen?.Invoke();
        lastOpenedPage = this;
    }


    public void SetTitle(string text) => pageTitleText.text = text;
    public void CloseMenu() => Page.Method_Public_Virtual_New_Void_0();

}
