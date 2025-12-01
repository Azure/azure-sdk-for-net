// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
    public sealed class CodeTransparencyVerificationKeys
    {
        private IDictionary<string, JwksDocument> _serializedKeys;

        /// <summary>
        /// Initializes a new instance of CodeTransparencyVerificationKeys.
        /// </summary>
        public CodeTransparencyVerificationKeys()
        {
            _serializedKeys = new Dictionary<string, JwksDocument>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the dictionary of ledger domains to their JWKS documents.
        /// </summary>
        public IDictionary<string, JwksDocument> SerializedKeys => _serializedKeys;

        /// <summary>
        /// Adds or updates a JWKS document for the specified ledger domain.
        /// </summary>
        public void Add(string ledgerDomain, JwksDocument jwksDocument)
        {
            _serializedKeys[ledgerDomain] = jwksDocument;
        }

        internal static CodeTransparencyVerificationKeys FromJsonDocument(JsonDocument jsonDocument)
        {
            return DeserializeKeys(jsonDocument.RootElement);
        }

        internal static CodeTransparencyVerificationKeys DeserializeKeys(JsonElement element, ModelReaderWriterOptions options = null)
        {
            var keys = new CodeTransparencyVerificationKeys();

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
