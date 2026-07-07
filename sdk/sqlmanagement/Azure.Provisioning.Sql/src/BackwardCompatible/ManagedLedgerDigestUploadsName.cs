// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The ManagedLedgerDigestUploadsName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum ManagedLedgerDigestUploadsName
{
    /// <summary>
    /// Current.
    /// </summary>
    [DataMember(Name = "current")]
    Current,
}
