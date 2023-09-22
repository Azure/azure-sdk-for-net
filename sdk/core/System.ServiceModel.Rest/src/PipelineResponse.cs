// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ServiceModel.Rest.Core;

// TODO: this does not include some members from Response (e.g. ClientRequestId). Is that OK?
// TODO: can we turn it into a class?
public abstract class PipelineResponse
{
    public abstract int Status { get; }
    public abstract BinaryData Content { get; }
    public abstract Stream? ContentStream { get; set; }
    //public abstract bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value);
    public abstract string ReasonPhrase { get; }

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    // TODO: we have to make IsError publicly settable, but we might not want this.  Rethink?
    public virtual bool IsError { get; set; }

    // TODO: Add isError
}
