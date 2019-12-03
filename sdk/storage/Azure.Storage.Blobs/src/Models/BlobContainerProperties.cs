﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    public partial class BlobContainerProperties
    {
        /// <summary>
        /// Update the Metadata property based on the value stored
        /// in the parent XML node
        /// </summary>
        /// <param name="element">XML element</param>
        /// <param name="value">value for element</param>
        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobContainerProperties value)
        {
            System.Xml.Linq.XElement parent = element.Parent;
            value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            System.Xml.Linq.XElement child = parent.Element(System.Xml.Linq.XName.Get("Metadata", ""));
            if (child != null)
            {
                foreach (System.Xml.Linq.XElement _pair in child.Elements())
                {
                    value.Metadata[_pair.Name.LocalName] = _pair.Value;
                }
            }
        }
    }
}
