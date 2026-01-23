// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> The ingress gateway access credentials. </summary>
    public partial class IngressGatewayAsset
    {
        /// <summary> The arc ingress gateway server app id. </summary>
        public Guid? ServerId
        {
            get
            {
                return Ingress.ServerId;
            }
        }

        /// <summary> The target resource home tenant id. </summary>
        public Guid? TenantId
        {
            get
            {
                return Ingress.TenantId;
            }
        }
    }
}
