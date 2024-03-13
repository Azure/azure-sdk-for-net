// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a collection of <see cref="BinaryContent"/> instances that are
/// formatted using the multipart/* content type specification.
/// </summary>
public partial class MultipartBinaryContent : BinaryContent, IDisposable
{
    private const string CrLf = "\r\n";
    private const string ColonSpace = ": ";
    private const string DashDash = "--";

    private protected static readonly byte[] s_crLfBytes = Encoding.UTF8.GetBytes(CrLf);
    private protected static readonly byte[] s_colonSpaceBytes = Encoding.UTF8.GetBytes(ColonSpace);
    private protected static readonly byte[] s_dashDashBytes = Encoding.UTF8.GetBytes(DashDash);

    private readonly List<MultipartContentSubpart> _subparts = new();
    private readonly string _boundary;
    private readonly string _contentType;

    /// <summary>
    /// The boundary string for the multipart content, which is used to separate the body parts.
    /// </summary>
    public string Boundary => _boundary;

    /// <summary>
    /// The boundary string for the multipart content, which is used to separate the body parts.
    /// </summary>
    public string ContentType => _contentType;

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartBinaryContent"/> class with a randomly generated boundary and default subtype of multipart/mixed.
    /// </summary>
    public MultipartBinaryContent() : this("mixed", Guid.NewGuid().ToString())
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartBinaryContent"/> class with the specified subtype and a randomly generated boundary.
    /// </summary>
    /// <param name="subtype">The subtype of the multipart content.</param>
    public MultipartBinaryContent(string subtype) : this(subtype, Guid.NewGuid().ToString())
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartBinaryContent"/> class with the specified boundary.
    /// </summary>
    /// <param name="subtype">The subtype of the multipart content.</param>
    /// <param name="boundary">The boundary string for the multipart content, which is used to separate the body parts.</param>
    public MultipartBinaryContent(string subtype, string boundary)
    {
        ValidateBoundary(boundary);
        ValidateSubtype(subtype);

        _boundary = boundary;

        if (!boundary.StartsWith("\"") && boundary.Contains(':'))
        {
            _contentType = $"multipart/{subtype}; boundary=\"{_boundary}\"";
        }
        else
        {
            _contentType = $"multipart/{subtype}; boundary={_boundary}";
        }
    }

    /// <summary>
    /// Adds a new <see cref="BinaryContent"/> instance to the collection of <see cref="BinaryContent"/> objects that get
    /// formatted into multipart/* content.
    /// </summary>
    /// <param name="part">The <see cref="BinaryContent"/> to add to the collection.</param>
    public void Add(BinaryContent part) => Add(part, Array.Empty<(string, string)>());

    /// <summary>
    /// Adds a new <see cref="BinaryContent"/> instance to the collection of <see cref="BinaryContent"/> objects that get
    /// formatted into multipart/* content.
    /// </summary>
    /// <param name="part">The <see cref="BinaryContent"/> to add to the collection.</param>
    /// <param name="headers">The headers to add to this <see cref="BinaryContent"/>'s section.</param>
    public void Add(BinaryContent part, (string Name, string Value)[] headers)
    {
        if (part == null)
        {
            throw new ArgumentNullException(nameof(part));
        }

        _subparts.Add(new MultipartContentSubpart(part, headers));
    }

    private static void ValidateSubtype(string subtype)
    {
        var allowedValues = new string[] { "mixed", "form-data" };
        if (!allowedValues.Contains(subtype, StringComparer.OrdinalIgnoreCase))
        {
            throw new ArgumentException($"The format of value '{subtype}' is invalid. The value must be 'mixed' or 'form-data'.", nameof(subtype));
        }
    }

    private static void ValidateBoundary(string boundary)
    {
        if (string.IsNullOrWhiteSpace(boundary))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(boundary));
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
    /// TODO.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public override bool TryComputeLength(out long length)
    {
        var boundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}{DashDash}{_boundary}").Length;

        // Footer boundary
        long multipartLength = 0;
        multipartLength += (boundaryBytes + s_dashDashBytes.Length);

        // Subparts
        foreach (var part in _subparts)
        {
            long partLength = 0;
            var couldComputeLength = part.Content.TryComputeLength(out partLength);
            if (!couldComputeLength)
            {
                // exit if we fail at any point
                length = 0;
                return false;
            }

            partLength += boundaryBytes;
            partLength += s_crLfBytes.Length; // before headers
            partLength += part.Headers.Sum(h => Encoding.UTF8.GetBytes(h.Name).Length + s_colonSpaceBytes.Length + Encoding.UTF8.GetBytes(h.Value).Length + s_crLfBytes.Length);
            partLength += s_crLfBytes.Length; // after headers

            multipartLength += partLength;
        }

        length = multipartLength;
        return true;
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        var firstBoundary = true;
        byte[] boundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}{DashDash}{_boundary}");
        byte[] firstBoundaryBytes = Encoding.UTF8.GetBytes($"{DashDash}{_boundary}");

        // Write the subparts to stream
        foreach (var part in _subparts)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Don't write a new line if this is the first boundary. This helps to avoid extra new lines
            // both at the beginning of the request and when using nested multipart content.
            if (firstBoundary)
            {
                await stream.WriteAsync(firstBoundaryBytes, 0, firstBoundaryBytes.Length).ConfigureAwait(false);
                firstBoundary = false;
            }
            else
            {
                await stream.WriteAsync(boundaryBytes, 0, boundaryBytes.Length).ConfigureAwait(false);
            }
            await part.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }
        byte[] endBoundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}--{_boundary}--");
        await stream.WriteAsync(endBoundaryBytes, 0, endBoundaryBytes.Length).ConfigureAwait(false);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
        var firstBoundary = true;
        byte[] boundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}{DashDash}{_boundary}");
        byte[] firstBoundaryBytes = Encoding.UTF8.GetBytes($"{DashDash}{_boundary}");

        // Write the subparts to stream
        foreach (var part in _subparts)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Don't write a new line if this is the first boundary. This helps to avoid extra new lines
            // both at the beginning of the request and when using nested multipart content.
            if (firstBoundary)
            {
                stream.Write(firstBoundaryBytes, 0, firstBoundaryBytes.Length);
                firstBoundary = false;
            }
            else
            {
                stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            }
            part.WriteTo(stream, cancellationToken);
        }
        byte[] endBoundaryBytes = Encoding.UTF8.GetBytes($"{CrLf}{DashDash}{_boundary}{DashDash}");
        stream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
    }

    /// <summary>
    /// Releases the unmanaged resources and disposes of the managed resources used by the <see cref="Primitives.MultipartBinaryContent"/>.
    /// </summary>
    public override void Dispose()
    {
        foreach (var subpart in _subparts)
        {
            subpart.Content.Dispose();
        }
        _subparts.Clear();
    }
}
