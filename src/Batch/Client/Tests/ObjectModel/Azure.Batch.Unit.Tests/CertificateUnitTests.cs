namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using TestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class CertificateUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private const string CertificateFilePrefix = "CertificateUnitTests";

        public CertificateUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateCerFileFromRawData()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath);

            TestCertificateFromRawData(filePath);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreatePfxFileFromRawData()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CommonResources.CertificatePassword);

            TestCertificateFromRawData(filePath, CommonResources.CertificatePassword);
        }

        private static void TestCertificateFromRawData(string certificateFileLocation, string password = null)
        {
            try
            {
                using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
                {
                    X509Certificate2 x509Certificate = password == null ? new X509Certificate2(certificateFileLocation) : new X509Certificate2(certificateFileLocation, password);
                    byte[] cerBytes = x509Certificate.Export(X509ContentType.Cert);

                    Certificate certificate = batchClient.CertificateOperations.CreateCertificate(cerBytes);

                    Assert.Equal(x509Certificate.Thumbprint.ToUpper(), certificate.Thumbprint.ToUpper());
                }
            }
            finally
            {
                File.Delete(certificateFileLocation);
            }
        }

    }
}
