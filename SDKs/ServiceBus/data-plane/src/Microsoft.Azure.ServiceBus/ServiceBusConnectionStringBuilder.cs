// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Primitives;

    /// <summary>
    /// Used to generate Service Bus connection strings.
    /// </summary>
    public class ServiceBusConnectionStringBuilder
    {
        const char KeyValueSeparator = '=';
        const char KeyValuePairDelimiter = ';';
        static readonly string EndpointScheme = "amqps";
        static readonly string EndpointConfigName = "Endpoint";
        static readonly string SharedAccessKeyNameConfigName = "SharedAccessKeyName";
        static readonly string SharedAccessKeyConfigName = "SharedAccessKey";
        static readonly string EntityPathConfigName = "EntityPath";

        string entityPath, sasKeyName, sasKey, endpoint;

        /// <summary>
        /// Instantiates a new <see cref="ServiceBusConnectionStringBuilder"/>
        /// </summary>
        public ServiceBusConnectionStringBuilder()
        {
        }

        /// <summary>
        /// Instatiates a new <see cref="ServiceBusConnectionStringBuilder"/>.
        /// </summary>
        /// <param name="connectionString">Connection string for namespace or the entity.</param>
        public ServiceBusConnectionStringBuilder(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                this.ParseConnectionString(connectionString);
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
        /// <param name="entityPath">Path to the entity.</param>
        /// <param name="sharedAccessKeyName">Shared access key name.</param>
        /// <param name="sharedAccessKey">Shared access key.</param>
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
            this.EntityPath = entityPath;
            this.SasKeyName = sharedAccessKeyName;
            this.SasKey = sharedAccessKey;
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
            get => this.endpoint;
            set
            {
                if (!value.Contains("."))
                {
                    throw Fx.Exception.Argument(nameof(Endpoint), "Endpoint should be fully qualified endpoint");
                }

                var uriBuilder = new UriBuilder(value.Trim());
                this.endpoint = (value.Contains("://") ? uriBuilder.Scheme : EndpointScheme) + "://" + uriBuilder.Host;
            }
        }

        /// <summary>
        /// Get the entity path value from the connection string
        /// </summary>
        public string EntityPath
        {
            get => this.entityPath;
            set => this.entityPath = value.Trim();
        }

        /// <summary>
        /// Get the shared access policy owner name from the connection string
        /// </summary>
        public string SasKeyName
        {
            get => this.sasKeyName;
            set => this.sasKeyName = value.Trim();
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

        internal Dictionary<string, string> ConnectionStringProperties = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to ServiceBus Namespace
        /// </summary>
        /// <returns>Namespace connection string</returns>
        public string GetNamespaceConnectionString()
        {
            StringBuilder connectionStringBuilder = new StringBuilder();
            if (this.Endpoint != null)
            {
                connectionStringBuilder.Append($"{EndpointConfigName}{KeyValueSeparator}{this.Endpoint}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.SasKeyName))
            {
                connectionStringBuilder.Append($"{SharedAccessKeyNameConfigName}{KeyValueSeparator}{this.SasKeyName}{KeyValuePairDelimiter}");
            }

            if (!string.IsNullOrWhiteSpace(this.SasKey))
            {
                connectionStringBuilder.Append($"{SharedAccessKeyConfigName}{KeyValueSeparator}{this.SasKey}");
            }

            return connectionStringBuilder.ToString().Trim(';');
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to the given ServiceBus Entity
        /// </summary>
        /// <returns>Entity connection string</returns>
        public string GetEntityConnectionString()
        {
            if (string.IsNullOrWhiteSpace(this.EntityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(this.EntityPath));
            }

            return $"{this.GetNamespaceConnectionString()}{KeyValuePairDelimiter}{EntityPathConfigName}{KeyValueSeparator}{this.EntityPath}";
        }

        /// <summary>
        /// Returns an interoperable connection string that can be used to connect to ServiceBus Namespace
        /// </summary>
        /// <returns>The connection string</returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.EntityPath))
            {
                return this.GetNamespaceConnectionString();
            }

            return this.GetEntityConnectionString();
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

                string value = keyAndValue[1].Trim();
                if (key.Equals(EndpointConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.Endpoint = value;
                }
                else if (key.Equals(SharedAccessKeyNameConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.SasKeyName = value;
                }
                else if (key.Equals(EntityPathConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.EntityPath = value;
                }
                else if (key.Equals(SharedAccessKeyConfigName, StringComparison.OrdinalIgnoreCase))
                {
                    this.SasKey = value;
                }
                else
                {
                    ConnectionStringProperties[key] = value;
                }
            }
        }
    }
}