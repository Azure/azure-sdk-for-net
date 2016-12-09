// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebApp.Definition;
    using WebApp.Update;
    using System.Collections.Generic;

    internal partial class WebAppImpl 
    {
        /// <summary>
        /// Creates a new free app service plan to use. No custom domains or SSL bindings are available in this plan.
        /// </summary>
        WebApp.Update.IUpdate WebApp.Update.IWithNewAppServicePlan.WithFreePricingTier()
        {
            return this.WithFreePricingTier() as WebApp.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The pricing tier to use.</param>
        WebApp.Update.IUpdate WebApp.Update.IWithNewAppServicePlan.WithPricingTier(AppServicePricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as WebApp.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new free app service plan to use. No custom domains or SSL bindings are available in this plan.
        /// </summary>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WebApp.Definition.IWithNewAppServicePlan.WithFreePricingTier()
        {
            return this.WithFreePricingTier() as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IWebApp>;
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The pricing tier to use.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WebApp.Definition.IWithNewAppServicePlan.WithPricingTier(AppServicePricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp>;
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebApp.Definition.IWithRegion WebApp.Definition.IWithAppServicePlan.WithNewAppServicePlan(string name)
        {
            return this.WithNewAppServicePlan(name) as WebApp.Definition.IWithRegion;
        }

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WebApp.Definition.IWithAppServicePlan.WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            return this.WithExistingAppServicePlan(appServicePlan) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp>;
        }

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebApp.Update.IWithNewAppServicePlan WebApp.Update.IWithAppServicePlan.WithNewAppServicePlan(string name)
        {
            return this.WithNewAppServicePlan(name) as WebApp.Update.IWithNewAppServicePlan;
        }

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        WebApp.Update.IUpdate WebApp.Update.IWithAppServicePlan.WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            return this.WithExistingAppServicePlan(appServicePlan) as WebApp.Update.IUpdate;
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.GetHostNameBindings()
        {
            return this.GetHostNameBindings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>;
        }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.GetPublishingProfile()
        {
            return this.GetPublishingProfile() as Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile;
        }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.ResetSlotConfigurations()
        {
 
            this.ResetSlotConfigurations();
        }

        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.GetSourceControl()
        {
            return this.GetSourceControl() as Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl;
        }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.Swap(string slotName)
        {
 
            this.Swap(slotName);
        }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.ApplySlotConfigurations(string slotName)
        {
 
            this.ApplySlotConfigurations(slotName);
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.Restart()
        {
 
            this.Restart();
        }

        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots Microsoft.Azure.Management.AppService.Fluent.IWebApp.DeploymentSlots
        {
            get
            {
                return this.DeploymentSlots() as Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots;
            }
        }
    }
}