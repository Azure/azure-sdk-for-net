// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A file to be uploaded as part of a multipart request.
/// </summary>
public class MultiPartFileWithRequiredMetadata
{
    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredMetadata"/>.
    /// </summary>
    public MultiPartFileWithRequiredMetadata(Stream contents, string filename, string contentType)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        File = contents;
        Filename = filename;
        ContentType = contentType;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredMetadata"/>.
    /// </summary>
    public MultiPartFileWithRequiredMetadata(BinaryData contents, string filename, string contentType)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        Contents = contents;
        Filename = filename;
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
    public string Filename { get; }

    /// <summary>
    /// The content type of the file to be uploaded as part of a multipart request.
    /// </summary>
    public string ContentType { get; }
}
