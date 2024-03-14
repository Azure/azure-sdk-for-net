// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a collection of <see cref="BinaryContent"/> instances that are
/// formatted using the multipart/* content type specification.
/// </summary>
public sealed class MultipartBinaryContent : BinaryContent, IDisposable
{
    private readonly string _boundary;

    private static readonly Random _random = new();
    private static readonly char[] _boundaryValues = "()+,-./0123456789:=?ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz".ToCharArray();

    // TODO: I think we want to use MultipartContent and not MultipartFormDataContent
    // and let callers specify the functional pieces needed for the latter, but we should
    // validate this at the end of the exercise.
    private readonly MultipartContentAdapter _multipartContent;

    /// <summary>
    /// Creates a new instance of the <see cref="MultipartBinaryContent"/> class with the specified boundary.
    /// </summary>
    /// <param name="subtype">The subtype of the multipart content.</param>
    public MultipartBinaryContent(string subtype)
    {
        _boundary = CreateBoundary();
        _multipartContent = new MultipartContentAdapter(subtype, _boundary);

        // TODO: what does subtype do?  I had thought this was e.g. 'form-data'
        // but now I am wondering if this is available for the parts on not
        // the top-level media type.
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public void Add(string value, IEnumerable<(string Name, string Value)> headers)
    {
        // TODO: is array of tuples preferred for headers?

        // TODO: should we pass `mediaType` to constructor?  If so, which header
        // would we get that from in order to make sure the header ends up correct
        // in the final content stream?

        StringContent content = new StringContent(value);

        // TODO: in order to format the content headers for MPFD correctly, I think
        // we need to call the overloads on that type.  We can either check the media
        // type in the constuctor and create MultipartFormDataContent, or have the
        // ClientModel type be specific to that and always use it.  The latter means
        // we would avoid a downcast on each call to Add.
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TryGetHeaderValue(string name, out string? value)
    {
        if (_multipartContent.Headers.TryGetValues(name, out IEnumerable<string>? values) &&
            values is IEnumerable<string> headerValues)
        {
            // TODO: optimize this using Span<char> or alternate approach
            int i = 0;
            value = string.Empty;
            foreach (string headerValue in headerValues)
            {
                value += headerValue;
                if (i > 0)
                {
                    value += ";";
                }
                i++;
            }

            return true;
        }

        value = default;
        return false;
    }

    /// <inheritdoc/>
    public override bool TryComputeLength(out long length)
        => _multipartContent.TryComputeContentLength(out length);

    /// <inheritdoc/>
    public async override Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        => await _multipartContent.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

    /// <inheritdoc/>
    public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
    {
        // TODO: confirm that this method does what I think it does
        _multipartContent.WriteTo(stream, cancellationToken);
    }

    /// <inheritdoc/>
    public override void Dispose()
    {
        // TODO: implement Dispose according to standard pattern
        _multipartContent.Dispose();
    }

    private static string CreateBoundary()
    {
        // TODO: test it.

        Span<char> chars = new char[70];

        byte[] random = new byte[70];
        _random.NextBytes(random);

        int mask = _boundaryValues.Length - 1;
        for (int i = 0; i < 70; i++)
        {
            chars[i] = _boundaryValues[random[i] & mask];
        }

        return chars.ToString();
    }

    /// <summary>
    /// Allow access to protected methods from this type.
    /// </summary>
    private class MultipartContentAdapter : MultipartContent
    {
        public MultipartContentAdapter(string subpart, string boundary) : base(subpart, boundary)
        {
        }

        public bool TryComputeContentLength(out long length)
            => TryComputeLength(out length);

        public void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
#if NET6_0_OR_GREATER
            SerializeToStream(stream, context: default, cancellationToken);
#else
            // TODO: confirm that this does what I expect
            // TODO: Handle cancellation token?
            SerializeToStreamAsync(stream, context: default).RunSynchronously();
#endif
        }

        public async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
#if NET6_0_OR_GREATER
            await SerializeToStreamAsync(stream, context: default, cancellationToken).ConfigureAwait(false);
#else
            // TODO: Handle cancellation token?
            await SerializeToStreamAsync(stream, context: default).ConfigureAwait(false);
#endif
        }
    }
}
