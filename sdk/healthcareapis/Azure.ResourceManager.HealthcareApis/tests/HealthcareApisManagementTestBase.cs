// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.HealthcareApis.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    public class HealthcareApisManagementTestBase : ManagementRecordedTestBase<HealthcareApisManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected string ResourceGroupNamePrefix = "HealthCareApisRG";

        protected HealthcareApisManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..authority");
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/Microsoft.EventHub/namespaces/[^/]+api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/Microsoft.EventHub/namespaces/[^/]+/eventhubs/[^/]+api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
        }

        protected HealthcareApisManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..authority");
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/Microsoft.EventHub/namespaces/[^/]+api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/Microsoft.EventHub/namespaces/[^/]+/eventhubs/[^/]+api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<HealthcareApisWorkspaceResource> CreateHealthcareApisWorkspace(ResourceGroupResource resourceGroup, string workspaceName)
        {
            var data = new HealthcareApisWorkspaceData(DefaultLocation);
            var lro = await resourceGroup.GetHealthcareApisWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, data);
            return lro.Value;
        }

        protected async Task<FhirServiceResource> CreateFhirService(HealthcareApisWorkspaceResource workspace, string fhirServiceName)
        {
            FhirServiceData data = new FhirServiceData(DefaultLocation)
            {
                Kind = "fhir-R4",
                AuthenticationConfiguration = new FhirServiceAuthenticationConfiguration()
                {
                    Authority = $"https://login.microsoftonline.com/{Environment.GetEnvironmentVariable("TENANT_ID")}",
                    Audience = $"https://{workspace.Data.Name}-{fhirServiceName}.fhir.azurehealthcareapis.com"
                },
                ImportConfiguration = new FhirServiceImportConfiguration()
                {
                    IsEnabled = false,
                    IsInitialImportMode = false,
                },
                ResourceVersionPolicyConfiguration = new FhirServiceResourceVersionPolicyConfiguration()
                {
                    Default = "no-version",
                }
            };
            var lro = await workspace.GetFhirServices().CreateOrUpdateAsync(WaitUntil.Completed, fhirServiceName, data);
            return lro.Value;
        }

        protected async Task<HealthcareApisIotConnectorResource> CreateHealthcareApisIotConnector(ResourceGroupResource resourceGroup, HealthcareApisWorkspaceResource workspace, string iotConnectorName)
        {
            // Create an Eventhub
            var eventhubNamespace = await resourceGroup.GetEventHubsNamespaces().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("azmedtechspaces"), new EventHubsNamespaceData(resourceGroup.Data.Location));
            string eventHubName = Recording.GenerateAssetName("eventhub");
            var eventhub = await eventhubNamespace.Value.GetEventHubs().CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, new EventHubData());

            // Create an IotConnector
            var data = new HealthcareApisIotConnectorData(DefaultLocation)
            {
                IngestionEndpointConfiguration = new HealthcareApisIotConnectorEventHubIngestionConfiguration()
                {
                    EventHubName = eventHubName,
                    ConsumerGroup = "$Default",
                    FullyQualifiedEventHubNamespace = $"{eventHubName}.servicesbus.windows.net",
                },
                DeviceMapping = new HealthcareApisIotMappingProperties()
                {
                    Content = BinaryData.FromString("{\"templateType\": \"CollectionContent\",\"template\": []}"),
                },
            };
            var iotConnectorLro = await workspace.GetHealthcareApisIotConnectors().CreateOrUpdateAsync(WaitUntil.Completed, iotConnectorName, data);
            return iotConnectorLro.Value;
        }
    }
}
