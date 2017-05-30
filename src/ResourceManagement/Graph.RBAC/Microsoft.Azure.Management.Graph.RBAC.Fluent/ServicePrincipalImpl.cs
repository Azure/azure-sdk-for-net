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

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalImpl  :
        Creatable<IServicePrincipal,ServicePrincipalInner,ServicePrincipalImpl,IServicePrincipal>,
        IServicePrincipal,
        IDefinition,
        IHasCredential<Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl>
    {
        private GraphRbacManager manager;
        private ServicePrincipalCreateParametersInner createParameters;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> cachedPasswordCredentials;
        private Dictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> cachedCertificateCredentials;
        private ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable;
        private Dictionary<string,BuiltInRole> roles;
         string assignedSubscription;
        private IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.CertificateCredentialImpl<object>> certificateCredentials;
        private IList<Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredentialImpl<object>> passwordCredentials;
                public PasswordCredentialImpl<ServicePrincipal.Definition.IWithCreate> DefinePasswordCredential(string name)
        {
            //$ return new PasswordCredentialImpl<>(name, this);

            return null;
        }

                internal async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> RefreshCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<ServicePrincipal> keyCredentials = manager.Inner().ServicePrincipals().ListKeyCredentialsAsync(id())
            //$ .Map(new Func1<List<KeyCredentialInner>, Map<String, CertificateCredential>>() {
            //$ @Override
            //$ public Map<String, CertificateCredential> call(List<KeyCredentialInner> keyCredentialInners) {
            //$ if (keyCredentialInners == null || keyCredentialInners.IsEmpty()) {
            //$ return null;
            //$ }
            //$ Map<String, CertificateCredential> certificateCredentialMap = new HashMap<String, CertificateCredential>();
            //$ for (KeyCredentialInner inner : keyCredentialInners) {
            //$ CertificateCredential credential = new CertificateCredentialImpl<>(inner);
            //$ certificateCredentialMap.Put(credential.Name(), credential);
            //$ }
            //$ return certificateCredentialMap;
            //$ }
            //$ })
            //$ .Map(new Func1<Map<String, CertificateCredential>, ServicePrincipal>() {
            //$ @Override
            //$ public ServicePrincipal call(Map<String, CertificateCredential> stringCertificateCredentialMap) {
            //$ ServicePrincipalImpl.This.cachedCertificateCredentials = stringCertificateCredentialMap;
            //$ return ServicePrincipalImpl.This;
            //$ }
            //$ });
            //$ Observable<ServicePrincipal> passwordCredentials = manager.Inner().ServicePrincipals().ListPasswordCredentialsAsync(id())
            //$ .Map(new Func1<List<PasswordCredentialInner>, Map<String, PasswordCredential>>() {
            //$ @Override
            //$ public Map<String, PasswordCredential> call(List<PasswordCredentialInner> passwordCredentialInners) {
            //$ if (passwordCredentialInners == null || passwordCredentialInners.IsEmpty()) {
            //$ return null;
            //$ }
            //$ Map<String, PasswordCredential> passwordCredentialMap = new HashMap<String, PasswordCredential>();
            //$ for (PasswordCredentialInner inner : passwordCredentialInners) {
            //$ PasswordCredential credential = new PasswordCredentialImpl<>(inner);
            //$ passwordCredentialMap.Put(credential.Name(), credential);
            //$ }
            //$ return passwordCredentialMap;
            //$ }
            //$ }).Map(new Func1<Map<String, PasswordCredential>, ServicePrincipal>() {
            //$ @Override
            //$ public ServicePrincipal call(Map<String, PasswordCredential> stringPasswordCredentialMap) {
            //$ ServicePrincipalImpl.This.cachedPasswordCredentials = stringPasswordCredentialMap;
            //$ return ServicePrincipalImpl.This;
            //$ }
            //$ });
            //$ return keyCredentials.MergeWith(passwordCredentials).Last();
            //$ }

            return null;
        }

                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public bool IsInCreateMode()
        {
            //$ return true;

            return false;
        }

                public ServicePrincipalImpl WithNewRoleInResourceGroup(BuiltInRole role, IResourceGroup resourceGroup)
        {
            //$ return withNewRole(role, resourceGroup.Id());

            return this;
        }

                public ServicePrincipalImpl WithNewRoleInSubscription(BuiltInRole role, string subscriptionId)
        {
            //$ this.assignedSubscription = subscriptionId;
            //$ return withNewRole(role, "subscriptions/" + subscriptionId);

            return this;
        }

                public CertificateCredentialImpl<ServicePrincipal.Definition.IWithCreate> DefineCertificateCredential(string name)
        {
            //$ return new CertificateCredentialImpl<>(name, this);

            return null;
        }

                public ServicePrincipalImpl WithNewApplication(ICreatable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> applicationCreatable)
        {
            //$ addCreatableDependency(applicationCreatable);
            //$ this.applicationCreatable = applicationCreatable;
            //$ return this;

            return this;
        }

                public ServicePrincipalImpl WithNewApplication(string signOnUrl)
        {
            //$ return withNewApplication(manager.Applications().Define(signOnUrl)
            //$ .WithSignOnUrl(signOnUrl)
            //$ .WithIdentifierUrl(signOnUrl));

            return this;
        }

                internal  ServicePrincipalImpl(ServicePrincipalInner innerObject, GraphRbacManager manager)
                    : base(innerObject.DisplayName, innerObject)
        {
            //$ super(innerObject.DisplayName(), innerObject);
            //$ this.manager = manager;
            //$ this.createParameters = new ServicePrincipalCreateParametersInner().WithAccountEnabled(true);
            //$ this.roles = new HashMap<>();
            //$ this.certificateCredentials = new ArrayList<>();
            //$ this.passwordCredentials = new ArrayList<>();
            //$ }

        }

                public ServicePrincipalImpl WithCertificateCredential(CertificateCredentialImpl<object> credential)
        {
            //$ if (createParameters.KeyCredentials() == null) {
            //$ createParameters.WithKeyCredentials(new ArrayList<KeyCredentialInner>());
            //$ }
            //$ createParameters.KeyCredentials().Add(credential.Inner());
            //$ this.certificateCredentials.Add(credential);
            //$ return this;

            return this;
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials()
        {
            //$ if (cachedCertificateCredentials == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableMap(cachedCertificateCredentials);

            return null;
        }

                protected override async Task<Models.ServicePrincipalInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager.Inner().ServicePrincipals().GetAsync(id());

            return null;
        }

                public IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials()
        {
            //$ if (cachedPasswordCredentials == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableMap(cachedPasswordCredentials);

            return null;
        }

                public ServicePrincipalImpl WithNewRole(BuiltInRole role, string scope)
        {
            //$ this.roles.Put(scope, role);
            //$ return this;

            return this;
        }

                public ServicePrincipalImpl WithExistingApplication(string id)
        {
            //$ createParameters.WithAppId(id);
            //$ return this;

            return this;
        }

                public ServicePrincipalImpl WithExistingApplication(IActiveDirectoryApplication application)
        {
            //$ createParameters.WithAppId(application.ApplicationId());
            //$ return this;

            return this;
        }

                public IReadOnlyList<string> ServicePrincipalNames()
        {
            //$ return inner().ServicePrincipalNames();

            return null;
        }

                public ServicePrincipalImpl WithPasswordCredential(PasswordCredentialImpl<object> credential)
        {
            //$ if (createParameters.PasswordCredentials() == null) {
            //$ createParameters.WithPasswordCredentials(new ArrayList<PasswordCredentialInner>());
            //$ }
            //$ createParameters.PasswordCredentials().Add(credential.Inner());
            //$ this.passwordCredentials.Add(credential);
            //$ return this;

            return this;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return getInnerAsync()
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<ServicePrincipal, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call(ServicePrincipal application) {
            //$ return refreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public string Id()
        {
            //$ return inner().ObjectId();

            return null;
        }

                public string ApplicationId()
        {
            //$ return inner().AppId();

            return null;
        }

                public override async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ActiveDirectoryApplication application = (ActiveDirectoryApplication) ((Object) super.CreatedModel(applicationCreatable.Key()));
            //$ createParameters.WithAppId(application.ApplicationId());
            //$ Observable<ServicePrincipal> sp = manager.Inner().ServicePrincipals().CreateAsync(createParameters)
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<ServicePrincipal, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call(ServicePrincipal servicePrincipal) {
            //$ return refreshCredentialsAsync();
            //$ }
            //$ });
            //$ if (roles == null || roles.IsEmpty()) {
            //$ return sp;
            //$ }
            //$ return sp.FlatMap(new Func1<ServicePrincipal, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call( ServicePrincipal servicePrincipal) {
            //$ return Observable.From(roles.EntrySet())
            //$ .FlatMap(new Func1<Map.Entry<String, BuiltInRole>, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Map.Entry<String, BuiltInRole> role) {
            //$ return manager().RoleAssignments().Define(UUID.RandomUUID().ToString())
            //$ .ForServicePrincipal(servicePrincipal)
            //$ .WithBuiltInRole(role.GetValue())
            //$ .WithScope(role.GetKey())
            //$ .CreateAsync()
            //$ .RetryWhen(new Func1<Observable<? extends Throwable>, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Observable<? extends Throwable> observable) {
            //$ return observable.ZipWith(Observable.Range(1, 30), new Func2<Throwable, Integer, Integer>() {
            //$ @Override
            //$ public Integer call(Throwable throwable, Integer integer) {
            //$ if (throwable instanceof CloudException
            //$ && ((CloudException) throwable).Body().Code().EqualsIgnoreCase("PrincipalNotFound")) {
            //$ return integer;
            //$ } else {
            //$ throw Exceptions.Propagate(throwable);
            //$ }
            //$ }
            //$ }).FlatMap(new Func1<Integer, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Integer i) {
            //$ return Observable.Timer(i, TimeUnit.SECONDS);
            //$ }
            //$ });
            //$ }
            //$ });
            //$ }
            //$ })
            //$ .Last()
            //$ .Map(new Func1<Object, ServicePrincipal>() {
            //$ @Override
            //$ public ServicePrincipal call(Object o) {
            //$ return servicePrincipal;
            //$ }
            //$ });
            //$ }
            //$ }).Map(new Func1<ServicePrincipal, ServicePrincipal>() {
            //$ @Override
            //$ public ServicePrincipal call(ServicePrincipal servicePrincipal) {
            //$ for (PasswordCredentialImpl<?> passwordCredential : passwordCredentials) {
            //$ passwordCredential.ExportAuthFile((ServicePrincipalImpl) servicePrincipal);
            //$ }
            //$ for (CertificateCredentialImpl<?> certificateCredential : certificateCredentials) {
            //$ certificateCredential.ExportAuthFile((ServicePrincipalImpl) servicePrincipal);
            //$ }
            //$ return servicePrincipal;
            //$ }
            //$ });

            return null;
        }
    }
}