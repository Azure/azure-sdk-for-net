// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// A <see cref="NewtonsoftJsonObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class NewtonsoftJsonObjectSerializer : ObjectSerializer
    {
        private const int DefaultBufferSize = 1024;

        // Older StreamReader and StreamWriter would otherwise default to this.
        private static readonly Encoding UTF8NoBOM = new UTF8Encoding(false, true);

        private readonly JsonSerializer _serializer;
        private readonly NamingStrategy? _namingStrategy;

        /// <summary>
        /// Initializes new instance of <see cref="NewtonsoftJsonObjectSerializer"/> using <see cref="JsonConvert.DefaultSettings"/>.
        /// </summary>
        public NewtonsoftJsonObjectSerializer() : this(true)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="NewtonsoftJsonObjectSerializer"/>.
        /// </summary>
        /// <param name="useDefaultSettings">Whether to use <see cref="JsonConvert.DefaultSettings"/> in combination with given <paramref name="settings"/>.</param>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/> instance to use when serializing/deserializing.</param>
        /// <param name="namingStrategy">
        /// Optional <see cref="NamingStrategy"/> to use for property names.
        /// If null and the created <see cref="JsonSerializer.ContractResolver"/> is a <see cref="DefaultContractResolver"/>,
        /// the <see cref="DefaultContractResolver.NamingStrategy"/> will be used.
        /// </param>
        public NewtonsoftJsonObjectSerializer(bool useDefaultSettings, JsonSerializerSettings? settings = null, NamingStrategy? namingStrategy = null)
        {
            _serializer = useDefaultSettings ?
                JsonSerializer.CreateDefault(settings) :
                JsonSerializer.Create(settings);

            _namingStrategy = namingStrategy ??
                (_serializer.ContractResolver is DefaultContractResolver resolver ? resolver.NamingStrategy : null);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        public override SerializableTypeInfo GetTypeInfo(Type type)
        {
            Argument.AssertNotNull(type, nameof(type));

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="returnType"/> is null.</exception>
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(returnType, nameof(returnType));

            using StreamReader reader = new StreamReader(stream, UTF8NoBOM, true, DefaultBufferSize, true);
            return _serializer.Deserialize(reader, returnType);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="returnType"/> is null.</exception>
        public override ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken) =>
            new ValueTask<object>(Deserialize(stream, returnType, cancellationToken));

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
    }
}
