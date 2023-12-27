// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace System.ClientModel
{
    /// <summary>
    /// A Content in multipart format.
    /// </summary>
    public class Multipart : IDisposable
    {
        private const string CrLf = "\r\n";
        private const string ColonSP = ": ";

        private static readonly int s_crlfLength = GetEncodedLength(CrLf);
        private static readonly int s_dashDashLength = GetEncodedLength("--");
        private static readonly int s_colonSpaceLength = GetEncodedLength(ColonSP);
        private readonly List<MultipartContentPart> _nestedContent;
        protected readonly string _subtype;
        protected readonly string _boundary;
        internal readonly Dictionary<string, string> _headers;
        protected const string MultipartContentTypePrefix = "multipart/mixed; boundary=";

        /// <summary> The list of request content parts. </summary>
        public List<MultipartContentPart> ContentParts => _nestedContent;
        public string Boundary => _boundary;
        public string Subtype => _subtype;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        ///  </summary>
        public Multipart()
            : this("mixed", GetDefaultBoundary())
        { }

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
        public Multipart(string subtype, string boundary): this(subtype, boundary, new List<MultipartContentPart>())
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        public Multipart(string subtype, string boundary, IReadOnlyList<MultipartContentPart> nestedContent)
        {
            ValidateBoundary(boundary);
            _subtype = subtype;

            // see https://www.ietf.org/rfc/rfc1521.txt page 29.
            _boundary = boundary.Contains(":") ? $"\"{boundary}\"" : boundary;
            _headers = new Dictionary<string, string>
            {
                ["Content-Type"] = $"multipart/{_subtype}; boundary={_boundary}"
            };

            _nestedContent = nestedContent.ToList<MultipartContentPart>();
        }

        private static string GetDefaultBoundary()
        {
            return Guid.NewGuid().ToString();
        }

        private static void ValidateBoundary(string boundary)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Add HTTP content to a collection of Content objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        public virtual void Add(BinaryData content)
        {
            AddInternal(content, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of binary data objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public virtual void Add(BinaryData content, Dictionary<string, string> headers)
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
        public virtual BinaryData ToContent()
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
                    BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    byte[] buffer = content.ToArray();
                    stream.Write(buffer, 0, buffer.Length);
                    //content.WriteTo(stream, cancellationToken);
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

        /// <summary>
        ///  Read the content from BinaryData and parse it.
        ///  each part of BinaryData separted by boundary will be parsed as one MultipartContentPart.
        /// </summary>
        public static async Task<Multipart> ReadAsync(BinaryData data, string subType = "mixed", string boundary = null)
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
            Multipart multipartContent = new Multipart(subType, boundary);
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
                multipartContent.ContentParts.Add(new MultipartContentPart(BinaryData.FromStream(section.Body), headers));
            }
            return multipartContent;
        }

        public static Multipart Read(BinaryData data, string subType = "mixed", string boundary = null)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return ReadAsync(data, subType, boundary).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void AddInternal(BinaryData content, Dictionary<string, string> headers)
        {
            var part = new MultipartContentPart(content, headers);
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

        private static void EncodeStringToStream(Stream stream, string input)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            stream.Write(buffer, 0, buffer.Length);
        }
        private static int GetEncodedLength(string input)
        {
            return Encoding.Default.GetByteCount(input);
        }
        private static bool GetBoundary(string contentType, string prefix, out string boundary)
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
