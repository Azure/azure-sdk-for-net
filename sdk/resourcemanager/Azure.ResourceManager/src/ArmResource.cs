// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class ArmResource
    {
        private TagResource _tagResource;
        private Tenant _tenant;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResource"/> class for mocking.
        /// </summary>
        protected ArmResource()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResource"/> class.
        /// </summary>
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ArmResource(ArmResource parentOperations, ResourceIdentifier id)
            : this(parentOperations.ArmClient, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResource"/> class.
        /// </summary>
        /// <param name="armClient"> The <see cref="ArmClient"/> this resource client should be created from. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ArmResource(ArmClient armClient, ResourceIdentifier id)
        {
            Argument.AssertNotNull(id, nameof(id));

            ArmClient = armClient;
            Id = id;
        }

        private Tenant Tenant => _tenant ??= new Tenant(ArmClient);

        /// <summary>
        /// Gets the <see cref="ArmClient"/> this resource client was created from.
        /// </summary>
        protected internal virtual ArmClient ArmClient { get; }

        internal DiagnosticsOptions DiagnosticOptions => ArmClient.DiagnosticOptions;

        internal HttpPipeline Pipeline => ArmClient.Pipeline;

        internal Uri BaseUri => ArmClient.BaseUri;

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the TagResourceOperations.
        /// </summary>
        /// <returns> A TagResourceOperations. </returns>
        protected internal TagResource TagResource => _tagResource ??= new TagResource(this, Id);

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected IEnumerable<AzureLocation> ListAvailableLocations(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            ProviderInfo resourcePageableProvider = Tenant.GetTenantProvider(resourceType.Namespace, null, cancellationToken);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => new AzureLocation(l));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected async Task<IEnumerable<AzureLocation>> ListAvailableLocationsAsync(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            ProviderInfo resourcePageableProvider = await Tenant.GetTenantProviderAsync(resourceType.Namespace, null, cancellationToken).ConfigureAwait(false);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => new AzureLocation(l));
        }
    }
}
