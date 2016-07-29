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
    /// A generic resource definition allowing region to be specified.
    /// </summary>
    public interface IDefinitionBlank  :
        IDefinitionWithRegion<IDefinitionWithGroup>
    {
    }
    /// <summary>
    /// A generic resource definition allowing parent resource to be specified.
    /// </summary>
    public interface IDefinitionWithOrWithoutParentResource  :
        IDefinitionWithPlan
    {
        /// <summary>
        /// Specifies the parent resource.
        /// </summary>
        /// <param name="parentResourceId">parentResourceId the parent resource id</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IDefinitionWithPlan WithParentResource (string parentResourceId);

    }
    /// <summary>
    /// A generic resource definition allowing resource type to be specified.
    /// </summary>
    public interface IDefinitionWithResourceType 
    {
        /// <summary>
        /// Specifies the resource's type.
        /// </summary>
        /// <param name="resourceType">resourceType the type of the resources</param>
        /// <returns>the next stage of generic resource definition</returns>
        IDefinitionWithProviderNamespace WithResourceType (string resourceType);

    }
    /// <summary>
    /// A generic resource definition allowing provider namespace to be specified.
    /// </summary>
    public interface IDefinitionWithProviderNamespace 
    {
        /// <summary>
        /// Specifies the resource provider's namespace.
        /// </summary>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace the namespace of the resource provider</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IDefinitionWithOrWithoutParentResource WithProviderNamespace (string resourceProviderNamespace);

    }
    /// <summary>
    /// A generic resource definition allowing resource group to be specified.
    /// </summary>
    public interface IDefinitionWithGroup  :
        IWithGroup<IDefinitionWithResourceType>
    {
    }
    /// <summary>
    /// A generic resource definition allowing plan to be specified.
    /// </summary>
    public interface IDefinitionWithPlan 
    {
        /// <summary>
        /// Specifies the plan of the resource. The plan can only be set for 3rd party resources.
        /// </summary>
        /// <param name="name">name the name of the plan</param>
        /// <param name="publisher">publisher the publisher of the plan</param>
        /// <param name="product">product the name of the product</param>
        /// <param name="promotionCode">promotionCode the promotion code, if any</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IDefinitionWithApiVersion WithPlan (string name, string publisher, string product, string promotionCode);

        /// <summary>
        /// Specifies the plan of the resource.
        /// </summary>
        /// <returns>the next stage of the generic resource definition</returns>
        IDefinitionWithApiVersion WithoutPlan { get; }

    }
    /// <summary>
    /// A deployment definition with sufficient inputs to create a new
    /// resource in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IDefinitionCreatable  :
        ICreatable<IGenericResource>,
        IDefinitionWithTags<IDefinitionCreatable>
    {
        /// <summary>
        /// Specifies other properties.
        /// </summary>
        /// <param name="properties">properties the properties object</param>
        /// <returns>the next stage of generic resource definition</returns>
        IDefinitionCreatable WithProperties (object properties);

    }
    /// <summary>
    /// A generic resource definition allowing api version to be specified.
    /// </summary>
    public interface IDefinitionWithApiVersion 
    {
        /// <summary>
        /// Specifies the api version.
        /// </summary>
        /// <param name="apiVersion">apiVersion the API version of the resource</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IDefinitionCreatable WithApiVersion (string apiVersion);

    }
}