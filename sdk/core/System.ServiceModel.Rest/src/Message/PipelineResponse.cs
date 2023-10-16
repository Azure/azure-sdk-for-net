// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineResponse : IDisposable
{
    public abstract int Status { get; }

    public abstract string ReasonPhrase {  get; }

    public abstract MessageHeaders Headers { get; }

    public abstract PipelineContent? Content { get; protected internal set; }

    protected internal virtual void OnMessageDisposed(bool disposeContentStream) { }

    #region Meta-data properties set by the pipeline.

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public bool IsError { get; internal set; }

    #endregion

    public abstract void Dispose();
}
