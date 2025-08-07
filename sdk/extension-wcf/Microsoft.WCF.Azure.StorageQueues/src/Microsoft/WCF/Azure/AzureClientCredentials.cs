// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IdentityModel.Selectors;
using System.ServiceModel.Description;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Queues.Models;

namespace Microsoft.WCF.Azure
{
    /// <summary>
    /// Represents the credentials used to authenticate with Azure services.
    /// </summary>
    public class AzureClientCredentials : ClientCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureClientCredentials"/> class.
        /// </summary>
        public AzureClientCredentials() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureClientCredentials"/> class cloning an existing instance.
        /// </summary>
        /// <param name="other">An existing instance of <see cref="AzureClientCredentials"/> to clone</param>
        protected AzureClientCredentials(AzureClientCredentials other) : base(other)
        {
            Audience = other.Audience;
            EnableTenantDiscovery = other.EnableTenantDiscovery;
            DefaultAzureCredentialOptions = other.DefaultAzureCredentialOptions;
            Sas = other.Sas;
            StorageSharedKey = other.StorageSharedKey;
            Token = other.Token;
            ConnectionString = other.ConnectionString;
        }

        /// <summary>
        /// Gets or sets the audience to use for authentication with Microsoft Entra ID. The audience isn't considered when using a shared key.
        /// </summary>
        public QueueAudience Audience { get; set; }

        /// <summary>
        /// Enables tenant discovery through the authorization challenge when the client is configured to use a TokenCredential.
        /// </summary>
        public bool EnableTenantDiscovery { get; set; }

        /// <summary>
        /// Gets of sets the <see href="https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredentialoptions">Azure.Identity.DefaultAzureCredentialOptions</see> instance used with DefaultAzureCredentials.
        /// </summary>
        public DefaultAzureCredentialOptions DefaultAzureCredentialOptions { get; set; }

        /// <summary>
        /// Gets or sets the <see href="https://learn.microsoft.com/dotnet/api/azure.azuresascredential">Azure.AzureSasCredential</see> (shared access signature) credential.
        /// </summary>
        public AzureSasCredential Sas { get; set; }

        /// <summary>
        /// Gets or sets the <see href="https://learn.microsoft.com/dotnet/api/azure.storage.storagesharedkeycredential">Azure.Storage.StorageSharedKeyCredential</see> credential.
        /// </summary>
        public StorageSharedKeyCredential StorageSharedKey { get; set; }

        /// <summary>
        /// Gets or sets the <see href="https://learn.microsoft.com/dotnet/api/azure.core.tokencredential">Azure.Core.TokenCredential</see> credential.
        /// </summary>
        public TokenCredential Token { get; set; }

        /// <summary>
        /// Gets or sets the connection string containing credentials.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Creates a security token manager for this instance.
        /// </summary>
        /// <returns>A <see cref="AzureClientCredentialsSecurityTokenManager">AzureClientCredentialsSecurityTokenManager</see> for this <see cref="AzureClientCredentials">AzureClientCredentials</see>.</returns>
        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new AzureClientCredentialsSecurityTokenManager(Clone() as AzureClientCredentials);
        }

        /// <summary>
        /// Creates a new copy of this <see cref="AzureClientCredentials">AzureClientCredentials</see> instance.
        /// </summary>
        /// <returns>A <see cref="AzureClientCredentials">AzureClientCredentials</see> instance.</returns>
        protected override ClientCredentials CloneCore()
        {
            // Implement the cloning functionality.
            return new AzureClientCredentials(this);
        }
    }
}
