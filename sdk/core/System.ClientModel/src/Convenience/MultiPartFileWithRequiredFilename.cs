// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// A file to be uploaded as part of a multipart request.
/// </summary>
public class MultiPartFileWithRequiredFilename
{
    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredFilename"/>.
    /// </summary>
    public MultiPartFileWithRequiredFilename(Stream contents, string filename)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        File = contents;
        Filename = filename;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MultiPartFileWithRequiredFilename"/>.
    /// </summary>
    public MultiPartFileWithRequiredFilename(BinaryData contents, string filename)
    {
        Argument.AssertNotNull(contents, nameof(contents));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        Contents = contents;
        Filename = filename;
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
    public string ContentType { get; set; } = "application/octet-stream";
}
