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
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryApplicationImpl  :
        CreatableUpdatable<IActiveDirectoryApplication,ApplicationInner,ActiveDirectoryApplicationImpl,IActiveDirectoryApplication,IUpdate>,
        IActiveDirectoryApplication,
        IDefinition,
        IUpdate,
        IHasCredential<Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl>
    {
        private GraphRbacManager manager;
        private ApplicationCreateParametersInner createParameters;
        private ApplicationUpdateParametersInner updateParameters;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> cachedPasswordCredentials;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> cachedCertificateCredentials;
                public ActiveDirectoryApplicationImpl WithAvailableToOtherTenants(bool availableToOtherTenants)
        {
            //$ if (isInCreateMode()) {
            //$ createParameters.WithAvailableToOtherTenants(availableToOtherTenants);
            //$ } else {
            //$ updateParameters.WithAvailableToOtherTenants(availableToOtherTenants);
            //$ }
            //$ return this;

            return this;
        }

                public PasswordCredentialImpl<T> DefinePasswordCredential<T>(string name) where T : class
        {
            //$ public PasswordCredentialImpl definePasswordCredential(String name) {
            //$ return new PasswordCredentialImpl<>(name, this);

            return null;
        }

                public IReadOnlyList<string> ApplicationPermissions()
        {
            //$ if (inner().AppPermissions() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableList(inner().AppPermissions());

            return null;
        }

                internal async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> RefreshCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<ActiveDirectoryApplication> keyCredentials = manager.Inner().Applications().ListKeyCredentialsAsync(id())
            //$ .FlatMapIterable(new Func1<List<KeyCredentialInner>, Iterable<KeyCredentialInner>>() {
            //$ @Override
            //$ public Iterable<KeyCredentialInner> call(List<KeyCredentialInner> keyCredentialInners) {
            //$ return keyCredentialInners;
            //$ }
            //$ })
            //$ .Map(new Func1<KeyCredentialInner, CertificateCredential>() {
            //$ @Override
            //$ public CertificateCredential call(KeyCredentialInner keyCredentialInner) {
            //$ return new CertificateCredentialImpl<ActiveDirectoryApplication>(keyCredentialInner);
            //$ }
            //$ })
            //$ .ToMap(new Func1<CertificateCredential, String>() {
            //$ @Override
            //$ public String call(CertificateCredential certificateCredential) {
            //$ return certificateCredential.Name();
            //$ }
            //$ }).Map(new Func1<Map<String, CertificateCredential>, ActiveDirectoryApplication>() {
            //$ @Override
            //$ public ActiveDirectoryApplication call(Map<String, CertificateCredential> stringCertificateCredentialMap) {
            //$ ActiveDirectoryApplicationImpl.This.cachedCertificateCredentials = stringCertificateCredentialMap;
            //$ return ActiveDirectoryApplicationImpl.This;
            //$ }
            //$ });
            //$ Observable<ActiveDirectoryApplication> passwordCredentials = manager.Inner().Applications().ListPasswordCredentialsAsync(id())
            //$ .FlatMapIterable(new Func1<List<PasswordCredentialInner>, Iterable<PasswordCredentialInner>>() {
            //$ @Override
            //$ public Iterable<PasswordCredentialInner> call(List<PasswordCredentialInner> passwordCredentialInners) {
            //$ return passwordCredentialInners;
            //$ }
            //$ })
            //$ .Map(new Func1<PasswordCredentialInner, PasswordCredential>() {
            //$ @Override
            //$ public PasswordCredential call(PasswordCredentialInner passwordCredentialInner) {
            //$ return new PasswordCredentialImpl<ActiveDirectoryApplication>(passwordCredentialInner);
            //$ }
            //$ })
            //$ .ToMap(new Func1<PasswordCredential, String>() {
            //$ @Override
            //$ public String call(PasswordCredential passwordCredential) {
            //$ return passwordCredential.Name();
            //$ }
            //$ }).Map(new Func1<Map<String, PasswordCredential>, ActiveDirectoryApplication>() {
            //$ @Override
            //$ public ActiveDirectoryApplication call(Map<String, PasswordCredential> stringPasswordCredentialMap) {
            //$ ActiveDirectoryApplicationImpl.This.cachedPasswordCredentials = stringPasswordCredentialMap;
            //$ return ActiveDirectoryApplicationImpl.This;
            //$ }
            //$ });
            //$ return keyCredentials.MergeWith(passwordCredentials).Last();
            //$ }

            return null;
        }

                public ActiveDirectoryApplicationImpl WithIdentifierUrl(string identifierUrl)
        {
            //$ if (isInCreateMode()) {
            //$ if (createParameters.IdentifierUris() == null) {
            //$ createParameters.WithIdentifierUris(new ArrayList<String>());
            //$ }
            //$ createParameters.IdentifierUris().Add(identifierUrl);
            //$ } else {
            //$ if (updateParameters.IdentifierUris() == null) {
            //$ updateParameters.WithIdentifierUris(new ArrayList<>(identifierUris()));
            //$ }
            //$ updateParameters.IdentifierUris().Add(identifierUrl);
            //$ }
            //$ return this;

            return this;
        }

                internal  ActiveDirectoryApplicationImpl(ApplicationInner innerObject, GraphRbacManager manager)
                    : base(innerObject.DisplayName, innerObject)
        {
            //$ super(innerObject.DisplayName(), innerObject);
            //$ this.manager = manager;
            //$ this.createParameters = new ApplicationCreateParametersInner().WithDisplayName(innerObject.DisplayName());
            //$ this.updateParameters = new ApplicationUpdateParametersInner().WithDisplayName(innerObject.DisplayName());
            //$ }

        }

                public ActiveDirectoryApplicationImpl WithSignOnUrl(string signOnUrl)
        {
            //$ if (isInCreateMode()) {
            //$ createParameters.WithHomepage(signOnUrl);
            //$ } else {
            //$ updateParameters.WithHomepage(signOnUrl);
            //$ }
            //$ return withReplyUrl(signOnUrl);

            return this;
        }

                public ISet<string> ReplyUrls()
        {
            //$ if (inner().ReplyUrls() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableSet(Sets.NewHashSet(inner().ReplyUrls()));

            return null;
        }

                public IUpdate WithoutIdentifierUrl(string identifierUrl)
        {
            //$ if (updateParameters.IdentifierUris() != null) {
            //$ updateParameters.IdentifierUris().Remove(identifierUrl);
            //$ }
            //$ return this;

            return null;
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials()
        {
            //$ if (cachedCertificateCredentials == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableMap(cachedCertificateCredentials);

            return null;
        }

                protected override async Task<Models.ApplicationInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.Inner.Applications.GetAsync(Id(), cancellationToken);
        }

                public bool AvailableToOtherTenants()
        {
            //$ return inner().AvailableToOtherTenants();

            return false;
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials()
        {
            //$ if (cachedPasswordCredentials == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableMap(cachedPasswordCredentials);

            return null;
        }

                public ActiveDirectoryApplicationImpl WithPasswordCredential(PasswordCredentialImpl<object> credential)
        {
            //$ if (isInCreateMode()) {
            //$ if (createParameters.PasswordCredentials() == null) {
            //$ createParameters.WithPasswordCredentials(new ArrayList<PasswordCredentialInner>());
            //$ }
            //$ createParameters.PasswordCredentials().Add(credential.Inner());
            //$ } else {
            //$ if (updateParameters.PasswordCredentials() == null) {
            //$ updateParameters.WithPasswordCredentials(new ArrayList<PasswordCredentialInner>());
            //$ }
            //$ updateParameters.PasswordCredentials().Add(credential.Inner());
            //$ }
            //$ return this;

            return this;
        }

                public ISet<string> IdentifierUris()
        {
            //$ if (inner().IdentifierUris() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableSet(Sets.NewHashSet(inner().IdentifierUris()));

            return null;
        }

                public string Id()
        {
            //$ return inner().ObjectId();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager.Inner().Applications().PatchAsync(id(), updateParameters)
            //$ .FlatMap(new Func1<Void, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ });

            return null;
        }

                public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (createParameters.IdentifierUris() == null) {
            //$ createParameters.WithIdentifierUris(new ArrayList<String>());
            //$ createParameters.IdentifierUris().Add(createParameters.Homepage());
            //$ }
            //$ return manager.Inner().Applications().CreateAsync(createParameters)
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<ActiveDirectoryApplication, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(ActiveDirectoryApplication application) {
            //$ return refreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public bool IsInCreateMode()
        {
            //$ return id() == null;

            return false;
        }

                public CertificateCredentialImpl<T> DefineCertificateCredential<T>(string name) where T : class
        {
            //$ public CertificateCredentialImpl defineCertificateCredential(String name) {
            //$ return new CertificateCredentialImpl<>(name, this);

            return null;
        }

                public ActiveDirectoryApplicationImpl WithCertificateCredential(CertificateCredentialImpl<object> credential)
        {
            //$ if (isInCreateMode()) {
            //$ if (createParameters.KeyCredentials() == null) {
            //$ createParameters.WithKeyCredentials(new ArrayList<KeyCredentialInner>());
            //$ }
            //$ createParameters.KeyCredentials().Add(credential.Inner());
            //$ } else {
            //$ if (updateParameters.KeyCredentials() == null) {
            //$ updateParameters.WithKeyCredentials(new ArrayList<KeyCredentialInner>());
            //$ }
            //$ updateParameters.KeyCredentials().Add(credential.Inner());
            //$ }
            //$ return this;

            return this;
        }

                public Uri SignOnUrl()
        {
            //$ try {
            //$ return new URL(inner().Homepage());
            //$ } catch (MalformedURLException e) {
            //$ return null;
            //$ }

            return null;
        }

                public ActiveDirectoryApplicationImpl WithoutReplyUrl(string replyUrl)
        {
            //$ if (updateParameters.ReplyUrls() != null) {
            //$ updateParameters.ReplyUrls().Remove(replyUrl);
            //$ }
            //$ return this;

            return this;
        }

                public ActiveDirectoryApplicationImpl WithoutCredential(string name)
        {
            //$ if (cachedPasswordCredentials.ContainsKey(name)) {
            //$ cachedPasswordCredentials.Remove(name);
            //$ if (updateParameters.PasswordCredentials() == null) {
            //$ updateParameters.WithPasswordCredentials(Lists.Transform(
            //$ new ArrayList<>(cachedPasswordCredentials.Values()),
            //$ new Function<PasswordCredential, PasswordCredentialInner>() {
            //$ @Override
            //$ public PasswordCredentialInner apply(PasswordCredential input) {
            //$ return input.Inner();
            //$ }
            //$ }));
            //$ }
            //$ } else if (cachedCertificateCredentials.ContainsKey(name)) {
            //$ cachedCertificateCredentials.Remove(name);
            //$ if (updateParameters.KeyCredentials() == null) {
            //$ updateParameters.WithKeyCredentials(Lists.Transform(
            //$ new ArrayList<>(cachedCertificateCredentials.Values()),
            //$ new Function<CertificateCredential, KeyCredentialInner>() {
            //$ @Override
            //$ public KeyCredentialInner apply(CertificateCredential input) {
            //$ return input.Inner();
            //$ }
            //$ }));
            //$ }
            //$ }
            //$ return this;

            return this;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return getInnerAsync()
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<ActiveDirectoryApplication, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(ActiveDirectoryApplication application) {
            //$ return refreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public string ApplicationId()
        {
            //$ return inner().AppId();

            return null;
        }

                public ActiveDirectoryApplicationImpl WithReplyUrl(string replyUrl)
        {
            //$ if (isInCreateMode()) {
            //$ if (createParameters.ReplyUrls() == null) {
            //$ createParameters.WithReplyUrls(new ArrayList<String>());
            //$ }
            //$ createParameters.ReplyUrls().Add(replyUrl);
            //$ } else {
            //$ if (updateParameters.ReplyUrls() == null) {
            //$ updateParameters.WithReplyUrls(new ArrayList<>(replyUrls()));
            //$ }
            //$ updateParameters.ReplyUrls().Add(replyUrl);
            //$ }
            //$ return this;

            return this;
        }
    }
}