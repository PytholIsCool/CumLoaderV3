using Il2CppSystem.Net;
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
using UnityEngine.UI;
using Il2CppSystem.Diagnostics;
using System.Security.Policy;
using VRC.UI.Elements.Buttons;

namespace HexedBase
{
    internal class Main
    {
        public static VRCPage MainPage;
        public static ButtonGroup MainGrp;
        public static void Init()
        {
            MainPage = new VRCPage("Cum Loader");
            new Tab(MainPage, "Cum Loader", Resources.Icon());
            MainGrp = new ButtonGroup(MainPage, "Main", false);


            MainGrp.AddToggle("Boner", (isStraight) =>
            {
                if (isStraight)
                {
                    LogHandler.Log("You just got Erect");
                    LogHandler.Log("You watched gay porn");
                    LogHandler.Log("I have a boner");
                }
                else
                {
                    LogHandler.Log("You are now Flaccid");
                    LogHandler.Log("(you watched straight porn)");
                    LogHandler.Log("I have a small pp");
                }
            }, false, "CUM", "Click to Cum!");

            MainGrp.AddButton("Click to cum!", "ambatakam", () =>
            {
                LogHandler.Log("You Came");
            });

            MainGrp.AddToggle("E-Thot Detector", (isDetectorOn) =>
            {
                if (isDetectorOn)
                {
                    LogHandler.Log("E-Thot Detector - On");
                    LogHandler.Log("Beep Beep Beep Beep");
                    LogHandler.Log("E-Thot has been loctated!");
                    LogHandler.Log("Calling All E-Thots!");
                }
                else
                {
                    LogHandler.Log("E-Thot Detector - Off");
                    LogHandler.Log("No more pixel pounding for you.");
                    LogHandler.Log("I get no bitches");
                }
            });

            MainGrp.AddButton("WC Staff ERP", "Lets you Erp With World Client Staff members!", () =>
            {
                LogHandler.Log("You send out a signal to world client staff that you want to erp");
            });

            MainGrp.AddButton("Made By Cyconi and Pythol", "Cyconi is Best World Client Staff", () =>
            {
                LogHandler.Log("Cyconi is Hot");
                LogHandler.Log("Pythol is lowkey kinda cute");
            });

            MainGrp.AddToggle("Dad Finder", (isDadFinderOn) =>
            {
                if (isDadFinderOn)
                {
                    LogHandler.Log("Dad Finder - On");
                    LogHandler.Log("Beep Beep Beep Beep");
                    LogHandler.Log("This may take some time...");
                    LogHandler.Log("Looking for a father figure!");
                    Application.OpenURL("https://dadfinder9000.site123.me/");
                }
                else
                {
                    LogHandler.Log("Dad Finder - Off");
                    LogHandler.Log("We were unable to find your dad");
                    LogHandler.Log("No longer looking for a father figure");
                }
            }, false, "Toggle The Dad Finder", "Toggle The Dad Finder");

            MainGrp.AddToggle("Horny Detector", (isHDetectorOn) =>
            {
                if (isHDetectorOn)
                {
                    LogHandler.Log("Horny Detector - On");
                    LogHandler.Log("Beep Beep Beep Beep");
                    LogHandler.Log("You are horny!");
                    Application.OpenURL("https://youtu.be/oO-gc3Lh-oI");
                }
                else
                {
                    LogHandler.Log("Horny Detector - Off");
                    LogHandler.Log("We couldn't find the Horny");
                }
            }, false, "Toggle Fatherless Child Detector", "Toggle Fatherless Child Detector");

            MainGrp.AddButton("Sub Menu", "Opens the submissive menu OwO", () =>
            {
                XtrMn.SubM.SubMainPage.OpenMenu();
            }, false, true);

            new VRCSlider(MainPage, "Cum Strength", "How hard will you cum", (cumStr) =>
            {
                LogHandler.Log(LogHandler.Colors.White, "Cum Strength Adjusted To " + cumStr + "%");
            }, 0f, 0f, 100f);
        }
    }
}