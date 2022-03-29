// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="SummarySentence"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(SummarySentenceCollectionDebugView))]
    public class SummarySentenceCollection : ReadOnlyCollection<SummarySentence>
    {
        internal SummarySentenceCollection(IList<SummarySentence> sentences, IList<TextAnalyticsWarning> warnings)
            : base(sentences)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="SummarySentenceCollection"/>.
        /// </summary>
        internal class SummarySentenceCollectionDebugView
        {
            private SummarySentenceCollection BaseCollection { get; }

            public SummarySentenceCollectionDebugView(SummarySentenceCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<SummarySentence> Items
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
