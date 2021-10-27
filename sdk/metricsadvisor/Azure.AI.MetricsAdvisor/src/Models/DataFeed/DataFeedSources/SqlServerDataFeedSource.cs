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
    /// Describes an SQL Server data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class SqlServerDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDataFeedSource"/> class. This constructor does not
        /// set a <see cref="ConnectionString"/>, so you must assign an <see cref="AuthenticationType"/> to the
        /// <see cref="Authentication"/> property. Currently, only the <see cref="AuthenticationType.SqlConnectionString"/>
        /// authentication is supported without a connection string. If you intend to use another type of authentication,
        /// see <see cref="SqlServerDataFeedSource(string, string)"/>.
        /// </summary>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="query"/> is empty.</exception>
        public SqlServerDataFeedSource(string query)
            : base(DataFeedSourceKind.SqlServer)
        {
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Query = query;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDataFeedSource"/> class. This constructor requires a
        /// <paramref name="connectionString"/> and is intended to be used with the authentication types
        /// <see cref="AuthenticationType.Basic"/> (default), <see cref="AuthenticationType.ManagedIdentity"/>,
        /// <see cref="AuthenticationType.ServicePrincipal"/>, or <see cref="AuthenticationType.ServicePrincipalInKeyVault"/>.
        /// If you intend to use <see cref="AuthenticationType.SqlConnectionString"/> authentication, see
        /// <see cref="SqlServerDataFeedSource(string)"/>.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="query"/> is empty.</exception>
        public SqlServerDataFeedSource(string connectionString, string query)
            : this(query)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ConnectionString = connectionString;
            Query = query;
        }

        internal SqlServerDataFeedSource(SqlSourceParameter parameter, AuthenticationTypeEnum? authentication, string credentialId)
            : base(DataFeedSourceKind.SqlServer)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Query = parameter.Query;

            Authentication = (authentication == null) ? default(AuthenticationType?) : new AuthenticationType(authentication.ToString());
            DataSourceCredentialId = credentialId;
        }

        /// <summary>
        /// The method used to authenticate to this <see cref="SqlServerDataFeedSource"/>. Be aware that some
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
        /// The different ways of authenticating to a <see cref="SqlServerDataFeedSource"/>. Be aware that
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
            /// Only uses the <see cref="ConnectionString"/> present in this <see cref="SqlServerDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            public static AuthenticationType Basic => new AuthenticationType(AuthenticationTypeEnum.Basic.ToString());

            /// <summary>
            /// Uses Managed Identity authentication.
            /// </summary>
            public static AuthenticationType ManagedIdentity => new AuthenticationType(AuthenticationTypeEnum.ManagedIdentity.ToString());

            /// <summary>
            /// Uses a SQL Server connection string for authentication. You need to have a
            /// <see cref="SqlConnectionStringCredentialEntity"/> in the server in order to use this type of
            /// authentication.
            /// </summary>
            public static AuthenticationType SqlConnectionString => new AuthenticationType(AuthenticationTypeEnum.AzureSQLConnectionString.ToString());

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
