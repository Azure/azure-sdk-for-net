using Azure;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subnet.
    /// </summary>
    public class SubnetOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, Subnet>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubnetOperations"/> class.
        /// </summary>
        /// <param name="virtualNetwork"> The client parameters to use in these operations. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        internal SubnetOperations(VirtualNetworkOperations virtualNetwork, string subnetName)
            : base(virtualNetwork, virtualNetwork.Id.AppendChildResource( "subnets", subnetName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubnetOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected SubnetOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a subnet.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks/subnets";

        /// <summary>
        /// Gets the valid resource type definition for a subnet.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private SubnetsOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).Subnets;

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken)
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken))
                .WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }


        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<Subnet> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(Operations.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken),
                n => new Subnet(this, new SubnetData(n)));
        }
        
        /// <inheritdoc/>
        public override async Task<ArmResponse<Subnet>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(await Operations.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken),
                n => new Subnet(this, new SubnetData(n)));
        }
    }
}
