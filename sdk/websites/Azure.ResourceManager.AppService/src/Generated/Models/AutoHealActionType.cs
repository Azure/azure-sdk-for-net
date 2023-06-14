// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Predefined action to be taken. </summary>
    public enum AutoHealActionType
    {
        /// <summary> Recycle. </summary>
        Recycle,
        /// <summary> LogEvent. </summary>
        LogEvent,
        /// <summary> CustomAction. </summary>
        CustomAction
    }
}
