// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A <see cref="JsonObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class JsonObjectSerializer : ObjectSerializer, IMemberNameConverter
    {
        private readonly ConcurrentDictionary<MemberInfo, string?> _cache;
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
            _cache = new ConcurrentDictionary<MemberInfo, string?>();
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
        public override object? Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return JsonSerializer.Deserialize(memoryStream.ToArray(), returnType, _options);
        }

        /// <inheritdoc />
        public override async ValueTask<object?> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync(stream, returnType, _options, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        string? IMemberNameConverter.ConvertMemberName(MemberInfo member)
        {
            Argument.AssertNotNull(member, nameof(member));

            return _cache.GetOrAdd(member, m =>
            {
                // Mimics property enumeration based on:
                // * https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L130-L191
                // * TODO: Add support for fields when .NET 5 GAs (https://github.com/Azure/azure-sdk-for-net/issues/13627)

                if (m is PropertyInfo propertyInfo)
                {
                    // Ignore indexers.
                    if (propertyInfo.GetIndexParameters().Length > 0)
                    {
                        return null;
                    }

                    // Only support public getters and/or setters.
                    if (propertyInfo.GetMethod?.IsPublic == true ||
                        propertyInfo.SetMethod?.IsPublic == true)
                    {
                        if (propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                        {
                            return null;
                        }

                        // Ignore - but do not assert correctness - for JsonExtensionDataAttribute based on
                        // https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L244-L261
                        if (propertyInfo.GetCustomAttribute<JsonExtensionDataAttribute>() != null)
                        {
                            return null;
                        }

                        // No need to validate collisions since they are based on the serialized name.
                        return GetPropertyName(propertyInfo);
                    }
                }

                // The member is unsupported or ignored.
                return null;
            });
        }

        private string GetPropertyName(MemberInfo memberInfo)
        {
            // Mimics property name determination based on
            // https://github.com/dotnet/runtime/blob/dc8b6f90/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonPropertyInfo.cs#L53-L90

            JsonPropertyNameAttribute? nameAttribute = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>(false);
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
