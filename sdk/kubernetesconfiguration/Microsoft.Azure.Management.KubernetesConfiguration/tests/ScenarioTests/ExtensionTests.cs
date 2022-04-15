// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KubernetesConfiguration.Tests.ScenarioTests
{
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport;

    public class ExtensionInstanceTest
    {
        [Fact]
        public void CanCreateUpdateDeleteExtensionInstanceWithoutIdentity()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "arc-cluster",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "dotnet-sdk-tests"
            );

            Extension extensionInstance = new Extension(
                name: "dapr",
                type: ExtensionTestBase.ConfigurationType,
                extensionType: "microsoft.dapr",
                autoUpgradeMinorVersion: false,
                releaseTrain: "stable",
                version: "1.6.0",
                scope: new Scope(
                    cluster: new ScopeCluster(
                        releaseNamespace: "dapr-system"
                    )
                )
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ExtensionTestBase(context))
                {
                     
                    testFixture.Cluster = cluster;
                    testFixture.Extension = extensionInstance;

                    // List configurations and get count
                    var extensions = testFixture.ListExtensions();
                    int extensionCount = extensions.Count();

                    // Create a configuration
                    var newExtension = testFixture.CreateExtension();
                    Assert.NotNull(newExtension);

                    // Get the configuration and verify
                    var ext = testFixture.GetExtension();
                    Assert.Equal(extensionInstance.Name, ext.Name);
                    Assert.True((ext.ProvisioningState.ToString() == "Creating") || (ext.ProvisioningState.ToString() == "Succeeded"));

                    // List configurations and get count to confirm it is up by one
                    extensions = testFixture.ListExtensions();
                    Assert.True(extensions.Count() == extensionCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteExtension();

                    // List configurations and get count to confirm it is what we started with
                    extensions = testFixture.ListExtensions();
                    Assert.True(extensions.Count() == extensionCount);
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteExtensionInstanceWithIdentity()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "arc-cluster",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "dotnet-sdk-tests"
            );

            Extension extensionInstance = new Extension(
                name: "openservicemesh",
                type: ExtensionTestBase.ConfigurationType,
                extensionType: "microsoft.openservicemesh",
                autoUpgradeMinorVersion: false,
                releaseTrain: "pilot",
                version: "1.0.0",
                scope: new Scope(
                    cluster: new ScopeCluster(
                        releaseNamespace: "servicemesh-system"
                    )
                ),
                identity: new Identity(
                    type: ResourceIdentityType.SystemAssigned
                )
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ExtensionTestBase(context))
                {
                     
                    testFixture.Cluster = cluster;
                    testFixture.Extension = extensionInstance;

                    // List configurations and get count
                    var extensions = testFixture.ListExtensions();
                    int extensionCount = extensions.Count();

                    // Create a configuration
                    var newExtension = testFixture.CreateExtension();
                    Assert.NotNull(newExtension);

                    // Get the configuration and verify
                    var ext = testFixture.GetExtension();
                    Assert.Equal(extensionInstance.Name, ext.Name);
                    Assert.True((ext.ProvisioningState.ToString() == "Creating") || (ext.ProvisioningState.ToString() == "Succeeded"));

                    // List configurations and get count to confirm it is up by one
                    extensions = testFixture.ListExtensions();
                    Assert.True(extensions.Count() == extensionCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteExtension();

                    // List configurations and get count to confirm it is what we started with
                    extensions = testFixture.ListExtensions();
                    Assert.True(extensions.Count() == extensionCount);
                }
            }
        }
    }
}


