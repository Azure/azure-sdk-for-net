// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// The implementation for WebApps.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwc0ltcGw=
    internal partial class WebAppsImpl  :
        GroupableResources<
            Microsoft.Azure.Management.AppService.Fluent.IWebApp,Microsoft.Azure.Management.AppService.Fluent.WebAppImpl,
            Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner,
            Microsoft.Azure.Management.AppService.Fluent.WebAppsOperations,
            Microsoft.Azure.Management.AppService.Fluent.AppServiceManager>,
        IWebApps
    {
        private Func<IEnumerable<SiteInner>, PagedList<IWebApp>> converter;
        private WebSiteManagementClient serviceClient;
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public WebAppImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IWebApp> ListByGroup(string resourceGroupName)
        {
            Func<SiteInner, IWebApp> converter = inner =>
            {
                return PopulateModelAsync(inner).GetAwaiter().GetResult();
            };
            var webApps = new WrappedPage<SiteInner, IWebApp>(InnerCollection.ListByResourceGroup(resourceGroupName), converter);
            return new PagedList<IWebApp>(webApps, s =>
            {
                return new WrappedPage(InnerCollection.ListByResourceGroupNext(s), converter);
            });
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:F6B932DEEE4F4CBE27781F2323DD7232
        public override async Task<IWebApp> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await InnerCollection.GetAsync(groupName, name, cancellationToken);
            var webapp = await PopulateModelAsync(inner, cancellationToken);
            return webapp;
        }

        private async Task<IWebApp> PopulateModelAsync(SiteInner inner, CancellationToken cancellationToken = default(CancellationToken)) {
            inner.SiteConfig = await InnerCollection.GetConfigurationAsync(inner.ResourceGroup, inner.Name, cancellationToken);
            var webApp = WrapModel(inner);
            await webApp.CacheAppSettingsAndConnectionStrings();
            return webApp;
        }

        ///GENMHASH:9CF36554B675F661BFEE8D1C53C27496:E373401BADB43C440BA3AAFA9214451D
        internal WebAppsImpl(WebAppsOperations innerCollection, AppServiceManager manager, WebSiteManagementClient serviceClient)
            : base(innerCollection, manager)
        {
            this.serviceClient = serviceClient;
            
            // TODO
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:E49716A6377D1B0BC4969F4A89093ED9
        protected override WebAppImpl WrapModel(string name)
        {
            return new WebAppImpl(name, new SiteInner(), null, InnerCollection, Manager, serviceClient);
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:BEC51BB7FA5CB1F04F04C62A207332AE
        protected override IWebApp WrapModel(SiteInner inner)
        {
            if (inner == null) {
                return null;
            }
            var configInner = inner.SiteConfig;
            return new WebAppImpl(inner.Name, inner, configInner, InnerCollection, Manager, serviceClient);
        }
    }
}