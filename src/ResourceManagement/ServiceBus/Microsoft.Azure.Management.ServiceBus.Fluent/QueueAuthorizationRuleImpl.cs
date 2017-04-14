// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using QueueAuthorizationRule.Definition;
    using QueueAuthorizationRule.Update;
    using ResourceManager.Fluent.Core;
    using Management.ServiceBus.Fluent.Models;
    using ServiceBus.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for QueueAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uUXVldWVBdXRob3JpemF0aW9uUnVsZUltcGw=
    internal partial class QueueAuthorizationRuleImpl  :
        AuthorizationRuleBaseImpl<Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRule,
            Microsoft.Azure.Management.ServiceBus.Fluent.QueueImpl,
            SharedAccessAuthorizationRuleInner,
            Microsoft.Azure.Management.ServiceBus.Fluent.QueueAuthorizationRuleImpl,
            IHasId,
            QueueAuthorizationRule.Update.IUpdate,
            ServiceBus.Fluent.IServiceBusManager>,
        IQueueAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private string namespaceName;
        private Region region;

        ///GENMHASH:5F5FAFAB925F6F87A6D566574235368A:8E65EC5E447E2A36F6F4362F1FFB1E59
        internal QueueAuthorizationRuleImpl(string resourceGroupName, 
            string namespaceName, 
            string queueName, 
            string name, 
            Region region, 
            SharedAccessAuthorizationRuleInner inner, 
            IServiceBusManager manager) : base(name, inner, manager)
        {
            this.namespaceName = namespaceName;
            this.region = region;
            this.WithExistingParentResource(resourceGroupName, queueName);
            if (inner.Location == null) {
                inner.Location = this.region.ToString();
            }
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:829C667609783F52ADE8A276408CB6CA
        public string NamespaceName()
        {
            return this.namespaceName;
        }

        ///GENMHASH:2DE15E5E45FA2E1512DC8E11676126DB:04B212B505D5C86A62596EEEE457DD66
        public string QueueName()
        {
            return this.parentName;
        }

        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:4AB288CC7CC6291048BDCBAFB0110546
        protected async override Task<ResourceListKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Queues.ListKeysAsync(this.ResourceGroupName,
                    this.namespaceName,
                    this.QueueName(),
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:1475FAC06F3CDD8B38B0B8B1586C3D7E:1E7FCECE5192C64244366E4A469949BB
        protected async override Task<ResourceListKeysInner> RegenerateKeysInnerAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Queues
                .RegenerateKeysAsync(this.ResourceGroupName,
                this.namespaceName,
                this.QueueName(),
                this.Name,
                policykey,
                cancellationToken);
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:46F4637261BEB669A9232C7B41AE2D1A
        protected async override Task<Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.Queues.CreateOrUpdateAuthorizationRuleAsync(this.ResourceGroupName,
                this.namespaceName,
                this.QueueName(),
                this.Name,
                this.Inner.Rights,
                cancellationToken);
            SetInner(inner);
            return this;
        }

        /////GENMHASH:5AD91481A0966B059A478CD4E9DD9466:FA8879C614CBDAFC8DA9F2E7FAB9838E
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Queues
                .GetAuthorizationRuleAsync(this.ResourceGroupName,
                this.namespaceName,
                this.QueueName(),
                this.Name,
                cancellationToken);
        }
    }
}