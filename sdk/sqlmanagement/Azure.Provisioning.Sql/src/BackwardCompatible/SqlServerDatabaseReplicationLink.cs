// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class SqlServerDatabaseReplicationLink
{
    /// <summary>
    /// This property is obsolete and will be removed in a future version.
    /// Please use <see cref="Name"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<string> LinkId
    {
        get => Name;
        set => Name = value;
    }
}
