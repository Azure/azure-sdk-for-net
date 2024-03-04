// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a collection of <see cref="BinaryContent"/> instances that are formatted using the multipart/* content type specification.
/// </summary>
public class MultipartContent : IDisposable
{
    private const string CrLf = "\r\n";
    private readonly List<MultipartContentSubpart> _subparts = new();
    private readonly string _boundary;

    /// <summary>
    /// The boundary string for the multipart content, which is used to separate the body parts.
    /// </summary>
    public string Boundary => _boundary;

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartContent"/> class with a randomly generated boundary.
    /// </summary>
    public MultipartContent() : this(Guid.NewGuid().ToString())
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartContent"/> class with the specified boundary.
    /// </summary>
    /// <param name="boundary">The boundary string for the multipart content, which is used to separate the body parts.</param>
    public MultipartContent(string boundary)
    {
        ValidateBoundary(boundary);

        // see https://www.ietf.org/rfc/rfc1521.txt page 29.
        _boundary = boundary.Contains(':') ? $"\"{boundary}\"" : boundary;
    }

    /// <summary>
    /// Gets the <see cref="ContentType"/> of this multipart body, to be used when formatting the request.
    /// </summary>
    /// <param name="contentType"></param>
    public ContentType GetContentType(ContentType contentType)
    {
        if (contentType == null)
        {
            throw new ArgumentNullException(nameof(contentType));
        }

        contentType.Boundary = _boundary;
        return contentType;
    }

    /// <summary>
    /// Returns the content of the <see cref="MultipartContent"/> as a <see cref="BinaryContent"/>.
    /// </summary>
    public BinaryContent ToBinaryContent() => new MultipartBinaryContent(_subparts, _boundary);

    /// <summary>
    /// Adds a new <see cref="BinaryContent"/> instance to the collection of <see cref="BinaryContent"/> objects that get
    /// formatted into multipart/* content.
    /// </summary>
    /// <param name="content">The <see cref="BinaryContent"/> to add to the collection.</param>
    public void Add(BinaryContent content) => Add(content, new Dictionary<string, string>());

    /// <summary>
    /// Adds a new <see cref="BinaryContent"/> instance to the collection of <see cref="BinaryContent"/> objects that get
    /// formatted into multipart/* content.
    /// </summary>
    /// <param name="content">The <see cref="BinaryContent"/> to add to the collection.</param>
    /// <param name="headers">The headers to add to this <see cref="BinaryContent"/>'s section.</param>
    public void Add(BinaryContent content, Dictionary<string, string> headers)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (headers == null)
        {
            throw new ArgumentNullException(nameof(headers));
        }

        _subparts.Add(new MultipartContentSubpart(content, headers));
    }

    private static void ValidateBoundary(string boundary)
    {
        if (string.IsNullOrWhiteSpace(boundary))
        {
            throw new ArgumentException("Value cannot be null or empty.", boundary);
        }

        // RFC 2046 Section 5.1.1

        if (boundary.Length > 70)
        {
            throw new ArgumentOutOfRangeException(nameof(boundary), boundary, $"The field cannot be longer than {70} characters.");
        }

        if (boundary.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ArgumentException($"The format of value '{boundary}' is invalid. '{boundary}' cannot end in a space", nameof(boundary));
        }

        foreach (char ch in boundary)
        {
            const string AllowedMarks = @"'()+_,-./:=? ";
            if (!(('0' <= ch && ch <= '9') || // Digit.
                    ('a' <= ch && ch <= 'z') || // alpha.
                    ('A' <= ch && ch <= 'Z') || // ALPHA.
                    AllowedMarks.Contains(char.ToString(ch)))) // Marks.
            {
                throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
            }
        }
    }

    /// <summary>
    /// Releases the unmanaged resources and disposes of the managed resources used by the <see cref="MultipartContent"/>.
    /// </summary>
    public void Dispose()
    {
    }

    #region Subpart

    /// <summary>
    /// A helper class representing a subpart of a multipart content.
    /// </summary>
    private class MultipartContentSubpart
    {
        /// <summary>
        /// The <see cref="BinaryContent"/> that represents the content of this subpart.
        /// </summary>
        public BinaryContent Content { get; }

        /// <summary>
        /// The headers for this subpart.
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        public MultipartContentSubpart(BinaryContent content, Dictionary<string, string> headers)
        {
            Content = content;
            Headers = headers;
        }

        /// <summary>
        /// Writes the <see cref="Headers"/> and <see cref="Content"/> of this subpart to the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write to.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal cancellation of the write operation.</param>
        public void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            // Write headers on a new line
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            stream.Write(crlf, 0, crlf.Length);

            // Write the headers to stream
            foreach (var header in Headers)
            {
                string headerString = $"{header.Key}: {header.Value}{CrLf}";
                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
                stream.Write(headerBytes, 0, headerBytes.Length);
            }

            // Add another line
            stream.Write(crlf, 0, crlf.Length);

            // Write the content to stream
            Content.WriteTo(stream, cancellationToken);
        }

        /// <summary>
        /// Writes the <see cref="Headers"/> and <see cref="Content"/> of this subpart to the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write to.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal cancellation of the write operation.</param>
        public async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            // Write headers on a new line
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            await stream.WriteAsync(crlf, 0, crlf.Length, cancellationToken).ConfigureAwait(false);

            // Write the headers to stream
            foreach (var header in Headers)
            {
                string headerString = $"{header.Key}: {header.Value}{CrLf}";
                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
                await stream.WriteAsync(headerBytes, 0, headerBytes.Length, cancellationToken).ConfigureAwait(false);
            }

            // Add another line
            await stream.WriteAsync(crlf, 0, crlf.Length, cancellationToken).ConfigureAwait(false);

            // Write the content to stream
            await Content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }
    }

    #endregion

    #region BinaryContent return helper
    /// <summary>
    /// A helper class to return a <see cref="MultipartContent"/> as a <see cref="BinaryContent"/>.
    /// </summary>
    private class MultipartBinaryContent : BinaryContent
    {
        private readonly List<MultipartContentSubpart> _subParts;
        private string _boundary;

        public MultipartBinaryContent(List<MultipartContentSubpart> subParts, string boundary)
        {
            _subParts = subParts;
            _boundary = boundary;
        }

        public override void Dispose() { }

        public override bool TryComputeLength(out long length)
        {
            throw new NotImplementedException();
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            // Write the subparts to stream
            foreach (var part in _subParts)
            {
                byte[] boundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}--{_boundary}");
                stream.Write(boundaryBytes, 0, boundaryBytes.Length);
                part.WriteTo(stream, cancellationToken);
            }
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}--{_boundary}--");
            stream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            // Write the subparts to stream
            foreach (var part in _subParts)
            {
                byte[] boundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}--{_boundary}");
                await stream.WriteAsync(boundaryBytes, 0, boundaryBytes.Length).ConfigureAwait(false);
                await part.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}--{_boundary}--");
            await stream.WriteAsync(endBoundaryBytes, 0, endBoundaryBytes.Length).ConfigureAwait(false);
        }
    }
    #endregion
}
