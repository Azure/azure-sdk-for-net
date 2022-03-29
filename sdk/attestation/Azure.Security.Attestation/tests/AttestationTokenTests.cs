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

            var token = new AttestationToken(BinaryData.FromObjectAsJson(body), new AttestationTokenSigningKey(fullCertificate));
            string serializedToken = token.Serialize();

            await ValidateSerializedToken(serializedToken, body);
        }
#endif

        [RecordedTest]
        public async Task GetSecuredAttestationToken()
        {
            X509Certificate2 fullCertificate = TestEnvironment.PolicyManagementCertificate;
            AsymmetricAlgorithm privateKey = TestEnvironment.PolicyManagementKey;

            object tokenBody = new StoredAttestationPolicy { AttestationPolicy = "Foo", };

            var token = new AttestationToken(BinaryData.FromObjectAsJson(tokenBody), new AttestationTokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.Serialize();

            await ValidateSerializedToken(serializedToken, tokenBody);
        }

        [RecordedTest]
        public async Task GetUnsecuredAttestationToken()
        {
            object tokenBody = new StoredAttestationPolicy { AttestationPolicy = "Foo", };

            var token = new AttestationToken(BinaryData.FromObjectAsJson(tokenBody));
            string serializedToken = token.Serialize();

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

            var token = new AttestationToken(BinaryData.FromObjectAsJson(tokenBody));
            string serializedToken = token.Serialize();

            // This check should fail since the token expired 5 seconds ago.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 5 second expiration time.
            await ValidateSerializedToken(serializedToken, tokenBody, new AttestationTokenValidationOptions { TimeValidationSlack = 10 });
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

            var token = new AttestationToken(BinaryData.FromObjectAsJson(tokenBody), new AttestationTokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.Serialize();

            // This check should fail since the token won't be valid for another 5 seconds.
            Assert.ThrowsAsync(typeof(Exception), async () => await ValidateSerializedToken(serializedToken, tokenBody));

            // This check should succeed since the token slack is greater than the 10 seconds before it becomes valid.
            await ValidateSerializedToken(serializedToken, tokenBody, new AttestationTokenValidationOptions { TimeValidationSlack = 10 });
        }

        [RecordedTest]
        public void ValidateTokenCallback()
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

            var token = new AttestationToken(BinaryData.FromObjectAsJson(tokenBody), new AttestationTokenSigningKey(privateKey, fullCertificate));
            string serializedToken = token.Serialize();

            var validationOptions = new AttestationTokenValidationOptions();

            validationOptions.TokenValidated += (args) =>
            {
                Assert.AreEqual(1, args.Signer.SigningCertificates.Count);
                Assert.IsNotNull(args.Signer.SigningCertificates[0]);
                CollectionAssert.AreEqual(fullCertificate.Export(X509ContentType.Cert), args.Signer.SigningCertificates[0].Export(X509ContentType.Cert));
                Assert.AreEqual(fullCertificate, args.Signer.SigningCertificates[0]);
                return Task.CompletedTask;
            };

            // ValidateTokenAsync will throw an exception if a callback is specified outside of an attestation client.
            // Note that validation callbacks are tested elsewhere in the AttestationClient codebase.
            Assert.ThrowsAsync(typeof(Exception), async() => await ValidateSerializedToken(
                serializedToken,
                tokenBody,
                validationOptions));
        }

        /// <summary>
        /// Ensure that the serialized token validates correctly.
        /// </summary>
        /// <param name="serializedToken"></param>
        public async Task ValidateSerializedToken(string serializedToken, object expectedBody, AttestationTokenValidationOptions tokenOptions = default)
        {
            var parsedToken = AttestationToken.Deserialize(serializedToken);
            await Task.Yield();
            Assert.IsTrue(await parsedToken.ValidateTokenAsync(tokenOptions ?? new AttestationTokenValidationOptions { ValidateExpirationTime = true }, null));

            // The body of the token should match the expected body.
            Assert.AreEqual(JsonSerializer.Serialize(expectedBody), Encoding.UTF8.GetString(parsedToken.TokenBodyBytes.ToArray()));
        }
    }
}
