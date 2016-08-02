// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    ///  Model classes that implement this interface represent resources that are persisted with an ETag version on the server.
    /// </summary>
    public interface IResourceWithETag
    {
        /// <summary>
        /// Gets the ETag value for the resource.
        /// </summary>
        string ETag { get; }
    }
}
