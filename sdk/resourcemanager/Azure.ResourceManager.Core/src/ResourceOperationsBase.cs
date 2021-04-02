// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Extensions;

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
        /// <param name="clientContext"></param>
        /// <param name="id"></param>
        internal ResourceOperationsBase(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, id)
        { 
        }
    }

    /// <summary>
    /// Base class for all operations over a resource
    /// </summary>
    /// <typeparam name="TOperations"> The type implementing operations over the resource. </typeparam>
    /// <typeparam name="TIdentifier"> The The identifier type for the resource. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public abstract class ResourceOperationsBase<TIdentifier, TOperations> : ResourceOperationsBase
        where TOperations : ResourceOperationsBase<TIdentifier, TOperations> where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TIdentifier, TOperations}"/> class for mocking.
        /// </summary>
        protected ResourceOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase{TIdentifier, TOperations}"/> class.
        /// </summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ResourceOperationsBase(OperationsBase parentOperations, ResourceIdentifier id)
            : base(new ClientContext(parentOperations.ClientOptions, parentOperations.Credential, parentOperations.BaseUri), id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"></param>
        internal ResourceOperationsBase(ClientContext clientContext, string id)
            : base(clientContext, id)
        {
        }

        /// <summary>
        /// The typed resource identifier for the underlying resource
        /// </summary>
        public virtual new TIdentifier Id
        {
            get { return base.Id as TIdentifier; }
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
