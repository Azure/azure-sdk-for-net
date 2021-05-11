// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachine and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineExtensionImageContainer : ContainerBase<SubscriptionResourceIdentifier>
    {
        private string _subsriptionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineContainer"/> class.
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
            string publisher,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineExtensionImage,
                VirtualMachineExtensionImage>(
                Operations.Get(location, publisher, type, version, cancellationToken),
                v => v);
        }

        public IEnumerable<VirtualMachineExtensionImage> ListTypes(
            string location,
            string publisher,
            CancellationToken cancellationToken = default)
        {
            return Operations
                .ListTypes(location, publisher, cancellationToken)
                .Value;
        }

        public IEnumerable<VirtualMachineExtensionImage> ListVersions(
            string location,
            string publisher,
            string type,
            string filter = null,
            int? top = null,
            string orderby = null,
            CancellationToken cancellationToken = default)
        {
            return Operations
                .ListVersions(location, publisher, type, filter: filter, top: top, orderby: orderby, cancellationToken: cancellationToken)
                .Value;
        }
    }
}