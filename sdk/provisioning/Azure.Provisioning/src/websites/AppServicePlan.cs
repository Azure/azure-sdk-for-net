// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;

namespace Azure.Provisioning.AppService
{
    /// <summary>
    /// Represents an App Service Plan.
    /// </summary>
    public class AppServicePlan : Resource<AppServicePlanData>
    {
        private const string ResourceTypeName = "Microsoft.Web/serverfarms";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppServicePlan"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The resource group.</param>
        public AppServicePlan(IConstruct scope, string resourceName, string version = "2021-02-01", AzureLocation? location = default, ResourceGroup? parent = default)
            : base(scope, parent, resourceName, ResourceTypeName, version, (name) => ArmAppServiceModelFactory.AppServicePlanData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: new AppServiceSkuDescription() { Name = "B1" },
                isReserved: true),
                data => data.Location)
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
