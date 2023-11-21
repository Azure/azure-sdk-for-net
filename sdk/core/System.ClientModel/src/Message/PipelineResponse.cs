// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal.Primitives;
using System.IO;
using System.Net.Http;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_emptyBinaryData = new(Array.Empty<byte>());

    public static PipelineResponse Create(HttpResponseMessage response)
        => new HttpPipelineResponse(response);

    public abstract int Status { get; }

    public abstract string ReasonPhrase { get; }

    public abstract MessageHeaders Headers { get; }

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
    public bool IsError { get; internal set; }

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

    public abstract void Dispose();
}
