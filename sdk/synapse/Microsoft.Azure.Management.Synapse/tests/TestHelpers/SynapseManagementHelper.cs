// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class SynapseManagementHelper
    {
        /// <summary>
        /// Provides operations for working with resources and resource groups.
        /// </summary>
        private ResourceManagementClient resourceManagementClient;

        /// <summary>
        /// The Azure Storage Management API.
        /// </summary>
        private StorageManagementClient storageManagementClient;

        /// <summary>
        /// Common data
        /// </summary>
        private CommonTestFixture commonData;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="context"></param>
        public SynapseManagementHelper(CommonTestFixture commonData, SynapseMockContext context)
        {
            resourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            storageManagementClient = context.GetServiceClient<StorageManagementClient>();
            this.commonData = commonData;
        }

        /// <summary>
        /// Register subscription for resource
        /// </summary>
        /// <param name="providerName"></param>
        public void RegisterSubscriptionForResource(string providerName)
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(
                reg == null,
                "resourceManagementClient.Providers.Register returned null."
            );

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(
                resultAfterRegister == null,
                "resourceManagementClient.Providers.Get returned null."
            );
            ThrowIfTrue(
                string.IsNullOrEmpty(resultAfterRegister.Id),
                "Provider.Id is null or empty."
            );
            ThrowIfTrue(
                !providerName.Equals(resultAfterRegister.NamespaceProperty),
                string.Format(
                    "Provider name: {0} is not equal to {1}.",
                    resultAfterRegister.NamespaceProperty,
                    providerName
                )
            );
            ThrowIfTrue(
                !resultAfterRegister.RegistrationState.Equals("Registered") &&
                !resultAfterRegister.RegistrationState.Equals("Registering"),
                string.Format(
                    "Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'",
                    resultAfterRegister.RegistrationState
                )
            );
            ThrowIfTrue(
                resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0,
                "Provider.ResourceTypes is empty."
            );
        }

        /// <summary>
        /// Create resource group
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="location"></param>
        public void CreateResourceGroup(string resourceGroupName, string location)
        {
            // Get the resource group first
            bool exists = false;
            ResourceGroup newlyCreatedGroup = null;
            try
            {
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
                exists = true;
            }
            catch
            {
                // Do nothing because it means it doesn't exist
            }

            if (!exists)
            {
                var result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(
                        resourceGroupName,
                        new ResourceGroup { Location = location }
                    );

                newlyCreatedGroup =
                    resourceManagementClient.ResourceGroups.Get(
                        resourceGroupName
                    );
            }

            ThrowIfTrue(
                newlyCreatedGroup == null,
                "resourceManagementClient.ResourceGroups.Get returned null."
            );
            ThrowIfTrue(
                !resourceGroupName.Equals(newlyCreatedGroup.Name),
                string.Format(
                    "resourceGroupName is not equal to {0}",
                    resourceGroupName
                )
            );
        }

        /// <summary>
        /// Create storage account
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="storageAccountName"></param>
        /// <param name="location"></param>
        /// <param name="storageAccountSuffix"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public string CreateStorageAccount(
                    string resourceGroupName,
                    string storageAccountName,
                    string location,
                    out string storageAccountSuffix,
                    string kind = Kind.StorageV2,
                    bool? isHnsEnabled = default(bool?))
        {
            var stoInput = new StorageAccountCreateParameters
            {
                Location = location,
                Kind = kind,
                Sku = new Microsoft.Azure.Management.Storage.Models.Sku
                {
                    Name = Microsoft.Azure.Management.Storage.Models.SkuName.StandardGRS
                },
                IsHnsEnabled = isHnsEnabled
            };

            // Retrieve the storage account
            storageManagementClient.StorageAccounts.Create(resourceGroupName, storageAccountName, stoInput);

            // Retrieve the storage account primary access key
            var accessKey = storageManagementClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName).Keys[0].Value;

            ThrowIfTrue(
                string.IsNullOrEmpty(accessKey),
                "storageManagementClient.StorageAccounts.ListKeys returned null."
            );

            // Set the storage account suffix
            var getResponse =
                storageManagementClient.StorageAccounts.GetProperties(
                    resourceGroupName,
                    storageAccountName
                );
            storageAccountSuffix = getResponse.PrimaryEndpoints.Blob.ToString();
            storageAccountSuffix = storageAccountSuffix.Replace("https://", "").TrimEnd('/');
            storageAccountSuffix = storageAccountSuffix.Replace(storageAccountName, "").TrimStart('.');
            // Remove the opening "blob." if it exists.
            storageAccountSuffix = storageAccountSuffix.Replace("blob.", "");

            return accessKey;
        }

        /// <summary>
        /// Throw expception if the given condition is satisfied
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
