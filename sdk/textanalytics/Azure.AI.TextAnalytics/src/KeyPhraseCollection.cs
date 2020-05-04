// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class KeyPhraseCollection : ReadOnlyCollection<string>
    {
        internal KeyPhraseCollection(IList<string> keyPhrases, IList<TextAnalyticsWarning> warnings)
            : base(keyPhrases)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
