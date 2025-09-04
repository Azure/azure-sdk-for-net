// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Kusto;

/// <summary>
/// KustoDatabase.
/// Please note that this class is the base class. Please use one of its derived classes:
/// <see cref="KustoReadOnlyFollowingDatabase"/> or <see cref="KustoReadWriteDatabase"/>.
/// </summary>
public abstract partial class KustoDatabase : ProvisionableResource
{ }
