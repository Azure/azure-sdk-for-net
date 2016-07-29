/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{

    using Microsoft.Rest;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The base interface for all template interfaces that support update operations.
    /// 
    /// @param <T> the type of the resource returned from the update.
    /// </summary>
    public interface IAppliable<T>  :
        IIndexable
    {
        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        T Apply ();

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <param name="multiThreaded">multiThreaded use mutli-threading</param>
        /// <returns>the handle to the REST call</returns>
        Task<T> ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true);

    }
}