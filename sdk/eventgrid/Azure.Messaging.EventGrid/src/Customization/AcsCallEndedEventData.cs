// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Communication.CallEnded event. </summary>
    public partial class AcsCallEndedEventData
    {
        /// <summary> Duration of the call. </summary>
        public TimeSpan? CallDuration => CallDurationInSeconds.HasValue
            ? TimeSpan.FromSeconds(CallDurationInSeconds.Value)
            : null;

        internal float? CallDurationInSeconds { get; }
    }
}
