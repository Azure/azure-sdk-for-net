﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.Identity
{
    internal class Constants
    {
        public const string OrganizationsTenantId = "organizations";

        public const string AdfsTenantId = "adfs";

        // TODO: Currently this is piggybacking off the Azure CLI client ID, but needs to be switched once the Developer Sign On application is available
        public const string DeveloperSignOnClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        public static string SharedTokenCacheFilePath { get { return Path.Combine(DefaultMsalTokenCacheDirectory, DefaultMsalTokenCacheName); } }

        public const int SharedTokenCacheAccessRetryCount = 100;

        public static readonly TimeSpan SharedTokenCacheAccessRetryDelay = TimeSpan.FromMilliseconds(600);

        public const string DefaultRedirectUrl = "http://localhost";

        public static readonly string DefaultMsalTokenCacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");

        public const string DefaultMsalTokenCacheKeychainService = "Microsoft.Developer.IdentityService";

        public const string DefaultMsalTokenCacheKeychainAccount = "MSALCache";

        public const string DefaultMsalTokenCacheKeyringLabel = "MSALCache";

        public const string DefaultMsalTokenCacheKeyringSchema = "msal.cache";

        public const string DefaultMsalTokenCacheKeyringCollection = "default";

        public static readonly KeyValuePair<string, string> DefaultMsaltokenCacheKeyringAttribute1 = new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService");

        public static readonly KeyValuePair<string, string> DefaultMsaltokenCacheKeyringAttribute2 = new KeyValuePair<string, string>("Microsoft.Developer.IdentityService", "1.0.0.0");

        public const string DefaultMsalTokenCacheName = "msal.cache";
    }
}
