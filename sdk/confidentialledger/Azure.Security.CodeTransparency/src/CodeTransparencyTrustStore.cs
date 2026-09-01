// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// A store of receipt-verification keys, keyed by issuer domain, for offline verification.
    /// <para>
    /// The store can be populated from either the JSON JWK Set (<c>/jwks</c>) or the CBOR COSE_Key_Set
    /// (<c>/.well-known/scitt-keys</c>) representation because both are normalized to
    /// <see cref="CodeTransparencyVerificationKeySet"/> before being added.
    /// </para>
    /// <para>
    /// <see cref="ToBinaryData"/> serializes to an SDK-owned, versioned JSON format that persists only
    /// public key parameters. Private key material is never stored.
    /// </para>
    /// </summary>
    public sealed class CodeTransparencyTrustStore
    {
        // Current version of the SDK-owned serialization format.
        private const int CurrentFormatVersion = 1;

        // Issuer domains are hostnames and matched case-insensitively.
        private readonly Dictionary<string, CodeTransparencyVerificationKeySet> _keysByIssuer =
            new Dictionary<string, CodeTransparencyVerificationKeySet>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new, empty <see cref="CodeTransparencyTrustStore"/>.
        /// </summary>
        public CodeTransparencyTrustStore()
        {
        }

        /// <summary>
        /// Gets the verification key sets, keyed by issuer domain.
        /// </summary>
        public IReadOnlyDictionary<string, CodeTransparencyVerificationKeySet> KeysByIssuer =>
            new ReadOnlyDictionary<string, CodeTransparencyVerificationKeySet>(_keysByIssuer);

        /// <summary>
        /// Adds or replaces the verification keys for the specified issuer domain.
        /// </summary>
        /// <param name="issuerDomain">The issuer domain (hostname) the keys belong to.</param>
        /// <param name="keys">The verification keys for the issuer.</param>
        /// <exception cref="ArgumentException"><paramref name="issuerDomain"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys"/> is null.</exception>
        public void SetKeys(string issuerDomain, CodeTransparencyVerificationKeySet keys)
        {
            if (string.IsNullOrEmpty(issuerDomain))
            {
                throw new ArgumentException("Issuer domain must not be null or empty.", nameof(issuerDomain));
            }
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            _keysByIssuer[issuerDomain] = keys;
        }

        /// <summary>
        /// Gets the verification keys for the specified issuer domain.
        /// </summary>
        /// <param name="issuerDomain">The issuer domain (hostname) to look up.</param>
        /// <param name="keys">When this method returns, the keys for the issuer if present; otherwise null.</param>
        /// <returns><c>true</c> if keys were found for the issuer; otherwise, <c>false</c>.</returns>
        public bool TryGetKeys(string issuerDomain, out CodeTransparencyVerificationKeySet keys)
        {
            if (string.IsNullOrEmpty(issuerDomain))
            {
                keys = null;
                return false;
            }

            return _keysByIssuer.TryGetValue(issuerDomain, out keys);
        }

        /// <summary>
        /// Removes the keys for the specified issuer domain.
        /// </summary>
        /// <param name="issuerDomain">The issuer domain (hostname) to remove.</param>
        /// <returns><c>true</c> if keys were removed; otherwise, <c>false</c>.</returns>
        public bool RemoveKeys(string issuerDomain)
        {
            if (string.IsNullOrEmpty(issuerDomain))
            {
                return false;
            }

            return _keysByIssuer.Remove(issuerDomain);
        }

        /// <summary>
        /// Creates a <see cref="CodeTransparencyTrustStore"/> from data previously produced by
        /// <see cref="ToBinaryData"/>.
        /// </summary>
        /// <param name="data">The serialized trust store.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="FormatException">The data is not a valid serialized trust store.</exception>
        /// <exception cref="NotSupportedException">The serialized format version is not supported.</exception>
        public static CodeTransparencyTrustStore FromBinaryData(BinaryData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var store = new CodeTransparencyTrustStore();

            using JsonDocument document = JsonDocument.Parse(data.ToMemory());
            JsonElement root = document.RootElement;

            if (root.ValueKind != JsonValueKind.Object)
            {
                throw new FormatException("The serialized trust store is not a JSON object.");
            }

            if (!root.TryGetProperty("version", out JsonElement versionElement) ||
                versionElement.ValueKind != JsonValueKind.Number ||
                !versionElement.TryGetInt32(out int version))
            {
                throw new FormatException("The serialized trust store is missing a numeric 'version' member.");
            }
            if (version != CurrentFormatVersion)
            {
                throw new NotSupportedException($"Unsupported trust store format version '{version}'.");
            }

            if (root.TryGetProperty("issuers", out JsonElement issuersElement))
            {
                if (issuersElement.ValueKind != JsonValueKind.Object)
                {
                    throw new FormatException("The serialized trust store 'issuers' member is not a JSON object.");
                }

                foreach (JsonProperty issuer in issuersElement.EnumerateObject())
                {
                    store.SetKeys(issuer.Name, DeserializeKeySet(issuer.Value));
                }
            }

            return store;
        }

        /// <summary>
        /// Serializes the trust store to an SDK-owned, versioned JSON format containing only public key
        /// parameters.
        /// </summary>
        public BinaryData ToBinaryData()
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                writer.WriteNumber("version", CurrentFormatVersion);

                writer.WritePropertyName("issuers");
                writer.WriteStartObject();
                foreach (KeyValuePair<string, CodeTransparencyVerificationKeySet> issuer in _keysByIssuer)
                {
                    writer.WritePropertyName(issuer.Key);
                    SerializeKeySet(writer, issuer.Value);
                }
                writer.WriteEndObject();

                writer.WriteEndObject();
            }

            return BinaryData.FromBytes(stream.ToArray());
        }

        private static void SerializeKeySet(Utf8JsonWriter writer, CodeTransparencyVerificationKeySet keySet)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keys");
            writer.WriteStartArray();

            foreach (CodeTransparencyVerificationKey key in keySet.Keys)
            {
                ECParameters parameters = key.ExportPublicParameters();

                writer.WriteStartObject();
                writer.WriteString("keyId", key.KeyId);
                writer.WriteString("curve", key.CurveName);
                writer.WriteString("x", Convert.ToBase64String(parameters.Q.X));
                writer.WriteString("y", Convert.ToBase64String(parameters.Q.Y));
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private static CodeTransparencyVerificationKeySet DeserializeKeySet(JsonElement keySetElement)
        {
            if (keySetElement.ValueKind != JsonValueKind.Object ||
                !keySetElement.TryGetProperty("keys", out JsonElement keysElement) ||
                keysElement.ValueKind != JsonValueKind.Array)
            {
                throw new FormatException("A serialized issuer entry is missing a 'keys' array.");
            }

            var keys = new List<CodeTransparencyVerificationKey>();
            foreach (JsonElement keyElement in keysElement.EnumerateArray())
            {
                keys.Add(DeserializeKey(keyElement));
            }

            return new CodeTransparencyVerificationKeySet(keys);
        }

        private static CodeTransparencyVerificationKey DeserializeKey(JsonElement keyElement)
        {
            string keyId = GetRequiredString(keyElement, "keyId");
            string curveName = GetRequiredString(keyElement, "curve");
            (ECCurve curve, int fieldSize) = MapCurve(curveName);

            byte[] x = DecodeCoordinate(keyElement, "x", fieldSize);
            byte[] y = DecodeCoordinate(keyElement, "y", fieldSize);

            return CodeTransparencyVerificationKey.FromPublicPoint(keyId, curve, x, y);
        }

        private static (ECCurve Curve, int FieldSize) MapCurve(string curveName)
        {
            return curveName switch
            {
                "P-256" => (ECCurve.NamedCurves.nistP256, 32),
                "P-384" => (ECCurve.NamedCurves.nistP384, 48),
                "P-521" => (ECCurve.NamedCurves.nistP521, 66),
                _ => throw new NotSupportedException($"Unsupported curve '{curveName}' in serialized trust store."),
            };
        }

        private static string GetRequiredString(JsonElement element, string propertyName)
        {
            if (element.ValueKind != JsonValueKind.Object ||
                !element.TryGetProperty(propertyName, out JsonElement value) ||
                value.ValueKind != JsonValueKind.String)
            {
                throw new FormatException($"A serialized key is missing the required '{propertyName}' member.");
            }

            string result = value.GetString();
            if (string.IsNullOrEmpty(result))
            {
                throw new FormatException($"A serialized key has an empty '{propertyName}' member.");
            }

            return result;
        }

        private static byte[] DecodeCoordinate(JsonElement keyElement, string propertyName, int fieldSize)
        {
            string encoded = GetRequiredString(keyElement, propertyName);
            byte[] decoded;
            try
            {
                decoded = Convert.FromBase64String(encoded);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"A serialized key '{propertyName}' member is not valid base64.", ex);
            }

            if (decoded.Length != fieldSize)
            {
                throw new FormatException($"A serialized key '{propertyName}' member has an unexpected length for its curve.");
            }

            return decoded;
        }
    }
}
