// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Primitives;

    /// <summary>
    /// Used to generate Service Bus connection strings.
    /// </summary>
    public class ServiceBusConnectionStringBuilder
    {
        const char KeyValueSeparator = '=';
        const char KeyValuePairDelimiter = ';';
        const string EndpointScheme = "amqps";
        const string EndpointConfigName = "Endpoint";
        const string SharedAccessKeyNameConfigName = "SharedAccessKeyName";
        const string SharedAccessKeyConfigName = "SharedAccessKey";
        const string SharedAccessSignatureConfigName = "SharedAccessSignature";
        const string AuthenticationConfigName = "Authentication";

        const string EntityPathConfigName = "EntityPath";
        const string TransportTypeConfigName = "TransportType";

        const string OperationTimeoutConfigName = "OperationTimeout";

        string entityPath, sasKeyName, sasKey, sasToken, endpoint;
        AuthenticationType authType = AuthenticationType.Other;

        public enum AuthenticationType
        {
            Other,
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

            Endpoint = endpoint;
            EntityPath = entityPath;
            SasKeyName = sharedAccessKeyName;
            SasKey = sharedAccessKey;
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

            Endpoint = endpoint;
            EntityPath = entityPath;
            SasToken = sharedAccessSignature;
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
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessKeyName, string sharedAccessKey, TransportType transportType)
            : this(endpoint, entityPath, sharedAccessKeyName, sharedAccessKey)
        {
            TransportType = transportType;
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
        public ServiceBusConnectionStringBuilder(string endpoint, string entityPath, string sharedAccessSignature, TransportType transportType)
            :this(endpoint, entityPath, sharedAccessSignature)
        {
            TransportType = transportType;
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
            }
        }

        /// <summary>
        /// Get the entity path value from the connection string
        /// </summary>
        public string EntityPath
        {
            get => entityPath;
            set => entityPath = value.Trim();
        }

        /// <summary>
        /// Get the shared access policy owner name from the connection string
        /// </summary>
        public string SasKeyName
        {
            get => sasKeyName;
            set
            {
                if (Authentication != AuthenticationType.Other)
                {
                    throw Fx.Exception.Argument("Authentication, SasKeyName", Resources.ArgumentInvalidCombination.FormatForUser("Authentication, SasKeyName"));
                }
                sasKeyName = value.Trim();
            }
        }

        /// <summary>
        /// Get the shared access policy key value from the connection string
        /// </summary>
        /// <value>Shared Access Signature key</value>
        public string SasKey
        {
            get => sasKey;
            set => sasKey = value.Trim();
        }

         /// <summary>
        /// Get the shared access signature token from the connection string
        /// </summary>
        /// <value>Shared Access Signature token</value>
        public string SasToken
        {
            get => sasToken;
            set
            {
                if (Authentication != AuthenticationType.Other)
                {
                    throw Fx.Exception.Argument("Authentication, SasToken", Resources.ArgumentInvalidCombination.FormatForUser("Authentication, SasToken"));
                }
                sasToken = value.Trim();
            }
        }

        /// <summary>
        /// Get the transport type from the connection string
        /// </summary>
        public TransportType TransportType { get; set; }

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
            get => authType;
            set
            {
                if (!string.IsNullOrWhiteSpace(SasKeyName))
                {
                    throw Fx.Exception.Argument(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName), 
                        Resources.ArgumentInvalidCombination.FormatForUser(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName)));
                }

                if (!string.IsNullOrWhiteSpace(SasToken))
                {
                    throw Fx.Exception.Argument(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName), 
                        Resources.ArgumentInvalidCombination.FormatForUser(nameof(AuthenticationConfigName) + ", " + nameof(SharedAccessKeyConfigName)));
                }
                authType = value;
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
            if (Endpoint != null)
            {
                connectionStringBuilder.Append(EndpointConfigName).Append(KeyValueSeparator).Append(Endpoint).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(SasKeyName))
            {
                connectionStringBuilder.Append(SharedAccessKeyNameConfigName).Append(KeyValueSeparator).Append(SasKeyName).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(SasKey))
            {
                connectionStringBuilder.Append(SharedAccessKeyConfigName).Append(KeyValueSeparator).Append(SasKey).Append(KeyValuePairDelimiter);
            }

            if (!string.IsNullOrWhiteSpace(SasToken))
            {
                connectionStringBuilder.Append(SharedAccessSignatureConfigName).Append(KeyValueSeparator).Append(SasToken).Append(KeyValuePairDelimiter);
            }

            if (TransportType != TransportType.Amqp)
            {
                connectionStringBuilder.Append(TransportTypeConfigName).Append(KeyValueSeparator).Append(TransportType).Append(KeyValuePairDelimiter);
            }

            if (OperationTimeout != Constants.DefaultOperationTimeout)
            {
                connectionStringBuilder.Append(OperationTimeoutConfigName).Append(KeyValueSeparator).Append(OperationTimeout).Append(KeyValuePairDelimiter);
            }

            if (Authentication == AuthenticationType.ManagedIdentity)
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
            if (string.IsNullOrWhiteSpace(EntityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(EntityPath));
            }

            return $"{GetNamespaceConnectionString()}{KeyValuePairDelimiter}{EntityPathConfigName}{KeyValueSeparator}{EntityPath}";
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to ServiceBus Namespace
        /// </summary>
        /// <returns>The connection string</returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(EntityPath))
            {
                return GetNamespaceConnectionString();
            }

            return GetEntityConnectionString();
        }

        void ParseConnectionString(string connectionString)
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
                    EntityPath = value;
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
                    if (Enum.TryParse(value, true, out TransportType transportType))
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
                    if (!Enum.TryParse(value, true, out authType))
                    {
                        authType = AuthenticationType.Other;
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