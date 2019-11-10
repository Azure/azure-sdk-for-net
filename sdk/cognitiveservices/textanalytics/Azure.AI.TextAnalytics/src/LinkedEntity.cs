// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct LinkedEntity
    {
        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<LinkedEntityMatch> Matches { get; set; }
    }
}
