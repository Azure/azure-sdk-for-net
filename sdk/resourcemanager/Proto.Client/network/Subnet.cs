using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class representing a subnet along with the instance operations that can be performed on it.
    /// </summary>
    public class Subnet : SubnetOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subnet"/> class.
        /// </summary>
        internal Subnet(ResourceOperationsBase options, SubnetData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing the subnet
        /// </summary>
        public SubnetData Data { get; private set; }

        /// <inheritdoc />
        protected override Subnet GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<Subnet> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
