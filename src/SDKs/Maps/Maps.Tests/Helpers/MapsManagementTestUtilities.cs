// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Maps.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Microsoft.Azure.Management.Maps;
    using Microsoft.Azure.Management.Maps.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public static class MapsManagementTestUtilities
    {
        private static readonly HttpClientHandler Handler = null;

        private static readonly string TestSubscription = null;
        private static readonly Uri TestUri = null;

        private static readonly bool IsTestTenant = false;

        // These are used to create default accounts
        public static string DefaultResourceGroupLocation = IsTestTenant ? null : "westus";
        public static string DefaultLocation = IsTestTenant ? null : "global";
        public const string DefaultSkuName = "S0";
        public static Dictionary<string, string> DefaultTags
            = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

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

        public static MapsManagementClient GetMapsManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            MapsManagementClient mapsClient;
            if (IsTestTenant)
            {
                mapsClient = new MapsManagementClient(new TokenCredentials("xyz"), GetHandler())
                {
                    SubscriptionId = TestSubscription,
                    BaseUri = TestUri
                };
            }
            else
            {
                handler.IsPassThrough = true;
                mapsClient = context.GetServiceClient<MapsManagementClient>(handlers: handler);
            }
            return mapsClient;
        }

        public static MapsAccountCreateParameters GetDefaultMapsAccountParameters()
        {
            var account = new MapsAccountCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = new Microsoft.Azure.Management.Maps.Models.Sku()
                {
                    Name = DefaultSkuName
                }
            };

            return account;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string TestPrefix = "res";
            var rgname = TestUtilities.GenerateName(TestPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultResourceGroupLocation
                    });
            }

            return rgname;
        }

        public static string CreateDefaultMapsAccount(MapsManagementClient mapsManagementClient, string rgname)
        {
            var accountName = TestUtilities.GenerateName("maps");
            var parameters = GetDefaultMapsAccountParameters();
            var newAccount = mapsManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
            VerifyAccountProperties(newAccount, true);

            return accountName;
        }

        public static void VerifyAccountProperties(MapsAccount account, bool useDefaults, string skuName = DefaultSkuName, string location = "global")
        {
            Assert.NotNull(account); // verifies that the account is actually created
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Tier);

            if (useDefaults)
            {
                Assert.Equal(MapsManagementTestUtilities.DefaultLocation, account.Location);
                Assert.Equal(MapsManagementTestUtilities.DefaultSkuName, account.Sku.Name);

                Assert.NotNull(account.Tags);
                Assert.Equal(2, account.Tags.Count);
                Assert.Equal("value1", account.Tags["key1"]);
                Assert.Equal("value2", account.Tags["key2"]);
            }
            else
            {
                Assert.Equal(skuName, account.Sku.Name);
                Assert.Equal(location, account.Location);
            }
        }

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }
    }
}