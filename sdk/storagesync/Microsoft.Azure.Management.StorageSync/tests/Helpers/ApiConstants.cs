// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public static class ApiConstants
    {
        public const string
            Subscriptions = "subscriptions",
            ResourceGroups = "resourceGroups",
            Providers = "providers",
            StorageSyncServices = "storageSyncServices",
            SyncGroups = "syncGroups",
            ServerEndpoints = "serverEndpoints",
            CloudEndpoints = "cloudEndpoints",
            ResourceProviderNamespace = "Microsoft.StorageSync";
    }

    public static class Constants
    {
        public const string StorageAccountFileUriTemplate = "https://{0}.file.core.windows.net/";
    }
}
