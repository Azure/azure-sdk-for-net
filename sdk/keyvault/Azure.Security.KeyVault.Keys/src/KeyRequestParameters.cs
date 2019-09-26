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

        private static readonly JsonEncodedText s_keyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private static readonly JsonEncodedText s_keySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);
        private static readonly JsonEncodedText s_keyOpsPropertyNameBytes = JsonEncodedText.Encode(KeyOpsPropertyName);
        private static readonly JsonEncodedText s_curveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        private KeyAttributes _attributes;

        public KeyType KeyType { get; set; }
        public int? KeySize { get; set; }
        public KeyAttributes Attributes { get; set; }
        public IList<KeyOperation> KeyOperations { get; set; }
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }
        public DateTimeOffset? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }
        public IDictionary<string, string> Tags { get; set; }
        public KeyCurveName? Curve { get; set; }

        internal KeyRequestParameters(KeyProperties key, IEnumerable<KeyOperation> operations)
        {
            if (key.Enabled.HasValue)
            {
                Enabled = key.Enabled.Value;
            }
            if (key.Expires.HasValue)
            {
                Expires = key.Expires.Value;
            }
            if (key.NotBefore.HasValue)
            {
                NotBefore = key.NotBefore.Value;
            }
            if (key.Tags != null)
            {
                Tags = new Dictionary<string, string>(key.Tags);
            }
            if (operations != null)
            {
                KeyOperations = new List<KeyOperation>(operations);
            }
        }

        internal KeyRequestParameters(KeyType type, KeyCreateOptions options = default)
        {
            KeyType = type;
            if (options != null)
            {
                if (options.Enabled.HasValue)
                {
                    Enabled = options.Enabled.Value;
                }
                if (options.Expires.HasValue)
                {
                    Expires = options.Expires.Value;
                }
                if (options.NotBefore.HasValue)
                {
                    NotBefore = options.NotBefore.Value;
                }
                if (options.KeyOperations != null)
                {
                    KeyOperations = new List<KeyOperation>(options.KeyOperations);
                }
                if (options.Tags != null)
                {
                    Tags = new Dictionary<string, string>(options.Tags);
                }
            }
        }

        internal KeyRequestParameters(EcKeyCreateOptions ecKey)
            : this(ecKey.KeyType, ecKey)
        {
            if (ecKey.Curve.HasValue)
            {
                Curve = ecKey.Curve.Value;
            }
        }

        internal KeyRequestParameters(RsaKeyCreateOptions rsaKey)
            : this(rsaKey.KeyType, rsaKey)
        {
            if (rsaKey.KeySize.HasValue)
            {
                KeySize = rsaKey.KeySize.Value;
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (KeyType != default)
            {
                json.WriteString(s_keyTypePropertyNameBytes, KeyType);
            }
            if (KeySize.HasValue)
            {
                json.WriteNumber(s_keySizePropertyNameBytes, KeySize.Value);
            }
            if (Curve.HasValue)
            {
                json.WriteString(s_curveNamePropertyNameBytes, Curve.Value);
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                _attributes.WriteProperties(json);

                json.WriteEndObject();
            }
            if (KeyOperations != null)
            {
                json.WriteStartArray(s_keyOpsPropertyNameBytes);
                foreach (KeyOperation operation in KeyOperations)
                {
                    json.WriteStringValue(operation);
                }
                json.WriteEndArray();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }
    }
}
