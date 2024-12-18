// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using NUnit.Framework;
using System;
using System.Buffers;
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
        public void ValidateSerialization(Type type)
        {
            var declaration = new CodeWriterDeclaration("value");
            var value = new VariableExpression(type, declaration);
            var writerDeclaration = new CodeWriterDeclaration("writer");
            var writer = new VariableExpression(typeof(Utf8JsonWriter), writerDeclaration);

            var statement = AzureClientPlugin.Instance.TypeFactory.SerializeValueType(type, SerializationFormat.Default, value, type, writer.As<Utf8JsonWriter>(), null!);
            Assert.IsNotNull(statement);

            var expected = Helpers.GetExpectedFromFile(type.ToString());
            Assert.AreEqual(expected, statement.ToDisplayString());
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
