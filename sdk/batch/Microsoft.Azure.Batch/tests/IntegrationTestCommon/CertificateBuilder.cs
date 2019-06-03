// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IntegrationTestCommon
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Linq;
    using Org.BouncyCastle.Crypto.Prng;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.Crypto.Operators;

    /// <summary>
    /// Static class for generating pfx and cer files.
    /// </summary>
    public static class CertificateBuilder
    {
        public static string Sha1Algorithm = "sha1WithRSA";
        public static string Sha256Algorithm = "sha256WithRSA";

        /// <summary>
        /// Create a self signed certificate in the specified file.
        /// </summary>
        /// <param name="subjectName">The subject of the certificate to create.</param>
        /// <param name="fileName">The file name to write the certificate to.</param>
        /// <param name="signatureAlgorithm">The signature algorithm to use</param>
        /// <param name="password">True if there is a password, false otherwise.  Note that if there is a password, PFX format is assumed.</param>
        public static void CreateSelfSignedInFile(string subjectName, string fileName, string signatureAlgorithm, string password = "")
        {
            byte[] serialNumber = GenerateSerialNumber();
            string subject = string.Format("CN={0}", subjectName);

            var subjectDN = new X509Name(subject);
            var issuerDN = subjectDN;

            const int keyStrength = 2048;
            var randomGenerator = new CryptoApiRandomGenerator();
            var random = new SecureRandom(randomGenerator);
            var keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            var subjectKeyPair = keyPairGenerator.GenerateKeyPair();
            var issuerKeyPair = subjectKeyPair;

            ISignatureFactory signatureFactory = new Asn1SignatureFactory(signatureAlgorithm, issuerKeyPair.Private, random);


            var certificateGenerator = new X509V3CertificateGenerator();
            certificateGenerator.AddExtension(X509Extensions.ExtendedKeyUsage.Id, true, new ExtendedKeyUsage(KeyPurposeID.IdKPServerAuth));
            certificateGenerator.SetSerialNumber(new BigInteger(serialNumber.Concat(new Byte[] { 0 }).ToArray()));
            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);
            certificateGenerator.SetNotBefore(DateTime.Now);
            certificateGenerator.SetNotAfter(DateTime.Now);
            certificateGenerator.SetPublicKey(subjectKeyPair.Public);
            var certificate = certificateGenerator.Generate(signatureFactory);


            var store = new Pkcs12Store();
            string friendlyName = certificate.SubjectDN.ToString();
            var certificateEntry = new X509CertificateEntry(certificate);
            store.SetCertificateEntry(friendlyName, certificateEntry);
            store.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(subjectKeyPair.Private), new[] { certificateEntry });
            var stream = new MemoryStream();
            store.Save(stream, password.ToCharArray(), random);

            var convertedCertificate = new X509Certificate2(stream.ToArray(), password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            //If password is not empty, generate a PKCS#12 formatted file
            if (!string.IsNullOrEmpty(password))
            {
                File.WriteAllBytes(fileName, stream.ToArray());
            }
            //If password is empty generate a DER formatted file
            else
            {
                File.WriteAllBytes(fileName, convertedCertificate.RawData);
            }

        }

        private static byte[] GenerateSerialNumber()
        {
            byte[] sn = Guid.NewGuid().ToByteArray();

            //The high bit must be unset
            sn[0] &= 0x7F;

            return sn;
        }
    }
}
