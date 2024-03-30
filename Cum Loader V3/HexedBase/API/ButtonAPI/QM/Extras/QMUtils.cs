using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC.UI.Elements;
using Object = UnityEngine.Object;


public static class QMUtils {
    private static VRC.UI.Elements.QuickMenu _Qm;
    private static MainMenu _MM;

    internal static MenuStateController QuickMenuController;
    internal static MenuStateController MainMenuController;
    internal static MenuStateController WLcontroller;
    internal static MenuStateController WRcontroller;

    public static VRC.UI.Elements.QuickMenu GetQuickMenuInstance
    {
        get
        {
            if (_Qm == null)
            {
                _Qm = Resources.FindObjectsOfTypeAll<VRC.UI.Elements.QuickMenu>().FirstOrDefault();
            }
            return _Qm;
        }
    }

    public static MainMenu GetMainMenuInstance
    {
        get
        {
            if (_MM == null)
            {
                _MM = Resources.FindObjectsOfTypeAll<MainMenu>().FirstOrDefault(x => x.name == "Canvas_MainMenu(Clone)");
            }
            return _MM;
        }
    }

    public static MenuStateController GetMenuStateControllerInstance
    {
        get
        {
            if (QuickMenuController == null)
            {
                QuickMenuController = GetQuickMenuInstance.GetComponent<MenuStateController>();
            }
            return QuickMenuController;
        }
    }

    public static MenuStateController GetMainMenuStateControllerInstance
    {
        get
        {
            if (MainMenuController == null)
            {
                MainMenuController = GetMainMenuInstance.GetComponent<MenuStateController>();
            }
            return MainMenuController;
        }
    }

    public static MenuStateController GetWngLMenuStateControllerInstance
    {
        get
        {
            if (WLcontroller == null)
            {
                WLcontroller = GetQuickMenuInstance.transform.Find("CanvasGroup/Container/Window/Wing_Left").GetComponent<MenuStateController>();
            }
            return WLcontroller;
        }
    }

    public static MenuStateController GetWngRMenuStateControllerInstance
    {
        get
        {
            if (WRcontroller == null)
            {
                WRcontroller = GetQuickMenuInstance.transform.Find("CanvasGroup/Container/Window/Wing_Right").GetComponent<MenuStateController>();
            }
            return WRcontroller;
        }
    }


    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component => gameObject.transform.GetOrAddComponent<T>();

    public static T GetOrAddComponent<T>(this Transform transform) where T : Component {
        T component = transform.GetComponent<T>();
        if (component == null)
            return transform.gameObject.AddComponent<T>();

        return component;
    }

    public static void DestroyChildren(this Transform transform, Func<Transform, bool> exclude = null) {
        for (var childcount = transform.childCount - 1; childcount >= 0; childcount--)
            if (exclude == null || exclude(transform.GetChild(childcount)))
                Object.DestroyImmediate(transform.GetChild(childcount).gameObject);
    }

    public static void DestroyChildren(this GameObject gameObj, Func<Transform, bool> exclude = null) =>
        gameObj.transform.DestroyChildren(exclude);

    public static List<GameObject> GetChildren(this Transform transform) {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++) {
            GameObject gameObject = transform.GetChild(i).gameObject;
            list.Add(gameObject);
        }
        return list;
    }

    internal static bool IsObfuscated(this string str) {
        foreach (var it in str)
            if (!char.IsDigit(it) && !((it >= 'a' && it <= 'z') || (it >= 'A' && it <= 'Z')) && it != '_' &&
                it != '`' && it != '.' && it != '<' && it != '>')
                return true;

        return false;
    }

    public static void ResetTransform(Transform transform) {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = Vector3.zero;
    }

    public static void RemoveUnknownComps(GameObject gameObject, Action<string> callBackOnDestroy = null) {
        Component[] components = gameObject.GetComponents<Component>();
        for (int D = 0; D < components.Length; D++) {
            var name = components[D].GetIl2CppType().Name;

            if (name.IsObfuscated() && components[D].GetIl2CppType().BaseType.Name != nameof(TMPro.TextMeshProUGUI)) {
                Object.Destroy(components[D]);
                callBackOnDestroy?.Invoke(name);
            }
        }
    }
}