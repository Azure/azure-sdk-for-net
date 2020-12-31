// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    public class RecordEntryMessage
    {
        public SortedDictionary<string, string[]> Headers { get; set; } = new SortedDictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

        public byte[] Body { get; set; }

        public bool TryGetContentType(out string contentType)
        {
            contentType = null;
            if (Headers.TryGetValue("Content-Type", out var contentTypes) &&
                contentTypes.Length == 1)
            {
                contentType = contentTypes[0];
                return true;
            }
            return false;
        }

        public bool IsTextContentType(out Encoding encoding)
        {
            encoding = null;
            return TryGetContentType(out string contentType) &&
                   ContentTypeUtilities.TryGetTextEncoding(contentType, out encoding);
        }

        public bool TryGetBodyAsText(out string text)
        {
            text = null;

            if (IsTextContentType(out Encoding encoding))
            {
                text = encoding.GetString(Body);

                return true;
            }

            return false;
        }
    }
}
