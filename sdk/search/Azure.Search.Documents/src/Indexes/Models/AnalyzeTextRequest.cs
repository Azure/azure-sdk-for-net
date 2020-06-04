// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("AnalyzeRequest")]
    public partial class AnalyzeTextRequest
    {
        /// <summary>
        /// Initializes a new instance of AnalyzeRequest.
        /// One of <see cref="Analyzer"/> or <see cref="Tokenizer"/> is also required.
        /// </summary>
        /// <param name="text">Required text to break into tokens.</param>
        public AnalyzeTextRequest(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));

            TokenFilters = new List<TokenFilterName>();
            CharFilters = new List<string>();
        }

        /// <summary> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IList<TokenFilterName> TokenFilters { get; }

        /// <summary> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IList<string> CharFilters { get; }
    }
}
