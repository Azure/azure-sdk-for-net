// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void ApplicationGroupCreateUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "South Central US";
                this.ResourceManagementClient.GetLocationFromProvider();
                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                try
                {
                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                       new EHNamespace()
                       {
                           Location = location,
                           Sku = new Sku
                           {
                               Name = SkuName.Premium,
                               Tier = SkuTier.Premium,
                               Capacity = 1
                           },
                           Tags = new Dictionary<string, string>()
                           {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                           }
                       });

                    string appGroupName = TestUtilities.GenerateName(EventHubManagementHelper.ApplicationGroupPrefix);
                    string SASKey = TestUtilities.GenerateName(EventHubManagementHelper.SASKeyPrefix);
                    string ClientAppGroupIdentifier = "SASKeyName=" + SASKey;

                    List<ApplicationGroupPolicy> appPolicyList = new List<ApplicationGroupPolicy>();

                    ThrottlingPolicy tp = new ThrottlingPolicy();
                    tp.Name = "ThrottlingPolicy1";
                    tp.RateLimitThreshold = 3951729;
                    tp.MetricId = "IncomingBytes";

                    appPolicyList.Add(tp);

                    ThrottlingPolicy tp1 = new ThrottlingPolicy();
                    tp1.Name = "ThrottlingPolicy2";
                    tp1.RateLimitThreshold = 79123;
                    tp1.MetricId = "IncomingMessages";

                    appPolicyList.Add(tp1);

                    ApplicationGroup appGroup = new ApplicationGroup()
                    {
                        ClientAppGroupIdentifier = ClientAppGroupIdentifier,
                        Policies = appPolicyList,
                        IsEnabled = true
                    };

                    var appGroupResult = this.EventHubManagementClient.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroup, namespaceName, appGroupName, appGroup);

                    Assert.NotNull(appGroupResult);
                    Assert.True(appGroupResult.IsEnabled);
                    Assert.Equal(2, appGroupResult.Policies.Count);

                    List<ThrottlingPolicy> policies = new List<ThrottlingPolicy>();

                    foreach (var x in appGroupResult.Policies)
                    {
                        policies.Add(x as ThrottlingPolicy);
                    }

                    Assert.Equal("ThrottlingPolicy1", policies[0].Name);
                    Assert.Equal(3951729, policies[0].RateLimitThreshold);
                    Assert.Equal("IncomingBytes", policies[0].MetricId);

                    Assert.Equal("ThrottlingPolicy2", policies[1].Name);
                    Assert.Equal(79123, policies[1].RateLimitThreshold);
                    Assert.Equal("IncomingMessages", policies[1].MetricId);

                    appGroupResult.IsEnabled = false;

                    appGroupResult = this.EventHubManagementClient.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroup, namespaceName, appGroupName, appGroupResult);

                    Assert.NotNull(appGroupResult);
                    Assert.False(appGroupResult.IsEnabled);
                    Assert.Equal(2, appGroupResult.Policies.Count);

                    appGroupResult.IsEnabled = true;

                    appGroupResult = this.EventHubManagementClient.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroup, namespaceName, appGroupName, appGroupResult);

                    Assert.NotNull(appGroupResult);
                    Assert.True(appGroupResult.IsEnabled);
                    Assert.Equal(2, appGroupResult.Policies.Count);

                    policies = new List<ThrottlingPolicy>();

                    foreach (var x in appGroupResult.Policies)
                    {
                        policies.Add(x as ThrottlingPolicy);
                    }

                    Assert.Equal("ThrottlingPolicy1", policies[0].Name);
                    Assert.Equal(3951729, policies[0].RateLimitThreshold);
                    Assert.Equal("IncomingBytes", policies[0].MetricId);

                    Assert.Equal("ThrottlingPolicy2", policies[1].Name);
                    Assert.Equal(79123, policies[1].RateLimitThreshold);
                    Assert.Equal("IncomingMessages", policies[1].MetricId);

                    appGroupResult = this.EventHubManagementClient.ApplicationGroup.Get(resourceGroup, namespaceName, appGroupName);
                    Assert.NotNull(appGroupResult);
                    Assert.True(appGroupResult.IsEnabled);

                    ThrottlingPolicy tp2 = new ThrottlingPolicy();
                    tp2.Name = "ThrottlingPolicy3";
                    tp2.RateLimitThreshold = 3951729;
                    tp2.MetricId = "OutgoingBytes";

                    appGroupResult.Policies.Add(tp2);

                    ThrottlingPolicy tp3 = new ThrottlingPolicy();
                    tp3.Name = "ThrottlingPolicy4";
                    tp3.RateLimitThreshold = 79123;
                    tp3.MetricId = "OutgoingMessages";

                    appGroupResult.Policies.Add(tp3);

                    appGroupResult = this.EventHubManagementClient.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroup, namespaceName, appGroupName, appGroupResult);

                    policies = new List<ThrottlingPolicy>();

                    foreach (var x in appGroupResult.Policies)
                    {
                        policies.Add(x as ThrottlingPolicy);
                    }

                    Assert.Equal("ThrottlingPolicy1", policies[0].Name);
                    Assert.Equal(3951729, policies[0].RateLimitThreshold);
                    Assert.Equal("IncomingBytes", policies[0].MetricId);

                    Assert.Equal("ThrottlingPolicy2", policies[1].Name);
                    Assert.Equal(79123, policies[1].RateLimitThreshold);
                    Assert.Equal("IncomingMessages", policies[1].MetricId);

                    Assert.Equal("ThrottlingPolicy3", policies[2].Name);
                    Assert.Equal(3951729, policies[2].RateLimitThreshold);
                    Assert.Equal("OutgoingBytes", policies[2].MetricId);

                    Assert.Equal("ThrottlingPolicy4", policies[3].Name);
                    Assert.Equal(79123, policies[3].RateLimitThreshold);
                    Assert.Equal("OutgoingMessages", policies[3].MetricId);

                    Assert.NotNull(appGroupResult);
                    Assert.True(appGroupResult.IsEnabled);
                    Assert.Equal(4, appGroupResult.Policies.Count);

                    var listOfApplicationGroups = this.EventHubManagementClient.ApplicationGroup.ListByNamespace(resourceGroup, namespaceName).ToList();
                    Assert.NotEmpty(listOfApplicationGroups);

                    this.EventHubManagementClient.ApplicationGroup.Delete(resourceGroup, namespaceName, appGroupName);
                    Assert.Throws<ErrorResponseException>(() => this.EventHubManagementClient.ApplicationGroup.Get(resourceGroup, namespaceName, appGroupName));
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, default(CancellationToken)).ConfigureAwait(false);

                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Application Groups test");
                }
                

            }
        }
    }
}

