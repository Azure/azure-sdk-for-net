// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable enable

namespace Azure.AI.Agents.Persistent;

internal static class HttpMessageExtensions
{
    public static Response ExtractResponse(this HttpMessage message)
    {
        Response? response = message.Response;
        message.Response = null!;
        return response;
    }
}
