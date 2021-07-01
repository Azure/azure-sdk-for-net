// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public class TenantOperations : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantOperations"/> class for mocking.
        /// </summary>
        protected TenantOperations()
        {
        }

        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = ResourceType.RootResourceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        internal TenantOperations(ArmClientOptions options, TokenCredential credential, Uri baseUri, HttpPipeline pipeline)
            : base(new ClientContext(options, credential, baseUri, pipeline), ResourceIdentifier.RootResourceIdentifier)
        {
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary>
        /// ListResources of type T.
        /// </summary>
        /// <typeparam name="T"> The type of resource being returned in the list. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns>  A collection of resources. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<T> ListResources<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, Pageable<T>> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// ListResources of type T.
        /// </summary>
        /// <typeparam name="T"> The type of resource being returned in the list. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns>  A collection of resources. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<T> ListResourcesAsync<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, AsyncPageable<T>> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// Gets the provider container under this subscription.
        /// </summary>
        /// <returns> The provider container. </returns>
        public virtual ProviderContainer GetProviders()
        {
            return new ProviderContainer(this);
        }
    }
}
