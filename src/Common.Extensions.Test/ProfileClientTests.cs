// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Subscriptions.Models;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Common.Extensions.Authentication;
using Xunit;
using Microsoft.Azure.Common.Extensions;
using Microsoft.WindowsAzure.Subscriptions.Models;
using CSMSubscription = Microsoft.Azure.Subscriptions.Models.Subscription;
using RDFESubscription = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription;

namespace Common.Extensions.Test
{
    public class ProfileClientTests
    {
        private string oldProfileData;
        private string oldProfileDataBadSubscription;
        private string oldProfileDataCorruptedFile;
        private string oldProfileDataPath;
        private string oldProfileDataPathError;
        private string newProfileDataPath;
        private string jsonProfileWithoutAccount;
        private string jsonProfileWithBadData;
        private string defaultSubscription = "06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F";
        private SubscriptionListOperationResponse.Subscription rdfeSubscription1;
        private SubscriptionListOperationResponse.Subscription rdfeSubscription2;
        private Subscription csmSubscription1;
        private Subscription csmSubscription1withDuplicateId;
        private Subscription csmSubscription2;
        private AzureSubscription azureSubscription1;
        private AzureSubscription azureSubscription2;
        private AzureSubscription azureSubscription3withoutUser;
        private AzureEnvironment azureEnvironment;
        private AzureAccount azureAccount;
        private TenantIdDescription commonTenant;
        private TenantIdDescription guestTenant;
        private RDFESubscription guestRdfeSubscription;
        private CSMSubscription guestCsmSubscription;

        public ProfileClientTests()
        {
            SetMockData();
            AzureSession.SetCurrentContext(null, null, null);
        }

        [Fact]
        public void ProfileGetsCreatedWithNonExistingFile()
        {
            ProfileClient.DataStore = new MockDataStore();
            ProfileClient client = new ProfileClient();
        }

        [Fact]
        public void ProfileMigratesOldData()
        {
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        public void ProfileMigratesOldDataOnce()
        {
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client1 = new ProfileClient();

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));

