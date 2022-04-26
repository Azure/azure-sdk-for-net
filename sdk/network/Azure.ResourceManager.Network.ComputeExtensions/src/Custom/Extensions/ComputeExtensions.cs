// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.Compute;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Network. </summary>
    public static class ComputeExtensions
    {
        private static VirtualMachineScaleSetResourceExtensionClient GetExtensionClient(VirtualMachineScaleSetResource virtuamMachineScaleSet)
        {
            return virtuamMachineScaleSet.GetCachedClient((client) =>
            {
                return new VirtualMachineScaleSetResourceExtensionClient(client, virtuamMachineScaleSet.Id);
            }
            );
        }

        /// <summary>
        /// Some sort of summary.
        /// </summary>
        /// <param name="virtuamMachineScaleSet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Pageable<PublicIPAddressResource> GetAllPublicIPAddresses(this VirtualMachineScaleSetResource virtuamMachineScaleSet, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(virtuamMachineScaleSet).GetAllPublicIpAddresses(cancellationToken);
        }

        /// <summary>
        /// Some sort of summary.
        /// </summary>
        /// <param name="virtuamMachineScaleSet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static AsyncPageable<PublicIPAddressResource> GetAllPublicIPAddressesAsync(this VirtualMachineScaleSetResource virtuamMachineScaleSet, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(virtuamMachineScaleSet).GetAllPublicIpAddressesAsync(cancellationToken);
        }
    }
}
