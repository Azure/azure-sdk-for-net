// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public abstract class ModelTests<T> where T : class, IModelSerializable<T>
    {
        private T _modelInstance;
        private T ModelInstance => _modelInstance ??= GetModelInstance();

        private bool IsXmlWireFormat => WirePayload.StartsWith("<", StringComparison.Ordinal);

        protected virtual T GetModelInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        protected abstract string GetExpectedResult(ModelSerializerFormat format);
        protected abstract void VerifyModel(T model, ModelSerializerFormat format);
        protected abstract void CompareModels(T model, T model2, ModelSerializerFormat format);
        protected abstract string JsonPayload { get; }
        protected abstract string WirePayload { get; }
        protected abstract Func<T, RequestContent> ToRequestContent { get; }
        protected abstract Func<Response, T> FromResponse { get; }

        protected virtual Func<Type, ObjectSerializer> GetObjectSerializerFactory(ModelSerializerFormat format) => null;

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelSerializer(string format)
            => RoundTripTest(format, new ModelSerializerStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelSerializerNonGeneric(string format)
            => RoundTripTest(format, new ModelSerializerNonGenericStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelSerializerFormatOverload(string format)
        {
            //if we only pass in the format we can't test BYOM
            if (!typeof(T).IsGenericType)
                RoundTripTest(format, new ModelSerializerFormatOverloadStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelInterface(string format)
            => RoundTripTest(format, new ModelInterfaceStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelInterfaceNonGeneric(string format)
            => RoundTripTest(format, new ModelInterfaceNonGenericStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterface(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceNonGeneric(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceNonGenericStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceUtf8Reader(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceUtf8ReaderStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceUtf8ReaderNonGeneric(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceUtf8ReaderNonGenericStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelJsonConverter(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new ModelJsonConverterStrategy<T>());
        }

        [Test]
        public void RoundTripWithCast()
        {
            //cast does not work without options
            if (!typeof(T).IsGenericType)
                RoundTripTest(ModelSerializerFormat.Wire, new CastStrategy<T>(ToRequestContent, FromResponse));
        }

        protected void RoundTripTest(ModelSerializerFormat format, RoundTripStrategy<T> strategy)
        {
            string serviceResponse = format == ModelSerializerFormat.Json ? JsonPayload : WirePayload;

            ModelSerializerOptions options = new ModelSerializerOptions(format);
            options.GenericTypeSerializerCreator = GetObjectSerializerFactory(format);

            var expectedSerializedString = GetExpectedResult(format);

            if (IsXmlWireFormat && (strategy.IsExplicitJsonDeserialize || strategy.IsExplicitJsonSerialize) && format == ModelSerializerFormat.Wire)
            {
                if (strategy.IsExplicitJsonDeserialize)
                {
                    if (strategy is ModelJsonConverterStrategy<T>)
                    {
                        //we never get to the interface implementation because JsonSerializer errors before that
                        Assert.Throws<JsonException>(() => { T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T; });
                    }
                    else
                    {
                        Assert.Throws<InvalidOperationException>(() => { T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T; });
                    }
                }

                if (strategy.IsExplicitJsonSerialize)
                {
                    Assert.Throws<InvalidOperationException>(() => { var data = strategy.Serialize(ModelInstance, options); });
                }
            }
            else if (ModelInstance is not IModelJsonSerializable<T> && format == ModelSerializerFormat.Json)
            {
                Assert.Throws<NotSupportedException>(() => { T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T; });
                Assert.Throws<NotSupportedException>(() => { var data = strategy.Serialize(ModelInstance, options); });
            }
            else
            {
                T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T;

                VerifyModel(model, format);
                var data = strategy.Serialize(model, options);
                string roundTrip = data.ToString();

                Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

                T model2 = strategy.Deserialize(roundTrip, ModelInstance, options) as T;
                CompareModels(model, model2, format);
            }
        }

        internal static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            while (modelType.BaseType != typeof(object))
            {
                modelType = modelType.BaseType;
            }
            var propertyInfo = modelType.GetField("_rawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            return propertyInfo.GetValue(model) as Dictionary<string, BinaryData>;
        }

        [Test]
        public void ThrowsIfUnknownFormat()
        {
            ModelSerializerOptions options = new ModelSerializerOptions("x");
            Assert.Throws<NotSupportedException>(() => ModelSerializer.Serialize(ModelInstance, options));
            Assert.Throws<NotSupportedException>(() => ModelSerializer.Deserialize<T>(new BinaryData("x"), options));

            Assert.Throws<NotSupportedException>(() => ModelSerializer.Serialize((IModelSerializable<object>)ModelInstance, options));
            Assert.Throws<NotSupportedException>(() => ModelSerializer.Deserialize(new BinaryData("x"), typeof(T), options));
            if (ModelInstance is IModelJsonSerializable<T> jsonModel)
            {
                Assert.Throws<NotSupportedException>(() => jsonModel.Serialize(new Utf8JsonWriter(new MemoryStream()), options));
                Assert.Throws<NotSupportedException>(() => ((IModelJsonSerializable<object>)jsonModel).Serialize(new Utf8JsonWriter(new MemoryStream()), options));
                bool gotException = false;
                try
                {
                    Utf8JsonReader reader = default;
                    jsonModel.Deserialize(ref reader, options);
                }
                catch (NotSupportedException)
                {
                    gotException = true;
                }
                finally
                {
                    Assert.IsTrue(gotException);
                }

                gotException = false;
                try
                {
                    Utf8JsonReader reader = default;
                    ((IModelJsonSerializable<object>)jsonModel).Deserialize(ref reader, options);
                }
                catch (NotSupportedException)
                {
                    gotException = true;
                }
                finally
                {
                    Assert.IsTrue(gotException);
                }
            }
        }
    }
}
