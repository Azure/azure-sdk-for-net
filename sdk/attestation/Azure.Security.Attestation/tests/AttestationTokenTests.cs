// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    [Category("Unit")]
    public class AttestationTokenTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public AttestationTokenTests(bool isAsync) : base(isAsync)
        {
        }

        private class TestAttestationToken : AttestationToken
        {
            public TestAttestationToken(string token) : base(token)
            {
            }
        }

        private class TestBody
        {
            public string StringField { get; set; }
            public int IntField { get; set; }
        }

        private class JwtTestBody
        {
            [JsonPropertyName("exp")]
            public long Exp { get; set; }

            public string StringField { get; set; }
            public int IntField { get; set; }
        }

#if FullNetFx
        [RecordedTest]
        public async Task GetSecuredAttestationTokenWithPrivateKey()
        {
            X509Certificate2 fullCertificate = TestEnvironment.PolicyManagementCertificate;
            fullCertificate.PrivateKey = TestEnvironment.PolicyManagementKey;

            // The body of attestation token MUST be a JSON object.
            TestBody body = new TestBody { StringField = "Foo", };

            var token = new AttestationToken(body, new TokenSigningKey(fullCertificate));
            string serializedToken = token.ToString();

            await ValidateSerializedToken(serializedToken, body);
        }
#endif

        [RecordedTest]
        public async Task GetSecuredAttestationToken()
        {
            X509Certificate2 fullCertificate = TestEnvironment.PolicyManagementCertificate;
            AsymmetricAlgorithm privateKey = TestEnvironment.PolicyManagementKey;

            object tokenBody = new StoredAttestationPolicy { AttestationPolicy = "Foo", };

            var token = new AttestationToken(tokenBody, new TokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.ToString();

            await ValidateSerializedToken(serializedToken, tokenBody);
        }

        [RecordedTest]
        public async Task GetUnsecuredAttestationToken()
        {
            object tokenBody = new StoredAttestationPolicy { AttestationPolicy = "Foo", };

            var token = new AttestationToken(tokenBody);
            string serializedToken = token.ToString();

            await ValidateSerializedToken(serializedToken, tokenBody);
        }

        [RecordedTest]
        public async Task ValidateJustExpiredAttestationToken()
        {
            // Create a JWT whose body has just expired.
            object tokenBody = new JwtTestBody{
                StringField = "Foo",
                Exp = DateTimeOffset.Now.Subtract(TimeSpan.FromSeconds(5)).ToUnixTimeSeconds(),
            };

            long unixtimeNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            long unixtimeFiveSecondsAgo = DateTimeOffset.Now.Subtract(TimeSpan.FromSeconds(5)).ToUnixTimeSeconds();

            DateTimeOffset timeNow = DateTimeOffset.FromUnixTimeSeconds(unixtimeNow);
            DateTimeOffset timeFiveSecondsAgo = DateTimeOffset.FromUnixTimeSeconds(unixtimeFiveSecondsAgo);

            var token = new AttestationToken(tokenBody);
            string serializedToken = token.ToString();

            // This check should fail since the token expired 5 minutes ago.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 5 second expiration time.
            await ValidateSerializedToken(serializedToken, tokenBody, new AttestationTokenOptions { TimeValidationSlack = 10, });
        }

        /// <summary>
        /// Ensure that the serialized token validates correctly.
        /// </summary>
        /// <param name="serializedToken"></param>
        /// <returns></returns>
        public async Task ValidateSerializedToken(string serializedToken, object expectedBody, AttestationTokenOptions tokenOptions = default)
        {
            var parsedToken = new TestAttestationToken(serializedToken);

            Assert.IsTrue(await parsedToken.ValidateToken(tokenOptions ?? new AttestationTokenOptions { ValidateExpirationTime = true, }, null));

            // The body of the token should match the expected body.
            Assert.AreEqual(JsonSerializer.Serialize(expectedBody), parsedToken.TokenBody);
            await Task.Yield();
        }
    }
}
