// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    internal partial class WebhookPropertiesCreateParameters
    {
        /// <summary> The service URI for the webhook to post notifications. </summary>
        [WirePath("serviceUri")]
        public Uri ServiceUri { get; set; }
    }
}
