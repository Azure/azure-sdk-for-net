/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Threading;
    using Microsoft.Rest;
    using System.Threading.Tasks;
    /// <summary>
    /// Providing access to creating a batch of Azure top level resources of same type.
    /// <p>
    /// (Note: this interface is not intended to be implemented by user code)
    /// @param <ResourceT> the top level Azure resource type
    /// </summary>
    public interface ISupportsBatchCreation<ResourceT> 
    {
        /*
        /// <summary>
        /// Executes the create requests on a collection (batch) of resources.
        /// </summary>
        /// <param name="creatables">creatables the creatables in the batch</param>
        /// <returns>the batch operation result from which created resources in this batch can be accessed.</returns>
        ICreatedResources<ResourceT> Create (params ICreatable<ResourceT>[] creatables);

        /// <summary>
        /// Executes the create requests on a collection (batch) of resources.
        /// </summary>
        /// <param name="creatables">creatables the list of creatables in the batch</param>
        /// <returns>the batch operation result from which created resources in this batch can be accessed.</returns>
        ICreatedResources<ResourceT> Create (List<Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.ICreatable<ResourceT>> creatables);

        /// <summary>
        /// Puts the requests to create a batch of resources into the queue and allow the HTTP client to execute it when
        /// system resources are available.
        /// </summary>
        /// <param name="creatables">creatables the creatables in the batch</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an observable for the resources</returns>
        Task CreateAsync (params ICreatable<ResourceT>[] creatables, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Puts the requests to create a batch of resources into the queue and allow the HTTP client to execute it when
        /// system resources are available.
        /// </summary>
        /// <param name="creatables">creatables the list of creatables in the batch</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an observable for the resources</returns>
        Task CreateAsync (List<Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.ICreatable<ResourceT>> creatables, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Puts the requests to create a batch of resources into the queue and allow the HTTP client to execute it when
        /// system resources are available.
        /// </summary>
        /// <param name="creatables">creatables the creatables in the batch</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>a handle to cancel the request</returns>
        Task<Microsoft.Azure.Management.V2.Resource.Core.ICreatedResources<ResourceT>> CreateAsync (params ICreatable<ResourceT>[] creatables, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Puts the requests to create a batch of resources into the queue and allow the HTTP client to execute it when
        /// system resources are available.
        /// </summary>
        /// <param name="creatables">creatables the list of creatables in the batch</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>a handle to cancel the request</returns>
        Task<Microsoft.Azure.Management.V2.Resource.Core.ICreatedResources<ResourceT>> CreateAsync (List<Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.ICreatable<ResourceT>> creatables, CancellationToken cancellationToken = default(CancellationToken));
        */
    }
}