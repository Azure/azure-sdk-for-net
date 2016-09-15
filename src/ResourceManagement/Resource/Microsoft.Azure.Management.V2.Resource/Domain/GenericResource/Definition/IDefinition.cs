/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.GenericResource.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefintion :
        IBlank,
        IWithGroup,
        IWithResourceType,
        IWithProviderNamespace,
        IWithParentResource,
        IWithPlan,
        IWithApiVersion,
        IWithCreate
    {
    }

    /// <summary>
    /// A generic resource definition allowing region to be specified.
    /// </summary>
    public interface IBlank  :
        Resource.Core.Resource.Definition.IDefinitionWithRegion<IWithGroup>
    {
    }

    /// <summary>
    /// A generic resource definition allowing parent resource to be specified.
    /// </summary>
    public interface IWithParentResource
    {
        /// <summary>
        /// Specifies the parent resource.
        /// </summary>
        /// <param name="parentResourceId">parentResourceId the parent resource id</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IWithCreate WithParentResource (string parentResourceId);

    }
    /// <summary>
    /// A generic resource definition allowing resource type to be specified.
    /// </summary>
    public interface IWithResourceType 
    {
        /// <summary>
        /// Specifies the resource's type.
        /// </summary>
        /// <param name="resourceType">resourceType the type of the resources</param>
        /// <returns>the next stage of generic resource definition</returns>
        IWithProviderNamespace WithResourceType (string resourceType);

    }
    /// <summary>
    /// A generic resource definition allowing provider namespace to be specified.
    /// </summary>
    public interface IWithProviderNamespace 
    {
        /// <summary>
        /// Specifies the resource provider's namespace.
        /// </summary>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace the namespace of the resource provider</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IWithPlan WithProviderNamespace (string resourceProviderNamespace);

    }
    /// <summary>
    /// A generic resource definition allowing resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Resource.Core.GroupableResource.Definition.IWithGroup<IWithResourceType>
    {
    }

    /// <summary>
    /// A generic resource definition allowing plan to be specified.
    /// </summary>
    public interface IWithPlan 
    {
        /// <summary>
        /// Specifies the plan of the resource. The plan can only be set for 3rd party resources.
        /// </summary>
        /// <param name="name">name the name of the plan</param>
        /// <param name="publisher">publisher the publisher of the plan</param>
        /// <param name="product">product the name of the product</param>
        /// <param name="promotionCode">promotionCode the promotion code, if any</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IWithApiVersion WithPlan (string name, string publisher, string product, string promotionCode);

        /// <summary>
        /// Specifies the plan of the resource.
        /// </summary>
        /// <returns>the next stage of the generic resource definition</returns>
        IWithApiVersion WithoutPlan();

    }
    /// <summary>
    /// A deployment definition with sufficient inputs to create a new
    /// resource in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        IWithParentResource,
        ICreatable<IGenericResource>,
        IDefinitionWithTags<IWithCreate>
    {
        /// <summary>
        /// Specifies other properties.
        /// </summary>
        /// <param name="properties">properties the properties object</param>
        /// <returns>the next stage of generic resource definition</returns>
        IWithCreate WithProperties (object properties);

    }
    /// <summary>
    /// A generic resource definition allowing api version to be specified.
    /// </summary>
    public interface IWithApiVersion 
    {
        /// <summary>
        /// Specifies the api version.
        /// </summary>
        /// <param name="apiVersion">apiVersion the API version of the resource</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IWithCreate WithApiVersion (string apiVersion);

    }
}