// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    /// <summary>
    /// Represents a type used to create a <see cref="DelegatingHandler"/> to be used by the WebJobs Azure Storage clients.
    /// </summary>
    internal interface IDelegatingHandlerProvider
    {
        /// <summary>
        /// Creates a new <see cref="DelegatingHandler"/>.
        /// </summary>
        /// <returns>The <see cref="DelegatingHandler"/>.</returns>
        DelegatingHandler Create();
    }
}