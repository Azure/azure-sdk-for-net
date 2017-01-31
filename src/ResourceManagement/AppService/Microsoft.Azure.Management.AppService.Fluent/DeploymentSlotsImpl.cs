// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
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
        private WebSiteManagementClient serviceClient;

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:DF6DF1B2A329B554D04700E954A45A08
        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await innerCollection.DeleteSlotAsync(groupName, parentName, name);
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:D92CC0F7821FC3C41ADC1CC35AB9A2E7
        public void DeleteByName(string name)
        {
            DeleteByParent(parent.ResourceGroupName, parent.Name, name);
        }

        ///GENMHASH:DED500AFBAD0A9AF916DAD488509F998:46CC5FC812EA999640A1A10FD4B00D83
        internal DeploymentSlotsImpl(WebAppImpl parent, IWebAppsOperations innerCollection, IAppServiceManager manager, WebSiteManagementClient serviceClient)
            : base(innerCollection, manager)
        {
            this.serviceClient = serviceClient;

            this.parent = parent;
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:1381FA42DE6ECBD284AA54F76A65CC41
        public override async Task<PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<SiteInner, IDeploymentSlot> converter = inner =>
            {
                return PopulateModelAsync(inner, parent).GetAwaiter().GetResult();
            };
            var slots = new WrappedPage<SiteInner, IDeploymentSlot>(await innerCollection.ListSlotsAsync(resourceGroupName, parentName), converter);
            return new PagedList<IDeploymentSlot>(slots, s =>
            {
                return new WrappedPage<SiteInner, IDeploymentSlot>(innerCollection.ListSlotsNext(s), converter);
            });
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:09CA495AE0F4F57BBBBDFC250874B0D4
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteByParentAsync(parent.ResourceGroupName, parent.Name, name);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:83FC2E4653FE30302201437639E1634A
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> List()
        {
            return ListByParent(parent.ResourceGroupName, parent.Name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5C4D08699E1ECDDF02A498EE458BCCC7
        protected override DeploymentSlotImpl WrapModel(string name)
        {
            var deploymentSlot = new DeploymentSlotImpl(name, new SiteInner(), null, parent, innerCollection, Manager, serviceClient);

            deploymentSlot.WithRegion(parent.RegionName);
            deploymentSlot.WithExistingResourceGroup(parent.ResourceGroupName);

            return deploymentSlot;
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:9586F8E3CBA078647A5B1619BB8CAD97
        protected override IDeploymentSlot WrapModel(SiteInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new DeploymentSlotImpl(inner.Name, inner, inner.SiteConfig, parent, innerCollection, Manager, serviceClient);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:03C8C385071EDDC2007A3CC169E2B327
        public IDeploymentSlot GetByName(string name)
        {
            return GetByParent(parent.ResourceGroupName, parent.Name, name);
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:C7E55DE6EB5DCE4FD47A68B8B1B62F02
        public override async Task<IDeploymentSlot> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            SiteInner siteInner = await innerCollection.GetSlotAsync(resourceGroup, parentName, name);
            if (siteInner == null)
            {
                return null;
            }
            siteInner.SiteConfig = await innerCollection.GetConfigurationSlotAsync(resourceGroup, parentName, name, cancellationToken);

            var result = WrapModel(siteInner);
            await ((DeploymentSlotImpl)result).CacheAppSettingsAndConnectionStringsAsync();

            return result;
        }

        public async Task<IDeploymentSlot> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByParentAsync(parent.ResourceGroupName, parent.Name, name);
        }

        private async Task<IDeploymentSlot> PopulateModelAsync(SiteInner inner, IWebApp parent, CancellationToken cancellationToken = default(CancellationToken))
        {
            inner.SiteConfig = await innerCollection.GetConfigurationSlotAsync(inner.ResourceGroup, parent.Name, Regex.Replace(inner.Name, ".*/", ""), cancellationToken);
            var slot = WrapModel(inner);
            await ((DeploymentSlotImpl)slot).CacheAppSettingsAndConnectionStringsAsync();
            return slot;
        }
    }
}
