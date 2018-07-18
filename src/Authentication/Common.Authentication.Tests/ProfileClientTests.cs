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
using Microsoft.Azure.Subscriptions.Csm.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Xunit;
using CSMSubscription = Microsoft.Azure.Subscriptions.Csm.Models.Subscription;
using RDFESubscription = Microsoft.Azure.Subscriptions.Rdfe.Models.Subscription;

namespace Common.Authentication.Test
{
    public class ProfileClientTests
    {
        private string oldProfileData;
        private string oldProfileDataBadSubscription;
        private string oldProfileDataCorruptedFile;
        private string oldProfileDataPath;
        private string oldProfileDataPathError;
        private string newProfileDataPath;
        private string defaultSubscription = "06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F";
        private string dummyCertificate = "MIIKJAIBAzCCCeQGCSqGSIb3DQEHAaCCCdUEggnRMIIJzTCCBe4GCSqGSIb3DQEHAaCCBd8EggXbMIIF1zCCBdMGCyqGSIb3DQEMCgECoIIE7jCCBOowHAYKKoZIhvcNAQwBAzAOBAjilB4DFutYJwICB9AEggTItMCor/6dq+ynHyoo82U2N8bT9fBn57xuvF4zTtZdl503n+q48ZE5SLcUFoeAZkrYoCiyPn4ayVA4pfAHou5I2XEG1B4YF46hD0Bz0igWRSrsVigdoYP98BGGaMgl43d9AQGeV8iJ3d3In/TxMGjHUYzZwoIg1jE7xhQ8dMr2Xenw8pLrxl8FybI1isyxzAUjFE7E/Znv9DYi83VNwjC1uPg8q16PzXUQ/smFVzoZMtvmp8MxPrnI/gHqcS5g7SnnisTLmJcjqdLVywBZqiMo1ALs90EEgc7qgbim9lxGczUh+SI9cj2m5w9XMmXro4XJNJTLFG26DDOVMPfMSr9ij9P4rmxckVK7nHrGhQpshrLr37dF5KGFo6mh79VUadbwn/a4rXjfX9gXm5N/ZS8wq3U4/4Pl7t5N+bwB5izt8JG4aMhX6M6jshNrpe/gZHI9u6jNAo1yRxNfBdoxA7P2sZdlHO4CYTc9zZcZqTgH2QjRLTelIDn17PEQL9L4rEzqhT322WMzNnSMH9TCu3D5l2RuO6hsHl0JK4saiq3s04kkYoLXF9i+ovS0xSmu0zxemnFAGB1q1mlwoWoD06zlXEjHM2Q3T2b8ip1tK6/GFpU8Qs5BOUDanBOCqVLWlyvM/ilXUyN9cyLRMKM1sgEmn5ue0wsZlflU6egqChF8qjSJzq/34FgTjPazvkXkXv0e2vBz5+qzeC/1R8xySdFoehglny42VTkCRH4BzhoXf+MrfrC6tW85WCTKOj8SiTSzYXRragIwfG8RyLViOzdIW9pEAJF3UOloKOGGL1NREAnRPgxm9UVxD1oUj+pqYkPRRXcHuEnbiYEqE8Dgwk6GaSVOZ4CKjKAcapOwwW8bTxHgFOCrwgZhxIFXQhIZVoH8NphqN2WWwIUPa1gsc3uPwVXecgt8y8S01QEYCCFo9dT5sBS0rAOXMTOnSudWSHvz7c36IJSG2KyJwW3YO2UopIQ1V14MBZQhwUyddUILeuOy50u1j2eVOV3XESHO99oNP9FfalmgZw19LQDqX8S861x1w+GuU/NG//LZ0aXXaw1IhddIMZlpZVTADMunXIJbd0OiunfblXFwGZ33M1y/wGvFAZ6ofOuZv6vM0kmtufg3AHl/Vg+jzLOp1bYbKx4f7FHoYAerV88EA/ELXr2NTOLwwRYdk0cLWk4VY2lCLs8lcyoIUrcOS/+af8oX8dgJo9qkx2AiKp6AgYAWwrdpolOH7sMLmtu1rrthoMesExLz6xpUq/rYrWQJuyXWUmwbdxpDYFP8spqcW3KdbroNWhPEvM0tdocSK6lPWNnFMgqbb2qJJqjyV87LBZPEpHI8TPraofE7h4NWjXx/OqA6/dF1t3RvrvYqyC7kvrnaJ2LWfQI/88K9s7LAVvfDIbxWtIadrGXlo4gbtbQDSFzjve123DngBJkXqpzqRoL7mdpFvsgpg0upIKQ1fIbtaksC115g8BGBOzwGlo0Y3f4+ob6++OkePHoLkGhLahCMyDmGV1mxFz3ZUkXyxmfPSeynwXe/N8TxeZ2ixLZMF3sa61CpFsuHfEmVEetFxP5t3rrO5ZIbE87KVtvl6jCr8JQ3h81TZJBaeu8iiNC0MVspJpNQ/irYFElTMYHRMBMGCSqGSIb3DQEJFTEGBAQBAAAAMFsGCSqGSIb3DQEJFDFOHkwAewA0ADgANQBFADQAOQBCADYALQBFAEUARQA4AC0ANAA3ADUAQgAtADgAOQAwAEQALQA5ADcAQQA3ADYARgAyADQANgBEADkAMwB9MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAG8AZgB0AHcAYQByAGUAIABLAGUAeQAgAFMAdABvAHIAYQBnAGUAIABQAHIAbwB2AGkAZABlAHIwggPXBgkqhkiG9w0BBwagggPIMIIDxAIBADCCA70GCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECG9kWMFPd2j2AgIH0ICCA5AUBLyrnhFVIYZKNWVLOWn0nfwmhADWS2FA3LGyGirb/lgpPcolLiQwGnXih0xxESn1CsZcWDpXiUvAfjQF1kxKHyCIUQBkrKQliYIT+RErliVuAY/vv1YW2Zj+bPUtTZKXUDzIPjNgb43+uxvf/wu+gGhAV/dV5oIWLjFhC1u4+Gp/LA5C6j60NtBXG7barSflAWTSOjGt2IIb5mBrUw+GkrhoYOqA+HYG40j2fkmkWpMCkImzcxxEM65ZElGUt7H1QY+GSRAxt7icA5ka9L+A0UM8a1SCFhbBK6Voo0IAkBZctJ6I7h4znhoHtqMDYYzraaYDVAK4SPdwOUMUyYdai0QwOYSL3frwVzC/ZHvCJkRmOsQXj9U44OGoXXrJ4rWIQIkcxFO3rEC3alI9lV5h5w73DWQRjex8Nz214B1yBRdlkoC/HQpgJ6IwFfEyJOn/lGgqkRPbgntTKSjNQZr5Ot60Z1SUYmmcMTpB8jRg+hy0LbWmx+79q9ERUnLO4yrtcXjQza12/FwAdpJOwbFrXMZb3QcuhQfn9aDF9/iNRkhTdxDmumS/C5gjZSYBzTugGDWsyS1hqws7LaYfcs6aWWRafqxt68cpNy4FaNXZ3XwXRVzuH+brnGvnWXRqhzwCbeGxEKDCEPxO9hO8NVrndsGlGfTZmxfTkKnPyRPD6vk4BG0Rc5BniyrmhnaZgSq0M04MeoAjp1s6S8CcIG73H5KkmoqQwSiKUbY3aA15nxqYhQj6L83WK5dPnVlmaV/xOeqkggzsdkaa+eQfA1e5RR27Gkyr5Rl20PQUR6J/sIGWIVCSSaqD2kxmDTODEORsF7jhL4YXZr96hqvNWtyNncxrqvjPsaFi/P2JFxjfZ8wmnF1HDsVW4W/i8cdRTyEz7Go4kzoRvSvC2sCPRAMa3D+o341r7L0hBlCnFfMU5Le8jatMKsw+Nk1TeOc4Cvc+w3gczSKrlhJnPtJjVZ67kKe8Ror8mKOP6afSr27avEizUYvJcCpKztUM59ukEbM2chEb2rrFPWxnB67KaLF825pRm+6Nl3mx0jaPDgK2ToydGfuVBA+9TSpnuV26imsd+K2yL2nwrdvBJPE/t2lPzVIR0hnf4AJ8/9BR0vTGmxiWwy8VMxrS3PyouLPZMXAgdT6ddRVwmewNjTe5g/tciGazIW+nROgg6fsgyObMp7keONMvtFMrJQLa2oKarGkwNzAfMAcGBSsOAwIaBBQXFDnqplMX7OuyknHK7B+HA/N8tAQUsL21+IY37DPL968vhVzqz09W/so=";
        private RDFESubscription rdfeSubscription1;
        private RDFESubscription rdfeSubscription2;
        private CSMSubscription csmSubscription1;
        private CSMSubscription csmSubscription1withDuplicateId;
        private CSMSubscription csmSubscription2;
        private AzureSubscription azureSubscription1;
        private AzureSubscription azureSubscription2;
        private AzureSubscription azureSubscription3withoutUser;
        private AzureEnvironment azureEnvironment;
        private AzureAccount azureAccount;
        private TenantIdDescription commonTenant;
        private TenantIdDescription guestTenant;
        private RDFESubscription guestRdfeSubscription;
        private CSMSubscription guestCsmSubscription;
        private AzureProfile currentProfile;

