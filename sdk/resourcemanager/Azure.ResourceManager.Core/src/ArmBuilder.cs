﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a builder object used to create Azure resources.
    /// </summary>
    /// <typeparam name="TOperations"> The type of the operations class for a specific resource. </typeparam>
    /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
    public class ArmBuilder<TOperations, TResource>
        where TResource : Resource
        where TOperations : ResourceOperationsBase<TOperations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmBuilder{TOperations, TResource}"/> class.
        /// </summary>
        /// <param name="container"> The container object to create the resource in. </param>
        /// <param name="resource"> The resource to create. </param>
        public ArmBuilder(ResourceContainerBase<TOperations, TResource> container, TResource resource)
        {
            Resource = resource;
            UnTypedContainer = container;
        }

        /// <summary>
        /// Gets the resource object to create.
        /// </summary>
        protected TResource Resource { get; private set; }

        /// <summary>
        /// Gets the resource name.
        /// </summary>
        protected string ResourceName { get; private set; }

        /// <summary>
        /// Gets the container object to create the resource in.
        /// </summary>
        protected ResourceContainerBase<TOperations, TResource> UnTypedContainer { get; private set; }

        /// <summary>
        /// Creates the resource object to send to the Azure API.
        /// </summary>
        /// <returns> The resource to create. </returns>
        public TResource Build()
        {
            ThrowIfNotValid();
            OnBeforeBuild();
            InternalBuild();
            OnAfterBuild();

            return Resource;
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <returns> A response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public ArmResponse<TOperations> CreateOrUpdate(string name)
        {
            ResourceName = name;
            Resource = Build();

            return UnTypedContainer.CreateOrUpdate(name, Resource);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public async Task<ArmResponse<TOperations>> CreateOrUpdateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            ResourceName = name;
            Resource = Build();

            return await UnTypedContainer.CreateOrUpdateAsync(name, Resource, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="ArmOperation{TOperations}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmOperation<TOperations> StartCreateOrUpdate(string name, CancellationToken cancellationToken = default)
        {
            ResourceName = name;
            Resource = Build();

            return UnTypedContainer.StartCreateOrUpdate(name, Resource, cancellationToken);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{TOperations}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public async Task<ArmOperation<TOperations>> StartCreateOrUpdateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            ResourceName = name;
            Resource = Build();

            return await UnTypedContainer.StartCreateOrUpdateAsync(name, Resource, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Determines whether or not the resource is valid.
        /// </summary>
        /// <param name="message"> The message indicating what is wrong with the resource. </param>
        /// <returns> Whether or not the resource is valid. </returns>
        protected virtual bool IsValid(out string message)
        {
            message = string.Empty;

            return true;
        }

        /// <summary>
        /// Perform any tasks necessary after the resource is built
        /// </summary>
        protected virtual void OnAfterBuild()
        {
        }

        /// <summary>
        /// Perform any tasks necessary before the resource is built
        /// </summary>
        protected virtual void OnBeforeBuild()
        {
        }

        private static void InternalBuild()
        {
        }

        private void ThrowIfNotValid()
        {
            if (!IsValid(out var message))
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
