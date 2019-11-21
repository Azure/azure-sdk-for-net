// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs
{

    /// <summary>
    ///   A factory to create a connection to the Azure Event Hubs service, enabling client communications with a specific
    ///   Event Hub instance within an Event Hubs namespace.  A single connection may be shared among multiple
    ///   Event Hub producers and/or consumers, or may be used as a dedicated connection for a single
    ///   producer or consumer client.
    /// </summary>
    public class EventHubConnectionFactory
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace that the connection is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public virtual string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the connection is associated with, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public virtual string EventHubName { get; }

        private readonly TokenCredential credential;

        private readonly EventHubConnectionOptions connectionOptions;

        private readonly string connectionString;

        /// <summary>
        ///  Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        protected internal EventHubConnectionFactory()
        {

        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventHubConnectionFactory(string connectionString) : this(connectionString, null, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventHubConnectionFactory(string connectionString,
                                  EventHubConnectionOptions connectionOptions) : this(connectionString, null, connectionOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConnectionFactory(string connectionString,
                                  string eventHubName) : this(connectionString, eventHubName, connectionOptions: null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubConnectionFactory(string connectionString,
                                  string eventHubName,
                                  EventHubConnectionOptions connectionOptions)
        {
            this.connectionString = connectionString;
            this.EventHubName = eventHubName;
            this.connectionOptions = connectionOptions;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConnectionFactory"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the connection with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="connectionOptions">A set of options to apply when configuring the connection.</param>
        ///
        public EventHubConnectionFactory(string fullyQualifiedNamespace,
                                          string eventHubName,
                                          TokenCredential credential,
                                          EventHubConnectionOptions connectionOptions = default)
        {
            this.FullyQualifiedNamespace = fullyQualifiedNamespace;
            this.EventHubName = eventHubName;
            this.credential = credential;
            this.connectionOptions = connectionOptions;
        }

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> instance.
        /// </summary>
        ///
        /// <returns>A new <see cref="EventHubConnection" /> instance.</returns>
        public virtual EventHubConnection CreateConnection()
        {
            if (credential != null)
            {
                return new EventHubConnection(FullyQualifiedNamespace, EventHubName, credential, connectionOptions);
            }
            else
            {
                return new EventHubConnection(FullyQualifiedNamespace, EventHubName, connectionOptions);
            }
        }
    }
}
