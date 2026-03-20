// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward compatibility: the old autorest SDK constructor took only `name`.
    // The new TypeSpec SDK requires both `name` and `type`. This overload defaults
    // `type` to MicrosoftContainerRegistryRegistries for existing callers.
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
