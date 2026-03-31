// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class InitContainerPropertiesDefinitionInstanceView
    {
        // backward-compat shim: old property returned IReadOnlyList<ContainerEvent>, new returns IReadOnlyList<Event>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ContainerEvent> Events
            => _events != null ? new UpCastReadOnlyList<ContainerEvent, Event>(_events) : null;
    }
}
