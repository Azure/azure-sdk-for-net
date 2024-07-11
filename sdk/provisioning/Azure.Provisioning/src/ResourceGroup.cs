// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;

namespace Azure.Provisioning.ResourceManager
{
    /// <summary>
    /// Resource group resource.
    /// </summary>
    public class ResourceGroup : Resource<ResourceGroupData>
    {
        internal static readonly ResourceType ResourceType = "Microsoft.Resources/resourceGroups";
        internal const string ResourceGroupFunction = "resourceGroup()";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/>.
        /// </summary>
        /// <param name="scope">The scope the resourceGroup belongs to.</param>
        /// <param name="name">The name of the resourceGroup.</param>
        /// <param name="version">The version of the resourceGroup.</param>
        /// <param name="location">The location of the resourceGroup.</param>
        /// <param name="parent">The parent of the resourceGroup.</param>
        public ResourceGroup(IConstruct scope, string? name = "rg", string version = "2023-07-01", AzureLocation? location = default, Subscription? parent = default)
            : base(scope, parent, name!, ResourceType, version, (name) => ResourceManagerModelFactory.ResourceGroupData(
                name: name,
                resourceType: ResourceType,
                tags: new Dictionary<string, string> { { "azd-env-name", scope.EnvironmentName } },
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetOrCreateSubscription();
            }
            return result;
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName)
        {
            return scope.Configuration?.UseInteractiveMode == true ? ResourceGroupFunction : base.GetAzureName(scope, resourceName);
        }
    }
}
