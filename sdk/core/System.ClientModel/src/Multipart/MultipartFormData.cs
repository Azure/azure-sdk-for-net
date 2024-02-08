// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

#nullable disable
namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormData : Multipart, IPersistableModel<MultipartFormData>
    {
        #region Fields

        private const string FormData = "form-data";

        #endregion Fields

        #region Construction
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        public MultipartFormData() : base(FormData)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartFormData(string boundary) : base(FormData, boundary)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        public MultipartFormData(string boundary, IReadOnlyList<MultipartBodyPart> nestedContent) : base(FormData, boundary, nestedContent)
        { }
        #endregion Construction
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(BinaryData content, string name)
        {
            AddInternal(content, null, name, null);
        }
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(BinaryData content, string name, Dictionary<string, string> headers)
        {
            AddInternal(content, headers, name, null);
        }
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(BinaryData content, string name, string fileName, Dictionary<string, string> headers)
        {
            AddInternal(content, headers, name, fileName);
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
        BinaryData IPersistableModel<MultipartFormData>.Write(ModelReaderWriterOptions options)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            return ToBinaryData();
        }
        MultipartFormData IPersistableModel<MultipartFormData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(data));
            }
            string MultipartContentTypePrefix = $"multipart/{_subtype}; boundary=";
            string boundary = null;
            string contentType = data.MediaType;
            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Missing content type", nameof(data));
            }
            if (contentType == null || !contentType.StartsWith(MultipartContentTypePrefix, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid content type", nameof(data));
            }
            if (!GetBoundary(contentType, MultipartContentTypePrefix, out boundary))
            {
                throw new ArgumentException("Missing boundary", nameof(data));
            }
            return new MultipartFormData(boundary, Read(data, FormData, boundary));
        }
        public RequestBody ToRequestBody()
        {
            return RequestBody.CreateFromStream(ToBinaryData().ToStream());//TODO: need to combine all the parts to a stream
        }
        private void AddInternal(BinaryData content, Dictionary<string, string> headers, string name, string fileName)
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
            if (!headers.ContainsKey("Content-Type"))
            {
                var value = content.MediaType;
                if (value != null)
                {
                    headers.Add("Content-Type", value);
                }
            }
            base.Add(content, headers);
        }
        public override bool TryComputeLength(out long length)
        {
            int boundaryLength = GetEncodedLength(_boundary);

            long currentLength = 0;
            long internalBoundaryLength = s_crlfLength + s_dashDashLength + boundaryLength + s_crlfLength;

            // Start Boundary.
            currentLength += s_dashDashLength + boundaryLength + s_crlfLength;

            bool first = true;
            foreach (MultipartBodyPart content in _nestedContent)
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
                currentLength += content.Content.Length;
            }

            // Terminating boundary.
            currentLength += s_crlfLength + s_dashDashLength + boundaryLength + s_dashDashLength + s_crlfLength;

            length = currentLength;
            return true;
        }
        /// <summary>
        /// Creates an instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to use.</param>
        /// <returns>An instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static MultipartFormData Create(BinaryData data)
        {
            return ModelReaderWriter.Read<MultipartFormData>(data, new ModelReaderWriterOptions("MPTD"));
        }
        string IPersistableModel<MultipartFormData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MPFD";
    }
    /*
    /// <summary>
    /// A form data item in multipart/form-data format.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class FormDataItem
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public BinaryData Content { get; set; }
    }
    */
}
