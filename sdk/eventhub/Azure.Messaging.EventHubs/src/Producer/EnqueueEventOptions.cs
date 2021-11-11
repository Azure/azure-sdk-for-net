// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified to influence the way in which events
    ///   are published to the Event Hubs service.
    /// </summary>
    ///
    public class EnqueueEventOptions : SendEventOptions
    {
        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
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
        ///   Deconstructs the instance into its component attributes.
        /// </summary>
        ///
        /// <param name="partitionId">The partition identifier specified by the options.</param>
        /// <param name="partitionKey">The partition key specified by the options.</param>
        ///
        internal void Deconstruct(out string partitionId,
                                  out string partitionKey)
        {
            partitionId = PartitionId;
            partitionKey = PartitionKey;
        }

        /// <summary>
        ///   The set of default attributes for the options, intended to be
        ///   used as alternative to <see cref="Deconstruct" /> when no options
        ///   were specified.
        /// </summary>
        ///
        /// <returns>A tuple of the default values for the options attributes.</returns>
        ///
        internal static (string PartitionId, string PartitionKey) DeconstructOrUseDefaultAttributes(EnqueueEventOptions options = default)
        {
            if (options != null)
            {
                (var partitionId, var partitionKey) = options;
                return (partitionId, partitionKey);
            }

            return (null, null);
        }
    }
}
