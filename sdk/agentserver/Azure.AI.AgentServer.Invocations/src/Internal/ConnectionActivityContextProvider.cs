// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Publishes the connection activity context to typed protocol layers without
/// making protocol work wait for synchronous telemetry listeners.
/// </summary>
internal sealed class ConnectionActivityContextProvider
{
    private ActivityContext _context;
    private int _available;

    public void Publish(ActivityContext context)
    {
        if (Volatile.Read(ref _available) != 0)
        {
            return;
        }

        _context = context;
        Volatile.Write(ref _available, 1);
    }

    public bool TryGet(out ActivityContext context)
    {
        if (Volatile.Read(ref _available) != 0)
        {
            context = _context;
            return true;
        }

        context = default;
        return false;
    }
}
