// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using System;

    /// <summary>
    /// The implementation of ServicePrincipals and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalsImpl  :
        CreatableResources<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal,Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl,Models.ServicePrincipalInner>,
        IServicePrincipals,
        IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipalsOperations>
    {
        private IServicePrincipalsOperations innerCollection;
        private GraphRbacManager manager;
                internal  ServicePrincipalsImpl(IServicePrincipalsOperations client, GraphRbacManager graphRbacManager)
        {
            //$ {
            //$ this.innerCollection = client;
            //$ this.manager = graphRbacManager;
            //$ converter = new PagedListConverter<ServicePrincipalInner, ServicePrincipal>() {
            //$ @Override
            //$ public ServicePrincipal typeConvert(ServicePrincipalInner servicePrincipalInner) {
            //$ ServicePrincipalImpl impl = wrapModel(servicePrincipalInner);
            //$ return impl.RefreshCredentialsAsync().ToBlocking().Single();
            //$ }
            //$ };
            //$ }

        }

                public GraphRbacManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public ServicePrincipalImpl GetById(string id)
        {
            //$ return (ServicePrincipalImpl) getByIdAsync(id).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.GetAsync(id)
            //$ .Map(new Func1<ServicePrincipalInner, ServicePrincipalImpl>() {
            //$ @Override
            //$ public ServicePrincipalImpl call(ServicePrincipalInner servicePrincipalInner) {
            //$ if (servicePrincipalInner == null) {
            //$ return null;
            //$ }
            //$ return new ServicePrincipalImpl(servicePrincipalInner, manager());
            //$ }
            //$ }).FlatMap(new Func1<ServicePrincipalImpl, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call(ServicePrincipalImpl servicePrincipal) {
            //$ if (servicePrincipal == null) {
            //$ return null;
            //$ }
            //$ return servicePrincipal.RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public IServicePrincipal GetByName(string spn)
        {
            //$ return getByNameAsync(spn).ToBlocking().Single();

            return null;
        }

                public ServicePrincipalImpl Define(string name)
        {
            //$ return new ServicePrincipalImpl(new ServicePrincipalInner().WithDisplayName(name), manager());

            return null;
        }

                public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await manager.Inner.ServicePrincipals.DeleteAsync(id, cancellationToken);
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.ListWithServiceResponseAsync(String.Format("servicePrincipalNames/any(c:c eq '%s')", name))
            //$ .FlatMap(new Func1<ServiceResponse<Page<ServicePrincipalInner>>, Observable<Page<ServicePrincipalInner>>>() {
            //$ @Override
            //$ public Observable<Page<ServicePrincipalInner>> call(ServiceResponse<Page<ServicePrincipalInner>> result) {
            //$ if (result == null || result.Body().Items() == null || result.Body().Items().IsEmpty()) {
            //$ return innerCollection.ListAsync(String.Format("displayName eq '%s'", name));
            //$ }
            //$ return Observable.Just(result.Body());
            //$ }
            //$ }).Map(new Func1<Page<ServicePrincipalInner>, ServicePrincipalImpl>() {
            //$ @Override
            //$ public ServicePrincipalImpl call(Page<ServicePrincipalInner> result) {
            //$ if (result == null || result.Items() == null || result.Items().IsEmpty()) {
            //$ return null;
            //$ }
            //$ return new ServicePrincipalImpl(result.Items().Get(0), manager());
            //$ }
            //$ }).FlatMap(new Func1<ServicePrincipalImpl, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call(ServicePrincipalImpl servicePrincipal) {
            //$ if (servicePrincipal == null) {
            //$ return null;
            //$ }
            //$ return servicePrincipal.RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> List()
        {
            //$ return wrapList(this.innerCollection.List());

            return null;
        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServicePrincipal>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(this.Inner().ListAsync())
            //$ .FlatMap(new Func1<ServicePrincipal, Observable<ServicePrincipal>>() {
            //$ @Override
            //$ public Observable<ServicePrincipal> call(ServicePrincipal servicePrincipal) {
            //$ return ((ServicePrincipalImpl) servicePrincipal).RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public IServicePrincipalsOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

                protected override IServicePrincipal WrapModel(ServicePrincipalInner servicePrincipalInner)
        {
            //$ if (servicePrincipalInner == null) {
            //$ return null;
            //$ }
            //$ return new ServicePrincipalImpl(servicePrincipalInner, manager());

            return null;
        }

                protected override ServicePrincipalImpl WrapModel(string name)
        {
            //$ return new ServicePrincipalImpl(new ServicePrincipalInner().WithDisplayName(name), manager());

            return null;
        }

        public override void DeleteById(string id)
        {
            Inner.Delete(id);
        }
    }
}