// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MediaLiveEventIngestHeartbeatEventData
    {
        internal string IngestDriftValueInternal { get; }

        /// <summary>
        /// Gets the ingest drift value.
        /// </summary>
        public int? IngestDriftValue
            => _ingestDriftValue ??= IngestDriftValueInternal == Constants.MediaEvents.NotApplicable
                ? null
                : int.Parse(IngestDriftValueInternal, CultureInfo.InvariantCulture);

        private int? _ingestDriftValue;
    }
}