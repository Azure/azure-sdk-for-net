// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal class KeyRequestParameters : Model
    {
        private KeyAttributes _attributes;

        public KeyType KeyType { get; set; }
        public int? KeySize { get; set; }
        public KeyAttributes Attributes { get; set; }
        public IList<KeyOperations> KeyOperations { get; set; }
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }
        public DateTimeOffset? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }
        public IDictionary<string, string> Tags { get; set; }
        public KeyCurveName? Curve { get; set; }

        internal KeyRequestParameters(KeyBase key, IEnumerable<KeyOperations> operations)
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
                KeyOperations = new List<KeyOperations>(operations);
            }
        }

        internal KeyRequestParameters(KeyType type, KeyCreateOptions options = default)
        {
            KeyType = type;
            if (options != default)
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
                    KeyOperations = new List<KeyOperations>(options.KeyOperations);
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
            if(ecKey.Curve.HasValue)
            {
                Curve = ecKey.Curve.Value;
            }
        }

        internal KeyRequestParameters(RsaKeyCreateOptions rsaKey)
            : this(rsaKey.KeyType, rsaKey)
        {
            if(rsaKey.KeySize.HasValue)
            {
                KeySize = rsaKey.KeySize.Value;
            }
        }

        private const string KeyTypePropertyName = "kty";
        private static readonly JsonEncodedText KeyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private const string KeySizePropertyName = "key_size";
        private static readonly JsonEncodedText KeySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);
        private const string KeyOpsPropertyName = "key_ops";
        private static readonly JsonEncodedText KeyOpsPropertyNameBytes = JsonEncodedText.Encode(KeyOpsPropertyName);
        private const string CurveNamePropertyName = "curveName";
        private static readonly JsonEncodedText CurveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private const string AttributesPropertyName = "attributes";
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private const string TagsPropertyName = "tags";
        private static readonly JsonEncodedText TagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            if(!string.IsNullOrEmpty(KeyType.StringValue))
            {
                json.WriteString(KeyTypePropertyNameBytes, KeyType.StringValue);
            }
            if(KeySize.HasValue)
            {
                json.WriteNumber(KeySizePropertyNameBytes, KeySize.Value);
            }
            if (Curve.HasValue)
            {
                json.WriteString(CurveNamePropertyNameBytes, KeyCurveNameExtensions.AsString(Curve.Value));
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                _attributes.WriteProperties(ref json);

                json.WriteEndObject();
            }
            if (KeyOperations != null)
            {
                json.WriteStartArray(KeyOpsPropertyNameBytes);
                foreach(var operation in KeyOperations)
                {
                    json.WriteStringValue(KeyOperationsExtensions.AsString(operation));
                }
                json.WriteEndArray();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject(TagsPropertyNameBytes);

                foreach (var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
        }

        internal override void ReadProperties(JsonElement json) { }
        
    }
}
