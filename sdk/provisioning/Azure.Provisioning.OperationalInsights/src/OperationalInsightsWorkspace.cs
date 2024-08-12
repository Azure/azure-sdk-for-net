// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.Provisioning.OperationalInsights
{
    /// <summary>
    /// Represents an Operational Insights workspace.
    /// </summary>
    public class OperationalInsightsWorkspace : Resource<OperationalInsightsWorkspaceData>
    {
        // https://learn.microsoft.com/en-us/azure/templates/microsoft.operationalinsights/2022-10-01/workspaces?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.OperationalInsights/workspaces";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/src/Generated/RestOperations/WorkspacesRestOperations.cs#L36C42-L36C52
        internal const string DefaultVersion = "2022-10-01";

        private static OperationalInsightsWorkspaceData Empty(string name) => ArmOperationalInsightsModelFactory.OperationalInsightsWorkspaceData();

        /// <summary>
        /// Creates a new instance of the <see cref="OperationalInsightsWorkspaceData"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="sku">The SKU.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location</param>
        public OperationalInsightsWorkspace(
            IConstruct scope,
            OperationalInsightsWorkspaceSku? sku = default,
            ResourceGroup? parent = default,
            string name = "opinsights",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmOperationalInsightsModelFactory.OperationalInsightsWorkspaceData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: new OperationalInsightsWorkspaceSku(OperationalInsightsWorkspaceSkuName.PerGB2018)))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private OperationalInsightsWorkspace(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, OperationalInsightsWorkspaceData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OperationalInsightsWorkspace"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static OperationalInsightsWorkspace FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new OperationalInsightsWorkspace(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
