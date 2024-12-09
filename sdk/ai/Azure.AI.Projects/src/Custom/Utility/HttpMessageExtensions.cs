// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable enable

namespace Azure.AI.Projects;

internal static class HttpMessageExtensions
{
    public static Response ExtractResponse(this HttpMessage message)
    {
        Response? response = message.Response;
        message.Response = null!;
        return response;
    }
}
