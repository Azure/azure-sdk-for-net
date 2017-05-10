﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace IotHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using IotHub.Tests.Helpers;

    using Xunit;
    using EHModel = Microsoft.Azure.Management.EventHub.Models;
    using SBModel = Microsoft.Azure.Management.ServiceBus.Models;

    public class IotHubTestBase
    {
        protected ResourceManagementClient resourcesClient;
        protected IotHubClient iotHubClient;
        protected EventHubManagementClient ehClient;
        protected ServiceBusManagementClient sbClient;

        protected bool initialized = false;
        protected object locker = new object();
        protected string location;
        protected TestEnvironment testEnv;

        protected void Initialize(MockContext context)
        {
            if (!initialized)
            {
                lock (locker)
                {
                    if (!initialized)
                    {
                        testEnv = TestEnvironmentFactory.GetTestEnvironment();
                        resourcesClient = IotHubTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        iotHubClient = IotHubTestUtilities.GetIotHubClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        ehClient = IotHubTestUtilities.GetEhClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        sbClient = IotHubTestUtilities.GetSbClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION")))
                        {
                            location = IotHubTestUtilities.DefaultLocation;
                        }
                        else
                        {
                            location = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION").Replace(" ", "").ToLower();
                        }

                        this.initialized = true;
                    }
                }
            }
        }

        protected string CreateExternalEH(ResourceGroup resourceGroup, string location)
        {
            var namespaceName = "iothubcsharpsdkehnamespacetest";
            var ehName = "iothubcsharpsdkehtest";
            var authRuleName = "iothubcsharpsdkehtestrule";

            var namespaceResource = ehClient.Namespaces.CreateOrUpdate(resourceGroup.Name, namespaceName, new EHModel.NamespaceCreateOrUpdateParameters()
            {
                Location = location,
                Sku = new EHModel.Sku()
                {
                    Name = "Standard",
                    Tier = "Standard"
                }
            });

            Assert.Equal(namespaceResource.ProvisioningState, "Succeeded");

            var ehResource = ehClient.EventHubs.CreateOrUpdate(resourceGroup.Name, namespaceName, ehName, new EventHubCreateOrUpdateParameters()
            {
                Location = location
            });

            ehClient.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroup.Name,
                namespaceName,
                ehName,
                authRuleName,
                new EHModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Location = location,
                    Rights = new List<EHModel.AccessRights?>()
                {
                    EHModel.AccessRights.Send,
                    EHModel.AccessRights.Listen
                }
                });

            return ehClient.EventHubs.ListKeys(resourceGroup.Name, namespaceName, ehName, authRuleName).PrimaryConnectionString;
        }

        protected Tuple<string, string> CreateExternalQueueAndTopic(ResourceGroup resourceGroup, string location)
        {
            string sbNamespaceName = "iotHubCSharpSDKSBNamespaceTest";
            var sbName = "iotHubCSharpSDKSBTest";
            var topicName = "iotHubCSharpSDKTopicTest";
            var authRuleName = "iotHubCSharpSDKSBTopicTestRule";

            var namespaceResource = sbClient.Namespaces.CreateOrUpdate(
                resourceGroup.Name,
                sbNamespaceName,
                new SBModel.NamespaceCreateOrUpdateParameters()
                {
                    Location = location,
                    Sku = new SBModel.Sku()
                    {
                        Name = "Standard",
                        Tier = "Standard"
                    }
                });

            Assert.Equal(namespaceResource.ProvisioningState, "Succeeded");

            var sbResource = sbClient.Queues.CreateOrUpdate(resourceGroup.Name, sbNamespaceName, sbName, new QueueCreateOrUpdateParameters()
            {
                Location = location
            });
            var topicResource = sbClient.Topics.CreateOrUpdate(resourceGroup.Name, sbNamespaceName, topicName, new TopicCreateOrUpdateParameters()
            {
                Location = location
            });

            sbClient.Queues.CreateOrUpdateAuthorizationRule(resourceGroup.Name, sbNamespaceName, sbName, authRuleName, new SBModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Location = location,
                Rights = new List<SBModel.AccessRights?>()
                {
                    SBModel.AccessRights.Send,
                    SBModel.AccessRights.Listen
                }
            });

            sbClient.Topics.CreateOrUpdateAuthorizationRule(resourceGroup.Name, sbNamespaceName, topicName, authRuleName, new SBModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Location = location,
                Rights = new List<SBModel.AccessRights?>()
                {
                    SBModel.AccessRights.Send,
                    SBModel.AccessRights.Listen
                }
            });

            var sbConnectionString = sbClient.Queues.ListKeys(resourceGroup.Name, sbNamespaceName, sbName, authRuleName).PrimaryConnectionString;
            var topicConnectionString = sbClient.Queues.ListKeys(resourceGroup.Name, sbNamespaceName, topicName, authRuleName).PrimaryConnectionString;

            return Tuple.Create(sbConnectionString, topicConnectionString);
        }

        protected IotHubDescription CreateIotHub(ResourceGroup resourceGroup, string location, string iotHubName, IotHubProperties properties)
        {
            var createIotHubDescription = new IotHubDescription()
            {
                Location = location,
                Subscriptionid = testEnv.SubscriptionId,
                Resourcegroup = resourceGroup.Name,
                Sku = new IotHubSkuInfo()
                {
                    Name = "S1",
                    Capacity = 1
                },
                Properties = properties

            };

            return this.iotHubClient.IotHubResource.CreateOrUpdate(
                resourceGroup.Name,
                iotHubName,
                createIotHubDescription);
        }



        protected IotHubDescription UpdateIotHub(ResourceGroup resourceGroup, IotHubDescription iotHubDescription, string iotHubName)
        {
            return this.iotHubClient.IotHubResource.CreateOrUpdate(
                resourceGroup.Name,
                iotHubName,
                iotHubDescription);
        }

        protected ResourceGroup CreateResourceGroup(string resourceGroupName)
        {
            return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = IotHubTestUtilities.DefaultLocation
                });
        }
    }
}
