// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Base class for all extensions
    /// </summary>
    public abstract class ExtensionResourceOperationsBase : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="genericOperations"> The operations to copy the client options from. </param>
        internal ExtensionResourceOperationsBase(OperationsBase genericOperations)
            : this(new ClientContext(genericOperations.ClientOptions, genericOperations.Credential, genericOperations.BaseUri), genericOperations.Id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the extension resource. </param>
        internal ExtensionResourceOperationsBase(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, id)
        {
        }
    }

    /// <summary>
    /// Separate Extension resources from non-extension resources
    /// </summary>
    /// <typeparam name="TOperations">The typed operations class for a specific resource.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Resource types that differ by Type arguments")]
    public abstract class ExtensionResourceOperationsBase<TOperations> : ExtensionResourceOperationsBase
        where TOperations : ExtensionResourceOperationsBase<TOperations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceOperationsBase{TOperations}"/> class.
        /// </summary>
        /// <param name="genericOperations"> The operations to copy the client options from. </param>
        protected ExtensionResourceOperationsBase(OperationsBase genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResourceOperationsBase{TOperations}"/> class.
        /// </summary>
        /// <param name="genericOperations"> The operations to copy the client options from. </param>
        /// <param name="id"> The identifier of the extension resource. </param>
        protected ExtensionResourceOperationsBase(OperationsBase genericOperations, ResourceIdentifier id)
            : base(new ClientContext(genericOperations.ClientOptions, genericOperations.Credential, genericOperations.BaseUri), id)
        {
        }

        /// <summary>
        /// Get details and operations for this extension resource.  This call will block the thread until details are returned from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing cancellation of the Http call in the task. </param>
        /// <returns> An Http Response containing details and operations for the extension resource. </returns>
        public abstract ArmResponse<TOperations> Get(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get details and operations for this extension resource.  This call returns a Task that completes when the details are returned from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing cancellation of the Http call in the task. </param>
        /// <returns> A Task that retrieves the resource details. When complete, the task will yield an Http Response
        /// containing details and operations for the extension resource. </returns>
        public abstract Task<ArmResponse<TOperations>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get details for this resource from the service or can be overriden to provide a cached instance.
        /// </summary>
        /// <returns> A <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        protected virtual TOperations GetResource()
        {
            return Get().Value;
        }

        /// <summary>
        /// Get details for this resource from the service or can be overriden to provide a cached instance.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing cancellation of the Http call in the task. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        protected virtual async Task<TOperations> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return (await GetAsync(cancellationToken).ConfigureAwait(false)).Value;
        }
    }
}
