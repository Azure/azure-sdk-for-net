// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.Storage;

public partial class StorageServiceAccessPolicy
{
    /// <summary> Gets or sets the start time of the access policy. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use StartsOn instead.")]
    public BicepValue<DateTimeOffset> StartOn
    {
        get => StartsOn;
        set => StartsOn = value;
    }
}
