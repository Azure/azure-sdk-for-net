// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("ServicePrincipalInKVCredential")]
    [CodeGenSuppress(nameof(ServicePrincipalInKeyVaultDatasourceCredential), typeof(string), typeof(ServicePrincipalInKVParam))]
    public partial class ServicePrincipalInKeyVaultDatasourceCredential
    {
        private string _keyVaultClientSecret;

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="endpoint"></param>
        /// <param name="keyVaultClientId"></param>
        /// <param name="keyVaultClientSecret"></param>
        /// <param name="tenantId"></param>
        /// <param name="secretNameForClientId"></param>
        /// <param name="secretNameForClientSecret"></param>
        public ServicePrincipalInKeyVaultDatasourceCredential(string name, Uri endpoint, string keyVaultClientId, string keyVaultClientSecret, string tenantId, string secretNameForClientId, string secretNameForClientSecret) : base(name)
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

        internal ServicePrincipalInKeyVaultDatasourceCredential(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, ServicePrincipalInKVParam parameters) : base(dataSourceCredentialType, id, name, description)
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
        /// </summary>
        public Uri Endpoint { get; set; }

        /// <summary>
        /// </summary>
        public string KeyVaultClientId { get; set; }

        /// <summary>
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// </summary>
        public string SecretNameForClientId { get; set; }

        /// <summary>
        /// </summary>
        public string SecretNameForClientSecret { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="keyVaultClientSecret"></param>
        public void UpdateKeyVaultClientSecret(string keyVaultClientSecret)
        {
            Argument.AssertNotNullOrEmpty(keyVaultClientSecret, nameof(keyVaultClientSecret));
            KeyVaultClientSecret = keyVaultClientSecret;
        }

        internal string KeyVaultClientSecret
        {
            get => Volatile.Read(ref _keyVaultClientSecret);
            set => Volatile.Write(ref _keyVaultClientSecret, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal ServicePrincipalInKVParam Parameters => new ServicePrincipalInKVParam(Endpoint.AbsoluteUri, KeyVaultClientId, SecretNameForClientId, SecretNameForClientSecret, TenantId);
    }
}
