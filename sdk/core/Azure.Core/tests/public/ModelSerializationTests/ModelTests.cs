// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public abstract class ModelTests<T> where T : IModelSerializable<T>
    {
        private T _modelInstance;
        private T ModelInstance => _modelInstance ??= GetModelInstance();

        private bool IsXmlWireFormat => WirePayload.StartsWith("<", StringComparison.Ordinal);

        protected virtual T GetModelInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
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
            options.ObjectSerializerResolver = GetObjectSerializerFactory(format);

            var expectedSerializedString = GetExpectedResult(format);

            if (AssertFailures(strategy, format, serviceResponse, options))
                return;

            T model = (T)strategy.Deserialize(serviceResponse, ModelInstance, options);

            VerifyModel(model, format);
            var data = strategy.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            T model2 = (T)strategy.Deserialize(roundTrip, ModelInstance, options);
            CompareModels(model, model2, format);
        }

        private bool AssertFailures(RoundTripStrategy<T> strategy, ModelSerializerFormat format, string serviceResponse, ModelSerializerOptions options)
        {
            bool result = false;
            if (IsXmlWireFormat && (strategy.IsExplicitJsonDeserialize || strategy.IsExplicitJsonSerialize) && format == ModelSerializerFormat.Wire)
            {
                if (strategy.IsExplicitJsonDeserialize)
                {
                    if (strategy.GetType().Name.StartsWith("ModelJsonConverterStrategy"))
                    {
                        //we never get to the interface implementation because JsonSerializer errors before that
                        Assert.Throws<JsonException>(() => { T model = (T)strategy.Deserialize(serviceResponse, ModelInstance, options); });
                        result = true;
                    }
                    else
                    {
                        Assert.Throws<InvalidOperationException>(() => { T model = (T)strategy.Deserialize(serviceResponse, ModelInstance, options); });
                        result = true;
                    }
                }

                if (strategy.IsExplicitJsonSerialize)
                {
                    Assert.Throws<InvalidOperationException>(() => { var data = strategy.Serialize(ModelInstance, options); });
                    result = true;
                }
            }
            else if (ModelInstance is not IModelJsonSerializable<T> && format == ModelSerializerFormat.Json)
            {
                Assert.Throws<FormatException>(() => { T model = (T)strategy.Deserialize(serviceResponse, ModelInstance, options); });
                Assert.Throws<FormatException>(() => { var data = strategy.Serialize(ModelInstance, options); });
                result = true;
            }
            return result;
        }

        internal static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            while (modelType.BaseType != typeof(object) && modelType.BaseType != typeof(ValueType))
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
            Assert.Throws<FormatException>(() => ModelSerializer.Serialize(ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelSerializer.Deserialize<T>(new BinaryData("x"), options));

            Assert.Throws<FormatException>(() => ModelSerializer.Serialize((IModelSerializable<object>)ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelSerializer.Deserialize(new BinaryData("x"), typeof(T), options));
            if (ModelInstance is IModelJsonSerializable<T> jsonModel)
            {
                Assert.Throws<FormatException>(() => jsonModel.Serialize(new Utf8JsonWriter(new MemoryStream()), options));
                Assert.Throws<FormatException>(() => ((IModelJsonSerializable<object>)jsonModel).Serialize(new Utf8JsonWriter(new MemoryStream()), options));
                bool gotException = false;
                try
                {
                    Utf8JsonReader reader = default;
                    jsonModel.Deserialize(ref reader, options);
                }
                catch (FormatException)
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
                catch (FormatException)
                {
                    gotException = true;
                }
                finally
                {
                    Assert.IsTrue(gotException);
                }
            }
        }

        [Test]
        public void ThrowsIfWireIsNotJson()
        {
            if (ModelInstance is IModelJsonSerializable<T> jsonModel && IsXmlWireFormat)
            {
                Assert.Throws<InvalidOperationException>(() => jsonModel.Serialize(new Utf8JsonWriter(new MemoryStream()), new ModelSerializerOptions(ModelSerializerFormat.Wire)));
                Utf8JsonReader reader = new Utf8JsonReader(new byte[] { });
                bool exceptionCaught = false;
                try
                {
                    jsonModel.Deserialize(ref reader, new ModelSerializerOptions(ModelSerializerFormat.Wire));
                }
                catch (InvalidOperationException)
                {
                    exceptionCaught = true;
                }
                Assert.IsTrue(exceptionCaught, "Expected InvalidOperationException to be thrown when deserializing wire format as json");
            }
        }

        [Test]
        public void CastNull()
        {
            if (typeof(T).IsClass)
            {
                object model = null;
                RequestContent content = ToRequestContent((T)model);
                Assert.IsNull(content);
            }
            else
            {
                T model = default;
                RequestContent content = ToRequestContent(model);
                Assert.IsNotNull(content);
            }

            Response response = null;
            Assert.Throws<ArgumentNullException>(() => FromResponse(response));
        }
    }
}
