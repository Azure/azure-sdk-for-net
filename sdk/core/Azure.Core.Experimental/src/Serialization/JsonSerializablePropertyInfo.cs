// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core
{
    internal class JsonSerializablePropertyInfo : SerializablePropertyInfo
    {
        private readonly PropertyInfo _propertyInfo;

        public JsonSerializablePropertyInfo(PropertyInfo propertyInfo, JsonSerializerOptions options)
        {
            _propertyInfo = propertyInfo;

            SerializedName = GetPropertyName(options);
            ShouldIgnore = _propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() != null;

            ShouldSerialize = propertyInfo.GetMethod?.IsPublic == true;
            ShouldDeserialize = propertyInfo.GetMethod?.IsPublic == true;
        }

        public override Type PropertyType => _propertyInfo.PropertyType;

        public override string PropertyName => _propertyInfo.Name;

        public override string SerializedName { get; }

        public override bool ShouldIgnore { get; }

        public override IReadOnlyCollection<object> GetAttributes(bool inherit) =>
            _propertyInfo.GetCustomAttributes(inherit);

        internal bool ShouldSerialize { get; }

        internal bool ShouldDeserialize { get; }

        private string GetPropertyName(JsonSerializerOptions options)
        {
            // Mimics getting the property name based on
            // https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonPropertyInfo.cs#L90-L133

            string ThrowMissingName() => throw new InvalidOperationException($"Missing serialized property name on {_propertyInfo.DeclaringType}.{_propertyInfo.Name}");

            JsonPropertyNameAttribute nameAttribute = _propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (nameAttribute != null)
            {
                return nameAttribute.Name ?? ThrowMissingName();
            }
            else if (options.PropertyNamingPolicy != null)
            {
                return options.PropertyNamingPolicy.ConvertName(_propertyInfo.Name) ?? ThrowMissingName();
            }
            else
            {
                return _propertyInfo.Name;
            }
        }
    }
}
