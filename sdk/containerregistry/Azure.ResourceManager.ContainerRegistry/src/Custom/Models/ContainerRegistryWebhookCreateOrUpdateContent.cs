// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward compatibility: the old API exposed ServiceUri with a setter.
    // The new generated code wraps the flattened property as get-only.
    [CodeGenSuppress("ServiceUri")]
    public partial class ContainerRegistryWebhookCreateOrUpdateContent
    {
        /// <summary> The service URI for the webhook to post notifications. </summary>
        [WirePath("properties.serviceUri")]
        public Uri ServiceUri
        {
            get => Properties is null ? default : Properties.ServiceUri;
            set
            {
                if (Properties is null)
                {
                    Properties = new WebhookPropertiesCreateParameters();
                }
                Properties.ServiceUri = value;
            }
        }
    }
}
