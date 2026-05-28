// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// PostgreSqlFlexibleServer.
/// </summary>
public partial class PostgreSqlFlexibleServer : ProvisionableResource
{
    /// <summary>
    /// Max storage allowed for a server.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> StorageSizeInGB
    {
        get { Initialize(); return Storage.StorageSizeInGB; }
        set { Initialize(); Storage.StorageSizeInGB = value; }
    }
}
