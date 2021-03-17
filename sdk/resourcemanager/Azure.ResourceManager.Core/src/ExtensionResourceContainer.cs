// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Container for extension resources.  Because there is no CreateOrUpdate, there is a difference in the input and output model
    /// </summary>
    /// <typeparam name="TOperations"> Operations class returned. </typeparam>
    /// <typeparam name="TInput"> Input Model. </typeparam>
    public abstract class ExtensionResourceContainer<TOperations, TInput> : ExtensionResourceOperationsBase
        where TOperations : ExtensionResourceOperationsBase<TOperations>
        where TInput : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceContainer{TOperations, TInput}"/> class.
        /// Create an ResourceContainer from an operations class or client
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        protected ExtensionResourceContainer(OperationsBase operations)
            : base(operations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceContainer{TOperations, TInput}"/> class.
        /// </summary>
        /// <param name="operations"> The operations to copy the client options from. </param>
        /// <param name="parentId"> The resource Id of the parent resource. </param>
        protected ExtensionResourceContainer(OperationsBase operations, ResourceIdentifier parentId)
            : base(new ClientContext(operations.ClientOptions, operations.Credential, operations.BaseUri), parentId)
        {
        }

        /// <summary>
        /// Validate that the given resource Id represents a valid parent for this resource
        /// </summary>
        /// <param name="identifier"> The resource Id of the parent resource. </param>
        protected override void Validate(ResourceIdentifier identifier)
        {
        }

        /// <summary>
        /// Create a new extension resource at the given scope.  Block further execution on the current thread until creation is complete.
        /// </summary>
        /// <param name="name"> The name of the created extension resource. </param>
        /// <param name="resourceDetails"> The properties of the extension resource. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An Http envelope containing the operations for the given extension. </returns>
        public abstract ArmResponse<TOperations> Create(string name, TInput resourceDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new extension resource at the given scope without blocking the current thread.
        /// Returns a Task that allows control over when or if the thread is blocked.
        /// </summary>
        /// <param name="name">The name of the created extension resource. </param>
        /// <param name="resourceDetails">The properties of the extension resource. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>A Task that creates the extension resource. </returns>
        public abstract Task<ArmResponse<TOperations>> CreateAsync(string name, TInput resourceDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Begin Creation of a new extension resource. Block until the creation is accepted by the service.
        /// The returned object allows fine-grained control over waiting for creation to complete.
        /// </summary>
        /// <param name="name"> The name of the created extension resource. </param>
        /// <param name="resourceDetails"> The properties of the extension resource. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="ArmOperation{TOperation}"/>, allowing fine grained control over waiting for creation to complete. </returns>
        public abstract ArmOperation<TOperations> StartCreate(string name, TInput resourceDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Begin Creation of a new extension resource in a background task.
        /// When creation has successfully begin, the object returned from the completed task allows fine-grained control over waiting for creation to complete.
        /// </summary>
        /// <param name="name"> The name of the created extension resource. </param>
        /// <param name="resourceDetails"> The properties of the extension resource. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{TOperations}"/> that allows polling for completion of the operation. </returns>
        public abstract Task<ArmOperation<TOperations>> StartCreateAsync(string name, TInput resourceDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the extension resources at the current scope. Blocks until the first page of results is returned.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="Azure.Pageable{TOperations}"/> allowing paged or non-paged enumeration of results. </returns>
        public abstract Pageable<TOperations> ListAtScope(CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the extension resources at the current scope asynchronously. The returned task completes when the first page of results is returned.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token clients can use to cancel any blocking HTTP requests made by this method, including
        /// any Http requests that result from enumerating pages of results. </param>
        /// <returns> An instance of <see cref="Azure.AsyncPageable{TOperations}"/> allowing asynchronous paged or non-paged enumeration of results. </returns>
        public abstract AsyncPageable<TOperations> ListAtScopeAsync(CancellationToken cancellationToken = default);
    }
}
