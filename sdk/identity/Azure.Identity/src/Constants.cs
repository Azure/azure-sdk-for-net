// Copyright (c) Microsoft Corporation. All rights reserved.
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

        public const string DefaultRedirectUrl = "http://localhost";

        public static readonly string DefaultMsalTokenCacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");

        public const string DefaultMsalTokenCacheKeychainService = "Microsoft.Developer.IdentityService";

        public const string DefaultMsalTokenCacheKeyringSchema = "msal.cache";

        public const string DefaultMsalTokenCacheKeyringCollection = "default";

        public static readonly KeyValuePair<string, string> DefaultMsaltokenCacheKeyringAttribute1 = new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService");

        public static readonly KeyValuePair<string, string> DefaultMsaltokenCacheKeyringAttribute2 = new KeyValuePair<string, string>("Microsoft.Developer.IdentityService", "1.0.0.0");
        public const string DefaultMsalTokenCacheName = "msal.cache";
        public const string CaeEnabledCacheSuffix = ".cae";
        public const string CaeDisabledCacheSuffix = ".nocae";

        public const string ManagedIdentityClientId = "client_id";
        public const string ManagedIdentityResourceId = "mi_res_id";
        public const string MiSourceNoUserAssignedIdentityMessage = "User-assigned managed identity is not supported by the detected managed identity environment.";
        public const string MiSeviceFabricNoUserAssignedIdentityMessage = "Specifying a clientId or resourceId is not supported by the Service Fabric managed identity environment. The managed identity configuration is determined by the Service Fabric cluster resource configuration. See https://aka.ms/servicefabricmi for more information.";

        // Credential selection options
        public const string DevCredentials = "dev";
        public const string ProdCredentials = "prod";
    }
}
