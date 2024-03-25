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
        private static AppServicePlanData Empty(string name) => ArmAppServiceModelFactory.AppServicePlanData();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppServicePlan"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent">The resource group.</param>
        public AppServicePlan(IConstruct scope, string name, string version = "2021-02-01", AzureLocation? location = default, ResourceGroup? parent = default)
            : this(scope, name, version, location, parent, false, (name) => ArmAppServiceModelFactory.AppServicePlanData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: new AppServiceSkuDescription() { Name = "B1" },
                isReserved: true))
        {
        }

        private AppServicePlan(IConstruct scope, string name, string version = "2021-02-01", AzureLocation? location = default, ResourceGroup? parent = default, bool isExisting = false, Func<string, AppServicePlanData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AppServicePlan"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static AppServicePlan FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new AppServicePlan(scope, parent: parent, name: name, isExisting: true);
    }
}
