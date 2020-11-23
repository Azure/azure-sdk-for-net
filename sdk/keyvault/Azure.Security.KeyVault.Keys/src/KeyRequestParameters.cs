// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal class KeyRequestParameters : IJsonSerializable
    {
        private const string KeyTypePropertyName = "kty";
        private const string KeySizePropertyName = "key_size";
        private const string KeyOpsPropertyName = "key_ops";
        private const string CurveNamePropertyName = "crv";
        private const string AttributesPropertyName = "attributes";
        private const string TagsPropertyName = "tags";
        private const string PublicExponentPropertyName = "public_exponent";
        private const string ReleasePolicyPropertyName = "release_policy";

        private static readonly JsonEncodedText s_keyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private static readonly JsonEncodedText s_keySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);
        private static readonly JsonEncodedText s_keyOpsPropertyNameBytes = JsonEncodedText.Encode(KeyOpsPropertyName);
        private static readonly JsonEncodedText s_curveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private static readonly JsonEncodedText s_publicExponentPropertyNameBytes = JsonEncodedText.Encode(PublicExponentPropertyName);
        private static readonly JsonEncodedText s_releasePolicyPropertyNameBytes = JsonEncodedText.Encode(ReleasePolicyPropertyName);

        private KeyAttributes _attributes;

        public KeyType KeyType { get; set; }
        public int? KeySize { get; set; }
        public KeyAttributes Attributes { get; set; }
        public IList<KeyOperation> KeyOperations { get; set; }
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }
        public DateTimeOffset? Expires { get => _attributes.ExpiresOn; set => _attributes.ExpiresOn = value; }
        public IDictionary<string, string> Tags { get; set; }
        public KeyCurveName? Curve { get; set; }
        public int? PublicExponent { get; set; }
        public KeyReleasePolicy ReleasePolicy { get; set; }

        internal KeyRequestParameters(KeyProperties key, IEnumerable<KeyOperation> operations)
        {
            if (key.Enabled.HasValue)
            {
                Enabled = key.Enabled.Value;
            }
            if (key.ExpiresOn.HasValue)
            {
                Expires = key.ExpiresOn.Value;
            }
            if (key.NotBefore.HasValue)
            {
                NotBefore = key.NotBefore.Value;
            }
            if (key.Tags != null && key.Tags.Count > 0)
            {
                Tags = new Dictionary<string, string>(key.Tags);
            }
            if (operations != null)
            {
                KeyOperations = new List<KeyOperation>(operations);
            }

            ReleasePolicy = key.ReleasePolicy;
        }

        internal KeyRequestParameters(KeyType type, CreateKeyOptions options = default)
        {
            KeyType = type;
            if (options != null)
            {
                if (options.Enabled.HasValue)
                {
                    Enabled = options.Enabled.Value;
                }
                if (options.ExpiresOn.HasValue)
                {
                    Expires = options.ExpiresOn.Value;
                }
                if (options.NotBefore.HasValue)
                {
                    NotBefore = options.NotBefore.Value;
                }
                if (options.KeyOperations != null && options.KeyOperations.Count > 0)
                {
                    KeyOperations = new List<KeyOperation>(options.KeyOperations);
                }
                if (options.Tags != null && options.Tags.Count > 0)
                {
                    Tags = new Dictionary<string, string>(options.Tags);
                }

                ReleasePolicy = options.ReleasePolicy;
            }
        }

        internal KeyRequestParameters(CreateEcKeyOptions ecKey)
            : this(ecKey.KeyType, ecKey)
        {
            if (ecKey.CurveName.HasValue)
            {
                Curve = ecKey.CurveName.Value;
            }
        }

        internal KeyRequestParameters(CreateRsaKeyOptions rsaKey)
            : this(rsaKey.KeyType, rsaKey)
        {
            if (rsaKey.KeySize.HasValue)
            {
                KeySize = rsaKey.KeySize.Value;
            }

            if (rsaKey.PublicExponent.HasValue)
            {
                PublicExponent = rsaKey.PublicExponent.Value;
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (KeyType != default)
            {
                json.WriteString(s_keyTypePropertyNameBytes, KeyType.ToString());
            }
            if (KeySize.HasValue)
            {
                json.WriteNumber(s_keySizePropertyNameBytes, KeySize.Value);
            }
            if (Curve.HasValue)
            {
                json.WriteString(s_curveNamePropertyNameBytes, Curve.Value.ToString());
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                _attributes.WriteProperties(json);

                json.WriteEndObject();
            }
            if (!KeyOperations.IsNullOrEmpty())
            {
                json.WriteStartArray(s_keyOpsPropertyNameBytes);
                foreach (KeyOperation operation in KeyOperations)
                {
                    json.WriteStringValue(operation.ToString());
                }
                json.WriteEndArray();
            }
            if (!Tags.IsNullOrEmpty())
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (PublicExponent.HasValue)
            {
                json.WriteNumber(s_publicExponentPropertyNameBytes, PublicExponent.Value);
            }

            if (ReleasePolicy != null)
            {
                json.WriteStartObject(s_releasePolicyPropertyNameBytes);

                ReleasePolicy.WriteProperties(json);

                json.WriteEndObject();
            }
        }
    }
}
