#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI.Tests.Utils
{
    /// <summary>
    /// Adapter to allow mixing reflection based JSON serialization and deserialization with the ModelReaderWriter based ones
    /// </summary>
    public class ModelReaderWriterConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            bool implementsInterface = typeof(IJsonModel<object>).IsAssignableFrom(typeToConvert);
            bool hasParameterlessConstructor = typeToConvert.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Any(ci => ci.GetParameters()?.Count() == 0);
            return implementsInterface && hasParameterlessConstructor;
        }

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return (JsonConverter)Activator.CreateInstance(typeof(InnerModelReaderWriterConverter<>).MakeGenericType([typeToConvert]))!;
        }

        private class InnerModelReaderWriterConverter<T> : JsonConverter<T> where T : IJsonModel<T>
        {
            private IJsonModel<T> _converter;

            /// <summary>
            /// Creates a new instance
            /// </summary>
            /// <exception cref="ArgumentNullException">The type does not have any paramterless constructor</exception>
            public InnerModelReaderWriterConverter()
            {
                _converter = (IJsonModel<T>)(Activator.CreateInstance(typeof(T), true)
                    ?? throw new ArgumentNullException());
            }

            /// <inheritdoc />
            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return _converter.Create(ref reader, ModelReaderWriterOptions.Json);
            }

            /// <inheritdoc />
            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                _converter.Write(writer, ModelReaderWriterOptions.Json);
            }
        }
    }
}
