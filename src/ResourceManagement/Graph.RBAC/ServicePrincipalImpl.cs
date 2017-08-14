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
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalImpl :
        CreatableUpdatable<IServicePrincipal, ServicePrincipalInner, ServicePrincipalImpl, IHasId, ServicePrincipal.Update.IUpdate>,
        IServicePrincipal,
        IDefinition,
        IUpdate,
        IHasCredential<IWithCreate>,
        IHasCredential<IUpdate>
    {
        private GraphRbacManager manager;

        private Dictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> cachedPasswordCredentials;
        private Dictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> cachedCertificateCredentials;
        private Dictionary<string, IRoleAssignment> cachedRoleAssignments;

        private ServicePrincipalCreateParametersInner createParameters;
        private ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable;
        private Dictionary<string, BuiltInRole> rolesToCreate;
        private ISet<string> rolesToDelete;

        internal string assignedSubscription;
        private IList<ICertificateCredential> certificateCredentialsToCreate;
        private IList<IPasswordCredential> passwordCredentialsToCreate;
        private ISet<string> certificateCredentialsToDelete;
        private ISet<string> passwordCredentialsToDelete;

        string IHasId.Id => Inner.ObjectId;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => throw new NotImplementedException();

        public PasswordCredentialImpl<T> DefinePasswordCredential<T>(string name) where T : class
        {
            return new PasswordCredentialImpl<T>(name, (IHasCredential<T>)this);
        }

        internal async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> RefreshCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<KeyCredential> keyCredentials = await manager.Inner.ServicePrincipals.ListKeyCredentialsAsync(Id(), cancellationToken);
            this.cachedCertificateCredentials = new Dictionary<string, ICertificateCredential>();
            if (keyCredentials != null)
            {
                foreach (var cred in keyCredentials)
                {
                    ICertificateCredential cert = new CertificateCredentialImpl<IServicePrincipal>(cred);
                    this.cachedCertificateCredentials.Add(cert.Name, cert);
                }
            }

            IEnumerable<Models.PasswordCredential> passwordCredentials = await manager.Inner.ServicePrincipals.ListPasswordCredentialsAsync(Id(), cancellationToken);
            this.cachedPasswordCredentials = new Dictionary<string, IPasswordCredential>();
            if (passwordCredentials != null)
            {
                foreach (var cred in passwordCredentials)
                {
                    IPasswordCredential cert = new PasswordCredentialImpl<IServicePrincipal>(cred);
                    this.cachedPasswordCredentials.Add(cert.Name, cert);
                }
            }

            return this;
        }

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public bool IsInCreateMode()
        {
            return Id() == null;
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

        public ServicePrincipalImpl WithoutRole(IRoleAssignment roleAssignment)
        {
            this.rolesToDelete.Add(roleAssignment.Id);
            return this;
        }

        public CertificateCredentialImpl<T> DefineCertificateCredential<T>(string name) where T : class
        {
            return new CertificateCredentialImpl<T>(name, (IHasCredential<T>)this);
        }

        public ServicePrincipalImpl WithoutCredential(string name)
        {
            if (cachedPasswordCredentials.ContainsKey(name))
            {
                passwordCredentialsToDelete.Add(name);
            }
            else if (cachedCertificateCredentials.ContainsKey(name))
            {
                certificateCredentialsToDelete.Add(name);
            }
            return this;
        }

        public ServicePrincipalImpl WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable)
        {
            AddCreatableDependency(applicationCreatable as IResourceCreator<IHasId>);
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
            this.cachedRoleAssignments = new Dictionary<string, IRoleAssignment>();
            this.rolesToCreate = new Dictionary<string, BuiltInRole>();
            this.rolesToDelete = new HashSet<string>();
            this.cachedCertificateCredentials = new Dictionary<string, ICertificateCredential>();
            this.cachedPasswordCredentials = new Dictionary<string, IPasswordCredential>();
            this.certificateCredentialsToCreate = new List<ICertificateCredential>();
            this.passwordCredentialsToCreate = new List<IPasswordCredential>();
            this.certificateCredentialsToDelete = new HashSet<string>();
            this.passwordCredentialsToDelete = new HashSet<string>();
        }

        public ServicePrincipalImpl WithCertificateCredential<T>(CertificateCredentialImpl<T> credential) where T : class
        {
            this.certificateCredentialsToCreate.Add(credential);
            return this;
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials()
        {
            return new ReadOnlyDictionary<string, ICertificateCredential>(cachedCertificateCredentials);
        }

        protected override async Task<Models.ServicePrincipalInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.Inner.ServicePrincipals.GetAsync(Id(), cancellationToken);
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials()
        {
            return new ReadOnlyDictionary<string, IPasswordCredential>(cachedPasswordCredentials);
        }

        public ServicePrincipalImpl WithNewRole(BuiltInRole role, string scope)
        {
            this.rolesToCreate.Add(scope, role);
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

        public ServicePrincipalImpl WithPasswordCredential<T>(PasswordCredentialImpl<T> credential) where T : class
        {
            this.passwordCredentialsToCreate.Add(credential);
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

        public ISet<IRoleAssignment> RoleAssignments()
        {
            return new HashSet<IRoleAssignment>(cachedRoleAssignments.Values.ToArray());
        }

        public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode())
            {
                if (applicationCreatable != null)
                {
                    IActiveDirectoryApplication application = (IActiveDirectoryApplication)base.CreatedResource(applicationCreatable.Key);
                    createParameters.AppId = application.ApplicationId;
                }
                ServicePrincipalInner inner = await manager.Inner.ServicePrincipals.CreateAsync(createParameters, cancellationToken);
                SetInner(inner);
            }

            Task.WaitAll(
                SubmitCredentialsAsync(this, cancellationToken),
                SubmitRolesAsync(this, cancellationToken));

            foreach (IPasswordCredential password in passwordCredentialsToCreate)
            {
                if (password is PasswordCredentialImpl<IWithCreate>)
                {
                    await ((PasswordCredentialImpl<IWithCreate>)password).ExportAuthFileAsync(this, cancellationToken);
                }
                else
                {
                    await ((PasswordCredentialImpl<IUpdate>)password).ExportAuthFileAsync(this, cancellationToken);
                }
            }
            foreach (ICertificateCredential certificate in certificateCredentialsToCreate)
            {
                if (certificate is CertificateCredentialImpl<IWithCreate>)
                {
                    await ((CertificateCredentialImpl<IWithCreate>)certificate).ExportAuthFileAsync(this, cancellationToken);
                }
                else
                {
                    await ((CertificateCredentialImpl<IUpdate>)certificate).ExportAuthFileAsync(this, cancellationToken);
                }
            }
            passwordCredentialsToCreate.Clear();
            certificateCredentialsToCreate.Clear();

            return await RefreshCredentialsAsync(cancellationToken);
        }

        private async Task<IServicePrincipal> SubmitCredentialsAsync(IServicePrincipal sp, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (certificateCredentialsToCreate.Count == 0 && certificateCredentialsToDelete.Count == 0 &&
                passwordCredentialsToCreate.Count == 0 && passwordCredentialsToDelete.Count == 0)
            {
                return sp;
            }

            if (certificateCredentialsToCreate.Count > 0 || certificateCredentialsToDelete.Count > 0)
            {
                var newCerts = new Dictionary<string, ICertificateCredential>(cachedCertificateCredentials);
                foreach (string delete in certificateCredentialsToDelete)
                {
                    newCerts.Remove(delete);
                }
                foreach (ICertificateCredential create in certificateCredentialsToCreate)
                {
                    newCerts.Add(create.Name, create);
                }
                await Manager().Inner.ServicePrincipals.UpdateKeyCredentialsAsync(
                    sp.Id,
                    new KeyCredentialsUpdateParametersInner
                    {
                        Value = newCerts.Values.Select(c => c.Inner).ToList()
                    },
                    cancellationToken);
            }
            if (passwordCredentialsToCreate.Count > 0 || passwordCredentialsToDelete.Count > 0)
            {
                var newPasses = new Dictionary<string, IPasswordCredential>(cachedPasswordCredentials);
                foreach (string delete in passwordCredentialsToDelete)
                {
                    newPasses.Remove(delete);
                }
                foreach (IPasswordCredential create in passwordCredentialsToCreate)
                {
                    newPasses.Add(create.Name, create);
                }
                await Manager().Inner.ServicePrincipals.UpdatePasswordCredentialsAsync(
                    sp.Id,
                    new PasswordCredentialsUpdateParametersInner
                    {
                        Value = newPasses.Values.Select(c => c.Inner).ToList()
                    },
                    cancellationToken);
            }

            passwordCredentialsToDelete.Clear();
            certificateCredentialsToDelete.Clear();
            return await RefreshAsync(cancellationToken);
        }

        private async Task<IServicePrincipal> SubmitRolesAsync(IServicePrincipal sp, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Delete
            if (rolesToDelete.Count > 0)
            {
                foreach (string roleId in rolesToDelete)
                {
                    await Manager().RoleAssignments.DeleteByIdAsync(roleId);
                    cachedRoleAssignments.Remove(roleId);
                }
                rolesToDelete.Clear();
            }

            // Create
            if (rolesToCreate.Count > 0)
            {
                foreach (KeyValuePair<string, BuiltInRole> role in rolesToCreate)
                {
                    int limit = 30;
                    while (true)
                    {
                        try
                        {
                            IRoleAssignment roleAssignment = await manager.RoleAssignments.Define(SdkContext.RandomGuid())
                                .ForServicePrincipal(sp)
                                .WithBuiltInRole(role.Value)
                                .WithScope(role.Key)
                                .CreateAsync(cancellationToken);
                            cachedRoleAssignments.Add(roleAssignment.Id, roleAssignment);
                            break;
                        }
                        catch (CloudException e)
                        {
                            if (--limit < 0)
                            {
                                throw e;
                            }
                            else if (e.Body != null && "PrincipalNotFound".Equals(e.Body.Code, StringComparison.OrdinalIgnoreCase))
                            {
                                await SdkContext.DelayProvider.DelayAsync((30 - limit) * 1000, cancellationToken);
                            }
                            else
                            {
                                throw e;
                            }
                        }
                    }

                }
                rolesToCreate.Clear();
            }

            return sp;
        }
    }
}