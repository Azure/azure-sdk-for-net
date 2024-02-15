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

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationStore"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public AppConfigurationStore(IConstruct scope, string name = "store", string version = "2023-03-01", AzureLocation? location = default)
            : base(scope, null, name, ResourceTypeName, version, (name) => ArmAppConfigurationModelFactory.AppConfigurationStoreData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                skuName: "free"))
        {
        }

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
