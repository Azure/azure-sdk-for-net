// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("EdgeNGramTokenFilterV2")]
    public partial class EdgeNGramTokenFilter
    {
        /// <summary> Initializes a new instance of EdgeNGramTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public EdgeNGramTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2";
        }

        /// <summary>
        /// The minimum n-gram length. Default is 1. Must be less than the value of maxGram.
        /// </summary>
        public int? MinGram { get; set; }

        /// <summary>
        /// The maximum n-gram length. Default is 2.
        /// </summary>
        public int? MaxGram { get; set; }

        /// <summary>
        /// Specifies which side of the input the n-gram should be generated from. Default is <see cref="EdgeNGramTokenFilterSide.Front"/>.
        /// </summary>
        public EdgeNGramTokenFilterSide? Side { get; set; }
    }
}
