// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Represent a multipart form file data.
    /// </summary>
    public class MultipartFormFileData
    {
        /// <summary>
        /// Construct a form file data.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <param name="content">Content of the file.</param>
        /// <param name="contentType">Content type of the file.</param>
        public MultipartFormFileData(string name, Stream content, string contentType) : this(name, content, contentType, null)
        { }

        /// <summary>
        /// Construct a form file data.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <param name="content">Content of the file.</param>
        /// <param name="contentType">Content type of the file.</param>
        /// <param name="headers">Optional headers appended to the file.</param>
        public MultipartFormFileData(string name, Stream content, string contentType, IDictionary<string, string> headers)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));
            Name = name;
            Content = content;
            ContentType = contentType ?? "application/octect-stream";
            Headers = (headers == null ? new Dictionary<string, string>() : new Dictionary<string, string>(headers));
        }

        /// <summary>
        /// File name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// File content.
        /// </summary>
        public Stream Content { get; }

        /// <summary>
        /// File content type.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Optional headers appended to this file.
        /// </summary>
        public IDictionary<string, string> Headers { get; }
    }
}
