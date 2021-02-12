﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="ServiceBusSender"/>
    /// to configure its behavior.
    /// </summary>
    public class ServiceBusSenderOptions
    {
        /// <summary>
        /// Gets or sets the transaction group associated with the processor. This is an
        /// arbitrary string that is used to all senders, receivers, and processors that you
        /// wish to use in a transaction that spans multiple different queues, topics, or subscriptions.
        /// If your transactions only involves a single queue, topic, or subscription, this property
        /// should not be set.
        /// </summary>
        public string TransactionGroup { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Creates a new copy of the current <see cref="ServiceBusSenderOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ServiceBusSenderOptions" />.</returns>
        internal ServiceBusSenderOptions Clone() =>
            new ServiceBusSenderOptions
            {
                TransactionGroup = TransactionGroup
            };
    }
}
