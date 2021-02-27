// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    /// <typeparam name="TOperations"> The type of the class containing operations for the underlying resource. </typeparam>
    /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
    public abstract class ResourceContainerBase<TOperations, TResource> : ContainerBase<TOperations>
        where TOperations : ResourceOperationsBase<TOperations>
        where TResource : Resource
    {
        private static readonly object _parentLock = new object();
        private object _parentResource;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceContainerBase{TOperations, TData}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ResourceContainerBase(ResourceOperationsBase parent)
            : base(parent)
        {
        }

        /// <summary>
        /// Verify that the input resource Id is a valid container for this type.
        /// </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        /// <exception cref="InvalidOperationException"> Resource identifier is not a valid type for this container. </exception>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (identifier.Type != ValidResourceType)
                throw new InvalidOperationException($"{identifier.Type} is not a valid container for {Id.Type}");
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceDetails"> The desired resource configuration. </param>
        /// <returns> A response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public abstract ArmResponse<TOperations> CreateOrUpdate(
            string name,
            TResource resourceDetails);

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceDetails"> The desired resource configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public abstract Task<ArmResponse<TOperations>> CreateOrUpdateAsync(
            string name,
            TResource resourceDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceDetails"> The desired resource configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="ArmOperation{TOperations}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public abstract ArmOperation<TOperations> StartCreateOrUpdate(
            string name,
            TResource resourceDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceDetails"> The desired resource configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{TOperations}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public abstract Task<ArmOperation<TOperations>> StartCreateOrUpdateAsync(
            string name,
            TResource resourceDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the location of the parent object.
        /// </summary>
        /// <typeparam name="TParent"> The type of the parents full resource object. </typeparam>
        /// <typeparam name="TParentOperations"> The type of the parents operations object. </typeparam>
        /// <returns> The <see cref="LocationData"/> associated with the parent object. </returns>
        protected TParent GetParentResource<TParent, TParentOperations>()
            where TParent : TParentOperations
            where TParentOperations : ResourceOperationsBase<TParent>
        {
            if (_parentResource is null)
            {
                lock (_parentLock)
                {
                    if (_parentResource is null)
                    {
                        _parentResource = Parent as TParent;
                        if (_parentResource is null)
                        {
                            _parentResource = (Parent as TParentOperations).Get().Value;
                        }
                    }
                }
            }

            return _parentResource as TParent;
        }

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="resourceName"> The name of the resource to get. </param>
        /// <returns> A response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public abstract ArmResponse<TOperations> Get(string resourceName);

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="resourceName"> The name of the resource to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public abstract Task<ArmResponse<TOperations>> GetAsync(string resourceName, CancellationToken cancellationToken = default);
    }
}
