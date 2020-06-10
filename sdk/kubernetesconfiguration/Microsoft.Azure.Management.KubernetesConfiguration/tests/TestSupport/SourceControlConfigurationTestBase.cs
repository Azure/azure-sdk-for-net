// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace KubernetesConfiguration.Tests.TestSupport
{
    using System;
    using KubernetesConfiguration.Tests.Helpers;
    using Microsoft.Azure.Management.KubernetesConfiguration;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport;

    /// <summary>
    /// Base class for tests of SourceControlConfiguration resource type
    /// </summary>
    public class SourceControlConfigurationTestBase : TestBase, IDisposable
    {
        public SourceControlConfigurationClient SourceControlConfigurationClient { get; set; }

        public SourceControlConfiguration SourceControlConfiguration { get; set; }

        public const string ApiVersion = "2019-11-01-preview";
        public const string ConfigurationType = "SourceControlConfiguration";
        public const string OperatorTypeFlux = "Flux";

        public ClusterInfo Cluster { get; set; }

        public SourceControlConfigurationTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            SourceControlConfigurationClient = context.GetServiceClient<SourceControlConfigurationClient>(false, handler);
        }

        /// <summary>
        /// Creates or Updates a SourceControlConfiguration
        /// </summary>
        /// <returns>The SourceControlConfiguration object that was created or updated.</returns>
        public SourceControlConfiguration CreateSourceControlConfiguration()
        {
            return SourceControlConfigurationClient.SourceControlConfigurations.CreateOrUpdate(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                sourceControlConfigurationName: SourceControlConfiguration.Name,
                apiVersion: ApiVersion,
                sourceControlConfiguration: SourceControlConfiguration);
        }

        /// <summary>
        /// Get a SourceControlConfiguration
        /// </summary>
        /// <returns>The SourceControlConfiguration object.</returns>
        public SourceControlConfiguration GetSourceControlConfiguration()
        {
            return SourceControlConfigurationClient.SourceControlConfigurations.Get(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                sourceControlConfigurationName: SourceControlConfiguration.Name,
                apiVersion: ApiVersion);
        }

        /// <summary>
        /// Delete a SourceControlConfiguration
        /// </summary>
        public void DeleteSourceControlConfiguration()
        {
            SourceControlConfigurationClient.SourceControlConfigurations.Delete(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                sourceControlConfigurationName: SourceControlConfiguration.Name,
                apiVersion: ApiVersion);
        }

        /// <summary>
        /// List SourceControlConfigurations in a cluster
        /// </summary>
        /// <returns></returns>
        public IPage<SourceControlConfiguration> ListSourceControlConfigurations()
        {
            return SourceControlConfigurationClient.SourceControlConfigurations.List(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                apiVersion: ApiVersion);
        }

        #region Common Methods

        public void Dispose()
        {
            SourceControlConfigurationClient.Dispose();
        }

        #endregion
    }
}