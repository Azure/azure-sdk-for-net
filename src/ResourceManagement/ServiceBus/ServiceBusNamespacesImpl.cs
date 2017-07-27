// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Management.ServiceBus.Fluent.Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using ServiceBus.Fluent;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ServiceBusNamespaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c05hbWVzcGFjZXNJbXBs
    internal partial class ServiceBusNamespacesImpl  :
        TopLevelModifiableResources<IServiceBusNamespace,
            ServiceBusNamespaceImpl, 
            NamespaceModelInner,
            INamespacesOperations,
            IServiceBusManager>,
        IServiceBusNamespaces
    {
        ///GENMHASH:03B58DF1706F0F92F7D99C96D11EBD56:0FCD47CBCD9128C3D4A03458C5796741
        internal ServiceBusNamespacesImpl(IServiceBusManager manager) : base(manager.Inner.Namespaces, manager)
        {
        }

        protected async override Task<NamespaceModelInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:9F33885F608914F714E6FA1E746CFA88
        public async Task<Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resultInner = await this.Inner.CheckNameAvailabilityMethodAsync(name, cancellationToken);
            return new CheckNameAvailabilityResultImpl(resultInner);
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:B6DE3F3ADD30CF80937F7E47989E73C7
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return Extensions.Synchronize(() => this.CheckNameAvailabilityAsync(name));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ServiceBusNamespaceImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:62E3350A9FAF32A0172D3FF0EECDFAD5
        protected override ServiceBusNamespaceImpl WrapModel(string name)
        {
            return new ServiceBusNamespaceImpl(name,
                new NamespaceModelInner(),
                this.Manager);
        }

        ///GENMHASH:586C665ACF635E212AB1A09D9563543A:7B03AAAEC3D40D56B6C75B57727A67CF
        protected override IServiceBusNamespace WrapModel(NamespaceModelInner inner)
        {
            return new ServiceBusNamespaceImpl(inner.Name,
                inner,
                this.Manager);
        }

        protected async override Task<IPage<NamespaceModelInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<NamespaceModelInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<NamespaceModelInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<NamespaceModelInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}