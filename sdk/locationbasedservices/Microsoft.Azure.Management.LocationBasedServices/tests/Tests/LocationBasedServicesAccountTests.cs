// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using LocationBasedServices.Tests.Helpers;
using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace LBS.Tests
{
    // aad tenant id:   72f988bf-86f1-41af-91ab-2d7cd011db47
    // aad application identity:  26ba1730-4c7c-4099-84b8-ec115a357455
    // application key:  bjrvl/yDY3lMNBn9Ft0R4ydCKlDU27MVOdG2qyWvmsw=


    public class LocationBasedServicesServicesAccountTests
    {
        private const string c_resourceNamespace = "Microsoft.LocationBasedServices";
        private const string c_resourceType = "accounts";

        [Fact]
        public void LocationBasedServicesAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                var rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("lbs");
                var parameters = LocationBasedServicesManagementTestUtilities.GetDefaultLocationBasedServicesAccountParameters();

                // Create account
                var newAccount = locationBasedServicesManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(newAccount, true);

                // now get the account
                var account = locationBasedServicesManagementClient.Accounts.Get(rgname, accountName);
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(account, true);

                // now delete the account
                locationBasedServicesManagementClient.Accounts.Delete(rgname, accountName);

            }
        }

        [Fact]
        public void LocationBasedServicesAccountUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                var rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("lbs");
                var parameters = LocationBasedServicesManagementTestUtilities.GetDefaultLocationBasedServicesAccountParameters();

                // create the account
                var newAccount = locationBasedServicesManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(newAccount, true);

                // create new parameters which are almost the same, but have different tags
                var newParameters = LocationBasedServicesManagementTestUtilities.GetDefaultLocationBasedServicesAccountParameters();
                newParameters.Tags = new Dictionary<string, string>
                                     {
                                         { "key3", "value3" },
                                         { "key4", "value4" }
                                     };
                var updatedAccount = locationBasedServicesManagementClient.Accounts.CreateOrUpdate(rgname, accountName, newParameters);
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(updatedAccount, false);
                Assert.NotNull(updatedAccount.Tags);
                Assert.Equal(2, updatedAccount.Tags.Count);
                Assert.Equal("value3", updatedAccount.Tags["key3"]);
                Assert.Equal("value4", updatedAccount.Tags["key4"]);
            }
        }


        [Fact]
        public void LocationBasedServicesAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                var rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                locationBasedServicesManagementClient.Accounts.Delete(rgname, "missingaccount");

                // prepare account properties
                string accountName = TestUtilities.GenerateName("lbs");
                var parameters = LocationBasedServicesManagementTestUtilities.GetDefaultLocationBasedServicesAccountParameters();

                // Create account
                var newAccount = locationBasedServicesManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);

                // Delete an account
                locationBasedServicesManagementClient.Accounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                locationBasedServicesManagementClient.Accounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void LocationBasedServicesAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                var rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = locationBasedServicesManagementClient.Accounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create accounts
                string accountName1 = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname);
                string accountName2 = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname);

                accounts = locationBasedServicesManagementClient.Accounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(accounts.Skip(1).First(), true);
            }
        }

        [Fact]
        public void LocationBasedServicesAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group and account
                var rgname1 = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname1);

                // Create different resource group and account
                var rgname2 = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname2);

                var accounts = locationBasedServicesManagementClient.Accounts.ListBySubscription();

                Assert.True(accounts.Count() >= 2);

                var account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(account1, true);

                var account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                LocationBasedServicesManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void LocationBasedServicesAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                string rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create account
                string accountName = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname);

                // List keys
                var keys = locationBasedServicesManagementClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                Assert.NotNull(keys.PrimaryKey);
                // Validate Key2
                Assert.NotNull(keys.SecondaryKey);
            }
        }

        [Fact]
        public void LocationBasedServicesAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = LocationBasedServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var locationBasedServicesManagementClient = LocationBasedServicesManagementTestUtilities.GetLocationBasedServicesManagementClient(context, handler);

                // Create resource group
                string rgname = LocationBasedServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create account
                string accountName = LocationBasedServicesManagementTestUtilities.CreateDefaultLocationBasedServicesAccount(locationBasedServicesManagementClient, rgname);

                // List keys
                var keys = locationBasedServicesManagementClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                var key2 = keys.SecondaryKey;
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = locationBasedServicesManagementClient.Accounts.RegenerateKeys(rgname,
                                                                                              accountName,
                                                                                              new LocationBasedServicesKeySpecification("secondary"));
                var key2Regen = regenKeys.SecondaryKey;
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2, key2Regen);
            }
        }
    }
}
