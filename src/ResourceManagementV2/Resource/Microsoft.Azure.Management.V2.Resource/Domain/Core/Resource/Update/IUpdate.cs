/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.Resource.Update
{

    using System.Collections.Generic;

    /// <summary>
    /// An update allowing tags to be modified for the resource.
    /// 
    /// @param <T> the type of the next stage resource update
    /// </summary>
    public interface IUpdateWithTags<T> 
    {
        /// <summary>
        /// Specifies tags for the resource as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the resource update</returns>
        T WithTags (IDictionary<string,string> tags);

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the resource update</returns>
        T WithTag (string key, string value);

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">key the key of the tag to remove</param>
        /// <returns>the next stage of the resource update</returns>
        T WithoutTag (string key);

    }
}