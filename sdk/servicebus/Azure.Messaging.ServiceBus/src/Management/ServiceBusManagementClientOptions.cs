// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="ServiceBusManagementClient" />
    ///   to configure its behavior.
    /// </summary>
    public class ServiceBusManagementClientOptions : ClientOptions
    {
        /// <summary>
        ///   Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
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
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