            ProfileClient client2 = new ProfileClient();

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        public void ProfileMigratesAccountsAndDefaultSubscriptions()
        {
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            // Verify Environment migration
            Assert.Equal(4, client.Profile.Environments.Count);
            Assert.Equal("Current", client.Profile.Environments["Current"].Name);
            Assert.Equal("Dogfood", client.Profile.Environments["Dogfood"].Name);
            Assert.Equal("https://login.windows-ppe.net/", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.AdTenant]);
            Assert.Equal("https://management.core.windows.net/", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId]);
            Assert.Equal("https://df.gallery.azure-test.net", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.Gallery]);
            Assert.Equal("https://windows.azure-test.net", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl]);
            Assert.Equal("https://auxnext.windows.azure-test.net/publishsettings/index", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl]);
            Assert.Equal("https://api-dogfood.resources.windows-int.net", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.ResourceManager]);
            Assert.Equal("https://management-preview.core.windows-int.net/", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.ServiceManagement]);
            Assert.Equal(".database.windows.net", client.Profile.Environments["Dogfood"].Endpoints[AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix]);

            // Verify subscriptions
            Assert.Equal(3, client.Profile.Subscriptions.Count);
            Assert.False(client.Profile.Subscriptions.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E")));
            Assert.True(client.Profile.Subscriptions.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")));
            Assert.Equal("Test 2", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Name);
            Assert.True(client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].IsPropertySet(AzureSubscription.Property.Default));
            Assert.Equal("test@mail.com", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Account);
            Assert.Equal("Dogfood", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Environment);
            Assert.Equal("123", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Properties[AzureSubscription.Property.Tenants]);
            Assert.True(client.Profile.Subscriptions.ContainsKey(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")));
            Assert.Equal("Test 3", client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Name);
            Assert.False(client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].IsPropertySet(AzureSubscription.Property.Default));
            Assert.Equal("test@mail.com", client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Account);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Properties[AzureSubscription.Property.Tenants]);
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Environment);
            Assert.Equal(EnvironmentName.AzureChinaCloud, client.Profile.Subscriptions[new Guid("c14d7dc5-ed4d-4346-a02f-9f1bcf78fb66")].Environment);

            // Verify accounts
            Assert.Equal(2, client.Profile.Accounts.Count);
            Assert.Equal("test@mail.com", client.Profile.Accounts["test@mail.com"].Id);
            Assert.Equal(AzureAccount.AccountType.User, client.Profile.Accounts["test@mail.com"].Type);
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F").ToString()));
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("123"));
            Assert.Equal("3AF24D48B97730E5C4C9CCB12397B5E046F79E09", client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].Id);
            Assert.Equal(AzureAccount.AccountType.Certificate, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].Type);
            Assert.Equal(0, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].GetPropertyAsArray(AzureAccount.Property.Tenants).Length);
            Assert.Equal(2, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);
        }

        [Fact]
        public void ProfileMigratesAccountsSkipsBadOnesAndBacksUpFile()
        {
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataBadSubscription;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            // Verify Environment migration
            Assert.Equal(2, client.Profile.Environments.Count);

            // Verify subscriptions
            Assert.Equal(3, client.Profile.Subscriptions.Count);
            Assert.True(client.Profile.Subscriptions.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")));
            Assert.Equal("Test Bad Management Endpoint", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Name);
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Environment);
            Assert.Equal("Test Null Management Endpoint", client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF")].Name);
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.Subscriptions[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF")].Environment);

            Assert.True(client.Profile.Subscriptions.ContainsKey(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")));
            Assert.Equal("Test Bad Cert", client.Profile.Subscriptions[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Name);

            // Verify accounts
            Assert.Equal(2, client.Profile.Accounts.Count);
            Assert.Equal("test@mail.com", client.Profile.Accounts["test@mail.com"].Id);
            Assert.Equal(AzureAccount.AccountType.User, client.Profile.Accounts["test@mail.com"].Type);
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F").ToString()));
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.False(client.Profile.Accounts["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("123"));
            Assert.Equal("3AF24D48B97730E5C4C9CCB12397B5E046F79E99", client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].Id);
            Assert.Equal(AzureAccount.AccountType.Certificate, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].Type);
            Assert.Equal(0, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Tenants).Length);
            Assert.Equal(1, client.Profile.Accounts["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);

            // Verify backup file
            Assert.True(dataStore.FileExists(oldProfileDataPathError));
            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.Equal(oldProfileDataBadSubscription, dataStore.ReadFileAsText(oldProfileDataPathError));
        }

        [Fact]
        public void ProfileMigratesCorruptedFileAndCreatedBackup()
        {
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataCorruptedFile;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            // Verify Environment migration
            Assert.Equal(2, client.Profile.Environments.Count);

            // Verify subscriptions
            Assert.Equal(0, client.Profile.Subscriptions.Count);

            // Verify accounts
            Assert.Equal(0, client.Profile.Accounts.Count);

            // Verify backup file
            Assert.True(dataStore.FileExists(oldProfileDataPathError));
            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.Equal(oldProfileDataCorruptedFile, dataStore.ReadFileAsText(oldProfileDataPathError));
        }

        [Fact]
        public void AddAzureAccountReturnsAccountWithAllSubscriptionsInRdfeMode()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "test", Type = AzureAccount.AccountType.User }, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("test", account.Id);
            Assert.Equal(3, account.GetSubscriptions(client.Profile).Count);
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(csmSubscription1.SubscriptionId)));
        }

        [Fact]
        public void AddAzureAccountReturnsAccountWithAllSubscriptionsInCsmMode()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "test", Type = AzureAccount.AccountType.User }, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("test", account.Id);
            Assert.Equal(3, account.GetSubscriptions(client.Profile).Count);
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.Id == new Guid(csmSubscription1.SubscriptionId)));
        }

        /// <summary>
        /// Verify that if a user has a different identity in one tenant, the identity is not added if it has no
        /// access to subscriptions
        /// </summary>
        [Fact]
        public void AddAzureAccountWithImpersonatedGuestWithNoSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1 }.ToList(), new List<Subscription>(),
                new[] { commonTenant, guestTenant }.ToList(),
                (userAccount, environment, tenant) =>
                {
                    var token = new MockAccessToken
                    {
                        UserId = tenant == commonTenant.TenantId ? userAccount.Id : "UserB",
                        AccessToken = "def",
                        LoginType = LoginType.OrgId
                    };
                    userAccount.Id = token.UserId;
                    return token;
                });
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User }, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("UserA", account.Id);
            Assert.Equal(1, account.GetSubscriptions(client.Profile).Count);
            var subrdfe1 = account.GetSubscriptions(client.Profile).FirstOrDefault(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId));
            var userA = client.GetAccount("UserA");
            var userB = client.GetAccount("UserB");
            Assert.NotNull(userA);
            Assert.NotNull(userB);
            Assert.Contains<string>(rdfeSubscription1.SubscriptionId, userA.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.False(userB.HasSubscription(new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.NotNull(subrdfe1);
            Assert.Equal("UserA", subrdfe1.Account);
        }

        /// <summary>
        /// Verify that multiple accounts can be added if a user has different identitities in different domains, linked to the same login
        /// Verify that subscriptions with admin access forall accounts are added
        /// </summary>
        [Fact]
        public void AddAzureAccountWithImpersonatedGuestWithSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(), new List<Subscription>(), new[] { commonTenant, guestTenant }.ToList(),
                    (userAccount, environment, tenant) =>
                {
                    var token = new MockAccessToken
                    {
                        UserId = tenant == commonTenant.TenantId ? userAccount.Id : "UserB",
                        AccessToken = "def",
                        LoginType = LoginType.OrgId
                    };
                    userAccount.Id = token.UserId;
                    return token;
                });
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User }, 
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("UserA", account.Id);
            Assert.Equal(1, account.GetSubscriptions(client.Profile).Count);
            var subrdfe1 = account.GetSubscriptions(client.Profile).FirstOrDefault(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId));
            var userA = client.GetAccount("UserA");
            var userB = client.GetAccount("UserB");
             var subGuest = userB.GetSubscriptions(client.Profile).FirstOrDefault(s => s.Id == new Guid(guestRdfeSubscription.SubscriptionId));
            Assert.NotNull(userA);
            Assert.NotNull(userB);
            Assert.Contains<string>(rdfeSubscription1.SubscriptionId, userA.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.Contains<string>(guestRdfeSubscription.SubscriptionId, userB.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(subrdfe1);
            Assert.NotNull(subGuest);
            Assert.Equal("UserA", subrdfe1.Account);
            Assert.Equal("UserB", subGuest.Account);
        }
        /// <summary>
        /// Test that when account is added more than once with different capitalization, only a single account is added
        /// and that accounts can be retrieved case-insensitively
        /// </summary>
        [Fact]
        public void AddAzureAccountIsCaseInsensitive()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(), new List<Subscription>(), new[] { commonTenant, guestTenant }.ToList(),
                    (userAccount, environment, tenant) =>
                {
                    var token = new MockAccessToken
                    {
                        UserId = tenant == commonTenant.TenantId ? userAccount.Id : "USERA",
                        AccessToken = "def",
                        LoginType = LoginType.OrgId
                    };
                    userAccount.Id = token.UserId;
                    return token;
                });
            MockDataStore dataStore = new MockDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User }, 
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            var userA = client.GetAccount("UserA");
            var secondUserA = client.GetAccount("USERA");
            Assert.NotNull(userA);
            Assert.NotNull(secondUserA);
            Assert.Equal(userA.Id, secondUserA.Id);
        }

        [Fact]
        public void GetAzureAccountReturnsAccountWithSubscriptions()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test").ToList();

            Assert.Equal(1, account.Count);
            Assert.Equal("test", account[0].Id);
            Assert.Equal(2, account[0].GetSubscriptions(client.Profile).Count);
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription1.Id));
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription2.Id));
        }

        [Fact]
        public void GetAzureAccountWithoutEnvironmentReturnsAccount()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test").ToList();

            Assert.Equal(1, account.Count);
            Assert.Equal("test", account[0].Id);
            Assert.Equal(2, account[0].GetSubscriptions(client.Profile).Count);
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription1.Id));
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription2.Id));
        }

        [Fact]
        public void GetAzureAccountReturnsEmptyEnumerationForNonExistingUser()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test2").ToList();

            Assert.Equal(1, account.Count);
        }

        [Fact]
        public void GetAzureAccountReturnsAllAccountsWithNullUser()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.Account = "test2";
            client.Profile.Accounts["test2"] = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Subscriptions, azureSubscription3withoutUser.Id.ToString()}
                }
            };
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts(null).ToList();

            Assert.Equal(2, account.Count);
        }

        [Fact]
        public void RemoveAzureAccountRemovesSubscriptions()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.Account = "test2";
            client.Profile.Accounts["test2"] = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Subscriptions, azureSubscription3withoutUser.Id.ToString()}
                }
            };
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;
            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            Assert.Equal(3, client.Profile.Subscriptions.Count);

            client.RemoveAccount("test2");

            Assert.Equal(2, client.Profile.Subscriptions.Count);
            Assert.Equal(0, log.Count);
        }

        [Fact]
        public void RemoveAzureAccountRemovesDefaultSubscriptionAndWritesWarning()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.Account = "test2";
            client.Profile.Accounts["test2"] = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Subscriptions, azureSubscription3withoutUser.Id.ToString()}
                }
            };
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;
            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            Assert.Equal(3, client.Profile.Subscriptions.Count);

            var account = client.RemoveAccount("test");

            Assert.Equal(1, client.Profile.Subscriptions.Count);
            Assert.Equal("test", account.Id);
            Assert.Equal(2, account.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);
            Assert.Equal(1, log.Count);
            Assert.Equal(
                "The default subscription is being removed. Use Select-AzureSubscription -Default <subscriptionName> to select a new default subscription.",
                log[0]);
        }

        [Fact]
        public void RemoveAzureAccountRemovesDefaultAccountFromSubscription()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.Account = "test2";
            client.Profile.Accounts["test2"] = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Subscriptions, azureSubscription1.Id.ToString()}
                }
            };
            client.Profile.Subscriptions[azureSubscription1.Id].Account = azureAccount.Id;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.RemoveAccount(azureAccount.Id);

            Assert.Equal("test2", client.Profile.Subscriptions[azureSubscription1.Id].Account);
        }

        [Fact]
        public void RemoveAzureAccountRemovesInMemoryAccount()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.Account = "test2";
            client.Profile.Accounts["test2"] = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Subscriptions, azureSubscription1.Id.ToString()}
                }
            };
            client.Profile.Subscriptions[azureSubscription1.Id].Account = azureAccount.Id;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;
            AzureSession.SetCurrentContext(azureSubscription1, azureEnvironment, azureAccount);

            client.RemoveAccount(azureAccount.Id);

            Assert.Equal("test2", AzureSession.CurrentContext.Account.Id);
            Assert.Equal("test2", AzureSession.CurrentContext.Subscription.Account);
            Assert.Equal(azureSubscription1.Id, AzureSession.CurrentContext.Subscription.Id);

            client.RemoveAccount("test2");

            Assert.Null(AzureSession.CurrentContext.Account);
            Assert.Null(AzureSession.CurrentContext.Subscription);
            Assert.Equal(EnvironmentName.AzureCloud, AzureSession.CurrentContext.Environment.Name);
        }

        [Fact]
        public void AddAzureEnvironmentAddsEnvironment()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            Assert.Equal(2, client.Profile.Environments.Count);

            Assert.Throws<ArgumentNullException>(() => client.AddOrSetEnvironment(null));
            var env = client.AddOrSetEnvironment(azureEnvironment);

            Assert.Equal(3, client.Profile.Environments.Count);
            Assert.Equal(env, azureEnvironment);
        }

        [Fact]
        public void GetAzureEnvironmentsListsEnvironments()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            var env1 = client.ListEnvironments(null);

            Assert.Equal(2, env1.Count);

            var env2 = client.ListEnvironments("bad");

            Assert.Equal(0, env2.Count);

            var env3 = client.ListEnvironments(EnvironmentName.AzureCloud);

            Assert.Equal(1, env3.Count);
        }

        [Fact]
        public void RemoveAzureEnvironmentRemovesEnvironmentSubscriptionsAndAccounts()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;

            Assert.Equal(2, client.Profile.Subscriptions.Values.Count(s => s.Environment == "Test"));
            Assert.Equal(3, client.Profile.Environments.Count);
            Assert.Equal(1, client.Profile.Accounts.Count);

            Assert.Throws<ArgumentNullException>(() => client.RemoveEnvironment(null));
            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment("bad"));

            var env = client.RemoveEnvironment(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, env.Name);
            Assert.Equal(0, client.Profile.Subscriptions.Values.Count(s => s.Environment == "Test"));
            Assert.Equal(2, client.Profile.Environments.Count);
            Assert.Equal(0, client.Profile.Accounts.Count);
        }

        [Fact]
        public void RemoveAzureEnvironmentDoesNotRemoveEnvironmentSubscriptionsAndAccountsForAzureCloudOrChinaCloud()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            azureSubscription1.Environment = EnvironmentName.AzureCloud;
            azureSubscription2.Environment = EnvironmentName.AzureChinaCloud;
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;

            Assert.Equal(1, client.Profile.Subscriptions.Values.Count(s => s.Environment == EnvironmentName.AzureCloud));
            Assert.Equal(1, client.Profile.Subscriptions.Values.Count(s => s.Environment == EnvironmentName.AzureChinaCloud));
            Assert.Equal(2, client.Profile.Environments.Count);
            Assert.Equal(1, client.Profile.Accounts.Count);

            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment(EnvironmentName.AzureCloud));
            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment(EnvironmentName.AzureChinaCloud));

            Assert.Equal(1, client.Profile.Subscriptions.Values.Count(s => s.Environment == EnvironmentName.AzureCloud));
            Assert.Equal(1, client.Profile.Subscriptions.Values.Count(s => s.Environment == EnvironmentName.AzureChinaCloud));
            Assert.Equal(2, client.Profile.Environments.Count);
            Assert.Equal(1, client.Profile.Accounts.Count);
        }

        [Fact]
        public void SetAzureEnvironmentUpdatesEnvironment()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            Assert.Equal(2, client.Profile.Environments.Count);

            Assert.Throws<ArgumentNullException>(() => client.AddOrSetEnvironment(null));

            var env2 = client.AddOrSetEnvironment(azureEnvironment);
            Assert.Equal(env2.Name, azureEnvironment.Name);
            Assert.NotNull(env2.Endpoints[AzureEnvironment.Endpoint.ServiceManagement]);
            AzureEnvironment newEnv = new AzureEnvironment
            {
                Name = azureEnvironment.Name
            };
            newEnv.Endpoints[AzureEnvironment.Endpoint.Graph] = "foo";
            env2 = client.AddOrSetEnvironment(newEnv);
            Assert.Equal("foo", env2.Endpoints[AzureEnvironment.Endpoint.Graph]);
            Assert.NotNull(env2.Endpoints[AzureEnvironment.Endpoint.ServiceManagement]);
        }

        [Fact]
        public void GetAzureEnvironmentReturnsCorrectValue()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);

            Assert.Equal(EnvironmentName.AzureCloud, AzureSession.CurrentContext.Environment.Name);

            var defaultEnv = client.GetEnvironmentOrDefault(null);

            Assert.Equal(EnvironmentName.AzureCloud, defaultEnv.Name);

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);

            Assert.Throws<ArgumentException>(() => client.GetEnvironmentOrDefault("bad"));
        }

        [Fact]
        public void GetCurrentEnvironmentReturnsCorrectValue()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            AzureSession.SetCurrentContext(azureSubscription1, azureEnvironment, azureAccount);

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);
        }

        [Fact]
        public void AddOrSetAzureSubscriptionChecksAndUpdates()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);

            Assert.Equal(1, client.Profile.Subscriptions.Count);

            var subscription = client.AddOrSetSubscription(azureSubscription1);

            Assert.Equal(1, client.Profile.Subscriptions.Count);
            Assert.Equal(1, client.Profile.Accounts.Count);
            Assert.Equal(subscription, azureSubscription1);
            Assert.Throws<ArgumentNullException>(() => client.AddOrSetSubscription(null));
            Assert.Throws<ArgumentNullException>(() => client.AddOrSetSubscription(
                new AzureSubscription { Id = new Guid(), Environment = null, Name = "foo" }));
        }

        [Fact]
        public void AddOrSetAzureSubscriptionUpdatesInMemory()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            AzureSession.SetCurrentContext(azureSubscription1, azureEnvironment, azureAccount);
            azureSubscription1.Properties[AzureSubscription.Property.StorageAccount] = "testAccount";
            Assert.Equal(azureSubscription1.Id, AzureSession.CurrentContext.Subscription.Id);
            Assert.Equal(azureSubscription1.Properties[AzureSubscription.Property.StorageAccount],
                AzureSession.CurrentContext.Subscription.Properties[AzureSubscription.Property.StorageAccount]);

            var newSubscription = new AzureSubscription
            {
                Id = azureSubscription1.Id,
                Environment = azureSubscription1.Environment,
                Account = azureSubscription1.Account,
                Name = azureSubscription1.Name
            };
            newSubscription.Properties[AzureSubscription.Property.StorageAccount] = "testAccount1";

            client.AddOrSetSubscription(newSubscription);
            var newSubscriptionFromProfile = client.Profile.Subscriptions[newSubscription.Id];

            Assert.Equal(newSubscription.Id, AzureSession.CurrentContext.Subscription.Id);
            Assert.Equal(newSubscription.Id, newSubscriptionFromProfile.Id);
            Assert.Equal(newSubscription.Properties[AzureSubscription.Property.StorageAccount],
                AzureSession.CurrentContext.Subscription.Properties[AzureSubscription.Property.StorageAccount]);
            Assert.Equal(newSubscription.Properties[AzureSubscription.Property.StorageAccount],
                newSubscriptionFromProfile.Properties[AzureSubscription.Property.StorageAccount]);
        }

        [Fact]
        public void RemoveAzureSubscriptionChecksAndRemoves()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsCurrent(azureSubscription1.Name, azureSubscription1.Account);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureSubscription1.Account);

            Assert.Equal(1, client.Profile.Subscriptions.Count);

            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            var subscription = client.RemoveSubscription(azureSubscription1.Name);

            Assert.Equal(0, client.Profile.Subscriptions.Count);
            Assert.Equal(azureSubscription1.Name, subscription.Name);
            Assert.Equal(2, log.Count);
            Assert.Equal(
                "The default subscription is being removed. Use Select-AzureSubscription -Default <subscriptionName> to select a new default subscription.",
                log[0]);
            Assert.Equal(
                "The current subscription is being removed. Use Select-AzureSubscription <subscriptionName> to select a new current subscription.",
                log[1]);
            Assert.Throws<ArgumentException>(() => client.RemoveSubscription("bad"));
            Assert.Throws<ArgumentNullException>(() => client.RemoveSubscription(null));
        }

        [Fact]
        public void RefreshSubscriptionsUpdatesAccounts()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.True(client.Profile.Accounts[azureAccount.Id].HasSubscription(new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(client.Profile.Accounts[azureAccount.Id].HasSubscription(new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.True(client.Profile.Accounts[azureAccount.Id].HasSubscription(new Guid(csmSubscription1.SubscriptionId)));
            Assert.True(client.Profile.Accounts[azureAccount.Id].HasSubscription(new Guid(csmSubscription1withDuplicateId.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsMergesFromServer()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.Equal(4, subscriptions.Count);
            Assert.Equal(4, subscriptions.Count(s => s.Account == "test"));
            Assert.Equal(1, subscriptions.Count(s => s.Id == azureSubscription1.Id));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(2, subscriptions.First(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)).GetPropertyAsArray(AzureSubscription.Property.SupportedModes).Count());
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(csmSubscription1.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsWorksWithMooncake()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            client.Profile.Accounts[azureAccount.Id] = azureAccount;

            var subscriptions = client.RefreshSubscriptions(client.Profile.Environments[EnvironmentName.AzureChinaCloud]);

            Assert.Equal(2, subscriptions.Count);
            Assert.Equal(2, subscriptions.Count(s => s.Account == "test"));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(1, subscriptions.First(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)).GetPropertyAsArray(AzureSubscription.Property.SupportedModes).Count());
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsListsAllSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.Equal(4, subscriptions.Count);
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(csmSubscription1.SubscriptionId)));
            Assert.True(subscriptions.All(s => s.Environment == "Test"));
            Assert.True(subscriptions.All(s => s.Account == "test"));
        }

        [Fact]
        public void GetAzureSubscriptionByNameChecksAndReturnsOnlyLocal()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);

            var subscriptions = client.GetSubscription(azureSubscription1.Name);

            Assert.Equal(azureSubscription1.Id, subscriptions.Id);
            Assert.Throws<ArgumentException>(() => client.GetSubscription(new Guid()));
        }

        [Fact]
        public void GetAzureSubscriptionByIdChecksAndReturnsOnlyLocal()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);

            var subscriptions = client.GetSubscription(azureSubscription1.Id);

            Assert.Equal(azureSubscription1.Id, subscriptions.Id);
            Assert.Throws<ArgumentException>(() => client.GetSubscription(new Guid()));
        }

        [Fact]
        public void SetAzureSubscriptionAsDefaultSetsDefaultAndCurrent()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);

            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.Account);

            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);
            Assert.Equal(azureSubscription2.Id, AzureSession.CurrentContext.Subscription.Id);
            Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault("bad", null));
            Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault(null, null));
        }

        [Fact]
        public void ClearDefaultAzureSubscriptionClearsDefault()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);
            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.Account);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            client.ClearDefaultSubscription();

            Assert.Null(client.Profile.DefaultSubscription);
        }

        [Fact]
        public void SetAzureSubscriptionAsCurrentSetsCurrent()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(AzureSession.CurrentContext.Subscription);

            client.SetSubscriptionAsCurrent(azureSubscription2.Name, azureSubscription2.Account);

            Assert.Equal(azureSubscription2.Id, AzureSession.CurrentContext.Subscription.Id);
            Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsCurrent("bad", null));
            Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsCurrent(null, null));
        }

        [Fact]
        public void ImportPublishSettingsLoadsAndReturnsSubscriptions()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);
            var account = client.Profile.Accounts.Values.First();

            Assert.True(subscriptions.All(s => s.Account == account.Id));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsDefaultsToAzureCloudEnvironmentWithManagementUrl()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.Environment == EnvironmentName.AzureCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithManagementUrl()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            azureEnvironment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = "https://newmanagement.core.windows.net/";
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.Environment == azureEnvironment.Name));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithChinaManagementUrl()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfileChina);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.Environment == EnvironmentName.AzureChinaCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithChinaManagementUrlOld()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfileChinaOld);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.Environment == EnvironmentName.AzureChinaCloud));
            Assert.Equal(1, subscriptions.Count);
            Assert.Equal(1, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsDefaultsToAzureCloudWithIncorrectManagementUrl()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.Environment == EnvironmentName.AzureCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesPassedInEnvironment()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);

            Assert.True(subscriptions.All(s => s.Environment == azureEnvironment.Name));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.Subscriptions.Count);
        }

        [Fact]
        public void ImportPublishSettingsAddsSecondCertificate()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            ProfileClient client = new ProfileClient();
            var newSubscription = new AzureSubscription
            {
                Id = new Guid("f62b1e05-af8f-4203-8f97-421089adc053"),
                Name = "Microsoft Azure Sandbox 9-220",
                Environment = EnvironmentName.AzureCloud,
                Account = azureAccount.Id
            };
            azureAccount.SetProperty(AzureAccount.Property.Subscriptions, newSubscription.Id.ToString());
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(newSubscription);
            client.Profile.Save();

            client = new ProfileClient();

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);

            Assert.Equal(2, client.Profile.Accounts.Count());
            var certAccount = client.Profile.Accounts.Values.First(a => a.Type == AzureAccount.AccountType.Certificate);
            var userAccount = client.Profile.Accounts.Values.First(a => a.Type == AzureAccount.AccountType.User);

            Assert.True(subscriptions.All(s => s.Account == certAccount.Id));
            Assert.Equal(azureAccount.Id, client.Profile.Subscriptions.Values.First(s => s.Id == newSubscription.Id).Account);

            Assert.True(userAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Contains(newSubscription.Id.ToString()));
            Assert.True(certAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Contains(newSubscription.Id.ToString()));

            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.Subscriptions.Count);
        }

        private void SetMocks(List<SubscriptionListOperationResponse.Subscription> rdfeSubscriptions,
            List<Subscription> csmSubscriptions,
            List<TenantIdDescription> tenants = null,
            Func<AzureAccount, AzureEnvironment, string, IAccessToken> tokenProvider = null)
        {
            ClientMocks clientMocks = new ClientMocks(new Guid(defaultSubscription));

            clientMocks.LoadRdfeSubscriptions(rdfeSubscriptions);
            clientMocks.LoadCsmSubscriptions(csmSubscriptions);
            clientMocks.LoadTenants(tenants);

            AzureSession.ClientFactory = new MockClientFactory(new object[] { clientMocks.RdfeSubscriptionClientMock.Object,
                clientMocks.CsmSubscriptionClientMock.Object });

            var mockFactory = new MockTokenAuthenticationFactory();
            if (tokenProvider != null)
            {
                mockFactory.TokenProvider = tokenProvider;
            }

            AzureSession.AuthenticationFactory = mockFactory;
        }

        private void SetMockData()
        {
            commonTenant = new TenantIdDescription
            {
                Id = "Common",
                TenantId = "Common"
            };
            guestTenant = new TenantIdDescription
            {
                Id = "Guest",
                TenantId = "Guest"
            };
            rdfeSubscription1 = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Common"
            };
            rdfeSubscription2 = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Common"
            };
            guestRdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1C",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Guest"
            };
            csmSubscription1 = new CSMSubscription
            {
                Id = "Subscriptions/36E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "CsmSub1",
                State = "Active",
                SubscriptionId = "36E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            csmSubscription1withDuplicateId = new CSMSubscription
            {
                Id = "Subscriptions/16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "RdfeSub1",
                State = "Active",
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            csmSubscription2 = new CSMSubscription
            {
                Id = "Subscriptions/46E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "CsmSub2",
                State = "Active",
                SubscriptionId = "46E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            guestCsmSubscription = new CSMSubscription
            {
                Id = "Subscriptions/76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1D",
                DisplayName = "CsmGuestSub",
                State = "Active",
                SubscriptionId = "76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1D"
            };
            azureSubscription1 = new AzureSubscription
            {
                Id = new Guid("56E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"),
                Name = "LocalSub1",
                Environment = "Test",
                Account = "test",
                Properties = new Dictionary<AzureSubscription.Property, string>
                {
                    { AzureSubscription.Property.Default, "True" } 
                }
            };
            azureSubscription2 = new AzureSubscription
            {
                Id = new Guid("66E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"),
                Name = "LocalSub2",
                Environment = "Test",
                Account = "test"
            };
            azureSubscription3withoutUser = new AzureSubscription
            {
                Id = new Guid("76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"),
                Name = "LocalSub3",
                Environment = "Test",
            };
            azureEnvironment = new AzureEnvironment
            {
                Name = "Test",
                Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                {
                    { AzureEnvironment.Endpoint.ServiceManagement, "https://umapi.rdfetest.dnsdemo4.com:8443/" },
                    { AzureEnvironment.Endpoint.ManagementPortalUrl, "https://windows.azure-test.net" },
                    { AzureEnvironment.Endpoint.AdTenant, "https://login.windows-ppe.net/" },
                    { AzureEnvironment.Endpoint.ActiveDirectory, "https://login.windows-ppe.net/" },
                    { AzureEnvironment.Endpoint.Gallery, "https://current.gallery.azure-test.net" },
                    { AzureEnvironment.Endpoint.ResourceManager, "https://api-current.resources.windows-int.net/" },
                }
            };
            azureAccount = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    { AzureAccount.Property.Subscriptions, azureSubscription1.Id + "," + azureSubscription2.Id } 
                }
            };
            newProfileDataPath = System.IO.Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            oldProfileDataPath = System.IO.Path.Combine(AzureSession.ProfileDirectory, AzureSession.OldProfileFile);
            oldProfileDataPathError = System.IO.Path.Combine(AzureSession.ProfileDirectory, AzureSession.OldProfileFileBackup);
            oldProfileData = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Extensions"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://current.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>http://go.microsoft.com/fwlink/?LinkId=254433</ManagementPortalUrl>
                      <Name>Current</Name>
                      <PublishSettingsFileUrl>d:\Code\azure.publishsettings</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-current.resources.windows-int.net/</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://umapi.rdfetest.dnsdemo4.com:8443/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://df.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>https://windows.azure-test.net</ManagementPortalUrl>
                      <Name>Dogfood</Name>
                      <PublishSettingsFileUrl>https://auxnext.windows.azure-test.net/publishsettings/index</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-dogfood.resources.windows-int.net</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://management-preview.core.windows-int.net/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                  </Environments>
                  <Subscriptions>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId>123</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management-preview.core.windows-int.net/</ManagementEndpoint>
                      <Name>Test 2</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint>https://login.windows.net/</ActiveDirectoryEndpoint>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <ActiveDirectoryTenantId>72f988bf-86f1-41af-91ab-2d7cd011db47</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E09</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test 3</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>d1e52cbc-b073-42e2-a0a0-c2f547118a6f</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E09</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.chinacloudapi.cn/</ManagementEndpoint>
                      <Name>Mooncake Test</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>c14d7dc5-ed4d-4346-a02f-9f1bcf78fb66</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                  </Subscriptions>
                </ProfileData>";

            oldProfileDataBadSubscription = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Extensions"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments>                    
                  </Environments>
                  <Subscriptions>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test Nill ID</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>Bad Data</ManagementEndpoint>
                      <Name>Test Bad Management Endpoint</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint i:nil=""true""/>
                      <Name>Test Null Management Endpoint</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint>https://login.windows.net/</ActiveDirectoryEndpoint>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <ActiveDirectoryTenantId>72f988bf-86f1-41af-91ab-2d7cd011db47</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E99</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test Bad Cert</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>d1e52cbc-b073-42e2-a0a0-c2f547118a6f</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>                    
                  </Subscriptions>
                </ProfileData>";

            oldProfileDataCorruptedFile = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Extensions"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments bad>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://current.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>http://go.microsoft.com/fwlink/?LinkId=254433</ManagementPortalUrl>
                      <Name>Current</Name>
                      <PublishSettingsFileUrl>d:\Code\azure.publishsettings</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-current.resources.windows-int.net/</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://umapi.rdfetest.dnsdemo4.com:8443/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                  <Subscriptions>                    
                  </Subscriptions>
                </ProfileData>";

            jsonProfileWithoutAccount = @"{
              ""Environments"": [],
              ""Subscriptions"": [  
                {
                  ""Id"": ""7e11f45f-70e6-430a-a4fc-af338aa22c11"",
                  ""Name"": ""Test"",
                  ""Environment"": ""AzureCloud"",
                  ""Account"": ""test@mail.com"",
                  ""Properties"": {
                    ""SupportedModes"": ""AzureServiceManagement"",
                    ""Default"": ""True"",
                    ""StorageAccount"": ""rjfmmanagement""
                  }
                }
              ],
              ""Accounts"": []
            }";

            jsonProfileWithBadData = @"{
              ""Environments"": [],
              ""Subscriptions"": {  
                {
                  ""Id"": ""7e11f45f-70e6-430a-a4fc-af338aa22c11"",
                  ""Name"": ""Test"",
                  ""Environment"": ""AzureCloud"",
                  ""Account"": ""test@mail.com"",
                  ""Properties"": {
                    ""SupportedModes"": ""AzureServiceManagement"",
                    ""Default"": ""True"",
                    ""StorageAccount"": ""rjfmmanagement""
                  }
                }
              ],
              ""Accounts"": []
            }";
        }
    }
}
