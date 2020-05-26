// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;

namespace HealthcareApis.Tests.Helpers
{
    public static class HealthcareApisManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";
        public static Kind DefaultKind = Kind.Fhir;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static Dictionary<string, string> UpdateTags = new Dictionary<string, string>
            {
                {"key3","value3"},
                {"key4","value4"},
                {"key5", "value5"}
            };

        public static string objectId = "7df19f2f-6169-40f0-ac1e-9a9b4e65a898";
        public static string authority = "https://login.microsoftonline.com/common";
        public static string audience = "https://azurehealthcareapis.com";
        public static bool smartOnFhirEnabled = false;
        public static int offerThroughput = 400;

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }

        public static HealthcareApisManagementClient GetHealthcareApisManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            HealthcareApisManagementClient healthcareApisManagementClient;
            if (IsTestTenant)
            {
                healthcareApisManagementClient = new HealthcareApisManagementClient(new TokenCredentials("xyz"), GetHandler());
                healthcareApisManagementClient.SubscriptionId = "testSubscription";
                healthcareApisManagementClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                healthcareApisManagementClient = context.GetServiceClient<HealthcareApisManagementClient>(handlers: handler);
            }
            return healthcareApisManagementClient;
        }

        public static ServicesDescription GetServiceDescription()
        {
            var serviceDescription = new ServicesDescription(DefaultKind, DefaultLocation);
            return serviceDescription;
        }

        public static ServicesDescription GetServiceDescription(Kind kind)
        {
            var serviceDescription = new ServicesDescription(kind, DefaultLocation);
            return serviceDescription;
        }

        public static ServicesPatchDescription GetServicePatchDescription()
        {
            var servicePatchDescription = new ServicesPatchDescription(UpdateTags);
            return servicePatchDescription;
        }

        public static ServicesDescription GetServiceDescriptionWithProperties()
        {
            var serviceProperties = GetServiceProperties();
            var serviceDescription = new ServicesDescription(DefaultKind, DefaultLocation, default(string), default(string), default(string), DefaultTags, default(string), default(ResourceIdentity), serviceProperties);
            return serviceDescription;
        }

        public static ServicesProperties GetServiceProperties()
        {
            IList<ServiceAccessPolicyEntry> accessPolicies = new List<ServiceAccessPolicyEntry>();
            accessPolicies.Add(new ServiceAccessPolicyEntry(objectId));

            string provisioningState = "Succeeded";

            ServiceCosmosDbConfigurationInfo cosmosDbConfigurationInfo = new ServiceCosmosDbConfigurationInfo(offerThroughput);
            ServiceAuthenticationConfigurationInfo authenticationConfigurationInfo = new ServiceAuthenticationConfigurationInfo(authority, audience, smartOnFhirEnabled);

            var serviceProperties = new ServicesProperties(accessPolicies, provisioningState, cosmosDbConfigurationInfo, authenticationConfigurationInfo);

            return serviceProperties;
        }

        public static string CreateHealthcareApisAccount(HealthcareApisManagementClient healthcareApisManagementClient, string rgname, string kind = null)
        {
            // Generate account name
            string accountName = TestUtilities.GenerateName("hca");

            // Create healthcareApis account
            var createdAccount = healthcareApisManagementClient.Services.CreateOrUpdate(rgname, accountName, GetServiceDescriptionWithProperties());

            return accountName;
        }

        public static void VerifyAccountProperties(ServicesDescription account, bool useDefaults, string location = "westus")
        {
            // verifies that the account is actually created
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.Etag);
            Assert.NotNull(account.Properties);
            Assert.Equal(ProvisioningState.Succeeded, account.Properties.ProvisioningState);

            if (!useDefaults)
            {
                Assert.NotNull(account.Properties.AuthenticationConfiguration);
                Assert.NotNull(account.Properties.CosmosDbConfiguration);
                Assert.NotNull(account.Properties.AccessPolicies);
                Assert.Equal("https://login.microsoftonline.com/common", account.Properties.AuthenticationConfiguration.Authority);
                Assert.Equal("https://azurehealthcareapis.com", account.Properties.AuthenticationConfiguration.Audience);
                Assert.False(account.Properties.AuthenticationConfiguration.SmartProxyEnabled);
                Assert.Equal(400, account.Properties.CosmosDbConfiguration.OfferThroughput);
                Assert.Equal(1, account.Properties.AccessPolicies.Count);
                Assert.Equal(ProvisioningState.Succeeded, account.Properties.ProvisioningState);
                Assert.Equal(Kind.FhirR4, account.Kind);
            }
        }

        public static void ValidateExpectedException(Action action, string expectedErrorCode)
        {
            try
            {
                action();
                Assert.True(false, "Expected an Exception");
            }
            catch (ErrorDetailsException e)
            {
                Assert.Equal(expectedErrorCode, e.Response.StatusCode.ToString());
            }
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            var rgname = "res7089";

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdateAsync(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultLocation
                    });
            }
            return rgname;
        }
    }
}
