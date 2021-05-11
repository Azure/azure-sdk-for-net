// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachine and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineImageContainer : ContainerBase<SubscriptionResourceIdentifier>
    {
        private string _subscriptionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineContainer"/> class.
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

        public ArmResponse<VirtualMachineImage> Get(
            string location,
            string publisher,
            string offer,
            string sku,
            string version,
            CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineImage, VirtualMachineImage>(
                Operations.Get(location, publisher, offer, sku, version, cancellationToken), v => v);
        }

        public IEnumerable<VirtualMachineImageResource> ListOffers(
            string location,
            string publisher,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListOffers(location, publisher, cancellationToken).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListPublishers(
            string location,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListPublishers(location, cancellationToken).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListSkus(
            string location,
            string publisher,
            string offer,
            CancellationToken cancellationToken = default)
        {
            return Operations.ListSkus(location, publisher, offer, cancellationToken).Value;
        }

        public IEnumerable<VirtualMachineImageResource> ListVersions(
            string location,
            string publisher,
            string offer,
            string skus,
            string expand = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return Operations.List(
                    location,
                    publisher,
                    offer,
                    skus,
                    expand: expand,
                    top: top,
                    orderby: orderby,
                    cancellationToken: cancellationToken)
                .Value;
        }
    }
}