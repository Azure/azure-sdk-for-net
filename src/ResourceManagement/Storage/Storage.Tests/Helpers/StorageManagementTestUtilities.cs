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

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Storage.Tests.Helpers
{
    public static class StorageManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
        public static string certName = null;
        public static string certPassword = null;
        private static string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";
        public static AccountType DefaultAccountType = AccountType.StandardGRS;
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
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handler);
                return resourcesClient;
            }
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            StorageManagementClient storageClient;
            if (IsTestTenant)
            {
                storageClient = new StorageManagementClient(new TokenCredentials("xyz"), GetHandler());
                storageClient.SubscriptionId = testSubscription;
                storageClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                storageClient = context.GetServiceClient<StorageManagementClient>(handler);
            }
            return storageClient;
        }

        private static HttpClientHandler GetHandler() 
        {
#if DNX451
            if (Handler == null)
            {
                //talk to yugangw-msft, if the code doesn't work under dnx451 (same with net451)
                X509Certificate2 cert = new X509Certificate2(certName, certPassword);
                Handler = new System.Net.Http.WebRequestHandler();
                ((WebRequestHandler)Handler).ClientCertificates.Add(cert);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            }
#endif
            return Handler;
        }

        public static StorageAccountCreateParameters GetDefaultStorageAccountParameters()
        {
            StorageAccountCreateParameters account = new StorageAccountCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                AccountType = DefaultAccountType
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

        public static string CreateStorageAccount(StorageManagementClient storageMgmtClient, string rgname)
        {
            string accountName = TestUtilities.GenerateName("sto");
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();

            var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

            return accountName;
        }

        public static void VerifyAccountProperties(StorageAccount account, bool useDefaults)
        {
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.AccountType);
            Assert.NotNull(account.CreationTime);

            Assert.Equal(AccountStatus.Available, account.StatusOfPrimary);
            Assert.Equal(account.Location, account.PrimaryLocation);

            Assert.NotNull(account.PrimaryEndpoints);
            Assert.NotNull(account.PrimaryEndpoints.Blob);

            if (account.AccountType != AccountType.StandardZRS && account.AccountType != AccountType.PremiumLRS)
            {
                Assert.NotNull(account.PrimaryEndpoints.Queue);
                Assert.NotNull(account.PrimaryEndpoints.Table);
                Assert.NotNull(account.PrimaryEndpoints.File);
            }

            Assert.Equal(ProvisioningState.Succeeded, account.ProvisioningState);
            Assert.Null(account.LastGeoFailoverTime);

            switch (account.AccountType)
            {
                case AccountType.StandardLRS:
                case AccountType.StandardZRS:
                case AccountType.PremiumLRS:
                    Assert.Null(account.SecondaryLocation);
                    Assert.Null(account.StatusOfSecondary);
                    Assert.Null(account.SecondaryEndpoints);
                    break;
                case AccountType.StandardRAGRS:
                    Assert.Equal(AccountStatus.Available, account.StatusOfSecondary);
                    Assert.NotNull(account.SecondaryLocation);
                    Assert.NotNull(account.SecondaryEndpoints);
                    Assert.NotNull(account.SecondaryEndpoints.Blob);
                    Assert.NotNull(account.SecondaryEndpoints.Queue);
                    Assert.NotNull(account.SecondaryEndpoints.Table);
                    break;
                case AccountType.StandardGRS:
                    Assert.Equal(AccountStatus.Available, account.StatusOfSecondary);
                    Assert.NotNull(account.SecondaryLocation);
                    Assert.Null(account.SecondaryEndpoints);
                    break;
            }

            if (useDefaults)
            {
                Assert.Equal(StorageManagementTestUtilities.DefaultLocation, account.Location);
                Assert.Equal(StorageManagementTestUtilities.DefaultAccountType, account.AccountType);
                
                Assert.NotNull(account.Tags);
                Assert.Equal(2, account.Tags.Count);
                Assert.Equal(account.Tags["key1"], "value1");
                Assert.Equal(account.Tags["key2"], "value2");
            }
        }
    }
}