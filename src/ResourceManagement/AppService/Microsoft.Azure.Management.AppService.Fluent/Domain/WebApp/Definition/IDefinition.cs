// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;

    /// <summary>
    /// A web app definition allowing app service plan to be set.
    /// </summary>
    public interface IWithNewAppServicePlan 
    {
        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewSharedAppServicePlan();

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithNewLinuxPlan(PricingTier pricingTier);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithNewLinuxPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewWindowsPlan(PricingTier pricingTier);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewWindowsPlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable);

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewFreeAppServicePlan();
    }

    /// <summary>
    /// A web app definition allowing docker registry credentials to be set.
    /// </summary>
    public interface IWithCredentials 
    {
        /// <summary>
        /// Specifies the username and password for Docker Hub or the docker registry.
        /// </summary>
        /// <param name="username">The username for Docker Hub or the docker registry.</param>
        /// <param name="password">The password for Docker Hub or the docker registry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithStartUpCommand WithCredentials(string username, string password);
    }

    /// <summary>
    /// A web app definition allowing resource group to be specified when an existing app service plan is used.
    /// </summary>
    public interface INewAppServicePlanWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithNewAppServicePlan>
    {
    }

    /// <summary>
    /// A web app definition allowing docker startup command to be specified.
    /// This will replace the "CMD" section in the Dockerfile.
    /// </summary>
    public interface IWithStartUpCommand  :
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies the startup command.
        /// </summary>
        /// <param name="startUpCommand">Startup command to replace "CMD" in Dockerfile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithStartUpCommand(string startUpCommand);
    }

    /// <summary>
    /// A web app definition allowing resource group to be specified when a new app service plan is to be created.
    /// </summary>
    public interface IExistingLinuxPlanWithGroup 
    {
        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// </summary>
        /// <param name="name">The name of the new group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithNewResourceGroup(string name);

        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// The group's name is automatically derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithNewResourceGroup();

        /// <summary>
        /// Creates a new resource group to put the resource in, based on the definition specified.
        /// </summary>
        /// <param name="groupDefinition">A creatable definition for a new resource group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithNewResourceGroup(ICreatable<Microsoft.Azure.Management.ResourceManager.Fluent.IResourceGroup> groupDefinition);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="groupName">The name of an existing resource group to put this resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithExistingResourceGroup(string groupName);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="group">An existing resource group to put the resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage WithExistingResourceGroup(IResourceGroup group);
    }

    /// <summary>
    /// A web app definition allowing resource group to be specified when a new app service plan is to be created.
    /// </summary>
    public interface IExistingWindowsPlanWithGroup 
    {
        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// </summary>
        /// <param name="name">The name of the new group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewResourceGroup(string name);

        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// The group's name is automatically derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewResourceGroup();

        /// <summary>
        /// Creates a new resource group to put the resource in, based on the definition specified.
        /// </summary>
        /// <param name="groupDefinition">A creatable definition for a new resource group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithNewResourceGroup(ICreatable<Microsoft.Azure.Management.ResourceManager.Fluent.IResourceGroup> groupDefinition);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="groupName">The name of an existing resource group to put this resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithExistingResourceGroup(string groupName);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="group">An existing resource group to put the resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithExistingResourceGroup(IResourceGroup group);
    }

    /// <summary>
    /// The first stage of the web app definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.INewAppServicePlanWithGroup>
    {
        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IExistingLinuxPlanWithGroup WithExistingLinuxPlan(IAppServicePlan appServicePlan);

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IExistingWindowsPlanWithGroup WithExistingWindowsPlan(IAppServicePlan appServicePlan);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.INewAppServicePlanWithGroup,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithNewAppServicePlan,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithDockerContainerImage,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCredentials,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithStartUpCommand,
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A web app definition allowing docker image source to be specified.
    /// </summary>
    public interface IWithDockerContainerImage 
    {
        /// <summary>
        /// Specifies the docker container image to be a built in one.
        /// </summary>
        /// <param name="runtimeStack">The runtime stack installed on the image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCreate WithBuiltInImage(RuntimeStack runtimeStack);

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCredentials WithPrivateDockerHubImage(string imageAndTag);

        /// <summary>
        /// Specifies the docker container image to be one from Docker Hub.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithStartUpCommand WithPublicDockerHubImage(string imageAndTag);

        /// <summary>
        /// Specifies the docker container image to be one from a private registry.
        /// </summary>
        /// <param name="imageAndTag">Image and optional tag (eg 'image:tag').</param>
        /// <param name="serverUrl">The URL to the private registry server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithCredentials WithPrivateRegistryImage(string imageAndTag, string serverUrl);
    }

    /// <summary>
    /// A site definition with sufficient inputs to create a new web app /
    /// deployments slot in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IWebApp>
    {
    }
}