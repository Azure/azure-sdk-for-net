// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translator.Document
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
        public MultipartFormFileData(string name, BinaryData content, string contentType)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(contentType, nameof(contentType));
            Name = name;
            Content = content;
            ContentType = contentType;
        }

        /// <summary>
        /// File name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// File content.
        /// </summary>
        public BinaryData Content { get; private set; }
        /// <summary>
        /// File content type.
        /// </summary>
        public string ContentType { get; private set; }
    }
}
