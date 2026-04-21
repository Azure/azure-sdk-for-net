// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SmartGroupModificationEvent
    {
        /// <summary> SmartGroupCreated. </summary>
        SmartGroupCreated = 0,
        /// <summary> StateChange. </summary>
        StateChange = 1,
        /// <summary> AlertAdded. </summary>
        AlertAdded = 2,
        /// <summary> AlertRemoved. </summary>
        AlertRemoved = 3,
    }
}
