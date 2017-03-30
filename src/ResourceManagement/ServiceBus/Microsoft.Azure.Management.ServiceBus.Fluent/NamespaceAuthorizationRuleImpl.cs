// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using NamespaceAuthorizationRule.Definition;
    using NamespaceAuthorizationRule.Update;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus.Models;
    using ServiceBus.Fluent;
    using System.Collections.Generic;
    using Management.Fluent.ServiceBus;

    /// <summary>
    /// Implementation for NamespaceAuthorizationRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVJbXBs
    internal partial class NamespaceAuthorizationRuleImpl  :
            AuthorizationRuleBaseImpl<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule,
            Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespaceImpl,
            SharedAccessAuthorizationRuleInner,
            Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRuleImpl,
            IHasId,
            NamespaceAuthorizationRule.Update.IUpdate,
            ServiceBus.Fluent.IServiceBusManager>,
        INamespaceAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private Region region;

        ///GENMHASH:C2117B189F9FA822914F24C24F37E1E4:18F16B53FD5A60D0DAF2DBAB78D6BEE7
        internal NamespaceAuthorizationRuleImpl(string resourceGroupName,
            string namespaceName,
            string name,
            Region region,
            SharedAccessAuthorizationRuleInner inner,
            IServiceBusManager manager) : base(name, inner, manager)
        {
            this.region = region;
            this.WithExistingParentResource(resourceGroupName, namespaceName);
            if (inner.Location == null)
            {
                inner.Location = this.region.ToString();
            }
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:04B212B505D5C86A62596EEEE457DD66
        public string NamespaceName()
        {
            return this.parentName;
        }

        IList<AccessRights> IAuthorizationRule<INamespaceAuthorizationRule>.Rights
        {
            get
            {
                return base.Rights();
            }
        }

        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:3854D5948CC5EB985EFD17B41F7BD546
        protected async override Task<ResourceListKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces
                .ListKeysAsync(this.ResourceGroupName,
                    this.NamespaceName(),
                    this.Name,
                    cancellationToken);
        }

        ///GENMHASH:1475FAC06F3CDD8B38B0B8B1586C3D7E:0900E482012F815059D11545A14D06F7
        protected async override Task<ResourceListKeysInner> RegenerateKeysInnerAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces
                .RegenerateKeysAsync(this.ResourceGroupName,
                this.NamespaceName(),
                this.Name,
                policykey,
                cancellationToken);
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:60710D4DE8BBAA25BEA3436DAE67B2F8
        protected async override Task<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.Namespaces.CreateOrUpdateAuthorizationRuleAsync(this.ResourceGroupName,
                this.NamespaceName(),
                this.Name,
                this.Inner.Rights,
                cancellationToken);
            SetInner(inner);
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AE869B1EBD7D0D502860692E76B432F1
        protected async override Task<SharedAccessAuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Namespaces
                .GetAuthorizationRuleAsync(this.ResourceGroupName,
                this.NamespaceName(),
                this.Name,
                cancellationToken);
        }

        async Task<IAuthorizationKeys> IAuthorizationRule<INamespaceAuthorizationRule>.RegenerateKeyAsync(Policykey policykey, CancellationToken cancellationToken)
        {
            return await base.RegenerateKeyAsync(policykey, cancellationToken);
        }

        async Task<IAuthorizationKeys> IAuthorizationRule<INamespaceAuthorizationRule>.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await base.GetKeysAsync(cancellationToken);
        }

        IAuthorizationKeys IAuthorizationRule<INamespaceAuthorizationRule>.GetKeys()
        {
            return base.GetKeys();
        }

        IAuthorizationKeys IAuthorizationRule<INamespaceAuthorizationRule>.RegenerateKey(Policykey policykey)
        {
            return base.RegenerateKey(policykey);
        }

        IUpdate AuthorizationRule.Update.IWithListen<IUpdate>.WithListeningEnabled()
        {
            return base.WithListeningEnabled();
        }

        IUpdate AuthorizationRule.Update.IWithSend<IUpdate>.WithSendingEnabled()
        {
            return base.WithSendingEnabled();
        }

        IUpdate AuthorizationRule.Update.IWithManage<IUpdate>.WithManagementEnabled()
        {
            return base.WithManagementEnabled();
        }

        IWithCreate AuthorizationRule.Definition.IWithListen<IWithCreate>.WithListeningEnabled()
        {
            return base.WithListeningEnabled();
        }

        IWithCreate AuthorizationRule.Definition.IWithSend<IWithCreate>.WithSendingEnabled()
        {
            return base.WithSendingEnabled();
        }

        IWithCreate AuthorizationRule.Definition.IWithManage<IWithCreate>.WithManagementEnabled()
        {
            return base.WithManagementEnabled();
        }
    }
}