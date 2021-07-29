// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Models
{
    [CodeGenModel("TextQueryOptions")]
    public partial class QueryTextOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueryTextOptions"/> from the given parameters.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <param name="records">The string records to query.</param>
        /// <param name="language">The language of the text records. This is the BCP-47 representation of a language. For example, use &quot;en&quot; for English; &quot;es&quot; for Spanish etc. If not set, uses &quot;en&quot; for English as default.</param>
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
        /// <param name="language">The language of the text records. This is the BCP-47 representation of a language. For example, use &quot;en&quot; for English; &quot;es&quot; for Spanish etc. If not set, uses &quot;en&quot; for English as default.</param>
        /// <returns>A new instance of the <see cref="QueryTextOptions"/> from the given parameters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        internal static QueryTextOptions From(string question, IEnumerable<TextRecord> records, string language) =>
            new(question, records)
            {
                Language = language,
            };
    }
}
