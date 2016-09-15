/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{

    /// <summary>
    /// Base class for resources that can be refreshed to get the latest state.
    /// 
    /// @param <T> the fluent type of the resource
    /// </summary>
    public interface IRefreshable<T> 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        T Refresh ();

    }
}