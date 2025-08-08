// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public abstract class MrwModelTests<T> : MrwTestBase<T> where T : IPersistableModel<T>
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");

        private bool IsXmlWireFormat => WirePayload.StartsWith("<", StringComparison.Ordinal);

        protected override T GetModelInstance()
        {
            var modelInstance = Activator.CreateInstance(typeof(T), true);
            if (modelInstance is null)
                throw new Exception($"Unable to create a model instance of {typeof(T).Name}");
            return (T)modelInstance;
        }

        protected abstract string GetExpectedResult(string format);
        protected abstract void VerifyModel(T model, string format);
        protected abstract void CompareModels(T model, T model2, string format);

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriter(string format)
            => RoundTripTest(format, new ModelReaderWriterStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelInterface(string format)
            => RoundTripTest(format, new ModelInterfaceStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelInterfaceNonGeneric(string format)
            => RoundTripTest(format, new ModelInterfaceAsObjectStrategy<T>());

        protected override void RoundTripTest(string format, RoundTripStrategy<T> strategy)
        {
            string serviceResponse = format == "J" ? JsonPayload : WirePayload;

            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            //options.ObjectSerializerResolver = GetObjectSerializerFactory(format);

            var expectedSerializedString = GetExpectedResult(format);

            if (AssertFailures(strategy, format, serviceResponse, options))
                return;

            T? model = (T?)strategy.Read(serviceResponse, Instance, options);
            Assert.That(model, Is.Not.Null, "Strategy.Read returned null");
            VerifyModel(model!, format);
            var data = strategy.Write(model!, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            T? model2 = (T?)strategy.Read(roundTrip, Instance, options);
            Assert.That(model2, Is.Not.Null, "Strategy.Read returned null for roundtrip");
            CompareModels(model!, model2!, format);
        }

        private bool AssertFailures(RoundTripStrategy<T> strategy, string format, string serviceResponse, ModelReaderWriterOptions options)
        {
            bool result = false;
            if (IsXmlWireFormat && (strategy.IsExplicitJsonRead || strategy.IsExplicitJsonWrite) && format == "W")
            {
                if (strategy.IsExplicitJsonRead)
                {
                    if (strategy.GetType().Name.StartsWith("ModelJsonConverterStrategy"))
                    {
                        //we never get to the interface implementation because JsonSerializer errors before that
                        Assert.Throws<JsonException>(() => { T? model = (T?)strategy.Read(serviceResponse, Instance, options); });
                        result = true;
                    }
                    else
                    {
                        Assert.Throws<InvalidOperationException>(() => { T? model = (T?)strategy.Read(serviceResponse, Instance, options); });
                        result = true;
                    }
                }

                if (strategy.IsExplicitJsonWrite)
                {
                    Assert.Throws<InvalidOperationException>(() => { var data = strategy.Write(Instance, options); });
                    result = true;
                }
            }
            else if (Instance is not IJsonModel<T> && format == "J")
            {
                Assert.Throws<FormatException>(() => { T? model = (T?)strategy.Read(serviceResponse, Instance, options); });
                Assert.Throws<FormatException>(() => { var data = strategy.Write(Instance, options); });
                result = true;
            }
            return result;
        }

        internal static Dictionary<string, BinaryData> GetRawData(object model)
        {
            Type modelType = model.GetType();
            while (modelType.BaseType != typeof(object) && modelType.BaseType != typeof(ValueType))
            {
                modelType = modelType.BaseType!;
            }
            var propertyInfo = modelType.GetField("_rawData", BindingFlags.Instance | BindingFlags.NonPublic);
            return propertyInfo?.GetValue(model) as Dictionary<string, BinaryData> ?? throw new InvalidOperationException($"unable to get raw data from {model.GetType().Name}");
        }

        [Test]
        public void ThrowsIfUnknownFormat()
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("x");
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(Instance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read<T>(new BinaryData("x"), options));

            Assert.Throws<FormatException>(() => ModelReaderWriter.Write((IPersistableModel<object>)Instance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read(new BinaryData("x"), typeof(T), options));
            if (Instance is IJsonModel<T> jsonModel)
            {
                Assert.Throws<FormatException>(() => jsonModel.Write(new Utf8JsonWriter(new MemoryStream()), options));
                Assert.Throws<FormatException>(() => ((IJsonModel<object>)jsonModel).Write(new Utf8JsonWriter(new MemoryStream()), options));
                bool gotException = false;
                try
                {
                    Utf8JsonReader reader = default;
                    jsonModel.Create(ref reader, options);
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
                    ((IJsonModel<object>)jsonModel).Create(ref reader, options);
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
            if (Instance is IJsonModel<T> jsonModel && IsXmlWireFormat)
            {
                Assert.Throws<InvalidOperationException>(() => jsonModel.Write(new Utf8JsonWriter(new MemoryStream()), _wireOptions));
                Utf8JsonReader reader = new Utf8JsonReader(new byte[] { });
                bool exceptionCaught = false;
                try
                {
                    jsonModel.Create(ref reader, _wireOptions);
                }
                catch (InvalidOperationException)
                {
                    exceptionCaught = true;
                }
                Assert.IsTrue(exceptionCaught, "Expected InvalidOperationException to be thrown when deserializing wire format as json");
            }
        }
    }
}
