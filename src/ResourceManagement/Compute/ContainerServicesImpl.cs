// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System;
    using System.Linq;

    /// <summary>
    /// The implementation for ContainerServices.
    /// </summary>
    internal partial class ContainerServicesImpl  :
        TopLevelModifiableResources<IContainerService,
            ContainerServiceImpl,
            ContainerServiceInner,
            IContainerServicesOperations,
            IComputeManager>,
        IContainerServices
    {
        internal ContainerServicesImpl(IComputeManager computeManager) : 
            base(computeManager.Inner.ContainerServices, computeManager)
        { }

        public ContainerServiceImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        public override IEnumerable<IContainerService> List()
        {
            // TODO - ans - We should try to check with service team if this is just missing API, if yes, then log a bug with swagger
            // and make a code change in auto-generated to support this method directly, as this will help implementing async pattern.

            // There is no API supporting listing of availability set across subscription so enumerate all RGs and then
            // flatten the "list of list of availability sets" as "list of availability sets" .
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        public override async Task<IPagedCollection<IContainerService>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellationToken);
            return await PagedCollection<IContainerService, ContainerServiceInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var containerService = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListInnerByGroupAsync(rg.Name, cancellation)));
                return containerService.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }


        protected override Task<IPage<ContainerServiceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<ContainerServiceInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected async override Task<IPage<ContainerServiceInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected async override Task<IPage<ContainerServiceInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ContainerServiceInner>>(null);
        }

        protected async override Task<ContainerServiceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override IContainerService WrapModel(ContainerServiceInner inner)
        {
            return new ContainerServiceImpl(inner.Name, inner, Manager);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>

        protected override ContainerServiceImpl WrapModel(string name)
        {
            return new ContainerServiceImpl(name, new ContainerServiceInner(), Manager);
        }
    }
}