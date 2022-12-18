// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="CategorizedEntity"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(CategorizedEntityCollectionDebugView))]
    public class CategorizedEntityCollection : ReadOnlyCollection<CategorizedEntity>
    {
        internal CategorizedEntityCollection(IList<CategorizedEntity> entities, IList<TextAnalyticsWarning> warnings)
            : base(entities)
        {
            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="CategorizedEntityCollection"/>.
        /// </summary>
        internal class CategorizedEntityCollectionDebugView
        {
            private CategorizedEntityCollection BaseCollection { get; }

            public CategorizedEntityCollectionDebugView(CategorizedEntityCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<CategorizedEntity> Items
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
