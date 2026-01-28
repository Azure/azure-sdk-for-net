// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenType("KeywordTokenizerV2")]
    internal partial class KeywordTokenizerV2 { }

    public partial class KeywordTokenizer
    {
        /// <summary>
        /// Initializes a new instance of KeywordTokenizer.
        /// </summary>
        /// <param name="name">
        /// The name of the tokenizer. It must only contain letters, digits, spaces,
        /// dashes or underscores, can only start and end with alphanumeric characters,
        /// and is limited to 128 characters.
        /// </param>
        public KeywordTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.KeywordTokenizerV2";
        }

        /// <summary>
        /// The read buffer size in bytes. Default is 256.
        /// Setting this property on new instances of <see cref="KeywordTokenizer"/> may result in an error
        /// when sending new requests to the Azure Cognitive Search service.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// The maximum token length. Default is 256.
        /// Tokens longer than the maximum length are split.
        /// The maximum token length that can be used is 300 characters.
        /// </summary>
        public int? MaxTokenLength { get; set; }
    }
}
