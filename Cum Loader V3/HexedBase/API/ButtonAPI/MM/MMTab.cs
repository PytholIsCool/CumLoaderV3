using HexedBase.API;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;
using WorldAPI;
using Object = UnityEngine.Object;




public class MMTab : Root {
    public static Action OnClick { get; set; }

    public Image Image { get; private set; }
    public VRC.UI.Elements.Tooltips.UiTooltip ToolTip { get; private set; }
    public Button1PublicObUnique MenuTab { get; private set; }

    private void Make(int NUM, string toolTip, Sprite sprite) {
        if (!APIBase.IsReady())
            throw new NullReferenceException("Object Search had FAILED!");

        gameObject = Object.Instantiate(APIBase.MMMTabTemplate, APIBase.MMMTabTemplate.transform.parent);
        if (sprite != null) (Image = gameObject.transform.Find("Icon").GetComponent<Image>()).sprite = sprite;
        else gameObject.transform.Find("Icon").gameObject.active = false;

        gameObject.GetComponent<StyleElement>().field_Private_Selectable_0 = gameObject.GetComponent<Button>();
        gameObject.GetComponent<Button>().onClick.AddListener(new Action(() => gameObject.SetActive(true)));

        (ToolTip = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>())._localizableString = toolTip.ReturnLocalizableString();
        (MenuTab = gameObject.GetComponent<Button1PublicObUnique>()).m_CurrentIndex = NUM - 1;
    }

    public MMTab(MMPage page, string toolTip = "", Sprite sprite = null) => Make(page.Pageint, toolTip, sprite);
    public MMTab(MMCarousel page, string toolTip = "", Sprite sprite = null) => Make(page.Pageint, toolTip, sprite);
}
