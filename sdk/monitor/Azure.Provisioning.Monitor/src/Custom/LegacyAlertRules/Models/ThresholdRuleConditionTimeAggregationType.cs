// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// Aggregation operators allowed in a rule.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum ThresholdRuleConditionTimeAggregationType
{
    /// <summary>
    /// Average.
    /// </summary>
    Average,

    /// <summary>
    /// Minimum.
    /// </summary>
    Minimum,

    /// <summary>
    /// Maximum.
    /// </summary>
    Maximum,

    /// <summary>
    /// Total.
    /// </summary>
    Total,

    /// <summary>
    /// Last.
    /// </summary>
    Last,
}
