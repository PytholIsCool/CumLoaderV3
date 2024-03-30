using HexedBase.API;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Element;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Tooltips;
using WorldAPI;

using Object = UnityEngine.Object;



public class CToggle : Root {
    public Action<bool> Listener { get; set; }

    public Toggle ToggleCompnt { get; private set; }
    public UiToggleTooltip ToolTip { get; private set; }
    public Transform Handle { get; private set; }

    private ToggleSwitch toggleSwitch;
    private bool shouldInvoke = true;

    private static Vector3 onPos = new Vector3(93, 0, 0), offPos = new Vector3(30, 0, 0);

    public CToggle(CGrp grp, string text, Action<bool> stateChange, bool defaultState = false, string toolTip = "", string toolTip2 = "") {
        if (!APIBase.IsReady())
            throw new NullReferenceException("Object Search had FAILED!");

        gameObject = Object.Instantiate(APIBase.MMCTgl, grp.MenuContents.transform);
        transform = gameObject.transform;
        gameObject.name = text;

        TMProCompnt = transform.Find("LeftItemContainer/Title").GetComponent<TextMeshProUGUIEx>();
        TMProCompnt.text = text;
        TMProCompnt.richText = true;
        Text = text;

        (ToolTip = gameObject.GetComponent<UiToggleTooltip>())._localizableString = toolTip.ReturnLocalizableString();

        toggleSwitch = transform.Find("RightItemContainer/Cell_MM_OnOffSwitch").GetComponent<ToggleSwitch>();
        toggleSwitch.Method_Public_Void_Boolean_0(defaultState);

        (Handle = transform.Find("RightItemContainer/Cell_MM_OnOffSwitch/Handle"))
            .transform.localPosition = defaultState ? onPos : offPos;

        ToggleCompnt = gameObject.GetComponent<Toggle>();
        ToggleCompnt.onValueChanged = new Toggle.ToggleEvent();
        ToggleCompnt.isOn = defaultState;
        Listener = stateChange;
        ToggleCompnt.onValueChanged.AddListener(new Action<bool>((val) => {
            if (shouldInvoke)
                APIBase.SafelyInvolk(val, Listener, text);
            APIBase.Events.onCToggleValChange?.Invoke(this, val);
            toggleSwitch.Method_Public_Void_Boolean_0(val);
            Handle.localPosition = val ? onPos : offPos;
        }));
    }

    public void SoftSetState(bool value) {
        shouldInvoke = false;
        ToggleCompnt.isOn = value;
        shouldInvoke = true;
    }
}