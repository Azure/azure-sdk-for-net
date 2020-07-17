// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// A <see cref="JsonObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class JsonObjectSerializer : ObjectSerializer, ISerializedNameProvider
    {
        private readonly Dictionary<Type, MemberInfo[]> _cache;
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes new instance of <see cref="JsonObjectSerializer"/>.
        /// </summary>
        public JsonObjectSerializer() : this(new JsonSerializerOptions())
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> instance to use when serializing/deserializing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public JsonObjectSerializer(JsonSerializerOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));

            // TODO: Consider using WeakReference cache to allow the GC to collect if the JsonObjectSerialized is held for a long duration.
            _cache = new Dictionary<Type, MemberInfo[]>();
        }

        /// <inheritdoc />
        public override void Serialize(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            var buffer = JsonSerializer.SerializeToUtf8Bytes(value, inputType, _options);
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            await JsonSerializer.SerializeAsync(stream, value, inputType, _options, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return JsonSerializer.Deserialize(memoryStream.ToArray(), returnType, _options);
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync(stream, returnType, _options, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        string? ISerializedNameProvider.GetSerializedName(MemberInfo memberInfo)
        {
            Argument.AssertNotNull(memberInfo, nameof(memberInfo));

            if (!_cache.TryGetValue(memberInfo.ReflectedType, out MemberInfo[] members))
            {
                members = GetMembers(memberInfo.ReflectedType).ToArray();
            }

            foreach (MemberInfo member in members)
            {
                if (member == memberInfo)
                {
                    return GetPropertyName(memberInfo);
                }
            }

            return null;
        }

        private static IEnumerable<MemberInfo> GetMembers(Type type)
        {
            // Mimics property enumeration based on:
            // * https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L130-L191
            // * TODO: https://github.com/dotnet/runtime/blob/dc8b6f90/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L147-L155

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo propertyInfo in properties)
            {
                // Ignore indexers.
                if (propertyInfo.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                // Only support public getters and/or setters.
                if (propertyInfo.GetMethod?.IsPublic == true ||
                    propertyInfo.SetMethod?.IsPublic == true)
                {
                    if (propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                    {
                        continue;
                    }

                    // Ignore - but do not assert correctness - for JsonExtensionDataAttribute based on
                    // https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L244-L261
                    if (propertyInfo.GetCustomAttribute<JsonExtensionDataAttribute>() != null)
                    {
                        continue;
                    }

                    // No need to validate collisions since they are based on the serialized name.
                    yield return propertyInfo;
                }
            }
        }

        private string GetPropertyName(MemberInfo memberInfo)
        {
            // Mimics property name determination based on
            // https://github.com/dotnet/runtime/blob/dc8b6f90/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonPropertyInfo.cs#L53-L90

            JsonPropertyNameAttribute nameAttribute = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>(false);
            if (nameAttribute != null)
            {
                return nameAttribute.Name
                    ?? throw new InvalidOperationException($"The JSON property name for '{memberInfo.DeclaringType}.{memberInfo.Name}' cannot be null.");
            }
            else if (_options.PropertyNamingPolicy != null)
            {
                return _options.PropertyNamingPolicy.ConvertName(memberInfo.Name)
                    ?? throw new InvalidOperationException($"The JSON property name for '{memberInfo.DeclaringType}.{memberInfo.Name}' cannot be null.");
            }
            else
            {
                return memberInfo.Name;
            }
        }
    }
}
