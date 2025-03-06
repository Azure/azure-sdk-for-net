// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A file to be uploaded as part of a multipart request.
/// </summary>
public class MultiPartFileWithRequiredContentType
{
    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredContentType"/>.
    /// </summary>
    public MultiPartFileWithRequiredContentType(Stream contents, string contentType)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        File = contents;
        ContentType = contentType;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredContentType"/>.
    /// </summary>
    public MultiPartFileWithRequiredContentType(BinaryData contents, string contentType)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        Contents = contents;
        ContentType = contentType;
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
    public string ContentType { get; }
}
