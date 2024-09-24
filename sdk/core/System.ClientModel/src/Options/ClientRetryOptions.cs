// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientRetryOptions
{
    // Setting this option to true either causes ClientPipeline.Create to
    // create a pipeline with no retry policy, or disables retry functionality
    // in a policy if it is passed to a policy constructor.
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
