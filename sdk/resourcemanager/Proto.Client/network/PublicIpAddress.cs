using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// Class representing a PublicIpAddress resource along with the instance operations that can be performed on it.
    /// </summary>
    public class PublicIpAddress : PublicIpAddressOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIpAddress"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PublicIpAddress(ResourceOperationsBase options, PublicIPAddressData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing this PublicIPAddress.
        /// </summary>
        public PublicIPAddressData Data { get; private set; }

        /// <inheritdoc />
        protected override PublicIpAddress GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<PublicIpAddress> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
