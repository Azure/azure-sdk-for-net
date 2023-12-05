// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System.ClientModel
{
    /// <summary>
    /// Provides functionality to read and write <see cref="IPersistableModel{T}"/> and <see cref="IJsonModel{T}"/>.
    /// </summary>
    public static class ModelReaderWriter
    {
        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write<T>(T model, ModelReaderWriterOptions? options = default)
            where T : IPersistableModel<T>
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            options ??= ModelReaderWriterOptions.Json;

            if (ShouldUseJsonInterface(model, options))
            {
                using (ModelWriter<T> writer = new ModelWriter<T>(GetJsonInterface(model, options), options))
                {
                    return writer.ToBinaryData();
                }
            }
            else
            {
                return model.Write(options);
            }
        }

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write(object model, ModelReaderWriterOptions? options = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            options ??= ModelReaderWriterOptions.Json;

            if (model is not IPersistableModel<object> iModel)
            {
                if (model is not IEnumerable enumerable)
                {
                    throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IPersistableModel<object>)} or {nameof(IEnumerable<IPersistableModel<object>>)}");
                }

                return WriteEnumerable(options, enumerable);
            }
            else
            {
                if (ShouldUseJsonInterface(iModel, options))
                {
                    using (ModelWriter<object> writer = new ModelWriter<object>(GetJsonInterface(iModel, options), options))
                    {
                        return writer.ToBinaryData();
                    }
                }
                else
                {
                    return iModel.Write(options);
                }
            }
        }

        private static BinaryData WriteEnumerable(ModelReaderWriterOptions options, IEnumerable enumerable)
        {
            bool checkedElementFormat = false;
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var item in enumerable)
            {
                if (!checkedElementFormat)
                {
                    if (item is not IPersistableModel<object> itemAsModel)
                    {
                        throw new InvalidOperationException($"{item.GetType().Name} does not implement {nameof(IPersistableModel<object>)} or {nameof(IEnumerable<IPersistableModel<object>>)}");
                    }
                    if (!ShouldUseJsonInterface(itemAsModel, options))
                    {
                        throw new InvalidOperationException($"Writing a collection is only supported for 'J' format");
                    }
                    checkedElementFormat = true;
                }
                BinaryData itemData = Write(item, options);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(itemData);
#else
                    using var doc = JsonDocument.Parse(itemData);
                    JsonSerializer.Serialize(writer, doc.RootElement);
#endif
            }
            writer.WriteEndArray();
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private static void ReadList(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type elementType, IList iList, ModelReaderWriterOptions options)
        {
            var converter = GetInstance(elementType);

            if (ShouldUseJsonInterface(converter, options))
            {
                ReadJsonList(data, GetJsonInterface(converter, options), iList, options);
            }
            else
            {
                throw new InvalidOperationException($"Reading a collection is only supported for 'J' format");
            }
        }

        private static void ReadJsonList<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, IJsonModel<T> converter, IList iList, ModelReaderWriterOptions options)
        {
            Utf8JsonReader reader = new Utf8JsonReader(data);
            reader.Read();
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new FormatException("Expected start of array.");
            }
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                iList.Add(converter.Create(ref reader, options));
            }
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
        /// <exception cref="MissingMethodException">If <typeparamref name="T"/> does not have a public or non public empty constructor.</exception>
        public static T? Read<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelReaderWriterOptions? options = default)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            options ??= ModelReaderWriterOptions.Json;

            Type typeOfT = typeof(T);

            if (typeOfT.IsGenericType && typeOfT.GetGenericTypeDefinition().Equals(typeof(List<>)))
            {
                var list = Activator.CreateInstance(typeOfT);
                ReadList(data, typeOfT.GenericTypeArguments[0], (list as IList)!, options);
                return (T)list!;
            }
            else
            {
                var converter = GetInstance(typeOfT) as IPersistableModel<T>;
                return converter!.Create(data, options);
            }
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="returnType">The type of the objec to convert and return.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
        /// <exception cref="MissingMethodException">If <paramref name="returnType"/> does not have a public or non public empty constructor.</exception>
        public static object? Read(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelReaderWriterOptions? options = default)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (returnType is null)
            {
                throw new ArgumentNullException(nameof(returnType));
            }

            options ??= ModelReaderWriterOptions.Json;

            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition().Equals(typeof(List<>)))
            {
                var list = Activator.CreateInstance(returnType);
                ReadList(data, returnType.GenericTypeArguments[0], (list as IList)!, options);
                return list;
            }
            else
            {
                return GetInstance(returnType).Create(data, options);
            }
        }

        private static IPersistableModel<object> GetInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            var model = GetObjectInstance(returnType) as IPersistableModel<object>;
            if (model is null)
            {
                throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IPersistableModel<object>)}");
            }
            return model;
        }

        private static IPersistableModel<T> GetInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
            where T : IPersistableModel<T>
        {
            var model = GetObjectInstance(typeof(T)) as IPersistableModel<T>;
            if (model is null)
            {
                throw new InvalidOperationException($"{typeof(T).Name} does not implement {nameof(IPersistableModel<T>)}");
            }
            return model;
        }

        private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            PersistableModelProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(PersistableModelProxyAttribute), false) as PersistableModelProxyAttribute;
            Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

            if (returnType.IsAbstract && attribute is null)
            {
                throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(PersistableModelProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
            }

            var obj = Activator.CreateInstance(typeToActivate, true);
            if (obj is null)
            {
                throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
            }
            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ShouldUseJsonInterface<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
        {
            return options.Format == "J" || (options.Format == "W" && model.GetFormatFromOptions(options) == "J");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IJsonModel<T> GetJsonInterface<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
        {
            if (model is not IJsonModel<T> jsonModel)
            {
                throw new FormatException($"The model {model.GetType().Name} does not support '{options.Format}' format.");
            }

            return jsonModel;
        }
    }
}
