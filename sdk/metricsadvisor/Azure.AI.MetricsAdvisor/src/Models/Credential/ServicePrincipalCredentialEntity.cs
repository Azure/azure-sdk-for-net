// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Authenticates to an Azure service via service principal.
    /// </summary>
    /// <remarks>
    /// In order to create a credential entity, you must pass this instance to the method
    /// <see cref="MetricsAdvisorAdministrationClient.CreateDataSourceCredentialAsync"/>.
    /// </remarks>
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
        /// <param name="clientSecret">The client secret of the service principal used for authentication.</param>
        /// <param name="tenantId">The tenant ID of the service principal used for authentication.</param>
        public ServicePrincipalCredentialEntity(string name, string clientId, string clientSecret, string tenantId)
            : base(name)
        {
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));

            CredentialKind = DataSourceCredentialKind.ServicePrincipal;
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        internal ServicePrincipalCredentialEntity(DataSourceCredentialKind dataSourceCredentialType, string id, string name, string description, ServicePrincipalParam parameters)
            : base(dataSourceCredentialType, id, name, description)
        {
            CredentialKind = dataSourceCredentialType;
            ClientId = parameters.ClientId;
            ClientSecret = parameters.ClientSecret;
            TenantId = parameters.TenantId;
        }

        /// <summary>
        /// The client ID of the service principal used for authentication.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The tenant ID of the service principal used for authentication.
        /// </summary>
        public string TenantId { get; set; }

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

        /// <summary>
        /// Updates the client secret.
        /// </summary>
        /// <param name="clientSecret">The client secret of the service principal used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="clientSecret"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="clientSecret"/> is empty.</exception>
        public void UpdateClientSecret(string clientSecret)
        {
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            ClientSecret = clientSecret;
        }
    }
}
