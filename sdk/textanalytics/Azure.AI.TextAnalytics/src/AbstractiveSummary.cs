// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A summary produced by the service from a given document.
    /// </summary>
    public readonly struct AbstractiveSummary
    {
        internal AbstractiveSummary(AbstractiveSummaryInternal summary)
        {
            Text = summary.Text;

            List<AbstractiveSummaryContext> contexts = new();
            foreach (SummaryContextInternal context in summary.Contexts)
            {
                contexts.Add(new AbstractiveSummaryContext(context));
            }
            Contexts = contexts;
        }

        /// <summary>
        /// The text of the summary.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The collection of <see cref="AbstractiveSummaryContext"/> objects that reference the text that was used as context by
        /// the service to produce the summary.
        /// </summary>
        public IReadOnlyCollection<AbstractiveSummaryContext> Contexts { get; }
    }
}
