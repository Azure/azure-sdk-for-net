// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Globalization;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Base class representing collection of resources.
    /// </summary>
    /// <typeparam name="TOperations"> The type of the class containing operations for the underlying resource. </typeparam>
    public abstract class ContainerBase<TOperations> : OperationsBase
        where TOperations : ResourceOperationsBase<TOperations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TOperations}"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        protected ContainerBase(AzureResourceManagerClientOptions options, ResourceIdentifier id, TokenCredential credential, Uri baseUri)
            : base(options, id, credential, baseUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TOperations}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ContainerBase(ResourceOperationsBase parent)
            : base(parent.ClientOptions, parent.Id, parent.Credential, parent.BaseUri)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource
        /// </summary>
        protected ResourceOperationsBase Parent { get; }

        /// <summary>
        /// Returns the resource from Azure if it exists
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to get. </param>
        /// <param name="resource"> The resource if it existed, null otherwise. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual bool TryGetValue(string resourceName, out ArmResponse<TOperations> resource)
        {
            var op = GetOperation(resourceName);

            try
            {
                resource = op.Get();
                return true;
            }
            catch
            {
                resource = null;
                return false;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="resourceName"> The name of the resource you want to check. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public virtual bool DoesExist(string resourceName)
        {
            ArmResponse<TOperations> output;
            return TryGetValue(resourceName, out output);
        }

        /// <summary>
        /// Get an instance of the operations this container holds.
        /// </summary>
        /// <param name="resourceName"> The name of the resource to scope the operations to. </param>
        /// <returns> An instance of <see cref="ResourceContainerBase{TOperations, TResource}"/>. </returns>
        protected virtual ResourceOperationsBase<TOperations> GetOperation(string resourceName)
        {
            return Activator.CreateInstance(
                typeof(TOperations).BaseType,
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new object[] { Parent, resourceName },
                CultureInfo.InvariantCulture) as ResourceOperationsBase<TOperations>;
        }
    }
}
