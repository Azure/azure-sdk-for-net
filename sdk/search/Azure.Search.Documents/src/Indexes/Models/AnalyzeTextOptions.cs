// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
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
    }
}
