// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Configuration settings for a change feed consumer, parameterized by the event type.
    /// </summary>
    internal class ChangeFeedConfiguration<TEvent> where TEvent : IChangeFeedEvent
    {
        /// <summary>
        /// The container-level prefix that the service prepends to shard paths in the segment manifest.
        /// This is stripped when resolving actual blob paths.
        /// </summary>
        public string ContainerPrefix { get; set; }

        /// <summary>
        /// Delegate that converts a raw Avro record dictionary into a strongly-typed event.
        /// </summary>
        public Func<Dictionary<string, object>, TEvent> EventParser { get; set; }

        /// <summary>
        /// Maximum number of events returned in a single page.
        /// </summary>
        public int DefaultPageSize { get; set; }

        /// <summary>
        /// Download size in bytes for each lazy-loading block read from a chunk blob.
        /// </summary>
        public long ChunkBlockDownloadSize { get; set; }

        /// <summary>
        /// Download size in bytes for the lazy-loading stream that reads just the Avro header
        /// when resuming mid-block. Typically much smaller than <see cref="ChunkBlockDownloadSize"/>.
        /// </summary>
        public long AvroHeaderDownloadSize { get; set; }

        /// <summary>
        /// Year prefix used for the initialization segment that should be skipped when enumerating years.
        /// </summary>
        public string InitializationSegment { get; set; }

        /// <summary>
        /// Blob prefix under which segment manifests are stored.
        /// </summary>
        public string SegmentPrefix { get; set; }

        /// <summary>
        /// Blob path to the meta segments JSON file that contains the last consumable timestamp.
        /// </summary>
        public string MetaSegmentsPath { get; set; }
    }
}
