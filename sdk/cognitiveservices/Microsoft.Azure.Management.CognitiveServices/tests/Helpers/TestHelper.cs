// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using Xunit;

namespace CognitiveServices.Tests.Helpers
{
    public static class TestHelper
    {
        // These are used to create default accounts
        public const string DefaultLocation = "CENTRALUS";
        public const string DefaultSkuName = "S0";
        public const string DefaultKind = "Face";
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourcesClient;
        }

        public static CognitiveServicesManagementClient GetCognitiveServicesManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            CognitiveServicesManagementClient cognitiveServicesClient;
            handler.IsPassThrough = true;
            cognitiveServicesClient = context.GetServiceClient<CognitiveServicesManagementClient>(handlers: handler);
            return cognitiveServicesClient;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                rgname,
                new ResourceGroup
                {
                    Location = DefaultLocation
                });

            return resourceGroup.Name;
        }


        public static Account CreateCognitiveServicesAccount(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgName, string accountType = DefaultKind, string skuName = DefaultSkuName, string location = DefaultLocation)
        {
            var accountName = TestUtilities.GenerateName("csa");
            var parameters = new Account
            {
                Location = location,
                Tags = DefaultTags,
                Sku = new Microsoft.Azure.Management.CognitiveServices.Models.Sku { Name = skuName },
                Kind = accountType,
                Properties = new AccountProperties(),
            };

            var account = cognitiveServicesMgmtClient.Accounts.Create(rgName, accountName, parameters);
            VerifyAccountProperties(account, false, accountType, skuName, location);

            return account;
        }

        public static void VerifyAccountProperties(Account account, bool useDefaults, string kind = DefaultKind, string skuName = DefaultSkuName, string location = DefaultLocation)
        {
            Assert.NotNull(account); // verifies that the account is actually created
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.Etag);
            Assert.NotNull(account.Kind);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Name);

            Assert.NotNull(account.Properties.Endpoint);
            Assert.NotNull(account.SystemData);
            Assert.Equal(ProvisioningState.Succeeded, account.Properties.ProvisioningState);
            Assert.NotNull(account.Properties.Endpoints);
            Assert.True(account.Properties.Endpoints.Count > 0);

            if (useDefaults)
            {
                Assert.Equal(TestHelper.DefaultLocation, account.Location);
                Assert.Equal(TestHelper.DefaultSkuName, account.Sku.Name);
                Assert.Equal(TestHelper.DefaultKind.ToString(), account.Kind);

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
            catch (ErrorResponseException e)
            {
                Assert.Equal(expectedErrorCode, e.Body.Error.Code);
            }
        }
    }
}