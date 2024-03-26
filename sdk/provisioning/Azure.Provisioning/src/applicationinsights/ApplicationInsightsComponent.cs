// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.CosmosDB;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.ApplicationInsights;
using Azure.ResourceManager.ApplicationInsights.Models;

namespace Azure.Provisioning.ApplicationInsights
{
    /// <summary>
    /// Represents an Application Insights component.
    /// </summary>
    public class ApplicationInsightsComponent : Resource<ApplicationInsightsComponentData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.insights/2020-02-02/components?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Insights/components";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/src/Generated/RestOperations/ComponentsRestOperations.cs#L36
        internal const string DefaultVersion = "2020-02-02";

        private static ApplicationInsightsComponentData Empty(string name) => ArmApplicationInsightsModelFactory.ApplicationInsightsComponentData();

        /// <summary>
        /// Creates a new instance of the <see cref="ApplicationInsightsComponentData"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="applicationType">The application type.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location</param>
        public ApplicationInsightsComponent(
            IConstruct scope,
            string kind = "web",
            string applicationType = "web",
            ResourceGroup? parent = default,
            string name = "appinsights",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, location, false, (name) => ArmApplicationInsightsModelFactory.ApplicationInsightsComponentData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                kind: kind,
                applicationType: applicationType))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private ApplicationInsightsComponent(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            AzureLocation? location = default,
            bool isExisting = false,
            Func<string, ApplicationInsightsComponentData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBAccount"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static ApplicationInsightsComponent FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new ApplicationInsightsComponent(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
