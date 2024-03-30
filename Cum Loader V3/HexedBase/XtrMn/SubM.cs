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

namespace HexedBase.XtrMn
{
    internal class SubM
    {
        public static VRCPage SubMainPage;
        public static ButtonGroup SubGrp;
        public static ButtonGroup TrueCum;
        public static void Init()
        {
            //Making the new sub menu and its contents
            SubMainPage = new VRCPage("Submissive Menu");
            SubGrp = new ButtonGroup(SubMainPage, "", false);
            TrueCum = new ButtonGroup(SubMainPage, "", false);

            SubGrp.AddButton("Clean up", "Click to Cum!", () =>
            {
                LogHandler.Log("You cleaned up all the Cum!");
            });

            SubGrp.AddToggle("Apiss Swastika", (isNazi) =>
            {
                if (isNazi)
                {
                    LogHandler.Log("waaaaa someone is using my skidded orbit");
                    LogHandler.Log("goo goo gaa gaa, i got mad someone made a joke about my orbit");
                }
                else
                {
                    LogHandler.Log("bunny pissing there pants rn");
                    LogHandler.Log("Fuck apiss lmaoo");
                }
            });

            SubGrp.AddButton("Cum Zone", "Play cum zone", () =>
            {
                Application.OpenURL("https://youtu.be/j0lN0w5HVT8");
            });

            SubGrp.AddButton("Subway Sexists", "Subway Sexists", () =>
            {
                Application.OpenURL("https://youtu.be/uFPu4Gfau2o");
            });

            SubGrp.AddButton("Cum?", "Cum whats that?", () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Application.OpenURL("https://www.urbandictionary.com/define.php?term=Cum");
                }
            });

            SubGrp.AddButton("Hentai", "mmmm Hentai", () =>
            {
                Application.OpenURL("https://nhentai.net/");
                Application.OpenURL("https://hanime.tv/");
            });

            SubGrp.AddToggle("Gay", (isGay) =>
            {
                if (isGay)
                {
                    LogHandler.Log("You are gay, very gay");
                    Application.OpenURL("https://youtu.be/dQw4w9WgXcQ");
                }
                else
                {
                    LogHandler.Log("you have ungayed");
                }
            });

            SubGrp.AddButton("Fatherless Child", "Toggle Fatherless Child Detector", () =>
            {
                LogHandler.Log("Fatherless Child Detector - On");
                LogHandler.Log("Beep Beep Beep Beep");
                LogHandler.Log("Fatherless Child been loctated!");
                Application.OpenURL("https://youtu.be/vA_P0IPNcog");
            });

            SubGrp.AddButton("HES PULLING HIS COCK OUT", "HES PULLING HIS COCK OUT!!", () =>
            {
                Application.OpenURL("https://youtu.be/YwILuJ5lVwM");
                LogHandler.Log("HES PULLING HIS COCK OUT!!");
            });

            SubGrp.AddButton("Men", "Men", () =>
            {
                Application.OpenURL("https://youtu.be/YwILuJ5lVwM");
                for (int i = 0; i < 50; i++)
                {
                    LogHandler.Log("Men");
                }
            });

            SubGrp.AddToggle("gahhhhhhhhhhhhhhhhhhhhhhhh myyyyyyy earrrrrrrrrrrrrrssss", (areEardrumsBlownOut) =>
            {
                if (areEardrumsBlownOut)
                {
                    LogHandler.Log("aasdjhlkfahsjklfhasjlkdf hajklsdhfjklashdfjkahfjlashdjfkghaejofhsanbcjkvahbdjkglhadjklvhajksfhasdkjlfha ");
                }
                else
                {
                    LogHandler.Log("my ears hurt...");
                }
            });
            SubGrp.AddToggle("Additional Cum Module", (HasNoCum) =>
            {
                if (HasNoCum)
                {
                    TrueCum.AddButton("<color=#ffffff>CUM MODULE 2</color>", "Experience TRUE CUM", () => 
                    {
                        CumModule2.CModP.OpenMenu();
                    }, false, true);
                }
                else
                {
                    TrueCum.RemoveAllChildren();
                }
            }, false, "Experience cum like never before", "Stay a virgin forever... loser...");
        }
    }
}
