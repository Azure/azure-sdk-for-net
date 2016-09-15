/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// Base interfaces for fluent resources.
    /// </summary>
    public interface IResource  :
        IIndexable
    {
        /// <returns>the resource ID string</returns>
        string Id { get; }

        /// <returns>the type of the resource</returns>
        string Type { get; }

        /// <returns>the name of the resource</returns>
        string Name { get; }

        /// <returns>the name of the region the resource is in</returns>
        string RegionName { get; }

        /// <returns>the region the resource is in</returns>
        Region Region { get; }

        /// <returns>the tags for the resource</returns>
        IDictionary<string,string> Tags { get; }

    }
}