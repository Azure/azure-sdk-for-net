// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// A case-insensitive dictionary mapping ledger domains to their JWKS documents for offline verification.
    /// </summary>
    public sealed class CodeTransparencyOfflineKeys
    {
        private IDictionary<string, JwksDocument> _keysByIssuer;

        /// <summary>
        /// Initializes a new instance of CodeTransparencyOfflineKeys.
        /// </summary>
        public CodeTransparencyOfflineKeys()
        {
            _keysByIssuer = new Dictionary<string, JwksDocument>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the dictionary of ledger domains to their JWKS documents.
        /// </summary>
        public IReadOnlyDictionary<string, JwksDocument> ByIssuer => new ReadOnlyDictionary<string, JwksDocument>(_keysByIssuer);

        /// <summary>
        /// Adds or updates a JWKS document for the specified ledger domain.
        /// </summary>
        public void Add(string ledgerDomain, JwksDocument jwksDocument)
        {
            Argument.AssertNotNullOrEmpty(ledgerDomain, nameof(ledgerDomain));
            Argument.AssertNotNull(jwksDocument, nameof(jwksDocument));
            _keysByIssuer[ledgerDomain] = jwksDocument;
        }

        /// <summary>
        /// Creates a CodeTransparencyOfflineKeys instance from a BinaryData containing JSON.
        /// </summary>
        public static CodeTransparencyOfflineKeys FromBinaryData(BinaryData json)
        {
            using (JsonDocument doc = JsonDocument.Parse(json.ToString()))
            {
                return FromJsonDocument(doc);
            }
        }

        /// <summary>
        /// Serializes the CodeTransparencyOfflineKeys to JSON bytes.
        /// </summary>
        public BinaryData ToBinaryData()
        {
            using (var stream = new System.IO.MemoryStream())
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                foreach (var kvp in _keysByIssuer)
                {
                    writer.WritePropertyName(kvp.Key);
                    writer.WriteObjectValue(kvp.Value);
                }
                writer.WriteEndObject();
                writer.Flush();
                return new BinaryData(stream.ToArray());
            }
        }

        internal static CodeTransparencyOfflineKeys FromJsonDocument(JsonDocument jsonDocument)
        {
            return DeserializeKeys(jsonDocument.RootElement);
        }

        internal static CodeTransparencyOfflineKeys DeserializeKeys(JsonElement element, ModelReaderWriterOptions options = null)
        {
            var keys = new CodeTransparencyOfflineKeys();

            foreach (var property in element.EnumerateObject())
            {
                var ledgerDomain = property.Name;
                var jwksDocument = JwksDocument.DeserializeJwksDocument(property.Value, options);
                keys.Add(ledgerDomain, jwksDocument);
            }

            return keys;
        }
    }
}
