/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource;

    /// <summary>
    /// A resource definition allowing a resource group to be selected.
    /// 
    /// @param <T> the next stage of the resource definition
    /// </summary>
    public interface IWithGroup<T>  :
        IWithExistingResourceGroup<T>,
        IWithNewResourceGroup<T>
    {
    }
    /// <summary>
    /// A resource definition allowing a new resource group to be created.
    /// 
    /// @param <T> the next stage of the resource definition
    /// </summary>
    public interface IWithNewResourceGroup<T> 
    {
        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// <p>
        /// The group will be created in the same location as the resource.
        /// </summary>
        /// <param name="name">name the name of the new group</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithNewResourceGroup (string name);

        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// <p>
        /// The group will be created in the same location as the resource.
        /// The group's name is automatically derived from the resource's name.
        /// </summary>
        /// <returns>the next stage of the resource definition</returns>
        T WithNewResourceGroup ();

        /// <summary>
        /// Creates a new resource group to put the resource in, based on the definition specified.
        /// </summary>
        /// <param name="groupDefinition">groupDefinition a creatable definition for a new resource group</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithNewResourceGroup (ICreatable<IResourceGroup> groupDefinition);

    }
    /// <summary>
    /// A resource definition allowing an existing resource group to be selected.
    /// 
    /// @param <T> the next stage of the resource definition
    /// </summary>
    public interface IWithExistingResourceGroup<T> 
    {
        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="groupName">groupName the name of an existing resource group to put this resource in.</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithExistingResourceGroup (string groupName);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="group">group an existing resource group to put the resource in</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithExistingResourceGroup (IResourceGroup group);

    }
}