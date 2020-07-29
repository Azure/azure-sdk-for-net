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
        public AnalyzeTextOptions(string text, LexicalAnalyzerName analyzerName)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            AnalyzerName = analyzerName;

            TokenFilters = new ChangeTrackingList<TokenFilterName>();
            CharFilters = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of AnalyzeRequest.
        /// </summary>
        /// <param name="text">Required text to break into tokens.</param>
        /// <param name="tokenizerName">The name of the tokenizer to use to break the given <paramref name="text"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is null.</exception>
        public AnalyzeTextOptions(string text, LexicalTokenizerName tokenizerName)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            TokenizerName = tokenizerName;

            TokenFilters = new ChangeTrackingList<TokenFilterName>();
            CharFilters = new ChangeTrackingList<string>();
        }

        /// <summary> The name of the analyzer to use to break the given text. If this parameter is not specified, you must specify a tokenizer instead. The tokenizer and analyzer parameters are mutually exclusive. </summary>
        [CodeGenMember("Analyzer")]
        public LexicalAnalyzerName? AnalyzerName { get; }

        /// <summary> The name of the tokenizer to use to break the given text. If this parameter is not specified, you must specify an analyzer instead. The tokenizer and analyzer parameters are mutually exclusive. </summary>
        [CodeGenMember("Tokenizer")]
        public LexicalTokenizerName? TokenizerName { get; }

        /// <summary> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public IList<TokenFilterName> TokenFilters { get; }

        /// <summary> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public IList<string> CharFilters { get; }
    }
}
