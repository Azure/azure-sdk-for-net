/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using Microsoft.Azure.Management.V2.Resource.Core;

    /// <summary>
    /// Provides access to listing Azure resources of a specific type in a subscription.
    /// <p>
    /// (Note: this interface is not intended to be implemented by user code)
    /// 
    /// @param <T> the fluent type of the resource
    /// </summary>
    public interface ISupportsListing<T> 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        PagedList<T> List ();

    }
}