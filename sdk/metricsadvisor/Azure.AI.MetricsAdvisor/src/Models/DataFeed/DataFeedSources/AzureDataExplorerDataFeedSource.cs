// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Data Explorer data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureDataExplorerDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataExplorerDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="query"/> is empty.</exception>
        public AzureDataExplorerDataFeedSource(string connectionString, string query)
            : base(DataFeedSourceKind.AzureDataExplorer)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ConnectionString = connectionString;
            Query = query;
        }

        internal AzureDataExplorerDataFeedSource(SqlSourceParameter parameter, AuthenticationTypeEnum? authentication, string credentialId)
            : base(DataFeedSourceKind.AzureDataExplorer)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Query = parameter.Query;

            Authentication = (authentication == null) ? default(AuthenticationType?) : new AuthenticationType(authentication.ToString());
            DataSourceCredentialId = credentialId;
        }

        /// <summary>
        /// The method used to authenticate to this <see cref="AzureDataExplorerDataFeedSource"/>. Be aware that some
        /// authentication types require you to have a <see cref="DataSourceCredentialEntity"/> in the service. In this
        /// case, you also need to set the property <see cref="DataSourceCredentialId"/> to specify which credential
        /// to use. Defaults to <see cref="AuthenticationType.Basic"/>.
        /// </summary>
        public AuthenticationType? Authentication { get; set; }

        /// <summary>
        /// The ID of the <see cref="DataSourceCredentialEntity"/> to use for authentication. The type of authentication to use
        /// must also be specified in the property <see cref="Authentication"/>.
        /// </summary>
        public string DataSourceCredentialId { get; set; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The connection string.
        /// </summary>
        internal string ConnectionString
        {
            get => Volatile.Read(ref _connectionString);
            private set => Volatile.Write(ref _connectionString, value);
        }

        /// <summary>
        /// Updates the connection string.
        /// </summary>
        /// <param name="connectionString">The new connection string to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> is empty.</exception>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureDataExplorerDataFeedSource"/>. Be aware that
        /// some authentication types require you to have a <see cref="DataSourceCredentialEntity"/> in the service. In this
        /// case, you also need to set the property <see cref="DataSourceCredentialId"/> to specify which credential
        /// to use. Defaults to <see cref="Basic"/>.
        /// </summary>
#pragma warning disable CA1034 // Nested types should not be visible
        public readonly partial struct AuthenticationType : IEquatable<AuthenticationType>
#pragma warning restore CA1034 // Nested types should not be visible
        {
            private readonly string _value;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuthenticationType"/> structure.
            /// </summary>
            /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
            internal AuthenticationType(string value)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary>
            /// Only uses the <see cref="ConnectionString"/> present in this <see cref="AzureDataExplorerDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            public static AuthenticationType Basic => new AuthenticationType(AuthenticationTypeEnum.Basic.ToString());

            /// <summary>
            /// Uses Managed Identity authentication.
            /// </summary>
            public static AuthenticationType ManagedIdentity => new AuthenticationType(AuthenticationTypeEnum.ManagedIdentity.ToString());

            /// <summary>
            /// Uses Service Principal authentication. You need to have a <see cref="ServicePrincipalCredentialEntity"/>
            /// in the server in order to use this type of authentication.
            /// </summary>
            public static AuthenticationType ServicePrincipal => new AuthenticationType(AuthenticationTypeEnum.ServicePrincipal.ToString());

            /// <summary>
            /// Uses Service Principal authentication, but the client ID and the client secret must be
            /// stored in a Key Vault resource. You need to have a <see cref="ServicePrincipalInKeyVaultCredentialEntity"/>
            /// in the server in order to use this type of authentication.
            /// </summary>
            public static AuthenticationType ServicePrincipalInKeyVault => new AuthenticationType(AuthenticationTypeEnum.ServicePrincipalInKV.ToString());

            /// <summary>
            /// Determines if two <see cref="AuthenticationType"/> values are the same.
            /// </summary>
            public static bool operator ==(AuthenticationType left, AuthenticationType right) => left.Equals(right);

            /// <summary>
            /// Determines if two <see cref="AuthenticationType"/> values are not the same.
            /// </summary>
            public static bool operator !=(AuthenticationType left, AuthenticationType right) => !left.Equals(right);

            /// <summary>
            /// Converts a <c>string</c> to an <see cref="AuthenticationType"/>.
            /// </summary>
            public static implicit operator AuthenticationType(string value) => new AuthenticationType(value);

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => obj is AuthenticationType other && Equals(other);

            /// <inheritdoc/>
            public bool Equals(AuthenticationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => _value?.GetHashCode() ?? 0;

            /// <inheritdoc/>
            public override string ToString() => _value;
        }
    }
}
