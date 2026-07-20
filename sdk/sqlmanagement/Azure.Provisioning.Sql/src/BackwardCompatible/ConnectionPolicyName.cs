// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The ConnectionPolicyName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum ConnectionPolicyName
{
    /// <summary>
    /// Default.
    /// </summary>
    [DataMember(Name = "default")]
    Default,
}
