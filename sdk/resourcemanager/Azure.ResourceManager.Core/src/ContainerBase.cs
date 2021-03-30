// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Base class representing collection of resources.
    /// </summary>
    /// <typeparam name="TOperations"> The type of the class containing operations for the underlying resource. </typeparam>
    /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
    public abstract class ContainerBase<TIdentifier, TOperations> : OperationsBase
        where TOperations : ResourceOperationsBase<TIdentifier, TOperations> where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TIdentifier, TOperations}"/> class for mocking.
        /// </summary>
        protected ContainerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TIdentifier, TOperations}"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ContainerBase(ClientContext clientContext, TIdentifier id)
            : base(clientContext, id)
        {
        }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TOperations, TIdentifier}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ContainerBase(ResourceOperationsBase parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri), parent.Id)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ResourceOperationsBase Parent { get; }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual TOperations TryGet(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ContainerBase`2.TryGet");
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
        public async virtual Task<TOperations> TryGetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ContainerBase`2.TryGet");
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
        /// <returns> Whether or not the resource existed. </returns>
        public virtual bool DoesExist(string resourceName)
        {
            return TryGet(resourceName) == null ? false : true;
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
