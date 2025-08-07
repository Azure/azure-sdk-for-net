// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// A note attached to a job
    /// </summary>
    public partial class RouterJobNote
    {
        /// <summary> Initializes a new instance of RouterJobNote. </summary>
        /// <param name="message"> The message contained in the note. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public RouterJobNote(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary>
        /// The time at which the note was added in UTC. If not provided, will default to the current time.
        /// </summary>
        public DateTimeOffset? AddedAt { get; set; }
    }
}
