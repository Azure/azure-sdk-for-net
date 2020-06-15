// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Azure.Management.Resources;
using Azure.Management.Resources.Models;

namespace Azure.Management.EventHub.Tests
{
    public static class Helper
    {
        internal const string ResourceGroupPrefix = "Default-EventHub-";
        internal const string NamespacePrefix = "sdk-Namespace-";
        internal const string AuthorizationRulesPrefix = "sdk-Authrules-";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        internal const string EventHubPrefix = "sdk-EventHub-";
        internal const string ConsumerGroupPrefix = "sdk-ConsumerGroup-";
        internal const string DisasterRecoveryPrefix = "sdk-DisasterRecovery-";

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = RandomNumberGenerator.Create())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
    }
}
