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

    public class SourceControlConfigurationTest
    {
        [Fact]
        public void CanCreateUpdateDeleteSourceControlConfiguration()
        {
            ClusterInfo cluster = new ClusterInfo(
                name: "arc-cluster",
                type: ClusterInfo.ClusterType.connectedClusters,
                location: "eastus2euap",
                resourceGroup: "dotnet-sdk-tests"
            );

            SourceControlConfiguration configuration = new SourceControlConfiguration(
                name: "netsdktestconfig01a",
                type: SourceControlConfigurationTestBase.ConfigurationType,
                repositoryUrl: "git://github.com/anubhav929/flux-get-started",
                operatorNamespace: "netsdktestconfig01a-opns",
                operatorInstanceName: "netsdktestconfig01a-opin",
                operatorParams: "--git-readonly",
                operatorScope: "namespace",
                enableHelmOperator: true,
                helmOperatorProperties: new HelmOperatorProperties(
                    chartVersion: "1.2.0",
                    chartValues: "--set helm.versions=v3"
                ),
                configurationProtectedSettings: new Dictionary<string, string>(){
                    {"dummyArg", "ZHVtbXlQYXJhbQ=="}
                }
            );

            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new SourceControlConfigurationTestBase(context))
                {
                    testFixture.Cluster = cluster;
                    testFixture.SourceControlConfiguration = configuration;

                    // List configurations and get count
                    var configurations = testFixture.ListSourceControlConfigurations();
                    int configCount = configurations.Count();

                    // Create a configuration
                    var newConfig = testFixture.CreateSourceControlConfiguration();
                    Assert.NotNull(newConfig);

                    // Get the configuration and verify
                    var config = testFixture.GetSourceControlConfiguration();
                    Assert.Equal(configuration.Name, config.Name);
                    Assert.True((config.ComplianceStatus.ComplianceState.ToString() == "Pending") || (config.ComplianceStatus.ComplianceState.ToString() == "Installed"));

                    // List configurations and get count to confirm it is up by one
                    configurations = testFixture.ListSourceControlConfigurations();
                    Assert.True(configurations.Count() == configCount + 1);

                    // Delete the configuration created
                    testFixture.DeleteSourceControlConfiguration();

                    // List configurations and get count to confirm it is what we started with
                    configurations = testFixture.ListSourceControlConfigurations();
                    Assert.True(configurations.Count() == configCount);
                }
            }
        }
    }
}


