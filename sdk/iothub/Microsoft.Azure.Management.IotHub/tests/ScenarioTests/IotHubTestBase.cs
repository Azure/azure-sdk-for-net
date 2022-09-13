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
using Microsoft.Azure.Test.HttpRecorder;
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
        protected ResourceManagementClient _resourcesClient;
        protected IotHubClient _iotHubClient;
        protected EventHubManagementClient _ehClient;
        protected ServiceBusManagementClient _sbClient;

        protected bool _isInitialized = false;
        protected object _initializeLock = new object();
        protected string _location;
        protected TestEnvironment _testEnvironment;

        static IotHubTestBase()
        {
            RecorderUtilities.JsonPathSanitizers.Add("$..primaryKey");
            RecorderUtilities.JsonPathSanitizers.Add("$..secondaryKey");
            RecorderUtilities.JsonPathSanitizers.Add("$..PrimaryKey");
            RecorderUtilities.JsonPathSanitizers.Add("$..SecondaryKey");
        }

        protected void Initialize(MockContext context)
        {
            if (_isInitialized)
            {
                return;
            }

            lock (_initializeLock)
            {
                if (_isInitialized)
                {
                    return;
                }

                _testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                _resourcesClient = IotHubTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                _iotHubClient = IotHubTestUtilities.GetIotHubClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                _ehClient = IotHubTestUtilities.GetEhClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                _sbClient = IotHubTestUtilities.GetSbClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                _location = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_LOCATION"))
                    ? IotHubTestUtilities.DefaultLocation
                    : Environment.GetEnvironmentVariable("AZURE_LOCATION").Replace(" ", "").ToLower();

                _isInitialized = true;
            }
        }

        protected async Task<string> CreateExternalEhAsync(ResourceGroup resourceGroup, string location)
        {
            const string namespaceName = "iothubcsharpsdkehnamespacetest";
            const string ehName = "iothubcsharpsdkehtest";
            const string authRuleName = "iothubcsharpsdkehtestrule";

            EHModel.NamespaceResource namespaceResource = await _ehClient.Namespaces
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

            _ = await _ehClient.EventHubs
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    namespaceName,
                    ehName,
                    new EventHubCreateOrUpdateParameters
                    {
                        Location = location,
                    })
                .ConfigureAwait(false);

            await _ehClient.EventHubs
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

            EHModel.ResourceListKeys listKeys = await _ehClient.EventHubs
                .ListKeysAsync(resourceGroup.Name, namespaceName, ehName, authRuleName)
                .ConfigureAwait(false);

            return listKeys.PrimaryConnectionString;
        }

        protected async Task<Tuple<string, string>> CreateExternalQueueAndTopicAsync(ResourceGroup resourceGroup, string location)
        {
            const string sbNamespaceName = "iotHubCSharpSDKSBNamespaceTest";
            const string sbName = "iotHubCSharpSDKSBTest";
            const string topicName = "iotHubCSharpSDKTopicTest";
            const string authRuleName = "iotHubCSharpSDKSBTopicTestRule";

            SBModel.NamespaceResource namespaceResource = await _sbClient.Namespaces
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
            _ = await _sbClient.Queues
                .CreateOrUpdateAsync(resourceGroup.Name, sbNamespaceName, sbName, new QueueCreateOrUpdateParameters { Location = location })
                .ConfigureAwait(false);
            _ = await _sbClient.Topics
                .CreateOrUpdateAsync(resourceGroup.Name, sbNamespaceName, topicName, new TopicCreateOrUpdateParameters { Location = location })
                .ConfigureAwait(false);

            await _sbClient.Queues
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

            await _sbClient.Topics
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

            SBModel.ResourceListKeys sbKeys = await _sbClient.Queues
                .ListKeysAsync(resourceGroup.Name, sbNamespaceName, sbName, authRuleName)
                .ConfigureAwait(false);
            SBModel.ResourceListKeys topicKeys = await _sbClient.Queues
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

            return _iotHubClient.IotHubResource.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                createIotHubDescription);
        }

        protected Task<IotHubDescription> UpdateIotHubAsync(ResourceGroup resourceGroup, IotHubDescription iotHubDescription, string iotHubName)
        {
            return _iotHubClient.IotHubResource.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                iotHubDescription);
        }

        protected Task<ResourceGroup> CreateResourceGroupAsync(string resourceGroupName)
        {
            return _resourcesClient.ResourceGroups.CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = IotHubTestUtilities.DefaultLocation
                });
        }

        protected Task DeleteResourceGroupAsync(string resourceGroupName)
        {
            return _resourcesClient.ResourceGroups.DeleteAsync(resourceGroupName);
        }

        protected Task<CertificateDescription> CreateCertificateAsync(
            ResourceGroup resourceGroup,
            string iotHubName,
            string certificateName)
        {
            return _iotHubClient.Certificates.CreateOrUpdateAsync(
                resourceGroup.Name,
                iotHubName,
                certificateName,
                null,
                new CertificateProperties(
                    IotHubTestUtilities.DefaultIotHubCertificateSubject,
                    null,
                    IotHubTestUtilities.DefaultIotHubCertificateThumbprint,
                    null,
                    null,
                    null,
                    IotHubTestUtilities.DefaultIotHubCertificateContent));
        }

        protected Task<CertificateListDescription> GetCertificatesAsync(ResourceGroup resourceGroup, string iotHubName)
        {
            return _iotHubClient.Certificates.ListByIotHubAsync(resourceGroup.Name, iotHubName);
        }

        protected Task<CertificateDescription> GetCertificateAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName)
        {
            return _iotHubClient.Certificates.GetAsync(resourceGroup.Name, iotHubName, certificateName);
        }

        protected Task<CertificateWithNonceDescription> GenerateVerificationCodeAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName, string etag)
        {
            return _iotHubClient.Certificates.GenerateVerificationCodeAsync(resourceGroup.Name, iotHubName, certificateName, etag);
        }

        protected Task DeleteCertificateAsync(ResourceGroup resourceGroup, string iotHubName, string certificateName, string Etag)
        {
            return _iotHubClient.Certificates.DeleteAsync(resourceGroup.Name, iotHubName, certificateName, Etag);
        }
    }
}

