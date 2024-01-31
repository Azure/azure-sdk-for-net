// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of categories that were used to classify a given document.
    /// </summary>
    [DebuggerTypeProxy(typeof(ClassificationCategoryCollectionDebugView))]
    public class ClassificationCategoryCollection : ReadOnlyCollection<ClassificationCategory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationCategoryCollection"/> class.
        /// </summary>
        internal ClassificationCategoryCollection(IList<ClassificationCategory> classificationCategories, IList<TextAnalyticsWarning> warnings)
            : base(classificationCategories)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// A debugger proxy for the <see cref="ClassificationCategoryCollection"/> class.
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
