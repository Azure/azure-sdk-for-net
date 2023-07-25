// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// A note attached to a job
    /// </summary>
    public class RouterJobNote
    {
        /// <summary>
        /// The message contained in the note.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The time at which the note was added in UTC. If not provided, will default to the current time.
        /// </summary>
        public DateTimeOffset? AddedAt { get; set; }
    }
}
