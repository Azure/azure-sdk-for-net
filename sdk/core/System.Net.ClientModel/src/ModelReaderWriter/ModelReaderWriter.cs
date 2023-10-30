// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel
{
    /// <summary>
    /// Provides functionality to read and write <see cref="IModel{T}"/> and <see cref="IJsonModel{T}"/>.
    /// </summary>
    public static class ModelReaderWriter
    {
        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write<T>(T model, ModelReaderWriterOptions? options = default) where T : IModel<T>
        {
            ClientUtilities.AssertNotNull(model, nameof(model));

            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            return model.Write(options);
        }

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        /// <param name="model">The model to convert.</param>
        /// <param name="format">The <see cref="ModelReaderWriterFormat"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterFormat"/> specified by the <paramref name="format"/>.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write<T>(T model, ModelReaderWriterFormat format)
            where T : IModel<T>
            => Write<T>(model, ModelReaderWriterOptions.GetOptions(format));

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IModel{T}"/>.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write(object model, ModelReaderWriterOptions? options = default)
        {
            ClientUtilities.AssertNotNull(model, nameof(model));

            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            var iModel = model as IModel<object>;
            if (iModel is null)
            {
                throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IModel<object>)}");
            }

            return iModel.Write(options);
        }

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="format">The <see cref="ModelReaderWriterFormat"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterFormat"/> specified by the <paramref name="format"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IModel{T}"/>.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
        public static BinaryData Write(object model, ModelReaderWriterFormat format)
            => Write(model, ModelReaderWriterOptions.GetOptions(format));

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
        public static T? Read<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelReaderWriterOptions? options = default) where T : IModel<T>
        {
            ClientUtilities.AssertNotNull(data, nameof(data));

            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            return GetInstance<T>().Read(data, options);
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="format">The <see cref="ModelReaderWriterFormat"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
        public static T? Read<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelReaderWriterFormat format)
            where T : IModel<T>
            => Read<T>(data, ModelReaderWriterOptions.GetOptions(format));

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="returnType">The type of the objec to convert and return.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IModel{T}"/>.</exception>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
        public static object? Read(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelReaderWriterOptions? options = default)
        {
            ClientUtilities.AssertNotNull(data, nameof(data));
            ClientUtilities.AssertNotNull(returnType, nameof(returnType));

            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            return GetInstance(returnType).Read(data, options);
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
        /// <param name="returnType">The type of the objec to convert and return.</param>
        /// <param name="format">The <see cref="ModelReaderWriterFormat"/> to use.</param>
        /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IModel{T}"/>.</exception>
        /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterFormat"/>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
        public static object? Read(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelReaderWriterFormat format)
            => Read(data, returnType, ModelReaderWriterOptions.GetOptions(format));

        /// <summary>
        /// Converts the value of a model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterFormat"/> specified by the <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> or <paramref name="options"/> are null.</exception>
        public static BinaryData WriteCore(IJsonModel<object> model, ModelReaderWriterOptions options)
        {
            ClientUtilities.AssertNotNull(model, nameof(model));
            ClientUtilities.AssertNotNull(options, nameof(options));

            using ModelWriter writer = new ModelWriter(model, options);
            return writer.ToBinaryData();
        }

        private static IModel<object> GetInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            var model = GetObjectInstance(returnType) as IModel<object>;
            if (model is null)
            {
                throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IModel<object>)}");
            }
            return model;
        }

        private static IModel<T> GetInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>() where T : IModel<T>
        {
            var model = GetObjectInstance(typeof(T)) as IModel<T>;
            if (model is null)
            {
                throw new InvalidOperationException($"{typeof(T).Name} does not implement {nameof(IModel<T>)}");
            }
            return model;
        }

        private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
        {
            ModelReaderProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(ModelReaderProxyAttribute), false) as ModelReaderProxyAttribute;
            Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

            if (returnType.IsAbstract && attribute is null)
            {
                throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(ModelReaderProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
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
