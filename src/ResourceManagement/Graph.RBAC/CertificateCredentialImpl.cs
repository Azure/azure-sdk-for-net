// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredential.UpdateDefinition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.IO;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Authentication;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class CertificateCredentialImpl<T> :
        IndexableRefreshableWrapper<Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential, Models.KeyCredential>,
        ICertificateCredential,
        IDefinition<T>,
        IUpdateDefinition<T>
    {
        private string name;
        private IHasCredential<T> parent;
        private StreamWriter authFile;
        private string privateKeyPath;
        private string privateKeyPassword;
        public CertificateCredentialImpl<T> WithSymmetricEncryption()
        {
            Inner.Type = CertificateType.Symmetric.Value;
            return this;
        }

        public CertificateCredentialImpl<T> WithAsymmetricX509Certificate()
        {
            Inner.Type = CertificateType.AsymmetricX509Cert.Value;
            return this;
        }

        public DateTime EndDate()
        {
            return Inner.EndDate ?? DateTime.MinValue;
        }

        public CertificateCredentialImpl<T> WithPrivateKeyPassword(string privateKeyPassword)
        {
            this.privateKeyPassword = privateKeyPassword;
            return this;
        }

        protected override async Task<Models.KeyCredential> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException("Cannot refresh credentials.");
        }

        public CertificateCredentialImpl<T> WithDuration(TimeSpan duration)
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
                await authFile.WriteLineAsync(string.Format("  \"clientCertificate\": \"{0}\",", NormalizeAuthFilePath(privateKeyPath)));
                await authFile.WriteLineAsync(string.Format("  \"clientCertificatePassword\": \"{0}\",", privateKeyPassword));
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

        public CertificateCredentialImpl<T> WithSecretKey(byte[] secret)
        {
            Inner.Value = System.Convert.ToBase64String(secret);
            return this;
        }

        internal CertificateCredentialImpl(KeyCredential keyCredential)
            : base(!String.IsNullOrEmpty(keyCredential.CustomKeyIdentifier) ? System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(keyCredential.CustomKeyIdentifier)) : keyCredential.KeyId, keyCredential)
        {
            if (!String.IsNullOrEmpty(keyCredential.CustomKeyIdentifier))
            {
                this.name = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(keyCredential.CustomKeyIdentifier));
            }
            else
            {
                this.name = keyCredential.KeyId;
            }
        }

        internal CertificateCredentialImpl(string name, IHasCredential<T> parent)
            : base(name, new KeyCredential()
            {
                Usage = "Verify",
                CustomKeyIdentifier = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            })
        {
            this.name = name;
            this.parent = parent;

        }

        private string NormalizeAuthFileUrl(string url)
        {
            if (!url.EndsWith("/"))
            {
                url = url + "/";
            }
            return url.Replace("\\", "\\\\").Replace("://", "\\://");
        }

        private string NormalizeAuthFilePath(string path)
        {
            return path.Replace("\\", "\\\\");
        }

        public CertificateCredentialImpl<T> WithPrivateKeyFile(string privateKeyPath)
        {
            this.privateKeyPath = Path.GetFullPath(privateKeyPath).ToString();
            return this;
        }

        public CertificateCredentialImpl<T> WithStartDate(DateTime startDate)
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

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException("Cannot refresh credentials.");
        }

        public string Id()
        {
            return Inner.KeyId;
        }

        public T Attach()
        {
            parent.WithCertificateCredential(this);
            return (T)parent;
        }

        public CertificateCredentialImpl<T> WithPublicKey(byte[] certificate)
        {
            Inner.Value = System.Convert.ToBase64String(certificate);
            return this;
        }

        public string Value()
        {
            return Inner.Value;
        }

        public CertificateCredentialImpl<T> WithAuthFileToExport(StreamWriter outputStream)
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