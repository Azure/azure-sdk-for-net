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
        private const string SETTING_DOCKER_IMAGE = "DOCKER_CUSTOM_IMAGE_NAME";
        private const string SETTING_REGISTRY_SERVER = "DOCKER_REGISTRY_SERVER_URL";
        private const string SETTING_REGISTRY_USERNAME = "DOCKER_REGISTRY_SERVER_USERNAME";
        private const string SETTING_REGISTRY_PASSWORD = "DOCKER_REGISTRY_SERVER_PASSWORD";


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
            EnsureLinuxPlan();
            CleanUpContainerSettings();
            if (SiteConfig == null)
            {
                SiteConfig = new SiteConfigResourceInner();
            }
            SiteConfig.LinuxFxVersion = string.Format("DOCKER|{0}", imageAndTag);
            WithAppSetting(SETTING_DOCKER_IMAGE, imageAndTag);
            WithAppSetting(SETTING_REGISTRY_SERVER, serverUrl);
            return this;
        }

        ///GENMHASH:602C33B7B682DA260F6CBFC17D1C7E12:E4FC04D27E28502A10F31E38E988A897
        private void CleanUpContainerSettings()
        {
            if (SiteConfig != null && SiteConfig.LinuxFxVersion != null)
            {
                SiteConfig.LinuxFxVersion = null;
            }
            // PHP
            if (SiteConfig != null && SiteConfig.PhpVersion != null)
            {
                SiteConfig.PhpVersion = null;
            }
            // Node
            if (SiteConfig != null && SiteConfig.NodeVersion != null)
            {
                SiteConfig.NodeVersion = null;
            }
            // .NET
            if (SiteConfig != null && SiteConfig.NetFrameworkVersion != null)
            {
                SiteConfig.NetFrameworkVersion = "v4.0";
            }
            // Docker Hub
            WithoutAppSetting(SETTING_DOCKER_IMAGE);
            WithoutAppSetting(SETTING_REGISTRY_SERVER);
            WithoutAppSetting(SETTING_REGISTRY_USERNAME);
            WithoutAppSetting(SETTING_REGISTRY_PASSWORD);
        }

        ///GENMHASH:2460CA25AB23358958E16CE251EDCDED:CB5ABC6F0B7D23F2B39F2E5148275C79
        public WebAppImpl WithExistingWindowsPlan(IAppServicePlan appServicePlan)
        {
            return WithExistingAppServicePlan(appServicePlan);
        }

        ///GENMHASH:8E1D3700A243EE806EC812A6D7F6CAE3:CB5ABC6F0B7D23F2B39F2E5148275C79
        public WebAppImpl WithExistingLinuxPlan(IAppServicePlan appServicePlan)
        {
            return WithExistingAppServicePlan(appServicePlan);
        }

        ///GENMHASH:D15FB33BB43555A701A8FD43F244B1D9:2B645488043FF9B7C9FE21F5BC901768
        public WebAppImpl WithPublicDockerHubImage(string imageAndTag)
        {
            EnsureLinuxPlan();
            CleanUpContainerSettings();
            if (SiteConfig == null)
            {
                SiteConfig = new SiteConfigResourceInner();
            }
            SiteConfig.LinuxFxVersion = string.Format("DOCKER|{0}", imageAndTag);
            WithAppSetting(SETTING_DOCKER_IMAGE, imageAndTag);
            return this;
        }

        ///GENMHASH:4554623A20A1D1D6CA43597FA7713AD7:DD8E427B2F3E82987E90A2D5CCB5E193
        private void EnsureLinuxPlan()
        {
            if (Fluent.OperatingSystem.Windows.Equals(OperatingSystem()))
            {
                throw new InvalidOperationException("Docker container settings only apply to Linux app service plans.");
            }
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:9AA0391980CD01ABEA62130DB5348393
        internal async override Task<SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationAsync(ResourceGroupName, Name, siteConfig, cancellationToken);
        }

        ///GENMHASH:AAA2EDCB023B7B99FC1D55B0B3B66F13:6B3219D30AE1CF4B94F25508BCCDD7E9
        public WebAppImpl WithPrivateDockerHubImage(string imageAndTag)
        {
            return WithPublicDockerHubImage(imageAndTag);
        }

        ///GENMHASH:9624C43502CE877F02ED31D67E4A6217:9E9E1980C1811DAF6A3570844756F43D
        public WebAppImpl WithNewWindowsPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            return WithNewAppServicePlan(appServicePlanCreatable);
        }

        ///GENMHASH:1C6077E4D6C66768F90D34959C6A9557:E04E020A102AA03085B45CBF493840AB
        public WebAppImpl WithNewWindowsPlan(PricingTier pricingTier)
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Windows, pricingTier);
        }

        ///GENMHASH:05FFF17BA5124DA9ADF68F72A294217A:9E9E1980C1811DAF6A3570844756F43D
        public WebAppImpl WithNewLinuxPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            return WithNewAppServicePlan(appServicePlanCreatable);
        }

        ///GENMHASH:93C29CF5161D2614E639C98402130AE8:6F5157AFE185E032D5BFCA058B128443
        public WebAppImpl WithNewLinuxPlan(PricingTier pricingTier)
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Linux, pricingTier);
        }

        ///GENMHASH:EF90793D27905B9731A3A9BAC102798B:43571FEFEFB64D6EDF2EE00DFD72EDFA
        public WebAppImpl WithStartUpCommand(string startUpCommand)
        {
            if (SiteConfig == null)
            {
                SiteConfig = new SiteConfigResourceInner();
            }
            SiteConfig.AppCommandLine = startUpCommand;
            return this;
        }

        ///GENMHASH:D79048417E133BB6DC503E8145592A80:62AD83CC92F592B62208E92CCB5E5752
        public WebAppImpl WithCredentials(string username, string password)
        {
            WithAppSetting(SETTING_REGISTRY_USERNAME, username);
            WithAppSetting(SETTING_REGISTRY_PASSWORD, password);
            return this;
        }

        ///GENMHASH:F7734222FF39440A50483317E5DF8156:998FF6187B952D74EE89FFECAAB847A3
        public WebAppImpl WithBuiltInImage(RuntimeStack runtimeStack)
        {
            EnsureLinuxPlan();
            CleanUpContainerSettings();
            if (SiteConfig == null) {
                SiteConfig = new SiteConfigResourceInner();
            }
            SiteConfig.LinuxFxVersion = string.Format("{0}|{1}", runtimeStack.Stack(), runtimeStack.Version());
            if (runtimeStack.Stack().Equals("NODE")) {
                SiteConfig.NodeVersion = runtimeStack.Version();
            }
            if (runtimeStack.Stack().Equals("PHP")) {
                SiteConfig.PhpVersion = runtimeStack.Version();
            }
            if (runtimeStack.Stack().Equals("DOTNETCORE")) {
                SiteConfig.NetFrameworkVersion = runtimeStack.Version();
            }
            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup(string name)
        {
            WithNewResourceGroup(name);
            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup()
        {
            WithNewResourceGroup();
            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            WithNewResourceGroup(groupDefinition);
            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithExistingResourceGroup(string groupName)
        {
            WithExistingResourceGroup(groupName);
            return this;
        }

        IWithCreate IExistingWindowsPlanWithGroup.WithExistingResourceGroup(IResourceGroup group)
        {
            WithExistingResourceGroup(group);
            return this;
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup(string name)
        {
            WithNewResourceGroup(name);
            return this;
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup()
        {
            WithNewResourceGroup();
            return this;
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            WithNewResourceGroup(groupDefinition);
            return this;
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithExistingResourceGroup(string groupName)
        {
            WithExistingResourceGroup(groupName);
            return this;
        }

        WebApp.Definition.IWithDockerContainerImage IExistingLinuxPlanWithGroup.WithExistingResourceGroup(IResourceGroup group)
        {
            WithExistingResourceGroup(group);
            return this;
        }
    }
}
