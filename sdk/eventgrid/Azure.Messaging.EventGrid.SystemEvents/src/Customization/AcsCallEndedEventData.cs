// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsCallEndedEventData
    {
        /// <summary> Duration of the call. </summary>
        [CodeGenMember("CallDurationInSeconds")]
        public TimeSpan? CallDuration { get; }
    }
}
