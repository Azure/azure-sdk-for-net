// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using DeploymentSlot.Definition;

    /// <summary>
    /// The implementation for DeploymentSlots.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RzSW1wbA==
    internal partial class DeploymentSlotsImpl  :
        IndependentChildResourcesImpl<
            IDeploymentSlot,
            DeploymentSlotImpl,
            SiteInner,
            WebAppsOperations,
            AppServiceManager>,
        IDeploymentSlots
    {
        private Func<IEnumerable<SiteInner>, PagedList<IDeploymentSlot>> converter;
        private WebAppImpl parent;
        private WebSiteManagementClient serviceClient;
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:DF6DF1B2A329B554D04700E954A45A08
        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.DeleteSlotAsync(groupName, parentName, name)
            //$ .FlatMap(new Func1<Object, Observable<Void>>() {
            //$ @Override
            //$ public Observable<Void> call(Object o) {
            //$ return null;
            //$ }
            //$ });
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:D92CC0F7821FC3C41ADC1CC35AB9A2E7
        public void DeleteByName(string name)
        {
            //$ deleteByParent(parent.ResourceGroupName(), parent.Name(), name);

        }

        ///GENMHASH:DED500AFBAD0A9AF916DAD488509F998:73380F084BCBB7208BE9649B9F292E25
        internal DeploymentSlotsImpl(WebAppImpl parent, WebAppsOperations innerCollection, AppServiceManager manager, WebSiteManagementClient serviceClient)
            : base(innerCollection, manager)
        {
            //$ super(innerCollection, manager);
            //$ this.serviceClient = serviceClient;
            //$ 
            //$ this.parent = parent;
            //$ converter = new PagedListConverter<SiteInner, DeploymentSlot>() {
            //$ @Override
            //$ public DeploymentSlot typeConvert(SiteInner siteInner) {
            //$ siteInner.WithSiteConfig(innerCollection.GetConfiguration(siteInner.ResourceGroup(), siteInner.Name()));
            //$ return wrapModel(siteInner).CacheAppSettingsAndConnectionStrings().ToBlocking().Single();
            //$ }
            //$ };
            //$ }

        }

        ///GENMHASH:CB94B6BC21E29A62E4013B4505C36CAB:9CA7B3DBB8B4F2B7418ED7A9EBEDD4BE
        protected PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WrapList(PagedList<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> pagedList)
        {
            //$ return converter.Convert(pagedList);
            //$ }

            return null;
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:1381FA42DE6ECBD284AA54F76A65CC41
        public override async Task<PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapList(innerCollection.ListSlots(resourceGroupName, parentName));

            return null;
        }

        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:09CA495AE0F4F57BBBBDFC250874B0D4
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return deleteByParentAsync(parent.ResourceGroupName(), parent.Name(), name);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:83FC2E4653FE30302201437639E1634A
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> List()
        {
            //$ return listByParent(parent.ResourceGroupName(), parent.Name());

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5C4D08699E1ECDDF02A498EE458BCCC7
        protected override DeploymentSlotImpl WrapModel(string name)
        {
            //$ return new DeploymentSlotImpl(name, new SiteInner(), null, parent, innerCollection, super.Manager, serviceClient)
            //$ .WithRegion(parent.RegionName())
            //$ .WithExistingResourceGroup(parent.ResourceGroupName());

            return null;
        }

        ///GENMHASH:64609469010BC4A501B1C3197AE4F243:9586F8E3CBA078647A5B1619BB8CAD97
        protected override IDeploymentSlot WrapModel(SiteInner inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new DeploymentSlotImpl(inner.Name(), inner, inner.SiteConfig(), parent, innerCollection, super.Manager, serviceClient);

            return null;
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:03C8C385071EDDC2007A3CC169E2B327
        public IDeploymentSlot GetByName(string name)
        {
            //$ return getByParent(parent.ResourceGroupName(), parent.Name(), name);

            return null;
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:C7E55DE6EB5DCE4FD47A68B8B1B62F02
        public override async Task<IDeploymentSlot> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SiteInner siteInner = innerCollection.GetSlot(resourceGroup, parentName, name);
            //$ if (siteInner == null) {
            //$ return null;
            //$ }
            //$ siteInner.WithSiteConfig(innerCollection.GetConfigurationSlot(resourceGroup, parentName, name));
            //$ return wrapModel(siteInner).CacheAppSettingsAndConnectionStrings().ToBlocking().Single();

            return null;
        }

        public Task<IDeploymentSlot> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}