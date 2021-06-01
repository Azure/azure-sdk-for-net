// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="PiiEntity"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(PiiEntityCollectionDebugView))]
    public class PiiEntityCollection : ReadOnlyCollection<PiiEntity>
    {
        internal PiiEntityCollection(IList<PiiEntity> entities, string redactedText, IList<TextAnalyticsWarning> warnings)
            : base(entities)
        {
            RedactedText = redactedText;
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Gets the text of the input document with all of the Personally Identifiable Information
        /// redacted out.
        /// </summary>
        public string RedactedText { get; }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="PiiEntityCollection"/>.
        /// </summary>
        internal class PiiEntityCollectionDebugView
        {
            private PiiEntityCollection BaseCollection { get; }

            public PiiEntityCollectionDebugView(PiiEntityCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<PiiEntity> Items
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

            public string RedactedText
            {
                get
                {
                    return BaseCollection.RedactedText;
                }
            }
        }
    }
}
