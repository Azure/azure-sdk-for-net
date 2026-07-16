// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA flattened status alias and enum type over generated Properties.Status.
    [CodeGenSuppress("Status")]
    public partial class MachineLearningSharedPrivateLinkResource
    {
        /// <summary> Connection status of the service consumer with the service provider. </summary>
        [WirePath("properties.status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpointServiceConnectionStatus? Status
        {
            get => Properties is null || !Properties.Status.HasValue ? null : new MachineLearningPrivateEndpointServiceConnectionStatus(Properties.Status.Value.ToString());
            set
            {
                Properties ??= new SharedPrivateLinkResourceProperty();
                Properties.Status = value.HasValue ? new EndpointServiceConnectionStatus(value.Value.ToString()) : null;
            }
        }
    }
}
