// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Job finished event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.JobFinished event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MediaJobFinishedEventData : MediaJobStateChangeEventData
    {
        /// <summary> Initializes a new instance of <see cref="MediaJobFinishedEventData"/>. </summary>
        internal MediaJobFinishedEventData()
        {
            Outputs = new ChangeTrackingList<MediaJobOutput>();
        }

        /// <summary> Initializes a new instance of <see cref="MediaJobFinishedEventData"/>. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs">
        /// Gets the Job outputs.
        /// Please note <see cref="MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MediaJobOutputAsset"/>.
        /// </param>
        internal MediaJobFinishedEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs) : base(previousState, state, correlationData)
        {
            Outputs = outputs;
        }

        /// <summary>
        /// Gets the Job outputs.
        /// Please note <see cref="MediaJobOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MediaJobOutputAsset"/>.
        /// </summary>
        public IReadOnlyList<MediaJobOutput> Outputs { get; }
    }
}
