// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a TagsResource along with the instance operations that can be performed on it.
    /// </summary>
    public class TagsResource : TagsOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TagsResource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TagsResource(OperationsBase options, TagsResourceData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TagsResourceData. </summary>
        public TagsResourceData Data { get; private set; }
    }
}
