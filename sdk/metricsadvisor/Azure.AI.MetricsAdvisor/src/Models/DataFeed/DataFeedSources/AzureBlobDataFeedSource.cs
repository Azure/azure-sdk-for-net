// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Blob data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureBlobDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Storage Account.</param>
        /// <param name="container">The name of the blob container.</param>
        /// <param name="blobTemplate">
        /// This is the template of the Blob file names. For example: /%Y/%m/X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
        /// <list type="bullet">
        /// <item>
        /// <term>%Y</term>
        /// <description>The year formatted as yyyy</description>
        /// </item>
        /// <item>
        /// <term>%m</term>
        /// <description>The month formatted as MM</description>
        /// </item>
        /// <item>
        /// <term>%d</term>
        /// <description>The day formatted as dd</description>
        /// </item>
        /// <item>
        /// <term>%h</term>
        /// <description>The hour formatted as HH</description>
        /// </item>
        /// <item>
        /// <term>%M</term>
        /// <description>The minute formatted as mm</description>
        /// </item>
        /// </list>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is empty.</exception>
        public AzureBlobDataFeedSource(string connectionString, string container, string blobTemplate)
            : base(DataFeedSourceKind.AzureBlob)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(container, nameof(container));
            Argument.AssertNotNullOrEmpty(blobTemplate, nameof(blobTemplate));

            ConnectionString = connectionString;
            Container = container;
            BlobTemplate = blobTemplate;
        }

        internal AzureBlobDataFeedSource(AzureBlobParameter parameter, AuthenticationTypeEnum? authentication)
            : base(DataFeedSourceKind.AzureBlob)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Container = parameter.Container;
            BlobTemplate = parameter.BlobTemplate;

            SetAuthentication(authentication);
        }

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureBlobDataFeedSource"/>.
        /// Defaults to <see cref="Basic"/>.
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            /// Only uses the <see cref="ConnectionString"/> present in this <see cref="AzureBlobDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            Basic,

            /// <summary>
            /// Uses Managed Identity authentication.
            /// </summary>
            ManagedIdentity
        };

        /// <summary>
        /// The method used to authenticate to this <see cref="AzureDataExplorerDataFeedSource"/>. Defaults to
        /// <see cref="AuthenticationType.Basic"/>.
        /// </summary>
        public AuthenticationType? Authentication { get; set; }

        /// <summary>
        /// The name of the blob container.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// This is the template of the Blob file names. For example: /%Y/%m/X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
        /// <list type="bullet">
        /// <item>
        /// <term>%Y</term>
        /// <description>The year formatted as yyyy</description>
        /// </item>
        /// <item>
        /// <term>%m</term>
        /// <description>The month formatted as MM</description>
        /// </item>
        /// <item>
        /// <term>%d</term>
        /// <description>The day formatted as dd</description>
        /// </item>
        /// <item>
        /// <term>%h</term>
        /// <description>The hour formatted as HH</description>
        /// </item>
        /// <item>
        /// <term>%M</term>
        /// <description>The minute formatted as mm</description>
        /// </item>
        /// </list>
        /// </summary>
        public string BlobTemplate { get; set; }

        /// <summary>
        /// The connection string for authenticating to the Azure Storage Account.
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
        }
    }
}
