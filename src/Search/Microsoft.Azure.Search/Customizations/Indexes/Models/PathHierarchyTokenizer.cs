// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Tokenizer for path-like hierarchies. This tokenizer is implemented
    /// using Apache Lucene.
    /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/path/PathHierarchyTokenizer.html" />
    /// </summary>
    [JsonObject("#Microsoft.Azure.Search.PathHierarchyTokenizer")]
    public partial class PathHierarchyTokenizer : Tokenizer
    {
        /// <summary>
        /// Initializes a new instance of the PathHierarchyTokenizer class.
        /// </summary>
        public PathHierarchyTokenizer() { }

        /// <summary>
        /// Initializes a new instance of the PathHierarchyTokenizer class.
        /// </summary>
        public PathHierarchyTokenizer(string name, char? delimiter = default(char?), char? replacement = default(char?), int? bufferSize = default(int?), bool? reverseTokenOrder = default(bool?), int? numberOfTokensToSkip = default(int?))
            : base(name)
        {
            Delimiter = delimiter;
            Replacement = replacement;
            BufferSize = bufferSize;
            ReverseTokenOrder = reverseTokenOrder;
            NumberOfTokensToSkip = numberOfTokensToSkip;
        }

        /// <summary>
        /// Gets or sets the delimiter character to use. Default is "/".
        /// </summary>
        [JsonProperty(PropertyName = "delimiter")]
        public char? Delimiter { get; set; }

        /// <summary>
        /// Gets or sets a value that, if set, replaces the delimiter
        /// character. Default is "/".
        /// </summary>
        [JsonProperty(PropertyName = "replacement")]
        public char? Replacement { get; set; }

        /// <summary>
        /// Gets or sets the buffer size. Default is 1024.
        /// </summary>
        [JsonProperty(PropertyName = "bufferSize")]
        public int? BufferSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to generate tokens in
        /// reverse order. Default is false.
        /// </summary>
        [JsonProperty(PropertyName = "reverse")]
        public bool? ReverseTokenOrder { get; set; }

        /// <summary>
        /// Gets or sets the number of initial tokens to skip. Default is 0.
        /// </summary>
        [JsonProperty(PropertyName = "skip")]
        public int? NumberOfTokensToSkip { get; set; }
    }
}
