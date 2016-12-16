// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithConfiguration
    {
    }

    /// <summary>
    /// The first stage of the deployment slot definition.
    /// </summary>
    public interface IBlank  :
        IWithConfiguration
    {
    }

    /// <summary>
    /// A deployment slot definition allowing the configuration to clone from to be specified.
    /// </summary>
    public interface IWithConfiguration 
    {
        /// <summary>
        /// Copies the site configurations from a given web app.
        /// </summary>
        /// <param name="webApp">The web app to copy the configurations from.</param>
        /// <return>The next stage of the deployment slot definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WithConfigurationFromWebApp(IWebApp webApp);

        /// <summary>
        /// Creates the deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the deployment slot definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WithBrandNewConfiguration();

        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the deployment slot definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WithConfigurationFromParent();

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the deployment slot definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot);
    }
}