// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using FluentAssertions;
using IotHub.Tests.Helpers;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EHModel = Microsoft.Azure.Management.EventHub.Models;
using SBModel = Microsoft.Azure.Management.ServiceBus.Models;

namespace IotHub.Tests.ScenarioTests
{
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

                        location = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_LOCATION"))
                            ? IotHubTestUtilities.DefaultLocation
                            : Environment.GetEnvironmentVariable("AZURE_LOCATION").Replace(" ", "").ToLower();

                        initialized = true;
                    }
                }
            }
        }

        protected async Task<string> CreateExternalEhAsync(ResourceGroup resourceGroup, string location)
        {
            string namespaceName = "iothubcsharpsdkehnamespacetest";
            string ehName = "iothubcsharpsdkehtest";
            string authRuleName = "iothubcsharpsdkehtestrule";

            EHModel.NamespaceResource namespaceResource = await ehClient.Namespaces
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    namespaceName,
                    new EHModel.NamespaceCreateOrUpdateParameters
                    {
                        Location = location,
                        Sku = new EHModel.Sku
                        {
                            Name = "Standard",
                            Tier = "Standard",
                        },
                    })
                .ConfigureAwait(false);
            namespaceResource.ProvisioningState.Should().Be("Succeeded");

            _ = await ehClient.EventHubs
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    namespaceName,
                    ehName,
                    new EventHubCreateOrUpdateParameters
                    {
                        Location = location,
                    })
                .ConfigureAwait(false);

            await ehClient.EventHubs
                .CreateOrUpdateAuthorizationRuleAsync(
                    resourceGroup.Name,
                    namespaceName,
                    ehName,
                    authRuleName,
                    new EHModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters
                    {
                        Location = location,
                        Rights = new List<EHModel.AccessRights?>
                        {
                            EHModel.AccessRights.Send,
                            EHModel.AccessRights.Listen,
                        },
                    })
                .ConfigureAwait(false);

            EHModel.ResourceListKeys listKeys = await ehClient.EventHubs
                .ListKeysAsync(resourceGroup.Name, namespaceName, ehName, authRuleName)
                .ConfigureAwait(false);

            return listKeys.PrimaryConnectionString;
        }

        protected async Task<Tuple<string, string>> CreateExternalQueueAndTopicAsync(ResourceGroup resourceGroup, string location)
        {
            string sbNamespaceName = "iotHubCSharpSDKSBNamespaceTest";
            string sbName = "iotHubCSharpSDKSBTest";
            string topicName = "iotHubCSharpSDKTopicTest";
            string authRuleName = "iotHubCSharpSDKSBTopicTestRule";

            SBModel.NamespaceResource namespaceResource = await sbClient.Namespaces
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    sbNamespaceName,
                    new SBModel.NamespaceCreateOrUpdateParameters
                    {
                        Location = location,
                        Sku = new SBModel.Sku
                        {
                            Name = "Standard",
                            Tier = "Standard",
                        },
                    })
                .ConfigureAwait(false);

            namespaceResource.ProvisioningState.Should().Be("Succeeded");
            _ = await sbClient.Queues
                .CreateOrUpdateAsync(resourceGroup.Name, sbNamespaceName, sbName, new QueueCreateOrUpdateParameters { Location = location })
                .ConfigureAwait(false);
            _ = await sbClient.Topics
                .CreateOrUpdateAsync(resourceGroup.Name, sbNamespaceName, topicName, new TopicCreateOrUpdateParameters { Location = location })
                .ConfigureAwait(false);

            await sbClient.Queues
                .CreateOrUpdateAuthorizationRuleAsync(
                    resourceGroup.Name,
                    sbNamespaceName,
                    sbName,
                    authRuleName,
                    new SBModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters
                    {
                        Location = location,
                        Rights = new List<SBModel.AccessRights?>
                        {
                            SBModel.AccessRights.Send,
                            SBModel.AccessRights.Listen,
                        }
                    })
                .ConfigureAwait(false);

            await sbClient.Topics
                .CreateOrUpdateAuthorizationRuleAsync(
                    resourceGroup.Name,
                    sbNamespaceName,
                    topicName,
                    authRuleName,
                    new SBModel.SharedAccessAuthorizationRuleCreateOrUpdateParameters
                    {
                        Location = location,
                        Rights = new List<SBModel.AccessRights?>
                        {
                            SBModel.AccessRights.Send,
                            SBModel.AccessRights.Listen,
                        }
                    })
                .ConfigureAwait(false);

            SBModel.ResourceListKeys sbKeys = await sbClient.Queues
                .ListKeysAsync(resourceGroup.Name, sbNamespaceName, sbName, authRuleName)
                .ConfigureAwait(false);
            SBModel.ResourceListKeys topicKeys = await sbClient.Queues
                .ListKeysAsync(resourceGroup.Name, sbNamespaceName, topicName, authRuleName)
                .ConfigureAwait(false);

            return Tuple.Create(sbKeys.PrimaryConnectionString, topicKeys.PrimaryConnectionString);
        }

        protected Task<IotHubDescription> CreateIotHubAsync(ResourceGroup resourceGroup, string location, string iotHubName, IotHubProperties properties)
        {
            var createIotHubDescription = new IotHubDescription
            {
                Location = location,
                Sku = new IotHubSkuInfo
                {
                    Name = "S1",
                    Capacity = 1,
                },
                Properties = properties,
            };

            return iotHubClient.IotHubResource.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                createIotHubDescription);
        }

        protected Task<IotHubDescription> UpdateIotHubAsync(ResourceGroup resourceGroup, IotHubDescription iotHubDescription, string iotHubName)
        {
            return iotHubClient.IotHubResource.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                iotHubDescription);
        }

        protected Task<ResourceGroup> CreateResourceGroupAsync(string resourceGroupName)
        {
            return resourcesClient.ResourceGroups.CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = IotHubTestUtilities.DefaultLocation
                });
        }

        protected Task DeleteResourceGroupAsync(string resourceGroupName)
        {
            return resourcesClient.ResourceGroups.DeleteAsync(resourceGroupName);
        }

        protected Task<CertificateDescription> CreateCertificateAsync(
            ResourceGroup resourceGroup,
            string iotHubName,
            string certificateName)
        {
            return iotHubClient.Certificates.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                certificateName,
                null,
                IotHubTestUtilities.DefaultIotHubCertificateContent);
        }

        protected Task<CertificateListDescription> GetCertificatesAsync(ResourceGroup resourceGroup, string iotHubName)
        {
            return iotHubClient.Certificates.ListByIotHubAsync(resourceGroup.Name, iotHubName);
        }

        protected Task<CertificateDescription> GetCertificateAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName)
        {
            return iotHubClient.Certificates.GetAsync(resourceGroup.Name, iotHubName, certificateName);
        }

        protected Task<CertificateWithNonceDescription> GenerateVerificationCodeAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName, string etag)
        {
            return iotHubClient.Certificates.GenerateVerificationCodeAsync(resourceGroup.Name, iotHubName, certificateName, etag);
        }

        protected Task DeleteCertificateAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName, string Etag)
        {
            return iotHubClient.Certificates.DeleteAsync(resourceGroup.Name, iotHubName, certificateName, Etag);
        }
    }
}

