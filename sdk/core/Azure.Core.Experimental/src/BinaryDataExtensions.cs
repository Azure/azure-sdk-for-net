// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Extensions to BinaryData.
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data)
        {
            return JsonData.Parse(data);
        }
    }
}
