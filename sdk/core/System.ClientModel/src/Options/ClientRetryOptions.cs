// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientRetryOptions
{
    //private static readonly ClientRetryOptions _defaultRetryOptions = new();
    //internal static ClientRetryOptions Default => _defaultRetryOptions;

    // This should remove the retry policy from the pipeline, or disable it if
    // passed to a policy constructor.
    public bool? DisableRetries { get; set; }

    public TimeSpan? MaxDelay { get; set; }

    public int? MaxRetries { get; set; }

    /// <summary>
    /// True if user provided a value for one of the options on this type.
    /// </summary>
    internal bool AreSet => DisableRetries != null ||
        MaxDelay != null ||
        MaxRetries != null;
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
