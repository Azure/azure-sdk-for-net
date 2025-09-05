// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Media.JobStateChange event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobStateChangeEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobStateChangeEventData"/>. </summary>
        internal MediaJobStateChangeEventData()
        {
            CorrelationData = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobStateChangeEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        internal MediaJobStateChangeEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData)
        {
            PreviousState = previousState;
            State = state;
            CorrelationData = correlationData;
        }

        /// <summary> The previous state of the Job. </summary>
        public MediaJobState? PreviousState { get; }
        /// <summary> The new state of the Job. </summary>
        public MediaJobState? State { get; }
        /// <summary> Gets the Job correlation data. </summary>
        public IReadOnlyDictionary<string, string> CorrelationData { get; }
    }
}
