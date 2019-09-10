// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A JSON Web Key (JWK) is a JavaScript Object Notation (JSON) data
    /// structure that represents a cryptographic key.
    /// For more information, see <see href="http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18"/>.
    /// </summary>
    public class JsonWebKey : IJsonDeserializable, IJsonSerializable
    {
        private static readonly KeyOperation[] AesKeyOperation = { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.WrapKey, KeyOperation.UnwrapKey };
        private static readonly KeyOperation[] RSAPublicKeyOperation = { KeyOperation.Encrypt, KeyOperation.Verify, KeyOperation.WrapKey };
        private static readonly KeyOperation[] RSAPrivateKeyOperation = { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.Sign, KeyOperation.Verify, KeyOperation.WrapKey, KeyOperation.UnwrapKey };
        private static readonly KeyOperation[] ECPublicKeyOperation = { KeyOperation.Sign };
        private static readonly KeyOperation[] ECPrivateKeyOperation = { KeyOperation.Sign, KeyOperation.Verify };

        /// <summary>
        /// The identifier of the key.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Supported JsonWebKey key types (kty) based on the cryptographic algorithm used for the key.
        /// For valid values, see <see cref="KeyType"/>.
        /// </summary>
        public KeyType KeyType { get; set; }

        /// <summary>
        /// Supported Key Operations.
        /// </summary>
        public IList<KeyOperation> KeyOps { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/>.
        /// </summary>
        public JsonWebKey()
        {
            KeyOps = new List<KeyOperation>();
        }

        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/> using type <see cref="KeyType.Octet"/>.
        /// </summary>
        /// <param name="aesProvider">An <see cref="Aes"/> provider.</param>
        /// <exception cref="ArgumentNullException"><paramref name="aesProvider"/> is null.</exception>
        public JsonWebKey(Aes aesProvider)
        {
            Argument.NotNull(aesProvider, nameof(aesProvider));

            KeyType = KeyType.Octet;
            KeyOps = new List<KeyOperation>(AesKeyOperation);

            K = aesProvider.Key;
        }

        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/> using type <see cref="KeyType.EllipticCurve"/>.
        /// </summary>
        /// <param name="ecdsa">An <see cref="ECDsa"/> provider.</param>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ecdsa"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The elliptic curve name is invalid.</exception>
        public JsonWebKey(ECDsa ecdsa, bool includePrivateParameters = default)
        {
            Argument.NotNull(ecdsa, nameof(ecdsa));

            Initialize(ecdsa, includePrivateParameters);
        }

        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/> using type <see cref="KeyType.Rsa"/>.
        /// </summary>
        /// <param name="rsaProvider">An <see cref="RSA"/> provider.</param>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rsaProvider"/> is null.</exception>
        public JsonWebKey(RSA rsaProvider, bool includePrivateParameters = default)
        {
            Argument.NotNull(rsaProvider, nameof(rsaProvider));

            KeyType = KeyType.Rsa;
            KeyOps = new List<KeyOperation>(includePrivateParameters ? RSAPrivateKeyOperation : RSAPublicKeyOperation);

            RSAParameters rsaParameters = rsaProvider.ExportParameters(includePrivateParameters);

            E = rsaParameters.Exponent;
            N = rsaParameters.Modulus;

            D = rsaParameters.D;
            DP = rsaParameters.DP;
            DQ = rsaParameters.DQ;
            P = rsaParameters.P;
            Q = rsaParameters.Q;
            QI = rsaParameters.InverseQ;
        }

        #region RSA Public Key Parameters

        /// <summary>
        /// RSA modulus, in Base64.
        /// </summary>
        public byte[] N { get; set; }

        /// <summary>
        /// RSA public exponent, in Base64.
        /// </summary>
        public byte[] E { get; set; }

        #endregion

        #region RSA Private Key Parameters

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] DP { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] DQ { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] QI { get; set; }

        /// <summary>
        /// RSA secret prime
        /// </summary>
        public byte[] P { get; set; }

        /// <summary>
        /// RSA secret prime, with p &lt; q
        /// </summary>
        public byte[] Q { get; set; }

        #endregion

        #region EC Public Key Parameters

        /// <summary>
        /// The curve for Elliptic Curve Cryptography (ECC) algorithms.
        /// </summary>
        public string CurveName { get; set; }

        /// <summary>
        /// X coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] X { get; set; }

        /// <summary>
        /// Y coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] Y { get; set; }

        #endregion

        #region EC and RSA Private Key Parameters

        /// <summary>
        /// RSA private exponent or ECC private key.
        /// </summary>
        public byte[] D { get; set; }

        #endregion

        #region Symmetric Key Parameters

        /// <summary>
        /// Symmetric key
        /// </summary>
        public byte[] K { get; set; }

        #endregion

        /// <summary>
        /// HSM Token, used with "Bring Your Own Key".
        /// </summary>
        public byte[] T { get; set; }

        /// <summary>
        /// Converts this <see cref="JsonWebKey"/> of type <see cref="KeyType.Octet"/> to an <see cref="Aes"/> object.
        /// </summary>
        /// <returns>An <see cref="Aes"/> object.</returns>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Octet"/> or <see cref="K"/> is null.</exception>
        public Aes ToAes()
        {
            if (KeyType != KeyType.Octet)
            {
                throw new InvalidOperationException("key is not an octet key");
            }

            if (K is null)
            {
                throw new InvalidOperationException("key does not contain a value");
            }

            Aes key = Aes.Create();
            if (key != null)
            {
                key.Key = K;
            }

            return key;
        }

        /// <summary>
        /// Converts this <see cref="JsonWebKey"/> of type <see cref="KeyType.EllipticCurve"/> or <see cref="KeyType.EllipticCurveHsm"/> to an <see cref="ECDsa"/> object.
        /// </summary>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <returns>An <see cref="ECDsa"/> object.</returns>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.EllipticCurve"/> or <see cref="KeyType.EllipticCurveHsm"/>, or one or more key parameters are invalid.</exception>
        public ECDsa ToECDsa(bool includePrivateParameters = false)
        {
            if (KeyType != KeyType.EllipticCurve && KeyType != KeyType.EllipticCurveHsm)
            {
                throw new InvalidOperationException("key is not an EC or EC-HSM type");
            }

            ValidateKeyParameter(nameof(X), X);
            ValidateKeyParameter(nameof(Y), Y);

            return Convert(includePrivateParameters);
        }

        /// <summary>
        /// Converts this <see cref="JsonWebKey"/> of type <see cref="KeyType.Rsa"/> or <see cref="KeyType.RsaHsm"/> to an <see cref="RSA"/> object.
        /// </summary>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <returns>An <see cref="RSA"/> object.</returns>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Rsa"/> or <see cref="KeyType.RsaHsm"/>, or one or more key parameters are invalid.</exception>
        public RSA ToRSA(bool includePrivateParameters = false)
        {
            if (KeyType != KeyType.Rsa && KeyType != KeyType.RsaHsm)
            {
                throw new InvalidOperationException("key is not an RSA or RSA-HSM type");
            }

            ValidateKeyParameter(nameof(E), E);
            ValidateKeyParameter(nameof(N), N);

            // Key parameter length requirements defined by 2.2.2.9.1 RSA Private Key BLOB specification: https://docs.microsoft.com/openspecs/windows_protocols/ms-wcce/5cf2e6b9-3195-4f85-bc18-05b50e6d4e11
            var rsaParameters = new RSAParameters
            {
                Exponent = ForceBufferLength(nameof(E), E, 4),
                Modulus = TrimBuffer(N),
            };

            if (includePrivateParameters)
            {
                var bitLength = rsaParameters.Modulus.Length * 8;

                rsaParameters.D = ForceBufferLength(nameof(D), D, bitLength / 8);
                rsaParameters.DP = ForceBufferLength(nameof(DP), DP, bitLength / 16);
                rsaParameters.DQ = ForceBufferLength(nameof(DQ), DQ, bitLength / 16);
                rsaParameters.P = ForceBufferLength(nameof(P), P, bitLength / 16);
                rsaParameters.Q = ForceBufferLength(nameof(Q), Q, bitLength / 16);
                rsaParameters.InverseQ = ForceBufferLength(nameof(QI), QI, bitLength / 16);
            }

            RSA rsa = RSA.Create();
            rsa.ImportParameters(rsaParameters);

            return rsa;
        }

        private const string KeyIdPropertyName = "kid";
        private const string KeyTypePropertyName = "kty";
        private static readonly JsonEncodedText KeyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private const string KeyOpsPropertyName = "key_ops";
        private static readonly JsonEncodedText KeyOpsPropertyNameBytes = JsonEncodedText.Encode(KeyOpsPropertyName);
        private const string CurveNamePropertyName = "curveName";
        private static readonly JsonEncodedText CurveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private const string NPropertyName = "n";
        private static readonly JsonEncodedText NPropertyNameBytes = JsonEncodedText.Encode(NPropertyName);
        private const string EPropertyName = "e";
        private static readonly JsonEncodedText EPropertyNameBytes = JsonEncodedText.Encode(EPropertyName);
        private const string DPPropertyName = "dp";
        private static readonly JsonEncodedText DPPropertyNameBytes = JsonEncodedText.Encode(DPPropertyName);
        private const string DQPropertyName = "dq";
        private static readonly JsonEncodedText DQPropertyNameBytes = JsonEncodedText.Encode(DQPropertyName);
        private const string QIPropertyName = "qi";
        private static readonly JsonEncodedText QIPropertyNameBytes = JsonEncodedText.Encode(QIPropertyName);
        private const string PPropertyName = "p";
        private static readonly JsonEncodedText PPropertyNameBytes = JsonEncodedText.Encode(PPropertyName);
        private const string QPropertyName = "q";
        private static readonly JsonEncodedText QPropertyNameBytes = JsonEncodedText.Encode(QPropertyName);
        private const string XPropertyName = "x";
        private static readonly JsonEncodedText XPropertyNameBytes = JsonEncodedText.Encode(XPropertyName);
        private const string YPropertyName = "y";
        private static readonly JsonEncodedText YPropertyNameBytes = JsonEncodedText.Encode(YPropertyName);
        private const string DPropertyName = "d";
        private static readonly JsonEncodedText DPropertyNameBytes = JsonEncodedText.Encode(DPropertyName);
        private const string KPropertyName = "k";
        private static readonly JsonEncodedText KPropertyNameBytes = JsonEncodedText.Encode(KPropertyName);
        private const string TPropertyName = "t";
        private static readonly JsonEncodedText TPropertyNameBytes = JsonEncodedText.Encode(TPropertyName);

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case KeyTypePropertyName:
                        KeyType = prop.Value.GetString();
                        break;
                    case KeyOpsPropertyName:
                        foreach (var element in prop.Value.EnumerateArray())
                        {
                            KeyOps.Add(element.ToString());
                        }
                        break;
                    case CurveNamePropertyName:
                        CurveName = prop.Value.GetString();
                        break;
                    case NPropertyName:
                        N = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case EPropertyName:
                        E = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case DPPropertyName:
                        DP = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case DQPropertyName:
                        DQ = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case QIPropertyName:
                        QI = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case PPropertyName:
                        P = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case QPropertyName:
                        Q = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case XPropertyName:
                        X = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case YPropertyName:
                        Y = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case DPropertyName:
                        D = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case KPropertyName:
                        K = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case TPropertyName:
                        T = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (KeyType != default)
            {
                json.WriteString(KeyTypePropertyNameBytes, KeyType);
            }
            if (KeyOps != null)
            {
                json.WriteStartArray(KeyOpsPropertyNameBytes);
                foreach (var operation in KeyOps)
                {
                    json.WriteStringValue(operation);
                }
                json.WriteEndArray();
            }
            if (!string.IsNullOrEmpty(CurveName))
            {
                json.WriteString(CurveNamePropertyNameBytes, CurveName);
            }
            if (N != null)
            {
                json.WriteString(NPropertyNameBytes, Base64Url.Encode(N));
            }
            if (E != null)
            {
                json.WriteString(EPropertyNameBytes, Base64Url.Encode(E));
            }
            if (DP != null)
            {
                json.WriteString(DPPropertyNameBytes, Base64Url.Encode(DP));
            }
            if (DQ != null)
            {
                json.WriteString(DQPropertyNameBytes, Base64Url.Encode(DQ));
            }
            if (QI != null)
            {
                json.WriteString(QIPropertyNameBytes, Base64Url.Encode(QI));
            }
            if (P != null)
            {
                json.WriteString(PPropertyNameBytes, Base64Url.Encode(P));
            }
            if (Q != null)
            {
                json.WriteString(QPropertyNameBytes, Base64Url.Encode(Q));
            }
            if (X != null)
            {
                json.WriteString(XPropertyNameBytes, Base64Url.Encode(X));
            }
            if (Y != null)
            {
                json.WriteString(YPropertyNameBytes, Base64Url.Encode(Y));
            }
            if (D != null)
            {
                json.WriteString(DPropertyNameBytes, Base64Url.Encode(D));
            }
            if (K != null)
            {
                json.WriteString(KPropertyNameBytes, Base64Url.Encode(K));
            }
            if (T != null)
            {
                json.WriteString(TPropertyNameBytes, Base64Url.Encode(T));
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);

        private static byte[] ForceBufferLength(string name, byte[] value, int requiredLength)
        {
            if (value is null || value.Length == 0)
            {
                throw new InvalidOperationException($"key parameter {name} is null or empty");
            }

            if (value.Length == requiredLength)
            {
                return value;
            }

            if (value.Length < requiredLength)
            {
                byte[] padded = new byte[requiredLength];
                Array.Copy(value, 0, padded, requiredLength - value.Length, value.Length);

                return padded;
            }

            // Throw if any extra bytes are non-zero.
            var extraLength = value.Length - requiredLength;
            for (int i = 0; i < extraLength; ++i)
            {
                if (value[i] != 0)
                {
                    throw new InvalidOperationException($"key parameter {name} is too long: expected at most {requiredLength} bytes, but found {value.Length - i} bytes");
                }
            }

            byte[] trimmed = new byte[requiredLength];
            Array.Copy(value, value.Length - requiredLength, trimmed, 0, requiredLength);

            return trimmed;
        }

        private static readonly byte[] ZeroBuffer = new byte[] { 0 };
        private static byte[] TrimBuffer(byte[] value)
        {
            if (value is null || value.Length <= 1 || value[0] != 0)
            {
                return value;
            }

            for (int i = 1; i < value.Length; ++i)
            {
                if (value[i] != 0)
                {
                    var trimmed = new byte[value.Length - i];
                    Array.Copy(value, i, trimmed, 0, trimmed.Length);

                    return trimmed;
                }
            }

            return ZeroBuffer;
        }

        private static void ValidateKeyParameter(string name, byte[] value)
        {
            if (value != null)
            {
                for (int i = 0; i < value.Length; ++i)
                {
                    if (value[i] != 0)
                    {
                        return;
                    }
                }
            }

            throw new InvalidOperationException($"key parameter {name} is null or zeros");
        }

        // ECParameters is defined in netstandard2.0 but not net461 (introduced in net47). Separate method with no inlining to prevent TypeLoadException on net461.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Initialize(ECDsa ecdsa, bool includePrivateParameters)
        {
            KeyType = KeyType.EllipticCurve;
            KeyOps = new List<KeyOperation>(includePrivateParameters ? ECPrivateKeyOperation : ECPublicKeyOperation);

            ECParameters ecParameters = ecdsa.ExportParameters(includePrivateParameters);
            CurveName = KeyCurveName.Find(ecParameters.Curve.Oid, ecdsa.KeySize).ToString() ?? throw new InvalidOperationException("elliptic curve name is invalid");
            D = ecParameters.D;
            X = ecParameters.Q.X;
            Y = ecParameters.Q.Y;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private ECDsa Convert(bool includePrivateParameters)
        {
            ref readonly KeyCurveName curveName = ref KeyCurveName.Find(CurveName);

            int requiredParameterSize = curveName.KeyParameterSize;
            if (requiredParameterSize <= 0)
            {
                throw new InvalidOperationException($"invalid curve name: {CurveName ?? "null"}");
            }

            ECParameters ecParameters = new ECParameters
            {
                Curve = ECCurve.CreateFromOid(curveName.Oid),
                Q = new ECPoint
                {
                    X = ForceBufferLength(nameof(X), X, requiredParameterSize),
                    Y = ForceBufferLength(nameof(Y), Y, requiredParameterSize),
                },
            };

            if (includePrivateParameters)
            {
                ecParameters.D = ForceBufferLength(nameof(D), D, requiredParameterSize);
            }

            ECDsa ecdsa = ECDsa.Create();
            ecdsa.ImportParameters(ecParameters);

            return ecdsa;
        }
    }
}
