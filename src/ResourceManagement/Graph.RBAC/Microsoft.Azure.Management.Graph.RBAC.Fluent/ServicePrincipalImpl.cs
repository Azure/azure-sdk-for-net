// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System;
    using Rest.Azure;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalImpl  :
        Creatable<IServicePrincipal,ServicePrincipalInner,ServicePrincipalImpl,IServicePrincipal>,
        IServicePrincipal,
        IDefinition,
        IHasCredential<IWithCreate>
    {
        private GraphRbacManager manager;
        private ServicePrincipalCreateParametersInner createParameters;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> cachedPasswordCredentials;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> cachedCertificateCredentials;
        private ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable;
        private Dictionary<string,BuiltInRole> roles;
        internal string assignedSubscription;
        private IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredentialImpl<IWithCreate>> certificateCredentials;
        private IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredentialImpl<IWithCreate>> passwordCredentials;
                public PasswordCredentialImpl<ServicePrincipal.Definition.IWithCreate> DefinePasswordCredential(string name)
        {
            return new PasswordCredentialImpl<IWithCreate>(name, this);
        }

                internal async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> RefreshCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<KeyCredential> keyCredentials = await manager.Inner.ServicePrincipals.ListKeyCredentialsAsync(Id(), cancellationToken);
            this.cachedCertificateCredentials = new Dictionary<string, ICertificateCredential>();
            foreach (var cred in keyCredentials)
            {
                ICertificateCredential cert = new CertificateCredentialImpl<IServicePrincipal>(cred);
                this.cachedCertificateCredentials.Add(cert.Name, cert);
            }

            IEnumerable<Models.PasswordCredential> passwordCredentials = await manager.Inner.ServicePrincipals.ListPasswordCredentialsAsync(Id(), cancellationToken);
            this.cachedPasswordCredentials = new Dictionary<string, IPasswordCredential>();
            foreach (var cred in passwordCredentials)
            {
                IPasswordCredential cert = new PasswordCredentialImpl<IServicePrincipal>(cred);
                this.cachedPasswordCredentials.Add(cert.Name, cert);
            }

            return this;
        }

                public GraphRbacManager Manager()
        {
            return manager;
        }

                public bool IsInCreateMode()
        {
            return true;
        }

                public ServicePrincipalImpl WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup)
        {
            return WithNewRole(role, resourceGroup.Id);
        }

                public ServicePrincipalImpl WithNewRoleInSubscription(BuiltInRole role, string subscriptionId)
        {
            this.assignedSubscription = subscriptionId;
            return WithNewRole(role, "subscriptions/" + subscriptionId);
        }

                public CertificateCredentialImpl<ServicePrincipal.Definition.IWithCreate> DefineCertificateCredential(string name)
        {
            return new CertificateCredentialImpl<IWithCreate>(name, this);
        }

                public ServicePrincipalImpl WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable)
        {
            AddCreatableDependency(applicationCreatable as IResourceCreator<IServicePrincipal>);
            this.applicationCreatable = applicationCreatable;
            return this;
        }

                public ServicePrincipalImpl WithNewApplication(string signOnUrl)
        {
            return WithNewApplication(manager.Applications.Define(signOnUrl)
                    .WithSignOnUrl(signOnUrl)
                    .WithIdentifierUrl(signOnUrl));
        }

        internal ServicePrincipalImpl(ServicePrincipalInner innerObject, GraphRbacManager manager)
            : base(innerObject.DisplayName, innerObject)
        {
            this.manager = manager;
            this.createParameters = new ServicePrincipalCreateParametersInner
            {
                AccountEnabled = true
            };
            this.roles = new Dictionary<string, BuiltInRole>();
            this.certificateCredentials = new List<CertificateCredentialImpl<IWithCreate>>();
            this.passwordCredentials = new List<PasswordCredentialImpl<IWithCreate>>();
        }

                public ServicePrincipalImpl WithCertificateCredential(CertificateCredentialImpl<IWithCreate> credential)
        {
            if (createParameters.KeyCredentials == null)
            {
                createParameters.KeyCredentials = new List<KeyCredential>();
            }
            createParameters.KeyCredentials.Add(credential.Inner);
            this.certificateCredentials.Add(credential);
            return this;
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials()
        {
            if (cachedCertificateCredentials == null)
            {
                return null;
            }
            return new ReadOnlyDictionary<string, ICertificateCredential>(cachedCertificateCredentials);
        }

                protected override async Task<Models.ServicePrincipalInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.Inner.ServicePrincipals.GetAsync(Id(), cancellationToken);
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials()
        {
            if (cachedPasswordCredentials == null)
            {
                return null;
            }
            return new ReadOnlyDictionary<string, IPasswordCredential>(cachedPasswordCredentials);
        }

                public ServicePrincipalImpl WithNewRole(BuiltInRole role, string scope)
        {
            this.roles.Add(scope, role);
            return this;
        }

                public ServicePrincipalImpl WithExistingApplication(string id)
        {
            createParameters.AppId = id;
            return this;
        }

                public ServicePrincipalImpl WithExistingApplication(IActiveDirectoryApplication application)
        {
            createParameters.AppId = application.ApplicationId;
            return this;
        }

                public IReadOnlyList<string> ServicePrincipalNames()
        {
            return Inner.ServicePrincipalNames.ToList().AsReadOnly();
        }

                public ServicePrincipalImpl WithPasswordCredential(PasswordCredentialImpl<IWithCreate> credential)
        {
            if (createParameters.PasswordCredentials == null)
            {
                createParameters.PasswordCredentials = new List<Models.PasswordCredential>();
            }
            createParameters.PasswordCredentials.Add(credential.Inner);
            this.passwordCredentials.Add(credential);
            return this;
        }

                public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await GetInnerAsync(cancellationToken));
            return await RefreshCredentialsAsync(cancellationToken);
        }

                public string Id()
        {
            return Inner.ObjectId;
        }

                public string ApplicationId()
        {
            return Inner.AppId;
        }

                public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (applicationCreatable != null)
            {
                IActiveDirectoryApplication application = (IActiveDirectoryApplication)base.CreatedResource(applicationCreatable.Key);
                createParameters.AppId = application.ApplicationId;
            }
            ServicePrincipalInner inner = await manager.Inner.ServicePrincipals.CreateAsync(createParameters, cancellationToken);
            SetInner(inner);
            IServicePrincipal sp = await RefreshCredentialsAsync(cancellationToken);

            if (roles == null || !roles.Any())
            {
                return sp;
            }

            foreach (KeyValuePair<string, BuiltInRole> role in roles)
            {
                int limit = 30;
                while (true)
                {
                    try
                    {
                        IRoleAssignment roleAssignment = await manager.RoleAssignments.Define(Guid.NewGuid().ToString())
                            .ForServicePrincipal(sp)
                            .WithBuiltInRole(role.Value)
                            .WithScope(role.Key)
                            .CreateAsync(cancellationToken);
                    }
                    catch (CloudException e)
                    {
                        if (--limit < 0)
                        {
                            throw e;
                        }
                        if (e.Body != null && "PrincipalNotFound".Equals(e.Body.Code, StringComparison.OrdinalIgnoreCase))
                        {
                            await SdkContext.DelayProvider.DelayAsync((30 - limit) * 1000, cancellationToken);
                        }
                    }
                }
            }

            foreach (PasswordCredentialImpl<IWithCreate> password in passwordCredentials)
            {
                await password.ExportAuthFileAsync(this, cancellationToken);
            }
            foreach (CertificateCredentialImpl<IWithCreate> certificate in certificateCredentials)
            {
                await certificate.ExportAuthFileAsync(this, cancellationToken);
            }

            return this;
        }
    }
}