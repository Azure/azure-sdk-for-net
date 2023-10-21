// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ClientModel.Core.Content;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    public abstract class ModelTests<T> where T : IModel<T>
    {
        private T _modelInstance;
        private T ModelInstance => _modelInstance ??= GetModelInstance();

        private bool IsXmlWireFormat => WirePayload.StartsWith("<", StringComparison.Ordinal);

        protected virtual T GetModelInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }

        protected abstract string GetExpectedResult(ModelReaderWriterFormat format);
        protected abstract void VerifyModel(T model, ModelReaderWriterFormat format);
        protected abstract void CompareModels(T model, T model2, ModelReaderWriterFormat format);
        protected abstract string JsonPayload { get; }
        protected abstract string WirePayload { get; }
        protected abstract Func<T, RequestContent> ToRequestContent { get; }
        protected abstract Func<Response, T> FromResponse { get; }

        protected virtual Func<Type, ObjectSerializer> GetObjectSerializerFactory(ModelReaderWriterFormat format) => null;

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriter(string format)
            => RoundTripTest(format, new ModelReaderWriterStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterNonGeneric(string format)
            => RoundTripTest(format, new ModelReaderWriterNonGenericStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterFormatOverload(string format)
        {
            //if we only pass in the format we can't test BYOM
            if (!typeof(T).IsGenericType)
                RoundTripTest(format, new ModelReaderWriterFormatOverloadStrategy<T>());
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
                RoundTripTest(ModelReaderWriterFormat.Wire, new CastStrategy<T>(ToRequestContent, FromResponse));
        }

        protected void RoundTripTest(ModelReaderWriterFormat format, RoundTripStrategy<T> strategy)
        {
            string serviceResponse = format == ModelReaderWriterFormat.Json ? JsonPayload : WirePayload;

            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            //options.ObjectSerializerResolver = GetObjectSerializerFactory(format);

            var expectedSerializedString = GetExpectedResult(format);

            if (AssertFailures(strategy, format, serviceResponse, options))
                return;

            T model = (T)strategy.Read(serviceResponse, ModelInstance, options);

            VerifyModel(model, format);
            var data = strategy.Write(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            T model2 = (T)strategy.Read(roundTrip, ModelInstance, options);
            CompareModels(model, model2, format);
        }

        private bool AssertFailures(RoundTripStrategy<T> strategy, ModelReaderWriterFormat format, string serviceResponse, ModelReaderWriterOptions options)
        {
            bool result = false;
            if (IsXmlWireFormat && (strategy.IsExplicitJsonRead || strategy.IsExplicitJsonWrite) && format == ModelReaderWriterFormat.Wire)
            {
                if (strategy.IsExplicitJsonRead)
                {
                    if (strategy.GetType().Name.StartsWith("ModelJsonConverterStrategy"))
                    {
                        //we never get to the interface implementation because JsonSerializer errors before that
                        Assert.Throws<JsonException>(() => { T model = (T)strategy.Read(serviceResponse, ModelInstance, options); });
                        result = true;
                    }
                    else
                    {
                        Assert.Throws<InvalidOperationException>(() => { T model = (T)strategy.Read(serviceResponse, ModelInstance, options); });
                        result = true;
                    }
                }

                if (strategy.IsExplicitJsonWrite)
                {
                    Assert.Throws<InvalidOperationException>(() => { var data = strategy.Write(ModelInstance, options); });
                    result = true;
                }
            }
            else if (ModelInstance is not IJsonModel<T> && format == ModelReaderWriterFormat.Json)
            {
                Assert.Throws<FormatException>(() => { T model = (T)strategy.Read(serviceResponse, ModelInstance, options); });
                Assert.Throws<FormatException>(() => { var data = strategy.Write(ModelInstance, options); });
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
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("x");
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read<T>(new BinaryData("x"), options));

            Assert.Throws<FormatException>(() => ModelReaderWriter.Write((IModel<object>)ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read(new BinaryData("x"), typeof(T), options));
            if (ModelInstance is IJsonModel<T> jsonModel)
            {
                Assert.Throws<FormatException>(() => jsonModel.Write(new Utf8JsonWriter(new MemoryStream()), options));
                Assert.Throws<FormatException>(() => ((IJsonModel<object>)jsonModel).Write(new Utf8JsonWriter(new MemoryStream()), options));
                bool gotException = false;
                try
                {
                    Utf8JsonReader reader = default;
                    jsonModel.Read(ref reader, options);
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
                    ((IJsonModel<object>)jsonModel).Read(ref reader, options);
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
            if (ModelInstance is IJsonModel<T> jsonModel && IsXmlWireFormat)
            {
                Assert.Throws<InvalidOperationException>(() => jsonModel.Write(new Utf8JsonWriter(new MemoryStream()), new ModelReaderWriterOptions(ModelReaderWriterFormat.Wire)));
                Utf8JsonReader reader = new Utf8JsonReader(new byte[] { });
                bool exceptionCaught = false;
                try
                {
                    jsonModel.Read(ref reader, new ModelReaderWriterOptions(ModelReaderWriterFormat.Wire));
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
