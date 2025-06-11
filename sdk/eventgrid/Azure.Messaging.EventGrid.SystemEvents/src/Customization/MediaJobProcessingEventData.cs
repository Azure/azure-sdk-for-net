// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Job processing event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.JobProcessing event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobProcessingEventData : MediaJobStateChangeEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobProcessingEventData"/>. </summary>
        internal MediaJobProcessingEventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobProcessingEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        internal MediaJobProcessingEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData) : base(previousState, state, correlationData)
        {
        }
    }
}
