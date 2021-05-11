// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// TODO.
    /// </summary>
    [CodeGenModel("ServicePrincipalCredential")]
    [CodeGenSuppress(nameof(ServicePrincipalCredentialIdentity), typeof(string), typeof(ServicePrincipalParam))]
    public partial class ServicePrincipalCredentialIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePrincipalCredentialIdentity"/> class.
        /// </summary>
        /// <param name="name">TODO.</param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="tenantId"></param>
        public ServicePrincipalCredentialIdentity(string name, string clientId, string clientSecret, string tenantId) : base(name)
        {
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));

            DataSourceCredentialType = DataSourceCredentialType.ServicePrincipal;
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        internal ServicePrincipalCredentialIdentity(DataSourceCredentialType dataSourceCredentialType, string id, string name, string description, ServicePrincipalParam parameters) : base(dataSourceCredentialType, id, name, description)
        {
            DataSourceCredentialType = dataSourceCredentialType;
            ClientId = parameters.ClientId; // Can these be null?
            ClientSecret = parameters.ClientSecret;
            TenantId = parameters.TenantId;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        public string TenantId { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal ServicePrincipalParam Parameters => new ServicePrincipalParam(ClientId, ClientSecret, TenantId);
    }
}
