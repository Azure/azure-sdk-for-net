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

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="client"> The client to copy settings from. </param>
        /// <param name="id"> The id of the parent for the collection. </param>
        protected ArmCollection(ArmClient client, ResourceIdentifier id)
            : base(client, id)
        {
        }
    }
}
