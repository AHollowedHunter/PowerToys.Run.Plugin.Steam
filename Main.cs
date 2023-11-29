// Copyright (c) Ashley Cave
// This file is licensed to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using ManagedCommon;
using Microsoft.Win32;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Steam
{
    public class Main : IPlugin
    {
        public string Name => "Steam";

        public string Description => "Run Steam commands";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = ".")]
        public static string PluginID => "B9EEDE93AEAD4851A2DF9E48DC3A4512";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string IconPath { get; set; } = "Images/Steam.dark.png";

        private PluginInitContext _context;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Init(PluginInitContext context)
        {
            this._context = context;
            _context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(_context.API.GetCurrentTheme());
        }

        private void UpdateIconPath(Theme theme)
        {
            IconPath = theme switch
            {
                Theme.Light or Theme.HighContrastWhite => "Images/Steam.light.png",
                _ => "Images/Steam.dark.png",
            };
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }

        public List<Result> Query(Query query)
        {
            List<Result> results = new();
            Result result = new()
            {
                Title = "Steam Store",
                Score = 5000,
                SubTitle = "Steam: Open Store",
                IcoPath = IconPath,
                Action = c =>
                    {
                        var ps = new ProcessStartInfo("steam://store")
                        {
                            UseShellExecute = true,
                        };
                        Process.Start(ps);
                        return true;
                    },
            };
            results.Add(result);

            return results;
        }
    }
}
