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
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void EventHubskiptop()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

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
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Create a EventHub
                    var eventhubName = TestUtilities.GenerateName(EventHubManagementHelper.EventHubPrefix);

                    for (int ehCount = 0; ehCount < 10; ehCount++)
                    {
                        var eventhubNameLoop = eventhubName + "_" + ehCount.ToString();
                        var createEventHubResponseForLoop = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubNameLoop, new Eventhub());

                        Assert.NotNull(createEventHubResponseForLoop);
                        Assert.Equal(createEventHubResponseForLoop.Name, eventhubNameLoop);
                    }

                    var createEventHubResponseList = this.EventHubManagementClient.EventHubs.ListByNamespace(resourceGroup, namespaceName);

                    Assert.Equal(10, createEventHubResponseList.Count<Eventhub>());

                    var gettop10EventHub = this.EventHubManagementClient.EventHubs.ListByNamespace(resourceGroup, namespaceName, skip: 5, top: 5);

                    Assert.Equal(5, gettop10EventHub.Count<Eventhub>());

                    // Create a ConsumerGroup
                    var consumergroupName = TestUtilities.GenerateName(EventHubManagementHelper.ConsumerGroupPrefix);

                    for (int consumergroupCount = 0; consumergroupCount < 10; consumergroupCount++)
                    {
                        var consumergroupNameLoop = consumergroupName + "_" + consumergroupCount.ToString();
                        var createConsumerGroupResponseForLoop = this.EventHubManagementClient.ConsumerGroups.CreateOrUpdate(resourceGroup, namespaceName, createEventHubResponseList.ElementAt<Eventhub>(0).Name, consumergroupNameLoop, new ConsumerGroup());

                        Assert.NotNull(createConsumerGroupResponseForLoop);
                        Assert.Equal(createConsumerGroupResponseForLoop.Name, consumergroupNameLoop);
                    }

                    var createConsumerGroupResponseList = this.EventHubManagementClient.ConsumerGroups.ListByEventHub(resourceGroup, namespaceName, createEventHubResponseList.ElementAt<Eventhub>(0).Name);

                    Assert.Equal(11, createConsumerGroupResponseList.Count<ConsumerGroup>());

                    var gettop10ConsumerGroup = this.EventHubManagementClient.ConsumerGroups.ListByEventHub(resourceGroup, namespaceName, createEventHubResponseList.ElementAt<Eventhub>(0).Name, skip: 5, top: 4);

                    Assert.Equal(4, gettop10ConsumerGroup.Count<ConsumerGroup>());


                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Delete namespace and check for the NotFound exception
                    EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }
            }
        }
    }
}
