// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        /// <summary>
        /// Some summary.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetExtensionResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetExtensionResource(client, id);
            }
            );
        }
    }
}
