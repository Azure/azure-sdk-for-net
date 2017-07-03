// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Management.ServiceBus.Fluent.Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using ServiceBus.Fluent;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for TopicAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNBdXRob3JpemF0aW9uUnVsZXNJbXBs
    internal partial class TopicAuthorizationRulesImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule,
            TopicAuthorizationRuleImpl,
            SharedAccessAuthorizationRuleInner,
            ITopicsOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.ServiceBus.Fluent.ITopic>,
            ITopicAuthorizationRules
    {
        private string resourceGroupName;
        private string namespaceName;
        private string topicName;
        private Region region;

        ///GENMHASH:5C2C33C827264DF37C8CB47D6FC05191:D523D8C228D67BAE63E8B815181D9698
        internal TopicAuthorizationRulesImpl(string resourceGroupName,
            string namespaceName,
            string topicName,
            Region region,
            IServiceBusManager manager) : base(manager.Inner.Topics, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.topicName = topicName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public TopicAuthorizationRuleImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesAsync(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                cancellationToken);
        }
        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:9DDF2E890869C153FE35A9BA52442792
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.GetAuthorizationRuleAsync(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                name,
                cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:ED38A22D1A6F643763BB631EE74414E3
        protected override TopicAuthorizationRuleImpl WrapModel(string name)
        {
            return new TopicAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                name,
                this.region,
                new SharedAccessAuthorizationRuleInner(),
                this.Manager);
        }

        ///GENMHASH:2D103FF04860F6EE3456875F8DA29A83:485F77D15565488001893585734CA339
        protected override ITopicAuthorizationRule WrapModel(SharedAccessAuthorizationRuleInner inner)
        {
            return new TopicAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:04EE773C8B0EE802364C84EEEF148730
        public async override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
                this.namespaceName,
                this.topicName,
                name,
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<IPagedCollection<ITopicAuthorizationRule>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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