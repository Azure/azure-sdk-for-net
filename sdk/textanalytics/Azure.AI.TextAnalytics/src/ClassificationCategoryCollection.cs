// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="ClassificationCategory"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(ClassificationCategoryCollectionDebugView))]
    public class ClassificationCategoryCollection : ReadOnlyCollection<ClassificationCategory>
    {
        internal ClassificationCategoryCollection(IList<ClassificationCategory> classificationCategories, IList<TextAnalyticsWarning> warnings)
            : base(classificationCategories)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="ClassificationCategoryCollection"/>.
        /// </summary>
        internal class ClassificationCategoryCollectionDebugView
        {
            private ClassificationCategoryCollection BaseCollection { get; }

            public ClassificationCategoryCollectionDebugView(ClassificationCategoryCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<ClassificationCategory> Items
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
