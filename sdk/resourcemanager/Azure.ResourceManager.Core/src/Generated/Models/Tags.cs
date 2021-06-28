using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a Tags along with the instance operations that can be performed on it.
    /// </summary>
    public class Tags : TagsOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "Tags"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal Tags(OperationsBase options, TagsData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PolicyAssignmentData. </summary>
        public TagsData Data { get; private set; }

        /// <inheritdoc />
#pragma warning disable CA1801 // 检查未使用的参数
        protected Tags GetResource(CancellationToken cancellation = default)
#pragma warning restore CA1801 // 检查未使用的参数
        {
            return this;
        }

        /// <inheritdoc />
#pragma warning disable CA1801 // 检查未使用的参数
        protected Task<Tags> GetResourceAsync(CancellationToken cancellation = default)
#pragma warning restore CA1801 // 检查未使用的参数
        {
            return Task.FromResult(this);
        }
    }
}
