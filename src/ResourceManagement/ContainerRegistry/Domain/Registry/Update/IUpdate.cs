// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IWithAdminUserEnabled
    {
    }

    /// <summary>
    /// The stage of the registry update allowing to enable admin user.
    /// </summary>
    public interface IWithAdminUserEnabled 
    {
        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithRegistryNameAsAdminUser();

        /// <summary>
        /// Disable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update.IUpdate WithoutRegistryNameAsAdminUser();
    }
}