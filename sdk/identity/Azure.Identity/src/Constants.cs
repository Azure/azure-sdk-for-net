// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity
{
    internal class Constants
    {
        // TODO: Currently this is piggybacking off the Azure CLI client ID, but needs to be switched once the Developer Sign On application is available
        public const string DeveloperSignOnClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        public const string AuthenticationUnhandledExceptionMessage = "The authentication request failed due to an unhandled exception.  See inner exception for details.";

        public static string SharedTokenCacheFilePath { get { return Path.Combine(DefaultCacheDirectory, "msal.cache"); } }

        public const int SharedTokenCacheAccessRetryCount = 100;

        public static readonly TimeSpan SharedTokenCacheAccessRetryDelay = TimeSpan.FromMilliseconds(600);

        private static string DefaultCacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");
    }
}
