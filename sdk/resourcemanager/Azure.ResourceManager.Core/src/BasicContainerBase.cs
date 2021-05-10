// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public abstract class BasicContainerBase : OperationsBase
    {
        private static readonly object _parentLock = new object();
        private object _parentResource;

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ResourceOperationsBase Parent { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicContainerBase"/> class for mocking.
        /// </summary>
        protected BasicContainerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicContainerBase "/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected BasicContainerBase(ResourceOperationsBase parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), parent.Id)
        {
            Parent = parent;
        }

        /// <summary>
        /// Verify that the input resource Id is a valid container for this type.
        /// </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        /// <exception cref="InvalidOperationException"> Resource identifier is not a valid type for this container. </exception>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (identifier.ResourceType != ValidResourceType)
                throw new InvalidOperationException($"{identifier.ResourceType} is not a valid container for {Id.ResourceType}");
        }

        /// <summary>
        /// Gets the location of the parent object.
        /// </summary>
        /// <typeparam name="TParent"> The type of the parents full resource object. </typeparam>
        /// <typeparam name="TParentId"> The type of the parents resource id. </typeparam>
        /// <typeparam name="TParentOperations"> The type of the parents operations object. </typeparam>
        /// <returns> The <see cref="LocationData"/> associated with the parent object. </returns>
        protected TParent GetParentResource<TParent, TParentId, TParentOperations>()
            where TParent : TParentOperations
            where TParentOperations : ResourceOperationsBase<TParentId, TParent>
            where TParentId : ResourceIdentifier
        {
            if (_parentResource is null)
            {
                lock (_parentLock)
                {
                    if (_parentResource is null)
                    {
                        _parentResource = Parent as TParent;
                        if (_parentResource is null)
                        {
                            _parentResource = (Parent as TParentOperations).Get().Value;
                        }
                    }
                }
            }

            return _parentResource as TParent;
        }
    }
}
