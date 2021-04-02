// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase"/> class for mocking.
        /// </summary>
        protected OperationsBase()
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
            Diagnostics = new ClientDiagnostics(ClientOptions);
            Validate(id);
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
        /// Gets the valid Azure resource type for the current operations.
        /// </summary>
        /// <returns> A valid Azure resource type. </returns>
        protected abstract ResourceType ValidResourceType { get; }

        /// <summary>
        /// Gets the resource client.
        /// </summary>
        protected ResourcesManagementClient ResourcesClient
        {
            get
            {
                string subscription;
                if (!Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ResourcesManagementClient(BaseUri, subscription, Credential, ClientOptions.Convert<ResourcesManagementClientOptions>());
            }
        }

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
