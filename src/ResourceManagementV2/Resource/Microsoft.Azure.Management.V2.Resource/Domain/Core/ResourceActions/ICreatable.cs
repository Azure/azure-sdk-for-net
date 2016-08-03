/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{

    using Microsoft.Rest;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The final stage of the resource definition, at which it can be create, using {@link #create()}.
    /// 
    /// @param <T> the fluent type of the resource to be created
    /// </summary>
    public interface ICreatable<T>  :
        IIndexable
    {
        /// <summary>
        /// Execute the create request.
        /// </summary>
        /// <returns>the create resource</returns>
        T Create ();

        /// <summary>
        /// Puts the request into the queue and allow the HTTP client to execute
        /// it when system resources are available.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <param name="multiThreaded">multiThreaded use mutli-threading</param>
        /// <returns>a handle to cancel the request</returns>
        Task<T> CreateAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true);

    }
}