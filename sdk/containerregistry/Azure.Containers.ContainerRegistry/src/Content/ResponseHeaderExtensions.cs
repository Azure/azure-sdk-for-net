// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    internal static class ResponseHeaderExtensions
    {
        public static long? ContentLengthLong(this ResponseHeaders headers)
        {
            if (headers.TryGetValue(HttpHeader.Names.ContentLength, out string stringValue))
            {
                return long.Parse(stringValue, CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}
