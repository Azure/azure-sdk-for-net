// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.AI.Agents.Persistent;

internal static class CancellationTokenExtensions
{
    private static RequestContext DefaultRequestContext = new();

    public static RequestContext ToRequestContext(this CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return DefaultRequestContext;
        }

        return new() { CancellationToken = cancellationToken };
    }
}
