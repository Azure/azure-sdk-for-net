// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Developer.Playwright.Interface;

namespace Azure.Developer.Playwright.Implementation
{
    internal class PlaywrightVersion: IPlaywrightVersion
    {
        public void ValidatePlaywrightVersion()
        {
            var minimumSupportedVersion = Constants.s_minimumSupportedPlaywrightVersion;
            var installedVersion = GetPlaywrightVersion();

            var minimumSupportedVersionInfo = GetVersionInfo(minimumSupportedVersion);
            var installedVersionInfo = GetVersionInfo(installedVersion);

            var isInstalledVersionGreater =
                installedVersionInfo.Major > minimumSupportedVersionInfo.Major ||
                (installedVersionInfo.Major == minimumSupportedVersionInfo.Major &&
                 installedVersionInfo.Minor >= minimumSupportedVersionInfo.Minor);

            if (!isInstalledVersionGreater)
            {
                throw new Exception(Constants.s_playwright_Version_not_supported_error_message);
            }
        }
        public string GetPlaywrightVersion()
        {
            string assemblyName = "Microsoft.Playwright";

            var assembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == assemblyName);

            if (assembly != null)
            {
                Version version = assembly.GetName().Version!;
                return version.ToString();
            }
            else
            {
                throw new Exception(Constants.s_playwright_Invalid_version);
            }
        }

        internal  (int Major, int Minor) GetVersionInfo(string version)
        {
            var parts = version.Split('.');
            if (parts.Length < 2 ||
                !int.TryParse(parts[0], out var major) ||
                !int.TryParse(parts[1], out var minor))
            {
                throw new ArgumentException("Invalid version format.");
            }
            return (major, minor);
        }
    }
}
