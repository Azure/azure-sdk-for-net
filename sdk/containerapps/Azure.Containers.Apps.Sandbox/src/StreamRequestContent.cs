// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    internal static class StreamRequestContent
    {
        internal static RequestContent Create(Stream content)
        {
            Argument.AssertNotNull(content, nameof(content));
            if (!content.CanRead || !content.CanSeek)
            {
                throw new ArgumentException("The stream must be readable and seekable.", nameof(content));
            }

            return RequestContent.Create(new NonDisposingStream(content));
        }
    }
}
