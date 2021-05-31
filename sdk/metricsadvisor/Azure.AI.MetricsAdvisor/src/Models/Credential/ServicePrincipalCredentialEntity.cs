// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Authenticates to an Azure service via service principal.
    /// </summary>
    [CodeGenModel("ServicePrincipalCredential")]
    [CodeGenSuppress(nameof(ServicePrincipalCredentialEntity), typeof(string), typeof(ServicePrincipalParam))]
    public partial class ServicePrincipalCredentialEntity
    {
        private string _clientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePrincipalCredentialEntity"/> class.
        /// </summary>
        /// <param name="name">A custom unique name for this <see cref="ServicePrincipalCredentialEntity"/> to be displayed on the web portal.</param>
        /// <param name="clientId">The client ID of the service principal used for authentication.</param>
        /// <param name="clientSecret">The client Secret of the service principal used for authentication.</param>
        /// <param name="tenantId">The tenant ID of the service principal used for authentication.</param>
        public ServicePrincipalCredentialEntity(string name, string clientId, string clientSecret, string tenantId) : base(name)
        {
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));

            DataSourceCredentialType = DataSourceCredentialType.ServicePrincipal;
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        internal ServicePrincipalCredentialEntity(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, ServicePrincipalParam parameters) : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            ClientId = parameters.ClientId;
            ClientSecret = parameters.ClientSecret;
            TenantId = parameters.TenantId;
        }

        /// <summary>
        /// The client ID of the service principal used for authentication.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// The tenant ID of the service principal used for authentication.
        /// </summary>
        public string TenantId { get; }

        /// <summary>
        /// The client Secret of the service principal used for authentication.
        /// </summary>
        internal string ClientSecret
        {
            get => Volatile.Read(ref _clientSecret);
            set => Volatile.Write(ref _clientSecret, value);
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal ServicePrincipalParam Parameters => new ServicePrincipalParam(ClientId, ClientSecret, TenantId);
    }
}
