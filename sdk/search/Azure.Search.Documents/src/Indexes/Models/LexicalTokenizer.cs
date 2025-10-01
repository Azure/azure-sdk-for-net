// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LexicalTokenizer
    {
        /// <summary> Initializes a new instance of LexicalTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        private protected LexicalTokenizer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        internal static LexicalTokenizer DeserializeLexicalTokenizer(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.ClassicTokenizer": return ClassicTokenizer.DeserializeClassicTokenizer(element, options);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenizer": return EdgeNGramTokenizer.DeserializeEdgeNGramTokenizer(element, options);
                    case "#Microsoft.Azure.Search.KeywordTokenizer": return KeywordTokenizer.DeserializeKeywordTokenizer(element, options);
                    case "#Microsoft.Azure.Search.KeywordTokenizerV2": return KeywordTokenizer.DeserializeKeywordTokenizer(element, options);
                    case "#Microsoft.Azure.Search.MicrosoftLanguageStemmingTokenizer": return MicrosoftLanguageStemmingTokenizer.DeserializeMicrosoftLanguageStemmingTokenizer(element, options);
                    case "#Microsoft.Azure.Search.MicrosoftLanguageTokenizer": return MicrosoftLanguageTokenizer.DeserializeMicrosoftLanguageTokenizer(element, options);
                    case "#Microsoft.Azure.Search.NGramTokenizer": return NGramTokenizer.DeserializeNGramTokenizer(element, options);
                    case "#Microsoft.Azure.Search.PathHierarchyTokenizerV2": return PathHierarchyTokenizer.DeserializePathHierarchyTokenizer(element, options);
                    case "#Microsoft.Azure.Search.PatternTokenizer": return PatternTokenizer.DeserializePatternTokenizer(element, options);
                    case "#Microsoft.Azure.Search.StandardTokenizer": return LuceneStandardTokenizer.DeserializeLuceneStandardTokenizer(element, options);
                    case "#Microsoft.Azure.Search.StandardTokenizerV2": return LuceneStandardTokenizer.DeserializeLuceneStandardTokenizer(element, options);
                    case "#Microsoft.Azure.Search.UaxUrlEmailTokenizer": return UaxUrlEmailTokenizer.DeserializeUaxUrlEmailTokenizer(element, options);
                }
            }
            return UnknownLexicalTokenizer.DeserializeUnknownLexicalTokenizer(element, options);
        }
    }
}
