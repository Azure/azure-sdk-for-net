// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// EventGridTopic.
/// </summary>
public partial class EventGridTopic
{
    /// <summary>
    /// Extended location of the resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ExtendedAzureLocation ExtendedLocation
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }

    /// <summary>
    /// Kind of the resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<ResourceKind> Kind
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }

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
