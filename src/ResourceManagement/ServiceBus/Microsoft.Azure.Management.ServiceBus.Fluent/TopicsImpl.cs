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
    /// Implementation for Topics.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNzSW1wbA==
    internal partial class TopicsImpl  :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.ITopic,Microsoft.Azure.Management.Servicebus.Fluent.TopicImpl,Microsoft.Azure.Management.Servicebus.Fluent.TopicInner,Microsoft.Azure.Management.Servicebus.Fluent.TopicsInner,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager,Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ITopics
    {
        private string resourceGroupName;
        private string namespaceName;
        private Region region;
        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public PagedList<Microsoft.Azure.Management.Servicebus.Fluent.ITopic> ListByParent(string resourceGroupName, string parentName)
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.ITopic> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public TopicImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:E9B29531317DB55DAD4ECD9DCD4DFFA8:B27CE4717D6B7472A7291BC54D32FA52
        protected PagedList<Microsoft.Azure.Management.Servicebus.Fluent.TopicInner> ListInner()
        {
            //$ return this.Inner.ListByNamespace(this.resourceGroupName,
            //$ this.namespaceName);

            return null;
        }

        ///GENMHASH:07619D5DE951D2CF8C8F33A2C42F91AD:62CB3CD567D5FF7DD6DD13A5F764AB5A
        internal  TopicsImpl(string resourceGroupName, string namespaceName, Region region, ServiceBusManager manager)
        {
            //$ super(manager.Inner.Topics(), manager);
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.namespaceName = namespaceName;
            //$ this.region = region;
            //$ }

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:9C8551ABD03284A4A199719789CA62E6
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.TopicInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.GetAsync(this.resourceGroupName, this.namespaceName, name);

            return null;
        }

        ///GENMHASH:62AC18170621D435D75BBABCA42E2D03:12FAB9CC9A0A428895413A6FF52EE05E
        protected async Task<Microsoft.Rest.ServiceResponse<Microsoft.Azure.IPage<Microsoft.Azure.Management.Servicebus.Fluent.TopicInner>>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.ListByNamespaceWithServiceResponseAsync(this.resourceGroupName, this.namespaceName);

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5E542742896671ABF1F76E8F3AD7BB34
        protected TopicImpl WrapModel(string name)
        {
            //$ return new TopicImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name,
            //$ this.region,
            //$ new TopicInner(),
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:708CB58A661381DD98FDB41D3B726B9F:107A6F1DA360C81F046B4090BC0F7FED
        protected TopicImpl WrapModel(TopicInner inner)
        {
            //$ return new TopicImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ inner.Name(),
            //$ this.region,
            //$ inner,
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:AEBB8A79E16164E35A225D2E6320E053
        public async Completable DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name).ToCompletable();

            return null;
        }

        ///GENMHASH:39A6A31D8DAC49D71E3CC7E7A36AE799:DE570EBD7F9A90BF21C9242DC8E5B830
        public async ServiceFuture DeleteByNameAsync(string name, IServiceCallback callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name,
            //$ callback);

            return null;
        }
    }
}