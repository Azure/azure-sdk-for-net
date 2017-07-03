// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ServiceBus.Fluent;
    using Rest.Azure;
    using ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Implementation for Subscriptions.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU3Vic2NyaXB0aW9uc0ltcGw=
    internal partial class SubscriptionsImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription,
            Microsoft.Azure.Management.ServiceBus.Fluent.SubscriptionImpl,
            Management.ServiceBus.Fluent.Models.SubscriptionInner,
            ISubscriptionsOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.ServiceBus.Fluent.ITopic>,
        ISubscriptions
    {
        private string resourceGroupName;
        private string namespaceName;
        private string topicName;
        private Region region;

        ///GENMHASH:2543CEBBD96EF3380CE25AD8CFC5AFBE:5ACB456EFBF8C14B803104BBCC81344D
        internal SubscriptionsImpl(string resourceGroupName, 
            string namespaceName, 
            string topicName, 
            Region region,
            IServiceBusManager manager) : base(manager.Inner.Subscriptions, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.topicName = topicName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public SubscriptionImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task<IPage<Management.ServiceBus.Fluent.Models.SubscriptionInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListByTopicAsync(this.resourceGroupName, 
                this.namespaceName, 
                this.topicName, 
                cancellationToken);
        }
        protected async override Task<IPage<Management.ServiceBus.Fluent.Models.SubscriptionInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListByTopicNextAsync(nextLink, 
                cancellationToken);

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:AC7DA12A153C81BA0050657D342ADB13
        protected async override Task<Management.ServiceBus.Fluent.Models.SubscriptionInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.GetAsync(this.resourceGroupName, 
                this.namespaceName, 
                this.topicName, 
                name, 
                cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:FA443DB5FDCE6273F113A575AC7922C4
        protected override SubscriptionImpl WrapModel(string name)
        {
            return new SubscriptionImpl(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                name,
                this.region,
                new Management.ServiceBus.Fluent.Models.SubscriptionInner(),
                this.Manager);
        }

        ///GENMHASH:74B2091B6489CB9BB077D200206A9817:B9A9842A672E25F235D522F599D8F9FE
        protected override ISubscription WrapModel(Management.ServiceBus.Fluent.Models.SubscriptionInner inner)
        {
            return new SubscriptionImpl(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:4DBCB8980532AA9B1B33D0E72379F286
        public async override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                name,
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<IPagedCollection<ISubscription>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }
    }
}