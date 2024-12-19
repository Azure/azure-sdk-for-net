// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using NUnit.Framework;
using System;
using System.Buffers;
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
            MockHelpers.LoadMockPlugin();
        }

        [TestCase(typeof(Guid))]
        [TestCase(typeof(IPAddress))]
        [TestCase(typeof(ETag))]
        [TestCase(typeof(AzureLocation))]
        [TestCase(typeof(ResourceIdentifier))]
        public void ValidateSerializationStatement(Type type)
        {
            var value = new ParameterProvider("value", $"", type).AsExpression().As(type);
            var writer = new ParameterProvider("writer", $"", typeof(Utf8JsonWriter)).AsExpression().As<Utf8JsonWriter>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsExpression().As<ModelReaderWriterOptions>();

            var statement = AzureClientPlugin.Instance.TypeFactory.SerializeValueType(type, SerializationFormat.Default, value, type, writer, options);
            Assert.IsNotNull(statement);

            var expected = Helpers.GetExpectedFromFile(type.ToString());
            Assert.AreEqual(expected, statement.ToDisplayString());
        }

        [TestCase(typeof(Guid))]
        [TestCase(typeof(IPAddress))]
        [TestCase(typeof(ETag))]
        [TestCase(typeof(AzureLocation))]
        [TestCase(typeof(ResourceIdentifier))]
        public void ValidateDeserializationExpression(Type type)
        {
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsExpression().As<JsonElement>();

            var expression = AzureClientPlugin.Instance.TypeFactory.GetValueTypeDeserializationExpression(type, element, SerializationFormat.Default);
            Assert.IsNotNull(expression);

            var expected = Helpers.GetExpectedFromFile(type.ToString());
            Assert.AreEqual(expected, expression.ToDisplayString());
        }

        [Test]
        public void Uuid()
        {
            var input = InputFactory.Primitive.String("uuid", "Azure.Core.uuid");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(Guid), actual?.FrameworkType);
        }

        [Test]
        public void IPv4Address()
        {
            var input = InputFactory.Primitive.String("ipV4Address", "Azure.Core.ipV4Address");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(IPAddress), actual?.FrameworkType);
        }

        [Test]
        public void IPv6Address()
        {
            var input = InputFactory.Primitive.String("ipV6Address", "Azure.Core.ipV6Address");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(IPAddress), actual?.FrameworkType);
        }

        [Test]
        public void ETag()
        {
            var input = InputFactory.Primitive.String("eTag", "Azure.Core.eTag");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(ETag), actual?.FrameworkType);
        }

        [Test]
        public void AzureLocation()
        {
            var input = InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(AzureLocation), actual?.FrameworkType);
        }

        [Test]
        public void ResourceIdentifier()
        {
            var input = InputFactory.Primitive.String("armResourceIdentifier", "Azure.Core.armResourceIdentifier");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(ResourceIdentifier), actual?.FrameworkType);
        }
    }
}
