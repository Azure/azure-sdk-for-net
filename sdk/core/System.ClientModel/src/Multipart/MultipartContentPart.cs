// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A content part of multipart content.
    /// </summary>
    public class MultipartContentPart
    {
        /// <summary> The request content of this part. </summary>
        public readonly BinaryData Content;
        /// <summary> The headers of this content part. </summary>
        public Dictionary<string, string> Headers;

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartContentPart"/> class.
        ///  </summary>
        ///  <param name="content">The request content.</param>
        /// <param name="headers">The headers of this content part.</param>
        public MultipartContentPart(BinaryData content, Dictionary<string, string> headers)
        {
            Content = content;
            Headers = headers;
        }
    }
}
