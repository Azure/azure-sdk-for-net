// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessorOptions
    {
        /// <summary>
        ///   TODO. (nullable? Default value?)
        /// </summary>
        ///
        public EventPosition InitialEventPosition { get; set; }

        /// <summary>
        ///   TODO. (Guard? Default value?)
        /// </summary>
        ///
        public int MaximumMessageCount { get; set; }

        /// <summary>
        ///   TODO. (nullable? Does null work?) Should we delegate the validation to the Consumer?
        /// </summary>
        ///
        public TimeSpan MaximumReceiveWaitTime { get; set; }

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

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventProcessorOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorOptions" />.</returns>
        ///
        internal EventProcessorOptions Clone() =>
            new EventProcessorOptions
            {
                // TODO: EventPosition properties are internal. Should we clone it?
                InitialEventPosition = this.InitialEventPosition,
                MaximumMessageCount = this.MaximumMessageCount,
                MaximumReceiveWaitTime = this.MaximumReceiveWaitTime
            };
    }
}
