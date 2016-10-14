// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest
{
    /// <summary>
    /// Interface used to group operations of a ServiceClient.
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