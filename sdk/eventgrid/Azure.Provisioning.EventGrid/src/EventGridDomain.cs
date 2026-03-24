// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// EventGridDomain.
/// </summary>
public partial class EventGridDomain
{
    /// <summary>
    /// The Sku name of the resource. The possible values are: Basic or Premium.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<EventGridSku> SkuName
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}
