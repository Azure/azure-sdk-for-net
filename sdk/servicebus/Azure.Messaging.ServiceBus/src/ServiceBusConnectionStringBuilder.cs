// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Primitives;

    /// <summary>
    /// Used to generate Service Bus connection strings.
    /// </summary>
    internal class ServiceBusConnectionStringBuilder
    {
        private const char KeyValueSeparator = '=';
        private const char KeyValuePairDelimiter = ';';
        private const string EndpointScheme = "amqps";
        private const string EndpointConfigName = "Endpoint";
        private const string SharedAccessKeyNameConfigName = "SharedAccessKeyName";
        private const string SharedAccessKeyConfigName = "SharedAccessKey";
        private const string SharedAccessSignatureConfigName = "SharedAccessSignature";
        private const string AuthenticationConfigName = "Authentication";
        private const string EntityPathConfigName = "EntityPath";
        private const string TransportTypeConfigName = "TransportType";
        private const string OperationTimeoutConfigName = "OperationTimeout";
        private string _entityPath, sasKeyName, sasKey, sasToken, endpoint;
        private AuthenticationType _authType = AuthenticationType.Other;

        /// <summary>
        ///
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            ///
            /// </summary>
            Other,
            /// <summary>
            ///
            /// </summary>
            ManagedIdentity
        }

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>
        /// </summary>
        public ServiceBusConnectionStringBuilder()
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="connectionString">Connection string for namespace or the entity.</param>
        public ServiceBusConnectionStringBuilder(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                ParseConnectionString(connectionString);
            }
        }

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var connectionStringBuilder = new ServiceBusConnectionStringBuilder(
        ///     "contoso.servicebus.windows.net",
        ///     "myQueue",
        ///     "RootManageSharedAccessKey",
        ///     "&amp;lt;sharedAccessKey&amp;gt;
        /// );
        /// </code>
        /// </example>
        /// <param name="endpoint">Fully qualified endpoint.</param>
        /// <param name="entityPath"></param>
        /// <param name="sharedAccessKeyName"></param>
        /// <param name="sharedAccessKey"></param>
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessKeyName, string sharedAccessKey)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(endpoint));
            }
            if (string.IsNullOrWhiteSpace(sharedAccessKeyName) || string.IsNullOrWhiteSpace(sharedAccessKey))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(string.IsNullOrWhiteSpace(sharedAccessKeyName) ? nameof(sharedAccessKeyName) : nameof(sharedAccessKey));
            }

            this.Endpoint = endpoint;
            this.EntityName = entityPath;
            this.SasKeyName = sharedAccessKeyName;
            this.SasKey = sharedAccessKey;
        }

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var connectionStringBuilder = new ServiceBusConnectionStringBuilder(
        ///     "contoso.servicebus.windows.net",
        ///     "myQueue",
        ///     "{ ... SAS token ... }"
        /// );
        /// </code>
        /// </example>
        /// <param name="endpoint">Fully qualified endpoint.</param>
        /// <param name="entityPath"></param>
        /// <param name="sharedAccessSignature"></param>
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessSignature)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(endpoint));
            }
            if (string.IsNullOrWhiteSpace(sharedAccessSignature))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(sharedAccessSignature));
            }

            this.Endpoint = endpoint;
            this.EntityName = entityPath;
            this.SasToken = sharedAccessSignature;
        }

        /// <summary>
        /// Instantiates a new <see cref="T:Microsoft.Azure.ServiceBus.ServiceBusConnectionStringBuilder" />.
        /// </summary>
        /// <example>
        /// <code>
        /// var connectionStringBuilder = new ServiceBusConnectionStringBuilder(
        ///     "contoso.servicebus.windows.net",
        ///     "myQueue",
        ///     "RootManageSharedAccessKey",
        ///     "&amp;lt;sharedAccessKey&amp;gt;,
        ///     TransportType.Amqp
        /// );
        /// </code>
        /// </example>
        /// <param name="endpoint">Fully qualified endpoint.</param>
        /// <param name="entityPath"></param>
        /// <param name="sharedAccessKeyName"></param>
        /// <param name="sharedAccessKey"></param>
        /// <param name="transportType"></param>
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessKeyName, string sharedAccessKey, ServiceBusTransportType transportType)
            : this(endpoint, entityPath, sharedAccessKeyName, sharedAccessKey)
        {
            this.TransportType = transportType;
        }

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var connectionStringBuilder = new ServiceBusConnectionStringBuilder(
        ///     "contoso.servicebus.windows.net",
        ///     "myQueue",
        ///     "{ ... SAS token ... }",
        ///     TransportType.Amqp
        /// );
        /// </code>
        /// </example>
        /// <param name="endpoint">Fully qualified endpoint.</param>
        /// <param name="entityPath"></param>
        /// <param name="sharedAccessSignature"></param>
        /// <param name="transportType"></param>
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessSignature, ServiceBusTransportType transportType)
            :this(endpoint, entityPath, sharedAccessSignature)
        {
            this.TransportType = transportType;
        }

        /// <summary>
        /// Fully qualified domain name of the endpoint.
        /// </summary>
        /// <example>
        /// <code>this.Endpoint = contoso.servicebus.windows.net</code>
        /// </example>
        /// <exception cref="ArgumentException">Throws when endpoint is not fully qualified endpoint.</exception>
        /// <exception cref="UriFormatException">Throws when the hostname cannot be parsed</exception>
        public string Endpoint
        {
            get => endpoint;
            set
            {
                if (!value.Contains("."))
                {
                    throw Fx.Exception.Argument(nameof(Endpoint), "Endpoint should be fully qualified endpoint");
                }

                var uriBuilder = new UriBuilder(value.Trim());
                endpoint = (value.Contains("://") ? uriBuilder.Scheme : EndpointScheme) + "://" + uriBuilder.Host;
                FullyQualifiedNamespace = uriBuilder.Host;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public string FullyQualifiedNamespace { get; private set; }

        /// <summary>
        /// Get the entity name value from the connection string
        /// </summary>
        public string EntityName
        {
            get => this._entityPath;
            set => this._entityPath = value.Trim();
        }

        /// <summary>
        /// Get the shared access policy owner name from the connection string
        /// </summary>
        public string SasKeyName
        {
            get => this.sasKeyName;
            set
            {
                if (this.Authentication != AuthenticationType.Other)
                {
                    throw Fx.Exception.Argument("Authentication, SasKeyName", Resources.ArgumentInvalidCombination.FormatForUser("Authentication, SasKeyName"));
                }
                this.sasKeyName = value.Trim();
            }
        }

        /// <summary>
        /// Get the shared access policy key value from the connection string
        /// </summary>
        /// <value>Shared Access Signature key</value>
        public string SasKey
        {
            get => this.sasKey;
            set => this.sasKey = value.Trim();
        }

         /// <summary>
        /// Get the shared access signature token from the connection string
        /// </summary>
        /// <value>Shared Access Signature token</value>
        public string SasToken
        {
            get => this.sasToken;
            set
            {
                if (this.Authentication != AuthenticationType.Other)
                {
                    throw Fx.Exception.Argument("Authentication, SasToken", Resources.ArgumentInvalidCombination.FormatForUser("Authentication, SasToken"));
                }
                this.sasToken = value.Trim();
            }
        }

        /// <summary>
        /// Get the transport type from the connection string
        /// </summary>
        public ServiceBusTransportType TransportType { get; set; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        /// <remarks>Defaults to 1 minute.</remarks>
        public TimeSpan OperationTimeout { get; set; } = Constants.DefaultOperationTimeout;

        /// <summary>
        /// Enables Azure Active Directory Managed Identity authentication when set to ServiceBusConnectionStringBuilder.AuthenticationType.ManagedIdentity
        /// </summary>
        public AuthenticationType Authentication
        {
            get => this._authType;
            set
            {
                if (!string.IsNullOrWhiteSpace(this.SasKeyName))
                {
                    throw Fx.Exception.Argument(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName),
                        Resources.ArgumentInvalidCombination.FormatForUser(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName)));
                }

                if (!string.IsNullOrWhiteSpace(this.SasToken))
                {
                    throw Fx.Exception.Argument(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName),
                        Resources.ArgumentInvalidCombination.FormatForUser(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName)));
                }
                this._authType = value;
            }
        }

        internal Dictionary<string, string> ConnectionStringProperties = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to ServiceBus Namespace
        /// </summary>
        /// <returns>Namespace connection string</returns>
        public string GetNamespaceConnectionString()
        {
            var connectionStringBuilder = new StringBuilder();
            if (this.Endpoint != null)
            {
                connectionStringBuilder.Append(EndpointConfigName).Append(KeyValueSeparator).Append(this.Endpoint).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(this.SasKeyName))
            {
                connectionStringBuilder.Append(SharedAccessKeyNameConfigName).Append(KeyValueSeparator).Append(this.SasKeyName).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(this.SasKey))
            {
                connectionStringBuilder.Append(SharedAccessKeyConfigName).Append(KeyValueSeparator).Append(this.SasKey).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(this.SasToken))
            {
                connectionStringBuilder.Append(SharedAccessSignatureConfigName).Append(KeyValueSeparator).Append(this.SasToken).Append(KeyValuePairDelimiter);
            }

            if (this.TransportType != ServiceBusTransportType.AmqpTcp)
            {
                connectionStringBuilder.Append(TransportTypeConfigName).Append(KeyValueSeparator).Append(this.TransportType).Append(KeyValuePairDelimiter);
            }

            if (this.OperationTimeout != Constants.DefaultOperationTimeout)
            {
                connectionStringBuilder.Append(OperationTimeoutConfigName).Append(KeyValueSeparator).Append(this.OperationTimeout).Append(KeyValuePairDelimiter);
            }

            if (this.Authentication == AuthenticationType.ManagedIdentity)
            {
                connectionStringBuilder.Append(AuthenticationConfigName).Append(KeyValueSeparator).Append("Managed Identity").Append(KeyValuePairDelimiter);
            }

            return connectionStringBuilder.ToString().Trim(';');
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to the given ServiceBus Entity
        /// </summary>
        /// <returns>Entity connection string</returns>
        public string GetEntityConnectionString()
        {
            if (string.IsNullOrWhiteSpace(this.EntityName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(this.EntityName));
            }

            return $"{this.GetNamespaceConnectionString()}{KeyValuePairDelimiter}{EntityPathConfigName}{KeyValueSeparator}{this.EntityName}";
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to ServiceBus Namespace
        /// </summary>
        /// <returns>The connection string</returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.EntityName))
            {
                return this.GetNamespaceConnectionString();
            }

            return this.GetEntityConnectionString();
        }

        internal void ParseConnectionString(string connectionString)
        {
            // First split based on ';'
            var keyValuePairs = connectionString.Split(new[] { KeyValuePairDelimiter }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var keyValuePair in keyValuePairs)
            {
                // Now split based on the _first_ '='
                var keyAndValue = keyValuePair.Split(new[] { KeyValueSeparator }, 2);
                var key = keyAndValue[0];
                if (keyAndValue.Length != 2)
                {
                    throw Fx.Exception.Argument(nameof(connectionString), $"Value for the connection string parameter name '{key}' was not found.");
                }

                var value = keyAndValue[1].Trim();
                if (key.Equals(EndpointConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    Endpoint = value;
                }
                else if (key.Equals(SharedAccessKeyNameConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SasKeyName = value;
                }
                else if (key.Equals(EntityPathConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    EntityName = value;
                }
                else if (key.Equals(SharedAccessKeyConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SasKey = value;
                }
                else if (key.Equals(SharedAccessSignatureConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    SasToken = value;
                }
                else if (key.Equals(TransportTypeConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    if (Enum.TryParse(value, true, out ServiceBusTransportType transportType))
                    {
                        TransportType = transportType;
                    }
                }
                else if (key.Equals(OperationTimeoutConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(value, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out var timeoutInSeconds))
                    {
                        OperationTimeout = TimeSpan.FromSeconds(timeoutInSeconds);
                    }
                    else if (TimeSpan.TryParse(value, NumberFormatInfo.InvariantInfo, out var operationTimeout))
                    {
                        OperationTimeout = operationTimeout;
                    }
                    else
                    {
                        throw Fx.Exception.Argument(nameof(connectionString), $"The {OperationTimeoutConfigName} ({value}) format is invalid. It must be an integer representing a number of seconds.");
                    }

                    if (OperationTimeout.TotalMilliseconds <= 0)
                    {
                        throw Fx.Exception.Argument(nameof(connectionString), $"The {OperationTimeoutConfigName} ({value}) must be greater than zero.");
                    }

                    if (OperationTimeout.TotalHours >= 1)
                    {
                        throw Fx.Exception.Argument(nameof(connectionString), $"The {OperationTimeoutConfigName} ({value}) must be smaller than one hour.");
                    }
                }
                else if (key.Equals(AuthenticationConfigName, StringComparison.OrdinalIgnoreCase) && !int.TryParse(value, out _))
                {
                    value = value.Replace(" ", string.Empty);
                    if (!Enum.TryParse(value, true, out this._authType))
                    {
                        _authType = AuthenticationType.Other;
                    }
                }
                else
                {
                    ConnectionStringProperties[key] = value;
                }
            }
        }
    }
}
