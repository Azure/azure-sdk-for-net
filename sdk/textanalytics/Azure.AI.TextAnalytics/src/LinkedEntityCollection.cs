// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="LinkedEntity"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(LinkedEntityCollectionDebugView))]
    public class LinkedEntityCollection : ReadOnlyCollection<LinkedEntity>
    {
        internal LinkedEntityCollection(IList<LinkedEntity> entities, IList<TextAnalyticsWarning> warnings)
       : base(entities)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Gets the warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="LinkedEntityCollection"/>.
        /// </summary>
        internal class LinkedEntityCollectionDebugView
        {
            private LinkedEntityCollection BaseCollection { get; }

            public LinkedEntityCollectionDebugView(LinkedEntityCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<LinkedEntity> Items
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
