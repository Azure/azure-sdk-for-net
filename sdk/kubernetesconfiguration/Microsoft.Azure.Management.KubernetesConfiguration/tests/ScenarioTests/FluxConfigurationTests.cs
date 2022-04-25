// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KubernetesConfiguration.Tests.ScenarioTests
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.KubernetesConfiguration.Models;
    using Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport;
    using Microsoft.Azure.Management.KubernetesConfiguration.Extensions.Models;

    public class FluxConfigurationTest : IClassFixture<FluxExtensionSetupFixture>
    {
        [Fact]
        public void CanCreateUpdateDeleteFluxConfiguration()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "arc-cluster",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "dotnet-sdk-tests"
            );

            FluxConfiguration configuration = new FluxConfiguration(
                name: "netsdktestconfig01a",
                type: FluxConfigurationTestBase.ConfigurationType,
                scope: "cluster",
                namespaceProperty: "default",
                sourceKind: "GitRepository",
                gitRepository: new GitRepositoryDefinition(
                    url: "https://github.com/Azure/arc-k8s-demo.git",
                    repositoryRef: new RepositoryRefDefinition(branch: "master")),
                kustomizations: new Dictionary<string, KustomizationDefinition>
                {
                        {
                            "mykustomization-1",
                            new KustomizationDefinition(path: "", timeoutInSeconds: 600, syncIntervalInSeconds: 600, prune: true)
                        },
                }
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new FluxConfigurationTestBase(context))
                {
                    testFixture.Cluster = cluster;
                    testFixture.FluxConfiguration = configuration;

                    // List configurations and get count
                    var configurations = testFixture.ListFluxConfigurations();
                    int configCount = configurations.Count();

                    // Create a configuration
                    var newConfig = testFixture.CreateFluxConfiguration();
                    Assert.NotNull(newConfig);

                    // Get the configuration and verify
                    var config = testFixture.GetFluxConfiguration();
                    Assert.Equal(configuration.Name, config.Name);
                    Assert.True((config.ProvisioningState.ToString() == "Creating") || (config.ProvisioningState.ToString() == "Succeeded"));

                    // List configurations and get count to confirm it is up by one
                    configurations = testFixture.ListFluxConfigurations();
                    Assert.True(configurations.Count() == configCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteFluxConfiguration();

                    // List configurations and get count to confirm it is what we started with
                    configurations = testFixture.ListFluxConfigurations();
                    Assert.True(configurations.Count() == configCount);
                }
            }
        }
    }
}


