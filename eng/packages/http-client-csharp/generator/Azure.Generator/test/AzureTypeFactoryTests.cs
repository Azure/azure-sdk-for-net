// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
            var value = new ParameterProvider("value", $"", type).AsVariable().As(type);
            var writer = new ParameterProvider("writer", $"", typeof(Utf8JsonWriter)).AsVariable().As<Utf8JsonWriter>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsVariable().As<ModelReaderWriterOptions>();

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
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsVariable().As<JsonElement>();
            var data = new ParameterProvider("data", $"", typeof(BinaryData)).AsVariable().As<BinaryData>();
            var expression = AzureClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                type,
                element,
                data,
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

        [Test]
        public void DataFactoryElementWithString()
        {
            // Create a union type with InputExternalType (DataFactoryElement) and InputPrimitiveType (string)
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var dfeExpression = InputFactory.Model("DfeExpression");
            var stringType = InputPrimitiveType.String;
            var unionType = InputFactory.Union("DfeString", [stringType, dfeExpression], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual!.IsGenericType);
            Assert.AreEqual(typeof(DataFactoryElement<>), actual.FrameworkType.GetGenericTypeDefinition());
            Assert.AreEqual(typeof(string), actual.Arguments[0].FrameworkType);
        }

        [Test]
        public void DataFactoryElementWithInt()
        {
            // Create a union type with InputExternalType (DataFactoryElement) and InputPrimitiveType (int)
            var intType = InputPrimitiveType.Int32;
            var dfeExpression = InputFactory.Model("DfeExpression");
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var unionType = InputFactory.Union("DfeInt", [intType, dfeExpression], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual!.IsGenericType);
            Assert.AreEqual(typeof(DataFactoryElement<>), actual.FrameworkType.GetGenericTypeDefinition());
            Assert.AreEqual(typeof(int), actual.Arguments[0].FrameworkType);
        }

        [Test]
        public void DataFactoryElementWithBool()
        {
            // Create a union type with InputExternalType (DataFactoryElement) and InputPrimitiveType (bool)
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var dfeExpression = InputFactory.Model("DfeExpression");
            var boolType = InputPrimitiveType.Boolean;
            var unionType = InputFactory.Union("DfeBool", [boolType, dfeExpression], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual!.IsGenericType);
            Assert.AreEqual(typeof(DataFactoryElement<>), actual.FrameworkType.GetGenericTypeDefinition());
            Assert.AreEqual(typeof(bool), actual.Arguments[0].FrameworkType);
        }

        [Test]
        public void DataFactoryElementWithArray()
        {
            // Create a union type with InputExternalType (DataFactoryElement) and InputArrayType (string[])
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var dfeExpression = InputFactory.Model("DfeExpression");
            var arrayType = InputFactory.Array(InputPrimitiveType.String);
            var unionType = InputFactory.Union("DfeStringArray", [arrayType, dfeExpression], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual!.IsGenericType);
            Assert.AreEqual(typeof(DataFactoryElement<>), actual.FrameworkType.GetGenericTypeDefinition());
            // The inner type should be IList<string>
            Assert.IsTrue(actual.Arguments[0].IsGenericType);
        }

        [Test]
        public void DataFactoryElementNotAppliedForNonDataFactoryExternalType()
        {
            // Create a union type with a different external type (not DataFactoryElement)
            var externalType = new InputExternalTypeMetadata("System.IO.File", null, null);
            var stringType = InputPrimitiveType.String;
            var unionType = InputFactory.Union("OtherUnion", [stringType], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            // Should fall back to default behavior, not create a DataFactoryElement
            Assert.IsTrue(actual!.Equals(typeof(File)));
        }

        [Test]
        public void DataFactoryElementWithModel()
        {
            // Create a union type with InputExternalType (DataFactoryElement) and InputModelType
            var externalType = new InputExternalTypeMetadata("Azure.Core.Expressions.DataFactoryElement", null, null);
            var dfeExpression = InputFactory.Model("DfeExpression");
            var modelType = InputFactory.Model("TestModel");
            var unionType = InputFactory.Union("DfeModel", [modelType, dfeExpression], externalType);

            var actual = AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(unionType);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual!.IsGenericType);
            Assert.AreEqual(typeof(DataFactoryElement<>), actual.FrameworkType.GetGenericTypeDefinition());
            // The inner type should be the model type
            Assert.AreEqual("TestModel", actual.Arguments[0].Name);
        }

        [Test]
        public void DataFactoryElementSerializationUsesWriteObjectValue()
        {
            // Verify that DataFactoryElement<string> uses WriteObjectValue for serialization
            // which internally leverages IJsonModel
            var type = typeof(DataFactoryElement<string>);
            var value = new ParameterProvider("value", $"", type).AsVariable().As(type);
            var writer = new ParameterProvider("writer", $"", typeof(Utf8JsonWriter)).AsVariable().As<Utf8JsonWriter>();
            var options = new ParameterProvider("options", $"", typeof(ModelReaderWriterOptions)).AsVariable().As<ModelReaderWriterOptions>();

            var statement = AzureClientGenerator.Instance.TypeFactory.SerializeJsonValue(type, value, writer, options, SerializationFormat.Default);
            Assert.IsNotNull(statement);

            var displayString = statement.ToDisplayString();
            // Should use WriteObjectValue pattern which internally uses IJsonModel
            Assert.IsTrue(
                displayString.Contains("WriteObjectValue") && displayString.Contains("DataFactoryElement"),
                $"Expected serialization to use WriteObjectValue pattern for DataFactoryElement, but got: {displayString}");
        }

        [Test]
        public void DataFactoryElementDeserializationUsesDeserializeMethod()
        {
            // Verify that DataFactoryElement<string> uses its deserialize method
            var type = typeof(DataFactoryElement<string>);
            var element = new ParameterProvider("element", $"", typeof(JsonElement)).AsVariable().As<JsonElement>();
            var data = new ParameterProvider("data", $"", typeof(BinaryData)).AsVariable().As<BinaryData>();
            var expression = AzureClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                type,
                element,
                data,
                new ScopedApi<ModelReaderWriterOptions>(new VariableExpression(typeof(ModelReaderWriterOptions), "options")),
                SerializationFormat.Default);
            Assert.IsNotNull(expression);

            var displayString = expression.ToDisplayString();
            Assert.AreEqual(
                "global::System.ClientModel.Primitives.ModelReaderWriter.Read<global::Azure.Core.Expressions.DataFactory.DataFactoryElement<string>>(data, global::Samples.ModelSerializationExtensions.WireOptions, global::Samples.SamplesContext.Default)",
                displayString);
        }
    }
}
