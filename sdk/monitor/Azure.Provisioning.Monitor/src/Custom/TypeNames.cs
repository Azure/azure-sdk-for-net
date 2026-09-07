// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Monitor;

// Preserve the previously shipped provisioning names where the TypeSpec names
// align with the management SDK instead.
[CodeGenType("DiagnosticSettingsResource")]
public partial class DiagnosticSetting
{
}

[CodeGenType("MonitorIncidentReceiver")]
public partial class IncidentReceiver
{
}

[CodeGenType("MonitorIncidentServiceConnection")]
public partial class IncidentServiceConnection
{
}

[CodeGenType("MonitorPrivateLinkScopedResource")]
public partial class MonitorPrivateLinkScoped
{
}

[CodeGenType("MetricAlertResolveConfiguration")]
public partial class ResolveConfiguration
{
}

/// <summary>
/// The incident management service type.
/// </summary>
[CodeGenType("MonitorIncidentManagementService")]
public enum IncidentManagementService
{
    /// <summary>
    /// Icm.
    /// </summary>
    Icm,
}

/// <summary>
/// The operator used to compare metric data and the threshold.
/// </summary>
[CodeGenType("MetricTriggerComparisonOperator")]
public enum MetricTriggerComparisonOperation
{
    /// <summary>
    /// Equals.
    /// </summary>
    [CodeGenMember("Equals")]
    EqualsValue,

    /// <summary>
    /// Not equals.
    /// </summary>
    NotEquals,

    /// <summary>
    /// Greater than.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Greater than or equal.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Less than.
    /// </summary>
    LessThan,

    /// <summary>
    /// Less than or equal.
    /// </summary>
    LessThanOrEqual,
}
