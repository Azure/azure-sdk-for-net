// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.Signing.Tests
{
    public class DevSigningClientTests : RecordedTestBase<DevSigningClientTestEnvironment>
    {
        private CertificateProfile _certificateProfileClient;

        public DevSigningClientTests(bool isAsync) : base(isAsync)
        {
        }

        internal CertificateProfile GetCertificateProfileClient() =>
            InstrumentClient(new SigningClient(TestEnvironment.Credential, InstrumentClientOptions(new SigningClientOptions()))
            .GetCertificateProfileClient(TestEnvironment.Region));

        [SetUp]
        public void SetUp()
        {
            _certificateProfileClient = GetCertificateProfileClient();
        }

        [RecordedTest]
        public async Task GetRootCertificateSuccess()
        {
            Response rootCertResponse = await _certificateProfileClient.GetSignRootCertificateAsync(TestEnvironment.AccountName, TestEnvironment.ProfileName, TestEnvironment.context);

            //Valid X509Certificate2 byte array
            Assert.AreEqual(200, rootCertResponse.Status);
            Assert.DoesNotThrow(() => new X509Certificate2(rootCertResponse.Content.ToArray()));
        }

        [RecordedTest]
        public async Task GetCustomerCertificateEkuSuccess()
        {
            const string eku = "eku";

            await foreach (BinaryData item in _certificateProfileClient.GetExtendedKeyUsagesAsync(TestEnvironment.AccountName, TestEnvironment.ProfileName, TestEnvironment.context))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;

                if (!result.TryGetProperty(eku, out JsonElement ekuElement))
                {
                    FailDueToMissingProperty(eku);
                }

                Assert.True(ekuElement.ToString().Contains("1.3.6.1.4.1.311"));
            }
        }

        [RecordedTest]
        public async Task SignSuccess()
        {
            const string signature = "signature";
            const string signingCert = "signingCertificate";
            const string signatureAlgorithm = "RS256";

            byte[] digest = new byte[32];
            var random = new Random();
            random.NextBytes(digest);

            using RequestContent content = RequestContent.Create(new
            {
                signatureAlgorithm,
                digest,
            });

            Operation<BinaryData> operation = await _certificateProfileClient.SignAsync(WaitUntil.Completed, TestEnvironment.AccountName, TestEnvironment.ProfileName, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;

            if (!result.TryGetProperty(signingCert, out JsonElement signingCertElement))
            {
                FailDueToMissingProperty(signingCert);
            }

            if (!result.TryGetProperty(signature, out JsonElement signatureElement))
            {
                FailDueToMissingProperty(signature);
            }

            string signingCertValue = signingCertElement.ToString();
            string signatureValue = signatureElement.ToString();

            Assert.IsNotEmpty(signatureValue, signingCertValue);
        }

        private static void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The JSON response received from the service does not include the necessary property: {propertyName}");
        }
    }
}
