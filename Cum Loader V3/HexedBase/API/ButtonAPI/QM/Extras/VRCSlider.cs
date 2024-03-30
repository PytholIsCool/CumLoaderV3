﻿using HexedBase.API;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Element;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Utilities;
using WorldAPI;


using Object = UnityEngine.Object;


public class VRCSlider {
    public GameObject gameObject { get; private set; }
    public TextMeshProUGUIEx TextMeshPro { get; private set; }
    public Transform transform { get; private set; }
    public Transform slider { get; private set; }
    public SnapSliderExtendedCallbacks snapSlider { get; private set; }

    /// <summary>
    /// listener Returns BOTH the slider value and the current slider for easy live slider editing 
    /// </summary>
    public VRCSlider(Transform menu, string text, string tooltip, Action<float, VRCSlider> listener, float defaultValue = 0f, float minValue = 0f, float maxValue = 100f) {
        if (!APIBase.IsReady())
            throw new NullReferenceException("Object Search had FAILED!");

        transform = Object.Instantiate(APIBase.Slider, menu);
        gameObject = transform.gameObject;
        gameObject.name = text;

        (TextMeshPro = gameObject.transform.Find("LeftItemContainer/Title").GetComponent<TextMeshProUGUIEx>()).prop_String_0 = text;
        TextMeshPro.richText = true;

        (slider = gameObject.transform.Find("RightItemContainer/Slider"))
            .GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>()._localizableString = tooltip.ReturnLocalizableString();

        snapSlider = slider.GetComponent<SnapSliderExtendedCallbacks>();
        snapSlider.field_Private_UnityEvent_0 = null;
        snapSlider.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
        snapSlider.minValue = minValue;
        snapSlider.maxValue = maxValue;
        snapSlider.value = defaultValue;
        snapSlider.onValueChanged.AddListener(new Action<float>((va) => listener.Invoke(va, this)));

        slider.parent.Find("Text_MM_H3").gameObject.active = false;
        gameObject.GetComponent<SliderSetting>().enabled = false;
    }

    public VRCSlider PercentEnding(string ending = "%") {
        var perst = slider.parent.Find("Text_MM_H3").GetComponent<TextMeshProUGUIEx>();
        perst.gameObject.active = true;
        snapSlider.onValueChanged.AddListener(new Action<float>((va) => perst.text = va.ToString("0.00") + ending));

        return this;
    }

    public VRCSlider Button(Action onClick, string toolTip = "", Sprite Icon = null) => Button((tgl) => onClick?.Invoke(), toolTip, Icon);

    public VRCSlider Button(Action<VRCSlider> onClick, string toolTip = "", Sprite Icon = null) {
        var Btn = slider.parent.Find("Button");
        Btn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>()._localizableString = toolTip.ReturnLocalizableString();
        (Btn.GetComponent<Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent()).AddListener(new Action(() => onClick?.Invoke(this)));
        Btn.gameObject.active = true;

        if (Icon != null) Btn.Find("Icon").GetComponent<Image>().sprite = Icon;

        return this;
    }

    public VRCToggle Toggle(string text, Action<bool> listenr, bool defaultState = false, string OffTooltip = null, string OnToolTip = null,
            Sprite onimage = null, Sprite offimage = null) {
        var tgl = new VRCToggle(slider.parent, text, listenr, defaultState, OffTooltip, OnToolTip, onimage, offimage);
        tgl.OnImage.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        tgl.OnImage.transform.localPosition = new Vector3(21.5f, 35, 0);

        tgl.OffImage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        tgl.OffImage.transform.localPosition = new Vector3(-22.5f, 24.5f, 0);

        tgl.TMProCompnt.transform.localScale = new Vector3(.5f, .5f, .5f);
        tgl.TMProCompnt.transform.localPosition = new Vector3(0, -35, 0);

        tgl.GetTransform().Find("Background").localScale = new Vector3(1, .5f, 1);

        return tgl;
    }

    public VRCSlider(VRCPage menu, string text, string tooltip, Action<float> listener, float defaultValue = 0f, float minValue = 0f, float maxValue = 100f) :
        this(menu.MenuContents, text, tooltip, (va, _) => listener.Invoke(va), defaultValue, minValue, maxValue) { }

    public VRCSlider(VRCPage menu, string text, string tooltip, Action<float, VRCSlider> listener, float defaultValue = 0f, float minValue = 0f, float maxValue = 100f) :
        this(menu.MenuContents, text, tooltip, listener, defaultValue, minValue, maxValue) { }

    public VRCSlider(CGrp menu, string text, string tooltip, Action<float> listener, float defaultValue = 0f, float minValue = 0f, float maxValue = 100f) :
        this(menu.MenuContents, text, tooltip, (va, _) => listener.Invoke(va), defaultValue, minValue, maxValue) { }

    public VRCSlider(CGrp menu, string text, string tooltip, Action<float, VRCSlider> listener, float defaultValue = 0f, float minValue = 0f, float maxValue = 100f) :
        this(menu.MenuContents, text, tooltip, listener, defaultValue, minValue, maxValue) { }
}