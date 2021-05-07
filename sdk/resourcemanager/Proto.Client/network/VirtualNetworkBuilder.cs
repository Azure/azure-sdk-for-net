// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing a builder object used to create Azure resources.
    /// </summary>
    public class VirtualNetworkBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetworkBuilder"/> class.
        /// </summary>
        /// <param name="container"> The container object to create the resource in. </param>
        /// <param name="resource"> The resource to create. </param>
        public VirtualNetworkBuilder(VirtualNetworkContainer container, VirtualNetworkData resource)
        {
            Resource = resource;
            UnTypedContainer = container;
        }

        /// <summary>
        /// Gets the resource object to create.
        /// </summary>
        protected VirtualNetworkData Resource { get; private set; }

        /// <summary>
        /// Gets the resource name.
        /// </summary>
        protected string ResourceName { get; private set; }

        /// <summary>
        /// Gets the container object to create the resource in.
        /// </summary>
        protected VirtualNetworkContainer UnTypedContainer { get; private set; }

        /// <summary>
        /// Creates the resource object to send to the Azure API.
        /// </summary>
        /// <returns> The resource to create. </returns>
        public VirtualNetworkData Build()
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{VirtualNetwork}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        public ArmResponse<VirtualNetwork> CreateOrUpdate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            ResourceName = name;
            Resource = Build();

            return UnTypedContainer.CreateOrUpdate(name, Resource, cancellationToken);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{VirtualNetwork}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        public async Task<ArmResponse<VirtualNetwork>> CreateOrUpdateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            ResourceName = name;
            Resource = Build();

            return await UnTypedContainer.CreateOrUpdateAsync(name, Resource, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="ArmOperation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        public ArmOperation<VirtualNetwork> StartCreateOrUpdate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            ResourceName = name;
            Resource = Build();

            return UnTypedContainer.StartCreateOrUpdate(name, Resource, cancellationToken);
        }

        /// <summary>
        /// The operation to create or update a resource. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the new resource to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualNetwork}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        public async Task<ArmOperation<VirtualNetwork>> StartCreateOrUpdateAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

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
