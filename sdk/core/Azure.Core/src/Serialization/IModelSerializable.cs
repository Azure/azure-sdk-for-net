// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IModelSerializable<out T>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        T Deserialize(BinaryData data, ModelSerializerOptions options);

        /// <summary>
        /// .
        /// </summary>
        BinaryData Serialize(ModelSerializerOptions options);
    }

    /// <summary>
    /// .
    /// </summary>
    public interface IModelSerializable : IModelSerializable<object> { }
}
