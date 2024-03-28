// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;

namespace Azure.Provisioning.AppConfiguration
{
    /// <summary>
    /// Represents a KeyVault.
    /// </summary>
    public class AppConfigurationStore : Resource<AppConfigurationStoreData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.appconfiguration/2023-03-01/configurationstores?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.AppConfiguration/configurationStores";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/src/Generated/RestOperations/ConfigurationStoresRestOperations.cs#L36
        private const string DefaultVersion = "2023-03-01";

        private static AppConfigurationStoreData Empty(string name) => ArmAppConfigurationModelFactory.AppConfigurationStoreData();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationStore"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="skuName">The sku name.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public AppConfigurationStore(IConstruct scope, string skuName = "free",  ResourceGroup? parent = null, string name = "store", string version = DefaultVersion, AzureLocation? location = default)
            : this(scope, parent, name, version, (name) => ArmAppConfigurationModelFactory.AppConfigurationStoreData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                skuName: skuName))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private AppConfigurationStore(IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            Func<string, AppConfigurationStoreData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AppConfigurationStore"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static AppConfigurationStore FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new AppConfigurationStore(scope, parent, name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
