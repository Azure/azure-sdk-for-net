// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Database server metadata.
/// </summary>
public partial class PostgreSqlServerMetadata
{
    private PostgreSqlFlexibleServersServerSku _serverSku;

    /// <summary>
    /// SKU for the database server.
    /// </summary>
    public PostgreSqlFlexibleServersServerSku ServerSku
    {
        get { Initialize(); return _serverSku; }
    }

    /// <summary>
    /// SKU for the database server.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
#nullable enable
    public ServerSku? Sku
    {
        get => new ServerSku(ServerSku);
    }
#nullable disable

    partial void DefineAdditionalProperties()
    {
        _serverSku = DefineModelProperty<PostgreSqlFlexibleServersServerSku>(nameof(ServerSku), ["sku"], isOutput: true);
    }
}
