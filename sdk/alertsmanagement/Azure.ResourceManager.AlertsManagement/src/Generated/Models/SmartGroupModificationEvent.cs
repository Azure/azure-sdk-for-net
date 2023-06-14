// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Reason for the modification. </summary>
    public enum SmartGroupModificationEvent
    {
        /// <summary> SmartGroupCreated. </summary>
        SmartGroupCreated,
        /// <summary> StateChange. </summary>
        StateChange,
        /// <summary> AlertAdded. </summary>
        AlertAdded,
        /// <summary> AlertRemoved. </summary>
        AlertRemoved
    }
}
