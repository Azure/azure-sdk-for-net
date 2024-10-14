// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientRetryOptions
{
    internal const int DefaultMaxRetries = 3;
    internal static readonly TimeSpan DefaultMaxDelay = TimeSpan.FromMinutes(1);
    internal static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);

    // TODO: implement freezing
    private bool _frozen;

    public int MaxRetries { get; set; }

    public TimeSpan? MaxDelay { get; set; }

    public virtual void Freeze() => _frozen = true;

    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientLoggingOptions instance after ClientPipeline has been created.");
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
