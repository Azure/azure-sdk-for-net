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
        public string Name { get; internal set; }

        /// <summary>
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// </summary>
        public string Language { get; internal set; }

        /// <summary>
        /// </summary>
        public string DataSource { get; internal set; }

        /// <summary>
        /// </summary>
        public Uri Uri { get; internal set; }

        /// <summary>
        /// </summary>
        public IEnumerable<LinkedEntityMatch> Matches { get; internal set; }
    }
}
