// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class VirtualMachineExtensionImageContainer : ContainerBase
    {
        private string _subsriptionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineExtensionImageContainer"/> class.
        /// </summary>
        /// <param name="subscription"> The subscription that is the parent of the VirtualMachinesExtensionImage. </param>
        internal VirtualMachineExtensionImageContainer(SubscriptionOperations subscription)
            : base(subscription)
        {
            _subsriptionId = subscription.Id.SubscriptionId;
        }

        private VirtualMachineExtensionImagesOperations Operations => new ComputeManagementClient(
            BaseUri,
            _subsriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachineExtensionImages;

        /// <summary>
        /// Gets the valid resource type for this object
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        public Response<VirtualMachineExtensionImage> Get(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return Operations.Get(location, publisherName, type, version, cancellationToken);
        }

        public async Task<Response<VirtualMachineExtensionImage>> GetAsync(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return await Operations.GetAsync(location, publisherName, type, version, cancellationToken)
                .ConfigureAwait(false);
        }

        public IEnumerable<VirtualMachineExtensionImage> ListTypes(
            string location,
            string publisherName,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListTypes(location, publisherName, cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineExtensionImage>> ListTypesAsync(
            string location,
            string publisherName,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListTypesAsync(location, publisherName, cancellationToken).ConfigureAwait(false)).Value;
        }

        public IEnumerable<VirtualMachineExtensionImage> ListVersions(
            string location,
            string publisherName,
            string type,
            string filter = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListVersions(location, publisherName, type, filter: filter, top: top, orderby: orderby, cancellationToken: cancellationToken).Value;
        }

        public async Task<IEnumerable<VirtualMachineExtensionImage>> ListVersionsAsync(
            string location,
            string publisherName,
            string type,
            string filter = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return (await Operations.ListVersionsAsync(location, publisherName, type, filter: filter, top: top, orderby: orderby, cancellationToken: cancellationToken).ConfigureAwait(false)).Value;
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="type"> The type of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineExtensionImageContainer"/>.</param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="VirtualMachineExtensionImageContainer"/> resource or null if not found. </returns>
        public VirtualMachineExtensionImage TryGet(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return Get(location:location, publisherName:publisherName, type:type, version:version, cancellationToken:cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the resource from Azure if it exists.
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="type"> The type of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An instance of <see cref="VirtualMachineExtensionImageContainer"/> resource or null if not found. </returns>
        public async Task<VirtualMachineExtensionImage> TryGetAsync(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return (await GetAsync(location: location, publisherName: publisherName, type: type, version: version, cancellationToken: cancellationToken).ConfigureAwait(false)).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="type"> The type of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineExtensionImageContainer"/>.</param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public bool DoesExist(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return TryGet(location: location, publisherName: publisherName, type: type, version: version, cancellationToken: cancellationToken) != null;
        }

        /// <summary>
        /// Determines whether or not the azure resource exists in this container
        /// </summary>
        /// <param name="location"> The location of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="publisherName"> The publisherName of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="type"> The type of the <see cref="VirtualMachineExtensionImageContainer"/>. </param>
        /// <param name="version"> The version of the <see cref="VirtualMachineExtensionImageContainer"/>.</param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> Whether or not the resource existed. </returns>
        public async Task<bool> DoesExistAsync(
            string location,
            string publisherName,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return await TryGetAsync(location: location, publisherName: publisherName, type: type, version: version, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
        }
    }
}
