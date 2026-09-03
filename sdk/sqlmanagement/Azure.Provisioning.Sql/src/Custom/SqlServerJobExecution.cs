// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class SqlServerJobExecution
{
    /// <summary>
    /// The time that the job execution started.
    /// Please use <see cref="StartsOn"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use StartsOn instead.", false)]
    public BicepValue<DateTimeOffset> StartOn => StartsOn;

    /// <summary>
    /// The time that the job execution completed.
    /// Please use <see cref="EndsOn"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use EndsOn instead.", false)]
    public BicepValue<DateTimeOffset> EndOn => EndsOn;

    /// <summary>
    /// Start time of the current attempt.
    /// Please use <see cref="CurrentAttemptStartsOn"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use CurrentAttemptStartsOn instead.", false)]
    public BicepValue<DateTimeOffset> CurrentAttemptStartOn => CurrentAttemptStartsOn;

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
