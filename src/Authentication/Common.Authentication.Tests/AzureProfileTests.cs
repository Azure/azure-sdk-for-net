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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Common.Authentication.Test
{
    public class AzureProfileTests
    {
        [Fact]
        public void ProfileSaveDoesNotSerializeContext()
        {
            var dataStore = new MockDataStore();
            var currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSession.DataStore = dataStore;
            var client = new ProfileClient(currentProfile);
            var tenant = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                Endpoints = { { AzureEnvironment.Endpoint.ActiveDirectory, "http://contoso.com" } }
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
                Properties = { { AzureAccount.Property.Tenants, tenant } }
            };
            var sub = new AzureSubscription
            {
                Account = account.Id,
                Environment = environment.Name,
                Id = new Guid(),
                Name = "Contoso Test Subscription",
                Properties = { { AzureSubscription.Property.Tenants, tenant } }
            };

            client.AddOrSetEnvironment(environment);
            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(sub);

            currentProfile.Save();

            var profileFile = currentProfile.ProfilePath;
            string profileContents = dataStore.ReadFileAsText(profileFile);
            var readProfile = JsonConvert.DeserializeObject<Dictionary<string, object>>(profileContents);
            Assert.False(readProfile.ContainsKey("DefaultContext"));
            AzureProfile parsedProfile = new AzureProfile();
            var serializer = new JsonProfileSerializer();
            Assert.True(serializer.Deserialize(profileContents, parsedProfile));
            Assert.NotNull(parsedProfile);
            Assert.NotNull(parsedProfile.Environments);
            Assert.True(parsedProfile.Environments.ContainsKey(environment.Name));
            Assert.NotNull(parsedProfile.Accounts);
            Assert.True(parsedProfile.Accounts.ContainsKey(account.Id));
            Assert.NotNull(parsedProfile.Subscriptions);
            Assert.True(parsedProfile.Subscriptions.ContainsKey(sub.Id));
        }

        [Fact]
        public void ProfileSerializeDeserializeWorks()
        {
            var dataStore = new MockDataStore();
            var currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSession.DataStore = dataStore;
            var client = new ProfileClient(currentProfile);
            var tenant = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                Endpoints = { { AzureEnvironment.Endpoint.ActiveDirectory, "http://contoso.com" } }
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
                Properties = { { AzureAccount.Property.Tenants, tenant } }
            };
            var sub = new AzureSubscription
            {
                Account = account.Id,
                Environment = environment.Name,
                Id = new Guid(),
                Name = "Contoso Test Subscription",
                Properties = { { AzureSubscription.Property.Tenants, tenant } }
            };

            client.AddOrSetEnvironment(environment);
            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(sub);

            AzureProfile deserializedProfile;
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, currentProfile);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                deserializedProfile = (AzureProfile)bf.Deserialize(ms);
            }
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = JsonConvert.SerializeObject(currentProfile);
            var jDeserializedProfile = JsonConvert.SerializeObject(deserializedProfile);
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
        }

        [Fact]
        public void AccountMatchingIgnoresCase()
        {
            var profile = new AzureProfile();
            string accountName = "howdy@contoso.com";
            string accountNameCase = "Howdy@Contoso.com";
            var subscriptionId = Guid.NewGuid();
            var tenantId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = accountName,
                Type = AzureAccount.AccountType.User
            };

            account.SetProperty(AzureAccount.Property.Subscriptions, subscriptionId.ToString());
            account.SetProperty(AzureAccount.Property.Tenants, tenantId.ToString());
            var subscription = new AzureSubscription
            {
                Id = subscriptionId,
                Account = accountNameCase,
                Environment = EnvironmentName.AzureCloud
            };
            
            subscription.SetProperty(AzureSubscription.Property.Default, "true");
            subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            profile.Accounts.Add(accountName, account);
            profile.Subscriptions.Add(subscriptionId, subscription);
            Assert.NotNull(profile.DefaultContext);
            Assert.NotNull(profile.DefaultContext.Account);
            Assert.NotNull(profile.DefaultContext.Environment);
            Assert.NotNull(profile.DefaultContext.Subscription);
            Assert.Equal(account, profile.DefaultContext.Account);
            Assert.Equal(subscription, profile.DefaultContext.Subscription);
        }

        [Fact]
        public void GetsCorrectContext()
        {
            AzureProfile profile = new AzureProfile();
            string accountId = "accountId";
            Guid subscriptionId = Guid.NewGuid();
            profile.Accounts.Add(accountId, new AzureAccount { Id = accountId, Type = AzureAccount.AccountType.User });
            profile.Subscriptions.Add(subscriptionId, new AzureSubscription
            {
                Account = accountId,
                Environment = EnvironmentName.AzureChinaCloud,
                Name = "hello",
                Id = subscriptionId
            });
            profile.DefaultSubscription = profile.Subscriptions[subscriptionId];
            AzureContext context = profile.DefaultContext;

            Assert.Equal(accountId, context.Account.Id);
            Assert.Equal(subscriptionId, context.Subscription.Id);
            Assert.Equal(EnvironmentName.AzureChinaCloud, context.Environment.Name);
        }
    }
}
