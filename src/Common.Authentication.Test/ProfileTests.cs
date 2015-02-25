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
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Common.Authentication.Test
{
    public class ProfileTests
    {
        [Fact]
        public void ProfileSaveDoesNotSerializeContext()
        {
            var dataStore = new MockDataStore();
            AzureSession.CurrentProfile = AzureSession.InitializeDefaultProfile();
            AzureSession.DataStore = dataStore;
            var client = new ProfileClient(AzureSession.CurrentProfile);
            var tenant = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                Endpoints = { {AzureEnvironment.Endpoint.ActiveDirectory, "http://contoso.com" } }
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
                Properties = {{AzureAccount.Property.Tenants, tenant}}
            };
            var sub = new AzureSubscription
            {
                Account = account.Id,
                Environment = environment.Name,
                Id = new Guid(),
                Name ="Contoso Test Subscription",
                Properties = {{AzureSubscription.Property.Tenants, tenant}}
            };

            client.AddOrSetEnvironment(environment);
            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(sub);

            AzureSession.CurrentProfile.Save();

            var profileFile = AzureSession.CurrentProfile.ProfilePath;
            string profileContents = dataStore.ReadFileAsText(profileFile);
            var readProfile = JsonConvert.DeserializeObject<Dictionary<string, object>>(profileContents);
            Assert.False(readProfile.ContainsKey("Context"));
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
    }
}
