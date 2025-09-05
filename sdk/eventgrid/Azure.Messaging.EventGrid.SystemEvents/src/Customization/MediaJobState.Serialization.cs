// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobStateExtensions
    {
        public static string ToSerialString(this MediaJobState value) => value switch
        {
            MediaJobState.Canceled => "Canceled",
            MediaJobState.Canceling => "Canceling",
            MediaJobState.Error => "Error",
            MediaJobState.Finished => "Finished",
            MediaJobState.Processing => "Processing",
            MediaJobState.Queued => "Queued",
            MediaJobState.Scheduled => "Scheduled",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobState value.")
        };

        public static MediaJobState ToMediaJobState(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Canceled")) return MediaJobState.Canceled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Canceling")) return MediaJobState.Canceling;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Error")) return MediaJobState.Error;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Finished")) return MediaJobState.Finished;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Processing")) return MediaJobState.Processing;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Queued")) return MediaJobState.Queued;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Scheduled")) return MediaJobState.Scheduled;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobState value.");
        }
    }
}
