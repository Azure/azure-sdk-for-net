// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DetectLanguageResultCollection : ReadOnlyCollection<DetectLanguageResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        internal DetectLanguageResultCollection(IList<DetectLanguageResult> list) : base(list)
        {
        }

        /// <summary>
        /// </summary>
        public TextBatchStatistics Statistics { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }
    }
}
