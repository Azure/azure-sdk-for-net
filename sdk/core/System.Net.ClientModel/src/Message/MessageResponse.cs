// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.Net.ClientModel.Core;

public abstract class MessageResponse : IDisposable
{
    public abstract int Status { get; }

    public abstract string ReasonPhrase {  get; }

    public abstract MessageHeaders Headers { get; }

    /// <summary>
    /// Gets the contents of HTTP response, if it is available.
    /// </summary>
    /// <remarks>
    /// Throws <see cref="InvalidOperationException"/> when <see cref="ContentStream"/> is not a <see cref="MemoryStream"/>.
    /// </remarks>
    public virtual BinaryData Content
    {
        get
        {
            if (ContentStream == null)
            {
                return ClientMessage.EmptyBinaryData;
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

    /// <summary>
    /// TBD.  Needed for inheritdoc.
    /// </summary>
    public abstract Stream? ContentStream { get; set; }

    internal bool ContentIsBuffered => ContentStream is MemoryStream;

    #region Meta-data properties set by the pipeline.

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public bool IsError { get; internal set; }

    #endregion

    public abstract void Dispose();
}
