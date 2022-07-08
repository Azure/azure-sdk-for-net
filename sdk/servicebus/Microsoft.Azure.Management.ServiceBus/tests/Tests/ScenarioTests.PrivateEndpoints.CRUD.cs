// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Management.Network;
    using PrivateLinkClient = Microsoft.Azure.Management.Network;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using System.Threading;

    public partial class ScenarioTests
    {
        [Fact]
        public void PrivateEndpointsCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }


                //Create a namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                try
                {
                    var createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                        new SBNamespace()
                        {
                            Location = location,
                            Sku = new SBSku
                            {
                                Name = SkuName.Premium,
                                Tier = SkuTier.Premium
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

                    var connectionName = TestUtilities.GenerateName(ServiceBusManagementHelper.PrivateLinkConnectionPrefix);
                    var privateEndpointName = TestUtilities.GenerateName(ServiceBusManagementHelper.PrivateEndpointPrefix);

                    PrivateLinkClient.Models.PrivateLinkServiceConnection privateEndpointConnection = new PrivateLinkClient.Models.PrivateLinkServiceConnection() { 
                        Name = connectionName,
                        PrivateLinkServiceId = createNamespaceResponse.Id,
                        GroupIds = new List<String>() { "namespace" }
                    };

                    PrivateLinkClient.Models.PrivateEndpoint privateEndpoint = new PrivateLinkClient.Models.PrivateEndpoint()
                    {
                        Location = "WestUS",
                        Subnet = new PrivateLinkClient.Models.Subnet() { Id = @"/subscriptions/" + ServiceBusManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/testsub" },
                        ManualPrivateLinkServiceConnections = new List<PrivateLinkClient.Models.PrivateLinkServiceConnection>() { privateEndpointConnection }
                    };

                    var privateEndpointResult = NetworkManagementClient.PrivateEndpoints.CreateOrUpdate(resourceGroup, privateEndpointName, privateEndpoint);

                    //TestUtilities.Wait(40000);

                    var listOfPrivateLinks = ServiceBusManagementClient.PrivateLinkResources.Get(resourceGroup, namespaceName);

                    Assert.NotNull(listOfPrivateLinks);

                    var privateEndpointForNamespace1 = ServiceBusManagementClient.PrivateEndpointConnections.List(resourceGroup, namespaceName);

                    var requiredName = "";

                    foreach(PrivateEndpointConnection x in privateEndpointForNamespace1)
                    {
                        requiredName = x.Name;
                    }

                    var privateEndpointForNamespace = ServiceBusManagementClient.PrivateEndpointConnections.Get(resourceGroup, namespaceName, requiredName);

                    Assert.Equal("pending", privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status.ToLower());
                    Assert.Equal(requiredName, privateEndpointForNamespace.Name);


                    privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status = "Approved";

                    privateEndpointForNamespace = ServiceBusManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroup, namespaceName, requiredName,
                        privateEndpointForNamespace);

                    Assert.Equal("approved", privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status.ToLower());
                    Assert.Equal(requiredName, privateEndpointForNamespace.Name);

                    for (int i=0; i<100; i++)
                    {
                        privateEndpointForNamespace = ServiceBusManagementClient.PrivateEndpointConnections.Get(resourceGroup, namespaceName, requiredName);
                        if (privateEndpointForNamespace.ProvisioningState == "Succeeded")
                            break;

                        TestUtilities.Wait(10000);
                    }

                    privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status = "Rejected";

                    privateEndpointForNamespace = ServiceBusManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroup, namespaceName, requiredName,
                        privateEndpointForNamespace);

                    Assert.Equal("rejected", privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status.ToLower());
                    Assert.Equal(requiredName, privateEndpointForNamespace.Name);

                    for (int i = 0; i < 100; i++)
                    {
                        privateEndpointForNamespace = ServiceBusManagementClient.PrivateEndpointConnections.Get(resourceGroup, namespaceName, requiredName);
                        if (privateEndpointForNamespace.ProvisioningState == "Succeeded")
                            break;

                        TestUtilities.Wait(10000);
                    }

                    privateEndpointForNamespace.PrivateLinkServiceConnectionState.Status = "Disconnected";

                    Assert.Throws<ErrorResponseException>(() => ServiceBusManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroup, namespaceName, requiredName,
                        privateEndpointForNamespace));

                    ServiceBusManagementClient.PrivateEndpointConnections.Delete(resourceGroup, namespaceName, requiredName);

                    TestUtilities.Wait(60000);

                    Assert.Throws<ErrorResponseException>(() => ServiceBusManagementClient.PrivateEndpointConnections.Get(resourceGroup, namespaceName, requiredName));

                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Private Endpoints test");
                }


            }
        }
    }
}