// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachine and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineExtensionImageContainer 
        : CustomKeyResourceContainerBase<SubscriptionResourceIdentifier, VirtualMachineExtensionImage, VirtualMachineExtensionImageData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The ResourceGroup that is the parent of the VirtualMachines. </param>
        internal VirtualMachineExtensionImageContainer(SubscriptionOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        private Azure.ResourceManager.Compute.VirtualMachineExtensionImagesOperations Operations => new ComputeManagementClient(
            BaseUri,
            GetParentResource<Subscription, SubscriptionResourceIdentifier, SubscriptionOperations>().Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachineExtensionImages;

        /// <summary>
        /// Gets the valid resource type for this object
        /// </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        public ArmResponse<VirtualMachineExtensionImage> Get(
            string location,
            string publisher,
            string type,
            string version,
            CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineExtensionImage, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>(
                Operations.Get(location, publisher, type, version, cancellationToken),
                v => new VirtualMachineExtensionImage(Parent, new VirtualMachineExtensionImageData(v)));
        }

        public IEnumerable<VirtualMachineExtensionImage> ListTypes(
            string location,
            string publisher,
            CancellationToken cancellationToken = default)
        {
            return Operations
                .ListTypes(location, publisher, cancellationToken)
                .Value.Select(s => new VirtualMachineExtensionImage(Parent, new VirtualMachineExtensionImageData(s)));
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
                .Value.Select(s => new VirtualMachineExtensionImage(Parent, new VirtualMachineExtensionImageData(s)));
        }
    }
}