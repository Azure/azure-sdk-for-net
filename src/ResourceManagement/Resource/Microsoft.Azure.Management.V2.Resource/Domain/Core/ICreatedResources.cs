// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// Represents result of batch of create operations.
    /// (Note: this interface is not intended to be implemented by user code)
    /// </summary>
    /// <typeparam name="ResourceT">the type of the resource in this batch</typeparam>
    public interface ICreatedResources<ResourceT> : IEnumerable<ResourceT>
        where ResourceT : IResource
    {
        /// <summary>
        /// Gets a created resource with the given key.
        /// </summary>
        /// <param name="key">the key of the resource</param>
        /// <returns>the created resource</returns>
        IResource CreatedRelatedResource(string key);
    }
}
