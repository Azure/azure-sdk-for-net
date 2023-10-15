// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineResponse : IDisposable
{
    public abstract int Status { get; }

    public abstract string ReasonPhrase {  get; }

    public abstract Stream? ContentStream { get; protected internal set; }

    public abstract MessageHeaders Headers { get; }

    #region Meta-data properties set by the pipeline.

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public bool IsError { get; internal set; }

    /// <summary>
    /// Gets the contents of HTTP response, if it is available.
    /// </summary>
    /// <remarks>
    /// Throws <see cref="InvalidOperationException"/> when <see cref="ContentStream"/> is not a <see cref="MemoryStream"/>.
    /// </remarks>
    public BinaryData Content
    {
        get
        {
            if (ContentStream == null)
            {
                return PipelineMessage.EmptyContent;
            }

            // TODO: Keep this?
            // Questions: what assumptions is this making and/or dependencies
            // is it mandating?
            MemoryStream? memoryContent = ContentStream as MemoryStream ??
                throw new InvalidOperationException($"The response is not fully buffered.");

            if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
            {
                return new BinaryData(segment.AsMemory());
            }
            else
            {
                return new BinaryData(memoryContent.ToArray());
            }
        }
    }

    #endregion

    public abstract void Dispose();
}
