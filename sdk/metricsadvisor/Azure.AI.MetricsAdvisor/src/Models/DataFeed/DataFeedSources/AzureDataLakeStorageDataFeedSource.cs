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
    /// Describes an Azure Data Lake Storage Gen2 data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureDataLakeStorageDataFeedSource : DataFeedSource
    {
        private string _accountKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageDataFeedSource"/> class. This constructor does not
        /// set an <see cref="AccountKey"/>, so you must assign an <see cref="AuthenticationType"/> to the <see cref="Authentication"/>
        /// property. If you intend to use the default authentication type, <see cref="AuthenticationType.Basic"/>, see
        /// <see cref="AzureDataLakeStorageDataFeedSource(string, string, string, string, string)"/>.
        /// </summary>
        /// <param name="accountName">The name of the Storage Account.</param>
        /// <param name="fileSystemName">The name of the file system.</param>
        /// <param name="directoryTemplate">The directory template.</param>
        /// <param name="fileTemplate">
        /// This is the file template of the Blob file. For example: X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
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
        /// <exception cref="ArgumentNullException"><paramref name="accountName"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountName"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is empty.</exception>
        public AzureDataLakeStorageDataFeedSource(string accountName, string fileSystemName, string directoryTemplate, string fileTemplate)
            : base(DataFeedSourceKind.AzureDataLakeStorage)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(fileSystemName, nameof(fileSystemName));
            Argument.AssertNotNullOrEmpty(directoryTemplate, nameof(directoryTemplate));
            Argument.AssertNotNullOrEmpty(fileTemplate, nameof(fileTemplate));

            AccountName = accountName;
            FileSystemName = fileSystemName;
            DirectoryTemplate = directoryTemplate;
            FileTemplate = fileTemplate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageDataFeedSource"/> class. This constructor
        /// requires an <paramref name="accountKey"/> and is intended to be used with the default authentication type,
        /// <see cref="AuthenticationType.Basic"/>. If you intend to use another type of authentication, see
        /// <see cref="AzureDataLakeStorageDataFeedSource(string, string, string, string)"/>.
        /// </summary>
        /// <param name="accountName">The name of the Storage Account.</param>
        /// <param name="accountKey">The Storage Account key.</param>
        /// <param name="fileSystemName">The name of the file system.</param>
        /// <param name="directoryTemplate">The directory template.</param>
        /// <param name="fileTemplate">
        /// This is the file template of the Blob file. For example: X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
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
        /// <exception cref="ArgumentNullException"><paramref name="accountName"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, <paramref name="fileTemplate"/>, or <paramref name="accountKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountName"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, <paramref name="fileTemplate"/>, or <paramref name="accountKey"/> is empty.</exception>
        public AzureDataLakeStorageDataFeedSource(string accountName, string accountKey, string fileSystemName, string directoryTemplate, string fileTemplate)
            : this(accountName, fileSystemName, directoryTemplate, fileTemplate)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));

            AccountKey = accountKey;
        }

        internal AzureDataLakeStorageDataFeedSource(AzureDataLakeStorageGen2Parameter parameter, AuthenticationTypeEnum? authentication, string credentialId)
            : base(DataFeedSourceKind.AzureDataLakeStorage)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            AccountName = parameter.AccountName;
            AccountKey = parameter.AccountKey;
            FileSystemName = parameter.FileSystemName;
            DirectoryTemplate = parameter.DirectoryTemplate;
            FileTemplate = parameter.FileTemplate;

            Authentication = (authentication == null) ? default(AuthenticationType?) : new AuthenticationType(authentication.ToString());
            DataSourceCredentialId = credentialId;
        }

        /// <summary>
        /// The method used to authenticate to this <see cref="AzureDataLakeStorageDataFeedSource"/>. Be aware that some
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
        /// The name of the Storage Account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// The name of the file system.
        /// </summary>
        public string FileSystemName { get; set; }

        /// <summary>
        /// The directory template.
        /// </summary>
        public string DirectoryTemplate { get; set; }

        /// <summary>
        /// This is the file template of the Blob file. For example: X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
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
        public string FileTemplate { get; set; }

        /// <summary>
        /// The Storage Account key.
        /// </summary>
        internal string AccountKey
        {
            get => Volatile.Read(ref _accountKey);
            private set => Volatile.Write(ref _accountKey, value);
        }

        /// <summary>
        /// Updates the account key.
        /// </summary>
        /// <param name="accountKey">The new account key to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="accountKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountKey"/> is empty.</exception>
        public void UpdateAccountKey(string accountKey)
        {
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));
            AccountKey = accountKey;
        }

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureDataLakeStorageDataFeedSource"/>. Be aware that
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
            /// Only uses the <see cref="AccountKey"/> present in this <see cref="AzureDataLakeStorageDataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            public static AuthenticationType Basic => new AuthenticationType(AuthenticationTypeEnum.Basic.ToString());

            /// <summary>
            /// Uses a Data Lake Storage Gen 2 shared key for authentication. You need to have a
            /// <see cref="DataLakeSharedKeyCredentialEntity"/> in the server in order to use this type of authentication.
            /// </summary>
            public static AuthenticationType SharedKey => new AuthenticationType(AuthenticationTypeEnum.DataLakeGen2SharedKey.ToString());

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
