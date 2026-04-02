// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shim: EventType was renamed to Type in TypeSpec migration.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerEvent
    {
        /// <summary> The event type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EventType => Type;
    }
}
