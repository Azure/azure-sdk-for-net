// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// .
    /// </summary>
    public interface IXmlModelSerializable<out T> : IModelSerializable<T>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
        void Serialize(XmlWriter writer, ModelSerializerOptions options);
    }

    /// <summary>
    /// .
    /// </summary>
    public interface IXmlModelSerializable : IXmlModelSerializable<object> { }
}
