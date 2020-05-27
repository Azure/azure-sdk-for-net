// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("LuceneStandardTokenizerV2")]
    public partial class LuceneStandardTokenizer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LuceneStandardTokenizer"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores,
        /// can only start and end with alphanumeric characters, and is limited to 128 characters.
        /// </param>
        public LuceneStandardTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.StandardTokenizerV2";
        }

        /// <summary>
        /// Gets or sets the maximum token length.
        /// okens longer than the maximum length are split.
        /// The maximum token length that can be used is 300 characters.
        /// </summary>
        public int? MaxTokenLength { get; set; }
    }
}
