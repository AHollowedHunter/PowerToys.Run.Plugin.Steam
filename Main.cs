// Copyright (c) Ashley Cave
// This file is licensed to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Community.PowerToys.Run.Plugin.Steam.Constants;
using ManagedCommon;
using Wox.Infrastructure;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Steam
{
    public class Main : IPlugin
    {
        public string Name => "Steam";

        public string Description => "Run Steam commands";

        public static string PluginID => "B9EEDE93AEAD4851A2DF9E48DC3A4512";

        private string IconPath { get; set; } = "Images/Steam.dark.png";

        private PluginInitContext _context;

        public void Init(PluginInitContext context)
        {
            this._context = context;
            this._context.API.ThemeChanged += this.OnThemeChanged;
            this.UpdateIconPath(this._context.API.GetCurrentTheme());
        }

        public List<Result> Query(Query query)
        {
            List<Result> results = new();

            foreach (var command in SteamCommands.Commands)
            {
                var titleScore = StringMatcher.FuzzySearch(query.Search, command.Title);
                var subTitleScore = StringMatcher.FuzzySearch(query.Search, command.SubTitle);
                var steamScore = StringMatcher.FuzzySearch(query.Search, "Steam");
                var scores = new[] { titleScore, subTitleScore, steamScore };
                var score = scores.Max(s => s.Score);
                if (scores.Any(s => s.Success))
                {
                    Result result = new()
                    {
                        Title = command.Title,
                        Score = score,
                        SubTitle = "Steam: " + command.SubTitle,
                        IcoPath = this.IconPath,
                        TitleHighlightData = titleScore.MatchData,
                        SubTitleHighlightData = subTitleScore.MatchData,
                        Action = command.Action,
                    };
                    results.Add(result);
                }
            }

            return results;
        }

        private void UpdateIconPath(Theme theme)
        {
            this.IconPath = theme switch
            {
                Theme.Light or Theme.HighContrastWhite => "Images/Steam.light.png",
                _ => "Images/Steam.dark.png",
            };
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            this.UpdateIconPath(newTheme);
        }
    }
}
