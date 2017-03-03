// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;

namespace Hyak.Common
{
    /// <summary>
    /// Interface used to represent resource groupings of ServiceClient 
    /// operations.
    /// </summary>
    /// <typeparam name="TClient">Type of the ServiceClient.</typeparam>
    public interface IServiceOperations<TClient>
        where TClient : ServiceClient<TClient>
    {
        /// <summary>
        /// Gets a reference to the ServiceClient.
        /// </summary>
        TClient Client { get; }
    }
}
