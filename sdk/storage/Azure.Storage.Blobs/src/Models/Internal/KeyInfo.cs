// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Xml;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    // CUSTOM:
    // - Maintain optional behavior of Start property when serializing to XML by using a custom serialization hook.
    [CodeGenSerialization(nameof(Start), SerializationValueHook = nameof(SerializeStart))]
    internal partial class KeyInfo
    {
        private void SerializeStart(XmlWriter writer, ModelReaderWriterOptions options)
        {
            if (Optional.IsDefined(Start))
            {
                writer.WriteStartElement("Start");
                writer.WriteValue(Start);
                writer.WriteEndElement();
            }
        }
    }
}
