// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace KubernetesConfiguration.Tests.ScenarioTests
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;
    using KubernetesConfiguration.Tests.TestSupport;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport;

    public class ExtensionInstanceTest
    {
        [Fact]
        public void CanCreateUpdateDeleteExtensionInstanceWithoutIdentity()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "nanthicluster0923",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "nanthirg0923"
            );

            ExtensionInstance extensionInstance = new ExtensionInstance(
                name: "openservicemesh",
                type: ExtensionTestBase.ConfigurationType,
                extensionType: "microsoft.openservicemesh",
                autoUpgradeMinorVersion: false,
                releaseTrain: "staging",
                version: "0.1.0",
                scope: new Scope(
                    cluster: new ScopeCluster(
                        releaseNamespace: "arc-osm-system"
                    )
                )
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ExtensionTestBase(context))
                {
                     
                    testFixture.Cluster = cluster;
                    testFixture.ExtensionInstance = extensionInstance;

                    // List configurations and get count
                    var extensions = testFixture.ListExtensionInstances();
                    int extensionCount = extensions.Count();

                    // Create a configuration
                    var newExtension = testFixture.CreateExtensionInstance();
                    Assert.NotNull(newExtension);

                    // Get the configuration and verify
                    var ext = testFixture.GetExtensionInstance();
                    Assert.Equal(extensionInstance.Name, ext.Name);
                    Assert.True((ext.InstallState.ToString() == "Pending") || (ext.InstallState.ToString() == "Installed"));

                    // List configurations and get count to confirm it is up by one
                    extensions = testFixture.ListExtensionInstances();
                    Assert.True(extensions.Count() == extensionCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteExtensionInstance();

                    // List configurations and get count to confirm it is what we started with
                    extensions = testFixture.ListExtensionInstances();
                    Assert.True(extensions.Count() == extensionCount);
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteExtensionInstanceWithIdentity()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "nanthicluster0923",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "nanthirg0923"
            );

            ExtensionInstance extensionInstance = new ExtensionInstance(
                name: "microsoft.azuredefender.kubernetes",
                type: ExtensionTestBase.ConfigurationType,
                location: "eastus2euap",
                extensionType: "microsoft.azuredefender.kubernetes",
                autoUpgradeMinorVersion: false,
                releaseTrain: "Stable",
                version: "0.4.61",
                scope: new Scope(
                    cluster: new ScopeCluster(
                        releaseNamespace: "azuredefender"
                    )
                ),
                identity: new ConfigurationIdentity(
                    type: ResourceIdentityType.SystemAssigned
                )
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new ExtensionTestBase(context))
                {
                     
                    testFixture.Cluster = cluster;
                    testFixture.ExtensionInstance = extensionInstance;

                    // List configurations and get count
                    var extensions = testFixture.ListExtensionInstances();
                    int extensionCount = extensions.Count();

                    // Create a configuration
                    var newExtension = testFixture.CreateExtensionInstance();
                    Assert.NotNull(newExtension);

                    // Get the configuration and verify
                    var ext = testFixture.GetExtensionInstance();
                    Assert.Equal(extensionInstance.Name, ext.Name);
                    Assert.True((ext.InstallState.ToString() == "Pending") || (ext.InstallState.ToString() == "Installed"));

                    // List configurations and get count to confirm it is up by one
                    extensions = testFixture.ListExtensionInstances();
                    Assert.True(extensions.Count() == extensionCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteExtensionInstance();

                    // List configurations and get count to confirm it is what we started with
                    extensions = testFixture.ListExtensionInstances();
                    Assert.True(extensions.Count() == extensionCount);
                }
            }
        }
    }
}


