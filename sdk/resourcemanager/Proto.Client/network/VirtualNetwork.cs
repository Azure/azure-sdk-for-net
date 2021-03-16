using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class representing a virtual nerwork along with the instance operations that can be performed on it.
    /// </summary>
    public class VirtualNetwork : VirtualNetworkOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualNetwork"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualNetwork(ResourceOperationsBase options, VirtualNetworkData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets or sets the virtual nerwork data.
        /// </summary>
        public VirtualNetworkData Data { get; private set; }

        /// <inheritdoc />
        protected override VirtualNetwork GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualNetwork> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
