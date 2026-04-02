// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class InitContainerPropertiesDefinitionInstanceView
    {
        /// <summary> The events of the init container. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ContainerEvent> Events =>
            new Azure.ResourceManager.ContainerInstance.UpCastReadOnlyList<ContainerEvent, Event>(_events);
    }
}
