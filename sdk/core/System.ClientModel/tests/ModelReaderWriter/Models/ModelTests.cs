// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Text.Json;
using System.Linq;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public abstract class ModelTests<T> where T : IPersistableModel<T>
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");

        private T? _modelInstance;
        private T ModelInstance => _modelInstance ??= GetModelInstance();

        private bool IsXmlWireFormat => WirePayload.StartsWith("<", StringComparison.Ordinal);

        protected virtual T GetModelInstance()
        {
            var modelInstance = Activator.CreateInstance(typeof(T), true);
            if (modelInstance is null)
                throw new Exception($"Unable to create a model instance of {typeof(T).Name}");
            return (T)modelInstance;
        }

        protected abstract string GetExpectedResult(string format);
        protected abstract void VerifyModel(T model, string format);
        protected abstract void CompareModels(T model, T model2, string format);
        protected abstract string JsonPayload { get; }
        protected abstract string WirePayload { get; }

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
        public void RoundTripWithModelInterface(string format)
            => RoundTripTest(format, new ModelInterfaceStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelInterfaceNonGeneric(string format)
            => RoundTripTest(format, new ModelInterfaceAsObjectStrategy<T>());

        protected void RoundTripTest(string format, RoundTripStrategy<T> strategy)
        {
            string serviceResponse = format == "J" ? JsonPayload : WirePayload;

            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            //options.ObjectSerializerResolver = GetObjectSerializerFactory(format);

            var expectedSerializedString = GetExpectedResult(format);

            if (AssertFailures(strategy, format, serviceResponse, options))
                return;

            T model = (T)strategy.Read(serviceResponse, ModelInstance, options);

            VerifyModel(model, format);
            var data = strategy.Write(model, options);
            string roundTrip = data.ToString();

            // we validate those are equivalent element, representing the same json object (ignoring the spaces and orders, etc)
            AssertJsonEquivalency(expectedSerializedString, roundTrip);

            T model2 = (T)strategy.Read(roundTrip, ModelInstance, options);
            CompareModels(model, model2, format);
        }

        private void AssertJsonEquivalency(string expected, string result)
        {
            using var expectedDoc = JsonDocument.Parse(expected);
            using var resultDoc = JsonDocument.Parse(result);

            AssertJsonEquivalency(expectedDoc.RootElement, resultDoc.RootElement);
        }

        private void AssertJsonEquivalency(JsonElement expected, JsonElement result)
        {
            if (expected.ValueKind != result.ValueKind)
            {
                Assert.Fail($"kind does not match between {expected} and {result}");
            }

            switch (result.ValueKind)
            {
                case JsonValueKind.Object:
                    AssertJsonObjectEquivalency(expected, result);
                    break;
                case JsonValueKind.Array:
                    AssertJsonArrayEquivalency(expected, result);
                    break;
                default:
                    Assert.AreEqual(expected.ToString(), result.ToString());
                    break;
            }
        }

        private void AssertJsonObjectEquivalency(JsonElement expected, JsonElement result)
        {
            // check result should have all properties in expected
            foreach (var expectedProperty in expected.EnumerateObject())
            {
                if (!result.TryGetProperty(expectedProperty.Name, out var resultPropertyValue))
                {
                    Assert.Fail($"expected property {expectedProperty} not found in {result}. Expected: {expected}");
                }
                AssertJsonEquivalency(expectedProperty.Value, resultPropertyValue);
            }

            foreach (var resultProperty in result.EnumerateObject())
            {
                if (!expected.TryGetProperty(resultProperty.Name, out var expectedPropertyValue))
                {
                    Assert.Fail($"result property {resultProperty} not found in {expected}.");
                }
                AssertJsonEquivalency(resultProperty.Value, expectedPropertyValue);
            }
        }

        private void AssertJsonArrayEquivalency(JsonElement expected, JsonElement result)
        {
            var expectedArray = expected.EnumerateArray().ToArray();
            var resultArray = result.EnumerateArray().ToArray();

            if (expectedArray.Length != resultArray.Length)
            {
                Assert.Fail($"expected array {expected} but got {result}");
            }

            for (int i = 0; i < expectedArray.Length; i++)
            {
                var ee = expectedArray[i];
                var re = resultArray[i];
                AssertJsonEquivalency(ee, re);
            }
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
            else if (ModelInstance is not IJsonModel<T> && format == "J")
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
                modelType = modelType.BaseType!;
            }
            var propertyInfo = modelType.GetField("_serializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
            return propertyInfo?.GetValue(model) as Dictionary<string, BinaryData> ?? throw new InvalidOperationException($"unable to get raw data from {model.GetType().Name}");
        }

        [Test]
        public void ThrowsIfUnknownFormat()
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("x");
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read<T>(new BinaryData("x"), options));

            Assert.Throws<FormatException>(() => ModelReaderWriter.Write((IPersistableModel<object>)ModelInstance, options));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read(new BinaryData("x"), typeof(T), options));
            if (ModelInstance is IJsonModel<T> jsonModel)
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
            if (ModelInstance is IJsonModel<T> jsonModel && IsXmlWireFormat)
            {
                Assert.Throws<FormatException>(() => jsonModel.Write(new Utf8JsonWriter(new MemoryStream()), _wireOptions));
                Utf8JsonReader reader = new Utf8JsonReader(new byte[] { });
                bool exceptionCaught = false;
                try
                {
                    jsonModel.Create(ref reader, _wireOptions);
                }
                catch (FormatException)
                {
                    exceptionCaught = true;
                }
                Assert.IsTrue(exceptionCaught, "Expected FormatException to be thrown when deserializing wire format as json");
            }
        }
    }
}
