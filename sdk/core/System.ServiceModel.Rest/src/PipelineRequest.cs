// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.ServiceModel.Rest.Experimental.Core;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineRequest : IDisposable
{
    public PipelineRequest(HttpMethod method)
    {
        Method = method;
    }

    //public abstract bool IsHttps { get; }

    public HttpMethod Method { get; }

    public abstract string ClientRequestId { get; set; }

    public abstract void SetMethod(string method);

    public abstract void SetUri(RequestUri uri);

    // TODO: Can we remove this in favor of a public Uri property?
    public abstract bool TryGetUri(out Uri uri);

    public abstract void SetHeaderValue(string name, string value);

    public abstract void SetContent(RequestBody content);

    // TODO: Can we remove this in favor of a public Content property?
    public abstract bool TryGetContent(out RequestBody content);

    //public abstract bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);

    //public abstract bool RemoveHeaderValue(string name);

    public abstract void Dispose();
}