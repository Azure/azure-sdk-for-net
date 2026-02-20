// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Xml;

namespace Azure.Core
{
    internal interface IXmlSerializable
    {
        void WriteXml(XmlWriter writer, string? nameHint);
    }
}
