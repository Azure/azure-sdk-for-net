// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            : base(DataFeedSourceType.AzureDataExplorer)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ConnectionString = connectionString;
            Query = query;
        }

        internal AzureDataExplorerDataFeedSource(SqlSourceParameter parameter, AuthenticationTypeEnum? authentication, string credentialId)
            : base(DataFeedSourceType.AzureDataExplorer)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Query = parameter.Query;

            SetAuthentication(authentication);
            DataSourceCredentialId = credentialId;
        }

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureDataExplorerDataFeedSource"/>. Be aware that
        /// some authentication types require you to have a <see cref="DataSourceCredentialEntity"/> in the service. In this
        /// case, you also need to set the property <see cref="DataSourceCredentialId"/> to specify which credential
        /// to use. Defaults to <see cref="Basic"/>.
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            /// Only uses the <see cref="ConnectionString"/> present in this <see cref="AzureDataExplorerDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            Basic,

            /// <summary>
            /// Uses Managed Identity authentication.
            /// </summary>
            ManagedIdentity,

            /// <summary>
            /// Uses Service Principal authentication. You need to have a <see cref="DataSourceServicePrincipal"/>
            /// in the server in order to use this type of authentication.
            /// </summary>
            ServicePrincipal,

            /// <summary>
            /// Uses Service Principal authentication, but the client ID and the client secret must be
            /// stored in a Key Vault resource. You need to have a <see cref="DataSourceServicePrincipalInKeyVault"/>
            /// in the server in order to use this type of authentication.
            /// </summary>
            ServicePrincipalInKeyVault
        };

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

        internal AuthenticationTypeEnum? GetAuthenticationTypeEnum() => Authentication switch
        {
            null => default(AuthenticationTypeEnum?),
            AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
            AuthenticationType.ManagedIdentity => AuthenticationTypeEnum.ManagedIdentity,
            AuthenticationType.ServicePrincipal => AuthenticationTypeEnum.ServicePrincipal,
            AuthenticationType.ServicePrincipalInKeyVault => AuthenticationTypeEnum.ServicePrincipalInKV,
            _ => throw new InvalidOperationException($"Unknown authentication type: {Authentication}")
        };

        internal void SetAuthentication(AuthenticationTypeEnum? authentication)
        {
            if (authentication == AuthenticationTypeEnum.Basic)
            {
                Authentication = AuthenticationType.Basic;
            }
            else if (authentication == AuthenticationTypeEnum.ManagedIdentity)
            {
                Authentication = AuthenticationType.ManagedIdentity;
            }
            else if (authentication == AuthenticationTypeEnum.ServicePrincipal)
            {
                Authentication = AuthenticationType.ServicePrincipal;
            }
            else if (authentication == AuthenticationTypeEnum.ServicePrincipalInKV)
            {
                Authentication = AuthenticationType.ServicePrincipalInKeyVault;
            }
        }
    }
}
