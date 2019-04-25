// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Text;
    using Microsoft.Azure.EventHubs.Primitives;

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
    public class EventHubsConnectionStringBuilder
    {
        const char KeyValueSeparator = '=';
        const char KeyValuePairDelimiter = ';';

        static readonly string EndpointScheme = "amqps";
        static readonly string EndpointConfigName = "Endpoint";
        static readonly string SharedAccessKeyNameConfigName = "SharedAccessKeyName";
        static readonly string SharedAccessKeyConfigName = "SharedAccessKey";
        static readonly string EntityPathConfigName = "EntityPath";
        static readonly string OperationTimeoutConfigName = "OperationTimeout";
        static readonly string TransportTypeConfigName = "TransportType";
        static readonly string SharedAccessSignatureConfigName = "SharedAccessSignature";

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
            : this (endpointAddress, entityPath, sharedAccessKeyName, sharedAccessKey, ClientConstants.DefaultOperationTimeout)
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

            this.SasKey = sharedAccessKey;
            this.SasKeyName = sharedAccessKeyName;
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

            this.SharedAccessSignature = sharedAccessSignature;
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
            this.OperationTimeout = ClientConstants.DefaultOperationTimeout;
            this.TransportType = TransportType.Amqp;

            // Parse the connection string now and override default values if any provided.
            this.ParseConnectionString(connectionString);
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
                Scheme = EndpointScheme
            };
            this.Endpoint = uriBuilder.Uri;

            this.EntityPath = entityPath;
            this.OperationTimeout = operationTimeout;
            this.TransportType = transportType;
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
            var clone = new EventHubsConnectionStringBuilder(this.ToString());
            clone.OperationTimeout = this.OperationTimeout;
            return clone;
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to Event Hubs Namespace
        /// </summary>
        /// <returns>the connection string</returns>
        public override string ToString()
        {
            this.Validate();
            var connectionStringBuilder = new StringBuilder();
            if (this.Endpoint != null)
            {
                connectionStringBuilder.Append($"{EndpointConfigName}{KeyValueSeparator}{this.Endpoint}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.EntityPath))
            {
                connectionStringBuilder.Append($"{EntityPathConfigName}{KeyValueSeparator}{this.EntityPath}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.SasKeyName))
            {
                connectionStringBuilder.Append($"{SharedAccessKeyNameConfigName}{KeyValueSeparator}{this.SasKeyName}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.SasKey))
            {
                connectionStringBuilder.Append($"{SharedAccessKeyConfigName}{KeyValueSeparator}{this.SasKey}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.SharedAccessSignature))
            {
                connectionStringBuilder.Append($"{SharedAccessSignatureConfigName}{KeyValueSeparator}{this.SharedAccessSignature}{KeyValuePairDelimiter}");
            }

            if (this.OperationTimeout != ClientConstants.DefaultOperationTimeout)
            {
                connectionStringBuilder.Append($"{OperationTimeoutConfigName}{KeyValueSeparator}{this.OperationTimeout}{KeyValuePairDelimiter}");
            }

            if (this.TransportType != ClientConstants.DefaultTransportType)
            {
                connectionStringBuilder.Append($"{TransportTypeConfigName}{KeyValueSeparator}{this.TransportType}{KeyValuePairDelimiter}");
            }

            return connectionStringBuilder.ToString();
        }

        void Validate()
        {
            if (this.Endpoint == null)
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(EndpointConfigName);
            }

            // if one supplied sharedAccessKeyName, they need to supply sharedAccesssecret, and vise versa
            // if SharedAccessSignature is specified, SasKey or SasKeyName should not be specified
            var hasSasKeyName = !string.IsNullOrWhiteSpace(this.SasKeyName);
            var hasSasKey = !string.IsNullOrWhiteSpace(this.SasKey);
            var hasSharedAccessSignature = !string.IsNullOrWhiteSpace(this.SharedAccessSignature);

            if (hasSharedAccessSignature)
            {
                if (hasSasKeyName)
                {
                    throw Fx.Exception.Argument(
                        string.Format("{0},{1}", SharedAccessSignatureConfigName, SharedAccessKeyNameConfigName),
                        Resources.SasTokenShouldBeAlone.FormatForUser(SharedAccessSignatureConfigName, SharedAccessKeyNameConfigName));
                }

                if (hasSasKey)
                {
                    throw Fx.Exception.Argument(
                        string.Format("{0},{1}", SharedAccessSignatureConfigName, SharedAccessKeyConfigName),
                        Resources.SasTokenShouldBeAlone.FormatForUser(SharedAccessSignatureConfigName, SharedAccessKeyConfigName));
                }
            }

            if (hasSasKeyName && !hasSasKey || !hasSasKeyName && hasSasKey)
            {
                throw Fx.Exception.Argument(
                    string.Format("{0},{1}", SharedAccessKeyNameConfigName, SharedAccessKeyConfigName),
                    Resources.ArgumentInvalidCombination.FormatForUser(SharedAccessKeyNameConfigName, SharedAccessKeyConfigName));
            }
        }

        void ParseConnectionString(string connectionString)
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
                if (key.Equals(EndpointConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.Endpoint = new Uri(value);
                }
                else if (key.Equals(EntityPathConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.EntityPath = value;
                }
                else if (key.Equals(SharedAccessKeyNameConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.SasKeyName = value;
                }
                else if (key.Equals(SharedAccessKeyConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.SasKey = value;
                }
                else if (key.Equals(SharedAccessSignatureConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.SharedAccessSignature = value;
                }
                else if (key.Equals(OperationTimeoutConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.OperationTimeout = TimeSpan.Parse(value);
                }
                else if (key.Equals(TransportTypeConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.TransportType = (TransportType)Enum.Parse(typeof(TransportType), value);
                }
                else
                {
                    throw Fx.Exception.Argument(nameof(connectionString), $"Illegal connection string parameter name '{key}'");
                }
            }
        }
    }
}
