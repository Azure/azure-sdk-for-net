// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineResponse : IDisposable
{
    public abstract int Status { get; }
    public abstract BinaryData Content { get; }
    public abstract Stream? ContentStream { get; set; }
    public abstract bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);
    public abstract string ReasonPhrase { get; }

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public bool IsError { get; set; }

    protected abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);
    protected abstract bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values);
    protected abstract bool ContainsHeader(string name);
    public abstract void Dispose();
    //protected abstract bool ContainsHeaderValues(string name);
}
