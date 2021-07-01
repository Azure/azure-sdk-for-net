// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class OperationsBase
    {
        private ProviderContainer _providerContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase"/> class for mocking.
        /// </summary>
        protected OperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase"/> class.
        /// </summary>
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected OperationsBase(OperationsBase parentOperations, ResourceIdentifier id)
            : this(new ClientContext(parentOperations.ClientOptions, parentOperations.Credential, parentOperations.BaseUri, parentOperations.Pipeline), id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OperationsBase(ClientContext clientContext, ResourceIdentifier id)
        {
            ClientOptions = clientContext.ClientOptions;
            Id = id;
            Credential = clientContext.Credential;
            BaseUri = clientContext.BaseUri;
            Pipeline = clientContext.Pipeline;
            Diagnostics = new ClientDiagnostics(ClientOptions);

            Validate(id);
        }

        /// <summary>
        /// Gets the provider operations.
        /// </summary>
        protected ProviderContainer ProviderContainer => _providerContainer ??= GetProviderContainer();

        private ProviderContainer GetProviderContainer()
        {
            return new ProviderContainer(this);
        }

        internal ClientDiagnostics Diagnostics { get; }

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
        /// Validate the resource identifier against current operations.
        /// </summary>
        /// <param name="identifier"> The resource identifier. </param>
        protected virtual void Validate(ResourceIdentifier identifier)
        {
            if (identifier?.ResourceType != ValidResourceType)
                throw new ArgumentException($"Invalid resource type {identifier?.ResourceType} expected {ValidResourceType}");
        }
    }
}
