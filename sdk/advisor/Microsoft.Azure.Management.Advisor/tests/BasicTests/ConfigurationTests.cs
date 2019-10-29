// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Advisor;
using Microsoft.Azure.Management.Advisor.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Advisor.Tests.BasicTests
{
    public class ConfigurationTests
    {
        const string ResourceGroupName = "DefaultResourceGroup-EUS";
        const string DefaultThreshold = "5";
        const string TestThreshold = "20";

        [Fact]
        public void ConfigureSubscriptionTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var config = new ConfigData
                {
                    Properties = new ConfigDataProperties {Exclude = false, LowCpuThreshold = TestThreshold }
                };

                using (var client = context.GetServiceClient<AdvisorManagementClient>())
                {
                    client.Configurations.CreateInSubscription(config);
                    var data = client.Configurations.ListBySubscription();
                    Assert.Equal(TestThreshold, data.First().Properties.LowCpuThreshold);
                    Assert.False(data.First().Properties.Exclude);

                    config.Properties.LowCpuThreshold = DefaultThreshold;
                    client.Configurations.CreateInSubscription(config);
                    data = client.Configurations.ListBySubscription();
                    Assert.Equal(DefaultThreshold, data.First().Properties.LowCpuThreshold);
                    Assert.False(data.First().Properties.Exclude);
                }
            }
        }

        [Fact]
        public void ConfigureResourceGroupTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var config = new ConfigData {Properties = new ConfigDataProperties {Exclude = true}};

                using (var client = context.GetServiceClient<AdvisorManagementClient>())
                {
                    client.Configurations.CreateInResourceGroup(config, ResourceGroupName);
                    var data = client.Configurations.ListByResourceGroup(ResourceGroupName);
                    Assert.True(data.First().Properties.Exclude);

                    config.Properties.Exclude = false;
                    client.Configurations.CreateInResourceGroup(config, ResourceGroupName);
                    data = client.Configurations.ListByResourceGroup(ResourceGroupName);
                    Assert.False(data.First().Properties.Exclude);
                }
            }
        }
    }
}