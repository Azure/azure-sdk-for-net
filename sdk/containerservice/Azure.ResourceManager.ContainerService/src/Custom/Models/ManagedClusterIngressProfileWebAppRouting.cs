// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSuppress("GatewayAPIImplementationsIstioMode")]
    public partial class ManagedClusterIngressProfileWebAppRouting
    {
        /// <summary> Whether to enable Istio as a Gateway API implementation for managed ingress with App Routing. </summary>
        [WirePath("gatewayAPIImplementations.appRoutingIstio.mode")]
        public GatewayApiIstioMode? GatewayApiImplementationsIstioMode
        {
            get
            {
                return GatewayAPIImplementations is null ? default : GatewayAPIImplementations.IstioMode;
            }
            set
            {
                if (GatewayAPIImplementations is null)
                {
                    GatewayAPIImplementations = new ManagedClusterWebAppRoutingGatewayAPIImplementations();
                }
                GatewayAPIImplementations.IstioMode = value;
            }
        }
    }
}
