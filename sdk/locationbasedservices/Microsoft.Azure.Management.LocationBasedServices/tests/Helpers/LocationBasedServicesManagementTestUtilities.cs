// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace LocationBasedServices.Tests.Helpers
{
    public static class LocationBasedServicesManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        private const string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultResourceGroupLocation = IsTestTenant ? null : "westus";
        public static string DefaultLocation = IsTestTenant ? null : "global";
        public const string DefaultSkuName = "S0";
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

        public static Microsoft.Azure.Management.LocationBasedServices.Client GetLocationBasedServicesManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            Client locationBasedServicesClient;
            if (IsTestTenant)
            {
                locationBasedServicesClient = new Client(new TokenCredentials("xyz"), GetHandler());
                locationBasedServicesClient.SubscriptionId = testSubscription;
                locationBasedServicesClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                locationBasedServicesClient = context.GetServiceClient<Microsoft.Azure.Management.LocationBasedServices.Client>(handlers: handler);
            }
            return locationBasedServicesClient;
        }

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }

        public static LocationBasedServicesAccountCreateParameters GetDefaultLocationBasedServicesAccountParameters()
        {
            LocationBasedServicesAccountCreateParameters account = new LocationBasedServicesAccountCreateParameters
                                                                   {
                                                                       Location = DefaultLocation,
                                                                       Tags = DefaultTags,
                                                                       Sku = new Microsoft.Azure.Management.LocationBasedServices.Models.Sku()
                                                                             {
                                                                                 Name = DefaultSkuName
                                                                             }
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
                        Location = DefaultResourceGroupLocation
                    });
            }

            return rgname;
        }

        public static string CreateDefaultLocationBasedServicesAccount(Microsoft.Azure.Management.LocationBasedServices.Client locationBasedServicesManagementClient, string rgname)
        {
            string accountName = TestUtilities.GenerateName("lbs");
            LocationBasedServicesAccountCreateParameters parameters = GetDefaultLocationBasedServicesAccountParameters();
            var newAccount = locationBasedServicesManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
            VerifyAccountProperties(newAccount, true);

            return accountName;
        }

        //public static CognitiveServicesAccount CreateAndValidateAccountWithOnlyRequiredParameters(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgName, string skuName, string accountType = Kind.Recommendations, string location = null)
        //{
        //    // Create account with only required params
        //    var accountName = TestUtilities.GenerateName("csa");
        //    var parameters = new CognitiveServicesAccountCreateParameters
        //    {
        //        Sku = new Microsoft.Azure.Management.CognitiveServices.Models.Sku { Name = skuName },
        //        Kind = accountType,
        //        Location = location ?? DefaultLocation,
        //        Properties = new object(),
        //    };
        //    var account = cognitiveServicesMgmtClient.CognitiveServicesAccounts.Create(rgName, accountName, parameters);
        //    VerifyAccountProperties(account, false, accountType, skuName, location ?? DefaultLocation);

        //    return account;
        //}

        public static void VerifyAccountProperties(LocationBasedServicesAccount account, bool useDefaults, string skuName = DefaultSkuName, string location = "global")
        {
            Assert.NotNull(account); // verifies that the account is actually created
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Tier);

            if (useDefaults)
            {
                Assert.Equal(LocationBasedServicesManagementTestUtilities.DefaultLocation, account.Location);
                Assert.Equal(LocationBasedServicesManagementTestUtilities.DefaultSkuName, account.Sku.Name);
                
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

    }
}