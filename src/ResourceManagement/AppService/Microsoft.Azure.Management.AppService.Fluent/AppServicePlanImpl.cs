// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServicePlan.Definition;
    using AppServicePlan.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZVBsYW5JbXBs
    internal partial class AppServicePlanImpl  :
        GroupableResource<
            IAppServicePlan,
            AppServicePlanInner,
            AppServicePlanImpl,
            AppServiceManager,
            IWithGroup,
            AppServicePlan.Definition.IWithPricingTier,
            IWithCreate,
            IUpdate>,
        IAppServicePlan,
        IDefinition,
        IUpdate
    {
        private IAppServicePlansOperations client;
        ///GENMHASH:DD6D049506665D52592C7FE5BDE38234:6B280B367194B8DBB81238BF9E23FF56
        public AppServicePlanImpl WithPerSiteScaling(bool perSiteScaling)
        {
            Inner.PerSiteScaling = perSiteScaling;
            return this;

        }

        ///GENMHASH:2EDD4B59BAFACBDD881E1EB427AFB76D:27E8C00736FB4030B068A418C1F77220
        public AppServicePlanImpl WithPricingTier(AppServicePricingTier pricingTier)
        {
            if (pricingTier == null)
            {
                throw new ArgumentException("pricingTier == null");
            }
            Inner.Sku = pricingTier.SkuDescription;

            return this;
        }

        ///GENMHASH:8DD1884D95AA83DF70C5D79066C82053:EE479BE5674DD2919F74BDF71907ED27
        public bool PerSiteScaling()
        {
            return Inner.PerSiteScaling.GetValueOrDefault();
        }

        ///GENMHASH:448254674B93100CCF6F2C593B4E5197:0B582D149117BC82BBCECC50876823E6
        public int NumberOfWebApps()
        {
            return Inner.NumberOfSites.GetValueOrDefault();
        }

        ///GENMHASH:085C052B5E99B190740EE6AF70CF4D53:E9337A64F885BD0450A880D39B4733A0
        public AppServicePlanImpl WithCapacity(int capacity)
        {
            if (capacity < 1) {
                throw new ArgumentException("Capacity is at least 1.");
            }
            Inner.Sku.Capacity = capacity;
            return this;
        }

        ///GENMHASH:B00DB10B25D0B1148EED70A5175FFB95:584BAEFB5CA005AA4A46C1C146CF8142
        public int MaxInstances()
        {
            return Inner.MaximumNumberOfWorkers.GetValueOrDefault();
        }

        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:7529ABBB57F7FCA2C180526D76FFE8FE
        public int Capacity()
        {
            return Inner.Sku.Capacity.GetValueOrDefault();
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F27412D40851995FA8EF630919CB5FD6
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await client.CreateOrUpdateAsync(ResourceGroupName, Name, Inner));

            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:24635E3B6AB96D3E6BFB9DA2AF7C6AB5
        public override IAppServicePlan Refresh()
        {
            this.SetInner(client.Get(ResourceGroupName, Name));
            return this;
        }

        ///GENMHASH:5929CFE21A9A83286B8C1C4A12A36B8B:9D4F7490FD2702FB45ED3AC0D12B3775
        public AppServicePricingTier PricingTier()
        {
            return AppServicePricingTier.FromSkuDescription(Inner.Sku);
        }

        internal AppServicePlanImpl(string name, AppServicePlanInner innerObject, IAppServicePlansOperations client, AppServiceManager manager)
            : base (name, innerObject, manager)
        {
            this.client = client;
        }
    }
}
