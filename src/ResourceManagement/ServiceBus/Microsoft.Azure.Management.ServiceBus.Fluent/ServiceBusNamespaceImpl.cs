// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ServiceBusNamespace.Definition;
    using ServiceBusNamespace.Update;
    using System.Collections.Generic;
    using System;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent;
    using ServiceBus.Fluent;
    using Management.Fluent.ServiceBus.Models;
    using Management.Fluent.ServiceBus;
    using System.Linq;

    /// <summary>
    /// Implementation for ServiceBusNamespace.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c05hbWVzcGFjZUltcGw=
    internal partial class ServiceBusNamespaceImpl  :
            GroupableResource<IServiceBusNamespace,
            NamespaceModelInner,
            ServiceBusNamespaceImpl,
            IServiceBusManager,
            ServiceBusNamespace.Definition.IWithGroup,
            ServiceBusNamespace.Definition.IWithCreate,
            ServiceBusNamespace.Definition.IWithCreate,
            ServiceBusNamespace.Update.IUpdate>,
        IServiceBusNamespace,
        IDefinition,
        IUpdate
    {
        private IList<ICreatable<IQueue>> queuesToCreate;
        private IList<ICreatable<ITopic>> topicsToCreate;
        private IList<ICreatable<INamespaceAuthorizationRule>> rulesToCreate;
        private IList<string> queuesToDelete;
        private IList<string> topicsToDelete;
        private IList<string> rulesToDelete;

        ///GENMHASH:D5F5D7B4ED6C3CD6D1BC4B193E789ED5:DE0F43E4763FD287984BB053E525DD48
        internal ServiceBusNamespaceImpl(string name, NamespaceModelInner inner, IServiceBusManager manager) : base(name, inner, manager)
        {
            this.InitChildrenOperationsCache();
        }

        ///GENMHASH:A310C258C80DD19DCDBD4A3629B90E97:BDC900789892FBE0EDAA0D38DFC8D3B6
        private void InitChildrenOperationsCache()
        {
            this.queuesToCreate = new List<ICreatable<IQueue>>();
            this.topicsToCreate = new List<ICreatable<ITopic>>();
            this.rulesToCreate = new List<ICreatable<INamespaceAuthorizationRule>>();
            this.queuesToDelete = new List<string>();
            this.topicsToDelete = new List<string>();
            this.rulesToDelete = new List<string>();
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:F2E0DA6714F4CBB82BD262DD3FAFD7F0
        public string Fqdn()
        {
            return this.Inner.ServiceBusEndpoint;
        }

        ///GENMHASH:F42F719E077F749448F6083CD4E91B80:D04B4C35FD4C9B52030B2516D8C37D06
        public TopicsImpl Topics()
        {
            return new TopicsImpl(this.ResourceGroupName,
                this.Name,
                this.Region,
                this.Manager);
        }

        ///GENMHASH:897277FEA28BB17BF24A0A7519334860:4F3DA646FA2835C582BCB6BB226D3FA3
        public ServiceBusNamespaceImpl WithoutQueue(string name)
        {
            this.queuesToDelete.Add(name);
            return this;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:E32C091119D6FB6D73E1D3322965866B
        public ServiceBusNamespaceImpl WithNewManageRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithManagementEnabled());
            return this;
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:6F2E4EBB9D600893514CE9A2997DFAD0
        public NamespaceAuthorizationRulesImpl AuthorizationRules()
        {
            return new NamespaceAuthorizationRulesImpl(this.ResourceGroupName,
                this.Name,
                this.Region,
                Manager);
        }

        ///GENMHASH:7701B5E45C28C739B5610C34A2EF5559:5BCC0A5E68F721378DE24C6D3EE350E5
        public ServiceBusNamespaceImpl WithoutAuthorizationRule(string name)
        {
            this.rulesToDelete.Add(name);
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:08FB5A6CC72E9C407DAC126C07B38561
        protected override async Task<NamespaceModelInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces.GetAsync(
                this.ResourceGroupName,
                this.Name, 
                cancellationToken);
        }

        ///GENMHASH:D1F1E3A5DB47929D06C249A1D7F38170:3E4EB2C841364DFF671396F0796788FE
        public ServiceBusNamespaceImpl WithoutTopic(string name)
        {
            this.topicsToDelete.Add(name);
            return this;
        }

        ///GENMHASH:9157FD0110376DF53A83D529D7A1A4E1:385804CDAC891325C8D939BDF7A1D4FF
        public DateTime CreatedAt()
        {
            if (this.Inner.CreatedAt == null || !this.Inner.CreatedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.CreatedAt.Value;
        }

        ///GENMHASH:ED658C324B78DF3F287B5EF364C1FB7E:E3B8199E67E4B270AA8358E7C5767AA5
        public ServiceBusNamespaceImpl WithSku(NamespaceSku namespaceSku)
        {
            this.Inner.Sku = new Sku
            {
                Name = namespaceSku.Name.ToString(),
                Tier = namespaceSku.Tier.ToString(),
                Capacity = namespaceSku.Capacity
            };
            return this;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:B5BA3212E181BC7B599A722AEFAC04B4
        public ServiceBusNamespaceImpl WithNewSendRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithSendingEnabled());
            return this;
        }

        ///GENMHASH:0056597C3B557D2380B446CF23AF2A7B:3ED10B976FB7009877FF91F8B760BA3E
        public ServiceBusNamespaceImpl WithNewQueue(string name, int maxSizeInMB)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.IQueues queues = this.Queues();
            this.queuesToCreate.Add(queues.Define(name).WithSizeInMB(maxSizeInMB));
            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:E6E0C1CF73E25181AD5C0BE989C2DE15
        public ServiceBusNamespaceImpl WithNewListenRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithListeningEnabled());
            return this;
        }

        ///GENMHASH:1D23568874BE06880E14E0FB7622F67C:348B5EED59A4609BB5965E7355718218
        private async Task SubmitChildrenOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Queues().CreateAsync(this.queuesToCreate, cancellationToken);
            await this.Queues().DeleteByNameAsync(this.queuesToDelete, cancellationToken);
            await this.Topics().CreateAsync(this.topicsToCreate, cancellationToken);
            await this.Topics().DeleteByNameAsync(this.topicsToDelete, cancellationToken);
            await this.AuthorizationRules().CreateAsync(this.rulesToCreate, cancellationToken);
            await this.AuthorizationRules().DeleteByNameAsync(this.rulesToDelete, cancellationToken);
        }

        ///GENMHASH:2B6A7C27023EE8442A6D59B3FABB77A4:2413E2F661081FE7F61AA483AFCE848F
        public QueuesImpl Queues()
        {
            return new QueuesImpl(this.ResourceGroupName,
                this.Name,
                this.Region,
                this.Manager);
        }

        ///GENMHASH:4E79F831CA615F31A3B9091C9216E524:61C1065B307679F3800C701AE0D87070
        public string DnsLabel()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:263DC3FB1C12DD6F3B10E185DDDE2F7A
        public NamespaceSku Sku()
        {
            return new NamespaceSku(this.Inner.Sku);
        }

        ///GENMHASH:98A63A985E9B6B6F14188D0E5238F102:8647FDD47A835E6860B5FD34AEAF4704
        public ServiceBusNamespaceImpl WithNewTopic(string name, int maxSizeInMB)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.ITopics topics = this.Topics();
            this.topicsToCreate.Add(topics.Define(name).WithSizeInMB(maxSizeInMB));
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:BBFCE2924F9633469A6BC7350F5D2F05
        public async override Task<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await this.Manager.Inner.Namespaces
                    .CreateOrUpdateAsync(this.ResourceGroupName,
                        this.Name,
                        this.Inner,
                        cancellationToken);
                SetInner(inner);
                await SubmitChildrenOperationsAsync(cancellationToken);
            }
            finally
            {
                InitChildrenOperationsCache();
            }
            return this;
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime UpdatedAt()
        {
            if (this.Inner.UpdatedAt == null || !this.Inner.UpdatedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.UpdatedAt.Value;
        }
    }
}