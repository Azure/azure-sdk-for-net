// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The <see cref="DataSourceCredentialKind"/>. See each specific kind for a description of each.
    /// </summary>
    [CodeGenModel("DataSourceCredentialType")]
    public readonly partial struct DataSourceCredentialKind
    {
        /// <summary>
        /// Authenticates to a <see cref="SqlServerDataFeedSource"/> via connection string.
        /// </summary>
        [CodeGenMember("AzureSQLConnectionString")]
        public static DataSourceCredentialKind SqlConnectionString { get; } = new DataSourceCredentialKind(SqlConnectionStringValue);

        /// <summary>
        /// Authenticates to a <see cref="AzureDataLakeStorageDataFeedSource"/> via shared key.
        /// </summary>
        [CodeGenMember("DataLakeGen2SharedKey")]
        public static DataSourceCredentialKind DataLakeSharedKey { get; } = new DataSourceCredentialKind(DataLakeSharedKeyValue);

        /// <summary>
        /// Authenticates to an Azure service via service principal.
        /// </summary>
        public static DataSourceCredentialKind ServicePrincipal { get; } = new DataSourceCredentialKind(ServicePrincipalValue);

        /// <summary>
        /// Authenticates to an Azure service via service principal. The client ID and the client secret used for data source
        /// authentication must be stored as secrets in a Key Vault resource.
        /// </summary>
        [CodeGenMember("ServicePrincipalInKV")]
        public static DataSourceCredentialKind ServicePrincipalInKeyVault { get; } = new DataSourceCredentialKind(ServicePrincipalInKeyVaultValue);
    }
}
