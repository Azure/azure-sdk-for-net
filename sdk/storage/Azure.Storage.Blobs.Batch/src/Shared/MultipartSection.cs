// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/WebUtilities/src

using System.Collections.Generic;
using System.IO;

#pragma warning disable IDE0018 // Inline declaration

namespace Azure.Core.Http.Multipart
{
    internal class MultipartSection
    {
        public string ContentType
        {
            get
            {
                StringValues values;
                if (Headers.TryGetValue(HeaderNames.ContentType, out values))
                {
                    return values;
                }
                return null;
            }
        }

        public string ContentDisposition
        {
            get
            {
                StringValues values;
                if (Headers.TryGetValue(HeaderNames.ContentDisposition, out values))
                {
                    return values;
                }
                return null;
            }
        }

        public Dictionary<string, StringValues> Headers { get; set; }

        public Stream Body { get; set; }

        /// <summary>
        /// The position where the body starts in the total multipart body.
        /// This may not be available if the total multipart body is not seekable.
        /// </summary>
        public long? BaseStreamOffset { get; set; }
    }
}
