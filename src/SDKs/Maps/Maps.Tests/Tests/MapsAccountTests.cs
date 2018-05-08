// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Maps.Tests.Helpers;
using Microsoft.Azure.Management.Maps;
using Microsoft.Azure.Management.Maps.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace MapsServices.Tests
{
    using System.ComponentModel.DataAnnotations;

    // aad tenant id:   72f988bf-86f1-41af-91ab-2d7cd011db47
    // aad application identity:  26ba1730-4c7c-4099-84b8-ec115a357455
    // application key must be generated from:
    // https://ms.portal.azure.com/#blade/Microsoft_AAD_IAM/ApplicationBlade/appId/26ba1730-4c7c-4099-84b8-ec115a357455/objectId/e0e8b1f6-23dd-40dd-af56-abd89d14fb0d


    public class MapsServicesAccountTests
    {
        [Fact]
        public void MapsAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("maps");
                var parameters = MapsManagementTestUtilities.GetDefaultMapsAccountParameters();

                // Create account
                var newAccount = mapsManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
                MapsManagementTestUtilities.VerifyAccountProperties(newAccount, true);

                // now get the account
                var account = mapsManagementClient.Accounts.Get(rgname, accountName);
                MapsManagementTestUtilities.VerifyAccountProperties(account, true);

                // now delete the account
                mapsManagementClient.Accounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void MapsAccountUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("maps");
                var parameters = MapsManagementTestUtilities.GetDefaultMapsAccountParameters();

                // create the account
                var newAccount = mapsManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);
                MapsManagementTestUtilities.VerifyAccountProperties(newAccount, true);

                // create new parameters which are almost the same, but have different tags
                var newParameters = MapsManagementTestUtilities.GetDefaultMapsAccountParameters();
                newParameters.Tags = new Dictionary<string, string>
                                     {
                                         { "key3", "value3" },
                                         { "key4", "value4" }
                                     };
                var updatedAccount = mapsManagementClient.Accounts.CreateOrUpdate(rgname, accountName, newParameters);
                MapsManagementTestUtilities.VerifyAccountProperties(updatedAccount, false);
                Assert.NotNull(updatedAccount.Tags);
                Assert.Equal(2, updatedAccount.Tags.Count);
                Assert.Equal("value3", updatedAccount.Tags["key3"]);
                Assert.Equal("value4", updatedAccount.Tags["key4"]);
            }
        }


        [Fact]
        public void MapsAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                mapsManagementClient.Accounts.Delete(rgname, "missingaccount");

                // prepare account properties
                var accountName = TestUtilities.GenerateName("maps");
                var parameters = MapsManagementTestUtilities.GetDefaultMapsAccountParameters();

                // Create account
                var newAccount = mapsManagementClient.Accounts.CreateOrUpdate(rgname, accountName, parameters);

                // Delete an account
                mapsManagementClient.Accounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                mapsManagementClient.Accounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void MapsAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = mapsManagementClient.Accounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create accounts
                var accountName1 = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname);
                var accountName2 = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname);

                accounts = mapsManagementClient.Accounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                MapsManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                MapsManagementTestUtilities.VerifyAccountProperties(accounts.Skip(1).First(), true);
            }
        }

        [Fact]
        public void MapsAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group and account
                var rgname1 = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);
                var accountName1 = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname1);

                // Create different resource group and account
                var rgname2 = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);
                var accountName2 = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname2);

                var accounts = mapsManagementClient.Accounts.ListBySubscription();

                Assert.True(accounts.Count() >= 2);

                var account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                MapsManagementTestUtilities.VerifyAccountProperties(account1, true);

                var account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                MapsManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void MapsAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create account
                var accountName = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname);

                // List keys
                var keys = mapsManagementClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                Assert.NotNull(keys.PrimaryKey);

                // Validate Key2
                Assert.NotNull(keys.SecondaryKey);
            }
        }

        [Fact]
        public void MapsAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = MapsManagementTestUtilities.GetResourceManagementClient(context, handler);
                var mapsManagementClient = MapsManagementTestUtilities.GetMapsManagementClient(context, handler);

                // Create resource group
                var rgname = MapsManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create account
                var accountName = MapsManagementTestUtilities.CreateDefaultMapsAccount(mapsManagementClient, rgname);

                // List keys
                var keys = mapsManagementClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                var key2 = keys.SecondaryKey;
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = mapsManagementClient.Accounts.RegenerateKeys(rgname, accountName, new MapsKeySpecification("secondary"));
                var key2Regen = regenKeys.SecondaryKey;
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2, key2Regen);
            }
        }
    }
}