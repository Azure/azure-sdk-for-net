// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public abstract class ModelTests<T> where T : class, IModelSerializable<T>
    {
        private T _modelInstance;

        public ModelTests()
        {
            _modelInstance = Activator.CreateInstance(typeof(T), true) as T;
        }

        protected abstract string GetExpectedResult(ModelSerializerFormat format);
        protected abstract void VerifyModel(T model, ModelSerializerFormat format);
        protected abstract void CompareModels(T model, T model2, ModelSerializerFormat format);
        protected abstract string JsonPayload { get; }
        protected abstract string WirePayload { get; }
        protected abstract Func<T, RequestContent> ToRequestContent { get; }
        protected abstract Func<Response, T> FromResponse { get; }

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
        public void RoundTripWithXmlInterface(string format)
        {
            if (_modelInstance is IXmlModelSerializable<T>)
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
            if (_modelInstance is IXmlModelSerializable<T>)
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
            if (_modelInstance is IXmlModelSerializable<T>)
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
            if (_modelInstance is IXmlModelSerializable<T>)
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
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceNonGeneric(string format)
        {
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceNonGenericStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceUtf8Reader(string format)
        {
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceUtf8ReaderStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceUtf8ReaderNonGeneric(string format)
        {
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceUtf8ReaderNonGenericStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceSequenceWriter(string format)
        {
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceSequenceWriterStrategy<T>());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonInterfaceSequenceNonGenericWriter(string format)
        {
            if (_modelInstance is IJsonModelSerializable<T>)
                RoundTripTest(format, new JsonInterfaceSequenceWriterNonGenericStrategy<T>());
        }

        [Test]
        public void RoundTripWithCast()
            => RoundTripTest(ModelSerializerFormat.Wire, new CastStrategy<T>(ToRequestContent, FromResponse));

        protected void RoundTripTest(ModelSerializerFormat format, RoundTripStrategy<T> strategy)
        {
            string serviceResponse = format == ModelSerializerFormat.Json ? JsonPayload : WirePayload;

            ModelSerializerOptions options = new ModelSerializerOptions(format);

            var expectedSerializedString = GetExpectedResult(format);

            T model = strategy.Deserialize(serviceResponse, options) as T;

            VerifyModel(model, format);
            var data = strategy.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            T model2 = strategy.Deserialize(roundTrip, options) as T;
            CompareModels(model, model2, format);
        }
    }
}
