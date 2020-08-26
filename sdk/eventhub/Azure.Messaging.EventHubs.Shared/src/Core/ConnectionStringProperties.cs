// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of properties that comprise a connection string from the
    ///   Azure portal.
    /// </summary>
    ///
    internal struct ConnectionStringProperties
    {
        /// <summary>
        ///   The endpoint to be used for connecting to the Event Hubs namespace.
        /// </summary>
        ///
        /// <value>The endpoint address, including protocol, from the connection string.</value>
        ///
        public Uri Endpoint { get; }

        /// <summary>
        ///   The name of the specific Event Hub instance under the associated Event Hubs namespace.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; }

        /// <summary>
        ///   The value of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKey { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ConnectionStringProperties"/> structure.
        /// </summary>
        ///
        /// <param name="endpoint">The endpoint of the Event Hubs namespace.</param>
        /// <param name="eventHubName">The name of the specific Event Hub under the namespace.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key, to use authorization.</param>
        /// <param name="sharedAccessKey">The shared access key to use for authorization.</param>
        ///
        public ConnectionStringProperties(Uri endpoint,
                                          string eventHubName,
                                          string sharedAccessKeyName,
                                          string sharedAccessKey)
        {
            Endpoint = endpoint;
            EventHubName = eventHubName;
            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
        }

        /// <summary>
        ///   Performs the actions needed to validate the set of connection string properties for connecting to the
        ///   Event Hubs service.
        /// </summary>
        ///
        /// <param name="explicitEventHubName">The name of the Event Hub that was explicitly passed independent of the connection string, allowing easier use of a namespace-level connection string.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <exception cref="ArgumentException">In the case that the properties violate an invariant or otherwise represent a combination that is not permissible, an appropriate exception will be thrown.</exception>
        ///
        public void Validate(string explicitEventHubName,
                             string connectionStringArgumentName)
        {
            // The Event Hub name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
            // value, then do not consider this a failure.

            if ((!string.IsNullOrEmpty(explicitEventHubName))
                && (!string.IsNullOrEmpty(EventHubName))
                && (!string.Equals(explicitEventHubName, EventHubName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException(Resources.OnlyOneEventHubNameMayBeSpecified, connectionStringArgumentName);
            }

            // Ensure that each of the needed components are present for connecting.

            if ((string.IsNullOrEmpty(explicitEventHubName)) && (string.IsNullOrEmpty(EventHubName))
                || (string.IsNullOrEmpty(Endpoint?.Host))
                || (string.IsNullOrEmpty(SharedAccessKeyName))
                || (string.IsNullOrEmpty(SharedAccessKey)))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation, connectionStringArgumentName);
            }
        }
    }
}
