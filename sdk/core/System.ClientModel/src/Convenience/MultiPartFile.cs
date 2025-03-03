// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A file to be uploaded as part of a multipart request.
/// </summary>
public class MultiPartFile
{
    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFile"/>.
    /// </summary>
    public MultiPartFile(Stream contents, string? filename = default, string? contentType = default)
    {
        Argument.AssertNotNull(contents, nameof(contents));

        File = contents;
        Filename = filename;
        ContentType = contentType ?? "application/octet-stream";
    }

    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFile"/>.
    /// </summary>
    public MultiPartFile(BinaryData contents, string? filename = default, string? contentType = default)
    {
        Argument.AssertNotNull(contents, nameof(contents));

        Contents = contents;
        Filename = filename;
        ContentType = contentType ?? "application/octet-stream";
    }

    /// <summary>
    /// The file stream to be uploaded as part of a multipart request.
    /// </summary>
    public Stream? File { get; }

    /// <summary>
    /// The file contents to be uploaded as part of a multipart request.
    /// </summary>
    public BinaryData? Contents { get; }

    /// <summary>
    /// The name of the file to be uploaded as part of a multipart request.
    /// </summary>
    public string? Filename { get; }

    /// <summary>
    /// The content type of the file to be uploaded as part of a multipart request.
    /// </summary>
    public string ContentType { get; }
}
