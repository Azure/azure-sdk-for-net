// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Serializer class for Azure models.
    /// </summary>
    public static class ModelSerializer
    {
        /// <summary>
        /// Serialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static BinaryData Serialize<T>(T model, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            // if options.Serializers is set and the model is in the dictionary, use the serializer
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    return serializer.Serialize(model);
                }
            }
            return model.Serialize(options ?? new ModelSerializerOptions());
        }

        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(BinaryData data, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            return (T)Deserialize(data, typeof(T), options);
        }

        internal static object Deserialize(BinaryData data, Type typeToConvert, ModelSerializerOptions? options = default)
        {
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeToConvert, out serializer))
                {
                    var obj = serializer.Deserialize(data.ToStream(), typeToConvert, default);
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return obj;
                }
            }

            options ??= new ModelSerializerOptions();

            if (typeToConvert.IsAbstract)
                return DeserializeObject(data, typeToConvert, options);

            IModelSerializable? model = Activator.CreateInstance(typeToConvert, true) as IModelSerializable;
            if (model is null)
                throw new InvalidOperationException($"{typeToConvert.Name} does not implement {nameof(IModelSerializable)}.");

            return model.Deserialize(data, options);
        }

        private static readonly Type[] _combinedDeserializeMethodParameters = new Type[] { typeof(BinaryData), typeof(ModelSerializerOptions) };

        internal static object DeserializeObject(BinaryData data, Type typeToConvert, ModelSerializerOptions options)
        {
            var classNameInMethod = typeToConvert.Name.AsSpan();
            int backtickIndex = classNameInMethod.IndexOf('`');
            if (backtickIndex != -1)
                classNameInMethod = classNameInMethod.Slice(0, backtickIndex);
            var methodName = $"Deserialize{classNameInMethod.ToString()}";

            var method = typeToConvert.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static, null, _combinedDeserializeMethodParameters, null);
            if (method is null)
                throw new NotSupportedException($"{typeToConvert.Name} does not have a deserialize method defined.");

            return method.Invoke(null, new object[] { data, options })!;
        }
    }
}
