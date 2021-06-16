// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Provides different ways of authenticating to a <see cref="DataFeedSource"/> for data ingestion when the
    /// default authentication method does not suffice. The supported credentials are:
    /// <list type="bullet">
    ///   <item><see cref="DataLakeGen2SharedKeyDataSourceCredential"/></item>
    ///   <item><see cref="ServicePrincipalDataSourceCredential"/></item>
    ///   <item><see cref="ServicePrincipalInKeyVaultDataSourceCredential"/></item>
    ///   <item><see cref="SqlConnectionStringDataSourceCredential"/></item>
    /// </list>
    /// </summary>
    [CodeGenModel("DataSourceCredential")]
    public partial class DataSourceCredential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceCredential"/> class.
        /// </summary>
        internal DataSourceCredential(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataSourceCredential"/>. Set by the service.
        /// </summary>
        [CodeGenMember("DataSourceCredentialId")]
        public string Id { get; }

        /// <summary>
        /// A custom unique name for this <see cref="DataSourceCredential"/> to be displayed on the web portal.
        /// </summary>
        [CodeGenMember("DataSourceCredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// A description of this <see cref="DataSourceCredential"/>.
        /// </summary>
        [CodeGenMember("DataSourceCredentialDescription")]
        public string Description { get; set; }

        internal DataSourceCredentialPatch GetPatchModel()
        {
            DataSourceCredentialPatch patch = this switch
            {
                DataLakeGen2SharedKeyDataSourceCredential c => new DataLakeGen2SharedKeyCredentialPatch()
                {
                    Parameters = new() { AccountKey = c.AccountKey }
                },
                ServicePrincipalDataSourceCredential c => new ServicePrincipalCredentialPatch()
                {
                    Parameters = new() { ClientId = c.ClientId, ClientSecret = c.ClientSecret, TenantId = c.TenantId }
                },
                ServicePrincipalInKeyVaultDataSourceCredential c => new ServicePrincipalInKVCredentialPatch()
                {
                    Parameters = new()
                    {
                        KeyVaultEndpoint = c.Endpoint.AbsoluteUri,
                        KeyVaultClientId = c.KeyVaultClientId,
                        KeyVaultClientSecret = c.KeyVaultClientSecret,
                        TenantId = c.TenantId,
                        ServicePrincipalIdNameInKV = c.SecretNameForClientId,
                        ServicePrincipalSecretNameInKV = c.SecretNameForClientSecret
                    }
                },
                SqlConnectionStringDataSourceCredential c => new AzureSQLConnectionStringCredentialPatch()
                {
                    Parameters = new() { ConnectionString = c.ConnectionString }
                },
                _ => throw new InvalidOperationException("Invalid data source credential type")
            };

            patch.DataSourceCredentialName = Name;
            patch.DataSourceCredentialDescription = Description;

            return patch;
        }
    }
}
