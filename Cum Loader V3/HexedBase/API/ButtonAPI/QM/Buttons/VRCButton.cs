using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using WorldAPI;
using Object = UnityEngine.Object;



public class VRCButton : ExtentedControl {
    public VRCButton(Transform menu, string text, string tooltip, Action<VRCButton> listener, bool Half = false,
        bool SubMenuIcon = false, Sprite Icon = null, HalfType Type = HalfType.Normal, bool IsGroup = false) 
    {
        if (!APIBase.IsReady())
            throw new NullReferenceException("Object Search had FAILED!");
        Icon = Icon != null ? Icon : APIBase.DefaultButtonSprite;

        (transform = Object.Instantiate(APIBase.Button, menu)).name = $"Button_{text}";
        gameObject = transform.gameObject;
        gameObject.SetActive(true);

        TMProCompnt = transform.GetComponentInChildren<TextMeshProUGUI>();
        TMProCompnt.text = text;
        TMProCompnt.richText = true;
        Text = text;

        ButtonCompnt = transform.GetComponent<Button>();
        ButtonCompnt.onClick = new Button.ButtonClickedEvent();
        if (listener != null) SetAction(listener);
        else ButtonCompnt.interactable = false;


        ImgCompnt = transform.transform.Find("Icon").GetComponent<Image>();
        var elemetn = ImgCompnt.gameObject.GetComponent<StyleElement>();
        if (elemetn != null) elemetn.enabled = false; // Fix the Images from going back to the default

        Object.Destroy(transform.transform.Find("Icon_Secondary").gameObject);
        if (Icon != null) 
            SetSprite(Icon);
        else {
            transform.transform.Find("Icon").gameObject.active = false;
            ResetTextPox();
        }

        ShowSubMenuIcon(SubMenuIcon);
        this.SetToolTip(tooltip);
        if (Half) TurnHalf(Type, IsGroup);

        inst = this;
    }

    public VRCButton(Transform menu, string text, string tooltip, Action click, bool Half = false, bool subMenuIcon = false, Sprite icon = null, HalfType Type = HalfType.Normal, bool IsGroup = false)
        : this(menu, text, tooltip, (_) => click(), Half, subMenuIcon, icon, Type, IsGroup) { }

    public VRCButton(ButtonGroupControl buttonGroup, string text, string tooltip, Action click, bool Half = false, bool subMenuIcon = false, Sprite icon = null, HalfType Type = HalfType.Normal, bool IsGroup = false)
        : this(buttonGroup, text, tooltip, (_) => click(), Half, subMenuIcon, icon, Type, IsGroup) { }

    public VRCButton(ButtonGroupControl buttonGroup, string text, string tooltip, Action<VRCButton> click, bool Half = false, bool subMenuIcon = false, Sprite icon = null, HalfType Type = HalfType.Normal, bool IsGroup = false)
        : this(buttonGroup.GroupContents.transform, text, tooltip, click, Half, subMenuIcon, icon, Type, IsGroup) => buttonGroup._buttons.Add(this);
}
