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
    /// Implementation for TopicAuthorizationRules.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNBdXRob3JpemF0aW9uUnVsZXNJbXBs
    internal partial class TopicAuthorizationRulesImpl  :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule,Microsoft.Azure.Management.Servicebus.Fluent.TopicAuthorizationRuleImpl,Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner,Microsoft.Azure.Management.Servicebus.Fluent.TopicsInner,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager,Microsoft.Azure.Management.Servicebus.Fluent.ITopic>,
        ITopicAuthorizationRules
    {
        private string resourceGroupName;
        private string namespaceName;
        private string topicName;
        private Region region;
        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public PagedList<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule> ListByParent(string resourceGroupName, string parentName)
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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
        public TopicAuthorizationRuleImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:E9B29531317DB55DAD4ECD9DCD4DFFA8:897A7CAD543016E92E5284740339C41E
        protected PagedList<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner> ListInner()
        {
            //$ return this.Inner.ListAuthorizationRules(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName);

            return null;
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:9DDF2E890869C153FE35A9BA52442792
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.GetAuthorizationRuleAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name);

            return null;
        }

        ///GENMHASH:62AC18170621D435D75BBABCA42E2D03:5E8668A8E2693DFB34BE7F25861A75CC
        protected async Task<Microsoft.Rest.ServiceResponse<Microsoft.Azure.IPage<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner>>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.ListAuthorizationRulesWithServiceResponseAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName);

            return null;
        }

        ///GENMHASH:5C2C33C827264DF37C8CB47D6FC05191:D523D8C228D67BAE63E8B815181D9698
        internal  TopicAuthorizationRulesImpl(string resourceGroupName, string namespaceName, string topicName, Region region, ServiceBusManager manager)
        {
            //$ {
            //$ super(manager.Inner.Topics(), manager);
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.namespaceName = namespaceName;
            //$ this.topicName = topicName;
            //$ this.region = region;
            //$ }

        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:ED38A22D1A6F643763BB631EE74414E3
        protected TopicAuthorizationRuleImpl WrapModel(string name)
        {
            //$ return new TopicAuthorizationRuleImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name,
            //$ this.region,
            //$ new SharedAccessAuthorizationRuleInner(),
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:2D103FF04860F6EE3456875F8DA29A83:485F77D15565488001893585734CA339
        protected TopicAuthorizationRuleImpl WrapModel(SharedAccessAuthorizationRuleInner inner)
        {
            //$ return new TopicAuthorizationRuleImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ inner.Name(),
            //$ this.region,
            //$ inner,
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:04EE773C8B0EE802364C84EEEF148730
        public async Completable DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name).ToCompletable();

            return null;
        }

        ///GENMHASH:39A6A31D8DAC49D71E3CC7E7A36AE799:C81597C03C62378C18674AC0E45CD0DF
        public async ServiceFuture DeleteByNameAsync(string name, IServiceCallback callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ this.topicName,
            //$ name,
            //$ callback);

            return null;
        }
    }
}