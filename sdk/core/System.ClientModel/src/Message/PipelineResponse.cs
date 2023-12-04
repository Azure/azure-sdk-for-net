// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_emptyBinaryData = new(Array.Empty<byte>());

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the HTTP reason phrase.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    public virtual MessageHeaders Headers
    {
        // We must make this property virtual because the Headers property on
        // Azure.Response that derives from it is virtual.  This property were
        // abstract, the newslotted Headers property on Response would hide an
        // abstract member, which is not valid in C#.  We throw from the getter
        // rather than providing a default implementation so that we don't commit
        // subtypes to a specific HTTP implementation.
        get => throw new NotSupportedException("Type derived from 'PipelineResponse' must implement 'Headers' property getter.");
    }

    /// <summary>
    /// Gets the contents of HTTP response. Returns <c>null</c> for responses without content.
    /// </summary>
    public abstract Stream? ContentStream { get; set; }

    #region Meta-data properties set by the pipeline.

    public BinaryData Content
    {
        get
        {
            if (ContentStream == null)
            {
                return s_emptyBinaryData;
            }

            if (!TryGetBufferedContent(out MemoryStream bufferedContent))
            {
                throw new InvalidOperationException($"The response is not buffered.");
            }

            if (bufferedContent.TryGetBuffer(out ArraySegment<byte> segment))
            {
                return new BinaryData(segment.AsMemory());
            }
            else
            {
                return new BinaryData(bufferedContent.ToArray());
            }
        }
    }

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public virtual bool IsError { get; protected internal set; }

    #endregion

    internal bool TryGetBufferedContent(out MemoryStream bufferedContent)
    {
        if (ContentStream is MemoryStream content)
        {
            bufferedContent = content;
            return true;
        }

        bufferedContent = default!;
        return false;
    }

    internal static bool ContentIsBuffered(Stream stream)
    {
        return stream is MemoryStream;
    }

    public abstract void Dispose();
}
