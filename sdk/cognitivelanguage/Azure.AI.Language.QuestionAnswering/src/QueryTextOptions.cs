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
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets the method used to interpret string offsets, which always returns <see cref="QuestionAnsweringClientOptions.DefaultStringIndexType"/> for .NET.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        internal StringIndexType? StringIndexType => QuestionAnsweringClientOptions.DefaultStringIndexType;
#pragma warning restore CA1822 // Mark members as static

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

        /// <summary>
        /// Clones the <see cref="QueryTextOptions"/> using the given <paramref name="language"/> if <see cref="Language"/> is not already set.
        /// </summary>
        /// <param name="language">The language to use if <see cref="Language"/> is not already set.</param>
        /// <returns>A shallow clone of the <see cref="QueryTextOptions"/>.</returns>
        internal QueryTextOptions Clone(string language) =>
            new(Question, Records)
            {
                Language = Language ?? language,
            };
    }
}
