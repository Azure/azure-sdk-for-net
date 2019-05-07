// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A snapshot of which events have been received across all partitions of an Event Hub.
    ///   Primarily intended for use when creating an <see cref="EventReceiver" /> to allow setting
    ///   its starting point to the begin reciving after the last events that it had previously read.
    /// </summary>
    ///
    public class ReceiverCheckpoint
    {
        /// <summary>
        ///   Corresponds to the location of the the first event present in each partition of the
        ///   Event Hub.  Use this checkpoint to begin receiving all events available in the Event Hub.
        /// </summary>
        ///
        public static ReceiverCheckpoint AllAvailableEvents => new ReceiverCheckpoint();  //TODO: Figure out what params are needed

        /// <summary>
        ///   Corresponds to the location at the end of each partition in the Event Hub.  Use this
        ///   position to begin receiving only new events as they are enqueued in the Event Hub, after the
        ///   <see cref="EventReceiver" /> created with this checkpoint begins receiving.
        /// </summary>
        ///
        public static ReceiverCheckpoint NewEventsOnly => new ReceiverCheckpoint(); //TODO: Figure out what params are needed

        /// <summary>
        ///   The date and time, in UTC, that the checkpoint information was last retrieved from the
        ///   Event Hub.
        /// </summary>
        ///
        public DateTime LastRetrievalTimeUtc { get; private set;}

        /// <summary>
        ///   Initializes a new instance of the <see cref="ReceiverCheckpoint"/> class.
        /// </summary>
        ///
        protected ReceiverCheckpoint()
        {
            //TODO: This will require arguments and additional attributes to be designed later.
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }

    //TODO: This class is not in scope for the June Preview; hide or remove it once the implementation begins.
}
