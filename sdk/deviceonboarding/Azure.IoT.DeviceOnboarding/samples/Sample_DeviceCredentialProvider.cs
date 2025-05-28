// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Cose;
using System.Security.Cryptography.X509Certificates;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    public class Sample_DeviceCredentialProvider : DeviceCredentialProvider
    {
        public AsymmetricAlgorithm privateKey;

        private KeySize deviceKeySize = KeySize.KeySize256;
        private PublicKeyType devicePublicKeyType = PublicKeyType.SECP256R1;

        private DeviceCredential creds;

        /// <inheritdoc/>
        public override CoseSign1Message CreateCoseSign1Message(byte[] payload, CoseHeaderMap unprotectedHeaders, PublicKeyType publicKeyType, AsymmetricAlgorithm privateKeyToSign = null)
        {
            var signingKey = privateKeyToSign ?? privateKey;
            var keySize = signingKey.KeySize;
            var coseAlgoID = GetCoseAlgorithm(publicKeyType, keySize);
            var hashingAlgorithm = HashHelper.GetSupportedHashAlgorithm(publicKeyType, keySize);

            // Created protected header with Algorithm Id
            CoseHeaderMap protectedHeader = new()
                {
                    { CoseHeaderLabel.Algorithm, coseAlgoID }
                };

            // Create Cose Signer
            CoseSigner coseSigner = CreateCoseSigner(signingKey, publicKeyType, hashingAlgorithm, protectedHeader, unprotectedHeaders);

            // Sign the payload
            var encoded = CoseSign1Message.SignEmbedded(payload, coseSigner, null);

            return CoseMessage.DecodeSign1(encoded);
        }

        /// <inheritdoc/>
        public override Hash GetCertChainHash(CertChain certChain)
        {
            try
            {
                if (!(certChain.Chain == null || certChain.Chain == null || certChain.Chain.Count == 0))
                {
                    var hashAlgorithm = HashHelper.GetHashType(GetKeySize(certChain.Chain.First()));
                    byte[] certChainConcatenated;
                    using (var memoryStream = new MemoryStream())
                    {
                        foreach (var cert in certChain.Chain)
                        {
                            var certData = cert.GetRawCertData();
                            memoryStream.Write(certData,0, certData.Length);
                        }
                        certChainConcatenated = memoryStream.ToArray();
                    }
                    var data = HashHelper.GetHashValue(hashAlgorithm, certChainConcatenated);

                    var hash = new Hash
                    {
                        HashType = hashAlgorithm,
                        HashValue = data
                    };
                    return hash;
                }
                else
                {
                    throw new Exception("Provide a valid Cert Chain.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public override CertChain GetDeviceCertificate()
        {
            try
            {
                var hashingAlgorithm = HashHelper.GetSupportedHashAlgorithm(devicePublicKeyType, (int)deviceKeySize);
#if NET8_0_OR_GREATER
                privateKey = ECDsa.Create(System.Security.Cryptography.ECCurve.NamedCurves.nistP256);
                var request = new CertificateRequest(new X500DistinguishedName("CN=Device.AzureLocal"),(ECDsa)privateKey, hashingAlgorithm);
                var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(365));
#else
                var curvename = "secp256k1";
                var signtype = "SHA1withECDSA";
                X9ECParameters ecParams = ECNamedCurveTable.GetByName(curvename);
                var curveparam = new ECDomainParameters(ecParams.Curve, ecParams.G, ecParams.N, ecParams.H, ecParams.GetSeed());
                ECKeyGenerationParameters keygenParams = new Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters(curveparam, new SecureRandom());

                ECKeyPairGenerator kpGenerator = new ECKeyPairGenerator("ECDSA");
                kpGenerator.Init(keygenParams);
                var subjectKeyPair = kpGenerator.GenerateKeyPair();

                X509V3CertificateGenerator generator = new X509V3CertificateGenerator();
                generator.SetIssuerDN(new X509Name("CN=Device.AzureLocal"));
                generator.SetSerialNumber(Org.BouncyCastle.Math.BigInteger.ProbablePrime(120, new Random()));
                generator.SetNotBefore(DateTime.Now);
                generator.SetNotAfter(DateTime.Now.AddYears(1));
                generator.SetSubjectDN(new X509Name("CN=Device.AzureLocal"));
                generator.SetPublicKey(subjectKeyPair.Public);
                Asn1SignatureFactory signatureFactory = new Asn1SignatureFactory(signtype, subjectKeyPair.Private);
                Org.BouncyCastle.X509.X509Certificate serverSignedPublicKey = generator.Generate(signatureFactory);
                var certificate = new X509Certificate2(serverSignedPublicKey.GetEncoded());
                //save private key for other methods
                var privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(subjectKeyPair.Private);
                var asn1Seq = (Asn1Sequence)Asn1Object.FromByteArray(
                    privateKeyInfo.ParsePrivateKey().GetDerEncoded());
                var ecdKeyStruct = ECPrivateKeyStructure.GetInstance(asn1Seq);
                privateKey = ECDsa.Create();
                //privateKey = DotNetUtilities.ToX509Certificate(ecdKeyStruct);
#endif
                var deviceCertificateChain = new CertChain();
                deviceCertificateChain.Chain = new List<X509Certificate2> { certificate };
                return deviceCertificateChain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public override DeviceCredential GetDeviceCredentials(RendezvousInfo rvInfo)
        {
            if (this.creds == null)
            {
                var deviceCert = GetDeviceCertificate();
                var certChainHash = GetCertChainHash(deviceCert);
                var deviceCredentials = new DeviceCredential(
                    isActive: true,
                    guid:Guid.Parse("ad5560fc-edbf-4a4e-a190-d297eb98a250"),
                    protocolVersion:ProtocolVersion.V101,
                    deviceInfo: "sampledeviceinfo",
                    rendezvousInfo: rvInfo,
                    publicKeyType: devicePublicKeyType,
                    keySize: deviceKeySize
                );

                SetDeviceCredentials(deviceCredentials);
                return deviceCredentials;
            }
            else
            {
                return this.creds; ;
            }
        }

        /// <inheritdoc/>
        public override Hash GetHMAC(byte[] payload, KeySize keySize, string keyIdenitifier)
        {
            try
            {
                var data = HashHelper.GetHashValue(HashHelper.GetHashType(keySize, true), payload);
                var hmac = new Hash()
                {
                    HashValue = data,
                    HashType = HashHelper.GetHashType(keySize, true)
                };
                return hmac;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public override void SetDeviceCredentials(DeviceCredential deviceCreds)
        {
            this.creds = deviceCreds;
        }

        /// <inheritdoc/>
        private int GetCoseAlgorithm(PublicKeyType keyType, int keySize)
        {
            // EC values come from COSE spec, table 5
            // RSA From https://datatracker.ietf.org/doc/html/draft-ietf-cose-webauthn-algorithms-05

            return keyType switch
            {
                PublicKeyType.SECP256R1 => -7,//COSE spec, table 5
                PublicKeyType.SECP384R1 => -35,// COSE spec, table 5
                PublicKeyType.RSA2048RESTR => -257,// see note above
                PublicKeyType.RSAPKCS => keySize switch
                {
                    2048 => -257,// see note above
                    3072 => -258,// see note above
                    256 => throw new NotImplementedException(),
                    384 => throw new NotImplementedException(),
                    _ => throw new ArgumentException("KeySize " + keySize),
                },
                _ => throw new ArgumentException("PublicKeyType " + keyType),
            };
        }

        /// <summary>
        /// Create COSE Signer
        /// </summary>
        /// <param name="privateKey">Paylod.</param>
        /// <param name="fdoPublicKeyType">Used to determine Cose Algorithm Id and Hashing Algorithm.</param>
        /// <param name="hashingAlgorithm">Hashing Algorithm.</param>
        /// <param name="protectedHeader">Protected Header Map.</param>
        /// <returns>
        /// Cose Signer
        /// </returns>
        private static CoseSigner CreateCoseSigner(AsymmetricAlgorithm privateKey, PublicKeyType fdoPublicKeyType, HashAlgorithmName hashingAlgorithm, CoseHeaderMap protectedHeader, CoseHeaderMap unprotectedHeader)
        {
            try
            {
                if (privateKey is RSA)
                {
                    var rsaPadding = RSASignaturePadding.Pkcs1;

                    if (fdoPublicKeyType.Equals(PublicKeyType.RSAPSS))
                    {
                        rsaPadding = RSASignaturePadding.Pss;
                    }

                    return new CoseSigner((RSA)privateKey, rsaPadding, hashingAlgorithm, protectedHeader, unprotectedHeader);
                }
                else if (privateKey is ECDsa)
                {
                    return new CoseSigner((ECDsa)privateKey, hashingAlgorithm, protectedHeader, unprotectedHeader);
                }
                else
                {
                    throw new ArgumentException("Invalid Key Type.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Key Size from X509Certificat2
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        internal static KeySize GetKeySize(X509Certificate2 cert)
        {
            try
            {
                var publicKey = Models.PublicKey.GetPublicKeyFromCert(cert);
                var keySize = publicKey.KeySize;

                switch (keySize)
                {
                    case 256:
                        return KeySize.KeySize256;
                    case 2048:
                        return KeySize.KeySize2048;
                    case 384:
                        return KeySize.KeySize384;
                    case 3072:
                        return KeySize.KeySize3072;
                    default:
                        throw new InvalidDataException($"Key size {keySize} not supported");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
