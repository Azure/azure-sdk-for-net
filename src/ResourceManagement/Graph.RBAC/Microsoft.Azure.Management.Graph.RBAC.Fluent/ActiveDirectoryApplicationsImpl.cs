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
    /// The implementation of Applications and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryApplicationsImpl  :
        CreatableResources<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication,Microsoft.Azure.Management.Graph.RBAC.Fluent.ActiveDirectoryApplicationImpl,Models.ApplicationInner>,
        IActiveDirectoryApplications,
        IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IApplicationsOperations>
    {
        private IApplicationsOperations innerCollection;
        private GraphRbacManager manager;
                public GraphRbacManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await innerCollection.DeleteAsync(id, cancellationToken);
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.ListWithServiceResponseAsync(String.Format("displayName eq '%s'", name))
            //$ .FlatMap(new Func1<ServiceResponse<Page<ApplicationInner>>, Observable<Page<ApplicationInner>>>() {
            //$ @Override
            //$ public Observable<Page<ApplicationInner>> call(ServiceResponse<Page<ApplicationInner>> result) {
            //$ if (result == null || result.Body().Items() == null || result.Body().Items().IsEmpty()) {
            //$ return innerCollection.ListAsync(String.Format("appId eq '%s'", name));
            //$ }
            //$ return Observable.Just(result.Body());
            //$ }
            //$ }).Map(new Func1<Page<ApplicationInner>, ActiveDirectoryApplicationImpl>() {
            //$ @Override
            //$ public ActiveDirectoryApplicationImpl call(Page<ApplicationInner> result) {
            //$ if (result == null || result.Items() == null || result.Items().IsEmpty()) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryApplicationImpl(result.Items().Get(0), manager());
            //$ }
            //$ }).FlatMap(new Func1<ActiveDirectoryApplicationImpl, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(ActiveDirectoryApplicationImpl application) {
            //$ if (application == null) {
            //$ return null;
            //$ }
            //$ return application.RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> List()
        {
            //$ return wrapList(this.innerCollection.List());

            return null;
        }

                public IApplicationsOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

                protected IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> WrapList(IEnumerable<Models.ApplicationInner> pagedList)
        {
            //$ return converter.Convert(pagedList);

            return null;
        }

                public ActiveDirectoryApplicationImpl GetById(string id)
        {
            //$ return (ActiveDirectoryApplicationImpl) getByIdAsync(id).ToBlocking().Single();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryApplication> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.GetAsync(id)
            //$ .Map(new Func1<ApplicationInner, ActiveDirectoryApplicationImpl>() {
            //$ @Override
            //$ public ActiveDirectoryApplicationImpl call(ApplicationInner applicationInner) {
            //$ if (applicationInner == null) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryApplicationImpl(applicationInner, manager());
            //$ }
            //$ }).FlatMap(new Func1<ActiveDirectoryApplicationImpl, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(ActiveDirectoryApplicationImpl application) {
            //$ return application.RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                public IActiveDirectoryApplication GetByName(string spn)
        {
            //$ return getByNameAsync(spn).ToBlocking().Single();

            return null;
        }

                public ActiveDirectoryApplicationImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

                internal  ActiveDirectoryApplicationsImpl(IApplicationsOperations client, GraphRbacManager graphRbacManager)
        {
            //$ {
            //$ this.innerCollection = client;
            //$ this.manager = graphRbacManager;
            //$ converter = new PagedListConverter<ApplicationInner, ActiveDirectoryApplication>() {
            //$ @Override
            //$ public ActiveDirectoryApplication typeConvert(ApplicationInner applicationsInner) {
            //$ ActiveDirectoryApplicationImpl impl = wrapModel(applicationsInner);
            //$ return impl.RefreshCredentialsAsync().ToBlocking().Single();
            //$ }
            //$ };
            //$ 
            //$ }

        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IActiveDirectoryApplication>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapPageAsync(this.Inner().ListAsync())
            //$ .FlatMap(new Func1<ActiveDirectoryApplication, Observable<ActiveDirectoryApplication>>() {
            //$ @Override
            //$ public Observable<ActiveDirectoryApplication> call(ActiveDirectoryApplication application) {
            //$ return ((ActiveDirectoryApplicationImpl) application).RefreshCredentialsAsync();
            //$ }
            //$ });

            return null;
        }

                protected override IActiveDirectoryApplication WrapModel(ApplicationInner applicationInner)
        {
            //$ if (applicationInner == null) {
            //$ return null;
            //$ }
            //$ return new ActiveDirectoryApplicationImpl(applicationInner, manager());

            return null;
        }

                protected override ActiveDirectoryApplicationImpl WrapModel(string name)
        {
            //$ return new ActiveDirectoryApplicationImpl(new ApplicationInner().WithDisplayName(name), manager());

            return null;
        }

        public override void DeleteById(string id)
        {
            innerCollection.Delete(id);
        }
    }
}