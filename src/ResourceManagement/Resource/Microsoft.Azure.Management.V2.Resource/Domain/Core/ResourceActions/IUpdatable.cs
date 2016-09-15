/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{

    /// <summary>
    /// Base class for resource that can be updated.
    /// 
    /// @param <T> the fluent type of the resource
    /// </summary>
    public interface IUpdatable<T> 
    {
        /// <summary>
        /// Begins an update for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Appliable#apply()}.
        /// </summary>
        /// <returns>the stage of new resource update</returns>
        T Update ();

    }
}