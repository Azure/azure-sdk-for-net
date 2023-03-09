// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Extensions to BinaryData.
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data)
        {
            MutableJsonDocument doc = MutableJsonDocument.Parse(data);
            ObjectElement element = new ObjectElement(doc, doc.RootElement);
            return new DynamicData(element, new DynamicDataOptions());
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicDataNameMapping propertyNameCasing)
        {
            MutableJsonDocument doc = MutableJsonDocument.Parse(data);
            ObjectElement element = new ObjectElement(doc, doc.RootElement);
            return new DynamicData(element, new DynamicDataOptions() {  PropertyNameCasing = propertyNameCasing });
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicDataOptions options)
        {
            MutableJsonDocument doc = MutableJsonDocument.Parse(data);
            ObjectElement element = new ObjectElement(doc, doc.RootElement);
            return new DynamicData(element, options);
        }
    }
}
