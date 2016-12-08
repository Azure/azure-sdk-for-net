// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// The implementation for WebApps.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwc0ltcGw=
    internal partial class WebAppsImpl  :
        GroupableResources<Microsoft.Azure.Management.Appservice.Fluent.IWebApp,Microsoft.Azure.Management.Appservice.Fluent.WebAppImpl,Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner,Microsoft.Azure.Management.AppService.Fluent.Models.WebAppsInner,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceManager>,
        IWebApps
    {
        private <Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner,Microsoft.Azure.Management.Appservice.Fluent.IWebApp> converter;
        private WebSiteManagementClientImpl serviceClient;
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public WebAppImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:CB94B6BC21E29A62E4013B4505C36CAB:9CA7B3DBB8B4F2B7418ED7A9EBEDD4BE
        protected PagedList<Microsoft.Azure.Management.Appservice.Fluent.IWebApp> WrapList(PagedList<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> pagedList)
        {
            //$ return converter.Convert(pagedList);
            //$ }

            return null;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.Appservice.Fluent.IWebApp> ListByGroup(string resourceGroupName)
        {
            //$ return wrapList(innerCollection.ListByResourceGroup(resourceGroupName));

            return null;
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        public async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.DeleteAsync(groupName, name)
            //$ .Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:F6B932DEEE4F4CBE27781F2323DD7232
        public async Task<IWebApp> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SiteInner siteInner = innerCollection.Get(groupName, name);
            //$ if (siteInner == null) {
            //$ return null;
            //$ }
            //$ siteInner.WithSiteConfig(innerCollection.GetConfiguration(groupName, name));
            //$ return wrapModel(siteInner).CacheAppSettingsAndConnectionStrings().ToBlocking().Single();

            return null;
        }

        ///GENMHASH:9CF36554B675F661BFEE8D1C53C27496:E373401BADB43C440BA3AAFA9214451D
        internal  WebAppsImpl(WebAppsInner innerCollection, AppServiceManager manager, WebSiteManagementClientImpl serviceClient)
        {
            //$ super(innerCollection, manager);
            //$ this.serviceClient = serviceClient;
            //$ 
            //$ converter = new PagedListConverter<SiteInner, WebApp>() {
            //$ @Override
            //$ public WebApp typeConvert(SiteInner siteInner) {
            //$ siteInner.WithSiteConfig(innerCollection.GetConfiguration(siteInner.ResourceGroup(), siteInner.Name()));
            //$ WebAppImpl impl = wrapModel(siteInner);
            //$ return impl.CacheAppSettingsAndConnectionStrings().ToBlocking().Single();
            //$ }
            //$ };
            //$ }

        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:E49716A6377D1B0BC4969F4A89093ED9
        protected WebAppImpl WrapModel(string name)
        {
            //$ return new WebAppImpl(name, new SiteInner(), null, innerCollection, super.MyManager, serviceClient);

            return null;
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:BEC51BB7FA5CB1F04F04C62A207332AE
        protected WebAppImpl WrapModel(SiteInner inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ SiteConfigInner configInner = inner.SiteConfig();
            //$ return new WebAppImpl(inner.Name(), inner, configInner, innerCollection, super.MyManager, serviceClient);

            return null;
        }
    }
}