// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Tokenizes the input from an edge into n-grams of the given size(s). This tokenizer is implemented using Apache Lucene.
    /// </summary>
    [JsonObject("#Microsoft.Azure.Search.EdgeNGramTokenizer")]
    public partial class EdgeNGramTokenizer : Tokenizer
    {
        /// <summary>
        /// Initializes a new instance of the EdgeNGramTokenizer class.
        /// </summary>
        public EdgeNGramTokenizer() { }

        /// <summary>
        /// Initializes a new instance of the EdgeNGramTokenizer class.
        /// </summary>
        public EdgeNGramTokenizer(string name, int? minGram = default(int?), int? maxGram = default(int?), IList<TokenCharacterKind> tokenChars = default(IList<TokenCharacterKind>))
            : base(name)
        {
            MinGram = minGram;
            MaxGram = maxGram;
            TokenChars = tokenChars;
        }

        /// <summary>
        /// Gets or sets the minimum n-gram length. Default is 1.
        /// </summary>
        [JsonProperty(PropertyName = "minGram")]
        public int? MinGram { get; set; }

        /// <summary>
        /// Gets or sets the maximum n-gram length. Default is 2.
        /// </summary>
        [JsonProperty(PropertyName = "maxGram")]
        public int? MaxGram { get; set; }

        /// <summary>
        /// Gets or sets character classes to keep in the tokens.
        /// </summary>
        [JsonProperty(PropertyName = "tokenChars")]
        public IList<TokenCharacterKind> TokenChars { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
