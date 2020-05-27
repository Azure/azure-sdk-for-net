// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("NGramTokenFilterV2")]
    public partial class NGramTokenFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NGramTokenFilter"/> class.
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
        /// Gets or sets the minimum n-gram length.
        /// Maximum is 300.
        /// Must be less than the value of maxGram.
        /// </summary>
        public int? MinGram { get; set; }

        /// <summary>
        /// Gets or sets the maximum n-gram length.
        /// Maximum is 300.
        /// </summary>
        public int? MaxGram { get; set; }
    }
}
