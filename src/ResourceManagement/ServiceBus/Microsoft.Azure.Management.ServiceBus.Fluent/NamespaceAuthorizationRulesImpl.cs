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
    /// Implementation for NamespaceAuthorizationRules.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uTmFtZXNwYWNlQXV0aG9yaXphdGlvblJ1bGVzSW1wbA==
    internal partial class NamespaceAuthorizationRulesImpl  :
        ServiceBusChildResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule,Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRuleImpl,Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner,Microsoft.Azure.Management.Servicebus.Fluent.NamespacesInner,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager,Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        INamespaceAuthorizationRules
    {
        private string resourceGroupName;
        private string namespaceName;
        private Region region;
        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:DBE309666B1D8BDFE15651BA9A0DD4A1
        public PagedList<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule> ListByParent(string resourceGroupName, string parentName)
        {
            //$ // 'IndependentChildResourcesImpl' will be refactoring to remove all 'ByParent' methods
            //$ // This method is not exposed to end user from any of the derived types of IndependentChildResourcesImpl
            //$ //
            //$ throw new UnsupportedOperationException();

            return null;
        }

        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:DBE309666B1D8BDFE15651BA9A0DD4A1
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
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
        public NamespaceAuthorizationRuleImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:E9B29531317DB55DAD4ECD9DCD4DFFA8:75FBBC2BBB405C7EAD5D905E80FFE842
        protected PagedList<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner> ListInner()
        {
            //$ return this.Inner.ListAuthorizationRules(this.resourceGroupName,
            //$ this.namespaceName);

            return null;
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:EBFD426A094C9B824FBCAD2C09993DFE
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.GetAuthorizationRuleAsync(this.resourceGroupName, this.namespaceName, name);

            return null;
        }

        ///GENMHASH:62AC18170621D435D75BBABCA42E2D03:35351DB865E3547CA3FA00E5A3573454
        protected async Task<Microsoft.Rest.ServiceResponse<Microsoft.Azure.IPage<Microsoft.Azure.Management.Servicebus.Fluent.SharedAccessAuthorizationRuleInner>>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.ListAuthorizationRulesWithServiceResponseAsync(this.resourceGroupName,
            //$ this.namespaceName);

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:3FFA7E03E9A86CF18509CF7A41D08CFE
        protected NamespaceAuthorizationRuleImpl WrapModel(string name)
        {
            //$ return new NamespaceAuthorizationRuleImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name,
            //$ this.region,
            //$ new SharedAccessAuthorizationRuleInner(),
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:2D103FF04860F6EE3456875F8DA29A83:B1000FD950D067C224AC23E0EA18F0F3
        protected NamespaceAuthorizationRuleImpl WrapModel(SharedAccessAuthorizationRuleInner inner)
        {
            //$ return new NamespaceAuthorizationRuleImpl(this.resourceGroupName,
            //$ this.namespaceName,
            //$ inner.Name(),
            //$ this.region,
            //$ inner,
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:AB83E550E2CF5D5B14F96E89DE7235EC:94828441129409B99782259FE77C4638
        internal  NamespaceAuthorizationRulesImpl(string resourceGroupName, string namespaceName, Region region, ServiceBusManager manager)
        {
            //$ {
            //$ super(manager.Inner.Namespaces(), manager);
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.namespaceName = namespaceName;
            //$ this.region = region;
            //$ }

        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:0F27C8E3D9C550228EB6462F66EE4FFD
        public async Completable DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name).ToCompletable();

            return null;
        }

        ///GENMHASH:39A6A31D8DAC49D71E3CC7E7A36AE799:4F04CF1C1FDE6EC362951F0052DEBA43
        public async ServiceFuture DeleteByNameAsync(string name, IServiceCallback callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.DeleteAuthorizationRuleAsync(this.resourceGroupName,
            //$ this.namespaceName,
            //$ name,
            //$ callback);

            return null;
        }
    }
}