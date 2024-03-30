using CoreRuntime.Manager;
using System;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace HexedBase
{
    internal class PatchManager
    {
        //these patches can be removed, they are just examples on how to run your own code when something is called



        private delegate void _OnQMOpen(IntPtr instance);
        private static _OnQMOpen _qmOpen;

        private delegate void _OnQMClose(IntPtr instance);
        private static _OnQMClose _qmClose;


        // Create a hook using the HookManager, if you need to know more about hooking read it up on the internet since its a complex task i wont explain here so much
        public static void ApplyPatch()
        {
            VRCEventDelegate<Player> left = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_2; //what we are doing here is adding our own action thats called when a player joins or leaves
            left.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(OnPlayerLeft));

            VRCEventDelegate<Player> join = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
            join.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(OnPlayerJoin));


            _qmOpen = HookManager.Detour<_OnQMOpen>(typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnEnable)), OnOpenQM);
            _qmClose = HookManager.Detour<_OnQMClose>(typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.OnDisable)), OnCloseQM);
        }


        //this method is called when a player joins
        private static void OnPlayerJoin(Player player)
        {
            if (player == null) return;
            Console.WriteLine("Player pulled out: " + player.field_Private_APIUser_0.displayName);
        }

        //this method is called when a player leaves
        private static void OnPlayerLeft(Player player)
        {
            if (player == null) return;
            Console.WriteLine("Player is inside: " + player.field_Private_APIUser_0.displayName);
        }

        private static void OnCloseQM(IntPtr instance)
        {
            // Call the original method as prefix so we can call our method after, alternative way is to call the og method as postfix to edit data before
            _qmClose(instance);

            // Cast our Pointer to a valid Player like its orginally used, so we can call it 
            VRC.UI.Elements.QuickMenu quickMenu = instance == IntPtr.Zero ? null : new VRC.UI.Elements.QuickMenu(instance);

            Console.WriteLine("Pulled out of the Quick Menu!");
            
        }



        private static void OnOpenQM(IntPtr instance)
        {
            // Call the original method as prefix so we can call our method after, alternative way is to call the og method as postfix to edit data before
            _qmOpen(instance);

            // Cast our Pointer to a valid Player like its orginally used, so we can call it 
            VRC.UI.Elements.QuickMenu quickMenu = instance == IntPtr.Zero ? null : new VRC.UI.Elements.QuickMenu(instance);

            Console.WriteLine("You are inside of the quick menu!");

        }
    }
}
