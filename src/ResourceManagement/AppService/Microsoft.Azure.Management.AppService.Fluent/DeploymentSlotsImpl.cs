// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DeploymentSlots.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RzSW1wbA==
    internal partial class DeploymentSlotsImpl :
        IndependentChildResourcesImpl<
            IDeploymentSlot,
            DeploymentSlotImpl,
            SiteInner,
            IWebAppsOperations,
            IAppServiceManager,
            IWebApp>,
        IDeploymentSlots
    {
        private WebAppImpl parent;

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:23815681E86022F4ACC67F93AAA34DF6
        public async override Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return innerCollection.DeleteSlotAsync(groupName, parentName, name).ToCompletable();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            await Inner.DeleteSlotAsync(groupName, parentName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:D92CC0F7821FC3C41ADC1CC35AB9A2E7
        public void DeleteByName(string name)
        {
            DeleteByParent(parent.ResourceGroupName, parent.Name, name);
        }

        ///GENMHASH:DED500AFBAD0A9AF916DAD488509F998:46CC5FC812EA999640A1A10FD4B00D83

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        internal DeploymentSlotsImpl(
            WebAppImpl parent,
            IAppServiceManager manager)
            : base(manager.Inner.WebApps, manager)
        {
            this.parent = parent;
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:1381FA42DE6ECBD284AA54F76A65CC41
        public async override Task<IPagedCollection<IDeploymentSlot>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IDeploymentSlot, SiteInner>.LoadPageWithWrapModelAsync(
                async (cancellation) => await Inner.ListSlotsAsync(resourceGroupName, parentName, cancellation),
                async (nextLink, cancellation) => await Inner.ListSlotsNextAsync(nextLink, cancellation),
                async (inner, cancellation) => await PopulateModelAsync(inner, parent, cancellation), true, cancellationToken);
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:09CA495AE0F4F57BBBBDFC250874B0D4
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByParentAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:83FC2E4653FE30302201437639E1634A
        public IEnumerable<IDeploymentSlot> List()
        {
            return ListByParent(parent.ResourceGroupName, parent.Name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:CAB02828F240DEA3976BF1456621A4A8
        protected override DeploymentSlotImpl WrapModel(string name)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return new DeploymentSlotImpl(name, new SiteInner(), null, parent)
            //$ .WithRegion(parent.RegionName())
            //$ .WithExistingResourceGroup(parent.ResourceGroupName());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var deploymentSlot = new DeploymentSlotImpl(name, new SiteInner(), null, parent, Manager);

            deploymentSlot.WithRegion(parent.RegionName);
            deploymentSlot.WithExistingResourceGroup(parent.ResourceGroupName);

            return deploymentSlot;
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:546B78C6345DE4CB959015B4F5C52E0D
        protected override IDeploymentSlot WrapModel(SiteInner inner)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return wrapModel(inner, null);

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            if (inner == null)
            {
                return null;
            }
            return new DeploymentSlotImpl(inner.Name, inner, null, parent, Manager);
        }

        private IDeploymentSlot WrapModel(SiteInner inner, SiteConfigResourceInner siteConfigInner)
        {
            if (inner == null)
            {
                return null;
            }
            return new DeploymentSlotImpl(inner.Name, inner, siteConfigInner, parent, Manager);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:03C8C385071EDDC2007A3CC169E2B327
        public IDeploymentSlot GetByName(string name)
        {
            return GetByParent(parent.ResourceGroupName, parent.Name, name);
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:C7E55DE6EB5DCE4FD47A68B8B1B62F02

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public async override Task<IDeploymentSlot> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            SiteInner siteInner = await Inner.GetSlotAsync(resourceGroup, parentName, name, cancellationToken);
            if (siteInner == null)
            {
                return null;
            }
            var siteConfig = await Inner.GetConfigurationSlotAsync(resourceGroup, parentName, name, cancellationToken);

            var result = WrapModel(siteInner, siteConfig);
            await ((DeploymentSlotImpl)result).CacheAppSettingsAndConnectionStringsAsync(cancellationToken);

            return result;
        }

        public async Task<IDeploymentSlot> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByParentAsync(parent.ResourceGroupName, parent.Name, name, cancellationToken);
        }

        private WebAppImpl Parent()
        {
            return this.parent;
        } 

        private async Task<IDeploymentSlot> PopulateModelAsync(SiteInner inner, IWebApp parent, CancellationToken cancellationToken = default(CancellationToken))
        {
            var siteConfig = await Inner.GetConfigurationSlotAsync(inner.ResourceGroup, parent.Name, Regex.Replace(inner.Name, ".*/", ""), cancellationToken);
            var slot = WrapModel(inner, siteConfig);
            await ((DeploymentSlotImpl)slot).CacheAppSettingsAndConnectionStringsAsync(cancellationToken);
            return slot;
        }

        public async Task<IPagedCollection<IDeploymentSlot>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByParentAsync(parent.ResourceGroupName, parent.Name, cancellationToken);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:11F9A1DFE425B6C4099E5E20B4D6B6AF
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IDeploymentSlot>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return convertPageToInnerAsync(innerCollection.ListSlotsAsync(parent.ResourceGroupName(), parent.Name())).Map(new Func1<SiteInner, DeploymentSlot>() {
            //$ @Override
            //$ public DeploymentSlot call(SiteInner siteInner) {
            //$ return wrapModelWithConfigChange(siteInner, innerCollection, parent);
            //$ }
            //$ });

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:EA1A01CE829067751D1BD24D7AC819DA:6B3D59259881324FE0CF7E22BF7F40ED
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.GetSlotAsync(resourceGroup, parentName, name).FlatMap(new Func1<SiteInner, Observable<DeploymentSlot>>() {
            //$ @Override
            //$ public Observable<DeploymentSlot> call( SiteInner siteInner) {
            //$ if (siteInner == null) {
            //$ return null;
            //$ }
            //$ return innerCollection.GetConfigurationSlotAsync(resourceGroup, parentName, name)
            //$ .FlatMap(new Func1<SiteConfigResourceInner, Observable<DeploymentSlot>>() {
            //$ @Override
            //$ public Observable<DeploymentSlot> call(SiteConfigResourceInner siteConfigInner) {
            //$ return wrapModel(siteInner, siteConfigInner).CacheSiteProperties();
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:CB94B6BC21E29A62E4013B4505C36CAB:9CA7B3DBB8B4F2B7418ED7A9EBEDD4BE
        protected IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WrapList(IEnumerable<Models.SiteInner> pagedList)
        {
            //$ return converter.Convert(pagedList);
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:2C44922AFF6366EE92E097CEC958CA81:549EBADE44CE71CDF3F96696D492C0C0
        private DeploymentSlotImpl WrapModel(SiteInner inner, SiteConfigResourceInner configResourceInner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new DeploymentSlotImpl(inner.Name(), inner, configResourceInner, parent);
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:39A6A31D8DAC49D71E3CC7E7A36AE799:C89D473BD6F78FC268FC1A95772A16AF
        public async Task<ServiceFuture> DeleteByNameAsync(string name, IServiceCallback callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return deleteByParentAsync(parent.ResourceGroupName(), parent.Name(), name, callback);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:7D20AFF6B32FFD01B49036D5C89ED11D
        public IWebApp Parent()
        {
            //$ return this.parent;

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:0DEB22BBB7D8923C553A1245310E2A47:606FE71056AF5E8384157FC5248CED0E
        private IDeploymentSlot WrapModelWithConfigChange(SiteInner siteInner, WebAppsInner innerCollection, WebAppImpl parent)
        {
            //$ return wrapModel(siteInner, innerCollection.GetConfigurationSlot(siteInner.ResourceGroup(), parent.Name(), siteInner.Name().ReplaceAll(".*/", ""))).CacheSiteProperties().ToBlocking().Single();
            //$ }

            return null;
        }

    }
}
