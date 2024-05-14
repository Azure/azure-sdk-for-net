// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading.Tasks;

namespace ClientModel.Tests.Internal.Mocks;

internal static class MockSyncAsyncInternalExtensions
{
    public static async Task<ServerSentEvent?> TryGetNextEventSyncOrAsync(this ServerSentEventReader reader, bool isAsync)
    {
        if (isAsync)
        {
            return await reader.TryGetNextEventAsync().ConfigureAwait(false);
        }
        else
        {
            return reader.TryGetNextEvent();
        }
    }
}
