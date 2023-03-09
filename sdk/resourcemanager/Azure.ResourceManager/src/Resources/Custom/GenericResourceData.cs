// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Buffers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    // this piece of customization code is used for fixing the base class here
    public partial class GenericResourceData : TrackedResourceExtendedData
    {
    }

    public partial class GenericResourceData : ISerializable
    {
        /// <summary>
        /// xxx
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bytesConsumed"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TryDeserialize(ReadOnlySpan<byte> data, out int bytesConsumed, StandardFormat format = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// xxx
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bytesWritten"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TrySerialize(Span<byte> buffer, out int bytesWritten, StandardFormat format = default)
        {
            throw new NotImplementedException();
        }
    }
}
