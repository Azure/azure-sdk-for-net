// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus.Models;
    using Management.Fluent.ServiceBus;
    using ServiceBus.Fluent;
    using System;
    using Rest.Azure;
    using System.Collections.Generic;
    using Management.Fluent.Resource.Core;

    /// <summary>
    /// Implementation for QueueAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uUXVldWVBdXRob3JpemF0aW9uUnVsZXNJbXBs
    internal partial class QueueAuthorizationRulesImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule,
            QueueAuthorizationRuleImpl,
            SharedAccessAuthorizationRuleInner,
            IQueuesOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.Servicebus.Fluent.IQueue>,
            IQueueAuthorizationRules
    {
        private string resourceGroupName;
        private string namespaceName;
        private string queueName;
        private Region region;

        //////GENMHASH:F733DDBADD9C63A8BD6DB92C6C88902E:26A75CD5C4E01BD8C21152C5F3F10120
        internal QueueAuthorizationRulesImpl(string resourceGroupName,
            string namespaceName,
            string queueName,
            Region region,
            IServiceBusManager manager) : base(manager.Inner.Queues, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.queueName = queueName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public QueueAuthorizationRuleImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesAsync(this.resourceGroupName, 
                this.namespaceName,
                this.queueName, 
                cancellationToken);
        }
        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesNextAsync(nextLink, 
                cancellationToken);

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:EF91C0DDA8BEC01982B7D92EFBC0621D
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.GetAuthorizationRuleAsync(this.resourceGroupName, 
                this.namespaceName, 
                this.queueName,
                name, 
                cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:07731204CB9E080306D4495D1BD3DBDA
        protected override QueueAuthorizationRuleImpl WrapModel(string name)
        {
            return new QueueAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                this.queueName,
                name,
                this.region,
                new SharedAccessAuthorizationRuleInner(),
                this.Manager);
        }

        ///GENMHASH:2D103FF04860F6EE3456875F8DA29A83:9431478C2BA9224B7417407ED1ED660A
        protected override IQueueAuthorizationRule WrapModel(SharedAccessAuthorizationRuleInner inner)
        {
            return new QueueAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                this.queueName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:663163B297CF6A5ED4F8980EF2B359AA
        public async override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
                this.namespaceName,
                this.queueName,
                name,
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<IPagedCollection<IQueueAuthorizationRule>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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