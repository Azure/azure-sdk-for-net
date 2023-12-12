// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_emptyBinaryData = new(Array.Empty<byte>());

    private bool _isError = false;

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the HTTP reason phrase.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    public MessageHeaders Headers => GetHeadersCore();

    protected abstract MessageHeaders GetHeadersCore();

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
    // IsError must be virtual in order to maintain Azure.Core back-compatibility.
    public virtual bool IsError { get; }

    // We have to have a separate method for setting IsError so that the IsError
    // setter doesn't become virtual when we make the getter virtual.
    internal void SetIsError(bool isError)
        => SetIsErrorCore(isError);

    protected virtual void SetIsErrorCore(bool isError)
        => _isError = isError;

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
