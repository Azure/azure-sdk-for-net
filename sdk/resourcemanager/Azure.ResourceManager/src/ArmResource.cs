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

namespace Azure.ResourceManager
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract partial class ArmResource
    {
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
        protected internal DiagnosticsOptions Diagnostics => Client.Diagnostics;

        /// <summary>
        /// Gets the pipeline for this resource client.
        /// </summary>
        protected internal HttpPipeline Pipeline => Client.Pipeline;

        /// <summary>
        /// Gets the base uri for this resource client.
        /// </summary>
        protected internal Uri Endpoint => Client.Endpoint;

        /// <summary>
        /// Gets the api version override if it has been set for the current client options.
        /// </summary>
        /// <param name="resourceType"> The resource type to get the version for. </param>
        /// <param name="apiVersion"> The api version to variable to set. </param>
        protected virtual bool TryGetApiVersion(ResourceType resourceType, out string apiVersion) => Client.TryGetApiVersion(resourceType, out apiVersion);

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Response<IEnumerable<AzureLocation>> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            string nameSpace = Id.ResourceType.Namespace;
            string type = Id.ResourceType.Type;
            Response<TenantResourceProvider> resourcePageableProviderResponse = Client.GetTenantResourceProvider(nameSpace, null, cancellationToken);
            TenantResourceProvider resourcePageableProvider = resourcePageableProviderResponse.Value;
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{type} not found for {nameSpace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => type.Equals(r.ResourceType, StringComparison.Ordinal));
            if (theResource is null)
                throw new InvalidOperationException($"{type} not found for {nameSpace}");
            return Response.FromValue(theResource.Locations.Select(l => new AzureLocation(l)), resourcePageableProviderResponse.GetRawResponse());
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<IEnumerable<AzureLocation>>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            string nameSpace = Id.ResourceType.Namespace;
            string type = Id.ResourceType.Type;
            Response<TenantResourceProvider> resourcePageableProviderResponse = await Client.GetTenantResourceProviderAsync(nameSpace, null, cancellationToken).ConfigureAwait(false);
            TenantResourceProvider resourcePageableProvider = resourcePageableProviderResponse.Value;
            if (resourcePageableProvider is null)
                throw new InvalidOperationException($"{type} not found for {nameSpace}");
            var theResource = resourcePageableProvider.ResourceTypes.FirstOrDefault(r => type.Equals(r.ResourceType, StringComparison.Ordinal));
            if (theResource is null)
                throw new InvalidOperationException($"{type} not found for {nameSpace}");
            return Response.FromValue(theResource.Locations.Select(l => new AzureLocation(l)), resourcePageableProviderResponse.GetRawResponse());
        }

        /// <summary>
        /// Gets a cached client to use for extension methods.
        /// </summary>
        /// <typeparam name="T"> The type of client to get. </typeparam>
        /// <param name="clientFactory"> The constructor factory for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(Func<ArmClient, T> clientFactory)
            where T : class
        {
            return _clientCache.GetOrAdd(typeof(T), (type) => { return clientFactory(Client); }) as T;
        }

        /// <summary>
        /// Checks to see if the TagResource API is deployed in the current environment.
        /// </summary>
        protected virtual bool CanUseTagResource(CancellationToken cancellationToken = default) => Client.CanUseTagResource(cancellationToken);

        /// <summary>
        /// Checks to see if the TagResource API is deployed in the current environment.
        /// </summary>
        protected virtual Task<bool> CanUseTagResourceAsync(CancellationToken cancellationToken = default) => Client.CanUseTagResourceAsync(cancellationToken);
    }
}
