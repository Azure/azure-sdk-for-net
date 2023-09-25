// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Experimental.Core;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineRequest : IDisposable
{
    //public abstract bool IsHttps { get; }

    public abstract string ClientRequestId { get; set; }

    public abstract void SetMethod(string method);

    public abstract void SetUri(RequestUri uri);

    public abstract void SetHeaderValue(string name, string value);

    public abstract void SetContent(RequestBody content);

    //public abstract bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);

    //public abstract bool RemoveHeaderValue(string name);

    public abstract void Dispose();
}