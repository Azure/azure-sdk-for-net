// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public abstract class Result
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_EmptyBinaryData = new BinaryData(Array.Empty<byte>());

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Result<T> FromValue<T>(T value, Result result)
    {
        return new Result<T>(value, result);
    }

    /// <summary>
    /// Gets the contents of HTTP response, if it is available.
    /// </summary>
    /// <remarks>
    /// Throws <see cref="InvalidOperationException"/> when <see cref="ContentStream"/> is not a <see cref="MemoryStream"/>.
    /// </remarks>
    public virtual BinaryData Content {
        get {
            if (ContentStream == null) {
                return s_EmptyBinaryData;
            }

            MemoryStream? memoryContent = ContentStream as MemoryStream;

            if (memoryContent == null) {
                throw new InvalidOperationException($"The response is not fully buffered.");
            }

            if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment)) {
                return new BinaryData(segment.AsMemory());
            }
            else {
                return new BinaryData(memoryContent.ToArray());
            }
        }
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract Stream? ContentStream { get; set; }

    /// <summary>
    /// Returns header value if the header is stored in the collection. If header has multiple values they will be joined with a comma.
    /// </summary>
    /// <param name="name">The header name.</param>
    /// <param name="value">The reference to populate with value.</param>
    /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
    public bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value) => TryGetHeader(name, out value);

    /// <summary>
    /// Returns header value if the header is stored in the collection. If header has multiple values they will be joined with a comma.
    /// </summary>
    /// <param name="name">The header name.</param>
    /// <param name="value">The reference to populate with value.</param>
    /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
    protected abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);
}
