using HexedBase.API;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorldAPI;

using Object = UnityEngine.Object;


public class CMenu : Root
{
    internal List<GameObject> ChlidrenObjects { get; set; } = new List<GameObject>(); // This prlly isn't the best way to do this

    public Button Button { get; private set; }
    public Image ImageComp { get; private set; }
    public MMCarousel RootMenu { get; private set; }
    public VRC.UI.Elements.Tooltips.UiTooltip ToolTip { get; private set; }

    public CMenu(MMCarousel ph, string buttonText, string toolTip = "", Sprite Icon = null) {
        if (!APIBase.IsReady()) throw new Exception();
        if (Icon == null) Icon = APIBase.DefaultButtonSprite;

        transform = (gameObject = Object.Instantiate(APIBase.MMMCarouselButtonTemplate, ph.BarContents)).transform;
        gameObject.name = buttonText;

        TMProCompnt = gameObject.transform.Find("Mask/Text_Name").GetComponent<TextMeshProUGUI>();
        TMProCompnt.text = buttonText;
        TMProCompnt.richText = true;

        (Button = gameObject.GetComponent<Button>()).onClick = new Button.ButtonClickedEvent();
        Button.onClick.AddListener(new Action(() => { // Once more, theres Prlly a better way to do this
            ph.MenuContents.GetChildren().ForEach(a => a.SetActive(false));
            ChlidrenObjects.ForEach(a => a.SetActive(true));
        }));

        ImageComp = gameObject.transform.Find("Icon").GetComponent<Image>();
        if (Icon != null)
            ImageComp.sprite = Icon;
        else ImageComp.gameObject.SetActive(false);

        (ToolTip = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>())._localizableString = toolTip.ReturnLocalizableString();
        RootMenu = ph;
    }
}