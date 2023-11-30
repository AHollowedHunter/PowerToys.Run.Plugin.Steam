// Copyright (c) Ashley Cave
// This file is licensed to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Steam
{
    public sealed class SteamCommand
    {
        public string Title { get; init; }

        public string SubTitle { get; init; }

        public string Uri { get; init; }

        public SteamCommandParameterType ParameterType { get; init; }

        public SteamCommand(string title, string subTitle, string uri, SteamCommandParameterType parameterType = SteamCommandParameterType.None)
        {
            this.Title = title;
            this.SubTitle = subTitle;
            this.Uri = uri;
            this.ParameterType = parameterType;
        }

        public bool Action(ActionContext actionContext)
        {
            var ps = new ProcessStartInfo("steam://" + this.Uri)
            {
                UseShellExecute = true,
            };
            Process.Start(ps);
            return true;
        }
    }

    public enum SteamCommandParameterType
    {
        None,
        AppID,
        SteamID64,
        PublisherName,
        SettingsMenu,
    }
}
