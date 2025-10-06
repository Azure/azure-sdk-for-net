// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A <see cref="NewtonsoftJsonObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class NewtonsoftJsonObjectSerializer : ObjectSerializer, IMemberNameConverter
    {
        private const int DefaultBufferSize = 1024;

        // Older StreamReader and StreamWriter would otherwise default to this.
        private static readonly Encoding UTF8NoBOM = new UTF8Encoding(false, true);

        private readonly ConcurrentDictionary<MemberInfo, string?> _cache;
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Initializes new instance of <see cref="NewtonsoftJsonObjectSerializer"/>. Uses setting returned by <see cref="CreateJsonSerializerSettings"/>.
        /// </summary>
        public NewtonsoftJsonObjectSerializer() : this(CreateJsonSerializerSettings())
        {
        }

        /// <summary>
        /// Returns a <see cref="JsonSerializerSettings"/> that's used when initializing the <see cref="NewtonsoftJsonObjectSerializer"/> using the parameterless constructor.
        /// The settings have default converters added.
        /// </summary>
        public static JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();

            // NOTE: Update the README when converters are added by default.
            settings.Converters.Add(new NewtonsoftJsonETagConverter());

            return settings;
        }

        /// <summary>
        /// Initializes new instance of <see cref="NewtonsoftJsonObjectSerializer"/>.
        /// </summary>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/> instance to use when serializing/deserializing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="settings"/> is null.</exception>
        public NewtonsoftJsonObjectSerializer(JsonSerializerSettings settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            _cache = new ConcurrentDictionary<MemberInfo, string?>();
            _serializer = JsonSerializer.Create(settings);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="returnType"/> is null.</exception>
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(returnType, nameof(returnType));

            using StreamReader reader = new StreamReader(stream, UTF8NoBOM, true, DefaultBufferSize, true);
            return _serializer.Deserialize(reader, returnType)!;
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="returnType"/> is null.</exception>
        public override ValueTask<object?> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken) =>
            new ValueTask<object?>(Deserialize(stream, returnType, cancellationToken));

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="inputType"/> is null.</exception>
        public override void Serialize(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(inputType, nameof(inputType));

            using StreamWriter writer = new StreamWriter(stream, UTF8NoBOM, DefaultBufferSize, true);
            _serializer.Serialize(writer, value, inputType);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="inputType"/> is null.</exception>
        public override ValueTask SerializeAsync(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            Serialize(stream, value, inputType, cancellationToken);
            return new ValueTask();
        }

        /// <inheritdoc/>
        string? IMemberNameConverter.ConvertMemberName(MemberInfo member)
        {
            Argument.AssertNotNull(member, nameof(member));

            return _cache.GetOrAdd(member, m =>
            {
                if (_serializer.ContractResolver.ResolveContract(m.ReflectedType!) is JsonObjectContract contract)
                {
                    foreach (JsonProperty property in contract.Properties)
                    {
                        if (!property.Ignored &&
                            string.Equals(property.UnderlyingName, m.Name, StringComparison.Ordinal) &&
                            property.DeclaringType == m.DeclaringType)
                        {
                            return property.PropertyName;
                        }
                    }
                }

                return null;
            });
        }
    }
}
