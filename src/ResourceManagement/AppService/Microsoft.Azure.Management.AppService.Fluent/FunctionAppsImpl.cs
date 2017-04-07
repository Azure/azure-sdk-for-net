// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for FunctionApps.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwc0ltcGw=
    internal partial class FunctionAppsImpl :
        TopLevelModifiableResources<
            IFunctionApp,
            FunctionAppImpl,
            Models.SiteInner,
            IWebAppsOperations,
            IAppServiceManager>,
        IFunctionApps
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public FunctionAppImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public override IEnumerable<IFunctionApp> ListByResourceGroup(string resourceGroupName)
        {
            Func<SiteInner, IFunctionApp> converter = inner =>
            {
                return PopulateModelAsync(inner).ConfigureAwait(false).GetAwaiter().GetResult();
            };

            return Inner.ListByResourceGroup(resourceGroupName)
                        .AsContinuousCollection(link => Inner.ListByResourceGroupNext(link))
                        .Select(inner => converter(inner));
        }

        public override async Task<IPagedCollection<IFunctionApp>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var collection = await PagedCollection<IFunctionApp, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellation),
                Inner.ListByResourceGroupNextAsync,
                async (inner, cancellation) => await PopulateModelAsync(inner, cancellation),
                loadAllPages, cancellationToken);
            return PagedCollection<IFunctionApp, SiteInner>.CreateFromEnumerable(collection.Where(w => w.Inner.Kind == "app"));
        }

        public override async Task<IPagedCollection<IFunctionApp>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var collection = await PagedCollection<IFunctionApp, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListAsync(cancellation),
                Inner.ListNextAsync,
                async (inner, cancellation) => await PopulateModelAsync(inner, cancellation),
                loadAllPages, cancellationToken);
            return PagedCollection<IFunctionApp, SiteInner>.CreateFromEnumerable(collection.Where(w => w.Inner.Kind == "app"));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:F6B932DEEE4F4CBE27781F2323DD7232
        public async override Task<IFunctionApp> GetByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerByGroupAsync(groupName, name, cancellationToken);
            var FunctionApp = await PopulateModelAsync(inner, cancellationToken);
            return FunctionApp;
        }

        private async Task<IFunctionApp> PopulateModelAsync(SiteInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            var siteConfig = await Inner.GetConfigurationAsync(inner.ResourceGroup, inner.Name, cancellationToken);
            var FunctionApp = WrapModel(inner, siteConfig);
            await ((FunctionAppImpl)FunctionApp).CacheAppSettingsAndConnectionStringsAsync(cancellationToken);
            return FunctionApp;
        }

        ///GENMHASH:9CF36554B675F661BFEE8D1C53C27496:E373401BADB43C440BA3AAFA9214451D
        internal FunctionAppsImpl(AppServiceManager manager)
            : base(manager.Inner.FunctionApps, manager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:E49716A6377D1B0BC4969F4A89093ED9
        protected override FunctionAppImpl WrapModel(string name)
        {
            return new FunctionAppImpl(name, new SiteInner(), null, Manager);
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:BEC51BB7FA5CB1F04F04C62A207332AE
        protected override IFunctionApp WrapModel(SiteInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new FunctionAppImpl(inner.Name, inner, null, Manager);
        }

        private IFunctionApp WrapModel(SiteInner inner, SiteConfigResourceInner siteConfigInner)
        {
            if (inner == null)
            {
                return null;
            }
            return new FunctionAppImpl(inner.Name, inner, siteConfigInner, Manager);
        }

        protected override async Task<IPage<SiteInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected override async Task<IPage<SiteInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(link, cancellationToken);
        }

        protected override async Task<IPage<SiteInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<SiteInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(link, cancellationToken);
        }

        protected override async Task<SiteInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:2C44922AFF6366EE92E097CEC958CA81:479D25A2D8F529C2A92A9524B10C70B9
        private FunctionAppImpl WrapModel(SiteInner inner, SiteConfigResourceInner configResourceInner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new FunctionAppImpl(inner.Name(), inner, configResourceInner, this.Manager());
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:546B78C6345DE4CB959015B4F5C52E0D
        protected FunctionAppImpl WrapModel(SiteInner inner)
        {
            //$ return wrapModel(inner, null);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:8A5BEB3322ABBAFDEBC760C4F353F882
        protected FunctionAppImpl WrapModel(string name)
        {
            //$ return new FunctionAppImpl(name, new SiteInner(), null, this.Manager());

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:9D38835F71DF2C39BF88CBB588420D30:FBFA0902403A234112A18515EE78DB0D
        public async Task DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner().DeleteAsync(groupName, name).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7D93B4EC99C64989F97B3D17F88C3F2C:1148670C7C28940DD2CBF2F669C165E4
        public IFunctionApp GetByResourceGroup(string groupName, string name)
        {
            //$ SiteInner siteInner = this.Inner().GetByResourceGroup(groupName, name);
            //$ if (siteInner == null) {
            //$ return null;
            //$ }
            //$ return wrapModel(siteInner, this.Inner().GetConfiguration(groupName, name)).CacheSiteProperties().ToBlocking().Single();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:CB94B6BC21E29A62E4013B4505C36CAB:9CA7B3DBB8B4F2B7418ED7A9EBEDD4BE
        protected IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp> WrapList(IEnumerable<Models.SiteInner> pagedList)
        {
            //$ return converter.Convert(pagedList);
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public FunctionAppImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:136D659EB836ECA199ED5D69D4606314
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner().DeleteAsync(resourceGroupName, name).ToCompletable();

            return null;
        }

    }
}
