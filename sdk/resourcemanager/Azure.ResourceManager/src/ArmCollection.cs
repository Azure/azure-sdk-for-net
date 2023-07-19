// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Base class representing collection of resources.
    /// </summary>
    public abstract class ArmCollection
    {
        private readonly ConcurrentDictionary<Type, object> _clientCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class for mocking.
        /// </summary>
        protected ArmCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="client"> The client to copy settings from. </param>
        /// <param name="id"> The id of the parent for the collection. </param>
        protected ArmCollection(ArmClient client, ResourceIdentifier id)
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
        protected bool TryGetApiVersion(ResourceType resourceType, out string apiVersion) => Client.TryGetApiVersion(resourceType, out apiVersion);

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
    }
}
