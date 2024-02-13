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

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroup"/>.
        /// </summary>
        /// <param name="scope">The scope the resourceGroup belongs to.</param>
        /// <param name="name">The name of the resourceGroup.</param>
        /// <param name="version">The version of the resourceGroup.</param>
        /// <param name="location">The location of the resourceGroup.</param>
        public ResourceGroup(IConstruct scope, string? name = default, string version = "2023-07-01", AzureLocation? location = default)
            : base(scope, null, GetName(name), ResourceType, version, ResourceManagerModelFactory.ResourceGroupData(
                name: GetName(name),
                resourceType: ResourceType,
                tags: new Dictionary<string, string> { { "azd-env-name", Environment.GetEnvironmentVariable("AZURE_ENV_NAME") ?? throw new Exception("No environment variable 'AZURE_ENV_NAME' was found") } },
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private static string GetName(string? name) => name is null ? $"rg-{Infrastructure.Seed}" : $"{name}-{Infrastructure.Seed}";

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
    }
}
