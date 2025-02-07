﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        [TestCase(typeof(Guid), ExpectedResult = "writer.WriteStringValue(value);\n")]
        [TestCase(typeof(IPAddress), ExpectedResult ="writer.WriteStringValue(value.ToString());\n")]
        [TestCase(typeof(ETag), ExpectedResult = "writer.WriteStringValue(value.ToString());\n")]
        [TestCase(typeof(AzureLocation), ExpectedResult = "writer.WriteStringValue(value);\n")]
        [TestCase(typeof(ResourceIdentifier), ExpectedResult = "writer.WriteStringValue(value);\n")]
        public string ValidateSerializationStatement(Type type)
        {
            var value = new ParameterProvider("value", $"", type).AsExpression().As(type);
            var writer = new ParameterProvider("writer", $"", typeof(Utf8JsonWriter)).AsExpression().As<Utf8JsonWriter>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsExpression().As<ModelReaderWriterOptions>();

            var statement = AzureClientPlugin.Instance.TypeFactory.SerializeJsonValue(type, value, writer, options, SerializationFormat.Default);
            Assert.IsNotNull(statement);

            return statement.ToDisplayString();
        }

        [TestCase(typeof(Guid), ExpectedResult = "new global::System.Guid(element.GetString())")]
        [TestCase(typeof(IPAddress), ExpectedResult = "global::System.Net.IPAddress.Parse(element.GetString())")]
        [TestCase(typeof(ETag), ExpectedResult = "new global::Azure.ETag(element.GetString())")]
        [TestCase(typeof(AzureLocation), ExpectedResult = "new global::Azure.Core.AzureLocation(element.GetString())")]
        [TestCase(typeof(ResourceIdentifier), ExpectedResult = "new global::Azure.Core.ResourceIdentifier(element.GetString())")]
        public string ValidateDeserializationExpression(Type type)
        {
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsExpression().As<JsonElement>();

            var expression = AzureClientPlugin.Instance.TypeFactory.DeserializeJsonValue(type, element, SerializationFormat.Default);
            Assert.IsNotNull(expression);

            return expression.ToDisplayString();
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
