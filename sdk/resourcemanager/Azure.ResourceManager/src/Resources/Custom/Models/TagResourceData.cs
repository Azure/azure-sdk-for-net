// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Buffers;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the TagResource data model.
    /// Wrapper resource for tags API requests and responses.
    /// </summary>
    public partial class TagResourceData : ISerializable
    {
        /// <summary>
        /// public constructor
        /// </summary>
        public TagResourceData() {}

        bool ISerializable.TryDeserialize(ReadOnlySpan<byte> data, out int bytesConsumed, StandardFormat format)
            => throw new NotImplementedException();

        bool ISerializable.TrySerialize(Span<byte> buffer, out int bytesWritten, StandardFormat format)
            => throw new NotImplementedException();
    }
}