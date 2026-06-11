// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Reason for the modification. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
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
