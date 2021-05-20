// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachine and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineImageContainer : ContainerBase
    {
        private string _subscriptionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineImageContainer"/> class.
        /// </summary>
        /// <param name="parent"> The parent subscription. </param>
        internal VirtualMachineImageContainer(SubscriptionOperations parent)
            : base(parent)
        {
            _subscriptionId = parent.Id.SubscriptionId;
        }

        private VirtualMachineImagesOperations Operations => new ComputeManagementClient(
            BaseUri,
            _subscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachineImages;

        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        public Response<VirtualMachineImage> Get(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            return Operations.Get(location, publisherName, offer, skus, version, cancellationToken);
        }

        public async Task<Response<VirtualMachineImage>> GetAsync(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            return await Operations.GetAsync(location, publisherName, offer, skus, version, cancellationToken);
        }

        public IEnumerable<VirtualMachineImageResource> ListOffers(
            string location,
            string publisherName,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListOffers(location, publisherName, cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineImageResource>> ListOffersAsync(
            string location,
            string publisherName,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListOffersAsync(location, publisherName, cancellationToken).ConfigureAwait(false)).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListPublishers(
            string location,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListPublishers(location, cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineImageResource>> ListPublishersAsync(
            string location,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListPublishersAsync(location, cancellationToken).ConfigureAwait(false)).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListSkus(
            string location,
            string publisherName,
            string offer,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListSkus(location, publisherName, offer, cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineImageResource>> ListSkusAsync(
            string location,
            string publisherName,
            string offer,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListSkusAsync(location, publisherName, offer, cancellationToken).ConfigureAwait(false)).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListVersions(
            string location,
            string publisherName,
            string offer,
            string skus,
            string expand = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return Operations.List(location,
                publisherName: publisherName,
                offer: offer,
                skus: skus,
                expand: expand,
                top: top,
                orderby: orderby,
                cancellationToken: cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineImageResource>> ListVersionsAsync(
            string location,
            string publisherName,
            string offer,
            string skus,
            string expand = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListAsync(location,
                publisherName: publisherName,
                offer: offer,
                skus: skus,
                expand: expand,
                top: top,
                orderby: orderby,
                cancellationToken: cancellationToken).ConfigureAwait(false)).Value;
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="offer"> The offer of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="skus"> The skus of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="VirtualMachineImage"/> resource or null if not found. </returns>
        public VirtualMachineImage TryGet(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return Get(location: location, publisherName: publisherName, offer: offer, skus: skus, version: version, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="offer"> The offer of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="skus"> The skus of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="VirtualMachineImage"/> resource or null if not found. </returns>
        public async Task<VirtualMachineImage> TryGetAsync(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return (await GetAsync(location: location, publisherName: publisherName, offer: offer, skus: skus, version: version, cancellationToken: cancellationToken).ConfigureAwait(false)).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="offer"> The offer of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="skus"> The skus of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public bool DoesExist(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            return TryGet(location: location, publisherName: publisherName, offer: offer, skus: skus, version: version, cancellationToken: cancellationToken) != null;
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="offer"> The offer of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="skus"> The skus of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineImage"/>. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public async Task<bool> DoesExistAsync(
            string location,
            string publisherName,
            string offer,
            string skus,
            string version,
            CancellationToken cancellationToken = default)
        {
            return await TryGetAsync(location: location, publisherName: publisherName, offer: offer, skus: skus, version: version, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
        }
    }
}
