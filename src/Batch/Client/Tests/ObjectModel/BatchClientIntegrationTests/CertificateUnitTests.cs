// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestCommon;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    //
    // NOTE: These are really unit tests but they cannot live in the unit tests project right now because the method we use to generate certificates is not
    // coreclr compatible
    //
    public class CertificateUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private const string CertificateFilePrefix = "CertificateUnitTests";
        private const string RsaSuffix = "RSA";

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
            expectedSignatureAlgorithm += RsaSuffix; //All algorithms friendly names seem to include a commo suffix

            try
            {
                using (BatchClient batchClient = CreateDummyClient())
                {
                    X509Certificate2 x509Certificate = password == null ? new X509Certificate2(certificateFileLocation) : new X509Certificate2(certificateFileLocation, password);
                    byte[] cerBytes = x509Certificate.Export(X509ContentType.Cert);

                    Certificate certificate = batchClient.CertificateOperations.CreateCertificate(cerBytes);

                    Assert.Equal(x509Certificate.Thumbprint.ToUpper(), certificate.Thumbprint.ToUpper());
                    Assert.Equal("sha1", certificate.ThumbprintAlgorithm);
                    Assert.Equal(expectedSignatureAlgorithm, x509Certificate.SignatureAlgorithm.FriendlyName);
                }
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
