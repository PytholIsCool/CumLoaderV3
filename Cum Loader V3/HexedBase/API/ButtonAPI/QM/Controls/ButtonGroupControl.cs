using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class ButtonGroupControl : Root {
    internal List<VRCButton> _buttons = new List<VRCButton>();
    internal List<VRCToggle> _toggles = new List<VRCToggle>();

    public GameObject headerGameObject { get; internal set; }
    public GameObject GroupContents { get; internal set; }
    public RectMask2D parentMenuMask { get; internal set; }
    public bool WasNoText { get; internal set; }
    public List<VRCButton> Buttons => _buttons.Where(x => x.gameObject != null).ToList();
    public List<VRCToggle> Toggles => _toggles.Where(x => x.gameObject != null).ToList();

    /// <summary>
    ///  Remove Buttons, Toggles, anything that was put on this ButtnGrp
    /// </summary>
    public void RemoveAllChildren() {
        GroupContents.transform.DestroyChildren();
        _buttons.Clear();
        _toggles.Clear();
    }


    public VRCButton AddButton(string text, string tooltip, Action listener, bool Half = false, bool SubMenuIcon = false, Sprite Icon = null) =>
        new VRCButton(gameObject.transform, text, tooltip, listener, Half, SubMenuIcon, Icon);

    public VRCToggle AddToggle(string Ontext, Action<bool> listener, bool DefaultState = false, string OffTooltip = null, string OnToolTip = null,
        Sprite onSprite = null, Sprite offSprite = null, bool Half = false) =>
        new VRCToggle(gameObject.transform, Ontext, listener, DefaultState, OffTooltip, OnToolTip, onSprite, offSprite, Half);

    public VRCLable AddLable(string text, string LowerText, Action onClick = null, bool Bg = true) =>
        new VRCLable(gameObject.transform, text, LowerText, onClick, Bg);

    public GrpButtons AddGrpOfButtons(string FirstName, string FirstTooltip, Action action,
                                        string SecondName = null, string SecondTooltip = null, Action Secondaction = null,
                                        string thirdName = null, string thirdTooltip = null, Action thirdaction = null) =>
            new GrpButtons(gameObject, FirstName, FirstTooltip, action,
                SecondName, SecondTooltip, Secondaction,
                thirdName, thirdTooltip, thirdaction);

    public DuoToggles AddGrpToggles(string text, string Ontooltip, string OffTooltip, Action<bool> BoolStateChange,
        string text2, string Ontooltip2, string OffTooltip2, Action<bool> BoolStateChange2,
        Sprite OnImageSprite = null, Sprite OffImageSprite = null,
        float FirstFontSize = 24f, float SecondFontSize = 24f, bool FirstState = false, bool SecondState = false) =>
        new DuoToggles(gameObject, text, Ontooltip, OffTooltip, BoolStateChange,
            text2, Ontooltip2, OffTooltip2, BoolStateChange2,
            OnImageSprite, OffImageSprite, FirstFontSize, SecondFontSize, FirstState, SecondState);

    public DuoButtons AddDuoButtons(string buttonOne, string buttonOneTooltip, Action btnAction, string buttonTwo, string buttonTwoTooltip, Action buttonTwoAction) =>
        new DuoButtons(gameObject, buttonOne, buttonOneTooltip, (_) => btnAction(),
            buttonTwo, buttonTwoTooltip, (_) => buttonTwoAction());

}
