// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using TrackOne.Primitives;

namespace TrackOne
{
    /// <summary>
    ///  Supported transport types
    /// </summary>
    public enum TransportType
    {
        /// <summary>
        /// AMQP over the default TCP transport protocol
        /// </summary>
        Amqp,

        /// <summary>
        /// AMQP over the Web Sockets transport protocol
        /// </summary>
        AmqpWebSockets
    }

    /// <summary>
    /// EventHubsConnectionStringBuilder can be used to construct a connection string which can establish communication with Event Hubs entities.
    /// It can also be used to perform basic validation on an existing connection string.
    /// <para/>
    /// A connection string is basically a string consisted of key-value pair separated by ";".
    /// Basic format is "&lt;key&gt;=&lt;value&gt;[;&lt;key&gt;=&lt;value&gt;]" where supported key name are as follow:
    /// <para/> Endpoint - the URL that contains the Event Hubs namespace
    /// <para/> EntityPath - the path to the Event Hub entity
    /// <para/> SharedAccessKeyName - the key name to the corresponding shared access policy rule for the namespace, or entity.
    /// <para/> SharedAccessKey - the key for the corresponding shared access policy rule of the namespace or entity.
    /// </summary>
    /// <example>
    /// Sample code:
    /// <code>
    /// var connectionStringBuiler = new EventHubsConnectionStringBuilder(
    ///     "amqps://EventHubsNamespaceName.servicebus.windows.net",
    ///     "EventHubsEntityName", // Event Hub Name
    ///     "SharedAccessSignatureKeyName",
    ///     "SharedAccessSignatureKey");
    ///  string connectionString = connectionStringBuiler.ToString();
    /// </code>
    /// </example>
    internal class EventHubsConnectionStringBuilder
    {
        private const char KeyValueSeparator = '=';
        private const char KeyValuePairDelimiter = ';';
        private static readonly string s_endpointScheme = "amqps";
        private static readonly string s_endpointConfigName = "Endpoint";
        private static readonly string s_sharedAccessKeyNameConfigName = "SharedAccessKeyName";
        private static readonly string s_sharedAccessKeyConfigName = "SharedAccessKey";
        private static readonly string s_entityPathConfigName = "EntityPath";
        private static readonly string s_operationTimeoutConfigName = "OperationTimeout";
        private static readonly string s_transportTypeConfigName = "TransportType";
        private static readonly string s_sharedAccessSignatureConfigName = "SharedAccessSignature";

        /// <summary>
        /// Build a connection string consumable by <see cref="EventHubClient.CreateFromConnectionString(string)"/>
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Entity path or Event Hub name.</param>
        /// <param name="sharedAccessKeyName">Shared Access Key name</param>
        /// <param name="sharedAccessKey">Shared Access Key</param>
        public EventHubsConnectionStringBuilder(
            Uri endpointAddress,
            string entityPath,
            string sharedAccessKeyName,
            string sharedAccessKey)
            : this(endpointAddress, entityPath, sharedAccessKeyName, sharedAccessKey, ClientConstants.DefaultOperationTimeout)
        {
        }

