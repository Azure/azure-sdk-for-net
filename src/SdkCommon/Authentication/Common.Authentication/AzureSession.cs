// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public static class AzureSession
    {
        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        public static IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        public static IAuthenticationFactory AuthenticationFactory { get; set; }

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
    }
}
