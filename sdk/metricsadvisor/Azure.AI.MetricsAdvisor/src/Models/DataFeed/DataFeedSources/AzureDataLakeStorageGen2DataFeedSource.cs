// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Data Lake Storage Gen2 data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureDataLakeStorageGen2DataFeedSource : DataFeedSource
    {
        private string _accountKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageGen2DataFeedSource"/> class.
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
        /// <exception cref="ArgumentNullException"><paramref name="accountName"/>, <paramref name="accountKey"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountName"/>, <paramref name="accountKey"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is empty.</exception>
        public AzureDataLakeStorageGen2DataFeedSource(string accountName, string accountKey, string fileSystemName, string directoryTemplate, string fileTemplate)
            : base(DataFeedSourceType.AzureDataLakeStorageGen2)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));
            Argument.AssertNotNullOrEmpty(fileSystemName, nameof(fileSystemName));
            Argument.AssertNotNullOrEmpty(directoryTemplate, nameof(directoryTemplate));
            Argument.AssertNotNullOrEmpty(fileTemplate, nameof(fileTemplate));

            AccountName = accountName;
            AccountKey = accountKey;
            FileSystemName = fileSystemName;
            DirectoryTemplate = directoryTemplate;
            FileTemplate = fileTemplate;
        }

        internal AzureDataLakeStorageGen2DataFeedSource(AzureDataLakeStorageGen2Parameter parameter, AuthenticationTypeEnum? authentication, string credentialId)
            : base(DataFeedSourceType.AzureDataLakeStorageGen2)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            AccountName = parameter.AccountName;
            AccountKey = parameter.AccountKey;
            FileSystemName = parameter.FileSystemName;
            DirectoryTemplate = parameter.DirectoryTemplate;
            FileTemplate = parameter.FileTemplate;

            SetAuthentication(authentication);
            DataSourceCredentialId = credentialId;
        }

        /// <summary>
        /// The different ways of authenticating to an <see cref="AzureDataLakeStorageGen2DataFeedSource"/>. Be aware that
        /// some authentication types require you to have a <see cref="DataSourceCredentialEntity"/> in the service. In this
        /// case, you also need to set the property <see cref="DataSourceCredentialId"/> to specify which credential
        /// to use. Defaults to <see cref="Basic"/>.
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            /// Only uses the <see cref="AccountKey"/> present in this <see cref="AzureDataLakeStorageGen2DataFeedSource"/>
            /// instance for authentication.
            /// </summary>
            Basic,

            /// <summary>
            /// Uses a Data Lake Storage Gen 2 shared key for authentication. You need to have a
            /// <see cref="DataSourceDataLakeGen2SharedKey"/> in the server in order to use this type of authentication.
            /// </summary>
            SharedKey,

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
        /// The method used to authenticate to this <see cref="AzureDataLakeStorageGen2DataFeedSource"/>. Be aware that some
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

        internal AuthenticationTypeEnum? GetAuthenticationTypeEnum() => Authentication switch
        {
            null => default(AuthenticationTypeEnum?),
            AuthenticationType.Basic => AuthenticationTypeEnum.Basic,
            AuthenticationType.SharedKey => AuthenticationTypeEnum.DataLakeGen2SharedKey,
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
            else if (authentication == AuthenticationTypeEnum.DataLakeGen2SharedKey)
            {
                Authentication = AuthenticationType.SharedKey;
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
