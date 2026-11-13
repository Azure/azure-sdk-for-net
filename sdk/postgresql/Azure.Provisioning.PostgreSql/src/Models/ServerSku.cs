// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Sku information related properties of a server.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Renamed to PostgreSqlFlexibleServersServerSku
public partial class ServerSku : ProvisionableConstruct
{
    private PostgreSqlFlexibleServersServerSku _sku;

    /// <summary>
    /// The name of the sku, typically, tier + family + cores, e.g.
    /// Standard_D4s_v3.
    /// </summary>
    public BicepValue<string> Name => _sku.Name;

    /// <summary>
    /// The tier of the particular SKU, e.g. Burstable.
    /// </summary>
    public BicepValue<PostgreSqlFlexibleServerSkuTier> Tier => _sku.Tier;

    /// <summary>
    /// Creates a new ServerSku.
    /// </summary>
    public ServerSku() : this(new()) { }

    internal ServerSku(PostgreSqlFlexibleServersServerSku sku)
    {
        _sku = sku;
    }
}
