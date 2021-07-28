﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class ResourceOperations
    {
        private TagResourceContainer _tagContainer;
        private TagResourceOperations _tagResourceOperations;
        private TenantOperations _tenant;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperations"/> class for mocking.
        /// </summary>
        protected ResourceOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperations"/> class.
        /// </summary>
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ResourceOperations(ResourceOperations parentOperations, ResourceIdentifier id)
            : this(new ClientContext(parentOperations.ClientOptions, parentOperations.Credential, parentOperations.BaseUri, parentOperations.Pipeline), id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperations"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceOperations(ClientContext clientContext, ResourceIdentifier id)
        {
            ClientOptions = clientContext.ClientOptions;
            Id = id;
            Credential = clientContext.Credential;
            BaseUri = clientContext.BaseUri;
            Pipeline = clientContext.Pipeline;
            Diagnostics = new ClientDiagnostics(ClientOptions);
            ValidateResourceType(id);
        }

        internal ClientDiagnostics Diagnostics { get; }

        private TenantOperations Tenant => _tenant ??= new TenantOperations(ClientOptions, Credential, BaseUri, Pipeline);

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the Azure Resource Manager client options.
        /// </summary>
        protected internal virtual ArmClientOptions ClientOptions { get; private set; }

        /// <summary>
        /// Gets the Azure credential.
        /// </summary>
        protected internal virtual TokenCredential Credential { get; private set; }

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        protected internal virtual Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets the HTTP pipeline.
        /// </summary>
        protected internal virtual HttpPipeline Pipeline { get; }

        /// <summary>
        /// Gets the valid Azure resource type for the current operations.
        /// </summary>
        /// <returns> A valid Azure resource type. </returns>
        protected abstract ResourceType ValidResourceType { get; }

        /// <summary>
        /// Gets the TagResourceOperations.
        /// </summary>
        /// <returns> A TagResourceOperations. </returns>
        protected internal TagResourceOperations TagResourceOperations => _tagResourceOperations ??= new TagResourceOperations(this, Id);

        /// <summary>
        /// Gets the TagsOperations.
        /// </summary>
        protected internal TagResourceContainer TagContainer => _tagContainer ??= new TagResourceContainer(this);

        /// <summary>
        /// Validate the resource identifier against current operations.
        /// </summary>
        /// <param name="identifier"> The resource identifier. </param>
        protected virtual void ValidateResourceType(ResourceIdentifier identifier)
        {
            if (identifier?.ResourceType != ValidResourceType)
                throw new ArgumentException($"Invalid resource type {identifier?.ResourceType} expected {ValidResourceType}");
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected IEnumerable<Location> ListAvailableLocations(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            ProviderInfo resourcePageableProvider = Tenant.GetProvider(resourceType.Namespace, null, cancellationToken);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => (Location)l);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected async Task<IEnumerable<Location>> ListAvailableLocationsAsync(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            ProviderInfo resourcePageableProvider = await Tenant.GetProviderAsync(resourceType.Namespace, null, cancellationToken).ConfigureAwait(false);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => (Location)l);
        }
    }
}
