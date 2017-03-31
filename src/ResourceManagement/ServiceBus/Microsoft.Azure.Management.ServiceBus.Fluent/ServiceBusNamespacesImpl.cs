// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Management.Fluent.ServiceBus;
    using Management.Fluent.ServiceBus.Models;
    using ResourceManager.Fluent.Core;
    using ServiceBus.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ServiceBusNamespaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c05hbWVzcGFjZXNJbXBs
    internal partial class ServiceBusNamespacesImpl  :
        GroupableResources<IServiceBusNamespace,
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

        public async override Task<IServiceBusNamespace> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await this.Inner.GetAsync(groupName, name, cancellationToken);
            return this.WrapModel(data);
        }

        public async override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:9F33885F608914F714E6FA1E746CFA88
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resultInner = await this.Inner.CheckNameAvailabilityMethodAsync(name, cancellationToken);
            return new CheckNameAvailabilityResultImpl(resultInner);
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:B6DE3F3ADD30CF80937F7E47989E73C7
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return this.CheckNameAvailabilityAsync(name).ConfigureAwait(false).GetAwaiter().GetResult();
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

        public IEnumerable<IServiceBusNamespace> List()
        {
            return WrapList(Inner.List()
                                 .AsContinuousCollection(link => Inner.ListNext(link)));
        }

        public IEnumerable<IServiceBusNamespace> ListByGroup(string resourceGroupName)
        {
            return WrapList(Inner.ListByResourceGroup(resourceGroupName)
                                 .AsContinuousCollection(link => Inner.ListByResourceGroupNext(link)));
        }
    }
}