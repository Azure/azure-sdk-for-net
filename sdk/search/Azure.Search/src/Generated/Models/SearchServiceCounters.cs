// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Search.Models
{
    /// <summary> Represents service-level resource counters and quotas. </summary>
    public partial class SearchServiceCounters
    {
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter DocumentCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter IndexCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter IndexerCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter DataSourceCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter StorageSizeCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public SearchResourceCounter SynonymMapCounter { get; set; }
    }
}
