// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Messaging.EventHubs.Plugins;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventSender" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class SenderOptions
    {
        /// <summary>
        ///   The <see cref="EventHubs.RetryPolicy" /> used to govern retry attempts when an issue
        ///   is encountered while sending.
        /// </summary>
        ///
        /// <value>If not specified, the retry policy configured on the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public RetryPolicy RetryPolicy { get; set; } = RetryPolicy.Default;

        /// <summary>
        ///   The default timeout to apply when sending events.  If the timeout is reached, before the Event Hub
        ///   acknowledges receipt of the event data being sent, the attempt will be conisdered failed and considered
        ///   to be retried.
        /// </summary>
        ///
        /// <value>If not specified, the operation timeout requested for the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public TimeSpan TimeoutWhenSending { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The set of transformers to invoke before an event is sent.  These transformers will be run
        ///   collectively, with each potentially receiving a message that was updated by other transformers
        ///   previously.
        /// </summary>
        ///
        /// <remarks>
        ///   The transformers will be run sequentially in the order they appear in the list; each transformer
        ///   will be given the opportunity to inspect and mutate the <see cref="EventData" /> before it is
        ///   ultimately sent, with data that may have been previously updated fed to the next transformer
        ///   in sequence.
        ///
        ///   Transformes may declare themselves as critial or non-critial to the send operation; failures by
        ///   any critical processor will cause the pending send operation to abort.  Non-critical failures will
        ///   be ignored, but may result in corrupt or inconsistent data.
        ///
        ///   It is, therefore, recommended to be very cautious in using transformers that assert their failures as
        ///   non-critial.
        /// </remarks>
        ///
        public IReadOnlyList<EventDataProcessor> BeforeSendTransformers { get; set; }

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
}
