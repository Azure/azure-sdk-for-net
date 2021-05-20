using Azure;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Network
{
    /// <summary>
    /// A class representing collection of LoadBalancers and their operations over a VirtualNetwork.
    /// </summary>
    public class LoadBalancerContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, LoadBalancer, LoadBalancerData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancerContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The parent resource group. </param>
        internal LoadBalancerContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private LoadBalancersOperations Operations => new NetworkManagementClient(
            Id.SubscriptionId,
            BaseUri,
            Credential,
            ClientOptions.Convert<NetworkManagementClientOptions>()).LoadBalancers;

        /// <inheritdoc/>
        public Response<LoadBalancer> CreateOrUpdate(string name, LoadBalancerData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return Response.FromValue(new LoadBalancer(Parent, new LoadBalancerData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public async Task<Response<LoadBalancer>> CreateOrUpdateAsync(string name, LoadBalancerData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new LoadBalancer(Parent, new LoadBalancerData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public Operation<LoadBalancer> StartCreateOrUpdate(string name, LoadBalancerData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<LoadBalancer, Azure.ResourceManager.Network.Models.LoadBalancer>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                s => new LoadBalancer(Parent, new LoadBalancerData(s)));
        }

        /// <inheritdoc/>
        public async Task<Operation<LoadBalancer>> StartCreateOrUpdateAsync(string name, LoadBalancerData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<LoadBalancer, Azure.ResourceManager.Network.Models.LoadBalancer>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                s => new LoadBalancer(Parent, new LoadBalancerData(s)));
        }

        /// <summary>
        /// Lists the LoadBalancers for this LoadBalancer.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<LoadBalancer> List(CancellationToken cancellationToken = default)
        {
            return new PhWrappingPageable<Azure.ResourceManager.Network.Models.LoadBalancer, LoadBalancer>(
                Operations.List(Id.ResourceGroupName, cancellationToken),
                convertor());
        }

        /// <summary>
        /// Lists the LoadBalancers for this LoadBalancer.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<LoadBalancer> ListAsync(CancellationToken cancellationToken = default)
        {
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.LoadBalancer, LoadBalancer>(
                Operations.ListAsync(Id.ResourceGroupName, cancellationToken),
                convertor());
        }

        private Func<Azure.ResourceManager.Network.Models.LoadBalancer, LoadBalancer> convertor()
        {
            return s => new LoadBalancer(Parent, new LoadBalancerData(s));
        }

        /// <inheritdoc/>
        public override Response<LoadBalancer> Get(string loadBalancerName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, loadBalancerName, null, cancellationToken: cancellationToken);
            return Response.FromValue(new LoadBalancer(Parent, new LoadBalancerData(response.Value)), response.GetRawResponse());

        }
        
        /// <inheritdoc/>
        public override async Task<Response<LoadBalancer>> GetAsync(string loadBalancerName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, loadBalancerName, null, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new LoadBalancer(Parent, new LoadBalancerData(response.Value)), response.GetRawResponse());
        }
    }
}
