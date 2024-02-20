// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A Content in multipart format.
    /// </summary>
    public abstract class Multipart : IDisposable
    {
        private const string CrLf = "\r\n";
        private const string ColonSP = ": ";
        private const int BufferSize = 1024;

        private protected static readonly int s_crlfLength = GetEncodedLength(CrLf);
        private protected static readonly int s_dashDashLength = GetEncodedLength("--");
        private protected static readonly int s_colonSpaceLength = GetEncodedLength(ColonSP);
        private protected readonly List<MultipartBodyPart> _nestedContent;
        private protected readonly string _subtype;
        private protected readonly string _boundary;
        internal readonly Dictionary<string, string> _headers;
        //private protected readonly string MultipartContentTypePrefix = "multipart/mixed; boundary=";
        public readonly string ContentType;

        /// <summary> The list of request content parts. </summary>
        public List<MultipartBodyPart> ContentParts => _nestedContent;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        ///  </summary>
        public Multipart()
            : this("mixed", GetDefaultBoundary())
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        public Multipart(string subtype)
            : this(subtype, GetDefaultBoundary())
        {
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public Multipart(string subtype, string boundary) : this(subtype, boundary, new List<MultipartBodyPart>())
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        internal Multipart(string subtype, string boundary, IReadOnlyList<MultipartBodyPart> nestedContent)
        {
            ValidateBoundary(boundary);
            _subtype = subtype;

            // see https://www.ietf.org/rfc/rfc1521.txt page 29.
            _boundary = boundary.Contains(":") ? $"\"{boundary}\"" : boundary;
            _headers = new Dictionary<string, string>
            {
                ["Content-Type"] = $"multipart/{_subtype}; boundary={_boundary}"
            };
            ContentType = $"multipart/{_subtype}; boundary={_boundary}";
            _nestedContent = nestedContent.ToList<MultipartBodyPart>();
        }

        private static string GetDefaultBoundary()
        {
            return Guid.NewGuid().ToString();
        }

        private static void ValidateBoundary(string boundary)
        {
            if (string.IsNullOrWhiteSpace(boundary))
            {
                throw new ArgumentException("Value cannot be null or empty.", boundary);
            }

            // cspell:disable
            // RFC 2046 Section 5.1.1
            // boundary := 0*69<bchars> bcharsnospace
            // bchars := bcharsnospace / " "
            // bcharsnospace := DIGIT / ALPHA / "'" / "(" / ")" / "+" / "_" / "," / "-" / "." / "/" / ":" / "=" / "?"
            // cspell:enable
            if (boundary.Length > 70)
            {
                throw new ArgumentOutOfRangeException(nameof(boundary), boundary, $"The field cannot be longer than {70} characters.");
            }
            // Cannot end with space.
            if (boundary.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
            }

            foreach (char ch in boundary)
            {
                if (!IsValidBoundaryCharacter(ch))
                {
                    throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
                }
            }
        }
        private static bool IsValidBoundaryCharacter(char ch)
        {
            const string AllowedMarks = @"'()+_,-./:=? ";
            if (('0' <= ch && ch <= '9') || // Digit.
                    ('a' <= ch && ch <= 'z') || // alpha.
                    ('A' <= ch && ch <= 'Z') || // ALPHA.
                    AllowedMarks.Contains(char.ToString(ch))) // Marks.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Add HTTP content to a collection of Content objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        public virtual void Add(object content)
        {
            AddInternal(content, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of binary data objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public virtual void Add(object content, Dictionary<string, string> headers)
        {
            AddInternal(content, headers);
        }

        /// <summary>
        ///  Combine all the parts to BinaryData Content.
        /// </summary>
        // for-each content
        // write "--" + boundary
        // for-each content header
        // write header: header-value
        // write content.WriteTo[Async]
        // write "--" + boundary + "--"
        private protected BinaryData ToBinaryData()
        {
            try
            {
                using MemoryStream stream = new MemoryStream();
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    object content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    byte[] buffer;
                    switch (content)
                    {
                        case BinaryData b:
                            buffer = b.ToArray();
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case string str:
                            buffer = Encoding.UTF8.GetBytes(str);
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case byte[] bytes:
                            buffer = bytes;
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case Int32 int32Data:
                            buffer = BitConverter.GetBytes(int32Data);
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case Stream streamData:
                            buffer = new byte[BufferSize];
                            int numBytesToRead = BufferSize;
                            long numBytesRemaining = streamData.Length;
                            while (numBytesRemaining > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = streamData.Read(buffer, 0, numBytesToRead);

                                // Break when the end of the file is reached.
                                if (n == 0)
                                    break;

                                numBytesRemaining -= n;
                                stream.Write(buffer, 0, n);
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported content type");
                    }
                }

                // Write footer boundary.
                EncodeStringToStream(stream, CrLf + "--" + _boundary + "--" + CrLf);
                string contentType = $"multipart/{_subtype}; boundary={_boundary}";
                BinaryData binaryData;
                if (stream.Position > int.MaxValue)
                {
                    binaryData = BinaryData.FromStream(stream, contentType);
                }
                else
                {
                    binaryData = new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position), contentType);
                }
                return binaryData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private protected void WriteToStream(Stream stream)
        {
            try
            {
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    //BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    byte[] buffer;
                    switch (_nestedContent[contentIndex].Content)
                    {
                        case BinaryData binaryData:
                            buffer = binaryData.ToArray();
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case string str:
                            buffer = Encoding.UTF8.GetBytes(str);
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case byte[] bytes:
                            buffer = bytes;
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case Int32 int32Data:
                            buffer = BitConverter.GetBytes(int32Data);
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case Stream streamData:
                            buffer = new byte[BufferSize];
                            int numBytesToRead = BufferSize;
                            long numBytesRemaining = streamData.Length;
                            while (numBytesRemaining > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = streamData.Read(buffer, 0, numBytesToRead);

                                // Break when the end of the file is reached.
                                if (n == 0)
                                    break;

                                numBytesRemaining -= n;
                                stream.Write(buffer, 0, n);
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported content type");
                    }
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
        private protected Task WriteToStreamAsync(Stream stream, CancellationToken cancellation) =>
            SerializeToStreamAsync(stream, cancellation);
        private async Task<string> SerializeToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            string contentType = $"multipart/{_subtype}; boundary={_boundary}";
            try
            {
                // Write start boundary.
                await EncodeStringToStreamAsync(stream, "--" + _boundary + CrLf, cancellationToken).ConfigureAwait(false);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    await EncodeStringToStreamAsync(stream, SerializeHeadersToString(output, contentIndex, headers), cancellationToken).ConfigureAwait(false);
                    //byte[] buffer = _nestedContent[contentIndex].Content.ToArray();
                    byte[] buffer;
                    switch (_nestedContent[contentIndex].Content)
                    {
                        case BinaryData binaryData:
                            buffer = binaryData.ToArray();
                            await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                            break;
                        case string str:
                            buffer = Encoding.UTF8.GetBytes(str);
                            await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                            break;
                        case byte[] bytes:
                            buffer = bytes;
                            await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                            break;
                        case int i:
                            buffer = BitConverter.GetBytes(i);
                            await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                            break;
                        case Stream streamData:
                            buffer = new byte[BufferSize];
                            int numBytesToRead = BufferSize;
                            long numBytesRemaining = streamData.Length;
                            while (numBytesRemaining > 0)
                            {
                                // Read may return anything from 0 to numBytesToRead.
                                int n = streamData.Read(buffer, 0, numBytesToRead);

                                // Break when the end of the file is reached.
                                if (n == 0)
                                    break;

                                numBytesRemaining -= n;
                                await stream.WriteAsync(buffer, 0, n, cancellationToken).ConfigureAwait(false);
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported content type");
                    }
                }

                // Write footer boundary.
                await EncodeStringToStreamAsync(stream, CrLf + "--" + _boundary + "--" + CrLf, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return contentType;
        }
        /// <summary>
        ///  Read the content from BinaryData and parse it.
        ///  each part of BinaryData separted by boundary will be parsed as one MultipartContentPart.
        /// </summary>
        private static async Task<IReadOnlyList<MultipartBodyPart>> ReadAsync(BinaryData data, string subType = "mixed", string boundary = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(data));
            }
            string prefix = $"multipart/{subType}; boundary=";
            if (boundary == null)
            {
                string contentType = data.MediaType;
                if (string.IsNullOrEmpty(contentType))
                {
                    throw new ArgumentException("Missing content type", nameof(data));
                }
                if (contentType == null || !contentType.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Invalid content type", nameof(data));
                }
                if (!GetBoundary(contentType, prefix, out boundary))
                {
                    throw new ArgumentException("Missing boundary", nameof(data));
                }
            }
            // Read the content into a stream.
            List<MultipartBodyPart> parts = new List<MultipartBodyPart>();
            Stream content = data.ToStream();
            CancellationToken cancellationToken = new CancellationToken();
            bool expectBoundariesWithCRLF = false;
            MultipartReader reader = new MultipartReader(boundary, content) { ExpectBoundariesWithCRLF = expectBoundariesWithCRLF };
            for (MultipartSection section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false);
                section != null;
                section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false))
            {
                if (section.Headers != null && section.Headers.TryGetValue("Content-Type", out string[] contentTypeValues) &&
                        contentTypeValues.Length == 1 &&
                        GetBoundary(contentTypeValues[0], prefix, out string subBoundary))
                {
                    // ExpectBoundariesWithCRLF should always be true for the Body.
                    reader = new MultipartReader(subBoundary, section.Body) { ExpectBoundariesWithCRLF = true };
                    continue;
                }
                Dictionary<string, string> headers = new Dictionary<string, string>();
                if (section.Headers != null)
                {
                    foreach (KeyValuePair<string, string[]> header in section.Headers)
                    {
                        headers.Add(header.Key, string.Join(";", header.Value));
                    }
                }
                parts.Add(new MultipartBodyPart(BinaryData.FromStream(section.Body), headers));
            }
            return parts;
        }

        private protected static IReadOnlyList<MultipartBodyPart> Read(BinaryData data, string subType = "mixed", string boundary = null)
        {
            //return multipartContent;
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return ReadAsync(data, subType, boundary).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void AddInternal(object content, Dictionary<string, string> headers)
        {
            var part = new MultipartBodyPart(content, headers);
            _nestedContent.Add(part);
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
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    scratch.Append(header.Key);
                    scratch.Append(": ");
                    scratch.Append(header.Value);
                    scratch.Append(CrLf);
                }
            }

            // Extra CRLF to end headers (even if there are no headers).
            scratch.Append(CrLf);

            return scratch.ToString();
        }

        private static Task EncodeStringToStreamAsync(Stream stream, string input, CancellationToken cancellationToken)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            return stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }
        private static void EncodeStringToStream(Stream stream, string input)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            stream.Write(buffer, 0, buffer.Length);
        }
        private protected static int GetEncodedLength(string input)
        {
            return Encoding.Default.GetByteCount(input);
        }
        private protected static bool GetBoundary(string contentType, string prefix, out string boundary)
        {
            if (contentType == null || !contentType.StartsWith(prefix, StringComparison.Ordinal))
            {
                boundary = null;
                return false;
            }
            boundary = contentType.Substring(prefix.Length);
            return true;
        }
        /// <summary>
        /// Frees resources held by the <see cref="Multipart"/> object.
        /// </summary>
        public void Dispose() { }
    }
}
