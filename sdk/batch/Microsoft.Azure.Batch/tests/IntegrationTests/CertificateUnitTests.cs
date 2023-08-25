// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using IntegrationTestCommon;
    using Xunit;
    using Xunit.Abstractions;

    //
    // NOTE: These are really unit tests but they cannot live in the unit tests project right now because the method we use to generate certificates is not
    // coreclr compatible
    //
    public class CertificateUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private const string CertificateFilePrefix = "CertificateUnitTests";
        private const string RsaMid = "With";

        public CertificateUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateCerFileFromRawData()
        {
            string filePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha1Algorithm);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha1Algorithm);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreatePfxFileFromRawData()
        {
            string filePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha1Algorithm, CommonResources.CertificatePassword);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha1Algorithm, CommonResources.CertificatePassword);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateSha256Cer()
        {
            string filePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha256Algorithm);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha256Algorithm);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateSha256Pfx()
        {
            string filePath = IntegrationTestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha256Algorithm, password: CommonResources.CertificatePassword);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha256Algorithm, CommonResources.CertificatePassword);
        }

        private static void TestCertificateFromRawData(string certificateFileLocation, string expectedSignatureAlgorithm, string password = null)
        {
            expectedSignatureAlgorithm = expectedSignatureAlgorithm.Replace(RsaMid, String.Empty);

            try
            {
                using BatchClient batchClient = CreateDummyClient();
                X509Certificate2 x509Certificate = password == null ? new X509Certificate2(certificateFileLocation) : new X509Certificate2(certificateFileLocation, password);
                byte[] cerBytes = x509Certificate.Export(X509ContentType.Cert);

#pragma warning disable CS0618 // Type or member is obsolete
                Certificate certificate = batchClient.CertificateOperations.CreateCertificateFromCer(cerBytes);
#pragma warning restore CS0618 // Type or member is obsolete

                Assert.Equal(x509Certificate.Thumbprint.ToUpper(), certificate.Thumbprint.ToUpper());
                Assert.Equal("sha1", certificate.ThumbprintAlgorithm);
                Assert.Equal(expectedSignatureAlgorithm, x509Certificate.SignatureAlgorithm.FriendlyName);
            }
            finally
            {
                File.Delete(certificateFileLocation);
            }
        }

        private const string DummyBaseUrl = "testbatch://batch-test.windows-int.net";
        private const string DummyAccountName = "Dummy";
        private const string DummyAccountKey = "ZmFrZQ==";

        private static BatchSharedKeyCredentials CreateDummySharedKeyCredential()
        {
            BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(
                DummyBaseUrl,
                DummyAccountName,
                DummyAccountKey);

            return credentials;
        }

        private static BatchClient CreateDummyClient()
        {
            return BatchClient.Open(CreateDummySharedKeyCredential());
        }

    }
}
