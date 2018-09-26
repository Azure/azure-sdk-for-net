// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace CognitiveServices.Tests.Helpers
{
    public static class CognitiveServicesManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        private const string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";
        public const string DefaultSkuName = SkuName.S1;
        public const string DefaultKind = Kind.TextAnalytics;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

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

        public static CognitiveServicesManagementClient GetCognitiveServicesManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            CognitiveServicesManagementClient cognitiveServicesClient;
            if (IsTestTenant)
            {
                cognitiveServicesClient = new CognitiveServicesManagementClient(new TokenCredentials("xyz"), GetHandler());
                cognitiveServicesClient.SubscriptionId = testSubscription;
                cognitiveServicesClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                cognitiveServicesClient = context.GetServiceClient<CognitiveServicesManagementClient>(handlers: handler);
            }
            return cognitiveServicesClient;
        }

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }

        public static CognitiveServicesAccountCreateParameters GetDefaultCognitiveServicesAccountParameters()
        {
            CognitiveServicesAccountCreateParameters account = new CognitiveServicesAccountCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = new Microsoft.Azure.Management.CognitiveServices.Models.Sku { Name = DefaultSkuName },
                Kind = DefaultKind,
                Properties = new object(),
            };

            return account;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultLocation
                    });
            }

            return rgname;
        }

        public static string CreateCognitiveServicesAccount(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgname, string kind = null)
        {
            string accountName = TestUtilities.GenerateName("csa");
            CognitiveServicesAccountCreateParameters parameters = GetDefaultCognitiveServicesAccountParameters();
            if (!string.IsNullOrEmpty(kind)) parameters.Kind = kind;
            var createRequest2 = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

            return accountName;
        }

        public static CognitiveServicesAccount CreateAndValidateAccountWithOnlyRequiredParameters(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgName, string skuName, string accountType = Kind.TextAnalytics, string location = null)
        {
            // Create account with only required params
            var accountName = TestUtilities.GenerateName("csa");
            var parameters = new CognitiveServicesAccountCreateParameters
            {
                Sku = new Microsoft.Azure.Management.CognitiveServices.Models.Sku { Name = skuName },
                Kind = accountType,
                Location = location ?? DefaultLocation,
                Properties = new object(),
            };
            var account = cognitiveServicesMgmtClient.Accounts.Create(rgName, accountName, parameters);
            VerifyAccountProperties(account, false, accountType, skuName, location ?? DefaultLocation);

            return account;
        }

        public static void VerifyAccountProperties(CognitiveServicesAccount account, bool useDefaults, string kind = DefaultKind, string skuName = DefaultSkuName, string location = "westus")
        {
            Assert.NotNull(account); // verifies that the account is actually created
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.Etag);
            Assert.NotNull(account.Kind);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Name);

            Assert.NotNull(account.Endpoint);
            Assert.Equal(ProvisioningState.Succeeded, account.ProvisioningState);

            if (useDefaults)
            {
                Assert.Equal(CognitiveServicesManagementTestUtilities.DefaultLocation, account.Location);
                Assert.Equal(CognitiveServicesManagementTestUtilities.DefaultSkuName, account.Sku.Name);
                Assert.Equal(CognitiveServicesManagementTestUtilities.DefaultKind.ToString(), account.Kind);

                Assert.NotNull(account.Tags);
                Assert.Equal(2, account.Tags.Count);
                Assert.Equal("value1", account.Tags["key1"]);
                Assert.Equal("value2", account.Tags["key2"]);
            }
            else
            {
                Assert.Equal(skuName, account.Sku.Name);
                Assert.Equal(kind, account.Kind);
                Assert.Equal(location, account.Location);
            }
        }

        public static void ValidateExpectedException(Action action, string expectedErrorCode)
        {
            try
            {
                action();
                Assert.True(false, "Expected an Exception");
            }
            catch (ErrorException e)
            {
                Assert.Equal(expectedErrorCode, e.Body.ErrorProperty.Code);
            }
        }
    }
}