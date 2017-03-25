// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    /// <summary>
    /// Implementation for Subscriptions.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU3Vic2NyaXB0aW9uc0ltcGw=
    internal partial class SubscriptionsImpl  :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription,Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionImpl,Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner,Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionsInner,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager,Microsoft.Azure.Management.Servicebus.Fluent.ITopic>,
        ISubscriptions
    {
        private string resourceGroupName;
        private string namespaceName;
        private string topicName;
        private Region region;
        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public PagedList<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription> ListByParent(string resourceGroupName, string parentName)
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public async Completable DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:2543CEBBD96EF3380CE25AD8CFC5AFBE:5ACB456EFBF8C14B803104BBCC81344D
        protected  SubscriptionsImpl(string resourceGroupName, string namespaceName, string topicName, Region region, ServiceBusManager manager)
        {
            //$ {
            //$ super(manager.Inner.Subscriptions(), manager);
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.namespaceName = namespaceName;
            //$ this.topicName = topicName;
            //$ this.region = region;
            //$ }

        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public SubscriptionImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:E9B29531317DB55DAD4ECD9DCD4DFFA8:BD49E3FDC5C0C3028D976404D8CAAC66
        protected PagedList<Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner> ListInner()
        {
            //$ return this.Inner.ListByTopic(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName);

            return null;
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:AC7DA12A153C81BA0050657D342ADB13
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.GetAsync(this.resourceGroupName, this.namespaceName, this.topicName, name);

            return null;
        }

        ///GENMHASH:62AC18170621D435D75BBABCA42E2D03:869446611919E0F298A1F4FBC9EC02A5
        protected async Task<Microsoft.Rest.ServiceResponse<Microsoft.Azure.IPage<Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner>>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.ListByTopicWithServiceResponseAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName);

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:FA443DB5FDCE6273F113A575AC7922C4
        protected SubscriptionImpl WrapModel(string name)
        {
            //$ return new SubscriptionImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name,
            //$ this.region,
            //$ new SubscriptionInner(),
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:74B2091B6489CB9BB077D200206A9817:B9A9842A672E25F235D522F599D8F9FE
        protected SubscriptionImpl WrapModel(SubscriptionInner inner)
        {
            //$ return new SubscriptionImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ inner.Name(),
            //$ this.region,
            //$ inner,
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:4DBCB8980532AA9B1B33D0E72379F286
        public async Completable DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name).ToCompletable();

            return null;
        }

        ///GENMHASH:39A6A31D8DAC49D71E3CC7E7A36AE799:E4DF6D5CC0711E7AE296C8A2BC4403EF
        public async ServiceFuture DeleteByNameAsync(string name, IServiceCallback callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name,
            //$ callback);

            return null;
        }
    }
}