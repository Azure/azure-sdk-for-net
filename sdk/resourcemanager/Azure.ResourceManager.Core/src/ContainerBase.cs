// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Base class representing collection of resources.
    /// </summary>
    /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
    public abstract class ContainerBase<TIdentifier> : OperationsBase
        where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TIdentifier}"/> class for mocking.
        /// </summary>
        protected ContainerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TIdentifier}"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ContainerBase(ClientContext clientContext, TIdentifier id)
            : base(clientContext, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TOperations}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ContainerBase(ResourceOperationsBase parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), parent.Id)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ResourceOperationsBase Parent { get; }
    }
}
