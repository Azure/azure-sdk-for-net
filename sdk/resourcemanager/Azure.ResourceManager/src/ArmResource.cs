// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
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
    public abstract partial class ArmResource
    {
        private TagResource _tagResource;
        private readonly ConcurrentDictionary<Type, object> _clientCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResource"/> class for mocking.
        /// </summary>
        protected ArmResource()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResource"/> class.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> this resource client should be created from. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ArmResource(ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(client, nameof(client));

            Client = client;
            Id = id;
        }

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the <see cref="ArmClient"/> this resource client was created from.
        /// </summary>
        protected internal virtual ArmClient Client { get; }

        /// <summary>
        /// Gets the diagnostic options for this resource client.
        /// </summary>
        protected internal DiagnosticsOptions DiagnosticOptions => Client.DiagnosticOptions;

        /// <summary>
        /// Gets the pipeline for this resource client.
        /// </summary>
        protected internal HttpPipeline Pipeline => Client.Pipeline;

        /// <summary>
        /// Gets the base uri for this resource client.
        /// </summary>
        protected internal Uri BaseUri => Client.BaseUri;

        /// <summary>
        /// Gets the TagResourceOperations.
        /// </summary>
        /// <returns> A TagResourceOperations. </returns>
        protected internal TagResource TagResource => _tagResource ??= new TagResource(Client, Id.AppendProviderResource("Microsoft.Resources", "tags", "default"));

        /// <summary>
        /// Gets the api version override if it has been set for the current client options.
        /// </summary>
        /// <param name="resourceType"> The resource type to get the version for. </param>
        /// <param name="apiVersion"> The api version to variable to set. </param>
        protected bool TryGetApiVersion(ResourceType resourceType, out string apiVersion) => Client.TryGetApiVersion(resourceType, out apiVersion);

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="resourceType"> The <see cref="ResourceType"/> instance to use for the list. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        protected IEnumerable<AzureLocation> ListAvailableLocations(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            ProviderInfo resourcePageableProvider = Client.GetTenantProvider(resourceType.Namespace, null, cancellationToken);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType, StringComparison.Ordinal));
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
            ProviderInfo resourcePageableProvider = await Client.GetTenantProviderAsync(resourceType.Namespace, null, cancellationToken).ConfigureAwait(false);
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Namespace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => resourceType.Type.Equals(r.ResourceType, StringComparison.Ordinal));
            if (theResource is null)
                throw new InvalidOperationException($"{resourceType.Type} not found for {resourceType.Type}");
            return theResource.Locations.Select(l => new AzureLocation(l));
        }

        /// <summary>
        /// Gets a cached client to use for extension methods.
        /// </summary>
        /// <typeparam name="T"> The type of client to get. </typeparam>
        /// <param name="func"> The constructor factory for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(Func<ArmClient, T> func)
            where T : class
        {
            return _clientCache.GetOrAdd(typeof(T), (type) => { return func(Client); }) as T;
        }
    }
}
