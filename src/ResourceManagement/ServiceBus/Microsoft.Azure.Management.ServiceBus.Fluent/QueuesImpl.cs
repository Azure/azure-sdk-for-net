// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Rest;
    using Management.Fluent.ServiceBus.Models;
    using Management.Fluent.ServiceBus;
    using ServiceBus.Fluent;
    using ResourceManager.Fluent.Core;
    using System;
    using Rest.Azure;

    /// <summary>
    /// Implementation for Queues.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uUXVldWVzSW1wbA==
    internal partial class QueuesImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.IQueue,
            Microsoft.Azure.Management.Servicebus.Fluent.QueueImpl,
            QueueInner,
            IQueuesOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        IQueues
    {
        private string resourceGroupName;
        private string namespaceName;
        private Region region;

        ///GENMHASH:98AC1A5C9A9130E6BB34288EC414EBC7:E76A8E1D3061342B4963F8D92782FAC2
        internal QueuesImpl(string resourceGroupName, 
            string namespaceName, 
            Region region, 
            ServiceBusManager manager) : base(manager.Inner.Queues, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public QueueImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override Task<IPage<QueueInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.ListByNamespaceAsync(this.resourceGroupName, this.namespaceName, cancellationToken);
        }
        protected override Task<IPage<QueueInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.ListByNamespaceNextAsync(nextLink, cancellationToken);

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:9C8551ABD03284A4A199719789CA62E6
        protected override Task<QueueInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.GetAsync(this.resourceGroupName, this.namespaceName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:06B731057FF84FCAD43933AB8443E28A
        protected override QueueImpl WrapModel(string name)
        {
            return new QueueImpl(this.resourceGroupName,
                this.namespaceName,
                name,
                this.region,
                new QueueInner(),
                this.Manager);
        }

        ///GENMHASH:4C53A89559FC19295E53536E684BAA11:F5424E5A24AD80B3CDB4E49FEDB7383F
        protected override IQueue WrapModel(QueueInner inner)
        {
            return new QueueImpl(this.resourceGroupName,
                this.namespaceName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:AEBB8A79E16164E35A225D2E6320E053
        public override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.DeleteAsync(this.resourceGroupName,
                this.namespaceName,
                name, 
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<PagedList<Microsoft.Azure.Management.Servicebus.Fluent.IQueue>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override async Task<Microsoft.Azure.Management.Servicebus.Fluent.IQueue> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            await Task.Yield();
            throw new NotImplementedException();
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            await Task.Yield();
            throw new NotImplementedException();
        }
    }
}