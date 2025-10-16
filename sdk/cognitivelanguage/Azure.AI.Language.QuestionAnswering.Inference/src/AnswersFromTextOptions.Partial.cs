// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    /// <summary>
    /// Client-specific helpers for <see cref="AnswersFromTextOptions"/>.
    /// </summary>
    public partial class AnswersFromTextOptions
    {
        /// <summary>
        /// Creates an <see cref="AnswersFromTextOptions"/> instance using a collection of raw text documents.
        /// </summary>
        /// <param name="question">The user question to ask.</param>
        /// <param name="textDocuments">The raw text documents to evaluate.</param>
        /// <param name="language">The BCP-47 language code for the documents.</param>
        /// <returns>An <see cref="AnswersFromTextOptions"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="question"/> is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        internal static AnswersFromTextOptions From(string question, IEnumerable<string> textDocuments, string language)
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            int id = 1;
            return new AnswersFromTextOptions(question, textDocuments.Select(record => new TextDocument(id++.ToString(CultureInfo.InvariantCulture), record)))
            {
                Language = language,
            };
        }

        /// <summary>
        /// Creates an <see cref="AnswersFromTextOptions"/> instance from the provided <see cref="TextDocument"/> collection.
        /// </summary>
        /// <param name="question">The user question to ask.</param>
        /// <param name="textDocuments">The documents to evaluate.</param>
        /// <param name="language">The BCP-47 language code for the documents.</param>
        /// <returns>An <see cref="AnswersFromTextOptions"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="question"/> is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        internal static AnswersFromTextOptions From(string question, IEnumerable<TextDocument> textDocuments, string language)
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            return new AnswersFromTextOptions(question, textDocuments.ToList())
            {
                Language = language,
            };
        }

        /// <summary>
        /// Creates a shallow clone of the current options, applying a fallback language when <see cref="Language"/> is not specified.
        /// </summary>
        /// <param name="defaultLanguage">The language to apply when <see cref="Language"/> is null.</param>
        /// <returns>A clone of the current <see cref="AnswersFromTextOptions"/>.</returns>
        internal AnswersFromTextOptions Clone(string defaultLanguage) =>
            new AnswersFromTextOptions(Question, TextDocuments)
            {
                Language = Language ?? defaultLanguage,
                StringIndexType = StringIndexType,
            };
    }
}
