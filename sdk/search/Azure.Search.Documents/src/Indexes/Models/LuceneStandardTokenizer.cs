// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LuceneStandardTokenizer
    {
        /// <summary>
        /// Initializes a new instance of LuceneStandardTokenizer.
        /// </summary>
        /// <param name="name">
        /// The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores,
        /// can only start and end with alphanumeric characters, and is limited to 128 characters.
        /// </param>
        public LuceneStandardTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.StandardTokenizerV2";
        }

        /// <summary>
        /// The maximum token length. Default is 255.
        /// Tokens longer than the maximum length are split.
        /// The maximum token length that can be used is 300 characters.
        /// </summary>
        public int? MaxTokenLength { get; set; }
    }
}
