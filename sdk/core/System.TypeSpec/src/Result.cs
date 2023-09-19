// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ServiceModel.Rest;

public abstract class Result // base of Response
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_EmptyBinaryData = new BinaryData(Array.Empty<byte>());

    public static Result<T> FromValue<T>(T value, Result result)
    {
        return new Result<T>(value, result);
    }

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

    public abstract int Status { get; }

    public abstract Stream? ContentStream { get; set; }

    public abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);
}
