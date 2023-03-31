// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            return new DynamicData(MutableJsonDocument.Parse(data).RootElement, new DynamicDataOptions());
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicDataNameMapping propertyNameCasing)
        {
            return new DynamicData(MutableJsonDocument.Parse(data).RootElement, new DynamicDataOptions() {  PropertyNameCasing = propertyNameCasing });
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamic(this BinaryData data, DynamicDataOptions options)
        {
            return new DynamicData(MutableJsonDocument.Parse(data).RootElement, options);
        }
    }
}
