// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;

namespace Azure.Generator.Tests
{
    public class AzureTypeFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            MockHelpers.LoadMockGenerator();
        }

        [TestCase(typeof(Guid), ExpectedResult = "writer.WriteStringValue(value);\n")]
        [TestCase(typeof(IPAddress), ExpectedResult ="writer.WriteStringValue(value.ToString());\n")]
        [TestCase(typeof(ETag), ExpectedResult = "writer.WriteStringValue(value.ToString());\n")]
        [TestCase(typeof(AzureLocation), ExpectedResult = "writer.WriteStringValue(value);\n")]
        [TestCase(typeof(ResourceIdentifier), ExpectedResult = "writer.WriteStringValue(value);\n")]
        [TestCase(typeof(ResponseError), ExpectedResult = "((global::System.ClientModel.Primitives.IJsonModel<global::Azure.ResponseError>)value).Write(writer, options);\n")]
        public string ValidateSerializationStatement(Type type)
        {
            var value = new ParameterProvider("value", $"", type).AsExpression().As(type);
            var writer = new ParameterProvider("writer", $"", typeof(Utf8JsonWriter)).AsExpression().As<Utf8JsonWriter>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsExpression().As<ModelReaderWriterOptions>();

            var statement = AzureClientGenerator.Instance.TypeFactory.SerializeJsonValue(type, value, writer, options, SerializationFormat.Default);
            Assert.IsNotNull(statement);

            return statement.ToDisplayString();
        }

        [TestCase(typeof(Guid), ExpectedResult = "new global::System.Guid(element.GetString())")]
        [TestCase(typeof(IPAddress), ExpectedResult = "global::System.Net.IPAddress.Parse(element.GetString())")]
        [TestCase(typeof(ETag), ExpectedResult = "new global::Azure.ETag(element.GetString())")]
        [TestCase(typeof(AzureLocation), ExpectedResult = "new global::Azure.Core.AzureLocation(element.GetString())")]
        [TestCase(typeof(ResourceIdentifier), ExpectedResult = "new global::Azure.Core.ResourceIdentifier(element.GetString())")]
        [TestCase(typeof(ResponseError), ExpectedResult = "global::System.ClientModel.Primitives.ModelReaderWriter.Read<global::Azure.ResponseError>(new global::System.BinaryData(global::System.Text.Encoding.UTF8.GetBytes(element.GetRawText())), options, global::Samples.SamplesContext.Default)")]
        public string ValidateDeserializationExpression(Type type)
        {
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsExpression().As<JsonElement>();

            var expression = AzureClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                type,
                element,
                new ScopedApi<ModelReaderWriterOptions>(new VariableExpression(typeof(ModelReaderWriterOptions), "options")),
                SerializationFormat.Default);
            Assert.IsNotNull(expression);

            return expression.ToDisplayString();
        }

        [Test]
        public void Uuid()
        {
            var input = InputFactory.Primitive.String("uuid", "Azure.Core.uuid");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(Guid), actual?.FrameworkType);
        }

        [Test]
        public void IPv4Address()
        {
            var input = InputFactory.Primitive.String("ipV4Address", "Azure.Core.ipV4Address");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(IPAddress), actual?.FrameworkType);
        }

        [Test]
        public void IPv6Address()
        {
            var input = InputFactory.Primitive.String("ipV6Address", "Azure.Core.ipV6Address");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(IPAddress), actual?.FrameworkType);
        }

        [Test]
        public void ETag()
        {
            var input = InputFactory.Primitive.String("eTag", "Azure.Core.eTag");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(ETag), actual?.FrameworkType);
        }

        [Test]
        public void AzureLocation()
        {
            var input = InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(AzureLocation), actual?.FrameworkType);
        }

        [Test]
        public void ResourceIdentifier()
        {
            var input = InputFactory.Primitive.String("armResourceIdentifier", "Azure.Core.armResourceIdentifier");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(ResourceIdentifier), actual?.FrameworkType);
        }

        [Test]
        public void ResponseError()
        {
            var input = InputFactory.Primitive.String("responseError", "Azure.Core.Foundations.Error");

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(ResponseError), actual?.FrameworkType);
        }

        [TestCase(typeof(Guid))]
        [TestCase(typeof(ETag))]
        [TestCase(typeof(ResourceIdentifier))]
        [TestCase(typeof(AzureLocation))]
        [TestCase(typeof(ResponseError))]
        public void CreatesFrameworkType(Type expectedType)
        {
            var factory = new TestTypeFactory();

            var actual = factory.InvokeCreateFrameworkType(expectedType.FullName!);
            Assert.AreEqual(expectedType, actual);
        }
    }
}
