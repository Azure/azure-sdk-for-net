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

        /// <summary>
        /// The operation to create or update a subnet. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the subnet. </param>
        /// <param name="resourceDetails"> The desired subnet configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="Response{Subnet}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name of the subnet cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Response<Subnet> CreateOrUpdate(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken);
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <summary>
        /// The operation to create or update a subnet. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the subnet. </param>
        /// <param name="resourceDetails"> The desired subnet configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{Subnet}"/> operation for this subnet. </returns>
        /// <exception cref="ArgumentException"> Name of the subnet cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Response<Subnet>> CreateOrUpdateAsync(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <summary>
        /// The operation to create or update a subnet. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the subnet. </param>
        /// <param name="resourceDetails"> The desired subnet configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An <see cref="Operation{Subnet}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the subnet cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public Operation<Subnet> StartCreateOrUpdate(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<Subnet, Azure.ResourceManager.Network.Models.Subnet>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, Id.Name, name, resourceDetails.Model, cancellationToken),
                s => new Subnet(Parent, new SubnetData(s)));
        }

        /// <summary>
        /// The operation to create or update a subnet. Please note some properties can be set only during creation.
        /// </summary>
        /// <param name="name"> The name of the subnet. </param>
        /// <param name="resourceDetails"> The desired subnet configuration. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{Subnet}"/> that allows polling for completion of the operation. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Name of the subnet cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> resourceDetails cannot be null. </exception>
        public async Task<Operation<Subnet>> StartCreateOrUpdateAsync(string name, SubnetData resourceDetails, CancellationToken cancellationToken = default)
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
        public override Response<Subnet> Get(string subnetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(Operations.Get(Id.ResourceGroupName, Id.Name, subnetName, cancellationToken: cancellationToken),
                n => new Subnet(Parent, new SubnetData(n)));
        }

        /// <inheritdoc/>
        public override async Task<Response<Subnet>> GetAsync(string subnetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Subnet, Azure.ResourceManager.Network.Models.Subnet>(await Operations.GetAsync(Id.ResourceGroupName, Id.Name, subnetName, null, cancellationToken),
                n => new Subnet(Parent, new SubnetData(n)));
        }
    }
}
