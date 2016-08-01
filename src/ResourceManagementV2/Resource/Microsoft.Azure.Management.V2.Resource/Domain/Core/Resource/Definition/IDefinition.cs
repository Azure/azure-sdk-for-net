/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using System.Collections.Generic;

    /// <summary>
    /// A resource definition allowing a location be selected for the resource.
    /// 
    /// @param <T> the type of the next stage resource definition
    /// </summary>
    public interface IDefinitionWithRegion<T> 
    {
        /// <summary>
        /// Specifies the region for the resource by name.
        /// </summary>
        /// <param name="regionName">regionName The name of the region for the resource</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithRegion (string regionName);

        /// <summary>
        /// Specifies the region for the resource.
        /// </summary>
        /// <param name="region">region The location for the resource</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithRegion (Region region);

    }
    /// <summary>
    /// A resource definition allowing tags to be modified for the resource.
    /// 
    /// @param <T> the type of the next stage resource definition
    /// </summary>
    public interface IDefinitionWithTags<T> 
    {
        /// <summary>
        /// Specifies tags for the resource as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithTags (IDictionary<string,string> tags);

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the resource definition</returns>
        T WithTag (string key, string value);

    }
}