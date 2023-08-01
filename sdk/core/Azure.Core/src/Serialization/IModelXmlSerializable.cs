// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml;
using System.Xml.Linq;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Indicates that the implementer can be serialized and deserialized as XML.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the value into.</typeparam>
    public interface IModelXmlSerializable<out T> : IModelSerializable<T>
    {
        /// <summary>
        /// Serializes the model to the provided <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize into.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        void Serialize(XmlWriter writer, ModelSerializerOptions options);

        /// <summary>
        /// Deserializes the XML element contained by the specified <see cref="XElement"/> into a model.
        /// </summary>
        /// <param name="root">The <see cref="XElement"/> that represents the model.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the Xml element.</returns>
        T Deserialize(XElement root, ModelSerializerOptions options);
    }
}
