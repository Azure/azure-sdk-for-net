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

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class PasswordCredentialImpl<T>  :
        IndexableRefreshableWrapper<Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential,Models.PasswordCredential>,
        IPasswordCredential,
        IDefinition<T>,
        IUpdateDefinition<T>
    {
        private string name;
        private IHasCredential<object> parent;
        FileStream authFile;
                public PasswordCredentialImpl<T> WithPasswordValue(string password)
        {
            //$ inner().WithValue(password);
            //$ return this;

            return this;
        }

                public DateTime EndDate()
        {
            //$ return inner().EndDate();

            return DateTime.Now;
        }

                protected override async Task<Models.PasswordCredential> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ throw new UnsupportedOperationException("Cannot refresh credentials.");

            return null;
        }

                public PasswordCredentialImpl<T> WithDuration(DateTimeOffset duration)
        {
            //$ inner().WithEndDate(startDate().PlusDays((int) duration.GetStandardDays()));
            //$ return this;

            return this;
        }

                internal void ExportAuthFile(ServicePrincipalImpl servicePrincipal)
        {
            //$ if (authFile == null) {
            //$ return;
            //$ }
            //$ RestClient restClient = servicePrincipal.Manager().RoleInner().RestClient();
            //$ AzureEnvironment environment = null;
            //$ if (restClient.Credentials() instanceof AzureTokenCredentials) {
            //$ environment = ((AzureTokenCredentials) restClient.Credentials()).Environment();
            //$ } else {
            //$ String baseUrl = restClient.Retrofit().BaseUrl().ToString();
            //$ for (AzureEnvironment env : AzureEnvironment.KnownEnvironments()) {
            //$ if (env.ResourceManagerEndpoint().ToLowerCase().Contains(baseUrl.ToLowerCase())) {
            //$ environment = env;
            //$ }
            //$ }
            //$ if (environment == null) {
            //$ throw new IllegalArgumentException("Unknown resource manager endpoint " + baseUrl);
            //$ }
            //$ }
            //$ 
            //$ StringBuilder builder = new StringBuilder();
            //$ builder.Append(String.Format("client=%s", servicePrincipal.ApplicationId())).Append("\n");
            //$ builder.Append(String.Format("key=%s", value())).Append("\n");
            //$ builder.Append(String.Format("tenant=%s", servicePrincipal.Manager().TenantId())).Append("\n");
            //$ builder.Append(String.Format("subscription=%s", servicePrincipal.AssignedSubscription)).Append("\n");
            //$ builder.Append(String.Format("authURL=%s", normalizeAuthFileUrl(environment.ActiveDirectoryEndpoint()))).Append("\n");
            //$ builder.Append(String.Format("baseURL=%s", normalizeAuthFileUrl(environment.ResourceManagerEndpoint()))).Append("\n");
            //$ builder.Append(String.Format("graphURL=%s", normalizeAuthFileUrl(environment.GraphEndpoint()))).Append("\n");
            //$ builder.Append(String.Format("managementURI=%s", normalizeAuthFileUrl(environment.ManagementEndpoint())));
            //$ try {
            //$ authFile.Write(builder.ToString().GetBytes());
            //$ } catch (IOException e) {
            //$ throw new RuntimeException(e);
            //$ }
            //$ }

        }

                internal  PasswordCredentialImpl(Models.PasswordCredential passwordCredential)
                    : base(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(passwordCredential.CustomKeyIdentifier)), passwordCredential)
        {
            //$ super(passwordCredential);
            //$ this.name = new String(BaseEncoding.Base64().Decode(passwordCredential.CustomKeyIdentifier()));
            //$ }

        }

                internal  PasswordCredentialImpl(string name, IHasCredential<object> parent)
                    : base(name, new Models.PasswordCredential()
                    {
                        CustomKeyIdentifier = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)),
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddYears(1)
                    })
        {
            //$ super(new PasswordCredentialInner()
            //$ .WithCustomKeyIdentifier(BaseEncoding.Base64().Encode(name.GetBytes()))
            //$ .WithStartDate(DateTime.Now())
            //$ .WithEndDate(DateTime.Now().PlusYears(1)));
            //$ this.name = name;
            //$ this.parent = parent;
            //$ }

        }

                private string NormalizeAuthFileUrl(string url)
        {
            //$ if (!url.EndsWith("/")) {
            //$ url = url + "/";
            //$ }
            //$ return url.Replace("://", "\\://");
            //$ }

            return null;
        }

                public PasswordCredentialImpl<T> WithStartDate(DateTime startDate)
        {
            //$ DateTime original = startDate();
            //$ inner().WithStartDate(startDate);
            //$ // Adjust end time
            //$ withDuration(Duration.Millis(endDate().GetMillis() - original.GetMillis()));
            //$ return this;

            return this;
        }

                public string Name()
        {
            //$ return name;

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ throw new UnsupportedOperationException("Cannot refresh credentials.");

            return null;
        }

                public string Id()
        {
            //$ return inner().KeyId();

            return null;
        }

                public T Attach()
        {
            //$ public T attach() {
            //$ parent.WithPasswordCredential(this);
            //$ return (T) parent;

            return default(T);
        }

                public string Value()
        {
            //$ return inner().Value();

            return null;
        }

                public PasswordCredentialImpl<T> WithAuthFileToExport(FileStream outputStream)
        {
            //$ this.authFile = outputStream;
            //$ return this;

            return this;
        }

                public DateTime StartDate()
        {
            //$ return inner().StartDate();

            return DateTime.Now;
        }
    }
}