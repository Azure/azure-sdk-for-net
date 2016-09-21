using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// Represents an external child resource.
    /// @param <T> fluent type of the external child resource
    /// </summary>
    public interface IExternalChildResource<T> : IChildResource, IRefreshable<T>
    {
        /// <returns>the id of the external child resource</returns>
        string Id { get; }
    }
}
