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
    /// The implementation for WebApps.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwc0ltcGw=
    internal partial class WebAppsImpl  :
        TopLevelModifiableResources<
            IWebApp,
            WebAppImpl,
            Models.SiteInner,
            IWebAppsOperations,
            IAppServiceManager>,
        IWebApps
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public WebAppImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public override IEnumerable<IWebApp> ListByResourceGroup(string resourceGroupName)
        {
            Func<SiteInner, IWebApp> converter = inner =>
            {
                return PopulateModelAsync(inner).ConfigureAwait(false).GetAwaiter().GetResult();
            };

            return Inner.ListByResourceGroup(resourceGroupName)
                        .AsContinuousCollection(link => Inner.ListByResourceGroupNext(link))
                        .Select(inner => converter(inner));
        }

        public override async Task<IPagedCollection<IWebApp>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var collection = await PagedCollection<IWebApp, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellation),
                Inner.ListByResourceGroupNextAsync,
                async (inner, cancellation) => await PopulateModelAsync(inner, cancellation),
                loadAllPages, cancellationToken);
            return PagedCollection<IWebApp, SiteInner>.CreateFromEnumerable(collection.Where(w => w.Inner.Kind == "app"));
        }

        public override async Task<IPagedCollection<IWebApp>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var collection = await PagedCollection<IWebApp, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListAsync(cancellation),
                Inner.ListNextAsync,
                async (inner, cancellation) => await PopulateModelAsync(inner, cancellation),
                loadAllPages, cancellationToken);
            return PagedCollection<IWebApp, SiteInner>.CreateFromEnumerable(collection.Where(w => w.Inner.Kind == "app"));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:F6B932DEEE4F4CBE27781F2323DD7232

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public async override Task<IWebApp> GetByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerByGroupAsync(groupName, name, cancellationToken);
            var webapp = await PopulateModelAsync(inner, cancellationToken);
            return webapp;
        }

        private async Task<IWebApp> PopulateModelAsync(SiteInner inner, CancellationToken cancellationToken = default(CancellationToken)) {
            var siteConfig = await Inner.GetConfigurationAsync(inner.ResourceGroup, inner.Name, cancellationToken);
            var webApp = WrapModel(inner, siteConfig);
            await ((WebAppImpl)webApp).CacheAppSettingsAndConnectionStringsAsync(cancellationToken);
            return webApp;
        }

        ///GENMHASH:9CF36554B675F661BFEE8D1C53C27496:E373401BADB43C440BA3AAFA9214451D

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        internal WebAppsImpl(AppServiceManager manager)
            : base(manager.Inner.WebApps, manager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:33344D035CDCB989D0A891ED92F04788
        protected override WebAppImpl WrapModel(string name)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return new WebAppImpl(name, new SiteInner(), null, this.Manager());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return new WebAppImpl(name, new SiteInner(), null, Manager);
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:546B78C6345DE4CB959015B4F5C52E0D
        protected override IWebApp WrapModel(SiteInner inner)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return wrapModel(inner, null);

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            if (inner == null) {
                return null;
            }
            return new WebAppImpl(inner.Name, inner, null, Manager);
        }

        private IWebApp WrapModel(SiteInner inner, SiteConfigResourceInner siteConfigInner)
        {
            if (inner == null)
            {
                return null;
            }
            return new WebAppImpl(inner.Name, inner, siteConfigInner, Manager);
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
        ///GENMHASH:2B19D171A02814189E0329A91320316B:230EBA25BDA8BD45DD3A052D91179FE6
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IWebApp> GetByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ WebAppsImpl self = this;
            //$ return this.Inner().GetByResourceGroupAsync(groupName, name).FlatMap(new Func1<SiteInner, Observable<WebApp>>() {
            //$ @Override
            //$ public Observable<WebApp> call( SiteInner siteInner) {
            //$ if (siteInner == null) {
            //$ return null;
            //$ }
            //$ return self.Inner().GetConfigurationAsync(groupName, name).FlatMap(new Func1<SiteConfigResourceInner, Observable<WebApp>>() {
            //$ @Override
            //$ public Observable<WebApp> call(SiteConfigResourceInner siteConfigInner) {
            //$ return wrapModel(siteInner, siteConfigInner).CacheSiteProperties();
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:2C44922AFF6366EE92E097CEC958CA81:78DC6C82F1719215EC18B6EA09AF8A4E
        protected WebAppImpl WrapModel(SiteInner inner, SiteConfigResourceInner configResourceInner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new WebAppImpl(inner.Name(), inner, configResourceInner, this.Manager());
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:CB94B6BC21E29A62E4013B4505C36CAB:9CA7B3DBB8B4F2B7418ED7A9EBEDD4BE
        protected IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WrapList(IEnumerable<Models.SiteInner> pagedList)
        {
            //$ return converter.Convert(pagedList);
            //$ }

            return null;
        }

    }
}
