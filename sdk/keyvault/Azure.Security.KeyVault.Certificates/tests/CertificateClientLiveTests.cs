// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientLiveTests : CertificatesTestBase
    {
        public CertificateClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // In record mode we reset the challenge cache before each test so that the challenge call
            // is always made. This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [Test]
        public void StartCreateCertificateError()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = new CertificatePolicy("invalid", "Self")
            {
                KeyUsage =
                {
                    "invalid",
                },
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => Client.StartCreateCertificateAsync(certName, certificatePolicy));
            Assert.AreEqual(400, ex.Status);
        }

        [Test]
        public async Task VerifyGetCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            CertificateOperation getOperation = await Client.GetCertificateOperationAsync(certName);

            Assert.IsNotNull(getOperation);
        }

        [Test]
        public async Task VerifyCancelCertificateOperation()
        {
            // Log details why this fails often for live tests on net461.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);

            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                await operation.CancelAsync();
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            OperationCanceledException ex = Assert.ThrowsAsync<OperationCanceledException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was canceled so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyUnexpectedCancelCertificateOperation()
        {
            // Log details why this fails often for live tests on net461.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);

            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                // Calling through the CertificateClient directly won't affect the CertificateOperation, so subsequent status updates should throw.
                await Client.CancelCertificateOperationAsync(certName);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            OperationCanceledException ex = Assert.ThrowsAsync<OperationCanceledException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was canceled so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyDeleteCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            await operation.DeleteAsync();

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was deleted so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(404, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyUnexpectedDeleteCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                // Calling through the CertificateClient directly won't affect the CertificateOperation, so subsequent status updates should throw.
                await Client.DeleteCertificateOperationAsync(certName);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was deleted so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(404, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyCertificateOperationError()
        {
            string issuerName = Recording.GenerateId();
            string certName = Recording.GenerateId();

            CertificateIssuer certIssuer = new CertificateIssuer(issuerName, "DigiCert")
            {
                AccountId = "test",
                Password = "test",
                OrganizationId = "test",
            };

            await Client.CreateIssuerAsync(certIssuer);

            CertificateOperation operation = null;
            try
            {
                CertificatePolicy certificatePolicy = DefaultPolicy;
                certificatePolicy.IssuerName = issuerName;

                operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

                RegisterForCleanup(certName);

                using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

                while (!operation.HasCompleted)
                {
                    await Task.Delay(pollingInterval, cts.Token);
                    await operation.UpdateStatusAsync(cts.Token);
                }

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => { KeyVaultCertificateWithPolicy cert = operation.Value; });
                StringAssert.StartsWith("The certificate operation failed: ", ex.Message);

                Assert.IsTrue(operation.HasCompleted);
                Assert.IsFalse(operation.HasValue);
                Assert.AreEqual(200, operation.GetRawResponse().Status);
                Assert.AreEqual("failed", operation.Properties.Status);
            }
            catch (TaskCanceledException) when (operation != null)
            {
                Assert.Inconclusive("Timed out while waiting for operation {0}", operation.Id);
            }
            finally
            {
                await Client.DeleteIssuerAsync(issuerName);
            }
        }

        [Test]
        public async Task VerifyCertificateGetWithPolicyInProgress()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            KeyVaultCertificateWithPolicy certificateWithPolicy = await Client.GetCertificateAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Properties.Version);

            KeyVaultCertificate certificate = await Client.GetCertificateVersionAsync(certName, certificateWithPolicy.Properties.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);
        }

        [Test]
        public async Task VerifyGetCertificateCompleted()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            await WaitForCompletion(operation);

            KeyVaultCertificateWithPolicy certificateWithPolicy = await Client.GetCertificateAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Properties.Version);

            KeyVaultCertificate certificate = await Client.GetCertificateVersionAsync(certName, certificateWithPolicy.Properties.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);

        }

        [Test]
        public async Task VerifyGetCertificateCompletedSubsequently()
        {
            string certName = Recording.GenerateId();

            await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            // Pretend a separate process was started subsequently and we need to get the operation again.
            CertificateOperation operation = new CertificateOperation(Client, certName);

            // Need to call the real async wait method or the sync version of this test fails because it's using the instrumented Client directly.
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

            await operation.WaitForCompletionAsync(pollingInterval, cts.Token);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            KeyVaultCertificateWithPolicy certificateWithPolicy = operation.Value;

            Assert.NotNull(certificateWithPolicy);
            Assert.AreEqual(certName, certificateWithPolicy.Name);
            Assert.NotNull(certificateWithPolicy.Properties.Version);
        }

        [Test]
        public async Task VerifyUpdateCertificate()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            KeyVaultCertificateWithPolicy original = await WaitForCompletion(operation);
            CertificateProperties originalProperties = original.Properties;
            Assert.IsTrue(originalProperties.Enabled);
            Assert.IsEmpty(originalProperties.Tags);

            IDictionary<string, string> expTags = new Dictionary<string, string>() { { "key1", "value1" } };
            originalProperties.Tags.Add("key1", "value1");

            KeyVaultCertificate updated = await Client.UpdateCertificatePropertiesAsync(originalProperties);
            Assert.IsTrue(updated.Properties.Enabled);
            CollectionAssert.AreEqual(expTags, updated.Properties.Tags);

            originalProperties.Enabled = false;
            originalProperties.Tags.Clear();
            updated = await Client.UpdateCertificatePropertiesAsync(originalProperties);
            Assert.IsFalse(updated.Properties.Enabled);
            CollectionAssert.AreEqual(expTags, updated.Properties.Tags);
        }

        [Test]
        public async Task VerifyDeleteRecoverPurge()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            KeyVaultCertificateWithPolicy original = await WaitForCompletion(operation);

            Assert.NotNull(original);

            DeleteCertificateOperation deleteOperation = await Client.StartDeleteCertificateAsync(certName);
            DeletedCertificate deletedCert = deleteOperation.Value;

            Assert.IsNotNull(deletedCert);

            Assert.IsNotNull(deletedCert.RecoveryId);

            await WaitForDeletedCertificate(certName);

            _ = await Client.StartRecoverDeletedCertificateAsync(certName);

            Assert.NotNull(original);

            await PollForCertificate(certName);

            deleteOperation = await Client.StartDeleteCertificateAsync(certName);
            deletedCert = deleteOperation.Value;

            Assert.IsNotNull(deletedCert);

            Assert.IsNotNull(deletedCert.RecoveryId);

            await WaitForDeletedCertificate(certName);

            await Client.PurgeDeletedCertificateAsync(certName);

            await WaitForPurgedCertificate(certName);
        }

        [Test]
        public async Task VerifyImportCertificatePem()
        {
            const string ca =
"MIIDqzCCApMCFC+MROpib4t03Wqzgkcod1lad6JtMA0GCSqGSIb3DQEBCwUAMIGR" +
"MQswCQYDVQQGEwJVUzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQ" +
"BgNVBAoMCU1pY3Jvc29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlB" +
"enVyZSBTREsxJzAlBgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNv" +
"bTAeFw0yMDAyMTQyMzE3MTZaFw0yNTAyMTIyMzE3MTZaMIGRMQswCQYDVQQGEwJV" +
"UzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQBgNVBAoMCU1pY3Jv" +
"c29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlBenVyZSBTREsxJzAl" +
"BgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNvbTCCASIwDQYJKoZI" +
"hvcNAQEBBQADggEPADCCAQoCggEBANwCTuK0OnFc8UytzzCIB5pUWqWCMZA8kWO1" +
"Es84wOVupPTZHNDWKI57prj0CB5JP2yU8BkIFjhkV/9wc2KLjKwu7xaJTwBZF/i0" +
"t8dPBbgiEUmK6xdbJsLXoef/XZ5AmvCKb0mimEMvL8KgeF5OHuZJuYO0zCiRNVtp" +
"ZYSx2R73qhgy5klDHh346qQd5T+KbsdK3DArilT86QO1GrpBWl1GPvHJ3VZ1OO33" +
"iFWfyEVgwdAtMAkWXH8Eh1/MpPE8WQk5X5pdVEu+RJLLrVbgr+cnlVzfirSVLRar" +
"KZROAB3e2x8JdSqylnar/WWK11NERdiKaZr3WxAkceuVkTsKmRkCAwEAATANBgkq" +
"hkiG9w0BAQsFAAOCAQEAYLfk2dBcW1mJbkVYx80ogDUy/xX3d+uuop2gZwUXuzWY" +
"I4uXzSEsY37/+NKzOX6PtET3X6xENDW7AuJhTuWmTGZtPB1AjiVKLIgRwugV3Ovr" +
"1DoPBIvS7iCHGGcsr7tAgYxiVATlIcczCxQG1KPhrrLSUDxkbiyUHpyroExHGBeC" +
"UflT2BIO+TZ+44aYfO7vuwpu0ajfB6Rs0s/DM+uUTWCfsVvyPenObHz5HF2vxf75" +
"y8pr3fYKuUvpJ45T0ZjiXyRpkBTDudU3vuYuyAP3PwO6F/ic7Rm9D1uzEI38Va+o" +
"6CUh4NJnpIZIBs7T+rPwhKrUuM7BEO0CL7VTh37UzA==";

            const string pem =
"-----BEGIN CERTIFICATE-----\n" +
"MIIDqzCCApMCFC+MROpib4t03Wqzgkcod1lad6JtMA0GCSqGSIb3DQEBCwUAMIGR\n" +
"MQswCQYDVQQGEwJVUzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQ\n" +
"BgNVBAoMCU1pY3Jvc29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlB\n" +
"enVyZSBTREsxJzAlBgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNv\n" +
"bTAeFw0yMDAyMTQyMzE3MTZaFw0yNTAyMTIyMzE3MTZaMIGRMQswCQYDVQQGEwJV\n" +
"UzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQBgNVBAoMCU1pY3Jv\n" +
"c29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlBenVyZSBTREsxJzAl\n" +
"BgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNvbTCCASIwDQYJKoZI\n" +
"hvcNAQEBBQADggEPADCCAQoCggEBANwCTuK0OnFc8UytzzCIB5pUWqWCMZA8kWO1\n" +
"Es84wOVupPTZHNDWKI57prj0CB5JP2yU8BkIFjhkV/9wc2KLjKwu7xaJTwBZF/i0\n" +
"t8dPBbgiEUmK6xdbJsLXoef/XZ5AmvCKb0mimEMvL8KgeF5OHuZJuYO0zCiRNVtp\n" +
"ZYSx2R73qhgy5klDHh346qQd5T+KbsdK3DArilT86QO1GrpBWl1GPvHJ3VZ1OO33\n" +
"iFWfyEVgwdAtMAkWXH8Eh1/MpPE8WQk5X5pdVEu+RJLLrVbgr+cnlVzfirSVLRar\n" +
"KZROAB3e2x8JdSqylnar/WWK11NERdiKaZr3WxAkceuVkTsKmRkCAwEAATANBgkq\n" +
"hkiG9w0BAQsFAAOCAQEAYLfk2dBcW1mJbkVYx80ogDUy/xX3d+uuop2gZwUXuzWY\n" +
"I4uXzSEsY37/+NKzOX6PtET3X6xENDW7AuJhTuWmTGZtPB1AjiVKLIgRwugV3Ovr\n" +
"1DoPBIvS7iCHGGcsr7tAgYxiVATlIcczCxQG1KPhrrLSUDxkbiyUHpyroExHGBeC\n" +
"UflT2BIO+TZ+44aYfO7vuwpu0ajfB6Rs0s/DM+uUTWCfsVvyPenObHz5HF2vxf75\n" +
"y8pr3fYKuUvpJ45T0ZjiXyRpkBTDudU3vuYuyAP3PwO6F/ic7Rm9D1uzEI38Va+o\n" +
"6CUh4NJnpIZIBs7T+rPwhKrUuM7BEO0CL7VTh37UzA==\n" +
"-----END CERTIFICATE-----\n" +
"-----BEGIN PRIVATE KEY-----\n" +
"MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDcAk7itDpxXPFM\n" +
"rc8wiAeaVFqlgjGQPJFjtRLPOMDlbqT02RzQ1iiOe6a49AgeST9slPAZCBY4ZFf/\n" +
"cHNii4ysLu8WiU8AWRf4tLfHTwW4IhFJiusXWybC16Hn/12eQJrwim9JophDLy/C\n" +
"oHheTh7mSbmDtMwokTVbaWWEsdke96oYMuZJQx4d+OqkHeU/im7HStwwK4pU/OkD\n" +
"tRq6QVpdRj7xyd1WdTjt94hVn8hFYMHQLTAJFlx/BIdfzKTxPFkJOV+aXVRLvkSS\n" +
"y61W4K/nJ5Vc34q0lS0WqymUTgAd3tsfCXUqspZ2q/1litdTREXYimma91sQJHHr\n" +
"lZE7CpkZAgMBAAECggEAMRfSwoO1BtbWgWXHdezkxWtNTuFebfEWAEnHiLYBVTD7\n" +
"XieUZoVjR2gQK/VIWnm9zVzutqc3Th4WBMny9WpuWX2fnEfHeSxoTPcGi1L207/G\n" +
"W8LD8tJEM/YqCrrRCR8hc8twSd4eW9+LqMJmGaUVAA4zd1BAvkyou10pahLFgEMZ\n" +
"nlYxOzz0KrniNIdQxhwfaXZYUzX5ooJYtgY74vnSOHQhepRt5HY9B7iZ6jm/3ulA\n" +
"aJnfNbQ8YDYTS0R+OGv8RXU/jLCm5+TPwx0XFwZ6vRtWwWUUxhLV77Re9GP1xIx9\n" +
"VnYm9W3RyOm/KD9keQMTWKT0bLGB8fC6kj2mvbjgAQKBgQDzh5sy7q9RA+GqprC8\n" +
"8aUmkaTMXNahPPPJoLOflJ/+QlOt6YZUIn55vmicVsvFzr9hbxdTW7aQS91iAu05\n" +
"swEyltsR0my7FXsHZnN4SBct2FimAzMLTWQr10vLLRoSR5CNpUdoXGWFOAa3LKrZ\n" +
"aPJEM1hA3h2XDfZ7Gtxjg4ypIQKBgQDnRl9pGwd83MkoxT4CiZvNbvdBg4lXlHcA\n" +
"JoZ9OfoOey+7WRsOFsMvQapXf+JlvixP0ldECXZyxifswvfmiR2oqYTeRbITderg\n" +
"mwjDjN571Ui0ls5HwCBE+/iZoNmQI5INAPqsQMXwW0rx4YNXHblsJ0qT+3yFNWOF\n" +
"m6STMH8Y+QKBgFai8JivB1nICrleMdQWF43gFIPLp2OXPpeFf0GPa1fWGtTtFifK\n" +
"WbpP/gFYc4f8pGMyVVcHcqxlAO5EYka7ovpvZqIxfRMVcj5QuVWaN/zMUcVFsBwe\n" +
"PTvHjSRL+FF2ejuaCAxdipRZOTJjRqivyDhxF72EB3zcr8pd5PfWLe1hAoGASJRO\n" +
"JvcDj4zeWDwmLLewvHTBhb7Y4DJIcjSk6jHCpr7ECQB6vB4qnO73nUQV8aYP0/EH\n" +
"z+NEV9qV9vhswd1wAFlKyFKJAxBzaI9e3becrrINghb9n4jM17lXmCbhgBmZoRkY\n" +
"kew18itERspl5HYAlc9y2SQIPOm3VNu2dza1/EkCgYEAlTMyL6arbtJJsygzVn8l\n" +
"gKHuURwp1cxf6hUuXKJ56xI/I1OZjMidZM0bYSznmK9SGNxlfNbIV8vNhQfiwR6t\n" +
"HyGypSRP+h9MS9E66boXyINaOClZqiCn0pI9aiIpl3D6EbT6e7+zKljT0XmZJduK\n" +
"BkRGMfUngiT8oVyaMtZWYPM=\n" +
"-----END PRIVATE KEY-----\n";

            string certName = Recording.GenerateId();
            byte[] certBytes = Encoding.ASCII.GetBytes(pem);

            ImportCertificateOptions options = new ImportCertificateOptions(certName, certBytes)
            {
                Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK")
                {
                    ContentType = CertificateContentType.Pem,
                },
            };

            KeyVaultCertificateWithPolicy cert = await Client.ImportCertificateAsync(options);
            RegisterForCleanup(certName);

            byte[] pubBytes = Convert.FromBase64String(ca);
            CollectionAssert.AreEqual(pubBytes, cert.Cer);
        }

        [Test]
        public async Task VerifyImportCertificatePfx()
        {
            const string ca =
"MIIDqzCCApMCFC+MROpib4t03Wqzgkcod1lad6JtMA0GCSqGSIb3DQEBCwUAMIGR" +
"MQswCQYDVQQGEwJVUzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQ" +
"BgNVBAoMCU1pY3Jvc29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlB" +
"enVyZSBTREsxJzAlBgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNv" +
"bTAeFw0yMDAyMTQyMzE3MTZaFw0yNTAyMTIyMzE3MTZaMIGRMQswCQYDVQQGEwJV" +
"UzELMAkGA1UECAwCV0ExEDAOBgNVBAcMB1JlZG1vbmQxEjAQBgNVBAoMCU1pY3Jv" +
"c29mdDESMBAGA1UECwwJQXp1cmUgU0RLMRIwEAYDVQQDDAlBenVyZSBTREsxJzAl" +
"BgkqhkiG9w0BCQEWGG9wZW5zb3VyY2VAbWljcm9zb2Z0LmNvbTCCASIwDQYJKoZI" +
"hvcNAQEBBQADggEPADCCAQoCggEBANwCTuK0OnFc8UytzzCIB5pUWqWCMZA8kWO1" +
"Es84wOVupPTZHNDWKI57prj0CB5JP2yU8BkIFjhkV/9wc2KLjKwu7xaJTwBZF/i0" +
"t8dPBbgiEUmK6xdbJsLXoef/XZ5AmvCKb0mimEMvL8KgeF5OHuZJuYO0zCiRNVtp" +
"ZYSx2R73qhgy5klDHh346qQd5T+KbsdK3DArilT86QO1GrpBWl1GPvHJ3VZ1OO33" +
"iFWfyEVgwdAtMAkWXH8Eh1/MpPE8WQk5X5pdVEu+RJLLrVbgr+cnlVzfirSVLRar" +
"KZROAB3e2x8JdSqylnar/WWK11NERdiKaZr3WxAkceuVkTsKmRkCAwEAATANBgkq" +
"hkiG9w0BAQsFAAOCAQEAYLfk2dBcW1mJbkVYx80ogDUy/xX3d+uuop2gZwUXuzWY" +
"I4uXzSEsY37/+NKzOX6PtET3X6xENDW7AuJhTuWmTGZtPB1AjiVKLIgRwugV3Ovr" +
"1DoPBIvS7iCHGGcsr7tAgYxiVATlIcczCxQG1KPhrrLSUDxkbiyUHpyroExHGBeC" +
"UflT2BIO+TZ+44aYfO7vuwpu0ajfB6Rs0s/DM+uUTWCfsVvyPenObHz5HF2vxf75" +
"y8pr3fYKuUvpJ45T0ZjiXyRpkBTDudU3vuYuyAP3PwO6F/ic7Rm9D1uzEI38Va+o" +
"6CUh4NJnpIZIBs7T+rPwhKrUuM7BEO0CL7VTh37UzA==";

            const string pfx =
"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";

            string certName = Recording.GenerateId();
            byte[] certBytes = Convert.FromBase64String(pfx);

            ImportCertificateOptions options = new ImportCertificateOptions(certName, certBytes)
            {
                Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK")
                {
                    ContentType = CertificateContentType.Pkcs12,
                },
            };

            KeyVaultCertificateWithPolicy cert = await Client.ImportCertificateAsync(options);
            RegisterForCleanup(certName);

            byte[] pubBytes = Convert.FromBase64String(ca);
            CollectionAssert.AreEqual(pubBytes, cert.Cer);
        }

        // Backup Restore
        // GetCertificates
        // GetCertificatsIncludePending
        // GetCertificateVersions
        // GetDeletedCertificates
        // GetUpdatePolicy
        // IssuerCrud
        // ContactsCrud

        private static CertificatePolicy DefaultPolicy => new CertificatePolicy
        {
            IssuerName = WellKnownIssuerNames.Self,
            Subject = "CN=default",
            KeyType = CertificateKeyType.Rsa,
            Exportable = true,
            ReuseKey = false,
            KeyUsage =
            {
                CertificateKeyUsage.CrlSign,
                CertificateKeyUsage.DataEncipherment,
                CertificateKeyUsage.DigitalSignature,
                CertificateKeyUsage.KeyEncipherment,
                CertificateKeyUsage.KeyAgreement,
                CertificateKeyUsage.KeyCertSign,
            },
            CertificateTransparency = false,
            ContentType = CertificateContentType.Pkcs12
        };
    }
}
