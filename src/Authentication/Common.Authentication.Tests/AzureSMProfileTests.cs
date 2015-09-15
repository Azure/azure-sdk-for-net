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
    public class AzureSMProfileTests
    {
        [Fact]
        public void ProfileSaveDoesNotSerializeContext()
        {
            var dataStore = new MockDataStore();
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSession.DataStore = dataStore;
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

            profile.Environments[environment.Name] = environment;
            profile.Accounts[account.Id] = account;
            profile.Subscriptions[sub.Id] = sub;

            profile.Save();

            var profileFile = profile.ProfilePath;
            string profileContents = dataStore.ReadFileAsText(profileFile);
            var readProfile = JsonConvert.DeserializeObject<Dictionary<string, object>>(profileContents);
            Assert.False(readProfile.ContainsKey("DefaultContext"));
            AzureSMProfile parsedProfile = new AzureSMProfile();
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
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSession.DataStore = dataStore;
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

            profile.Environments[environment.Name] = environment;
            profile.Accounts[account.Id] = account;
            profile.Subscriptions[sub.Id] = sub;

            AzureSMProfile deserializedProfile;
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, profile);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                deserializedProfile = (AzureSMProfile)bf.Deserialize(ms);
            }
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = JsonConvert.SerializeObject(profile);
            var jDeserializedProfile = JsonConvert.SerializeObject(deserializedProfile);
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
        }

        [Fact]
        public void AccountMatchingIgnoresCase()
        {
            var profile = new AzureSMProfile();
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
            Assert.NotNull(profile.Context);
            Assert.NotNull(profile.Context.Account);
            Assert.NotNull(profile.Context.Environment);
            Assert.NotNull(profile.Context.Subscription);
            Assert.Equal(account, profile.Context.Account);
            Assert.Equal(subscription, profile.Context.Subscription);
        }

        [Fact]
        public void GetsCorrectContext()
        {
            AzureSMProfile profile = new AzureSMProfile();
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
            AzureContext context = profile.Context;

            Assert.Equal(accountId, context.Account.Id);
            Assert.Equal(subscriptionId, context.Subscription.Id);
            Assert.Equal(EnvironmentName.AzureChinaCloud, context.Environment.Name);
        }
    }
}
