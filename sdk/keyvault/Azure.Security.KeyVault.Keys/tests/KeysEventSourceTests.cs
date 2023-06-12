// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [NonParallelizable]
    public class KeysEventSourceTests : ClientTestBase
    {
        private static readonly byte[] s_buffer = new byte[32];

        private const string KeyId = "https://localhost/keys/test";
        private TestEventListener _listener;

        static KeysEventSourceTests()
        {
            new Random().NextBytes(s_buffer);
        }

        public KeysEventSourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(KeysEventSource.Singleton, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [Test]
        public void MatchesNameAndGuid()
        {
            Type eventSourceType = typeof(KeysEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual("Azure-Security-KeyVault-Keys", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("657a121e-762e-50da-b233-05d7cdb24eb8"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }

        [TestCaseSource(nameof(GetAesOperations))]
        public async Task AlgorithmNotSupportedAes(string operation, Func<CryptographyClient, string, Task<object>> thunk)
        {
            using Aes aes = Aes.Create();
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(aes)
                {
                    Id = KeyId,
                },
            };

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":""test""}}");

            MockTransport transport = new MockTransport(_ => response);
            CryptographyClient client = CreateClient(key, transport);

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("AlgorithmNotSupported", e.EventName);
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [TestCaseSource(nameof(GetEcOperations), new object[] { true, true })]
        public async Task AlgorithmNotSupportedEc(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(new[] { KeyOperation.Sign, KeyOperation.Verify })
                {
                    Id = KeyId,
                    KeyType = KeyType.Ec,
                    CurveName = "invalid",
                },
            };

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":{value ?? @"""test"""}}}");

            CryptographyClient client = CreateClient(key, new MockTransport(_ => response));

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("AlgorithmNotSupported", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [TestCaseSource(nameof(GetRsaOperations), new object[] { true, true })]
        public async Task AlgorithmNotSupportedRsa(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
            using RSA rsa = RSA.Create();
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(rsa, includePrivateParameters: true)
                {
                    Id = KeyId,
                },
            };

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":{value ?? @"""test"""}}}");

            CryptographyClient client = CreateClient(key, new MockTransport(_ => response));

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.AlgorithmNotSupportedEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("AlgorithmNotSupported", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("algorithm"));
        }

        [TestCaseSource(nameof(GetRsaOperations), new object[] { true, true })]
        public async Task KeyTypeNotSupported(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
            MockResponse keyResponse = new MockResponse(200);
            keyResponse.SetContent($@"{{""key"":{{""kid"":""{KeyId}"",""kty"":""invalid""}}}}");

            // Get the same key as above and reset the stream.
            KeyVaultKey key = new KeyVaultKey();
            key.Deserialize(keyResponse.ContentStream);
            keyResponse.ContentStream.Position = 0;

            CryptographyClient client = CreateClient(key, new MockTransport(_ =>
            {
                keyResponse.ContentStream.Position = 0;
                return keyResponse;
                }
            ));

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.KeyTypeNotSupportedEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("KeyTypeNotSupported", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
            Assert.AreEqual("invalid", e.GetProperty<string>("keyType"));
        }

        [TestCaseSource(nameof(GetEcOperations), new object[] { false, true })]
        public async Task PrivateKeyRequiredEc(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
#if NET462
            Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net462.");
#endif

            KeyOperation[] keyOps = new[]
            {
                KeyOperation.Sign,
                KeyOperation.Verify,
            };

            using ECDsa ecdsa = ECDsa.Create();
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(ecdsa, includePrivateParameters: false, keyOps)
                {
                    Id = KeyId,
                },
            };

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":{value ?? @"""test"""}}}");

            CryptographyClient client = CreateClient(key, new MockTransport(_ => response));

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.PrivateKeyRequiredEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("PrivateKeyRequired", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
        }

        [TestCaseSource(nameof(GetRsaOperations), new object[] { false, true })]
        public async Task PrivateKeyRequiredRsa(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
            KeyOperation[] keyOps = new[]
            {
                KeyOperation.Encrypt,
                KeyOperation.Decrypt,
                KeyOperation.Sign,
                KeyOperation.Verify,
                KeyOperation.WrapKey,
                KeyOperation.UnwrapKey,
            };

            using RSA rsa = RSA.Create();
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(rsa, includePrivateParameters: false, keyOps)
                {
                    Id = KeyId,
                },
            };

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":{value ?? @"""test"""}}}");

            CryptographyClient client = CreateClient(key, new MockTransport(_ => response));

            object result = await thunk(client, "invalid");
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.PrivateKeyRequiredEvent);
            Assert.AreEqual(EventLevel.Verbose, e.Level);
            Assert.AreEqual("PrivateKeyRequired", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
        }

        [TestCaseSource(nameof(GetRsaOperations), new object[] { true, true })]
        public async Task CryptographicException(string operation, string value, Func<CryptographyClient, string, Task<object>> thunk)
        {
            using RSA rsa = RSA.Create();
            KeyVaultKey key = new KeyVaultKey
            {
                Key = new JsonWebKey(rsa, includePrivateParameters: true)
                {
                    Id = KeyId,
                },
            };

            Random rand = new Random();
            rand.NextBytes(key.Key.N);

            MockResponse response = new MockResponse(200);
            response.SetContent(@$"{{""kid"":""{KeyId}"",""value"":{value ?? @"""test"""}}}");

            CryptographyClient client = CreateClient(key, new MockTransport(_ => response), new ThrowingCryptographyProvider());

            object result = await thunk(client, null);
            Assert.IsNotNull(result);

            EventWrittenEventArgs e = _listener.SingleEventById(KeysEventSource.CryptographicExceptionEvent);
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("CryptographicException", e.EventName);
            Assert.AreEqual(operation, e.GetProperty<string>("operation"));
            StringAssert.StartsWith("System.Security.Cryptography.CryptographicException (0x80092006):", e.GetProperty<string>("message"));
        }

        private CryptographyClient CreateClient(KeyVaultKey key, HttpPipelineTransport transport, ICryptographyProvider provider = null)
        {
            CryptographyClientOptions options = new CryptographyClientOptions
            {
                Transport = transport,
            };

            return InstrumentClient(new CryptographyClient(key, new MockCredential(), options, provider));
        }

        private static IEnumerable GetAesOperations()
        {
            yield return new TestCaseData("WrapKey", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.WrapKeyAsync(algorithm, s_buffer)));
            yield return new TestCaseData("UnwrapKey", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.UnwrapKeyAsync(algorithm, s_buffer)));
        }

        private static IEnumerable GetEcOperations(bool includePublicKeyMethods, bool ignoreHashingMethods)
        {
            yield return new TestCaseData("Sign", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.SignAsync(algorithm, s_buffer)));
            yield return new TestCaseData("SignData", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.SignDataAsync(algorithm, s_buffer)))
                .ConditionalIgnore(ignoreHashingMethods, "Cannot hash locally with invalid algorithm");

            if (includePublicKeyMethods)
            {
                yield return new TestCaseData("Verify", "true", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.VerifyAsync(algorithm, s_buffer, s_buffer)));
                yield return new TestCaseData("VerifyData", "true", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.VerifyDataAsync(algorithm, s_buffer, s_buffer)))
                    .ConditionalIgnore(ignoreHashingMethods, "Cannot create hash locally with invalid algorithm");
            }
        }

        // Use RSA operations as a proxy for cryptographic operations since it currently supports them all.
        private static IEnumerable GetRsaOperations(bool includePublicKeyMethods, bool ignoreHashingMethods)
        {
            yield return new TestCaseData("Decrypt", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.DecryptAsync(algorithm ?? EncryptionAlgorithm.RsaOaep, s_buffer)));
            yield return new TestCaseData("Sign", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.SignAsync(algorithm ?? SignatureAlgorithm.RS256, s_buffer)));
            yield return new TestCaseData("SignData", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.SignDataAsync(algorithm ?? SignatureAlgorithm.RS256, s_buffer)))
                .ConditionalIgnore(ignoreHashingMethods, "Cannot hash locally with invalid algorithm");
            yield return new TestCaseData("UnwrapKey", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.UnwrapKeyAsync(algorithm ?? KeyWrapAlgorithm.RsaOaep, s_buffer)));

            if (includePublicKeyMethods)
            {
                yield return new TestCaseData("Encrypt", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.EncryptAsync(algorithm ?? EncryptionAlgorithm.RsaOaep, s_buffer)));
                yield return new TestCaseData("Verify", "true", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.VerifyAsync(algorithm ?? SignatureAlgorithm.RS256, s_buffer, s_buffer)));
                yield return new TestCaseData("VerifyData", "true", new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.VerifyDataAsync(algorithm ?? SignatureAlgorithm.RS256, s_buffer, s_buffer)))
                    .ConditionalIgnore(ignoreHashingMethods, "Cannot hash locally with invalid algorithm");
                yield return new TestCaseData("WrapKey", null, new Func<CryptographyClient, string, Task<object>>(async (client, algorithm) => await client.WrapKeyAsync(algorithm ?? KeyWrapAlgorithm.RsaOaep, s_buffer)));
            }
        }

        public class MockCredential : TokenCredential
        {
            private AccessToken token = new AccessToken("mockToken", DateTimeOffset.UtcNow.AddHours(1));

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return token;
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(token);
            }
        }
    }
}
