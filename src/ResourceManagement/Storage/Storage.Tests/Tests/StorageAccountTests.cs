// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ResourceGroups.Tests;
using Storage.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Storage.Tests
{
    public class StorageAccountTests
    {
        [Fact]
        public void StorageAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                Assert.Equal(createRequest.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(createRequest.AccountType, AccountType.StandardGRS);
                Assert.Equal(createRequest.Tags.Count, 2);

                // Make sure a second create returns immediately
                createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.Equal(createRequest.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(createRequest.AccountType, AccountType.StandardGRS);
                Assert.Equal(createRequest.Tags.Count, 2);

                // Create storage account with only required params
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    AccountType = AccountType.StandardGRS,
                    Location = StorageManagementTestUtilities.DefaultLocation
                };
                createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                Assert.Equal(createRequest.Location, StorageManagementTestUtilities.DefaultLocation);
                Assert.Equal(createRequest.AccountType, AccountType.StandardGRS);
                Assert.Null(createRequest.Tags);
            }
        }

        [Fact]
        public void StorageAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                storageMgmtClient.StorageAccounts.Delete(rgname, "missingaccount");

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Delete an account
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void StorageAccountGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                //Create and get a LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);

                // Create and get a GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, true);

                // Create and get a RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardRAGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);
               
                // Create and get a ZRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardZRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);

                // Create and get a Premium LRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.AccountType = AccountType.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(getRequest, false);
            }
        }

        [Fact]
        public void StorageAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var listAccountsRequest = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Empty(listAccountsRequest);

                // Create storage accounts
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                listAccountsRequest = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(2, listAccountsRequest.Count());

                StorageManagementTestUtilities.VerifyAccountProperties(listAccountsRequest.First(), true);
                StorageManagementTestUtilities.VerifyAccountProperties(listAccountsRequest.ToArray()[1], true);
            }
        }

        [Fact]
        public void StorageAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);


                // Create resource group and storage account
                var rgname1 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname1);

                // Create different resource group and storage account
                var rgname2 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname2);

                var listAccountsRequest = storageMgmtClient.StorageAccounts.List();

                StorageAccount account1 = listAccountsRequest.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                StorageManagementTestUtilities.VerifyAccountProperties(account1, true);

                StorageAccount account2 = listAccountsRequest.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                StorageManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void StorageAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(listKeysRequest.Key1);
                Assert.NotNull(listKeysRequest.Key2);

                // Regenerate keys
                var regenRequest1 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, new StorageAccountRegenerateKeyParameters { KeyName = KeyName.Key1 });
                var regenRequest2 = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, new StorageAccountRegenerateKeyParameters { KeyName = KeyName.Key2 });

                // Verify listed keys are the same as keys returned by the regenerate request
                listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest1.Key1, listKeysRequest.Key1);
                Assert.Equal(regenRequest2.Key2, listKeysRequest.Key2);
            }
        }

        [Fact]
        public void StorageAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Regenerate keys
                var regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, new StorageAccountRegenerateKeyParameters { KeyName = KeyName.Key1 });
                Assert.NotNull(regenRequest.Key1);
                Assert.NotNull(regenRequest.Key2);

                // Verify listed keys are the same as keys returned by the regenerate request
                var listKeysRequest = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.Equal(regenRequest.Key1, listKeysRequest.Key1);
                Assert.Equal(regenRequest.Key2, listKeysRequest.Key2);

                // Regenerate keys and verify that keys change
                regenRequest = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, new StorageAccountRegenerateKeyParameters { KeyName = KeyName.Key2 });
                Assert.Equal(regenRequest.Key1, listKeysRequest.Key1);
                Assert.NotEqual(regenRequest.Key2, listKeysRequest.Key2);
            }
        }

        // [Fact]
        // TODO: Uncomment out test when CSM bug is fixed. Right now all will return ResourceNotFound
        public void StorageAccountCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);
                
                // Check valid name
                string accountName = TestUtilities.GenerateName("sto");
                var checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(new StorageAccountCheckNameAvailabilityParameters { Name = accountName });
                Assert.Equal(true, checkNameRequest.NameAvailable);
                Assert.Equal(null, checkNameRequest.Reason);
                Assert.Equal(null, checkNameRequest.Message);

                // Check invalid name
                accountName = "CAPS";
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(new StorageAccountCheckNameAvailabilityParameters { Name = accountName });
                Assert.Equal(false, checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AccountNameInvalid, checkNameRequest.Reason);
                Assert.Equal("CAPS is not a valid storage account name. Storage account name must be between 3 and 24 "
                    + "characters in length and use numbers and lower-case letters only.", checkNameRequest.Message);
                
                // Check name of account that already exists
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(new StorageAccountCheckNameAvailabilityParameters { Name = accountName });
                Assert.Equal(false, checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AlreadyExists, checkNameRequest.Reason);
                Assert.Equal("The storage account named " + accountName + " is already taken.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void StorageAccountUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // TODO: Remove wait when CSM is fixed
                TestUtilities.Wait(30000);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    AccountType = AccountType.StandardLRS
                };
                var updateAccountTypeRequest = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(updateAccountTypeRequest.AccountType, AccountType.StandardLRS);

                var getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(getRequest.AccountType, AccountType.StandardLRS);

                // Update storage tags
                parameters = new StorageAccountUpdateParameters
                {
                    Tags = new Dictionary<string, string> 
                    {
                        {"key3","value3"},
                        {"key4","value4"}, 
                        {"key5","value6"}
                    }
                };

                var updateTagsRequest = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(updateTagsRequest.Tags.Count, parameters.Tags.Count);
                Assert.Equal(updateTagsRequest.Tags.ElementAt(0), parameters.Tags.ElementAt(0));

                getRequest = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(getRequest.Tags.Count, parameters.Tags.Count);

                // Update storage custom domains
                parameters = new StorageAccountUpdateParameters
                {
                    CustomDomain = new CustomDomain
                    {
                        Name = "foo.example.com",
                        UseSubDomain = true
                    }
                };

                try
                {
                    storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code."); 
                } 
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Body.Code);
                    Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " + 
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }
    }
}