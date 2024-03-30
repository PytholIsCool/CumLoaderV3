using CoreRuntime.Interfaces;
using CoreRuntime.Manager;
using Cysharp.Threading.Tasks.Linq;
using HexedBase.XtrMn;
using System;
using System.Collections;
using UnityEngine;

namespace HexedBase
{
    public class Entry : HexedCheat // Define the Main Class for the Loader
    {
        private static IEnumerator waitForQM()
        {
            Console.WriteLine("Birthing menus OwO");
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null) yield return null;
            yield return null;

            while (GameObject.Find("Canvas_MainMenu(Clone)") == null) yield return null;
            yield return null;

            Main.Init();
            SubM.Init();
            CumModule2.Init();

            yield break;
        }
        public override void OnLoad()
        {
            //Entry thats getting called by HexedLoader
            Console.ForegroundColor = ConsoleColor.White;

            if (!System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\SpermBank\\CumLoader\\"))
            {
                System.IO.Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\SpermBank\\CumLoader\\");
                Console.WriteLine("Sperm Bank has be configured");
            }
            else
            {
                Console.WriteLine("Going to the Sperm Bank to make a contribution.");
            }

            Console.WriteLine(" $$$$$$\\   $$\\   $$\\ $$\\      $$\\       $$\\       $$$$$$\\   $$$$$$\\  $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\  ");
            Console.WriteLine("$$  __$$\\  $$ |  $$ |$$$\\    $$$ |      $$ |     $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  _____ |$$  __$$\\ ");
            Console.WriteLine("$$ /  \\__| $$ |  $$ |$$$$\\  $$$$ |      $$ |     $$ /  $$ |$$ /  $$ |$$ |  $$ |$$ |      $$ |  $$ |");
            Console.WriteLine("$$ |       $$ |  $$ |$$\\$$\\$$ $$ |      $$ |     $$ |  $$ |$$$$$$$$ |$$ |  $$ |$$$$$\\    $$$$$$$  |");
            Console.WriteLine("$$ |       $$ |  $$ |$$ \\$$$  $$ |      $$ |     $$ |  $$ |$$  __$$ |$$ |  $$ |$$  __|   $$  __$$< ");
            Console.WriteLine("$$ |  $$\\  $$ |  $$ |$$ |\\$  /$$ |      $$ |     $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |  $$ |");
            Console.WriteLine("\\$$$$$$  | \\$$$$$$  |$$ | \\_/ $$ |      $$$$$$$$\\ $$$$$$  |$$ |  $$ |$$$$$$$  |$$$$$$$$\\ $$ |  $$ |");
            Console.WriteLine(" \\______ /  \\______/ \\__|     \\__|      \\________|\\______/ \\__|  \\__|\\_______/ \\________|\\__|  \\__|");
            Console.WriteLine("CUM INJECTED !");

            Console.WriteLine("░░███████████");
            Console.WriteLine("░██░░░░░░░░░░██");
            Console.WriteLine("█░░░░░░░░░░░░░█░░░░░████████████████████████████");
            Console.WriteLine("░░░░░░░░░███████████░░░░░░░░░░░░░░░░░░░░░░░░░█░█████");
            Console.WriteLine("░░░░░███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░░░░██");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░██");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░░████");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░░░███");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░███");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████████████");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████████");
            Console.WriteLine("░░░█████████████████████████");
            Console.WriteLine("░░░░░░░░░░░████");
            Console.WriteLine("█░░░░░░░░░░░░░█");
            Console.WriteLine("░███░░░░░░░░░░█");
            Console.WriteLine("░░░███████████");
            Console.WriteLine("");
            Console.WriteLine("░█████╗░██╗░░░██╗███╗░░░███╗  ██╗░░░░░░█████╗░░█████╗░██████╗░███████╗██████╗░");
            Console.WriteLine("██╔══██╗██║░░░██║████╗░████║  ██║░░░░░██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗");
            Console.WriteLine("██║░░╚═╝██║░░░██║██╔████╔██║  ██║░░░░░██║░░██║███████║██║░░██║█████╗░░██████╔╝");
            Console.WriteLine("██║░░██╗██║░░░██║██║╚██╔╝██║  ██║░░░░░██║░░██║██╔══██║██║░░██║██╔══╝░░██╔══██╗");
            Console.WriteLine("╚█████╔╝╚██████╔╝██║░╚═╝░██║  ███████╗╚█████╔╝██║░░██║██████╔╝███████╗██║░░██║");
            Console.WriteLine("░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝  ╚══════╝░╚════╝░╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝");
            Console.WriteLine("\n\nMade by Cyconi and Pythol\n\n");
            // Specify our main function hooks to let the loader know about the games base functions, it takes any method that matches the original unity function struct
            MonoManager.PatchUpdate(typeof(VRCApplication).GetMethod(nameof(VRCApplication.Update))); // Update is needed to work with IEnumerators, hooking it will enable the CoroutineManager
            // Apply our custom Hooked function
            CoroutineManager.RunCoroutine(waitForQM());
        }

        public override void OnApplicationQuit()
        {
            Console.WriteLine("Game Closed! Bye!");
        }
        private static IEnumerator PrintLateHello()
        {
            // Example on calling a simple print after a 5 second delay
            yield return new WaitForSeconds(5);

            Console.WriteLine("Hello from a delayed function!");
        }
    }
}