        /// <summary>
        /// Build a connection string consumable by <see cref="EventHubClient.CreateFromConnectionString(string)"/>
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Entity path or Event Hub name.</param>
        /// <param name="sharedAccessKeyName">Shared Access Key name</param>
        /// <param name="sharedAccessKey">Shared Access Key</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations</param>
        public EventHubsConnectionStringBuilder(
            Uri endpointAddress,
            string entityPath,
            string sharedAccessKeyName,
            string sharedAccessKey,
            TimeSpan operationTimeout)
            : this(endpointAddress, entityPath, operationTimeout)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(sharedAccessKey), sharedAccessKey);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(sharedAccessKeyName), sharedAccessKeyName);

            SasKey = sharedAccessKey;
            SasKeyName = sharedAccessKeyName;
        }

        /// <summary>
        /// Build a connection string consumable by <see cref="EventHubClient.CreateFromConnectionString(string)"/>
        /// </summary>
        /// <param name="endpointAddress">Fully qualified domain name for Event Hubs. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Entity path or Event Hub name.</param>
        /// <param name="sharedAccessSignature">Shared Access Signature</param>
        /// <param name="operationTimeout">Operation timeout for Event Hubs operations</param>
        public EventHubsConnectionStringBuilder(
            Uri endpointAddress,
            string entityPath,
            string sharedAccessSignature,
            TimeSpan operationTimeout)
            : this(endpointAddress, entityPath, operationTimeout)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(sharedAccessSignature), sharedAccessSignature);

            SharedAccessSignature = sharedAccessSignature;
        }

        /// <summary>
        /// ConnectionString format:
        /// Endpoint=sb://namespace_DNS_Name;EntityPath=EVENT_HUB_NAME;SharedAccessKeyName=SHARED_ACCESS_KEY_NAME;SharedAccessKey=SHARED_ACCESS_KEY
        /// </summary>
        /// <param name="connectionString">Event Hubs ConnectionString</param>
        public EventHubsConnectionStringBuilder(string connectionString)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(connectionString), connectionString);

            // Assign default values.
            OperationTimeout = ClientConstants.DefaultOperationTimeout;
            TransportType = TransportType.Amqp;

            // Parse the connection string now and override default values if any provided.
            ParseConnectionString(connectionString);
        }

        internal EventHubsConnectionStringBuilder(
            Uri endpointAddress,
            string entityPath,
            TimeSpan operationTimeout,
            TransportType transportType = TransportType.Amqp)
        {
            Guard.ArgumentNotNull(nameof(endpointAddress), endpointAddress);
            Guard.ArgumentNotNullOrWhiteSpace(nameof(entityPath), entityPath);

            // Replace the scheme. We cannot really make sure that user passed an amps:// scheme to us.
            var uriBuilder = new UriBuilder(endpointAddress.AbsoluteUri)
            {
                Scheme = s_endpointScheme
            };
            Endpoint = uriBuilder.Uri;

            EntityPath = entityPath;
            OperationTimeout = operationTimeout;
            TransportType = transportType;
        }

        /// <summary>
        /// Gets or sets the Event Hubs endpoint.
        /// </summary>
        public Uri Endpoint { get; set; }

        /// <summary>
        /// Get the shared access policy key value from the connection string
        /// </summary>
        /// <value>Shared Access Signature key</value>
        public string SasKey { get; set; }

        /// <summary>
        /// Get the shared access policy owner name from the connection string
        /// </summary>
        public string SasKeyName { get; set; }

        /// <summary>
        /// Gets or sets the SAS access token.
        /// </summary>
        /// <value>Shared Access Signature</value>
        public string SharedAccessSignature { get; set; }

        /// <summary>
        /// Get the entity path value from the connection string
        /// </summary>
        public string EntityPath { get; set; }

        /// <summary>
        /// OperationTimeout is applied in erroneous situations to notify the caller about the relevant <see cref="EventHubsException"/>
        /// </summary>
        public TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// Transport type for the client connection.
        /// Avaiable options are Amqp and AmqpWebSockets.
        /// Defaults to Amqp if not specified.
        /// </summary>
        public TransportType TransportType { get; set; }

        /// <summary>
        /// Creates a cloned object of the current <see cref="EventHubsConnectionStringBuilder"/>.
        /// </summary>
        /// <returns>A new <see cref="EventHubsConnectionStringBuilder"/></returns>
        public EventHubsConnectionStringBuilder Clone()
        {
            var clone = new EventHubsConnectionStringBuilder(ToString())
            {
                OperationTimeout = OperationTimeout
            };
            return clone;
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to Event Hubs Namespace
        /// </summary>
        /// <returns>the connection string</returns>
        public override string ToString()
        {
            Validate();
            var connectionStringBuilder = new StringBuilder();
            if (Endpoint != null)
            {
                connectionStringBuilder.Append($"{s_endpointConfigName}{KeyValueSeparator}{Endpoint}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(EntityPath))
            {
                connectionStringBuilder.Append($"{s_entityPathConfigName}{KeyValueSeparator}{EntityPath}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(SasKeyName))
            {
                connectionStringBuilder.Append($"{s_sharedAccessKeyNameConfigName}{KeyValueSeparator}{SasKeyName}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(SasKey))
            {
                connectionStringBuilder.Append($"{s_sharedAccessKeyConfigName}{KeyValueSeparator}{SasKey}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(SharedAccessSignature))
            {
                connectionStringBuilder.Append($"{s_sharedAccessSignatureConfigName}{KeyValueSeparator}{SharedAccessSignature}{KeyValuePairDelimiter}");
            }

            if (OperationTimeout != ClientConstants.DefaultOperationTimeout)
            {
                connectionStringBuilder.Append($"{s_operationTimeoutConfigName}{KeyValueSeparator}{OperationTimeout}{KeyValuePairDelimiter}");
            }

            if (TransportType != ClientConstants.DefaultTransportType)
            {
                connectionStringBuilder.Append($"{s_transportTypeConfigName}{KeyValueSeparator}{TransportType}{KeyValuePairDelimiter}");
            }

            return connectionStringBuilder.ToString();
        }

        private void Validate()
        {
            if (Endpoint == null)
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(s_endpointConfigName);
            }

            // if one supplied sharedAccessKeyName, they need to supply sharedAccesssecret, and vise versa
            // if SharedAccessSignature is specified, SasKey or SasKeyName should not be specified
            var hasSasKeyName = !string.IsNullOrWhiteSpace(SasKeyName);
            var hasSasKey = !string.IsNullOrWhiteSpace(SasKey);
            var hasSharedAccessSignature = !string.IsNullOrWhiteSpace(SharedAccessSignature);

            if (hasSharedAccessSignature)
            {
                if (hasSasKeyName)
                {
                    throw Fx.Exception.Argument(
                        string.Format("{0},{1}", s_sharedAccessSignatureConfigName, s_sharedAccessKeyNameConfigName),
                        Resources.SasTokenShouldBeAlone.FormatForUser(s_sharedAccessSignatureConfigName, s_sharedAccessKeyNameConfigName));
                }

                if (hasSasKey)
                {
                    throw Fx.Exception.Argument(
                        string.Format("{0},{1}", s_sharedAccessSignatureConfigName, s_sharedAccessKeyConfigName),
                        Resources.SasTokenShouldBeAlone.FormatForUser(s_sharedAccessSignatureConfigName, s_sharedAccessKeyConfigName));
                }
            }

            if (hasSasKeyName && !hasSasKey || !hasSasKeyName && hasSasKey)
            {
                throw Fx.Exception.Argument(
                    string.Format("{0},{1}", s_sharedAccessKeyNameConfigName, s_sharedAccessKeyConfigName),
                    Resources.ArgumentInvalidCombination.FormatForUser(s_sharedAccessKeyNameConfigName, s_sharedAccessKeyConfigName));
            }
        }

        private void ParseConnectionString(string connectionString)
        {
            // First split based on ';'
            string[] keyValuePairs = connectionString.Split(new[] { KeyValuePairDelimiter }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var keyValuePair in keyValuePairs)
            {
                // Now split based on the _first_ '='
                string[] keyAndValue = keyValuePair.Split(new[] { KeyValueSeparator }, 2);
                string key = keyAndValue[0];
                if (keyAndValue.Length != 2)
                {
                    throw Fx.Exception.Argument(nameof(connectionString), $"Value for the connection string parameter name '{key}' was not found.");
                }

                string value = keyAndValue[1];
                if (key.Equals(s_endpointConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    Endpoint = new Uri(value);
                }
                else if (key.Equals(s_entityPathConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    EntityPath = value;
                }
                else if (key.Equals(s_sharedAccessKeyNameConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SasKeyName = value;
                }
                else if (key.Equals(s_sharedAccessKeyConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SasKey = value;
                }
                else if (key.Equals(s_sharedAccessSignatureConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SharedAccessSignature = value;
                }
                else if (key.Equals(s_operationTimeoutConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    OperationTimeout = TimeSpan.Parse(value);
                }
                else if (key.Equals(s_transportTypeConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    TransportType = (TransportType)Enum.Parse(typeof(TransportType), value);
                }
                else
                {
                    throw Fx.Exception.Argument(nameof(connectionString), $"Illegal connection string parameter name '{key}'");
                }
            }
        }
    }
}
