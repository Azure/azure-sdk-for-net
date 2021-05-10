// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core.Extensions;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific resource that requires complex key.
    /// </summary>
    public abstract class CustomKeyResourceOperationsBase : OperationsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase"/> class for mocking.
        /// </summary>
        protected CustomKeyResourceOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"></param>
        internal CustomKeyResourceOperationsBase(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, id)
        {
        }
    }

    /// <summary>
    /// Base class for all operations over a resource
    /// </summary>
    /// <typeparam name="TOperations"> The type implementing operations over the resource. </typeparam>
    /// <typeparam name="TIdentifier"> The The identifier type for the resource. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public abstract class CustomKeyResourceOperationsBase<TIdentifier, TOperations> : CustomKeyResourceOperationsBase
        where TOperations : CustomKeyResourceOperationsBase<TIdentifier, TOperations> where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase{TIdentifier,TOperations}"/> class for mocking.
        /// </summary>
        protected CustomKeyResourceOperationsBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase{TIdentifier,TOperations}"/> class.
        /// </summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase"/> class.
        /// <param name="parentOperations"> The resource representing the parent resource. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected CustomKeyResourceOperationsBase(OperationsBase parentOperations, ResourceIdentifier id)
            : base(new ClientContext(parentOperations.ClientOptions, parentOperations.Credential, parentOperations.BaseUri, parentOperations.Pipeline), id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"></param>
        internal CustomKeyResourceOperationsBase(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, id)
        {
        }

        /// <summary>
        /// The typed resource identifier for the underlying resource
        /// </summary>
        public virtual new TIdentifier Id
        {
            get { return base.Id as TIdentifier; }
        }
    }
}
