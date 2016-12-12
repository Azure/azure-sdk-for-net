// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Models;

    /// <summary>
    /// Base interfaces for fluent resources.
    /// </summary>
    public interface IResource  :
        IIndexable,
        IHasId,
        IHasName
    {
        /// <returns>the type of the resource</returns>
        string Type { get; }

        /// <returns>the name of the region the resource is in</returns>
        string RegionName { get; }

        /// <returns>the region the resource is in</returns>
        Region Region { get; }

        /// <returns>the tags for the resource</returns>
        IReadOnlyDictionary<string,string> Tags { get; }
    }
}