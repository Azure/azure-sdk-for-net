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
    /// Implementation for NamespaceAuthorizationRules.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVzSW1wbA==
    internal partial class NamespaceAuthorizationRulesImpl :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule,
            NamespaceAuthorizationRuleImpl,
            SharedAccessAuthorizationRuleInner,
            INamespacesOperations,
            IServiceBusManager,
            Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
            INamespaceAuthorizationRules
    {
        private string resourceGroupName;
        private string namespaceName;
        private Region region;

        ///GENMHASH:AB83E550E2CF5D5B14F96E89DE7235EC:94828441129409B99782259FE77C4638
        internal NamespaceAuthorizationRulesImpl(string resourceGroupName,
            string namespaceName,
            Region region,
            IServiceBusManager manager) : base(manager.Inner.Namespaces, manager)
        {
            this.resourceGroupName = resourceGroupName;
            this.namespaceName = namespaceName;
            this.region = region;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public NamespaceAuthorizationRuleImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerFirstPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesAsync(this.resourceGroupName,
                this.namespaceName,
                cancellationToken);
        }
        protected async override Task<IPage<SharedAccessAuthorizationRuleInner>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListAuthorizationRulesNextAsync(nextLink, cancellationToken);

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:EBFD426A094C9B824FBCAD2C09993DFE
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.GetAuthorizationRuleAsync(this.resourceGroupName,
                this.namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:3FFA7E03E9A86CF18509CF7A41D08CFE
        protected override NamespaceAuthorizationRuleImpl WrapModel(string name)
        {
            return new NamespaceAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                name,
                this.region,
                new SharedAccessAuthorizationRuleInner(),
                this.Manager);
        }

        ///GENMHASH:2D103FF04860F6EE3456875F8DA29A83:B1000FD950D067C224AC23E0EA18F0F3
        protected override INamespaceAuthorizationRule WrapModel(SharedAccessAuthorizationRuleInner inner)
        {
            return new NamespaceAuthorizationRuleImpl(this.resourceGroupName,
                this.namespaceName,
                inner.Name,
                this.region,
                inner,
                this.Manager);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:0F27C8E3D9C550228EB6462F66EE4FFD
        public async override Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
                this.namespaceName,
                name,
                cancellationToken);
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<IPagedCollection<INamespaceAuthorizationRule>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //
            throw new NotImplementedException();
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public override Task<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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