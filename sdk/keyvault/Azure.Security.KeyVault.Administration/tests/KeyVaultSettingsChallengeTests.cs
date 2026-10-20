// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [NonParallelizable]
    public class KeyVaultSettingsChallengeTests : ClientTestBase
    {
        public KeyVaultSettingsChallengeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        [TearDown]
        public void ClearCache()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public void PolicyIsCompiledIntoClientAssembly()
        {
            Assert.That(typeof(ChallengeBasedAuthenticationPolicy).Assembly, Is.SameAs(typeof(KeyVaultSettingsClient).Assembly));
        }

        [Test]
        public async Task StrictClientRevalidatesChallengeSeededByLenientClient(
            [Values(
                "https://attacker.example",
                "https://resource.example@managedhsm.azure.net",
                "https://@managedhsm.azure.net",
                "relative-resource",
                "https://managedhsm.azure.net:invalid")] string resource,
            [Values("resource", "scope")] string parameter,
            [Values(false, true)] bool strictFirst)
        {
            Uri endpoint = new("https://cache-client.managedhsm.azure.net");
            string scope = resource + "/.default";
            string value = parameter == "scope" ? scope : resource;
            MockResponse Challenge() => new MockResponse(401).WithHeader(
                "WWW-Authenticate",
                string.Concat("Bearer ", "authorization=\"https://login.microsoftonline.com/common\", ", parameter, "=\"", value, "\""));
            MockResponse Success() => new MockResponse(200).WithJson(@"{""settings"":[]}");

            int seedTokenRequests = 0;
            MockCredential seedCredential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    seedTokenRequests++;
                    CollectionAssert.AreEqual(new[] { scope }, context.Scopes);
                }
            };
            MockTransport seedTransport = new(Challenge(), Success());
            using KeyVaultSettingsClient lenientClient = InstrumentClient(new KeyVaultSettingsClient(
                endpoint, seedCredential, new KeyVaultAdministrationClientOptions
                {
                    DisableChallengeResourceVerification = true,
                    Transport = seedTransport,
                }));

            int strictTokenRequests = 0;
            MockCredential strictCredential = new() { GetTokenCallback = (_, _) => strictTokenRequests++ };
            MockTransport strictTransport = new(Challenge(), Success());
            using KeyVaultSettingsClient strictClient = InstrumentClient(new KeyVaultSettingsClient(
                endpoint, strictCredential, new KeyVaultAdministrationClientOptions { Transport = strictTransport }));

            if (strictFirst)
            {
                Assert.ThrowsAsync<InvalidOperationException>(async () => await strictClient.GetSettingsAsync());
                Assert.That(strictTokenRequests, Is.Zero);
                Assert.That(strictTransport.Requests.Count, Is.EqualTo(1));
                Assert.That(strictTransport.SingleRequest.Headers.Contains("Authorization"), Is.False);
            }

            Assert.That((await lenientClient.GetSettingsAsync()).Value.Settings, Is.Empty);
            Assert.That(seedTokenRequests, Is.EqualTo(1));
            Assert.That(seedTransport.Requests.Count, Is.EqualTo(2));
            Assert.That(seedTransport.Requests[1].Headers.Contains("Authorization"), Is.True);

            int requestsBeforeRejection = strictTransport.Requests.Count;
            for (int attempt = 0; attempt < 2; attempt++)
            {
                InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
                    async () => await strictClient.GetSettingsAsync());
                StringAssert.DoesNotContain(resource, exception.Message);
            }
            Assert.That(strictTokenRequests, Is.Zero);
            Assert.That(strictTransport.Requests.Count, Is.EqualTo(requestsBeforeRejection));
        }
    }
}
