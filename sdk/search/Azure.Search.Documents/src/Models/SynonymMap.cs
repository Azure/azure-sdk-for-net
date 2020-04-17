// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    public partial class SynonymMap
    {
        private const string DefaultFormat = "soln";
        private const string NewLine = "\n";

        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="synonym">The synonym to define.</param>
        /// <param name="format">The format of the synonym map. Currently, only "soln" is supported and is the default value.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/>, <paramref name="synonym"/>, or <paramref name="format"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="synonym"/>, or <paramref name="format"/> is null.</exception>
        public SynonymMap(string name, string synonym, string format = DefaultFormat)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(format, nameof(format));
            Argument.AssertNotNullOrEmpty(synonym, nameof(synonym));

            Name = name;
            Format = format;
            Synonyms = synonym;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="synonyms">One or more synonyms to define. These values will be separated by line breaks automatically.</param>
        /// <param name="format">The format of the synonym map. Currently, only "soln" is supported and is the default value.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/>, <paramref name="synonyms"/>, or <paramref name="format"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="synonyms"/>, or <paramref name="format"/> is null.</exception>
        public SynonymMap(string name, IEnumerable<string> synonyms, string format = DefaultFormat)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(format, nameof(format));
            Argument.AssertNotNullOrEmpty(synonyms, nameof(synonyms));

            Name = name;
            Format = format;
            Synonyms = string.Join(NewLine, synonyms);
        }

        private SynonymMap()
        {
        }

        /// <summary>
        /// Gets the name of the synonym map.
        /// </summary>
        [CodeGenMember("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the format of the synonym map.
        /// </summary>
        [CodeGenMember("format")]
        public string Format { get; internal set; }

        /// <summary>
        /// Gets the synonym rules for this synonym map.
        /// </summary>
        [CodeGenMember("synonyms")]
        public string Synonyms { get; internal set; }
    }
}
