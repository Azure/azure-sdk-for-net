// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebApp.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A web app definition allowing docker startup command to be specified.
    /// This will replace the "CMD" section in the Dockerfile.
    /// </summary>
    public interface IWithStartUpCommand  :
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate
    {
        /// <summary>
        /// Specifies the startup command.
        /// </summary>
        /// <param name="startUpCommand">Startup command to replace "CMD" in Dockerfile.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithStartUpCommand(string startUpCommand);
    }

    /// <summary>
    /// A web app update allowing docker hub credentials to be set.
    /// </summary>
    public interface IWithCredentials 
    {
        /// <summary>
        /// Specifies the username and password for Docker Hub.
        /// </summary>
        /// <param name="username">The username for Docker Hub.</param>
        /// <param name="password">The password for Docker Hub.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithStartUpCommand WithCredentials(string username, string password);
    }

    /// <summary>
    /// A web app update allowing docker image source to be specified.
    /// </summary>
    public interface IWithDockerContainerImage 
    {
        /// <summary>
        /// Specifies the docker container image to be a built in one.
        /// </summary>
        /// <param name="runtimeStack">The runtime stack installed on the image.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithBuiltInImage(RuntimeStack runtimeStack);

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithCredentials WithPrivateDockerHubImage(string imageAndTag);

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithStartUpCommand WithPublicDockerHubImage(string imageAndTag);

        /// <summary>
        /// Specifies the docker container image to be one from a private registry.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <param name="serverUrl">The URL to the private registry server.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithCredentials WithPrivateRegistryImage(string imageAndTag, string serverUrl);
    }

    /// <summary>
    /// The template for a web app update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithAppServicePlan,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithDockerContainerImage
    {
    }

    /// <summary>
    /// A web app update allowing app service plan to be set.
    /// </summary>
    public interface IWithAppServicePlan 
    {
        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithNewSharedAppServicePlan();

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithNewFreeAppServicePlan();

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithNewAppServicePlan(PricingTier pricingTier);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithNewAppServicePlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable);

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithExistingAppServicePlan(IAppServicePlan appServicePlan);
    }
}