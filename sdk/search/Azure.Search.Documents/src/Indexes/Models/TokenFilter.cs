// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class TokenFilter
    {
        /// <summary> Initializes a new instance of TokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        private protected TokenFilter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        internal static TokenFilter DeserializeTokenFilter(JsonElement element, ModelReaderWriterOptions options = null)
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
                    case "#Microsoft.Azure.Search.AsciiFoldingTokenFilter": return AsciiFoldingTokenFilter.DeserializeAsciiFoldingTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.CjkBigramTokenFilter": return CjkBigramTokenFilter.DeserializeCjkBigramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.CommonGramTokenFilter": return CommonGramTokenFilter.DeserializeCommonGramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter": return DictionaryDecompounderTokenFilter.DeserializeDictionaryDecompounderTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilter": return EdgeNGramTokenFilter.DeserializeEdgeNGramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2": return EdgeNGramTokenFilter.DeserializeEdgeNGramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.ElisionTokenFilter": return ElisionTokenFilter.DeserializeElisionTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.KeepTokenFilter": return KeepTokenFilter.DeserializeKeepTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.KeywordMarkerTokenFilter": return KeywordMarkerTokenFilter.DeserializeKeywordMarkerTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.LengthTokenFilter": return LengthTokenFilter.DeserializeLengthTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.LimitTokenFilter": return LimitTokenFilter.DeserializeLimitTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.NGramTokenFilter": return NGramTokenFilter.DeserializeNGramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.NGramTokenFilterV2": return NGramTokenFilter.DeserializeNGramTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.PatternCaptureTokenFilter": return PatternCaptureTokenFilter.DeserializePatternCaptureTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.PatternReplaceTokenFilter": return PatternReplaceTokenFilter.DeserializePatternReplaceTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.PhoneticTokenFilter": return PhoneticTokenFilter.DeserializePhoneticTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.ShingleTokenFilter": return ShingleTokenFilter.DeserializeShingleTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.SnowballTokenFilter": return SnowballTokenFilter.DeserializeSnowballTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.StemmerOverrideTokenFilter": return StemmerOverrideTokenFilter.DeserializeStemmerOverrideTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.StemmerTokenFilter": return StemmerTokenFilter.DeserializeStemmerTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.StopwordsTokenFilter": return StopwordsTokenFilter.DeserializeStopwordsTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.SynonymTokenFilter": return SynonymTokenFilter.DeserializeSynonymTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.TruncateTokenFilter": return TruncateTokenFilter.DeserializeTruncateTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.UniqueTokenFilter": return UniqueTokenFilter.DeserializeUniqueTokenFilter(element, options);
                    case "#Microsoft.Azure.Search.WordDelimiterTokenFilter": return WordDelimiterTokenFilter.DeserializeWordDelimiterTokenFilter(element, options);
                }
            }
            return UnknownTokenFilter.DeserializeUnknownTokenFilter(element, options);
        }
    }
}
