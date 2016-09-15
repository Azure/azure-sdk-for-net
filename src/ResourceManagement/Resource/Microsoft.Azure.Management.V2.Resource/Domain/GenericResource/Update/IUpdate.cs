/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.GenericResource.Update
{
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;

    /// <summary>
    /// A generic resource update allowing to change the resource properties.
    /// </summary>
    public interface IWithProperties
    {
        /// <summary>
        /// Specifies other properties of the resource.
        /// </summary>
        /// <param name="properties">properties the properties object</param>
        /// <returns>the next stage of generic resource update</returns>
        IUpdate WithProperties (object properties);

    }
    /// <summary>
    /// A generic resource update allowing to change the resource plan.
    /// </summary>
    public interface IWithPlan 
    {
        /// <summary>
        /// Specifies the plan of the resource.
        /// </summary>
        /// <param name="name">name the name of the plan</param>
        /// <param name="publisher">publisher the publisher of the plan</param>
        /// <param name="product">product the name of the product</param>
        /// <param name="promotionCode">promotionCode the promotion code, if any</param>
        /// <returns>the next stage of the generic resource update</returns>
        IUpdate WithPlan (string name, string publisher, string product, string promotionCode);

        /// <summary>
        /// Specifies the plan of the resource.
        /// </summary>
        /// <returns>the next stage of the generic resource update</returns>
        IUpdate WithoutPlan();

    }
    /// <summary>
    /// A generic resource update allowing to change the parent resource.
    /// </summary>
    public interface IWithParentResource 
    {
        /// <summary>
        /// Specifies the parent resource.
        /// </summary>
        /// <param name="parentResourceId">parentResourceId the parent resource ID</param>
        /// <returns>the next stage of the generic resource definition</returns>
        IUpdate WithParentResource (string parentResourceId);

    }
    /// <summary>
    /// The template for a generic resource update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IGenericResource>,
        IWithPlan,
        IWithParentResource,
        IWithProperties,
        IUpdateWithTags<IUpdate>
    {
    }
    /// <summary>
    /// The template for a generic resource update operation for specifying the resource provider API version.
    /// </summary>
    public interface IWithApiVersion 
    {
        /// <summary>
        /// Specifies the API version of the resource provider.
        /// </summary>
        /// <param name="apiVersion">apiVersion the API version</param>
        /// <returns>the next stage of the generic resource update</returns>
        IUpdate WithApiVersion (string apiVersion);

    }
}