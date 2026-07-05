// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The name of the container registry. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerRegistryNameAvailabilityContent(string name)
            : this(name, ContainerRegistryResourceType.MicrosoftContainerRegistryRegistries)
        {
        }
    }
}
