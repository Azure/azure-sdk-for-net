using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of Subnets and their operations over a VirtualNetwork.
    /// </summary>
    public class SubnetContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, Subnet, SubnetData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubnetContainer"/> class.
        /// </summary>
        /// <param name="virtualNetwork"> The virtual network associate with this subnet </param>
        internal SubnetContainer(VirtualNetworkOperations virtualNetwork)
            : base(virtualNetwork)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => VirtualNetworkOperations.ResourceType;

        private SubnetsOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).Subnets;

        /// <inheritdoc/>
        public override ArmResponse<Subnet> CreateOrUpdate(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken);
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<Subnet>> CreateOrUpdateAsync(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <inheritdoc/>
        public override ArmOperation<Subnet> StartCreateOrUpdate(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <inheritdoc/>
        public async override Task<ArmOperation<Subnet>> StartCreateOrUpdateAsync(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <summary>
        /// Constructs an object used to create a subnet.
        /// </summary>
        /// <param name="subnetCidr"> The CIDR of the resource. </param>
        /// <param name="group"> The network security group of the resource. </param>
        /// <returns> A builder with <see cref="Subnet"/> and <see cref="Subnet"/>. </returns>
        public SubnetBuilder Construct(string subnetCidr, NetworkSecurityGroupData group = null)
        {
            var subnet = new Azure.ResourceManager.Network.Models.Subnet()
            {
                AddressPrefix = subnetCidr,
            };

            if (null != group)
            {
                subnet.NetworkSecurityGroup = group.Model;
            }

            return new SubnetBuilder(this, new SubnetData(subnet));
        }
        
        /// <summary>
        /// Lists the subnets for this virtual network.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<Subnet> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<Azure.ResourceManager.Network.Models.Subnet, Subnet>(
                Operations.List(Id.ResourceGroupName, Id.Name, cancellationToken),
                convertor());
        }

        /// <summary>
        /// Lists the subnets for this virtual network.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Subnet> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.Subnet, Subnet>(
                Operations.ListAsync(Id.ResourceGroupName, Id.Name, cancellationToken),
                convertor());
        }

        private Func<Azure.ResourceManager.Network.Models.Subnet, Subnet> convertor()
        {
            return s => new Subnet(Parent, new SubnetData(s));
        }

        /// <inheritdoc/>
        public override ArmResponse<Subnet> Get(string subnetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(Operations.Get(Id.ResourceGroupName, Id.Name, subnetName, cancellationToken: cancellationToken),
                n => new Subnet(Parent, new SubnetData(n)));
        }
        
        /// <inheritdoc/>
        public override async Task<ArmResponse<Subnet>> GetAsync(string subnetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(await Operations.GetAsync(Id.ResourceGroupName, Id.Name, subnetName, null, cancellationToken),
                n => new Subnet(Parent, new SubnetData(n)));
        }
    }
}
