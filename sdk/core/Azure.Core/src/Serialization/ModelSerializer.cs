// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides functionality to serialize and deserialize Azure models.
    /// </summary>
    public static class ModelSerializer
    {
        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelSerializerFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Serialize<T>(T model, ModelSerializerOptions? options = default) where T : IModelSerializable<T>
        {
            Argument.AssertNotNull(model, nameof(model));

            options ??= ModelSerializerOptions.DefaultWireOptions;

            return model.Serialize(options);
        }

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="model">The model to convert.</param>
        /// <param name="format">The <see cref="ModelSerializerFormat"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelSerializerFormat"/> specified by the <paramref name="format"/>.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Serialize<T>(T model, ModelSerializerFormat format)
            where T : IModelSerializable<T>
            => Serialize<T>(model, ModelSerializerOptions.GetOptions(format));

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelSerializerFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IModelSerializable{T}"/>.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Serialize(object model, ModelSerializerOptions? options = default)
        {
            Argument.AssertNotNull(model, nameof(model));

            options ??= ModelSerializerOptions.DefaultWireOptions;

            var iModel = model as IModelSerializable<object>;
            if (iModel is null)
            {
                throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IModelSerializable<object>)}");
            }

            return iModel.Serialize(options);
        }

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="format">The <see cref="ModelSerializerFormat"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelSerializerFormat"/> specified by the <paramref name="format"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IModelSerializable{T}"/>.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Serialize(object model, ModelSerializerFormat format)
            => Serialize(model, ModelSerializerOptions.GetOptions(format));

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
        public static T? Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelSerializerOptions? options = default) where T : IModelSerializable<T>
        {
            Argument.AssertNotNull(data, nameof(data));

            options ??= ModelSerializerOptions.DefaultWireOptions;

            return GetInstance<T>().Deserialize(data, options);
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="format">The <see cref="ModelSerializerFormat"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
        public static T? Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelSerializerFormat format)
            where T : IModelSerializable<T>
            => Deserialize<T>(data, ModelSerializerOptions.GetOptions(format));

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="returnType">The type of the objec to convert and return.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IModelSerializable{T}"/>.</exception>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
        public static object? Deserialize(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelSerializerOptions? options = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(returnType, nameof(returnType));

            options ??= ModelSerializerOptions.DefaultWireOptions;

            return GetInstance(returnType).Deserialize(data, options);
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="returnType">The type of the objec to convert and return.</param>
        /// <param name="format">The <see cref="ModelSerializerFormat"/> to use.</param>
        /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IModelSerializable{T}"/>.</exception>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
        public static object? Deserialize(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelSerializerFormat format)
            => Deserialize(data, returnType, ModelSerializerOptions.GetOptions(format));

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelSerializerFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> or <paramref name="options"/> are null.</exception>
        public static BinaryData SerializeCore(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(options, nameof(options));

            using ModelWriter writer = new ModelWriter(model, options);
            return writer.ToBinaryData();
        }

        private static IModelSerializable<object> GetInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            var model = GetObjectInstance(returnType) as IModelSerializable<object>;
            if (model is null)
            {
                throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IModelSerializable<object>)}");
            }
            return model;
        }

        private static IModelSerializable<T> GetInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>() where T : IModelSerializable<T>
        {
            var model = GetObjectInstance(typeof(T)) as IModelSerializable<T>;
            if (model is null)
            {
                throw new InvalidOperationException($"{typeof(T).Name} does not implement {nameof(IModelSerializable<T>)}");
            }
            return model;
        }

        private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            DeserializationProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(DeserializationProxyAttribute), false) as DeserializationProxyAttribute;
            Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

            if (returnType.IsAbstract && attribute is null)
            {
                throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(DeserializationProxyAttribute)} to be used with {nameof(ModelSerializer)}");
            }

            var obj = Activator.CreateInstance(typeToActivate, true);
            if (obj is null)
            {
                throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
            }
            return obj;
        }
    }
}
