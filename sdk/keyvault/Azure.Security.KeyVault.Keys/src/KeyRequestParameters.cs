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
            Curve = ecKey.Curve;
        }

        internal KeyRequestParameters(RsaKeyCreateOptions rsaKey)
            : this(rsaKey.KeyType, rsaKey)
        {
            KeySize = rsaKey.KeySize;
        }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            if(KeyType != default)
            {
                json.WriteString("kty", KeyTypeExtensions.ParseToString(KeyType));
            }
            if(KeySize.HasValue)
            {
                json.WriteNumber("key_size", KeySize.Value);
            }
            if (Curve != default)
            {
                json.WriteString("crv", KeyCurveNameExtensions.ParseToString(Curve.Value));
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject("attributes");

                _attributes.WriteProperties(ref json);

                json.WriteEndObject();
            }
            if (KeyOperations != null)
            {
                json.WriteStartArray("key_ops");
                foreach(var operation in KeyOperations)
                {
                    json.WriteStringValue(KeyOperationsExtensions.ParseToString(operation));
                }
                json.WriteEndArray();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject("tags");

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
