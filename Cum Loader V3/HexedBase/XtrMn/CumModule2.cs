using Il2CppSystem.Diagnostics;
using OVR.OpenVR;
using Starborn.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Playables;
using VRC.Core;
using VRC.DataModel;
using VRC.SDKBase;
using VRC.UI.Client.Emoji;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Menus;

namespace HexedBase.XtrMn
{
    internal class CumModule2
    {
        public static VRCPage CModP;
        public static ButtonGroup CModGrp;

        public static void Init()
        {
            CModP = new VRCPage("Cum: The Sequel");
            CModGrp = new ButtonGroup(CModP, "", false);

            CModGrp.AddToggle("Mom Finder", (HasNoMommy) =>
            {
                if (HasNoMommy)
                {
                    Application.OpenURL("https://singlemomfinder.com");
                    for (int i = 0; i < 50; i++)
                    {
                        LogHandler.Log("Mommy? I mean-");
                    }
                }
                else
                {

                }
            }, false, "Find your mommy", "Stop finding your mommy");

            CModGrp.AddButton("Cum", "Cum", () =>
            {
                LogHandler.Log("Still havent decided what this will do");
            });
        }
    }
}
