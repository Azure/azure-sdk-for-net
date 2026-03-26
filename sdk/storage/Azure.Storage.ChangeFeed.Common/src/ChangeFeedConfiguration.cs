// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ChangeFeedConfiguration<TEvent>
    {
        public TimeSpan TimeWindowInterval { get; set; }
        public string ContainerPrefix { get; set; }
        public Func<Dictionary<string, object>, TEvent> EventParser { get; set; }
        public int DefaultPageSize { get; set; } = 5000;
        public long ChunkBlockDownloadSize { get; set; } = Constants.MB;
        public string InitializationSegment { get; set; } = "1601";
        public string SegmentPrefix { get; set; } = "idx/segments/";
        public string MetaSegmentsPath { get; set; } = "meta/segments.json";
    }
}
