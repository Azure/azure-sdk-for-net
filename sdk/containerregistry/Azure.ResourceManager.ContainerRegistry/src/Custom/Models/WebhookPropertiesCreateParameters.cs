// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward compatibility: make ServiceUri settable so it can be assigned
    // via the ContainerRegistryWebhookCreateOrUpdateContent wrapper.
    internal partial class WebhookPropertiesCreateParameters
    {
        /// <summary> The service URI for the webhook to post notifications. </summary>
        [WirePath("serviceUri")]
        public Uri ServiceUri { get; set; }
    }
}
