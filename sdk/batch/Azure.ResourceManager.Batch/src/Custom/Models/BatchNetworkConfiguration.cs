// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Batch.Models
{
    // This custom property is added for backward compatibility with the previous
    // Swagger/AutoRest-generated SDK. In the generated code, BatchNetworkConfiguration
    // has an EndpointConfiguration property of type PoolEndpointConfiguration which
    // contains InboundNatPools. The old SDK exposed InboundNatPools directly as
    // EndpointInboundNatPools on BatchNetworkConfiguration. This custom property
    // re-exposes it at the same level to preserve the public API surface.
    //
    // The setter always creates a new PoolEndpointConfiguration because
    // PoolEndpointConfiguration.InboundNatPools is read-only ({ get; }) in the
    // generated code — the list is set via the constructor only.
    public partial class BatchNetworkConfiguration
    {
        /// <summary> The maximum number of inbound NAT pools per Batch pool is 5. If the maximum number of inbound NAT pools is exceeded the request fails with HTTP status code 400. This cannot be specified if the IPAddressProvisioningType is NoPublicIPAddresses. </summary>
        public IList<BatchInboundNatPool> EndpointInboundNatPools
        {
            get
            {
                if (EndpointConfiguration is null)
                {
                    EndpointConfiguration = new PoolEndpointConfiguration([]);
                }
                return EndpointConfiguration.InboundNatPools;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (value is null)
                {
                   EndpointConfiguration = null;
                }
                else
                {
                    if (EndpointConfiguration == null)
                    {
                        EndpointConfiguration = new PoolEndpointConfiguration([]);
                    }
                    else
                    {
                        EndpointConfiguration.InboundNatPools.Clear();
                    }
                    foreach (var item in value)
                    {
                        EndpointConfiguration.InboundNatPools.Add(item);
                    }
                }
            }
        }
    }
}
