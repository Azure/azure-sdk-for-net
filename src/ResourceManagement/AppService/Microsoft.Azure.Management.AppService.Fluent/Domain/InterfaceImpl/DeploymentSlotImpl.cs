// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
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
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithBrandNewConfiguration()
        {
            return this.WithBrandNewConfiguration() as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot)
        {
            return this.WithConfigurationFromDeploymentSlot(deploymentSlot) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from a given web app.
        /// </summary>
        /// <param name="webApp">The web app to copy the configurations from.</param>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromWebApp(IWebApp webApp)
        {
            return this.WithConfigurationFromWebApp(webApp) as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot> DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromParent()
        {
            return this.WithConfigurationFromParent() as WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>;
        }

        Microsoft.Azure.Management.Appservice.Fluent.IWebApp Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Appservice.Fluent.IWebApp;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IHostNameBinding> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.GetHostNameBindings()
        {
            return this.GetHostNameBindings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IHostNameBinding>;
        }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        Microsoft.Azure.Management.Appservice.Fluent.IPublishingProfile Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.GetPublishingProfile()
        {
            return this.GetPublishingProfile() as Microsoft.Azure.Management.Appservice.Fluent.IPublishingProfile;
        }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.ResetSlotConfigurations()
        {
 
            this.ResetSlotConfigurations();
        }

        Microsoft.Azure.Management.Appservice.Fluent.IWebAppSourceControl Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.GetSourceControl()
        {
            return this.GetSourceControl() as Microsoft.Azure.Management.Appservice.Fluent.IWebAppSourceControl;
        }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.Swap(string slotName)
        {
 
            this.Swap(slotName);
        }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.ApplySlotConfigurations(string slotName)
        {
 
            this.ApplySlotConfigurations(slotName);
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        async Task Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<Microsoft.Azure.Management.Appservice.Fluent.IDeploymentSlot>.Restart()
        {
 
            this.Restart();
        }
    }
}