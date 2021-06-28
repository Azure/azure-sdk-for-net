// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
        /// <param name="parent"></param>
        internal SingletonOperationsBase(OperationsBase parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), ResourceIdentifier.RootResourceIdentifier)
        {
            Parent = parent;
            ParentId = parent.Id;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected OperationsBase Parent { get; }

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
        /// Initializes a new instance of the <see cref="SingletonOperationsBase{TIdentifier, TOperations}"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected SingletonOperationsBase(OperationsBase parent)
            : base(parent)
        {
            ParentId = parent.Id as TIdentifier;
            if (string.IsNullOrWhiteSpace(ParentId))
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// The typed resource identifier for the underlying resource
        /// </summary>
        protected new TIdentifier ParentId
        {
            get;
        }
    }
}
