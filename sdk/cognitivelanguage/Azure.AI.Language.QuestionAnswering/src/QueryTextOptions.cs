// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    [CodeGenModel("TextQueryOptions")]
    public partial class QueryTextOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryTextOptions"/> class from another instance using a shallow clone.
        /// </summary>
        /// <param name="options">The <see cref="QueryTextOptions"/> to copy.</param>
        internal QueryTextOptions(QueryTextOptions options)
        {
            Question = options.Question;
            Records = options.Records;
            Language = options.Language;
            StringIndexType = options.StringIndexType;
        }

        /// <summary>
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the method used to interpret string offsets.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultStringIndexType"/> as the default, which uses <see cref="StringIndexType.Utf16CodeUnit"/> for .NET.
        /// </summary>
        public StringIndexType? StringIndexType { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="QueryTextOptions"/> from the given parameters.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="records">The string records to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// </param>
        /// <returns>A new instance of the <see cref="QueryTextOptions"/> from the given parameters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        internal static QueryTextOptions From(string question, IEnumerable<string> records, string language)
        {
            Argument.AssertNotNull(records, nameof(records));

            int id = 1;
            return new QueryTextOptions(question, records.Select(record => new TextRecord(id++.ToString(CultureInfo.InvariantCulture), record)))
            {
                Language = language,
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="QueryTextOptions"/> from the given parameters.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="records">The collection of <see cref="TextRecord"/> to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// </param>
        /// <returns>A new instance of the <see cref="QueryTextOptions"/> from the given parameters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        internal static QueryTextOptions From(string question, IEnumerable<TextRecord> records, string language) =>
            new(question, records)
            {
                Language = language,
            };
    }
}
