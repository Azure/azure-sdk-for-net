// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using NamespaceAuthorizationRule.Definition;
    using NamespaceAuthorizationRule.Update;

    /// <summary>
    /// Implementation for NamespaceAuthorizationRule.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVJbXBs
    internal partial class NamespaceAuthorizationRuleImpl  :
        AuthorizationRuleBaseImpl<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespaceImpl,Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner,Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRuleImpl,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager>,
        INamespaceAuthorizationRule,
        IDefinition,
        IUpdate
    {
        private Region region;
        ///GENMHASH:323E13EA523CC5C9992A3C5081E83085:3854D5948CC5EB985EFD17B41F7BD546
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.ResourceListKeysInner> GetKeysInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.Namespaces()
            //$ .ListKeysAsync(this.ResourceGroupName(),
            //$ this.NamespaceName(),
            //$ this.Name());

            return null;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:60710D4DE8BBAA25BEA3436DAE67B2F8
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ NamespaceAuthorizationRule self = this;
            //$ return this.Manager().Inner.Namespaces().CreateOrUpdateAuthorizationRuleAsync(this.ResourceGroupName(),
            //$ this.NamespaceName(),
            //$ this.Name(),
            //$ this.Inner.Rights()).Map(new Func1<SharedAccessAuthorizationRuleInner, NamespaceAuthorizationRule>() {
            //$ @Override
            //$ public NamespaceAuthorizationRule call(SharedAccessAuthorizationRuleInner inner) {
            //$ setInner(inner);
            //$ return self;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:C2117B189F9FA822914F24C24F37E1E4:18F16B53FD5A60D0DAF2DBAB78D6BEE7
        internal  NamespaceAuthorizationRuleImpl(string resourceGroupName, string namespaceName, string name, Region region, SharedAccessAuthorizationRuleInner inner, ServiceBusManager manager)
        {
            //$ {
            //$ super(name, inner, manager);
            //$ this.region = region;
            //$ this.WithExistingParentResource(resourceGroupName, namespaceName);
            //$ if (inner.Location() == null) {
            //$ inner.WithLocation(this.region.ToString());
            //$ }
            //$ }

        }

        ///GENMHASH:1475FAC06F3CDD8B38B0B8B1586C3D7E:0900E482012F815059D11545A14D06F7
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.ResourceListKeysInner> RegenerateKeysInnerAsync(Policykey policykey, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.Namespaces()
            //$ .RegenerateKeysAsync(this.ResourceGroupName(),
            //$ this.NamespaceName(),
            //$ this.Name(),
            //$ policykey);

            return null;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AE869B1EBD7D0D502860692E76B432F1
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.Namespaces()
            //$ .GetAuthorizationRuleAsync(this.ResourceGroupName(),
            //$ this.NamespaceName(),
            //$ this.Name());

            return null;
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:04B212B505D5C86A62596EEEE457DD66
        public string NamespaceName()
        {
            //$ return this.ParentName;

            return null;
        }
    }
}