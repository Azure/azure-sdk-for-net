// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A JSON Web Key (JWK) is a JavaScript Object Notation (JSON) data
    /// structure that represents a cryptographic key.
    /// For more information, see <see href="http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18">JSON Web Key (JWK)</see>.
    /// </summary>
    [JsonConverter(typeof(JsonWebKeyConverter))]
    public class JsonWebKey : IJsonDeserializable, IJsonSerializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string KeyTypePropertyName = "kty";
        private const string KeyOpsPropertyName = "key_ops";
        private const string CurveNamePropertyName = "crv";
        private const string NPropertyName = "n";
        private const string EPropertyName = "e";
        private const string DPPropertyName = "dp";
        private const string DQPropertyName = "dq";
        private const string QIPropertyName = "qi";
        private const string PPropertyName = "p";
        private const string QPropertyName = "q";
        private const string XPropertyName = "x";
        private const string YPropertyName = "y";
        private const string DPropertyName = "d";
        private const string KPropertyName = "k";
        private const string TPropertyName = "key_hsm";

        private static readonly JsonEncodedText s_keyIdPropertyNameBytes = JsonEncodedText.Encode(KeyIdPropertyName);
        private static readonly JsonEncodedText s_keyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private static readonly JsonEncodedText s_keyOpsPropertyNameBytes = JsonEncodedText.Encode(KeyOpsPropertyName);
        private static readonly JsonEncodedText s_curveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private static readonly JsonEncodedText s_nPropertyNameBytes = JsonEncodedText.Encode(NPropertyName);
        private static readonly JsonEncodedText s_ePropertyNameBytes = JsonEncodedText.Encode(EPropertyName);
        private static readonly JsonEncodedText s_dPPropertyNameBytes = JsonEncodedText.Encode(DPPropertyName);
        private static readonly JsonEncodedText s_dQPropertyNameBytes = JsonEncodedText.Encode(DQPropertyName);
        private static readonly JsonEncodedText s_qIPropertyNameBytes = JsonEncodedText.Encode(QIPropertyName);
        private static readonly JsonEncodedText s_pPropertyNameBytes = JsonEncodedText.Encode(PPropertyName);
        private static readonly JsonEncodedText s_qPropertyNameBytes = JsonEncodedText.Encode(QPropertyName);
        private static readonly JsonEncodedText s_xPropertyNameBytes = JsonEncodedText.Encode(XPropertyName);
        private static readonly JsonEncodedText s_yPropertyNameBytes = JsonEncodedText.Encode(YPropertyName);
        private static readonly JsonEncodedText s_dPropertyNameBytes = JsonEncodedText.Encode(DPropertyName);
        private static readonly JsonEncodedText s_kPropertyNameBytes = JsonEncodedText.Encode(KPropertyName);
        private static readonly JsonEncodedText s_tPropertyNameBytes = JsonEncodedText.Encode(TPropertyName);

        private static readonly KeyOperation[] s_aesKeyOperation = { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.WrapKey, KeyOperation.UnwrapKey };
        private static readonly KeyOperation[] s_rSAPublicKeyOperation = { KeyOperation.Encrypt, KeyOperation.Verify, KeyOperation.WrapKey };
        private static readonly KeyOperation[] s_rSAPrivateKeyOperation = { KeyOperation.Encrypt, KeyOperation.Decrypt, KeyOperation.Sign, KeyOperation.Verify, KeyOperation.WrapKey, KeyOperation.UnwrapKey };
        private static readonly KeyOperation[] s_eCPublicKeyOperation = { KeyOperation.Sign };
        private static readonly KeyOperation[] s_eCPrivateKeyOperation = { KeyOperation.Sign, KeyOperation.Verify };

        private readonly IList<KeyOperation> _keyOps;

        /// <summary>
        /// Gets the identifier of the key. This is not limited to a <see cref="Uri"/>.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the <see cref="KeyType"/> for this <see cref="JsonWebKey"/>.
        /// </summary>
        public KeyType KeyType { get; set; }

        /// <summary>
        /// Gets a list of <see cref="KeyOperation"/> values supported by this key.
        /// </summary>
        public IReadOnlyCollection<KeyOperation> KeyOps { get; }

        internal JsonWebKey() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWebKey"/> class with the given key operations.
        /// </summary>
        /// <param name="keyOps">
        /// A list of supported <see cref="KeyOperation"/> values.
        /// If null, no operations will be permitted and subsequent cryptography operations may fail.
        /// </param>
        public JsonWebKey(IEnumerable<KeyOperation> keyOps)
        {
            _keyOps = keyOps is null ? new List<KeyOperation>() : new List<KeyOperation>(keyOps);
            KeyOps = new ReadOnlyCollection<KeyOperation>(_keyOps);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWebKey"/> class using type <see cref="KeyType.Oct"/>.
        /// </summary>
        /// <param name="aesProvider">An <see cref="Aes"/> provider.</param>
        /// <param name="keyOps">
        /// Optional list of supported <see cref="KeyOperation"/> values. If null, the default for the key type is used, including:
        /// <see cref="KeyOperation.Encrypt"/>, <see cref="KeyOperation.Decrypt"/>, <see cref="KeyOperation.WrapKey"/>, and <see cref="KeyOperation.UnwrapKey"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="aesProvider"/> is null.</exception>
        public JsonWebKey(Aes aesProvider, IEnumerable<KeyOperation> keyOps = default)
        {
            Argument.AssertNotNull(aesProvider, nameof(aesProvider));

            _keyOps = new List<KeyOperation>(keyOps ?? s_aesKeyOperation);
            KeyOps = new ReadOnlyCollection<KeyOperation>(_keyOps);

            KeyType = KeyType.Oct;
            K = aesProvider.Key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWebKey"/> class using type <see cref="KeyType.Ec"/>.
        /// </summary>
        /// <param name="ecdsa">An <see cref="ECDsa"/> provider.</param>
        /// <param name="includePrivateParameters">Whether to include the private key.</param>
        /// <param name="keyOps">
        /// Optional list of supported <see cref="KeyOperation"/> values. If null, the default for the key type is used, including:
        /// <see cref="KeyOperation.Sign"/>, and <see cref="KeyOperation.Decrypt"/> if <paramref name="includePrivateParameters"/> is true.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="ecdsa"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The elliptic curve name is invalid.</exception>
        public JsonWebKey(ECDsa ecdsa, bool includePrivateParameters = default, IEnumerable<KeyOperation> keyOps = default)
        {
            Argument.AssertNotNull(ecdsa, nameof(ecdsa));

            _keyOps = new List<KeyOperation>(keyOps ?? (includePrivateParameters ? s_eCPrivateKeyOperation : s_eCPublicKeyOperation));
            KeyOps = new ReadOnlyCollection<KeyOperation>(_keyOps);

            Initialize(ecdsa, includePrivateParameters);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWebKey"/> class using type <see cref="KeyType.Rsa"/>.
        /// </summary>
        /// <param name="rsaProvider">An <see cref="RSA"/> provider.</param>
        /// <param name="includePrivateParameters">Whether to include the private key.</param>
        /// <param name="keyOps">
        /// Optional list of supported <see cref="KeyOperation"/> values. If null, the default for the key type is used, including:
        /// <see cref="KeyOperation.Encrypt"/>, <see cref="KeyOperation.Verify"/>, and <see cref="KeyOperation.WrapKey"/>;
        /// and <see cref="KeyOperation.Decrypt"/>, <see cref="KeyOperation.Sign"/>, and <see cref="KeyOperation.UnwrapKey"/> if <paramref name="includePrivateParameters"/> is true.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="rsaProvider"/> is null.</exception>
        public JsonWebKey(RSA rsaProvider, bool includePrivateParameters = default, IEnumerable<KeyOperation> keyOps = default)
        {
            Argument.AssertNotNull(rsaProvider, nameof(rsaProvider));

            _keyOps = new List<KeyOperation>(keyOps ?? (includePrivateParameters ? s_rSAPrivateKeyOperation : s_rSAPublicKeyOperation));
            KeyOps = new ReadOnlyCollection<KeyOperation>(_keyOps);

            KeyType = KeyType.Rsa;
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
        /// Gets the RSA modulus.
        /// </summary>
        public byte[] N { get; set; }

        /// <summary>
        /// Gets RSA public exponent.
        /// </summary>
        public byte[] E { get; set; }

        #endregion

        #region RSA Private Key Parameters

        /// <summary>
        /// Gets the RSA private key parameter.
        /// </summary>
        public byte[] DP { get; set; }

        /// <summary>
        /// Gets the RSA private key parameter.
        /// </summary>
        public byte[] DQ { get; set; }

        /// <summary>
        /// Gets the RSA private key parameter.
        /// </summary>
        public byte[] QI { get; set; }

        /// <summary>
        /// Gets the RSA secret prime.
        /// </summary>
        public byte[] P { get; set; }

        /// <summary>
        /// Gets the RSA secret prime.
        /// </summary>
        public byte[] Q { get; set; }

        #endregion

        #region EC Public Key Parameters

        /// <summary>
        /// Gets the name of the elliptical curve.
        /// </summary>
        public KeyCurveName? CurveName { get; set; }

        /// <summary>
        /// Gets the X coordinate of the elliptic curve point.
        /// </summary>
        public byte[] X { get; set; }

        /// <summary>
        /// Gets the Y coordinate for the elliptic curve point.
        /// </summary>
        public byte[] Y { get; set; }

        #endregion

        #region EC and RSA Private Key Parameters

        /// <summary>
        /// Gets the RSA private exponent or EC private key.
        /// </summary>
        public byte[] D { get; set; }

        #endregion

        #region Symmetric Key Parameters

        /// <summary>
        /// Gets the symmetric key.
        /// </summary>
        public byte[] K { get; set; }

        #endregion

        /// <summary>
        /// Gets the protected key used with "Bring Your Own Key".
        /// </summary>
        public byte[] T { get; set; }

        internal bool HasPrivateKey
        {
            get
            {
                if (KeyType == KeyType.Rsa || KeyType == KeyType.Ec || KeyType == KeyType.RsaHsm || KeyType == KeyType.EcHsm)
                {
                    return D != null;
                }

                if (KeyType == KeyType.Oct || KeyType == KeyType.OctHsm)
                {
                    return K != null;
                }

                return false;
            }
        }

        /// <summary>
        /// Converts this <see cref="JsonWebKey"/> of type <see cref="KeyType.Oct"/> or <see cref="KeyType.OctHsm"/> to an <see cref="Aes"/> object.
        /// </summary>
        /// <returns>An <see cref="Aes"/> object.</returns>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Oct"/> or <see cref="K"/> is null.</exception>
        public Aes ToAes()
        {
            if (KeyType != KeyType.Oct && KeyType != KeyType.OctHsm)
            {
                throw new InvalidOperationException($"key is not an {nameof(KeyType.Oct)} or {nameof(KeyType.OctHsm)} type");
            }

            if (K is null)
            {
                throw new InvalidOperationException("key does not contain a value");
            }

            Aes key = Aes.Create();
            key.Key = K;

            return key;
        }

        /// <summary>
        /// Converts this <see cref="JsonWebKey"/> of type <see cref="KeyType.Ec"/> or <see cref="KeyType.EcHsm"/> to an <see cref="ECDsa"/> object.
        /// </summary>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <returns>An <see cref="ECDsa"/> object.</returns>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Ec"/> or <see cref="KeyType.EcHsm"/>, or one or more key parameters are invalid.</exception>
        public ECDsa ToECDsa(bool includePrivateParameters = false) => ToECDsa(includePrivateParameters, true);

        internal ECDsa ToECDsa(bool includePrivateParameters, bool throwIfNotSupported)
        {
            if (KeyType != KeyType.Ec && KeyType != KeyType.EcHsm)
            {
                throw new InvalidOperationException($"key is not an {nameof(KeyType.Ec)} or {nameof(KeyType.EcHsm)} type");
            }

            ValidateKeyParameter(nameof(X), X);
            ValidateKeyParameter(nameof(Y), Y);

            return Convert(includePrivateParameters, throwIfNotSupported);
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
                throw new InvalidOperationException($"key is not an {nameof(KeyType.Rsa)} or {nameof(KeyType.RsaHsm)} type");
            }

            ValidateKeyParameter(nameof(E), E);
            ValidateKeyParameter(nameof(N), N);

            // Key parameter length requirements defined by 2.2.2.9.1 RSA Private Key BLOB specification: https://docs.microsoft.com/openspecs/windows_protocols/ms-wcce/5cf2e6b9-3195-4f85-bc18-05b50e6d4e11
            var rsaParameters = new RSAParameters
            {
                Exponent = E,
                Modulus = TrimBuffer(N),
            };

            if (includePrivateParameters && HasPrivateKey)
            {
                int byteLength = rsaParameters.Modulus.Length;
                rsaParameters.D = ForceBufferLength(nameof(D), D, byteLength);

                byteLength >>= 1;
                rsaParameters.DP = ForceBufferLength(nameof(DP), DP, byteLength);
                rsaParameters.DQ = ForceBufferLength(nameof(DQ), DQ, byteLength);
                rsaParameters.P = ForceBufferLength(nameof(P), P, byteLength);
                rsaParameters.Q = ForceBufferLength(nameof(Q), Q, byteLength);
                rsaParameters.InverseQ = ForceBufferLength(nameof(QI), QI, byteLength);
            }

            return CreateRSAProvider(rsaParameters);
        }

        internal bool SupportsOperation(KeyOperation operation)
        {
            if (KeyOps != null)
            {
                for (int i = 0; i < KeyOps.Count; ++i)
                {
                    if (_keyOps[i] == operation)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        Id = prop.Value.GetString();
                        break;
                    case KeyTypePropertyName:
                        KeyType = prop.Value.GetString();
                        break;
                    case KeyOpsPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            _keyOps.Add(element.ToString());
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

        internal void WriteProperties(Utf8JsonWriter json, bool withId = false)
        {
            if (Id != null && withId)
            {
                json.WriteString(s_keyIdPropertyNameBytes, Id);
            }
            if (KeyType != default)
            {
                json.WriteString(s_keyTypePropertyNameBytes, KeyType.ToString());
            }
            if (KeyOps != null)
            {
                json.WriteStartArray(s_keyOpsPropertyNameBytes);
                foreach (KeyOperation operation in KeyOps)
                {
                    json.WriteStringValue(operation.ToString());
                }
                json.WriteEndArray();
            }
            if (CurveName.HasValue)
            {
                json.WriteString(s_curveNamePropertyNameBytes, CurveName.Value.ToString());
            }
            if (N != null)
            {
                json.WriteString(s_nPropertyNameBytes, Base64Url.Encode(N));
            }
            if (E != null)
            {
                json.WriteString(s_ePropertyNameBytes, Base64Url.Encode(E));
            }
            if (DP != null)
            {
                json.WriteString(s_dPPropertyNameBytes, Base64Url.Encode(DP));
            }
            if (DQ != null)
            {
                json.WriteString(s_dQPropertyNameBytes, Base64Url.Encode(DQ));
            }
            if (QI != null)
            {
                json.WriteString(s_qIPropertyNameBytes, Base64Url.Encode(QI));
            }
            if (P != null)
            {
                json.WriteString(s_pPropertyNameBytes, Base64Url.Encode(P));
            }
            if (Q != null)
            {
                json.WriteString(s_qPropertyNameBytes, Base64Url.Encode(Q));
            }
            if (X != null)
            {
                json.WriteString(s_xPropertyNameBytes, Base64Url.Encode(X));
            }
            if (Y != null)
            {
                json.WriteString(s_yPropertyNameBytes, Base64Url.Encode(Y));
            }
            if (D != null)
            {
                json.WriteString(s_dPropertyNameBytes, Base64Url.Encode(D));
            }
            if (K != null)
            {
                json.WriteString(s_kPropertyNameBytes, Base64Url.Encode(K));
            }
            if (T != null)
            {
                json.WriteString(s_tPropertyNameBytes, Base64Url.Encode(T));
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);

        private static Func<RSAParameters, RSA> s_rsaFactory;

        private static RSA CreateRSAProvider(RSAParameters parameters)
        {
            if (s_rsaFactory is null)
            {
                // On Framework 4.7.2 and newer, to create the CNG implementation of RSA that supports RSA-OAEP-256, we need to create it with RSAParameters.
                [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Incorrectly identifies RSA.Create(String); see https://github.com/Azure/azure-sdk-for-net/issues/40175 for discussion.")]
                static MethodInfo GetRsaCreateMethod() => typeof(RSA).GetMethod(nameof(RSA.Create), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(RSAParameters) }, null);

                MethodInfo createMethod = GetRsaCreateMethod();
                if (createMethod != null)
                {
                    s_rsaFactory = (Func<RSAParameters, RSA>)createMethod.CreateDelegate(typeof(Func<RSAParameters, RSA>));
                }
                else
                {
                    s_rsaFactory = p =>
                    {
                        // On Framework, this will not support RSA-OAEP-256 padding.
                        RSA rsa = RSA.Create();
                        rsa.ImportParameters(parameters);

                        return rsa;
                    };
                }
            }

            return s_rsaFactory(parameters);
        }

        private static byte[] ForceBufferLength(string name, byte[] value, int requiredLengthInBytes)
        {
            if (value is null || value.Length == 0)
            {
                throw new InvalidOperationException($"key parameter {name} is null or empty");
            }

            if (value.Length == requiredLengthInBytes)
            {
                return value;
            }

            if (value.Length < requiredLengthInBytes)
            {
                byte[] padded = new byte[requiredLengthInBytes];
                Array.Copy(value, 0, padded, requiredLengthInBytes - value.Length, value.Length);

                return padded;
            }

            // Throw if any extra bytes are non-zero.
            var extraLength = value.Length - requiredLengthInBytes;
            for (int i = 0; i < extraLength; ++i)
            {
                if (value[i] != 0)
                {
                    throw new InvalidOperationException($"key parameter {name} is too long: expected at most {requiredLengthInBytes} bytes, but found {value.Length - i} bytes");
                }
            }

            byte[] trimmed = new byte[requiredLengthInBytes];
            Array.Copy(value, value.Length - requiredLengthInBytes, trimmed, 0, requiredLengthInBytes);

            return trimmed;
        }

        private static readonly byte[] s_zeroBuffer = new byte[] { 0 };
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

            return s_zeroBuffer;
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
            KeyType = KeyType.Ec;

            ECParameters ecParameters = ecdsa.ExportParameters(includePrivateParameters);
            CurveName = KeyCurveName.FromOid(ecParameters.Curve.Oid, ecdsa.KeySize).ToString() ?? throw new InvalidOperationException("elliptic curve name is invalid");
            D = ecParameters.D;
            X = ecParameters.Q.X;
            Y = ecParameters.Q.Y;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private ECDsa Convert(bool includePrivateParameters, bool throwIfNotSupported)
        {
            if (!CurveName.HasValue)
            {
                if (throwIfNotSupported)
                {
                    throw new InvalidOperationException("missing required curve name");
                }

                return null;
            }

            KeyCurveName curveName = CurveName.Value;

            int requiredParameterSize = curveName.KeyParameterSize;
            if (requiredParameterSize <= 0)
            {
                if (throwIfNotSupported)
                {
                    throw new InvalidOperationException($"invalid curve name: {CurveName.ToString()}");
                }

                return null;
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

            if (includePrivateParameters && HasPrivateKey)
            {
                ecParameters.D = ForceBufferLength(nameof(D), D, requiredParameterSize);
            }

            ECDsa ecdsa = ECDsa.Create();
            try
            {
                ecdsa.ImportParameters(ecParameters);
            }
            catch when (!throwIfNotSupported)
            {
                ecdsa.Dispose();

                return null;
            }

            return ecdsa;
        }
    }
}
