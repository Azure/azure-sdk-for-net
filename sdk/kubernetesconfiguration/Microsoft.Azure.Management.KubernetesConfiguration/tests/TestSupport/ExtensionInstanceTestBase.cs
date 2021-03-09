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
    public class ExtensionTestBase : TestBase, IDisposable
    {
        public SourceControlConfigurationClient SourceControlConfigurationClient { get; set; }

        public ExtensionInstance ExtensionInstance { get; set; }

        public const string ApiVersion = "2020-07-01-preview";
        public const string ConfigurationType = "Extensions";

        public ClusterInfo Cluster { get; set; }

        public ExtensionTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            SourceControlConfigurationClient = context.GetServiceClient<SourceControlConfigurationClient>(false, handler);
        }

        /// <summary>
        /// Creates an ExtensionInstance
        /// </summary>
        /// <returns>The ExtensionInstance object that was created.</returns>
        public ExtensionInstance CreateExtensionInstance()
        {
            return SourceControlConfigurationClient.Extensions.Create(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionInstanceName: ExtensionInstance.Name,
                extensionInstance: ExtensionInstance
            );
        }

        /// <summary>
        /// Get an ExtensionInstance
        /// </summary>
        /// <returns>The ExtensionInstance object.</returns>
        public ExtensionInstance GetExtensionInstance()
        {
            return SourceControlConfigurationClient.Extensions.Get(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionInstanceName: ExtensionInstance.Name
            );
        }

        /// <summary>
        /// Delete an ExtensionInstance
        /// </summary>
        public void DeleteExtensionInstance()
        {
            SourceControlConfigurationClient.Extensions.Delete(
                resourceGroupName: Cluster.ResourceGroup,
                clusterRp: Cluster.RpName,
                clusterResourceName: Cluster.Type,
                clusterName: Cluster.Name,
                extensionInstanceName: ExtensionInstance.Name
            );
        }

        /// <summary>
        /// List ExtensionInstances in a cluster
        /// </summary>
        /// <returns></returns>
        public IPage<ExtensionInstance> ListExtensionInstances()
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