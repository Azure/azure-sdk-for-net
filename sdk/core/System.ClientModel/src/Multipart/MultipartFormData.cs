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
        public override void Add(MultipartBodyPart part) => AddInternal(part, null, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(MultipartBodyPart part, string name) => AddInternal(part, name, null);

        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        public void Add(MultipartBodyPart part, string name, string fileName)
        {
            AddInternal(part, name, fileName);
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
            string contentType = data.MediaType;
            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Missing content type", nameof(data));
            }
            if (contentType == null || !contentType.StartsWith(MultipartContentTypePrefix, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid content type", nameof(data));
            }
            if (!GetBoundary(contentType, out _, out string boundary))
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

        MultipartFormData IPersistableStreamModel<MultipartFormData>.Create(Stream stream, string contentType, ModelReaderWriterOptions options)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            if (!GetBoundary(contentType, out string subType, out string boundary))
            {
                throw new ArgumentException("Invalid content type", nameof(contentType));
            }
            return new MultipartFormData(boundary, Read(stream, subType, boundary));
        }

        string IPersistableStreamModel<MultipartFormData>.GetMediaType(ModelReaderWriterOptions options)
        {
            return ContentType;
        }
        private void AddInternal(MultipartBodyPart part, string name, string fileName)
        {
            if (!part.Headers.ContainsKey("Content-Disposition"))
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

                part.Headers.Add("Content-Disposition", value);
            }
            if (!part.Headers.ContainsKey("Content-Type"))
            {
                var value = part.ContentType;
                if (value != null)
                {
                    part.Headers.Add("Content-Type", value);
                }
            }
            base.Add(part);
        }
        string IPersistableModel<MultipartFormData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MPFD";
    }
}
