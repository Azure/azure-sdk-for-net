// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/WebUtilities/src

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Core
{
    internal class MultipartSection
    {
        public Dictionary<string, string[]>? Headers { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public Stream Body { get; set; } = default!;

        /// <summary>
        /// The position where the body starts in the total multipart body.
        /// This may not be available if the total multipart body is not seekable.
        /// </summary>
        public long? BaseStreamOffset { get; set; }
    }
}
