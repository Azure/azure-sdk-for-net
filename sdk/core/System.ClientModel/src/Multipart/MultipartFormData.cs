// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable disable
namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormData : Multipart, IPersistableModel<MultipartFormData>, IPersistableStreamModel<MultipartFormData>
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
        public void Add(object content, string name)
        {
            AddInternal(content, null, name, null);
        }
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public void Add(object content, string name, Dictionary<string, string> headers)
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
        public void Add(object content, string name, string fileName, Dictionary<string, string> headers)
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
        void IPersistableStreamModel<MultipartFormData>.Write(Stream stream, ModelReaderWriterOptions options)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            WriteToStream(stream);
        }
        Task IPersistableStreamModel<MultipartFormData>.WriteAsync(Stream stream, ModelReaderWriterOptions options, CancellationToken cancellation)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            return WriteToStreamAsync(stream, cancellation);
        }

        MultipartFormData IPersistableStreamModel<MultipartFormData>.Create(Stream stream, ModelReaderWriterOptions options)
        {
            //Not implemented.
            return new MultipartFormData();
        }

        string IPersistableStreamModel<MultipartFormData>.GetMediaType(ModelReaderWriterOptions options)
        {
            return ContentType;
        }

        private void AddInternal(object content, Dictionary<string, string> headers, string name, string fileName)
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
                /*
                var value = content.MediaType;
                if (value != null)
                {
                    headers.Add("Content-Type", value);
                }
                */
                switch (content)
                {
                    case BinaryData binaryData:
                        headers.Add("Content-Type", binaryData.MediaType);
                        break;
                    case byte[] b:
                        headers.Add("Content-Type", "application/octet-stream");
                        break;
                }
            }
            base.Add(content, headers);
        }
        string IPersistableModel<MultipartFormData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MPFD";
    }
}
