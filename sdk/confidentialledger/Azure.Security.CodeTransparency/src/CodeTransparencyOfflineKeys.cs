// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// A case-insensitive dictionary mapping ledger domains to their JWKS documents for offline verification.
    /// </summary>
    public sealed class CodeTransparencyOfflineKeys
    {
        private IDictionary<string, JwksDocument> _keysByDomain;

        /// <summary>
        /// Initializes a new instance of CodeTransparencyOfflineKeys.
        /// </summary>
        public CodeTransparencyOfflineKeys()
        {
            _keysByDomain = new Dictionary<string, JwksDocument>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the dictionary of ledger domains to their JWKS documents.
        /// </summary>
        public IReadOnlyDictionary<string, JwksDocument> ByDomain => new ReadOnlyDictionary<string, JwksDocument>(_keysByDomain);

        /// <summary>
        /// Adds or updates a JWKS document for the specified ledger domain.
        /// </summary>
        public void Add(string ledgerDomain, JwksDocument jwksDocument)
        {
            _keysByDomain[ledgerDomain] = jwksDocument;
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
