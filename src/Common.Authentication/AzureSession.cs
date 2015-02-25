// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public static class AzureSession
    {
        /// <summary>
        /// field to contain current profile
        /// </summary>
        private static AzureProfile _currentProfile = null;
        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        public static IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        public static IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets the current azure profile
        /// </summary>
        public static AzureProfile CurrentProfile
        {
            get
            {
                if (_currentProfile == null)
                {
                    SetCurrentProfile(InitializeDefaultProfile());
                }

                return _currentProfile;
            }
            set
            {
                SetCurrentProfile(value);
            }
        }

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        public static IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        public static TokenCache TokenCache { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        public static string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        public static string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        public static string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        public static string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        public static string OldProfileFile { get; set; }

        static AzureSession()
        {
            ClientFactory = new ClientFactory();
            AuthenticationFactory = new AuthenticationFactory();
            DataStore = new MemoryDataStore();
            TokenCache = new TokenCache();
            OldProfileFile = "WindowsAzureProfile.xml";
            OldProfileFileBackup = "WindowsAzureProfile.xml.bak";
            ProfileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.AzureDirectoryName); ;
            ProfileFile = "AzureProfile.json";
            TokenCacheFile = "TokenCache.dat";
        }

        public static AzureProfile InitializeDefaultProfile()
        {
            if (!string.IsNullOrEmpty(ProfileDirectory) && !string.IsNullOrEmpty(ProfileFile))
            {
                try
                {
                    return new AzureProfile(Path.Combine(ProfileDirectory, ProfileFile));
                }
                catch
                {
                   // swallow exceptions in creating the profile from disk
                }
            }

            return new AzureProfile();
        }

        private static void SetCurrentProfile(AzureProfile profile)
        {
            var defaultProfilePath = Path.Combine(ProfileDirectory, ProfileFile);
            if (string.Equals(profile.ProfilePath, defaultProfilePath, StringComparison.OrdinalIgnoreCase))
            {
                var tokenCacheFile = Path.Combine(ProfileDirectory, TokenCacheFile);
                TokenCache = new ProtectedFileTokenCache(tokenCacheFile);
            }
            else
            {
                TokenCache = new TokenCache();
            }

            if (!string.IsNullOrWhiteSpace(profile.ProfilePath))
            {
                DataStore = new DiskDataStore();
            }
            else
            {
                DataStore = new MemoryDataStore();
            }

            _currentProfile = profile;
        }
    }
}
