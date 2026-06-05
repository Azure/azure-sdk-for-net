// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The EncryptionProtectorName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum EncryptionProtectorName
{
    /// <summary>
    /// Current.
    /// </summary>
    [DataMember(Name = "current")]
    Current,
}
