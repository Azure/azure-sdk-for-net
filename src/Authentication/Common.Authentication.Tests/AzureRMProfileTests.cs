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
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Common.Authentication.Test
{
    public class AzureRMProfileTests
    {
        [Fact]
        public void ProfileSerializeDeserializeWorks()
        {
            var dataStore = new MockDataStore();
            AzureSession.DataStore = dataStore;
            var currentProfile = new AzureRMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            var tenantId = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                Endpoints = { { AzureEnvironment.Endpoint.ActiveDirectory, "http://contoso.com" } }
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
                Properties = { { AzureAccount.Property.Tenants, tenantId } }
            };
            var sub = new AzureSubscription
            {
                Account = account.Id,
                Environment = environment.Name,
                Id = new Guid(),
                Name = "Contoso Test Subscription",
                Properties = { { AzureSubscription.Property.Tenants, tenantId } }
            };
            var tenant = new AzureTenant
            {
                Id = new Guid(tenantId),
                Domain = "contoso.com"
            };

            currentProfile.Context = new AzureContext(sub, account, environment, tenant);
            currentProfile.Environments[environment.Name] = environment;
            currentProfile.Context.TokenCache = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 };

            AzureRMProfile deserializedProfile;
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, currentProfile);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                deserializedProfile = (AzureRMProfile)bf.Deserialize(ms);
            }
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = currentProfile.ToString();
            var jDeserializedProfile = deserializedProfile.ToString();
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
        }

        [Fact]
        public void SavingProfileWorks()
        {
            string expected = @"{
  ""Environments"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    }
  },
  ""Context"": {
    ""Account"": {
      ""Id"": ""me@contoso.com"",
      ""Type"": 1,
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Subscription"": {
      ""Id"": ""00000000-0000-0000-0000-000000000000"",
      ""Name"": ""Contoso Test Subscription"",
      ""Environment"": ""testCloud"",
      ""Account"": ""me@contoso.com"",
      ""State"": ""Enabled"",
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Environment"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    },
    ""Tenant"": {
      ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
      ""Domain"": ""contoso.com""
    },
    ""TokenCache"": ""AQIDBAUGCAkA""
  }
}";
            string path = Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.DataStore = dataStore;
            AzureRMProfile profile = new AzureRMProfile(path);
            var tenantId = new Guid("3c0ff8a7-e8bb-40e8-ae66-271343379af6");
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                Endpoints = { { AzureEnvironment.Endpoint.ActiveDirectory, "http://contoso.com" } }
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
                Properties = { { AzureAccount.Property.Tenants, tenantId.ToString() } }
            };
            var sub = new AzureSubscription
            {
                Account = account.Id,
                Environment = environment.Name,
                Id = new Guid(),
                Name = "Contoso Test Subscription",
                State = "Enabled",
                Properties = { { AzureSubscription.Property.Tenants, tenantId.ToString() } }
            };
            var tenant = new AzureTenant
            {
                Id = tenantId,
                Domain = "contoso.com"
            };
            profile.Context = new AzureContext(sub, account, environment, tenant);
            profile.Environments[environment.Name] = environment;
            profile.Context.TokenCache = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 };
            profile.Save();
            string actual = dataStore.ReadFileAsText(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoadingProfileWorks()
        {
            string contents = @"{
  ""Environments"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    }
  },
  ""Context"": {
    ""TokenCache"": ""AQIDBAUGCAkA"",
    ""Account"": {
      ""Id"": ""me@contoso.com"",
      ""Type"": 1,
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Subscription"": {
      ""Id"": ""00000000-0000-0000-0000-000000000000"",
      ""Name"": ""Contoso Test Subscription"",
      ""Environment"": ""testCloud"",
      ""Account"": ""me@contoso.com"",
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Environment"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    },
    ""Tenant"": {
      ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
      ""Domain"": ""contoso.com""
    }
  }
}";
            string path = Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.DataStore = dataStore;
            dataStore.WriteFile(path, contents);
            var profile = new AzureRMProfile(path);
            Assert.Equal(4, profile.Environments.Count);
            Assert.Equal("3c0ff8a7-e8bb-40e8-ae66-271343379af6", profile.Context.Tenant.Id.ToString());
            Assert.Equal("contoso.com", profile.Context.Tenant.Domain);
            Assert.Equal("00000000-0000-0000-0000-000000000000", profile.Context.Subscription.Id.ToString());
            Assert.Equal("testCloud", profile.Context.Environment.Name);
            Assert.Equal("me@contoso.com", profile.Context.Account.Id);
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 }, profile.Context.TokenCache);
            Assert.Equal(path, profile.ProfilePath);
        }
    }
}
