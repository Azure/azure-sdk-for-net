// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.Language.Models;

namespace Azure.AI.Language
{
    /// <summary>
    /// QAResults
    /// </summary>
    public class QAResults
    {
        internal QAResults(List<QAResult> qAResults)
        {
            Answers = new ReadOnlyCollection<QAResult>(qAResults);
        }

        internal QAResults(QAResults qaResults)
        {
            Answers = qaResults.Answers;
        }

        /// <summary>
        /// Gets the predicted sentiment for each sentence in the corresponding
        /// document.
        /// </summary>
        public IReadOnlyCollection<QAResult> Answers { get; }

    }
}
