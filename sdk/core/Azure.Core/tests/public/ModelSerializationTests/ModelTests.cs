// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml;
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
        public void RoundTripWithXmlInterface(string format)
        {
            if (ModelInstance is IModelXmlSerializable<T>)
            {
                if (format == ModelSerializerFormat.Wire)
                {
                    RoundTripTest(format, new XmlInterfaceStrategy<T>());
                }
                else
                {
                    Assert.Throws<InvalidOperationException>(() => RoundTripTest(format, new XmlInterfaceStrategy<T>()));
                }
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithXmlInterfaceNonGeneric(string format)
        {
            if (ModelInstance is IModelXmlSerializable<T>)
            {
                if (format == ModelSerializerFormat.Wire)
                {
                    RoundTripTest(format, new XmlInterfaceNonGenericStrategy<T>());
                }
                else
                {
                    Assert.Throws<InvalidOperationException>(() => RoundTripTest(format, new XmlInterfaceNonGenericStrategy<T>()));
                }
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithXmlInterfaceXElement(string format)
        {
            if (ModelInstance is IModelXmlSerializable<T>)
            {
                if (format == ModelSerializerFormat.Wire)
                {
                    RoundTripTest(format, new XmlInterfaceXElementStrategy<T>());
                }
                else
                {
                    Assert.Throws<XmlException>(() => RoundTripTest(format, new XmlInterfaceXElementStrategy<T>()));
                }
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithXmlInterfaceXElementNonGeneric(string format)
        {
            if (ModelInstance is IModelXmlSerializable<T>)
            {
                if (format == ModelSerializerFormat.Wire)
                {
                    RoundTripTest(format, new XmlInterfaceXElementNonGenericStrategy<T>());
                }
                else
                {
                    Assert.Throws<XmlException>(() => RoundTripTest(format, new XmlInterfaceXElementNonGenericStrategy<T>()));
                }
            }
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
        public void RoundTripWithJsonInterfaceSequenceWriter(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceSequenceWriterStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceSequenceNonGenericWriter(string format)
        {
            if (ModelInstance is IModelJsonSerializable<T>)
                RoundTripTest(format, new JsonInterfaceSequenceWriterNonGenericStrategy<T>());
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

            if (IsXmlWireFormat && strategy.IsExplicitJsonDeserialize && format == ModelSerializerFormat.Wire)
            {
                Assert.Throws<InvalidOperationException>(() => { T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T; });
            }
            else
            {
                T model = strategy.Deserialize(serviceResponse, ModelInstance, options) as T;

                VerifyModel(model, format);
                if (IsXmlWireFormat && strategy.IsExplicitJsonSerialize && format == ModelSerializerFormat.Wire)
                {
                    Assert.Throws<InvalidOperationException>(() => { var data = strategy.Serialize(model, options); });
                }
                else
                {
                    var data = strategy.Serialize(model, options);
                    string roundTrip = data.ToString();

                    Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

                    T model2 = strategy.Deserialize(roundTrip, ModelInstance, options) as T;
                    CompareModels(model, model2, format);
                }
            }
        }

        protected Dictionary<string, BinaryData> GetRawData(object model)
        {
            var propertyInfo = model.GetType().GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            return propertyInfo.GetValue(model) as Dictionary<string, BinaryData>;
        }
    }
}
