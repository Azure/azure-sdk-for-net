// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IXmlSerializableModel
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
        void Serialize(XmlWriter writer, ModelSerializerOptions options);
    }
}
