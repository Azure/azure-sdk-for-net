// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Job canceling event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.JobCanceling event. </summary>
    public partial class MediaJobCancelingEventData : MediaJobStateChangeEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobCancelingEventData"/>. </summary>
        internal MediaJobCancelingEventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobCancelingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        internal MediaJobCancelingEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData) : base(previousState, state, correlationData)
        {
        }
    }
}
