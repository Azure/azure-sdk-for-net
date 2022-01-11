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
        /// <param name="clientContext"></param>
        internal ArmCollection(ClientContext clientContext)
            : base(clientContext, ResourceIdentifier.Root)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ArmCollection(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="options"> The options to use. </param>
        /// <param name="credential"> The credential to use. </param>
        /// <param name="baseUri"> The base uri to use. </param>
        /// <param name="pipeline"> The http pipeline policy to use. </param>
        protected ArmCollection(ArmClientOptions options, TokenCredential credential, Uri baseUri, HttpPipeline pipeline)
            : this(new ClientContext(options, credential, baseUri, pipeline))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmCollection"/> class.
        /// </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        protected ArmCollection(ArmResource parent)
            : base(new ClientContext(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline), parent.Id)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent resource of this resource.
        /// </summary>
        protected ArmResource Parent { get; }
    }
}
