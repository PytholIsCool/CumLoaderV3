using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;
using WorldAPI;


public class Tab : ExtentedControl {
    public Image tabIcon { get; private set; }
    public GameObject badgeGameObject { get; private set; }
    public TextMeshProUGUI badgeText { get; private set; }

    public VRCPage Menu { get; private set; }
    public Button1PublicObUnique menuTab { get; private set; }

    public Tab(VRCPage menu, string tooltip, Sprite icon = null, Transform parent = null, bool openMenu = true)
    {
        if (!APIBase.IsReady()) throw new Exception();

        if (parent == null)
            parent = APIBase.Tab.parent;
        Menu = menu;

        gameObject = UnityEngine.Object.Instantiate(APIBase.Tab.gameObject, parent);
        gameObject.name = menu.MenuName + "_Tab";
        gameObject.active = true;
        menuTab = gameObject.GetOrAddComponent<Button1PublicObUnique>();
        menuTab.field_Private_MenuStateController_0 = QMUtils.GetMenuStateControllerInstance;
        menuTab._controlName = menu.MenuName;
        tabIcon = gameObject.transform.Find("Icon").GetOrAddComponent<Image>();
        tabIcon.sprite = icon;
        tabIcon.overrideSprite = icon;
        badgeGameObject = gameObject.transform.GetChild(0).gameObject;
        badgeText = badgeGameObject.GetComponentInChildren<TextMeshProUGUI>();
        menuTab.gameObject.GetOrAddComponent<StyleElement>().field_Private_Selectable_0 = menuTab.gameObject.GetOrAddComponent<Button>();


        SetToolTip(tooltip);
        menuTab.gameObject.GetOrAddComponent<Button>().onClick.AddListener((Action)delegate {
            menuTab.gameObject.GetOrAddComponent<StyleElement>().field_Private_Selectable_0 = menuTab.gameObject.GetOrAddComponent<Button>();
            if (openMenu) Menu?.OpenMenu();
            onClickAction?.Invoke();
        });
    }

}
