// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    public partial class Suggester
    {
        private const string AnalyzingInfixMatching = "analyzingInfixMatching";

        /// <summary>
        /// Creates a new instance of the <see cref="Suggester"/> class.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies. Each field must be searchable.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="sourceFields"/> is null.</exception>
        public Suggester(string name, IEnumerable<string> sourceFields)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(sourceFields, nameof(sourceFields));

            Name = name;
            SourceFields = sourceFields.ToList();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Suggester"/> class.
        /// </summary>
        /// <param name="name">The name of the suggester.</param>
        /// <param name="sourceFields">The list of field names to which the suggester applies. Each field must be searchable.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="sourceFields"/> is null.</exception>
        public Suggester(string name, params string[] sourceFields) : this(name, (IEnumerable<string>)sourceFields)
        {
        }

        private Suggester()
        {
        }

        [CodeGenMember("searchMode")]
        private string SearchMode { get; } = AnalyzingInfixMatching;
    }
}
