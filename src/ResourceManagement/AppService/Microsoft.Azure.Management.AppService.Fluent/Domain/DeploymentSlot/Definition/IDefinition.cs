// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithConfiguration,
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of the deployment slot definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithConfiguration
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate WithConfigurationFromWebApp(IWebApp webApp);

        /// <summary>
        /// Creates the deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate WithBrandNewConfiguration();

        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate WithConfigurationFromParent();

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition.IWithCreate WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot);
    }

    /// <summary>
    /// A site definition with sufficient inputs to create a new web app /
    /// deployments slot in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>
    {
    }
}