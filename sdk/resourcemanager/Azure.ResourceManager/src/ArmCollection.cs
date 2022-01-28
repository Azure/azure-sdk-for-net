// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Base class representing collection of resources.
    /// </summary>
    public abstract class ArmCollection : ArmResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class for mocking.
        /// </summary>
        protected ArmCollection()
        {
        }

        internal ArmCollection(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ArmCollection(ArmResource parent)
            : base(parent.ArmClient, parent.Id)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ArmResource Parent { get; }
    }
}
