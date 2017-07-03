// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using TopicAuthorizationRule.Definition;
    using TopicAuthorizationRule.Update;
    using ResourceManager.Fluent.Core;
    using Management.ServiceBus.Fluent.Models;
    using ServiceBus.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for TopicAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNBdXRob3JpemF0aW9uUnVsZUltcGw=
    internal partial class TopicAuthorizationRuleImpl  :
            AuthorizationRuleBaseImpl<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule,
            Microsoft.Azure.Management.ServiceBus.Fluent.TopicImpl,
            SharedAccessAuthorizationRuleInner,
            Microsoft.Azure.Management.ServiceBus.Fluent.TopicAuthorizationRuleImpl,
            IHasId,
            TopicAuthorizationRule.Update.IUpdate,
            ServiceBus.Fluent.IServiceBusManager>,
        ITopicAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private string namespaceName;
        private Region region;

        ///GENMHASH:19216A575CCA5B7FAAFF89290573DE1A:FAF1EE7AC452C290A5530A75FBBD6949
        internal TopicAuthorizationRuleImpl(string resourceGroupName,
            string namespaceName,
            string topicName,
            string name,
            Region region,
            SharedAccessAuthorizationRuleInner inner,
            IServiceBusManager manager) : base(name, inner, manager)
        {
            this.namespaceName = namespaceName;
            this.region = region;
            this.WithExistingParentResource(resourceGroupName, topicName);
            if (inner.Location == null)
            {
                inner.Location = this.region.ToString();
            }
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:829C667609783F52ADE8A276408CB6CA
        public string NamespaceName()
        {
            return this.namespaceName;
        }

        ///GENMHASH:3BD6FE85DD609B2F7387FE981B03D515:04B212B505D5C86A62596EEEE457DD66
        public string TopicName()
        {
            return this.parentName;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:EF7BE4FD6602A9C76AF00072DF1A0223
        protected async override Task<ResourceListKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Topics.ListKeysAsync(this.ResourceGroupName,
                    this.namespaceName,
                    this.TopicName(),
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:1475FAC06F3CDD8B38B0B8B1586C3D7E:173C7A559FAFC66AACDFAAC549271084
        protected async override Task<ResourceListKeysInner> RegenerateKeysInnerAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Topics
                .RegenerateKeysAsync(this.ResourceGroupName,
                this.namespaceName,
                this.TopicName(),
                this.Name,
                policykey,
                cancellationToken);
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:4187094DEEE3C6A3870BD8806AF85CA6
        protected async override Task<Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.Topics.CreateOrUpdateAuthorizationRuleAsync(this.ResourceGroupName,
                this.namespaceName,
                this.TopicName(),
                this.Name,
                this.Inner.Rights,
                cancellationToken);
            SetInner(inner);
            return this;
        }

        /////GENMHASH:5AD91481A0966B059A478CD4E9DD9466:FA8879C614CBDAFC8DA9F2E7FAB9838E
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Topics
                .GetAuthorizationRuleAsync(this.ResourceGroupName,
                this.namespaceName,
                this.TopicName(),
                this.Name,
                cancellationToken);
        }
    }
}