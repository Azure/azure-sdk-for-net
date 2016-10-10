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

﻿namespace Azure.Batch.Unit.Tests
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
        private const string RsaSuffix = "RSA";

        public CertificateUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateCerFileFromRawData()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.cer", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha1Algorithm);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha1Algorithm);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreatePfxFileFromRawData()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha1Algorithm, password: CommonResources.CertificatePassword);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha1Algorithm, CommonResources.CertificatePassword);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateSha256Cer()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha256Algorithm);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha256Algorithm);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCreateSha256Pfx()
        {
            string filePath = TestCommon.GetTemporaryCertificateFilePath(string.Format("{0}.pfx", CertificateFilePrefix));
            CertificateBuilder.CreateSelfSignedInFile("Foo", filePath, CertificateBuilder.Sha256Algorithm, password: CommonResources.CertificatePassword);

            TestCertificateFromRawData(filePath, CertificateBuilder.Sha256Algorithm, CommonResources.CertificatePassword);
        }

        private static void TestCertificateFromRawData(string certificateFileLocation, string expectedSignatureAlgorithm, string password = null)
        {
            expectedSignatureAlgorithm += RsaSuffix; //All algorithms friendly names seem to include a commo suffix

            try
            {
                using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
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

    }
}
