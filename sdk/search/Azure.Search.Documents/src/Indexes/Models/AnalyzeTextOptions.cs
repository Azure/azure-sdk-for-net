// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("AnalyzeRequest")]
    public partial class AnalyzeTextOptions
    {
        /// <summary>
        /// Initializes a new instance of AnalyzeRequest.
        /// </summary>
        /// <param name="text">Required text to break into tokens.</param>
        /// <param name="analyzerName">The name of the analyzer to use to break the given <paramref name="text"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is null.</exception>
        public AnalyzeTextOptions(string text, LexicalAnalyzerName analyzerName) : this(text)
            => AnalyzerName = analyzerName;

        /// <summary>
        /// Initializes a new instance of AnalyzeRequest.
        /// </summary>
        /// <param name="text">Required text to break into tokens.</param>
        /// <param name="tokenizerName">The name of the tokenizer to use to break the given <paramref name="text"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is null.</exception>
        public AnalyzeTextOptions(string text, LexicalTokenizerName tokenizerName) : this(text)
            => TokenizerName = tokenizerName;

        /// <summary> The name of the analyzer to use to break the given text. </summary>
        [CodeGenMember("Analyzer")]
        public LexicalAnalyzerName? AnalyzerName { get; }

        /// <summary> The name of the tokenizer to use to break the given text. </summary>
        [CodeGenMember("Tokenizer")]
        public LexicalTokenizerName? TokenizerName { get; }

        /// <summary> The name of the normalizer to use to normalize the given text. </summary>
        [CodeGenMember("Normalizer")]
        public LexicalNormalizerName? NormalizerName { get; set; }

        /// <summary> An optional list of token filters to use when breaking the given text. </summary>
        public IList<TokenFilterName> TokenFilters { get; }

        /// <summary> An optional list of character filters to use when breaking the given text. </summary>
        public IList<string> CharFilters { get; }
    }
}
