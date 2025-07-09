// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// CosmosDBService.
/// </summary>
public partial class CosmosDBService
{
    /// <summary>
    /// Services response resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public CosmosDBServiceProperties Properties
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}
