// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// The Sku name of the resource. The possible values are: Basic or Premium.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum EventGridSku
{
    /// <summary>
    /// Basic.
    /// </summary>
    Basic,

    /// <summary>
    /// Premium.
    /// </summary>
    Premium,
}
