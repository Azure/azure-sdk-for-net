// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A file to be uploaded as part of a multipart request.
/// </summary>
public class MultiPartFileWithOptionalMetadata
{
    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithOptionalMetadata"/>.
    /// </summary>
    public MultiPartFileWithOptionalMetadata(Stream contents)
    {
        Argument.AssertNotNull(contents, nameof(contents));

        File = contents;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithOptionalMetadata"/>.
    /// </summary>
    public MultiPartFileWithOptionalMetadata(BinaryData contents)
    {
        Argument.AssertNotNull(contents, nameof(contents));

        Contents = contents;
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
    public string? Filename { get; set; }

    /// <summary>
    /// The content type of the file to be uploaded as part of a multipart request.
    /// </summary>
    public string ContentType { get; set; } = "application/octet-stream";
}
