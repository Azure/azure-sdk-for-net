// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="ServiceBusAdministrationClient" />
    ///   to configure its behavior.
    /// </summary>
    public class ServiceBusAdministrationClientOptions : ClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusAdministrationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public ServiceBusAdministrationClientOptions(ServiceVersion version = ServiceVersion.V2021_05)
        {
            Version = version;
        }

        /// <summary>
        /// The versions of Service Bus Administration supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2017-04 service version.
            /// </summary>
            V2017_04 = 1,

            /// <summary>
            /// The 2021-05 service version.
            /// </summary>
            V2021_05 = 2
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

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
