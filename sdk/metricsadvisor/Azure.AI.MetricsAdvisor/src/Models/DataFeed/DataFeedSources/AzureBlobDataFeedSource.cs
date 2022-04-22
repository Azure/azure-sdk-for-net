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

            Authentication = (authentication == null) ? default(AuthenticationType?) : new AuthenticationType(authentication.ToString());
        }

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

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureBlobDataFeedSource"/>.
        /// Defaults to <see cref="Basic"/>.
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
            /// Only uses the <see cref="ConnectionString"/> present in this <see cref="AzureBlobDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            public static AuthenticationType Basic => new AuthenticationType(AuthenticationTypeEnum.Basic.ToString());

            /// <summary>
            /// Uses Managed Identity authentication.
            /// </summary>
            public static AuthenticationType ManagedIdentity => new AuthenticationType(AuthenticationTypeEnum.ManagedIdentity.ToString());

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
