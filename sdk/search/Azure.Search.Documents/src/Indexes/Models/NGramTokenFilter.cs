// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("NGramTokenFilterV2")]
    public partial class NGramTokenFilter : IUtf8JsonSerializable
    {
        /// <summary>
        /// Initializes a new instance of NGramTokenFilter.
        /// </summary>
        /// <param name="name">
        /// The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores,
        /// can only start and end with alphanumeric characters, and is limited to 128 characters.
        /// </param>
        public NGramTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.NGramTokenFilterV2";
        }

        /// <summary>
        /// The minimum n-gram length. Default is 1.
        /// Maximum is 300.
        /// Must be less than the value of maxGram.
        /// </summary>
        public int? MinGram { get; set; }

        /// <summary>
        /// The maximum n-gram length. Default is 2.
        /// Maximum is 300.
        /// </summary>
        public int? MaxGram { get; set; }
    }
}
