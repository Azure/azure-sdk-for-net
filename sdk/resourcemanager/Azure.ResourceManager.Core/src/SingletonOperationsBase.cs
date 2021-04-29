// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource.
    /// </summary>
    public abstract class SingletonOperationsBase : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonOperationsBase"/> class for mocking.
        /// </summary>
        protected SingletonOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonOperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"></param>
        internal SingletonOperationsBase(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, ResourceIdentifier.RootResourceIdentifier)
        {
            ParentId = id;
        }

        /// <summary>
        /// The typed resource identifier for the underlying resource
        /// </summary>
        public ResourceIdentifier ParentId
        {
            get;
        }
    }

    /// <summary>
    /// Base class representing a singleton operation
    /// </summary>
    /// <typeparam name="TOperations"> The type of the class containing operations for the underlying resource. </typeparam>
    /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<Pending>")]
    public abstract class SingletonOperationsBase<TIdentifier, TOperations> : SingletonOperationsBase
        where TOperations : SingletonOperationsBase<TIdentifier, TOperations>
        where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonOperationsBase{TIdentifier, TOperations}"/> class for mocking.
        /// </summary>
        protected SingletonOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBase{TOperations, TIdentifier}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        /// <param name="parentId"> The identifier of the resource that is the target of operations. </param>
        protected SingletonOperationsBase(OperationsBase parent, TIdentifier parentId)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), parentId)
        {
            Parent = parent;
            ParentId = parentId;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected OperationsBase Parent { get; }

        /// <summary>
        /// The typed resource identifier for the underlying resource
        /// </summary>
        protected new TIdentifier ParentId
        {
            get;
        }
    }
}
