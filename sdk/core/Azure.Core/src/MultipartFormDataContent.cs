// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    ///  Provides a container for content encoded using multipart/form-data MIME type.
    /// </summary>
    internal class MultipartFormDataContent : RequestContent
    {
        #region Fields

        private const string CrLf = "\r\n";
        private const string FormData = "form-data";

        private static readonly int s_crlfLength = GetEncodedLength(CrLf);
        private static readonly int s_dashDashLength = GetEncodedLength("--");
        private static readonly int s_colonSpaceLength = GetEncodedLength(": ");

        private readonly List<MultipartRequestContent> _nestedContent;
        private readonly string _boundary;

        #endregion Fields

        #region Construction

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataContent"/> class.
        /// </summary>
        public MultipartFormDataContent() : this(GetDefaultBoundary())
        { }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataContent"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartFormDataContent(string boundary)
        {
            ValidateBoundary(boundary);
            _boundary = boundary;
            _nestedContent = new List<MultipartRequestContent>();
        }

        private static void ValidateBoundary(string boundary)
        {
            // NameValueHeaderValue is too restrictive for boundary.
            // Instead validate it ourselves and then quote it.
            Argument.AssertNotNullOrWhiteSpace(boundary, nameof(boundary));

            // RFC 2046 Section 5.1.1
            // boundary := 0*69<bchars> bcharsnospace
            // bchars := bcharsnospace / " "
            // bcharsnospace := DIGIT / ALPHA / "'" / "(" / ")" / "+" / "_" / "," / "-" / "." / "/" / ":" / "=" / "?"
            if (boundary.Length > 70)
            {
                throw new ArgumentOutOfRangeException(nameof(boundary), boundary, $"The field cannot be longer than {70} characters.");
            }
            // Cannot end with space.
            if (boundary.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
            }

            const string AllowedMarks = @"'()+_,-./:=? ";

            foreach (char ch in boundary)
            {
                if (('0' <= ch && ch <= '9') || // Digit.
                    ('a' <= ch && ch <= 'z') || // alpha.
                    ('A' <= ch && ch <= 'Z') || // ALPHA.
                    AllowedMarks.Contains(char.ToString(ch))) // Marks.
                {
                    // Valid.
                }
                else
                {
                    throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
                }
            }
        }

        private static string GetDefaultBoundary()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        ///  Add content type header to the request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ApplyToRequest(Request request)
        {
            request.Headers.Add("Content-Type", $"multipart/form-data;boundary=\"{_boundary}\"");
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        public void Add(RequestContent content)
        {
            Argument.AssertNotNull(content, nameof(content));
            AddInternal(content, null, null, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(RequestContent content, Dictionary<string, string> headers)
        {
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(headers, nameof(headers));

            AddInternal(content, headers, null, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(RequestContent content, string name, Dictionary<string, string>? headers)
        {
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNullOrWhiteSpace(name, nameof(name));

            AddInternal(content, headers, name, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the reuest content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(RequestContent content, string name, string fileName, Dictionary<string, string>? headers)
        {
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNullOrWhiteSpace(name, nameof(name));
            Argument.AssertNotNullOrWhiteSpace(fileName, nameof(fileName));

            AddInternal(content, headers, name, fileName);
        }

        private void AddInternal(RequestContent content, Dictionary<string, string>? headers, string? name, string? fileName)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            if (!headers.ContainsKey("Content-Disposition"))
            {
                var value = FormData;

                if (name != null)
                {
                    value = value + "; name=" + name;
                }
                if (fileName != null)
                {
                    value = value + "; filename=" + fileName;
                }

                headers.Add("Content-Disposition", value);
            }

            _nestedContent.Add(new MultipartRequestContent(content, headers));
        }

        #endregion Construction

        #region Dispose

        /// <summary>
        ///  Frees resources held by the <see cref="MultipartFormDataContent"/> object.
        /// </summary>
        public override void Dispose()
        {
            foreach (MultipartRequestContent content in _nestedContent)
            {
                content.RequestContent.Dispose();
            }
            _nestedContent.Clear();

        }

        #endregion Dispose

        #region Serialization

        // for-each content
        //   write "--" + boundary
        //   for-each content header
        //     write header: header-value
        //   write content.WriteTo[Async]
        // write "--" + boundary + "--"
        // Can't be canceled directly by the user.  If the overall request is canceled
        // then the stream will be closed an exception thrown.
        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        ///
        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            try
            {
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    RequestContent content = _nestedContent[contentIndex].RequestContent;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    content.WriteTo(stream, cancellationToken);
                }

                // Write footer boundary.
                EncodeStringToStream(stream, CrLf + "--" + _boundary + "--" + CrLf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // for-each content
        //   write "--" + boundary
        //   for-each content header
        //     write header: header-value
        //   write content.WriteTo[Async]
        // write "--" + boundary + "--"
        // Can't be canceled directly by the user.  If the overall request is canceled
        // then the stream will be closed an exception thrown.
        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public override Task WriteToAsync(Stream stream, CancellationToken cancellation) =>
            SerializeToStreamAsync(stream, cancellation);

        private async Task SerializeToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            try
            {
                // Write start boundary.
                await EncodeStringToStreamAsync(stream, "--" + _boundary + CrLf, cancellationToken).ConfigureAwait(false);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    RequestContent content = _nestedContent[contentIndex].RequestContent;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    await EncodeStringToStreamAsync(stream, SerializeHeadersToString(output, contentIndex, headers), cancellationToken).ConfigureAwait(false);
                    await content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                // Write footer boundary.
                await EncodeStringToStreamAsync(stream, CrLf + "--" + _boundary + "--" + CrLf, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string SerializeHeadersToString(StringBuilder scratch, int contentIndex, Dictionary<string, string> headers)
        {
            scratch.Clear();

            // Add divider.
            if (contentIndex != 0) // Write divider for all but the first content.
            {
                scratch.Append(CrLf + "--"); // const strings
                scratch.Append(_boundary);
                scratch.Append(CrLf);
            }

            // Add headers.
            foreach (KeyValuePair<string, string> header in headers)
            {
                scratch.Append(header.Key);
                scratch.Append(": ");
                scratch.Append(header.Value);
                scratch.Append(CrLf);
            }

            // Extra CRLF to end headers (even if there are no headers).
            scratch.Append(CrLf);

            return scratch.ToString();
        }

        private static void EncodeStringToStream(Stream stream, string input)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            stream.Write(buffer, 0, buffer.Length);
        }

        private static Task EncodeStringToStreamAsync(Stream stream, string input, CancellationToken cancellationToken)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            return stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }

        /// <summary>
        /// Attempts to compute the length of the underlying content, if available.
        /// </summary>
        /// <param name="length">The length of the underlying data.</param>
        public override bool TryComputeLength(out long length)
        {
            int boundaryLength = GetEncodedLength(_boundary);

            long currentLength = 0;
            long internalBoundaryLength = s_crlfLength + s_dashDashLength + boundaryLength + s_crlfLength;

            // Start Boundary.
            currentLength += s_dashDashLength + boundaryLength + s_crlfLength;

            bool first = true;
            foreach (MultipartRequestContent content in _nestedContent)
            {
                if (first)
                {
                    first = false; // First boundary already written.
                }
                else
                {
                    // Internal Boundary.
                    currentLength += internalBoundaryLength;
                }

                // Headers.
                foreach (KeyValuePair<string, string> headerPair in content.Headers)
                {
                    currentLength += GetEncodedLength(headerPair.Key) + s_colonSpaceLength;
                    currentLength += GetEncodedLength(headerPair.Value);
                    currentLength += s_crlfLength;
                }

                currentLength += s_crlfLength;

                // Content.
                if (!content.RequestContent.TryComputeLength(out long tempContentLength))
                {
                    length = 0;
                    return false;
                }
                currentLength += tempContentLength;
            }

            // Terminating boundary.
            currentLength += s_crlfLength + s_dashDashLength + boundaryLength + s_dashDashLength + s_crlfLength;

            length = currentLength;
            return true;
        }

        private static int GetEncodedLength(string input)
        {
            return Encoding.Default.GetByteCount(input);
        }

        #endregion Serialization

        private class MultipartRequestContent
        {
            public readonly RequestContent RequestContent;
            public Dictionary<string, string> Headers;

            public MultipartRequestContent(RequestContent content, Dictionary<string, string> headers)
            {
                RequestContent = content;
                Headers = headers;
            }
        }
    }
}
