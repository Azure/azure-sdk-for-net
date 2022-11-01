// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of summaries produced from a given document.
    /// </summary>
    [DebuggerTypeProxy(typeof(SummaryCollectionDebugView))]
    public class SummaryCollection : ReadOnlyCollection<Summary>
    {
        internal SummaryCollection(IList<Summary> summaries, IList<TextAnalyticsWarning> warnings)
            : base(summaries)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// The warnings the resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// A debugger proxy for the <see cref="SummaryCollection"/> class.
        /// </summary>
        internal class SummaryCollectionDebugView
        {
            private SummaryCollection BaseCollection { get; }

            public SummaryCollectionDebugView(SummaryCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<Summary> Items
            {
                get
                {
                    return BaseCollection.ToList();
                }
            }

            public IReadOnlyCollection<TextAnalyticsWarning> Warnings
            {
                get
                {
                    return BaseCollection.Warnings;
                }
            }
        }
    }
}
