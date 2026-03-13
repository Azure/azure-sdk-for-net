// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

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

        /// <summary> The resource type of the container registry. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerRegistryResourceType ResourceType => Type;
    }
}
