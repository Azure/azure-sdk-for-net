// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class SqlServerJobSchedule
{
    /// <summary>
    /// Schedule start time.
    /// Please use <see cref="StartsOn"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use StartsOn instead.", false)]
    public BicepValue<DateTimeOffset> StartOn
    {
        get => StartsOn;
        set => StartsOn = value;
    }

    /// <summary>
    /// Schedule end time.
    /// Please use <see cref="EndsOn"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use EndsOn instead.", false)]
    public BicepValue<DateTimeOffset> EndOn
    {
        get => EndsOn;
        set => EndsOn = value;
    }
}
