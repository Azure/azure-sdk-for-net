// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core
{
    internal class JsonSerializableTypeInfo : SerializableTypeInfo
    {
        private readonly JsonSerializerOptions _options;

        public JsonSerializableTypeInfo(Type type, JsonSerializerOptions options)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            _options = options ?? new JsonSerializerOptions();

            if (!IsPrimitive && !IsCollection)
            {
                Properties = GetProperties(type);
            }
            else
            {
                Properties = Array.Empty<SerializablePropertyInfo>();
            }
        }

        public override Type Type { get; }

        public override IReadOnlyCollection<SerializablePropertyInfo> Properties { get; }

        private IReadOnlyCollection<JsonSerializablePropertyInfo> GetProperties(Type type)
        {
            // Mimics property and field discovery based on
            // https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L130-L191

            Dictionary<string, JsonSerializablePropertyInfo> cache = new Dictionary<string, JsonSerializablePropertyInfo>(
                _options.PropertyNameCaseInsensitive
                    ? StringComparer.OrdinalIgnoreCase
                    : StringComparer.Ordinal);

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo propertyInfo in properties)
            {
                // Ignore indexers
                if (propertyInfo.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                // Only support public getters and/or setters.
                if (propertyInfo.GetMethod?.IsPublic == true ||
                    propertyInfo.SetMethod?.IsPublic == true)
                {
                    JsonSerializablePropertyInfo property = new JsonSerializablePropertyInfo(propertyInfo, _options);

                    if (cache.ContainsKey(property.SerializedName))
                    {
                        JsonSerializablePropertyInfo other = cache[property.SerializedName];

                        if (!other.ShouldDeserialize && !other.ShouldSerialize)
                        {
                            // Overwrite the other one since it has [JsonIgnore].
                            cache[property.SerializedName] = property;
                        }
                        else if (property.ShouldDeserialize || property.ShouldSerialize)
                        {
                            throw new InvalidOperationException($"Cannot serialize more than one property as \"{property.SerializedName}\"");
                        }
                    }
                    else
                    {
                        cache.Add(property.SerializedName, property);
                    }
                }
            }

            JsonSerializablePropertyInfo[] array = new JsonSerializablePropertyInfo[cache.Count];
            cache.Values.CopyTo(array, 0);

            return array;
        }
    }
}
