// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.IO;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Authentication;
    using System.Text;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class PasswordCredentialImpl<T> :
        IndexableRefreshableWrapper<Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential, Models.PasswordCredential>,
        IPasswordCredential,
        IDefinition<T>,
        IUpdateDefinition<T>
    {
        private string name;
        private IHasCredential<T> parent;
        StreamWriter authFile;
        public PasswordCredentialImpl<T> WithPasswordValue(string password)
        {
            Inner.Value = password;
            return this;
        }

        public DateTime EndDate()
        {
            return Inner.EndDate ?? DateTime.MinValue;
        }

        protected override async Task<Models.PasswordCredential> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException("Cannot refresh credentials.");
        }

        public PasswordCredentialImpl<T> WithDuration(TimeSpan duration)
        {
            Inner.EndDate = StartDate().Add(duration);
            return this;
        }

        internal async Task ExportAuthFileAsync(ServicePrincipalImpl servicePrincipal, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (authFile == null)
            {
                return;
            }
            RestClient restClient = servicePrincipal.Manager().restClient;
            AzureEnvironment environment = null;
            if (restClient.Credentials is AzureCredentials)
            {
                environment = ((AzureCredentials)restClient.Credentials).Environment;
            }
            else
            {
                string baseUrl = restClient.BaseUri;
                if (AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureGlobalCloud;
                }
                else if (AzureEnvironment.AzureChinaCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureChinaCloud;
                }
                else if (AzureEnvironment.AzureGermanCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureGermanCloud;
                }
                else if (AzureEnvironment.AzureUSGovernment.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureUSGovernment;
                }
                if (environment == null)
                {
                    throw new NotSupportedException("Unknown resource manager endpoint " + baseUrl);
                }
            }

            try
            {
                await authFile.WriteLineAsync("{");
                await authFile.WriteLineAsync(string.Format("  \"clientId\": \"{0}\",", servicePrincipal.ApplicationId()));
                await authFile.WriteLineAsync(string.Format("  \"clientSecret\": \"{0}\",", Value()));
                await authFile.WriteLineAsync(string.Format("  \"tenantId\": \"{0}\",", servicePrincipal.Manager().tenantId));
                await authFile.WriteLineAsync(string.Format("  \"subscriptionId\": \"{0}\",", servicePrincipal.assignedSubscription));
                await authFile.WriteLineAsync(string.Format("  \"activeDirectoryEndpointUrl\": \"{0}\",", environment.AuthenticationEndpoint));
                await authFile.WriteLineAsync(string.Format("  \"resourceManagerEndpointUrl\": \"{0}\",", environment.ResourceManagerEndpoint));
                await authFile.WriteLineAsync(string.Format("  \"activeDirectoryGraphResourceId\": \"{0}\",", environment.GraphEndpoint));
                await authFile.WriteLineAsync(string.Format("  \"managementEndpointUrl\": \"{0}\"", environment.ManagementEnpoint));
                await authFile.WriteLineAsync("}");
            }
            finally
            {
                authFile.Dispose();
            }
        }

        internal PasswordCredentialImpl(Models.PasswordCredential passwordCredential)
                    : base(!String.IsNullOrEmpty(passwordCredential.CustomKeyIdentifier) ? System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(passwordCredential.CustomKeyIdentifier)) : passwordCredential.KeyId, passwordCredential)
        {
            if (!String.IsNullOrEmpty(passwordCredential.CustomKeyIdentifier))
            {
                name = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(passwordCredential.CustomKeyIdentifier));
            }
            else
            {
                this.name = passwordCredential.KeyId;
            }
        }

        internal PasswordCredentialImpl(string name, IHasCredential<T> parent)
            : base(name, new Models.PasswordCredential()
            {
                CustomKeyIdentifier = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            })
        {
            this.name = name;
            this.parent = parent;
        }

        public PasswordCredentialImpl<T> WithStartDate(DateTime startDate)
        {
            DateTime original = StartDate();
            Inner.StartDate = startDate;
            // Adjust end time
            WithDuration(EndDate().Subtract(original));
            return this;
        }

        public string Name()
        {
            return name;
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException("Cannot refresh credentials.");
        }

        public string Id()
        {
            return Inner.KeyId;
        }

        public T Attach()
        {
            parent.WithPasswordCredential(this);
            return parent as T;
        }

        public string Value()
        {
            return Inner.Value;
        }

        public PasswordCredentialImpl<T> WithAuthFileToExport(StreamWriter outputStream)
        {
            this.authFile = outputStream;
            return this;
        }

        public DateTime StartDate()
        {
            return Inner.StartDate ?? DateTime.MinValue;
        }
    }
}