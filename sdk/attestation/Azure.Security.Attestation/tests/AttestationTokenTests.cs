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

        #region Snippet:CreateTestTokenForMocking
        private class TestAttestationToken : AttestationToken
        {
            public TestAttestationToken(string token) : base(token)
            {
            }
        }
        #endregion

        private class TestBody
        {
            public string StringField { get; set; }
            public int IntField { get; set; }
        }

        // A JSON Web Token with an expiration time, helpful to test token expiration time.
        private class JwtTestBody
        {
            [JsonPropertyName("exp")]
            public long ExpiresAt { get; set; }

            [JsonPropertyName("nbf")]
            public double NotBefore { get; set; }

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
                ExpiresAt = DateTimeOffset.Now.Subtract(TimeSpan.FromSeconds(5)).ToUnixTimeSeconds(),
            };

            var token = new AttestationToken(tokenBody);
            string serializedToken = token.ToString();

            // This check should fail since the token expired 5 seconds ago.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 5 second expiration time.
            await ValidateSerializedToken(serializedToken, tokenBody, new TokenValidationOptions(timeValidationSlack: 10));
        }

        [RecordedTest]
        public async Task ValidateTooEarlyAttestationToken()
        {
            // Create a JWT whose body will become valid 5 seconds from now.
            object tokenBody = new JwtTestBody
            {
                StringField = "Foo",
                NotBefore = DateTimeOffset.Now.AddSeconds(5).ToUnixTimeSeconds(),
                ExpiresAt = DateTimeOffset.Now.AddSeconds(60).ToUnixTimeSeconds(),
            };

            X509Certificate2 fullCertificate = TestEnvironment.PolicyManagementCertificate;
            AsymmetricAlgorithm privateKey = TestEnvironment.PolicyManagementKey;

            var token = new AttestationToken(tokenBody, new TokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.ToString();

            // This check should fail since the token won't be valid for another 5 seconds.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 10 seconds before it becomes valid.
            await ValidateSerializedToken(serializedToken, tokenBody, new TokenValidationOptions(timeValidationSlack: 10));
        }

        [RecordedTest]
        public async Task ValidateTokenCallback()
        {
            // Create a JWT whose body will become valid 5 seconds from now.
            object tokenBody = new JwtTestBody
            {
                StringField = "Foo",
                NotBefore = DateTimeOffset.Now.AddSeconds(5).ToUnixTimeSeconds(),
                ExpiresAt = DateTimeOffset.Now.AddSeconds(60).ToUnixTimeSeconds(),
            };

            X509Certificate2 fullCertificate = TestEnvironment.PolicyManagementCertificate;
            AsymmetricAlgorithm privateKey = TestEnvironment.PolicyManagementKey;

            var token = new AttestationToken(tokenBody, new TokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.ToString();

            // This check should fail since the token won't be valid for another 5 seconds.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 10 seconds before it becomes valid.
            await ValidateSerializedToken(
                serializedToken,
                tokenBody,
                new TokenValidationOptions(timeValidationSlack: 10, validationCallback: (AttestationToken tokenToValidate, AttestationSigner tokenSigner) =>
                {
                    Assert.AreEqual(1, tokenSigner.SigningCertificates.Count);
                    Assert.IsNotNull(tokenSigner.SigningCertificates[0]);
                    CollectionAssert.AreEqual(fullCertificate.Export(X509ContentType.Cert), tokenSigner.SigningCertificates[0].Export(X509ContentType.Cert));
                    Assert.AreEqual(fullCertificate, tokenSigner.SigningCertificates[0]);
                    return true;
                }));
        }

        /// <summary>
        /// Ensure that the serialized token validates correctly.
        /// </summary>
        /// <param name="serializedToken"></param>
        public async Task ValidateSerializedToken(string serializedToken, object expectedBody, TokenValidationOptions tokenOptions = default)
        {
            var parsedToken = new TestAttestationToken(serializedToken);

            Assert.IsTrue(await parsedToken.ValidateTokenAsync(tokenOptions ?? new TokenValidationOptions(validateExpirationTime:true), null));

            // The body of the token should match the expected body.
            Assert.AreEqual(JsonSerializer.Serialize(expectedBody), parsedToken.TokenBody);
        }
    }
}
