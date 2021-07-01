// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
    /// <typeparam name="TOperations"> The type of the class containing operations for the underlying resource. </typeparam>
    /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
    public abstract class ResourceContainerBase<TIdentifier, TOperations, TResource> : ContainerBase
        where TIdentifier : ResourceIdentifier
        where TOperations : ResourceOperationsBase<TIdentifier, TOperations>
        where TResource : class
    {
        private readonly object _parentLock = new object();
        private object _parentResource;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceContainerBase{TIdentifier, TOperations, TResource}"/> class for mocking.
        /// </summary>
        protected ResourceContainerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceContainerBase{TIdentifier, TOperations, TResource}"/> class.
        /// </summary>
        /// <param name="clientContext"> The client context to use. </param>
        /// <param name="parentId"> The identifier of the resource that is the target of operations. </param>
        internal ResourceContainerBase(ClientContext clientContext, TIdentifier parentId)
            : base(clientContext, parentId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceContainerBase{TIdentifier, TOperations, TData}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ResourceContainerBase(OperationsBase parent)
            : base(parent)
        {
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected new ResourceOperationsBase Parent { get {return base.Parent as ResourceOperationsBase;} }

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

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual TOperations TryGet(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceContainerBase`3.TryGet");
            scope.Start();

            var op = GetOperation(resourceName);

            try
            {
                return op.Get(cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<TOperations> TryGetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceContainerBase`3.TryGet");
            scope.Start();

            var op = GetOperation(resourceName);

            try
            {
                return (await op.GetAsync(cancellationToken).ConfigureAwait(false)).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual bool DoesExist(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceContainerBase`3.DoesExist");
            scope.Start();
            return TryGet(resourceName, cancellationToken) != null;
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to check. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual async Task<bool> DoesExistAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceContainerBase`3.DoesExist");
            scope.Start();
            return await TryGetAsync(resourceName, cancellationToken).ConfigureAwait(false) != null;
        }

        /// <summary>
        /// Get an instance of the operations this container holds.
        /// </summary>
        /// <param name="resourceName"> The name of the resource to scope the operations to. </param>
        /// <returns> An instance of <see cref="ResourceContainerBase{TIdentifier, TOperations, TResource}"/>. </returns>
        protected virtual ResourceOperationsBase<TIdentifier, TOperations> GetOperation(string resourceName)
        {
            return Activator.CreateInstance(
                typeof(TOperations).BaseType,
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new object[] { Parent, resourceName },
                CultureInfo.InvariantCulture) as ResourceOperationsBase<TIdentifier, TOperations>;
        }
    }
}
