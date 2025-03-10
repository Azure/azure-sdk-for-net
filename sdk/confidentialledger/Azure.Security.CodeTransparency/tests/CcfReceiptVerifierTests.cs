// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Azure.Security.CodeTransparency.Receipt;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    /// <summary>
    /// Tests for receipt verification.
    /// </summary>
    public class CcfReceiptVerifierTests
    {
        private string _fileQualifierPrefix;

        private byte[] readFileBytes(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix+name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix+name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        /// <summary>
        /// .NET Framework 4.6.2 cannot use newer X509Certificate2.CreateFromPem method.
        /// </summary>
        /// <param name="pem">certificate PEM bytes</param>
        /// <returns>X509Certificate2</returns>
        private static X509Certificate2 certFromPem(byte[] pem) {
            var pemText = Encoding.Default.GetString(pem);
            string base64 = pemText.Replace("-----BEGIN CERTIFICATE-----", "").Replace("-----END CERTIFICATE-----", "").Trim();
            byte[] rawCert = Convert.FromBase64String(base64);

#if NET9_0_OR_GREATER
            var cert = X509CertificateLoader.LoadCertificate(rawCert);
#else
            var cert = new X509Certificate2(rawCert);
#endif
            return cert;
        }

        [SetUp]
        public void BaseSetUp() {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "sbom.json";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[]{mustExistFilename}, StringSplitOptions.None)[0];
        }

        [Test]
        public void Verify_separate_receipt_example1_success_Test()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-11-09.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-11-09.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes);
        }

        [Test]
        public void Fails_to_parse_signature()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-11-09.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("artifact.broken.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes));
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.That(ex.Message, Contains.Substring("Error while decoding COSE message"));
#endif
        }

        [Test]
        public void Verification_fails_with_signature_issued_elsewhere()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-11-09.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("artifact.other.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes));
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.That(ex.Message, Contains.Substring("VerifyReceipt: signature invalid"));
#endif
        }

        [Test]
        public void Verify_separate_receipt_example2_success_Test()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-11-10.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-11-10.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes);
        }

        [Test]
        public void Verify_separate_receipt_example3_success_Test()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-12-10.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes);
        }

        [Test]
        public void Verify_embedded_receipt_example_success()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.2023-02-13.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes);
        }

        [Test]
        public void Verify_embedded_receipt_is_missing_did_issuer()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.2023-02-13.cose");
            var didDocBytes = readFileBytes("service.2022-11.did.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(receiptBytes, null, didRef => didDoc));
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.That(ex.Message, Contains.Substring("invalid did:web issuer: null"));
#endif
        }

        [Test]
        public void Verify_embedded_receipt_with_did_issuer()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.did.2023-02-13.cose");
            var didDocBytes = readFileBytes("service.2023-03.did.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            CcfReceiptVerifier.RunVerification(receiptBytes, null, didRef => {
                Assert.AreEqual("https://preview-test.scitt.azure.net/.well-known/did.json", didRef.DidDocUrl.ToString());
                return didDoc;
            });
        }

        [Test]
        public void Verify_Using_DID_Success_Test()
        {
            byte[] receiptBytes = readFileBytes("artifact.2023-03-03.receipt.did.2023-03-03.cbor");
            byte[] coseSign1Bytes = readFileBytes("artifact.2023-03-03.cose");
            var didDocBytes = readFileBytes("service.2023-02.did.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            CcfReceiptVerifier.RunVerification(receiptBytes, coseSign1Bytes, didRef => {
                Assert.AreEqual("https://127.0.0.1:42399/.well-known/did.json", didRef.DidDocUrl.ToString());
                return didDoc;
            });
        }

        [Test]
        public void Verify_Using_DID_2_Success_Test()
        {
            byte[] receiptBytes = readFileBytes("artifact.2023-03-15.receipt.did.2023-03-15.cbor");
            byte[] coseSign1Bytes = readFileBytes("artifact.2023-03-15.cose");
            var didDocBytes = readFileBytes("service.2023-03.did.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            CcfReceiptVerifier.RunVerification(receiptBytes, coseSign1Bytes, didRef => {
                Assert.AreEqual("https://preview-test.scitt.azure.net/.well-known/did.json", didRef.DidDocUrl.ToString());
                return didDoc;
            });
        }

        [Test]
        public void Verify_Using_invalid_DID_failure_Test()
        {
            byte[] receiptBytes = readFileBytes("artifact.2023-03-15.receipt.did.2023-03-15.cbor");
            byte[] coseSign1Bytes = readFileBytes("artifact.2023-03-15.cose");
            var didDocBytes = readFileBytes("service.did.invalid.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(receiptBytes, coseSign1Bytes, didRef => didDoc));
            // in net462 the exception message is different
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.True(ex.Message.Contains("Missing cert chain in x5c"));
#endif
        }

        [Test]
        public void Fails_with_receipt_signature_in_ASN1DER_instead_IEEE_encoding()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-08.receipt.2022-12-08.ansi1der.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-12-08.cose");
            var pem = readFileBytes("service.2022-12.cert.pem");
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes));
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.That(ex.Message, Contains.Substring("VerifyReceipt: signature invalid"));
#endif
        }

        [Test]
        public void Fails_with_invalid_service_cert()
        {
            byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.receipt.2023-01-23.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-12-10.cose");
            var pem = readFileBytes("service.other.cert.pem");
            var ex = Assert.Throws<AggregateException>(() => CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes));
#if NETFRAMEWORK
            Assert.True(ex.Message.Contains("One or more errors occurred"));
#else
            Assert.That(ex.Message, Contains.Substring("Certificate chain verification failed"));
#endif
        }

        [Test]
        public void Fails_to_parse_receipt()
        {
            byte[] receiptBytes = readFileBytes("artifact.broken.receipt.cbor");
            byte[] coseSign1Bytes = readFileBytes("sbom.descriptor.2022-11-10.cose");
            var pem = readFileBytes("service.2022-11.cert.pem");
            var ex = Assert.Throws<Exception>(() => CcfReceiptVerifier.RunVerification(certFromPem(pem), receiptBytes, coseSign1Bytes));
            Assert.That(ex.Message, Contains.Substring("Failed to parse Plain Receipt object"));
        }
    }
}
