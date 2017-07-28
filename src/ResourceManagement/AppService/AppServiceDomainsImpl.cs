// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServiceDomains.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZURvbWFpbnNJbXBs
    internal partial class AppServiceDomainsImpl  :
        TopLevelModifiableResources<
            IAppServiceDomain,
            AppServiceDomainImpl,
            DomainInner,
            IDomainsOperations,
            IAppServiceManager>,
        IAppServiceDomains
    {

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceDomainImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:C332A900315E8149F8047F02D419C9DC:DA276544D03C0E0CFA6F790ECB2A2B92
        public IEnumerable<IDomainLegalAgreement> ListAgreements(string topLevelExtension)
        {
            var topLevelDomains = Manager.Inner.TopLevelDomains;

            return Extensions.Synchronize(() => topLevelDomains.ListAgreementsAsync(topLevelExtension, new TopLevelDomainAgreementOptionInner()))
                                  .AsContinuousCollection(link => Extensions.Synchronize(() => topLevelDomains.ListAgreementsNextAsync(link)))
                                  .Select(inner => new DomainLegalAgreementImpl(inner));
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

        protected async override Task<IPage<DomainInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<DomainInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF

        protected async override Task<DomainInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8CF52FF5A0D0AA245495F311570001AD

        protected async override Task<IPage<DomainInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<DomainInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:9303C19C6745E77DCF648A0A5F603980:6058FD68A2D3CB7431C37FFF30958B5E

        internal  AppServiceDomainsImpl(AppServiceManager manager)
            : base (manager.Inner.Domains, manager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:A825BD2BA1961FDCEBA86379F29EB25B
        protected override AppServiceDomainImpl WrapModel(string name)
        {
            return new AppServiceDomainImpl(name, new DomainInner(), Manager);
        }

        ///GENMHASH:D46619B18B9E2DF548FE051B5E4AA581:B2349B8AC556881EB5FF1F67AC6E2BB3
        protected override IAppServiceDomain WrapModel(DomainInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new AppServiceDomainImpl(inner.Name, inner, Manager);
        }

    }
}
