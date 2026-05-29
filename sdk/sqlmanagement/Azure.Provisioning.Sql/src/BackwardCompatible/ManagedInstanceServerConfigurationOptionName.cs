// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The ManagedInstanceServerConfigurationOptionName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum ManagedInstanceServerConfigurationOptionName
{
    /// <summary>
    /// AllowPolybaseExport.
    /// </summary>
    [DataMember(Name = "allowPolybaseExport")]
    AllowPolybaseExport,
}
