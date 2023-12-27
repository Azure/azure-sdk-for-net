// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;

#nullable disable
namespace System.ClientModel
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormData : Multipart
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
        public MultipartFormData(string boundary, IReadOnlyList<MultipartContentPart> nestedContent) : base(FormData, boundary, nestedContent)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        /// <param name="data">The content in multipart/form-data format.</param>
        public MultipartFormData(BinaryData data)
        {
            Read(data);
        }
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
        public RequestBody ToRequestBody()
        {
            return RequestBody.CreateFromStream(ToContent().ToStream());//TODO: need to combine all the parts to a stream
        }
        public IReadOnlyList<FormDataItem> ParseToFormData()
        {
            List<FormDataItem> results = new List<FormDataItem>();
            foreach (var part in this.ContentParts)
            {
                var contentDisposition = part.Headers["Content-Disposition"];
                var name = contentDisposition.Substring(contentDisposition.IndexOf("name=") + 5);
                name = name.Substring(0, name.IndexOf(";"));
                var fileName = contentDisposition.IndexOf("filename=") > 0 ? contentDisposition.Substring(contentDisposition.IndexOf("filename=") + 9) : null;
                if (fileName != null)
                {
                    fileName = fileName.Substring(0, fileName.IndexOf(";"));
                }
                var contentType = part.Headers.ContainsKey("Content-Type") ? part.Headers["Content-Type"] : null;
                var content = part.Content;
                var item = new FormDataItem
                {
                    Name = name,
                    FileName = fileName,
                    ContentType = contentType,
                    Content = content
                };
                results.Add(item);
            }
            return results;
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
        /// <summary>
        /// Creates an instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to use.</param>
        /// <param name="boundary">The boundary of the multipart content.</param>
        /// <returns>An instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static MultipartFormData Create(BinaryData data, string boundary = null)
        {
            Multipart multipartContent = Read(data, FormData, boundary);
            return new MultipartFormData(multipartContent.Boundary, multipartContent.ContentParts);
        }
    }
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
}
