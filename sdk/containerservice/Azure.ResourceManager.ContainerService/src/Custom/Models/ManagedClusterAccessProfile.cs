// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ContainerService;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterAccessProfile : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ManagedClusterAccessProfile"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public ManagedClusterAccessProfile(AzureLocation location) : base(location)
        {
        }

        /// <summary> Base64-encoded Kubernetes configuration file. </summary>
        [WirePath("properties.kubeConfig")]
        public byte[] KubeConfig
        {
            get
            {
                return Properties?.KubeConfig;
            }
            set
            {
                if (Properties != null)
                {
                    Properties.KubeConfig = value;
                }
            }
        }
    }
}
