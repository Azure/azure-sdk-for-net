// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientTests : ClientTestBase
    {
        public KeyClientTests(bool isAsync) : base(isAsync)
        {
            KeyClientOptions options = new KeyClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new KeyClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public KeyClient Client { get; set; }

        [Test]
        public void CreateKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateKeyAsync(null, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync("name", default));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync(string.Empty, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateEcKeyAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateRsaKeyAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateOctKeyAsync(null));
        }

        [Test]
        public void UpdateKeyPropertiesArgumentValidation()
        {
            var keyOperations = new List<KeyOperation>() { KeyOperation.Sign };
            var key = new KeyProperties("name");

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(null, null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(null, keyOperations));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(key, null));
        }

        [Test]
        public void RestoreKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreKeyBackupAsync(null));
        }

        [Test]
        public void PurgeDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void GetKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetKeyAsync(string.Empty));
        }

        [Test]
        public void DeleteKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartDeleteKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartDeleteKeyAsync(string.Empty));
        }

        [Test]
        public void GetDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void RecoverDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartRecoverDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartRecoverDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void BackupKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.BackupKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupKeyAsync(string.Empty));
        }

        [Test]
        public void ImportKeyArgumentValidation()
        {
            var jwk = new JsonWebKey();
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync(string.Empty, jwk));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, jwk));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, null));
        }

        [Test]
        public void GetKeyVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetPropertiesOfKeyVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetPropertiesOfKeyVersionsAsync(string.Empty));
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetKeyAsync("test"));
        }

        [Test]
        public async Task InitialRequestTimesOut()
        {
            const string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            int requestIndex = 0;
            Func<MockRequest, MockResponse> factory = request =>
            {
                switch (requestIndex++)
                {
                    case 0:
                        // Mimics the exact exception thrown during the initial request.
                        throw new RequestFailedException("Operation timed out", new HttpRequestException("Operation timed out", new SocketException(60)));

                    case 1:
                        return new MockResponse(401)
                            .WithHeader("WWW-Authenticate", $@"Bearer authorization=""https://login.windows.net/{tenantId}"", resource=""https://vault.azure.net""")
                            .WithContent(@"{""error"":{""code"":""Unauthorized"",""message"":""Error validating token: IDX10223""}}");

                    case 2:
                        Assert.IsNotNull(request.Content);
                        Assert.IsTrue(request.Content.TryComputeLength(out long length));
                        Assert.AreNotEqual(0, length);

                        return new MockResponse(200)
                            // Copied from SessionRecords/KeyClientLiveTests/CreateRsaKey.json
                            .WithContent(@"{
  ""key"": {
    ""kid"": ""https://heathskeyvault.vault.azure.net/keys/625710934/ef3685592e1c4e839206aaa10f0f058e"",
    ""kty"": ""RSA"",
    ""key_ops"": [
      ""encrypt"",
      ""decrypt"",
      ""sign"",
      ""verify"",
      ""wrapKey"",
      ""unwrapKey""
    ],
    ""n"": ""7tp-vHhIdmj7phgSABe9eFb3WM3J8edzlZ9aXrBZFY6SlvCmSMPuHtNVteC_bFY42eqWb6xHz21Q8pSKmoD-ebPr00Rv2TK7k2miZRx-a_iF4hYWUMySVzUNszPoiRgUjEbEFpL2pPxpCVIO-C3nM2HPBUPZX5ATOUmO_Ioiw4vo_Q4pSaBXWrmT4Wf7c7WaVZ3KYofntuS0V4k0Q94fUyTVUEvWVeLg9Q_RhDVcY1pJX_cNaQUSm7v7yd6gPDKsEjC8HjGgV5QYWmO3ZBLnb0sY8Ond_iRWpBTM6dK7GB9W7jdvZd80azPbDxIhr68BWomwvRa_D19t0nSSGZDexQ"",
    ""e"": ""AQAB""
  },
  ""attributes"": {
    ""enabled"": true,
    ""created"": 1613807137,
    ""updated"": 1613807137,
    ""recoveryLevel"": ""Recoverable\u002BPurgeable"",
    ""recoverableDays"": 90
  }
}");

                    default:
                        // Should be done after the previous request.
                        throw new NotSupportedException("Should not have gotten this far");
                }
            };

            KeyClient client = InstrumentClient(
                new KeyClient(
                    new Uri("https://heathskeyvault.vault.azure.net"),
                    new MockCredential(),
                    new()
                    {
                        Transport = new MockTransport(factory),
                    }));

            KeyVaultKey key = await client.CreateRsaKeyAsync(new("625710934")
            {
                KeySize = 2048,
            });

            Assert.IsNotNull(key.Key);
        }

        private class MockCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new("mockaccesstoken=", DateTimeOffset.Now.AddMinutes(5));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new(GetToken(requestContext, cancellationToken));
        }
    }
}
