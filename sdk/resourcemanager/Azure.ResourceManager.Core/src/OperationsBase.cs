// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class OperationsBase : IClientContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OperationsBase(IClientContext clientContext, ResourceIdentifier id)
        {
            ((IClientContext)this).ClientOptions = clientContext.ClientOptions;
            Id = id;
            ((IClientContext)this).Credential = clientContext.Credential;
            ((IClientContext)this).BaseUri = clientContext.BaseUri;

            Validate(id);
        }

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        public virtual ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the Azure Resource Manager client options.
        /// </summary>
        AzureResourceManagerClientOptions IClientContext.ClientOptions { get; set; }

        /// <summary>
        /// Gets the Azure credential.
        /// </summary>
        TokenCredential IClientContext.Credential { get; set; }

        /// <summary>
        /// Gets the base URI of the service.
        /// </summary>
        Uri IClientContext.BaseUri { get; set; }

        /// <summary>
        /// Gets the valid Azure resource type for the current operations.
        /// </summary>
        /// <returns> A valid Azure resource type. </returns>
        protected abstract ResourceType ValidResourceType { get; }

        /// <summary>
        /// Gets the resource client.
        /// </summary>
        protected ResourcesManagementClient ResourcesClient => new ResourcesManagementClient(((IClientContext)this).BaseUri, Id.Subscription, ((IClientContext)this).Credential);

        /// <summary>
        /// Validate the resource identifier against current operations.
        /// </summary>
        /// <param name="identifier"> The resource identifier. </param>
        protected virtual void Validate(ResourceIdentifier identifier)
        {
            if (identifier?.Type != ValidResourceType)
                throw new ArgumentException($"Invalid resource type {identifier?.Type} expected {ValidResourceType}");
        }
    }
}
