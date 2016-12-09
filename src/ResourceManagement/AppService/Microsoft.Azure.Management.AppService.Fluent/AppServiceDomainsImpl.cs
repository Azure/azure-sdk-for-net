// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// The implementation for AppServiceDomains.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZURvbWFpbnNJbXBs
    internal partial class AppServiceDomainsImpl  :
        GroupableResources<
            IAppServiceDomain,
            AppServiceDomainImpl,
            DomainInner,
            DomainsOperations,
            AppServiceManager>,
        IAppServiceDomains
    {
        private TopLevelDomainsOperations topLevelDomainsInner;
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceDomainImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:C332A900315E8149F8047F02D419C9DC:7655A447C81D4846C50195D4FED8EB4A
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement> ListAgreements(string topLevelExtension)
        {
            //$ return new PagedListConverter<TldLegalAgreementInner, DomainLegalAgreement>() {
            //$ @Override
            //$ public DomainLegalAgreement typeConvert(TldLegalAgreementInner tldLegalAgreementInner) {
            //$ return new DomainLegalAgreementImpl(tldLegalAgreementInner);
            //$ }
            //$ }.Convert(topLevelDomainsInner.ListAgreements(topLevelExtension));

            return null;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain> ListByGroup(string resourceGroupName)
        {
            //$ return wrapList(innerCollection.ListByResourceGroup(resourceGroupName));

            return null;
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        public override async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.DeleteAsync(groupName, name)
            //$ .Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return;
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF
        public override async Task<IAppServiceDomain> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapModel(innerCollection.Get(groupName, name));

            return null;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8CF52FF5A0D0AA245495F311570001AD
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain> List()
        {
            //$ return wrapList(innerCollection.List());

            return null;
        }

        ///GENMHASH:9303C19C6745E77DCF648A0A5F603980:6058FD68A2D3CB7431C37FFF30958B5E
        internal  AppServiceDomainsImpl(DomainsOperations innerCollection, TopLevelDomainsOperations topLevelDomainsInner, AppServiceManager manager)
            : base (innerCollection, manager)
        {
            this.topLevelDomainsInner = topLevelDomainsInner;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:E44B844695C9BA669571A2A4CFD69105
        protected override AppServiceDomainImpl WrapModel(string name)
        {
            //$ return new AppServiceDomainImpl(name, new DomainInner(), innerCollection, topLevelDomainsInner, myManager);

            return null;
        }

        ///GENMHASH:D46619B18B9E2DF548FE051B5E4AA581:A6FE631194B3B92F0A3A833982E01503
        protected override IAppServiceDomain WrapModel(DomainInner inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new AppServiceDomainImpl(inner.Name(), inner, innerCollection, topLevelDomainsInner, myManager);

            return null;
        }
    }
}