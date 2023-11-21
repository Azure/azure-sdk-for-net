// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal.Primitives;
using System.Net.Http;

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    public static PipelineRequest Create()
        => new HttpPipelineRequest();

    public static bool TryGetHttpRequest(PipelineRequest request,
        out HttpRequestMessage httpRequest)
    {
        if (request is HttpPipelineRequest httpPipelineRequest &&
            httpPipelineRequest.HttpRequest is not null)
        {
            httpRequest = httpPipelineRequest.HttpRequest;
            return true;
        }

        httpRequest = default!;
        return false;
    }

    public abstract string Method { get; set; }

    public abstract Uri Uri { get; set; }

    public abstract InputContent? Content { get; set; }

    public abstract MessageHeaders Headers { get; }

    public abstract void Dispose();
}