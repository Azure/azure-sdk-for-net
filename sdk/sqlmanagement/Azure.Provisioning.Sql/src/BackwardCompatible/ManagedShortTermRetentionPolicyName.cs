// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The ManagedShortTermRetentionPolicyName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum ManagedShortTermRetentionPolicyName
{
    /// <summary>
    /// Default.
    /// </summary>
    [DataMember(Name = "default")]
    Default,
}
