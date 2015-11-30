// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Serializers
{
    using System.Linq.Expressions;

    /// <summary>
    ///     Main interface that allows building a serializer/de-serializer using expressions.
    /// </summary>
    internal interface IFieldSerializer
    {
        #region +++Generated serializer+++
        /// <summary>
        /// Builds the serializer.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="object">The object.</param>
        /// <returns>
        /// Expression that serializes the value into the given encoder.
        /// </returns>
        Expression BuildSerializer(Expression encoder, Expression @object);

        /// <summary>
        /// Builds the de-serializer.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <param name="object">The object.</param>
        /// <returns>
        /// Expression that de-serializes the value using the given decoder.
        /// </returns>
        Expression BuildDeserializer(Expression decoder, Expression @object);

        /// <summary>
        /// Builds a skipper for the corresponding type.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>Expression that skips the value using the given decoder.</returns>
        Expression BuildSkipper(Expression decoder);
        #endregion

        #region +++Runtime serializer+++
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="object">The object.</param>
        void Serialize(IEncoder encoder, object @object);

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <param name="object">The object.</param>
        void Deserialize(IDecoder decoder, object @object);

        /// <summary>
        /// Skips the object using the encoder.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        void Skip(IDecoder decoder);
        #endregion
    }
}
