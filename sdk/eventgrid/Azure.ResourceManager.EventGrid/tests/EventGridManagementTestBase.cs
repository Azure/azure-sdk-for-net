// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridManagementTestBase : ManagementRecordedTestBase<EventGridManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public Azure.ResourceManager.Resources.SubscriptionResource DefaultSubscription { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.EastUS;
        public const string  ResourceGroupNamePrefix = "EventGridRG";

        protected EventGridManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
           // Sanitize the endpointUrl with code parameter
           BodyKeySanitizers.Add(new BodyKeySanitizer("..endpointUrl") { Value = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY"
           });
           // Sanitize Endpoint property with sig and sv parameters
           BodyKeySanitizers.Add(new BodyKeySanitizer("..Endpoint") { Value = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY"
           });

            // Sanitize for the AAD Application ID used in the tests
            BodyKeySanitizers.Add(new BodyKeySanitizer("..azureActiveDirectoryApplicationIdOrUri") { Value = "api://SANITIZED_APPLICATION_ID" });

            // Sanitizer for AAD TenantId used in the tests
            BodyKeySanitizers.Add(new BodyKeySanitizer("..azureActiveDirectoryTenantId") { Value = "SANITIZED_TENANT_ID" });

            // Sanitizer for encoded certificate used in testing MQTT Namespace creation
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"encodedCertificate\":\\s?\").*?(?=\")") { Value = "SANITIZED_ENCODED_CERTIFICATE" });

            // Sanitizer for Certificate's Thumbprint used to test MQTT Namespace creation
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"allowedThumbprints\"\\s*:\\s*)\\[[^\\]]*\\]") { Value = "[\"SANITIZED_THUMBPRINTS\"]" });

            // Sanitize shared access keys (ListSharedAccessKeys and RegenerateKeyAsync responses)
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("\"key1\"\\s*:\\s*\"[^\"]*\"") { Value = "\"key1\":\"SANITIZED_KEY1\"" });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("\"key2\"\\s*:\\s*\"[^\"]*\"") { Value = "\"key2\":\"SANITIZED_KEY2\"" });
        }

        protected EventGridManagementTestBase(bool isAsync)
            : base(isAsync)
        {
           // Sanitize the endpointUrl with code parameter
           BodyKeySanitizers.Add(new BodyKeySanitizer("..endpointUrl") { Value = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY"
           });

           // Sanitize Endpoint property with sig and sv parameters
           BodyKeySanitizers.Add(new BodyKeySanitizer("..Endpoint") { Value = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY"
           });

           // Sanitize certificateUrl property
           BodyKeySanitizers.Add(new BodyKeySanitizer("..certificateUrl") { Value = "https://sdk-eg-pre-generated-kv.vault.azure.net/certificates/sdk-eventgrid-test-certificate/SANITIZED_CERTIFICATE_URL"
           });

            // Sanitize for the AAD Application ID used in the tests
            BodyKeySanitizers.Add(new BodyKeySanitizer("..azureActiveDirectoryApplicationIdOrUri") { Value = "api://SANITIZED_APPLICATION_ID" });

            // Sanitizer for AAD TenantId used in the tests
            BodyKeySanitizers.Add(new BodyKeySanitizer("..azureActiveDirectoryTenantId") { Value = "SANITIZED_TENANT_ID" });

            // Sanitizer for encoded certificate used in testing MQTT Namespace creation
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"encodedCertificate\":\\s?\").*?(?=\")") { Value = "SANITIZED_ENCODED_CERTIFICATE" });

            // Sanitizer for Certificate's Thumbprint used to test MQTT Namespace creation
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"allowedThumbprints\"\\s*:\\s*)\\[[^\\]]*\\]") { Value = "[\"SANITIZED_THUMBPRINTS\"]" });

            // Sanitize shared access keys (ListSharedAccessKeys and RegenerateKeyAsync responses)
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("\"key1\"\\s*:\\s*\"[^\"]*\"") { Value = "\"key1\":\"SANITIZED_KEY1\"" });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("\"key2\"\\s*:\\s*\"[^\"]*\"") { Value = "\"key2\":\"SANITIZED_KEY2\"" });
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient(enableDeleteAfter: true);
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> GetResourceGroupAsync(Azure.ResourceManager.Resources.SubscriptionResource subscription, string rgName)
        {
            var lro = await subscription.GetResourceGroups().GetAsync(rgName);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(Azure.ResourceManager.Resources.SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PartnerRegistrationResource> CreatePartnerRegistration(ResourceGroupResource resourceGroup, string registrationName)
        {
            var data = new PartnerRegistrationData(new AzureLocation("Global"));
            var registration = await resourceGroup.GetPartnerRegistrations().CreateOrUpdateAsync(WaitUntil.Completed, registrationName, data);
            return registration.Value;
        }

        protected async Task<PartnerConfigurationResource> CreatePartnerConfiguration(ResourceGroupResource resourceGroup, string registrationName)
        {
            var data = new PartnerConfigurationData(new AzureLocation("Global"));
            PartnerAuthorization partnerAuthorization = new PartnerAuthorization();
            data.PartnerAuthorization = partnerAuthorization;
            var registration = await resourceGroup.GetPartnerConfiguration().CreateOrUpdateAsync(WaitUntil.Completed, data);
            return registration.Value;
        }

        protected async Task<PartnerNamespaceResource> CreatePartnerNamespace(ResourceGroupResource resourceGroup, string namespaceName)
        {
            var registration = await CreatePartnerRegistration(resourceGroup, Recording.GenerateAssetName("PartnerRegistration"));
            var data = new PartnerNamespaceData(resourceGroup.Data.Location)
            {
                PartnerRegistrationFullyQualifiedId = registration.Data.Id,
                IsLocalAuthDisabled = true,
                PublicNetworkAccess = EventGridPublicNetworkAccess.Enabled,
                PartnerTopicRoutingMode = PartnerTopicRoutingMode.ChannelNameHeader,
            };
            var partnerNamespace = await resourceGroup.GetPartnerNamespaces().CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, data);
            return partnerNamespace.Value;
        }

        protected async Task<EventGridTopicResource> CreateEventGridTopic(ResourceGroupResource resourceGroup, string topicName)
        {
            var data = new EventGridTopicData(resourceGroup.Data.Location);
            var topic = await resourceGroup.GetEventGridTopics().CreateOrUpdateAsync(WaitUntil.Completed, topicName, data);
            return topic.Value;
        }
    }
}
