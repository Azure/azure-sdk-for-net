// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Linq;
    using Rest.Azure;
    using System;
    using Models;

    /// <summary>
    /// Implementation for Registries.
    /// </summary>
    public partial class RegistriesImpl :
        TopLevelModifiableResources<IRegistry, 
            RegistryImpl,
            Models.RegistryInner, 
            IRegistriesOperations, IRegistryManager>,
        IRegistries
    {
        private IStorageManager storageManager;

        internal RegistriesImpl(IRegistryManager manager, IStorageManager storageManager) :
            base(manager.Inner.Registries, manager)
        {
            this.storageManager = storageManager;
        }

        public RegistryImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        public override IEnumerable<IRegistry> List()
        {
            // TODO - ans - We should try to check with service team if this is just missing API, if yes, then log a bug with swagger
            // and make a code change in auto-generated to support this method directly, as this will help implementing async pattern.

            // There is no API supporting listing of availability set across subscription so enumerate all RGs and then
            // flatten the "list of list of availability sets" as "list of availability sets" .
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        public override async Task<IPagedCollection<IRegistry>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellationToken);
            return await PagedCollection<IRegistry, Models.RegistryInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var containerService = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListInnerByGroupAsync(rg.Name, cancellation)));
                return containerService.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }


        protected override Task<IPage<Models.RegistryInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.RegistryInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.RegistryInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected async override Task<IPage<Models.RegistryInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<Models.RegistryInner>>(null);
        }

        protected async override Task<Models.RegistryInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override IRegistry WrapModel(Models.RegistryInner inner)
        {
            return new RegistryImpl(inner.Name, inner, Manager, this.storageManager);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>

        protected override RegistryImpl WrapModel(string name)
        {
            return new RegistryImpl(name, new Models.RegistryInner(), Manager, this.storageManager);
        }

        public RegistryListCredentials RegenerateCredential(string groupName, string registryName, PasswordName passwordName)
        {
            return this.RegenerateCredential(groupName, registryName, passwordName);
        }

        public async Task<RegistryListCredentials> ListCredentialsAsync(string groupName, string registryName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListCredentialsAsync(groupName, registryName, cancellationToken);
        }

        public RegistryListCredentials ListCredentials(string groupName, string registryName)
        {
            return Extensions.Synchronize(() => this.Inner.ListCredentialsAsync(groupName, registryName));
        }

        public async Task<RegistryListCredentials> RegenerateCredentialAsync(string groupName, string registryName, PasswordName passwordName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.RegenerateCredentialAsync(groupName, registryName, passwordName, cancellationToken);
        }
    }
}