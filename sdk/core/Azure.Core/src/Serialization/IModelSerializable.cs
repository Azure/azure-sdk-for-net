﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Indicates that the impleenter can be serialized and deserialized.
    /// The format of the serialization is determined by the implementer.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the value into.</typeparam>
    public interface IModelSerializable<out T>
    {
        /// <summary>
        /// Serializes the model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A binary representation of the serialized model.</returns>
        /// <exception cref="InvalidOperationException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        BinaryData Serialize(ModelSerializerOptions options);

        /// <summary>
        /// Converts the provided <see cref="BinaryData"/> into a model.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to parse.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the data.</returns>
        /// <exception cref="InvalidOperationException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        T Deserialize(BinaryData data, ModelSerializerOptions options);
    }
}
