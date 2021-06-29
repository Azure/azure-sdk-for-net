// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
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

        /// <summary> Gets or sets the PolicyAssignmentData. </summary>
        public TagsResourceData Data { get; private set; }

        /// <inheritdoc />
#pragma warning disable CA1801 // 检查未使用的参数
        protected TagsResource GetResource(CancellationToken cancellation = default)
#pragma warning restore CA1801 // 检查未使用的参数
        {
            return this;
        }

        /// <inheritdoc />
#pragma warning disable CA1801 // 检查未使用的参数
        protected Task<TagsResource> GetResourceAsync(CancellationToken cancellation = default)
#pragma warning restore CA1801 // 检查未使用的参数
        {
            return Task.FromResult(this);
        }
    }
}
