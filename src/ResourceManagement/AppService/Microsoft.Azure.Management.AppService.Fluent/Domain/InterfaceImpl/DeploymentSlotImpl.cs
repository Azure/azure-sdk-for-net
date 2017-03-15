// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    internal partial class DeploymentSlotImpl 
    {
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Creates the deployment slot with brand new site configurations.
        /// </summary>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithBrandNewConfiguration()
        {
            return this.WithBrandNewConfiguration() as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot)
        {
            return this.WithConfigurationFromDeploymentSlot(deploymentSlot) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from a given web app.
        /// </summary>
        /// <param name="webApp">The web app to copy the configurations from.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromWebApp(IWebApp webApp)
        {
            return this.WithConfigurationFromWebApp(webApp) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromParent()
        {
            return this.WithConfigurationFromParent() as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        Microsoft.Azure.Management.AppService.Fluent.IWebApp Resource.Fluent.Core.IHasParent<IWebApp>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.AppService.Fluent.IWebApp;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetHostNameBindings()
        {
            return this.GetHostNameBindings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>;
        }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetPublishingProfile()
        {
            return this.GetPublishingProfile() as Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile;
        }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ResetSlotConfigurations()
        {
 
            this.ResetSlotConfigurations();
        }

        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetSourceControl()
        {
            return this.GetSourceControl() as Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl;
        }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Swap(string slotName)
        {
 
            this.Swap(slotName);
        }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ApplySlotConfigurations(string slotName)
        {
 
            this.ApplySlotConfigurations(slotName);
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Restart()
        {
 
            this.Restart();
        }
    }
}