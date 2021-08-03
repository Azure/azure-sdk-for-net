// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a TagsResource along with the instance operations that can be performed on it.
    /// </summary>
    public class TagResource : TagResourceOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TagResource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TagResource(ResourceOperations options, TagResourceData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TagsResourceData. </summary>
        public TagResourceData Data { get; private set; }
    }
}
