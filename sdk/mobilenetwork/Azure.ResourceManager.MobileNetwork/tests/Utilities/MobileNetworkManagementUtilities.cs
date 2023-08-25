// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.MobileNetwork.Models;

namespace Azure.ResourceManager.MobileNetwork.Tests.Utilities
{
    public class MobileNetworkManagementUtilities
    {
        public static AzureLocation DefaultResourceLocation = new AzureLocation("westcentralus");
        public static string DefaultResourceGroupName = "DotNetSDKUTRG";
    }
}
