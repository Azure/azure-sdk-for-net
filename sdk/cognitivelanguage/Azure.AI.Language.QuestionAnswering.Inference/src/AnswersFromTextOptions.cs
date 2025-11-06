// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    public partial class AnswersFromTextOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AnswersFromTextOptions"/> from the given parameters.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="textDocuments">The text documents to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <returns>A new instance of the <see cref="AnswersFromTextOptions"/> from the given parameters.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        internal static AnswersFromTextOptions From(
            string question,
            IEnumerable<string> textDocuments,
            string language
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            int id = 1;
            return new AnswersFromTextOptions(
                question,
                textDocuments.Select(record => new TextDocument(
                    id++.ToString(CultureInfo.InvariantCulture),
                    record
                ))
            )
            {
                Language = language,
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AnswersFromTextOptions"/> from the given parameters.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="textDocuments">The collection of <see cref="TextDocument"/> to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default, which uses "en" for English.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <returns>A new instance of the <see cref="AnswersFromTextOptions"/> from the given parameters.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        internal static AnswersFromTextOptions From(
            string question,
            IEnumerable<TextDocument> textDocuments,
            string language
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));

            return new(question, textDocuments) { Language = language };
        }

        /// <summary>
        /// Clones the <see cref="AnswersFromTextOptions"/> using the given <paramref name="language"/> if <see cref="Language"/> is not already set.
        /// </summary>
        /// <param name="language">The language to use if <see cref="Language"/> is not already set.</param>
        /// <returns>A shallow clone of the <see cref="AnswersFromTextOptions"/>.</returns>
        internal AnswersFromTextOptions Clone(string language) =>
            new(Question, TextDocuments) { Language = Language ?? language };
    }
}
