// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Definition;
    using WebApp.Update;

    /// <summary>
    /// The implementation for WebApp.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwSW1wbA==
    internal partial class WebAppImpl  :
        AppServiceBaseImpl<
            IWebApp,
            WebAppImpl,
            WebApp.Definition.IWithCreate,
            WebApp.Definition.INewAppServicePlanWithGroup,
            WebApp.Definition.IWithNewAppServicePlan,
            WebApp.Update.IUpdate>,
        IWebApp,
        IDefinition,
        WebApp.Update.IUpdate,
        WebApp.Definition.IExistingWindowsPlanWithGroup,
        WebApp.Definition.IExistingLinuxPlanWithGroup,
        WebApp.Update.IWithAppServicePlan,
        WebApp.Update.IWithCredentials,
        WebApp.Update.IWithStartUpCommand
    {
        private IDeploymentSlots deploymentSlots;

        ///GENMHASH:B22FA99F4432342EBBDB2AB426A8D2A2:DB92CE96AE133E965FE6DE31D475D7ED
        internal WebAppImpl(
            string name,
            SiteInner innerObject,
            SiteConfigResourceInner configObject,
            IAppServiceManager manager)
            : base(name, innerObject, configObject, manager)
        {
        }

        ///GENMHASH:CF27BBA612E1A2ABC8C2A6B8E0D936B0:8EE9D9B6AF47B6B9D97ADAC781E86E83
        public IDeploymentSlots DeploymentSlots()
        {
            if (deploymentSlots == null)
            {
                deploymentSlots = new DeploymentSlotsImpl(this, Manager);
            }
            return deploymentSlots;
        }


        ///GENMHASH:E73A2BC2090FC3A00E0D2D18D7506D67:BFA1AA102FC308FAD095DF52D3D7C9F1
        public WebAppImpl WithPrivateRegistryImage(string imageAndTag, string serverUrl)
        {
            //$ ensureLinuxPlan();
            //$ cleanUpContainerSettings();
            //$ withBuiltInImage(RuntimeStack.NODEJS_6_6_0);
            //$ withAppSetting(SETTING_DOCKER_IMAGE, imageAndTag);
            //$ withAppSetting(SETTING_REGISTRY_SERVER, serverUrl);
            //$ return this;

            return this;
        }

        ///GENMHASH:602C33B7B682DA260F6CBFC17D1C7E12:E4FC04D27E28502A10F31E38E988A897
        private void CleanUpContainerSettings()
        {
            //$ if (siteConfig != null && siteConfig.LinuxFxVersion() != null) {
            //$ siteConfig.WithLinuxFxVersion(null);
            //$ }
            //$ // PHP
            //$ if (siteConfig != null && siteConfig.PhpVersion() != null) {
            //$ siteConfig.WithPhpVersion(null);
            //$ }
            //$ // Node
            //$ if (siteConfig != null && siteConfig.NodeVersion() != null) {
            //$ siteConfig.WithNodeVersion(null);
            //$ }
            //$ // .NET
            //$ if (siteConfig != null && siteConfig.NetFrameworkVersion() != null) {
            //$ siteConfig.WithNetFrameworkVersion("v4.0");
            //$ }
            //$ // Docker Hub
            //$ withoutAppSetting(SETTING_DOCKER_IMAGE);
            //$ withoutAppSetting(SETTING_REGISTRY_SERVER);
            //$ withoutAppSetting(SETTING_REGISTRY_USERNAME);
            //$ withoutAppSetting(SETTING_REGISTRY_PASSWORD);
            //$ }

        }

        ///GENMHASH:2460CA25AB23358958E16CE251EDCDED:CB5ABC6F0B7D23F2B39F2E5148275C79
        public WebAppImpl WithExistingWindowsPlan(IAppServicePlan appServicePlan)
        {
            //$ return super.WithExistingAppServicePlan(appServicePlan);

            return this;
        }

        ///GENMHASH:8E1D3700A243EE806EC812A6D7F6CAE3:CB5ABC6F0B7D23F2B39F2E5148275C79
        public WebAppImpl WithExistingLinuxPlan(IAppServicePlan appServicePlan)
        {
            //$ return super.WithExistingAppServicePlan(appServicePlan);

            return this;
        }

        ///GENMHASH:D15FB33BB43555A701A8FD43F244B1D9:2B645488043FF9B7C9FE21F5BC901768
        public WebAppImpl WithPublicDockerHubImage(string imageAndTag)
        {
            //$ ensureLinuxPlan();
            //$ cleanUpContainerSettings();
            //$ withBuiltInImage(RuntimeStack.NODEJS_6_6_0);
            //$ withAppSetting(SETTING_DOCKER_IMAGE, imageAndTag);
            //$ return this;

            return this;
        }

        ///GENMHASH:4554623A20A1D1D6CA43597FA7713AD7:DD8E427B2F3E82987E90A2D5CCB5E193
        private void EnsureLinuxPlan()
        {
            //$ if (OperatingSystem.WINDOWS.Equals(operatingSystem())) {
            //$ throw new IllegalArgumentException("Docker container settings only apply to Linux app service plans.");
            //$ }
            //$ }
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:9AA0391980CD01ABEA62130DB5348393
        internal async override Task<SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationAsync(ResourceGroupName, Name, siteConfig, cancellationToken);
        }

        ///GENMHASH:AAA2EDCB023B7B99FC1D55B0B3B66F13:6B3219D30AE1CF4B94F25508BCCDD7E9
        public WebAppImpl WithPrivateDockerHubImage(string imageAndTag)
        {
            //$ return withPublicDockerHubImage(imageAndTag);

            return this;
        }

        ///GENMHASH:9624C43502CE877F02ED31D67E4A6217:9E9E1980C1811DAF6A3570844756F43D
        public WebAppImpl WithNewWindowsPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            //$ return super.WithNewAppServicePlan(appServicePlanCreatable);

            return this;
        }

        ///GENMHASH:1C6077E4D6C66768F90D34959C6A9557:E04E020A102AA03085B45CBF493840AB
        public WebAppImpl WithNewWindowsPlan(PricingTier pricingTier)
        {
            //$ return super.WithNewAppServicePlan(OperatingSystem.WINDOWS, pricingTier);

            return this;
        }

        ///GENMHASH:05FFF17BA5124DA9ADF68F72A294217A:9E9E1980C1811DAF6A3570844756F43D
        public WebAppImpl WithNewLinuxPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            //$ return super.WithNewAppServicePlan(appServicePlanCreatable);

            return this;
        }

        ///GENMHASH:93C29CF5161D2614E639C98402130AE8:6F5157AFE185E032D5BFCA058B128443
        public WebAppImpl WithNewLinuxPlan(PricingTier pricingTier)
        {
            //$ return super.WithNewAppServicePlan(OperatingSystem.LINUX, pricingTier);

            return this;
        }

        ///GENMHASH:EF90793D27905B9731A3A9BAC102798B:43571FEFEFB64D6EDF2EE00DFD72EDFA
        public WebAppImpl WithStartUpCommand(string startUpCommand)
        {
            //$ if (siteConfig == null) {
            //$ siteConfig = new SiteConfigResourceInner();
            //$ }
            //$ siteConfig.WithAppCommandLine(startUpCommand);
            //$ return this;

            return this;
        }

        ///GENMHASH:D79048417E133BB6DC503E8145592A80:62AD83CC92F592B62208E92CCB5E5752
        public WebAppImpl WithCredentials(string username, string password)
        {
            //$ withAppSetting(SETTING_REGISTRY_USERNAME, username);
            //$ withAppSetting(SETTING_REGISTRY_PASSWORD, password);
            //$ return this;

            return this;
        }

        ///GENMHASH:F7734222FF39440A50483317E5DF8156:998FF6187B952D74EE89FFECAAB847A3
        public WebAppImpl WithBuiltInImage(RuntimeStack runtimeStack)
        {
            //$ ensureLinuxPlan();
            //$ cleanUpContainerSettings();
            //$ if (siteConfig == null) {
            //$ siteConfig = new SiteConfigResourceInner();
            //$ }
            //$ siteConfig.WithLinuxFxVersion(String.Format("%s|%s", runtimeStack.Stack(), runtimeStack.Version()));
            //$ if (runtimeStack.Stack().Equals("NODE")) {
            //$ siteConfig.WithNodeVersion(runtimeStack.Version());
            //$ }
            //$ if (runtimeStack.Stack().Equals("PHP")) {
            //$ siteConfig.WithPhpVersion(runtimeStack.Version());
            //$ }
            //$ if (runtimeStack.Stack().Equals("DOTNETCORE")) {
            //$ siteConfig.WithNetFrameworkVersion(runtimeStack.Version());
            //$ }
            //$ return this;

            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup(string name)

        {
            throw new NotImplementedException();
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup()
        {
            throw new NotImplementedException();
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            throw new NotImplementedException();
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithExistingResourceGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithExistingResourceGroup(IResourceGroup group)
        {
            throw new NotImplementedException();
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup(string name)
        {
            throw new NotImplementedException();
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup()
        {
            throw new NotImplementedException();
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            throw new NotImplementedException();
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithExistingResourceGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithExistingResourceGroup(IResourceGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
