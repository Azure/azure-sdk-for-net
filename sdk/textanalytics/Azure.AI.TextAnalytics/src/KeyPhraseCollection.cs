// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of key phrases present in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(KeyPhraseCollectionDebugView))]
    public class KeyPhraseCollection : ReadOnlyCollection<string>
    {
        internal KeyPhraseCollection(IList<string> keyPhrases, IList<TextAnalyticsWarning> warnings)
            : base(keyPhrases)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="KeyPhraseCollection"/>.
        /// </summary>
        internal class KeyPhraseCollectionDebugView
        {
            private KeyPhraseCollection BaseCollection { get; }

            public KeyPhraseCollectionDebugView(KeyPhraseCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<string> Items
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
