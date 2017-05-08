// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Microsoft.Rest.Azure
{
    public static class JsonSerializerExtensions
    {
        /// <summary>
        /// Gets a JsonSerializer without specified converter.
        /// </summary>
        /// <param name="serializer">JsonSerializer</param>
        /// <param name="converterToExclude">Converter to exclude from serializer.</param>
        /// <returns></returns>
        public static JsonSerializer WithoutConverter(this JsonSerializer serializer, 
            JsonConverter converterToExclude)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            JsonSerializer newSerializer = new JsonSerializer();
            var properties = typeof(JsonSerializer).GetTypeInfo().DeclaredProperties;
            foreach (var property in properties.Where(p => p.SetMethod != null && !p.SetMethod.IsPrivate))
            {
                property.SetValue(newSerializer, property.GetValue(serializer, null), null);
            }
            foreach (var converter in serializer.Converters)
            {
                if (converter != converterToExclude)
                {
                    newSerializer.Converters.Add(converter);
                }
            }
            return newSerializer;
        }
    }
}
