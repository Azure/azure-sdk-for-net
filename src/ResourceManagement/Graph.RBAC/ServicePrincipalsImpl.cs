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
    using System.Linq;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;

    /// <summary>
    /// The implementation of ServicePrincipals and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalsImpl :
        CreatableResources<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal, Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipalImpl, Models.ServicePrincipalInner>,
        IServicePrincipals,
        IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.GraphRbacManager>,
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipalsOperations>
    {
        private IServicePrincipalsOperations innerCollection;
        private GraphRbacManager manager;
        internal ServicePrincipalsImpl(GraphRbacManager graphRbacManager)
        {
            this.innerCollection = graphRbacManager.Inner.ServicePrincipals;
            this.manager = graphRbacManager;
        }

        public ServicePrincipalImpl GetById(string id)
        {
            return (ServicePrincipalImpl)Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ((ServicePrincipalImpl)WrapModel(await innerCollection.GetAsync(id, cancellationToken))).RefreshCredentialsAsync(cancellationToken);
        }

        public IServicePrincipal GetByName(string spn)
        {
            return Extensions.Synchronize(() => GetByNameAsync(spn));
        }

        public ServicePrincipalImpl Define(string name)
        {
            return WrapModel(name);
        }

        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await manager.Inner.ServicePrincipals.DeleteAsync(id, cancellationToken);
        }

        public async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<ServicePrincipalInner> inners = await manager.Inner.ServicePrincipals.ListAsync(string.Format("displayName eq '{0}'", name), cancellationToken);
            if (inners == null || !inners.Any())
            {
                inners = await manager.Inner.ServicePrincipals.ListAsync(string.Format("servicePrincipalNames/any(c:c eq '{0}')", name), cancellationToken);
            }
            if (inners == null || !inners.Any())
            {
                return null;
            }
            else
            {
                return await new ServicePrincipalImpl(inners.First(), manager).RefreshCredentialsAsync(cancellationToken);
            }
        }

        public IEnumerable<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> List()
        {
            Func<ServicePrincipalInner, IServicePrincipal> converter = inner =>
            {
                return Extensions.Synchronize(() => ((ServicePrincipalImpl)WrapModel(inner)).RefreshCredentialsAsync());
            };

            return Extensions.Synchronize(() => Inner.ListAsync())
                        .AsContinuousCollection(link => Extensions.Synchronize(() => Inner.ListNextAsync(link)))
                        .Select(inner => converter(inner));
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IServicePrincipal>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IServicePrincipal, ServicePrincipalInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await innerCollection.ListAsync(null, cancellation),
                innerCollection.ListNextAsync,
                async (inner, cancellation) => await ((ServicePrincipalImpl)WrapModel(inner)).RefreshCredentialsAsync(cancellation),
                loadAllPages, cancellationToken);
        }

        public IServicePrincipalsOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

        GraphRbacManager IHasManager<GraphRbacManager>.Manager
        {
            get
            {
                return manager;
            }
        }

        protected override IServicePrincipal WrapModel(ServicePrincipalInner servicePrincipalInner)
        {
            return servicePrincipalInner == null ? null : new ServicePrincipalImpl(servicePrincipalInner, manager);
        }

        protected override ServicePrincipalImpl WrapModel(string name)
        {
            return new ServicePrincipalImpl(new ServicePrincipalInner
            {
                DisplayName = name
            }, manager);
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => Inner.DeleteAsync(id));
        }

        IServicePrincipal ISupportsGettingById<IServicePrincipal>.GetById(string id)
        {
            return WrapModel(Extensions.Synchronize(() => manager.Inner.ServicePrincipals.GetAsync(id)));
        }

        IBlank ISupportsCreating<IBlank>.Define(string name)
        {
            return WrapModel(name);
        }
    }
}