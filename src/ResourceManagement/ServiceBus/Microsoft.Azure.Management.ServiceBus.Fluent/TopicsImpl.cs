// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Management.Fluent.ServiceBus.Models;
    using Management.Fluent.ServiceBus;
    using ServiceBus.Fluent;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System;
    using System.Collections.Generic;
    using Management.Fluent.Resource.Core;

    /// <summary>
    /// Implementation for Topics.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNzSW1wbA==
    internal partial class TopicsImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.ITopic,
            Microsoft.Azure.Management.Servicebus.Fluent.TopicImpl,
            TopicInner,
            ITopicsOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ITopics
    {
        private string resourceGroupName;
        private string namespaceName;
        private Region region;

        ///GENMHASH:07619D5DE951D2CF8C8F33A2C42F91AD:62CB3CD567D5FF7DD6DD13A5F764AB5A
        internal TopicsImpl(string resourceGroupName,
            string namespaceName,
            Region region,
            IServiceBusManager manager) : base(manager.Inner.Topics, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public TopicImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task<IPage<TopicInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListByNamespaceAsync(this.resourceGroupName, this.namespaceName, cancellationToken);
        }
        
        protected async override Task<IPage<TopicInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListByNamespaceNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:9C8551ABD03284A4A199719789CA62E6
        protected async override Task<TopicInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.GetAsync(this.resourceGroupName, this.namespaceName, name, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5E542742896671ABF1F76E8F3AD7BB34
        protected override TopicImpl WrapModel(string name)
        {
            return new TopicImpl(this.resourceGroupName,
                this.namespaceName,
                name,
                this.region,
                new TopicInner(),
                this.Manager);
        }

        ///GENMHASH:708CB58A661381DD98FDB41D3B726B9F:107A6F1DA360C81F046B4090BC0F7FED
        protected override ITopic WrapModel(TopicInner inner)
        {
            return new TopicImpl(this.resourceGroupName,
                this.namespaceName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:AEBB8A79E16164E35A225D2E6320E053
        public async override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(this.resourceGroupName,
                this.namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<IPagedCollection<ITopic>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<Microsoft.Azure.Management.Servicebus.Fluent.ITopic> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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