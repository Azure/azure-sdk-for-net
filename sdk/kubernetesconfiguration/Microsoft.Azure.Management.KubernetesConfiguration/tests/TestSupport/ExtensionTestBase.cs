// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport
{
    using System;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.Helpers;
    using Microsoft.Azure.Management.KubernetesConfiguration;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;

    /// <summary>
    /// Base class for tests of SourceControlConfiguration resource type
    /// </summary>
    public class ExtensionTestBase : TestBase, IDisposable
    {
        public SourceControlConfigurationClient SourceControlConfigurationClient { get; set; }

        public Extension Extension { get; set; }

        public const string ApiVersion = "2022-03-01";
        public const string ConfigurationType = "Extensions";

        public ClusterInfo Cluster { get; set; }

        public ExtensionTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            SourceControlConfigurationClient = context.GetServiceClient<SourceControlConfigurationClient>(false, handler);
        }

        /// <summary>
        /// Creates an Extension
        /// </summary>
        /// <returns>The Extension object that was created.</returns>
        public Extension CreateExtension()
        {
            return SourceControlConfigurationClient.Extensions.BeginCreate(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionName: Extension.Name,
                extension: Extension
            );
        }

        /// <summary>
        /// Get an Extension
        /// </summary>
        /// <returns>The Extension object.</returns>
        public Extension GetExtension()
        {
            return SourceControlConfigurationClient.Extensions.Get(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionName: Extension.Name
            );
        }

        /// <summary>
        /// Delete an Extension
        /// </summary>
        public void DeleteExtension(bool force = true)
        {
            SourceControlConfigurationClient.Extensions.BeginDelete(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionName: Extension.Name,
                forceDelete: force
            );
        }

        /// <summary>
        /// List Extensions in a cluster
        /// </summary>
        /// <returns></returns>
        public IPage<Extension> ListExtensions()
        {
            return SourceControlConfigurationClient.Extensions.List(
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