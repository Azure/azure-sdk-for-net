// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace Azure.Storage.Files.Models
{
    public partial struct FileRange
    {
        /// <summary>
        /// Deserializes XML into a new Range instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Range instance.</returns>
        internal static FileRange FromXml(XElement element)
        {
            Debug.Assert(element != null);
            XElement child;
            long start = default;
            long end = default;
            child = element.Element(XName.Get("Start", ""));
            if (child != null)
            {
                start = long.Parse(child.Value, CultureInfo.InvariantCulture);
            }
            child = element.Element(XName.Get("End", ""));
            if (child != null)
            {
                end = long.Parse(child.Value, CultureInfo.InvariantCulture);
            }
            return new FileRange(start, end);
        }
    }
}