        public ProfileClientTests()
        {
            SetMockData();
            currentProfile = new AzureProfile();
        }

        [Fact]
        public void ProfileMigratesOldData()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        public void NewProfileFromCertificateWithNullsThrowsArgumentNullException()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(null, Guid.NewGuid(), new X509Certificate2(), "foo"));
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"], Guid.NewGuid(), null, "foo"));
        }

        [Fact]
        public void NewProfileFromCertificateReturnsProfile()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var subscriptionId = Guid.NewGuid();
            var certificate = new X509Certificate2(Convert.FromBase64String(dummyCertificate));

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                subscriptionId, certificate, null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.Environment);
            Assert.Equal(subscriptionId, newProfile.DefaultSubscription.Id);
            Assert.Equal(certificate.Thumbprint, newProfile.DefaultSubscription.Account);
            Assert.False(newProfile.DefaultSubscription.Properties.ContainsKey(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileFromAdCredentialsWithNullsThrowsArgumentNullException()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(null, Guid.NewGuid(), new AzureAccount(), null, "foo"));
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"], Guid.NewGuid(), (AzureAccount)null, null, "foo"));
        }

        [Fact]
        public void NewProfileFromADReturnsProfile()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var newAccount = new AzureAccount {Id = "foo"};
            newAccount.Properties[AzureAccount.Property.Tenants] = "123";

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                new Guid(csmSubscription1.SubscriptionId), newAccount, null, null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.Environment);
            Assert.Equal(new Guid(csmSubscription1.SubscriptionId), newProfile.DefaultSubscription.Id);
            Assert.Equal(newAccount.Id, newProfile.DefaultSubscription.Account);
            Assert.False(newProfile.DefaultSubscription.Properties.ContainsKey(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileWithAccessTokenReturnsProfile()
        {
            //SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                new Guid(csmSubscription1.SubscriptionId), "accessToken", "accountId", null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.Environment);
            Assert.Equal(new Guid(csmSubscription1.SubscriptionId), newProfile.DefaultSubscription.Id);
            Assert.Equal("accountId", newProfile.DefaultSubscription.Account);
            Assert.Equal(AzureAccount.AccountType.AccessToken, newProfile.Context.Account.Type);
            Assert.Equal("accessToken", newProfile.Context.Account.Properties[AzureAccount.Property.AccessToken]);
            Assert.False(newProfile.DefaultSubscription.Properties.ContainsKey(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileFromADWithMismatchSubscriptionThrows()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            AzureProfile newProfile = new AzureProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var newAccount = new AzureAccount { Id = "foo" };
            newAccount.Properties[AzureAccount.Property.Tenants] = "123";

            Assert.Throws<ArgumentException>(() => client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                Guid.NewGuid(), newAccount, null, null));
        }

        [Fact]
        public void ProfileMigratesOldDataOnce()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client1 = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));

            ProfileClient client2 = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        public void ProfileMigratesAccountsAndDefaultSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataBadSubscription;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataCorruptedFile;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(
                    new AzureAccount { 
                        Id = "test", 
                        Type = AzureAccount.AccountType.User }, 
                    AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], 
                    null);

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
            SetMocks(new[] { rdfeSubscription1 }.ToList(), 
                     new List<Microsoft.Azure.Subscriptions.Csm.Models.Subscription>(),
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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
        /// Verify that multiple accounts can be added if a user has different identities in different domains, linked to the same login
        /// Verify that subscriptions with admin access for all accounts are added
        /// </summary>
        [Fact]
        public void AddAzureAccountWithImpersonatedGuestWithSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(), 
                     new List<Microsoft.Azure.Subscriptions.Csm.Models.Subscription>(), 
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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
        /// Test that when accountId is added more than once with different capitalization, only a single accountId is added
        /// and that accounts can be retrieved case-insensitively
        /// </summary>
        [Fact]
        public void AddAzureAccountIsCaseInsensitive()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(), 
                     new List<Microsoft.Azure.Subscriptions.Csm.Models.Subscription>(), 
                     new[] { commonTenant, guestTenant }.ToList(),
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
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.Subscriptions[azureSubscription1.Id] = azureSubscription1;
            client.Profile.Subscriptions[azureSubscription2.Id] = azureSubscription2;
            client.Profile.Subscriptions[azureSubscription3withoutUser.Id] = azureSubscription3withoutUser;
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.Profile.Environments[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test2").ToList();

            Assert.Equal(0, account.Count);
        }

        [Fact]
        public void GetAzureAccountReturnsAllAccountsWithNullUser()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
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
            currentProfile.DefaultSubscription = azureSubscription1;

            client.RemoveAccount(azureAccount.Id);

            Assert.Equal("test2", currentProfile.Context.Account.Id);
            Assert.Equal("test2", currentProfile.Context.Subscription.Account);
            Assert.Equal(azureSubscription1.Id, currentProfile.Context.Subscription.Id);

            client.RemoveAccount("test2");

            Assert.Null(currentProfile.Context.Account);
            Assert.Null(currentProfile.Context.Subscription);
            Assert.Null(currentProfile.Context.Environment);
        }

        [Fact]
        public void AddAzureEnvironmentAddsEnvironment()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            Assert.Equal(2, client.Profile.Environments.Count);

            Assert.Throws<ArgumentNullException>(() => client.AddOrSetEnvironment(null));
            var env = client.AddOrSetEnvironment(azureEnvironment);

            Assert.Equal(3, client.Profile.Environments.Count);
            Assert.Equal(env, azureEnvironment);
        }

        [Fact]
        public void GetAzureEnvironmentsListsEnvironments()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetEnvironment(azureEnvironment);
            
            var defaultEnv = client.GetEnvironmentOrDefault(null);

            Assert.Equal(EnvironmentName.AzureCloud, defaultEnv.Name);

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);

            Assert.Throws<ArgumentException>(() => client.GetEnvironmentOrDefault("bad"));
        }

        [Fact]
        public void GetCurrentEnvironmentReturnsCorrectValue()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(azureSubscription1);

            currentProfile.DefaultSubscription = azureSubscription1;

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);
        }

        [Fact]
        public void AddOrSetAzureSubscriptionChecksAndUpdates()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            currentProfile.DefaultSubscription = azureSubscription1;
            azureSubscription1.Properties[AzureSubscription.Property.StorageAccount] = "testAccount";
            Assert.Equal(azureSubscription1.Id, currentProfile.Context.Subscription.Id);
            Assert.Equal(azureSubscription1.Properties[AzureSubscription.Property.StorageAccount],
                currentProfile.Context.Subscription.Properties[AzureSubscription.Property.StorageAccount]);

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

            Assert.Equal(newSubscription.Id, currentProfile.Context.Subscription.Id);
            Assert.Equal(newSubscription.Id, newSubscriptionFromProfile.Id);
            Assert.Equal(newSubscription.Properties[AzureSubscription.Property.StorageAccount],
                currentProfile.Context.Subscription.Properties[AzureSubscription.Property.StorageAccount]);
            Assert.Equal(newSubscription.Properties[AzureSubscription.Property.StorageAccount],
                newSubscriptionFromProfile.Properties[AzureSubscription.Property.StorageAccount]);
        }

        [Fact]
        public void RemoveAzureSubscriptionChecksAndRemoves()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureSubscription1.Account);

            Assert.Equal(1, client.Profile.Subscriptions.Count);

            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            var subscription = client.RemoveSubscription(azureSubscription1.Name);

            Assert.Equal(0, client.Profile.Subscriptions.Count);
            Assert.Equal(azureSubscription1.Name, subscription.Name);
            Assert.Equal(1, log.Count);
            Assert.Equal(
                "The default subscription is being removed. Use Select-AzureSubscription -Default <subscriptionName> to select a new default subscription.",
                log[0]);
            Assert.Throws<ArgumentException>(() => client.RemoveSubscription("bad"));
            Assert.Throws<ArgumentNullException>(() => client.RemoveSubscription(null));
        }

        [Fact]
        public void RefreshSubscriptionsUpdatesAccounts()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.Accounts[azureAccount.Id] = azureAccount;

            var subscriptions = client.RefreshSubscriptions(client.Profile.Environments[EnvironmentName.AzureChinaCloud]);

            Assert.Equal(3, subscriptions.Count);
            Assert.Equal(3, subscriptions.Count(s => s.Account == "test"));
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(2, subscriptions.First(s => s.Id == new Guid(rdfeSubscription1.SubscriptionId)).GetPropertyAsArray(AzureSubscription.Property.SupportedModes).Count());
            Assert.Equal(1, subscriptions.Count(s => s.Id == new Guid(rdfeSubscription2.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsListsAllSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);

            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.Account);

            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);
            Assert.Equal(azureSubscription2.Id, currentProfile.Context.Subscription.Id);
            Assert.Equal(azureSubscription2.Account, currentProfile.Context.Account.Id);
            Assert.Equal(azureSubscription2.Environment, currentProfile.Context.Environment.Name);
            var notFoundEx = Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault("bad", null));
            var invalidEx = Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault(null, null));
            Assert.Contains("doesn't exist", notFoundEx.Message);
            Assert.Contains("non-null", invalidEx.Message);
        }

        [Fact]
        public void ClearDefaultAzureSubscriptionClearsDefault()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.Accounts[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);
            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.Account);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            client.ClearDefaultSubscription();

            Assert.Null(client.Profile.DefaultSubscription);
            Assert.Null(client.Profile.Context.Account);
            Assert.Null(client.Profile.Context.Environment);
            Assert.Null(client.Profile.Context.Subscription);
        }

        [Fact]
        public void ImportPublishSettingsLoadsAndReturnsSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            azureEnvironment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = "https://newmanagement.core.windows.net/";
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient(currentProfile);

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
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
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

            currentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            client = new ProfileClient(currentProfile);

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

        private void SetMocks(List<Microsoft.Azure.Subscriptions.Rdfe.Models.Subscription> rdfeSubscriptions,
            List<Microsoft.Azure.Subscriptions.Csm.Models.Subscription> csmSubscriptions,
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
                SubscriptionStatus = Microsoft.Azure.Subscriptions.Rdfe.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Common"
            };
            rdfeSubscription2 = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.Azure.Subscriptions.Rdfe.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Common"
            };
            guestRdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1C",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.Azure.Subscriptions.Rdfe.Models.SubscriptionStatus.Active,
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
            newProfileDataPath = Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            oldProfileDataPath = Path.Combine(AzureSession.ProfileDirectory, AzureSession.OldProfileFile);
            oldProfileDataPathError = Path.Combine(AzureSession.ProfileDirectory, AzureSession.OldProfileFileBackup);
            oldProfileData = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
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
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
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
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
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
        }
    }
}
