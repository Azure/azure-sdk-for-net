using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing an availability set along with the instance operations that can be performed on it.
    /// </summary>
    public class AvailabilitySet : AvailabilitySetOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilitySet"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal AvailabilitySet(ResourceOperationsBase options, AvailabilitySetData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets or sets the availability set data.
        /// </summary>
        public AvailabilitySetData Data { get; private set; }

        /// <inheritdoc />
        protected override AvailabilitySet GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<AvailabilitySet> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
