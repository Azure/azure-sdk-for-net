// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward compatibility: suppress generated Scope/Status (no setters) and re-expose with setters.
    // The old autorest SDK exposed Scope and Status as get/set on the data class.
    [CodeGenSuppress("ContainerRegistryWebhookData", typeof(AzureLocation))]
    [CodeGenSuppress("Scope")]
    [CodeGenSuppress("Status")]
    public partial class ContainerRegistryWebhookData
    {
        // Backward compatibility: the generated constructor is internal. The old API
        // exposed a public constructor taking AzureLocation for creating webhook resources.
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryWebhookData"/>. </summary>
        /// <param name="location"> The location of the webhook. </param>
        public ContainerRegistryWebhookData(AzureLocation location) : base(default, default, default, default, default, location)
        {
        }

        /// <summary> The scope of repositories where the event can be triggered. </summary>
        [WirePath("properties.scope")]
        public string Scope
        {
            get => Properties?.Scope;
            set { }
        }

        /// <summary> The status of the webhook at the time the operation was called. </summary>
        [WirePath("properties.status")]
        public ContainerRegistryWebhookStatus? Status
        {
            get => Properties?.Status;
            set { }
        }
    }
}
