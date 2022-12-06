// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport
{
    using System;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.Helpers;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.KubernetesConfiguration;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;

    /// <summary>
    /// Base class for tests of SourceControlConfiguration resource type
    /// </summary>
    public class FluxConfigurationTestBase : TestBase, IDisposable
    {
        public SourceControlConfigurationClient SourceControlConfigurationClient { get; set; }

        public FluxConfiguration FluxConfiguration { get; set; }

        public const string ApiVersion = "2022-03-01";
        public const string ConfigurationType = "FluxConfiguration";

        public ClusterInfo Cluster { get; set; }

        public FluxConfigurationTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            SourceControlConfigurationClient = context.GetServiceClient<SourceControlConfigurationClient>(false, handler);
        }

        /// <summary>
        /// Creates or Updates a FluxConfiguration
        /// </summary>
        /// <returns>The FluxConfiguration object that was created or updated.</returns>
        public FluxConfiguration CreateFluxConfiguration()
        {
            return SourceControlConfigurationClient.FluxConfigurations.BeginCreateOrUpdate(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                fluxConfigurationName: FluxConfiguration.Name,
                fluxConfiguration: FluxConfiguration);
        }

        /// <summary>
        /// Get a FluxConfiguration
        /// </summary>
        /// <returns>The FluxConfiguration object.</returns>
        public FluxConfiguration GetFluxConfiguration()
        {
            return SourceControlConfigurationClient.FluxConfigurations.Get(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                fluxConfigurationName: FluxConfiguration.Name
            );
        }

        /// <summary>
        /// Delete a FluxConfiguration
        /// </summary>
        public void DeleteFluxConfiguration(bool force = true)
        {
            SourceControlConfigurationClient.FluxConfigurations.BeginDelete(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                fluxConfigurationName: FluxConfiguration.Name,
                forceDelete: force
            );
        }

        /// <summary>
        /// List FluxConfigurations in a cluster
        /// </summary>
        /// <returns></returns>
        public IPage<FluxConfiguration> ListFluxConfigurations()
        {
            return SourceControlConfigurationClient.FluxConfigurations.List(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name
            );
        }

        #region Common Methods

        public void Dispose()
        {
            SourceControlConfigurationClient.Dispose();
        }

        #endregion
    }
}