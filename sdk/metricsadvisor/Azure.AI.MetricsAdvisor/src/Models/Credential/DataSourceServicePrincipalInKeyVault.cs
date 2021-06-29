// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Authenticates to an Azure service via service principal. The client ID and the client secret used for data source
    /// authentication must be stored as secrets in a Key Vault resource, so credentials to access this Key Vault instance
    /// must also be provided.
    /// </summary>
    [CodeGenModel("ServicePrincipalInKVCredential")]
    [CodeGenSuppress(nameof(DataSourceServicePrincipalInKeyVault), typeof(string), typeof(ServicePrincipalInKVParam))]
    public partial class DataSourceServicePrincipalInKeyVault
    {
        private string _keyVaultClientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceServicePrincipalInKeyVault"/> class.
        /// </summary>
        /// <param name="name">A custom unique name for this <see cref="DataSourceServicePrincipalInKeyVault"/> to be displayed on the web portal.</param>
        /// <param name="endpoint">The endpoint to connect to the Key Vault resource where the secrets are stored.</param>
        /// <param name="keyVaultClientId">The client ID to authenticate to the Key Vault resource.</param>
        /// <param name="keyVaultClientSecret">The client secret to authenticate to the Key Vault resource.</param>
        /// <param name="tenantId">The tenant ID of the service principals used for authentication.</param>
        /// <param name="secretNameForClientId">The name of the Key Vault secret storing the client ID used for data source authentication.</param>
        /// <param name="secretNameForClientSecret">The name of the Key Vault secret storing the client secret used for data source authentication.</param>
        public DataSourceServicePrincipalInKeyVault(string name, Uri endpoint, string keyVaultClientId, string keyVaultClientSecret, string tenantId, string secretNameForClientId, string secretNameForClientSecret)
            : base(name)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(keyVaultClientId, nameof(keyVaultClientId));
            Argument.AssertNotNullOrEmpty(keyVaultClientSecret, nameof(keyVaultClientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));
            Argument.AssertNotNullOrEmpty(secretNameForClientId, nameof(secretNameForClientId));
            Argument.AssertNotNullOrEmpty(secretNameForClientSecret, nameof(secretNameForClientSecret));

            DataSourceCredentialType = DataSourceCredentialType.ServicePrincipalInKV;
            Endpoint = endpoint;
            KeyVaultClientId = keyVaultClientId;
            KeyVaultClientSecret = keyVaultClientSecret;
            TenantId = tenantId;
            SecretNameForClientId = secretNameForClientId;
            SecretNameForClientSecret = secretNameForClientSecret;
        }

        internal DataSourceServicePrincipalInKeyVault(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, ServicePrincipalInKVParam parameters)
            : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            Endpoint = new Uri(parameters.KeyVaultEndpoint);
            KeyVaultClientId = parameters.KeyVaultClientId;
            KeyVaultClientSecret = parameters.KeyVaultClientSecret;
            TenantId = parameters.TenantId;
            SecretNameForClientId = parameters.ServicePrincipalIdNameInKV;
            SecretNameForClientSecret = parameters.ServicePrincipalSecretNameInKV;
        }

        /// <summary>
        /// The endpoint to connect to the Key Vault resource where the secrets are stored.
        /// </summary>
        public Uri Endpoint { get; set; }

        /// <summary>
        /// The client ID to authenticate to the Key Vault resource.
        /// </summary>
        public string KeyVaultClientId { get; set; }

        /// <summary>
        /// The tenant ID of the service principals used for authentication.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The name of the Key Vault secret storing the client ID used for data source authentication.
        /// </summary>
        public string SecretNameForClientId { get; set; }

        /// <summary>
        /// The name of the Key Vault secret storing the client secret used for data source authentication.
        /// </summary>
        public string SecretNameForClientSecret { get; set; }

        internal string KeyVaultClientSecret
        {
            get => Volatile.Read(ref _keyVaultClientSecret);
            set => Volatile.Write(ref _keyVaultClientSecret, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal ServicePrincipalInKVParam Parameters => new ServicePrincipalInKVParam(Endpoint.AbsoluteUri, KeyVaultClientId, KeyVaultClientSecret, SecretNameForClientId, SecretNameForClientSecret, TenantId);

        /// <summary>
        /// Updates the client secret used to access the key vault resource.
        /// </summary>
        /// <param name="keyVaultClientSecret">The new client secret.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keyVaultClientSecret"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="keyVaultClientSecret"/> is empty.</exception>
        public void UpdateKeyVaultClientSecret(string keyVaultClientSecret)
        {
            Argument.AssertNotNullOrEmpty(keyVaultClientSecret, nameof(keyVaultClientSecret));
            KeyVaultClientSecret = keyVaultClientSecret;
        }
    }
}
