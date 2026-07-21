// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace ClientModel.Tests.Collections;

public class MockStreamedData
{
    public const int TotalItemCount = 3;

    private static ReadOnlySpan<byte> TerminalData => "[DONE]"u8;

    // Note: need extra line because raw string literal removes \n from final line.
    public const string DefaultMockContent = """
        id: 0
        retry: 1500
        event: event.0
        data: { "id": 0, "value": "0" }

        id: 1
        event: event.1
        data: { "id": 1, "value": "1" }

        id: 2
        event: event.2
        data: { "id": 2, "value": "2" }

        event: done
        data: [DONE]


        """;

    public const string JsonlMockContent = """
        { "id": 0, "value": "0" }

        { "id": 1, "value": "1" }
        { "id": 2, "value": "2" }

        """;

    public static bool IsTerminalEvent(byte[] data)
    {
        return data.AsSpan().SequenceEqual(TerminalData);
    }
}
