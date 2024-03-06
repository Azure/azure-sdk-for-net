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
        private const string ResourceTypeName = "Microsoft.AppConfiguration/configurationStores";
        private static readonly Func<string, AppConfigurationStoreData> Empty = (name) => ArmAppConfigurationModelFactory.AppConfigurationStoreData();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationStore"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public AppConfigurationStore(IConstruct scope, string name = "store", string version = "2023-03-01", AzureLocation? location = default)
            : this(scope, name, version, location, null, false, (name) => ArmAppConfigurationModelFactory.AppConfigurationStoreData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                skuName: "free"))
        {
            AddOutput(store => store.Endpoint, $"{Name}_endpoint");
        }

        private AppConfigurationStore(IConstruct scope, string name = "store", string version = "2023-03-01", AzureLocation? location = default, ResourceGroup? parent = null, bool isExisting = false, Func<string, AppConfigurationStoreData>? creator = null)
            : base(scope, null, name, ResourceTypeName, version, creator ?? Empty, isExisting)
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
            => new AppConfigurationStore(scope, name, parent: parent, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetOrAddResourceGroup();
            }
            return result;
        }
    }
}
