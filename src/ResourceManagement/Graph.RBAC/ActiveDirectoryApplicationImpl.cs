// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplication.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryApplicationImpl :
        CreatableUpdatable<IActiveDirectoryApplication, ApplicationInner, ActiveDirectoryApplicationImpl, IHasId, IUpdate>,
        IActiveDirectoryApplication,
        IDefinition,
        IUpdate,
        IHasCredential<IWithCreate>,
        IHasCredential<IUpdate>
    {
        private GraphRbacManager manager;
        private ApplicationCreateParametersInner createParameters;
        private ApplicationUpdateParametersInner updateParameters;
        private Dictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> cachedPasswordCredentials;
        private Dictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> cachedCertificateCredentials;

        string IHasId.Id => Inner.ObjectId;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => manager;

        public ActiveDirectoryApplicationImpl WithAvailableToOtherTenants(bool availableToOtherTenants)
        {
            if (IsInCreateMode())
            {
                createParameters.AvailableToOtherTenants = availableToOtherTenants;
            }
            else
            {
                updateParameters.AvailableToOtherTenants = availableToOtherTenants;
            }
            return this;
        }

        public PasswordCredentialImpl<T> DefinePasswordCredential<T>(string name) where T : class
        {
            return new PasswordCredentialImpl<T>(name, (IHasCredential<T>)this);
        }

        public IReadOnlyList<string> ApplicationPermissions()
        {
            if (Inner.AppPermissions == null)
            {
                return null;
            }
            return Inner.AppPermissions.ToList().AsReadOnly();
        }

        internal async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> RefreshCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<KeyCredential> keyCredentials = await manager.Inner.Applications.ListKeyCredentialsAsync(Id(), cancellationToken);
            this.cachedCertificateCredentials = new Dictionary<string, ICertificateCredential>();
            foreach (var cred in keyCredentials)
            {
                ICertificateCredential cert = new CertificateCredentialImpl<IActiveDirectoryApplication>(cred);
                this.cachedCertificateCredentials.Add(cert.Name, cert);
            }

            IEnumerable<Models.PasswordCredential> passwordCredentials = await manager.Inner.Applications.ListPasswordCredentialsAsync(Id(), cancellationToken);
            this.cachedPasswordCredentials = new Dictionary<string, IPasswordCredential>();
            foreach (var cred in passwordCredentials)
            {
                IPasswordCredential cert = new PasswordCredentialImpl<IActiveDirectoryApplication>(cred);
                this.cachedPasswordCredentials.Add(cert.Name, cert);
            }

            return this;
        }

        public ActiveDirectoryApplicationImpl WithIdentifierUrl(string identifierUrl)
        {
            if (IsInCreateMode())
            {
                if (createParameters.IdentifierUris == null)
                {
                    createParameters.IdentifierUris = new List<string>();
                }
                createParameters.IdentifierUris.Add(identifierUrl);
            }
            else
            {
                if (updateParameters.IdentifierUris == null)
                {
                    updateParameters.IdentifierUris = new List<string>(IdentifierUris());
                }
                updateParameters.IdentifierUris.Add(identifierUrl);
            }
            return this;
        }

        internal ActiveDirectoryApplicationImpl(ApplicationInner innerObject, GraphRbacManager manager)
            : base(innerObject.DisplayName, innerObject)
        {
            this.manager = manager;
            this.createParameters = new ApplicationCreateParametersInner
            {
                DisplayName = innerObject.DisplayName
            };
            this.updateParameters = new ApplicationUpdateParametersInner
            {
                DisplayName = innerObject.DisplayName
            };
        }

        public ActiveDirectoryApplicationImpl WithSignOnUrl(string signOnUrl)
        {
            if (IsInCreateMode())
            {
                createParameters.Homepage = signOnUrl;
            }
            else
            {
                updateParameters.Homepage = signOnUrl;
            }
            return WithReplyUrl(signOnUrl);
        }

        public ISet<string> ReplyUrls()
        {
            if (Inner.ReplyUrls == null)
            {
                return null;
            }
            return new System.Collections.Generic.HashSet<string>(Inner.ReplyUrls);
        }

        public IUpdate WithoutIdentifierUrl(string identifierUrl)
        {
            if (updateParameters.IdentifierUris != null)
            {
                updateParameters.IdentifierUris.Remove(identifierUrl);
            }
            return this;
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials()
        {
            if (cachedCertificateCredentials == null)
            {
                return null;
            }
            return new ReadOnlyDictionary<string, ICertificateCredential>(cachedCertificateCredentials);
        }

        protected override async Task<Models.ApplicationInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.Inner.Applications.GetAsync(Id(), cancellationToken);
        }

        public bool AvailableToOtherTenants()
        {
            return Inner.AvailableToOtherTenants ?? false;
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials()
        {
            if (cachedPasswordCredentials == null)
            {
                return null;
            }
            return new ReadOnlyDictionary<string, IPasswordCredential>(cachedPasswordCredentials);
        }

        public ActiveDirectoryApplicationImpl WithPasswordCredential<T>(PasswordCredentialImpl<T> credential) where T : class
        {
            if (IsInCreateMode())
            {
                if (createParameters.PasswordCredentials == null)
                {
                    createParameters.PasswordCredentials = new List<Models.PasswordCredential>();
                }
                createParameters.PasswordCredentials.Add(credential.Inner);
            }
            else
            {
                if (updateParameters.PasswordCredentials == null)
                {
                    updateParameters.PasswordCredentials = new List<Models.PasswordCredential>();
                }
                updateParameters.PasswordCredentials.Add(credential.Inner);
            }
            return this;
        }

        public ISet<string> IdentifierUris()
        {
            if (Inner.IdentifierUris == null)
            {
                return null;
            }
            return new HashSet<string>(Inner.IdentifierUris);
        }

        public string Id()
        {
            return Inner.ObjectId;
        }

        public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode())
            {
                if (createParameters.IdentifierUris == null)
                {
                    createParameters.IdentifierUris = new List<string>();
                    createParameters.IdentifierUris.Add(createParameters.Homepage);
                }
                SetInner(await manager.Inner.Applications.CreateAsync(createParameters, cancellationToken));
                return await RefreshCredentialsAsync(cancellationToken);
            }
            else
            {
                await manager.Inner.Applications.PatchAsync(Id(), updateParameters, cancellationToken);
                return await RefreshAsync(cancellationToken);
            }
        }

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public bool IsInCreateMode()
        {
            return Id() == null;
        }

        public CertificateCredentialImpl<T> DefineCertificateCredential<T>(string name) where T : class
        {
            return new CertificateCredentialImpl<T>(name, (IHasCredential<T>)this);
        }

        public ActiveDirectoryApplicationImpl WithCertificateCredential<T>(CertificateCredentialImpl<T> credential) where T : class
        {
            if (IsInCreateMode())
            {
                if (createParameters.KeyCredentials == null)
                {
                    createParameters.KeyCredentials = new List<KeyCredential>();
                }
                createParameters.KeyCredentials.Add(credential.Inner);
            }
            else
            {
                if (updateParameters.KeyCredentials == null)
                {
                    updateParameters.KeyCredentials = new List<KeyCredential>();
                }
                updateParameters.KeyCredentials.Add(credential.Inner);
            }
            return this;
        }

        public Uri SignOnUrl()
        {
            try
            {
                return new Uri(Inner.Homepage);
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        public ActiveDirectoryApplicationImpl WithoutReplyUrl(string replyUrl)
        {
            if (updateParameters.ReplyUrls != null)
            {
                updateParameters.ReplyUrls.Remove(replyUrl);
            }
            return this;
        }

        public ActiveDirectoryApplicationImpl WithoutCredential(string name)
        {
            if (cachedPasswordCredentials.ContainsKey(name))
            {
                cachedPasswordCredentials.Remove(name);
                updateParameters.PasswordCredentials = cachedPasswordCredentials.Values.Select(pc => pc.Inner).ToList();
            }
            else if (cachedCertificateCredentials.ContainsKey(name))
            {
                cachedCertificateCredentials.Remove(name);
                updateParameters.KeyCredentials = cachedCertificateCredentials.Values.Select(pc => pc.Inner).ToList();
            }
            return this;
        }

        public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await GetInnerAsync(cancellationToken));
            return await RefreshCredentialsAsync(cancellationToken);
        }

        public string ApplicationId()
        {
            return Inner.AppId;
        }

        public ActiveDirectoryApplicationImpl WithReplyUrl(string replyUrl)
        {
            if (IsInCreateMode())
            {
                if (createParameters.ReplyUrls == null)
                {
                    createParameters.ReplyUrls = new List<string>();
                }
                createParameters.ReplyUrls.Add(replyUrl);
            }
            else
            {
                if (updateParameters.ReplyUrls == null)
                {
                    updateParameters.ReplyUrls = new List<string>(ReplyUrls());
                }
                updateParameters.ReplyUrls.Add(replyUrl);
            }
            return this;
        }
    }
}