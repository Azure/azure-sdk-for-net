using Azure;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific LoadBalancer.
    /// </summary>
    // TODO, ITaggable was not added.
    public class LoadBalancerOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, LoadBalancer>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancerOperations"/> class.
        /// </summary>
        /// <param name="virtualNetwork"> The client parameters to use in these operations. </param>
        /// <param name="loadBalancerName"> The name of the LoadBalancer. </param>
        internal LoadBalancerOperations(VirtualNetworkOperations virtualNetwork, string loadBalancerName)
            : base(virtualNetwork, virtualNetwork.Id.AppendChildResource( "loadBalancers", loadBalancerName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancerOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected LoadBalancerOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a LoadBalancer.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/loadBalancers";

        /// <summary>
        /// Gets the valid resource type definition for a LoadBalancer.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private LoadBalancersOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).LoadBalancers;

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }


        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<LoadBalancer> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<LoadBalancer, Azure.ResourceManager.Network.Models.LoadBalancer>(Operations.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken),
                n => new LoadBalancer(this, new LoadBalancerData(n)));
        }
        
        /// <inheritdoc/>
        public override async Task<ArmResponse<LoadBalancer>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<LoadBalancer, Azure.ResourceManager.Network.Models.LoadBalancer>(await Operations.GetAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken),
                n => new LoadBalancer(this, new LoadBalancerData(n)));
        }
    }
}
