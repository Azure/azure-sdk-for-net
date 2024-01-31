// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

// suppress the generated type for the property `SearchMode`
[assembly: CodeGenSuppressType("SuggesterMode")]
namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("Suggester")]
    public partial class SearchSuggester
    {
        private const string AnalyzingInfixMatching = "analyzingInfixMatching";

        /// <summary>
        /// Creates a new instance of the <see cref="SearchSuggester"/> class.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies. Each field must be searchable.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="sourceFields"/> is null.</exception>
        public SearchSuggester(string name, IEnumerable<string> sourceFields)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(sourceFields, nameof(sourceFields));

            Name = name;
            SourceFields = sourceFields.ToList();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SearchSuggester"/> class.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies. Each field must be searchable.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="sourceFields"/> is null.</exception>
        public SearchSuggester(string name, params string[] sourceFields) : this(name, (IEnumerable<string>)sourceFields)
        {
        }

        /// <summary> The list of field names to which the suggester applies. Each field must be searchable. </summary>
        public IList<string> SourceFields { get; }

        [CodeGenMember("searchMode")]
        private string SearchMode { get; } = AnalyzingInfixMatching;
    }
}
