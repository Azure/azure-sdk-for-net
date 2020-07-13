// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    /// <summary>
    /// Represents a type used to create a <see cref="DelegatingHandler"/> to be used by the WebJobs Azure Storage clients.
    /// </summary>
    public interface IDelegatingHandlerProvider
    {
        /// <summary>
        /// Creates a new <see cref="DelegatingHandler"/>.
        /// </summary>
        /// <returns>The <see cref="DelegatingHandler"/>.</returns>
        DelegatingHandler Create();
    }
}
