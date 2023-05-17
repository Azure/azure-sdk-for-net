// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IJsonSerializable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytesWritten"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool TrySerialize(Stream stream, out long bytesWritten, SerializableOptions? options = default);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="bytesConsumed"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool TryDeserialize(Stream stream, out long bytesConsumed, SerializableOptions? options = default);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        void Serialize(Stream stream, SerializableOptions? options = default);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        void Deserialize(Stream stream, SerializableOptions? options = default);
    }
}
