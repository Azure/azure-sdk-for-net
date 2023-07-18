// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IModelSerializable
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        object Deserialize(BinaryData data, ModelSerializerOptions options);
    }
}
