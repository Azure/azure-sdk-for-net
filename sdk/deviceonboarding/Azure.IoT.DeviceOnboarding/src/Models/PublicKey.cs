// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Public key data type
    /// </summary>
    public class PublicKey
    {
        /// <summary>
        /// RSA Signature Algorithm
        /// </summary>
        private const string RSAAlgo = "RSA";

        /// <summary>
        /// RSA PSS Signature Algorithm
        /// </summary>
        private const string RSAPSSAlgo = "RSASSA-PSS";

        /// <summary>
        /// Type of Public key
        /// </summary>
        public PublicKeyType Type { get; set; }

        /// <summary>
        /// Type of Public Key Encoding
        /// </summary>
        public PublicKeyEncoding Encoding { get; set; }

        /// <summary>
        /// value of owner public key
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Create new instance of PublicKey from cert collection
        /// </summary>
        /// <param name="certs"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static PublicKey GeneratePublicKey(X509Certificate2Collection certs, PublicKeyEncoding encoding)
        {
            try
            {
                var publicKey = new PublicKey();
                publicKey.Encoding = encoding;
                ValidateX509Chain(certs);
                if (PublicKeyEncoding.X509.Equals(encoding))
                {
                    X509Certificate2 cert = certs[0];
#if NETSTANDARD
                    publicKey.Body = cert.PublicKey.EncodedKeyValue.RawData;
#else
                    var key = GetPublicKeyFromCert(cert);
                    publicKey.Body = key.ExportSubjectPublicKeyInfo();
#endif
                    publicKey.Type = GetPublicKeyTypeFromCert(certs[0]);
                }
                else if (PublicKeyEncoding.COSEX5CHAIN.Equals(encoding))
                {
                    var certChain = new CertChain();
                    certChain.Chain = [.. certs];
                    publicKey.Body = certChain;
                    publicKey.Type = GetPublicKeyTypeFromCert(certs[0]);
                }
                else
                {
                    var err = $"Public Key Encoding - {encoding} not supported";
                    throw new ArgumentException(err);
                }
                return publicKey;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is PublicKey ownerPublicKey)
            {
                if (this.Type != ownerPublicKey.Type)
                {
                    return false;
                }

                if (this.Encoding != ownerPublicKey.Encoding)
                {
                    return false;
                }

                if (this.Encoding == PublicKeyEncoding.X509)
                {
                    byte[] keyA = ConvertToType<byte[]>(this.Body);
                    byte[] keyB = ConvertToType<byte[]>(ownerPublicKey.Body);
                    return StructuralComparisons.StructuralEqualityComparer.Equals(keyA, keyB);
                }
                else if (this.Encoding == PublicKeyEncoding.COSEX5CHAIN)
                {
                    CertChain keyA = ConvertToType<CertChain>(this.Body);
                    CertChain keyB = ConvertToType<CertChain>(ownerPublicKey.Body);
                    return Equals(keyA, keyB);
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = HashCode.Combine(Type, Encoding);

            if (Encoding == PublicKeyEncoding.X509)
            {
                byte[] key = ConvertToType<byte[]>(Body);
                if (key != null)
                {
                    foreach (var val in key)
                    {
                        hashCode = HashCode.Combine(hashCode, val);
                    }
                }
            }
            else if (Encoding == PublicKeyEncoding.COSEX5CHAIN)
            {
                CertChain key = ConvertToType<CertChain>(Body);
                if (key != null)
                {
                    hashCode = HashCode.Combine(hashCode, key.GetHashCode());
                }
            }

            return hashCode;
        }

        private static T ConvertToType<T>(object obj) where T : class
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
            {
                return null;
            }
        }

        /// <summary>
        /// Validate the certificate chain
        /// </summary>
        /// <param name="certs"></param>
        /// <exception cref="InvalidDataException"></exception>
        private static void ValidateX509Chain(X509Certificate2Collection certs)
        {
            foreach (var certificate in certs)
            {
                if (certificate.HasPrivateKey)
                {
                    throw new InvalidDataException("Please provide a certificate with only public key for Ownership Voucher creation.");
                }
            }
        }

        /// <summary>
        /// Get the PublicKey from the cert
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        public static AsymmetricAlgorithm GetPublicKeyFromCert(X509Certificate2 cert)
        {
            if (cert.GetRSAPublicKey() != null)
            {
                return cert.GetRSAPublicKey();
            }
            else if (cert.GetECDsaPublicKey() != null)
            {
                return cert.GetECDsaPublicKey();
            }
            else
            {
                throw new InvalidOperationException("Certificate Public Key is not supported.");
            }
        }

        /// <summary>
        /// Get PublicKeyType from the cert
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static PublicKeyType GetPublicKeyTypeFromCert(X509Certificate2 cert)
        {
            if (cert.GetECDsaPublicKey() != null)
            {
                Console.Write($"{cert.FriendlyName} is ecdsa");
                var curve = cert.GetECDsaPublicKey().ExportParameters(false).Curve;
                if (curve.Oid.Value.Equals(ECCurve.NamedCurves.nistP256.Oid.Value))
                {
                    return PublicKeyType.SECP256R1;
                }
                else if (curve.Oid.Value.Equals(ECCurve.NamedCurves.nistP384.Oid.Value))
                {
                    return PublicKeyType.SECP384R1;
                }
                else
                {
                    throw new InvalidOperationException($"EC Curve {curve} not supported");
                }
            }
            else if (cert.GetRSAPublicKey() != null)
            {
                Console.Write($"{cert.FriendlyName} is rsa");
                var rsaKey = cert.GetRSAPublicKey();

                if (rsaKey.SignatureAlgorithm.Equals(RSAAlgo))
                {
                    var certSignAlgo = cert.SignatureAlgorithm?.FriendlyName;
                    if (!string.IsNullOrEmpty(certSignAlgo) && certSignAlgo.Equals(RSAPSSAlgo))
                    {
                        return PublicKeyType.RSAPSS;
                    }
                    else
                    {
                        return PublicKeyType.RSAPKCS;
                    }
                }
                else
                {
                    var ex = new ArgumentException($"Not a valid RSA key, Expected Signature Algorithm {RSAAlgo} , found {rsaKey.SignatureAlgorithm}");
                    throw ex;
                }
            }
            else
            {
                throw new InvalidOperationException("Certificate Public Key Type is not supported.");
            }
        }

        /// <summary>
        /// Convert FDO Public Key to AsymmetricAlgorithm Key Type
        /// </summary>
        /// <param name="fdoPublicKey"></param>
        /// <returns>
        /// Public Key
        /// </returns>
        internal static AsymmetricAlgorithm DecodeFDOPublicKey(PublicKey fdoPublicKey)
        {
                var publicKeyType = fdoPublicKey.Type;
                if (publicKeyType.Equals(PublicKeyType.RSAPSS) || publicKeyType.Equals(PublicKeyType.RSAPKCS)
                    || publicKeyType.Equals(PublicKeyType.RSA2048RESTR))
                {
                    if (fdoPublicKey.Encoding.Equals(PublicKeyEncoding.X509))
                    {
                        var rsa = RSA.Create();
                        var rsaPubBytes = ConvertToType<byte[]>(fdoPublicKey.Body);
#if NET8_0
                        rsa.ImportSubjectPublicKeyInfo(rsaPubBytes, out _);
#endif
                        return rsa;
                    }

                    else if (fdoPublicKey.Encoding.Equals(PublicKeyEncoding.COSEX5CHAIN))
                    {
                        var certs = ConvertToType<CertChain>(fdoPublicKey.Body);
                        return certs.Chain.FirstOrDefault().GetRSAPublicKey();
                    }
                    else
                    {
                        var err = "Public Key encoding not supported";
                        throw new Exception(err);
                    }
                }
                else if (publicKeyType.Equals(PublicKeyType.SECP256R1) || publicKeyType.Equals(PublicKeyType.SECP384R1))
                {
                    if (fdoPublicKey.Encoding.Equals(PublicKeyEncoding.X509))
                    {
                        var ecdsa = ECDsa.Create();
                        var pubKeyBytes = ConvertToType<byte[]>(fdoPublicKey.Body);
#if NET8_0_OR_GREATER
                        ecdsa.ImportSubjectPublicKeyInfo(pubKeyBytes, out _);
#endif
                        return ecdsa;
                    }
                    else if (fdoPublicKey.Encoding.Equals(PublicKeyEncoding.COSEX5CHAIN))
                    {
                        var certs = ConvertToType<CertChain>(fdoPublicKey.Body);
                        return certs.Chain.FirstOrDefault().GetECDsaPublicKey();
                    }
                    else
                    {
                        var err = $"Public Key encoding {fdoPublicKey.Encoding} not supported";
                        throw new NotSupportedException(err);
                    }
                }
                else
                {
                    var err = $"Public Key Type - {fdoPublicKey.Type} not supported";
                    throw new ArgumentException(err);
                }
        }

        /// <summary>
        /// Get Key Size from PublicKey
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static KeySize GetKeySize(PublicKey ownerPublicKey)
        {
            var publicKey = DecodeFDOPublicKey(ownerPublicKey);
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
        /// <summary>
        /// Validate Public Private Key Pair
        /// </summary>
        /// <param name="fdoPublicKey"/>
        /// <param name="privateKey"/>
        internal static void ValidateOwnerKeyPair(PublicKey fdoPublicKey, AsymmetricAlgorithm privateKey)
        {
            // We have already tried to validate the public key and private key type
            // while trying to read the private key.

            var publicKeyType = fdoPublicKey.Type;
            var publicKey = DecodeFDOPublicKey(fdoPublicKey);
            var pkType = fdoPublicKey.Type;
            if (IsRSAKey(pkType))
            {
                try
                {
                    var rsaPrivateKey = (RSA)privateKey;
                    var privateKeyParams = rsaPrivateKey.ExportParameters(true);
                    var publicKeyParams = ((RSA)publicKey).ExportParameters(false);
                    var hashAlgoName = HashHelper.GetSupportedHashAlgorithm(pkType, rsaPrivateKey.KeySize);

                    if (privateKeyParams.Modulus.SequenceEqual(publicKeyParams.Modulus) &&
                        privateKeyParams.Exponent.SequenceEqual(publicKeyParams.Exponent))
                    {
                        byte[] testBytes = System.Text.Encoding.UTF8.GetBytes("testData");
                        byte[] signedBytes;
                        using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider())
                        {
                            var rsaKey = (RSA)privateKey;
                            var keyParams = rsaKey.ExportParameters(true);
                            rsaProvider.ImportParameters(keyParams);
                            signedBytes = rsaProvider.SignData(testBytes, CryptoConfig.MapNameToOID(hashAlgoName.ToString()));
                        }
                        var status = false;
                        using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider())
                        {
                            var rsaKey = (RSA)publicKey;
                            var keyParams = rsaKey.ExportParameters(false);
                            rsaProvider.ImportParameters(keyParams);
                            status = rsaProvider.VerifyData(testBytes, CryptoConfig.MapNameToOID(hashAlgoName.ToString()), signedBytes);
                        }
                        if (status == false)
                        {
                            var err = $"The provided key pair do not match as sign and verification failed.";
                            throw new Exception(err);
                        }
                    }
                    else
                    {
                        var err = $"The provided key pair do not match.";
                        throw new Exception(err);
                    }
                }
                catch (Exception ex)
                {
                    var err = $"Validation of Key pair failed with exception {ex.Message}";
                    throw;
                }
            }
            else if (IsECDsaKey(pkType))
            {
                try
                {
                    var ecdsaPrivateKey = (ECDsa)privateKey;
                    var ecdsaPublicKey = (ECDsa)publicKey;
                    var hashingAlgoName = HashHelper.GetSupportedHashAlgorithm(pkType, ecdsaPublicKey.KeySize);

                    byte[] testBytes = System.Text.Encoding.UTF8.GetBytes("testData");
                    var ecdsa = (ECDsa)ecdsaPrivateKey;
                    byte[] signedBytes = ecdsa.SignData(testBytes, (HashAlgorithmName)hashingAlgoName);
                    var ecdsaPubKey = (ECDsa)ecdsaPublicKey;
                    var status = ecdsaPubKey.VerifyData(testBytes, signedBytes, (HashAlgorithmName)hashingAlgoName);
                    if (status == false)
                    {
                        var err = $"The provided key pair do not match as sign and verification failed.";
                        throw new Exception(err);
                    }
                }
                catch (Exception ex)
                {
                    var err = $"Validation of Key pair failed with exception {ex.Message}";
                    throw;
                }
            }
            else
            {
                var err = $"The FDO Public Key Type does not match RSA or ECDsa.";
                throw new Exception(err);
            }
        }

        private static bool IsRSAKey(PublicKeyType publicKeyType)
        {
            if (publicKeyType.Equals(PublicKeyType.RSAPSS) || publicKeyType.Equals(PublicKeyType.RSAPKCS)
                    || publicKeyType.Equals(PublicKeyType.RSA2048RESTR))
            {
                return true;
            }
            return false;
        }

        private static bool IsECDsaKey(PublicKeyType publicKeyType)
        {
            if (publicKeyType.Equals(PublicKeyType.SECP256R1) || publicKeyType.Equals(PublicKeyType.SECP384R1))
            {
                return true;
            }
            return false;
        }
    }
}
