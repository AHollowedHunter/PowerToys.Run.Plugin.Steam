// Copyright (c) Ashley Cave
// This file is licensed to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;

namespace Community.PowerToys.Run.Plugin.Steam.Constants
{
    public static class SteamCommands
    {
        public static readonly ReadOnlyCollection<SteamCommand> Commands;

        static SteamCommands()
        {
            var commands = new List<SteamCommand>
            {
                // Put 'more important' commands first to prioritise for vague searches
                new("Game Library", "Open games", "open/games"),
                new("Friends List", "Open Friends List", "open/friends"), // Prioritise over other 'Friend' searches
                new("Open Big Picture", "Open Big Picture Mode", "open/bigpicture"),
                new("Open Downloads", "Open Downloads", "open/downloads"),
                new("Screenshots", "Open screenshots", "open/screenshots"),
                new("Steam Store", "Open Store Home Page", "store"),
                new("Inventory", "Open your Inventory", "url/CommunityInventory"),
                new("Steam Settings", "Open settings", "open/settings"),

                new("Add Friend", "Go to Add Friends", "friends/add"),
                new("Set Status Away", "Set Friends Status to Away", "friends/status/away"),
                new("Set Status Invisible", "Set Friends Status to Invisible", "friends/status/invisible"),
                new("Set Status Offline", "Set Friends Status to Offline", "friends/status/offline"),
                new("Set Status Online", "Set Friends Status to Online", "friends/status/online"),
                new("Activate Product", "Open product activation input", "open/activateproduct"),
                new("Open Console", "Open Console", "open/console"),
                new("Server Browser", "Open servers browser", "open/servers"),
                new("Steam Tools", "Open tools library", "open/tools"),
                new("Steam Community", "Open Store Community Home", "url/CommunityHome"),
                new("Family Sharing", "Open Family Sharing options", "url/FamilySharing"),
                new("Friend Activity", "Open Friends activity page", "url/SteamIDFriendsPage"),
                new("My Profile", "Open your Steam Profile Page", "url/SteamIDMyProfile"),
                new("Workshop", "Open Workshop", "url/SteamWorkshop"),
                new("My Account", "Open your account details", "url/StoreAccount"),
                new("Exit Steam", "Close and stop Steam", "exit"),
            };
            Commands = commands.AsReadOnly();
        }
    }
}
