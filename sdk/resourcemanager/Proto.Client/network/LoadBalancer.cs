using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class representing a LoadBalancer along with the instance operations that can be performed on it.
    /// </summary>
    public class LoadBalancer : LoadBalancerOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancer"/> class.
        /// </summary>
        internal LoadBalancer(ResourceOperationsBase options, LoadBalancerData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets the data representing the LoadBalancer
        /// </summary>
        public LoadBalancerData Data { get; private set; }

        /// <inheritdoc />
        protected override LoadBalancer GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<LoadBalancer> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
