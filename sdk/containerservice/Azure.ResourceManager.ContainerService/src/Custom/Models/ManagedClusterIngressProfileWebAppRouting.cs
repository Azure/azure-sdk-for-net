// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

namespace Azure.ResourceManager.ContainerService.Models
{
    // Rename API -> Api to follow .NET acronym casing guidance.
    [CodeGenSuppress("GatewayAPIImplementationsIstioMode")]
    public partial class ManagedClusterIngressProfileWebAppRouting
    {
        /// <summary> Whether to enable Istio as a Gateway API implementation for managed ingress with App Routing. </summary>
        [CodeGenMember("GatewayAPIImplementationsIstioMode")]
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
