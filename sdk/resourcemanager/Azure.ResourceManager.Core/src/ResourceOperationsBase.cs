// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class ResourceOperationsBase : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class for mocking.
        /// </summary>
        protected ResourceOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="operations"> The operations representing the resource. </param>
        protected ResourceOperationsBase(ResourceOperationsBase operations)
            : base(operations.ClientOptions, operations.Id, operations.Credential, operations.BaseUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="options"> The operations to copy options from. </param>
        /// <param name="resourceId">The resource that is the target of operations.</param>
        protected ResourceOperationsBase(ResourceOperationsBase options, ResourceIdentifier resourceId)
            : base(options.ClientOptions, resourceId, options.Credential, options.BaseUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resourceId"> The identifier of the resource that is the target of operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        protected ResourceOperationsBase(AzureResourceManagerClientOptions options, ResourceIdentifier resourceId, TokenCredential credential, Uri baseUri)
            : base(options, resourceId, credential, baseUri)
        {
        }
    }

    /// <summary>
    /// Base class for all operations over a resource
    /// </summary>
    /// <typeparam name="TOperations"> The type implementing operations over the resource. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public abstract class ResourceOperationsBase<TOperations> : ResourceOperationsBase
        where TOperations : ResourceOperationsBase<TOperations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TOperations}"/> class for mocking.
        /// </summary>
        protected ResourceOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TOperations}"/> class.
        /// </summary>
        /// <param name="genericOperations"> Generic ARMResourceOperations for this resource type. </param>
        protected ResourceOperationsBase(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TOperations}"/> class.
        /// </summary>
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ResourceOperationsBase(ResourceOperationsBase parentOperations, ResourceIdentifier id)
            : base(parentOperations, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TOperations}"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resourceId"> The identifier of the resource that is the target of operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        protected ResourceOperationsBase(AzureResourceManagerClientOptions options, ResourceIdentifier resourceId, TokenCredential credential, Uri baseUri)
            : base(options, resourceId, credential, baseUri)
        {
        }

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        public abstract ArmResponse<TOperations> Get(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets details for this resource from the service.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        protected virtual async Task<TOperations> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return (await GetAsync(cancellationToken).ConfigureAwait(false)).Value;
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected IEnumerable<LocationData> ListAvailableLocations(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            var pageableProvider = ResourcesClient.Providers.List(expand: "metadata", cancellationToken: cancellationToken);
            var resourcePageableProvider = pageableProvider.FirstOrDefault(p => string.Equals(p.Namespace, resourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase));
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => (LocationData)l);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            var pageableProvider = ResourcesClient.Providers.ListAsync(expand: "metadata", cancellationToken: cancellationToken);
            var resourcePageableProvider = await pageableProvider.FirstOrDefaultAsync(
                p => string.Equals(p.Namespace, resourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase),
                cancellationToken).ConfigureAwait(false);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => (LocationData)l);
        }
    }
}
