// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: the TypeSpec spec (models.tsp AlertModificationEvent) and the
// Swagger spec (2025-05-25-preview) define only 6 enum values: AlertCreated, StateChange,
// SeverityChange, MonitorConditionChange, ActionsTriggered, ActionsSuppressed.
// The old SDK (AutoRest-based, v1.1.1) had 9 values including ActionRuleTriggered,
// ActionRuleSuppressed, and ActionsFailed. This custom enum restores all 9 values to
// maintain backward compatibility with existing code that references these members.
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Reason for the modification. </summary>
    public enum ServiceAlertModificationEvent
    {
        /// <summary> AlertCreated. </summary>
        AlertCreated,
        /// <summary> StateChange. </summary>
        StateChange,
        /// <summary> MonitorConditionChange. </summary>
        MonitorConditionChange,
        /// <summary> SeverityChange. </summary>
        SeverityChange,
        /// <summary> ActionRuleTriggered. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ActionRuleTriggered,
        /// <summary> ActionRuleSuppressed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ActionRuleSuppressed,
        /// <summary> ActionsTriggered. </summary>
        ActionsTriggered,
        /// <summary> ActionsSuppressed. </summary>
        ActionsSuppressed,
        /// <summary> ActionsFailed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ActionsFailed,
    }
}
