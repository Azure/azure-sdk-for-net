// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    public class KnownManagementDeserializationTests
    {
        [TestCase(typeof(SystemData))]
        [TestCase(typeof(OperationStatusResult))]
        [TestCase(typeof(ManagedServiceIdentity))]
        public void KnownModelReadsElementBytesRatherThanDocumentData(Type type)
        {
            var factory = ManagementMockHelpers.LoadMockPlugin().Object.TypeFactory;
            var expression = factory.DeserializeJsonValue(
                type,
                new VariableExpression(typeof(JsonElement), "property.Value").As<JsonElement>(),
                new VariableExpression(typeof(BinaryData), "documentData").As<BinaryData>(),
                new VariableExpression(typeof(ModelReaderWriterOptions), "options").As<ModelReaderWriterOptions>(),
                SerializationFormat.Default).ToDisplayString();

            Assert.Multiple(() =>
            {
                Assert.That(expression, Does.Contain("property.Value.GetUtf8Bytes()"));
                Assert.That(expression, Does.Not.Contain("documentData"));
                Assert.That(expression, Does.Not.Contain("GetRawText"));
                Assert.That(expression, Does.Contain("ModelSerializationExtensions.WireOptions"));
                Assert.That(expression, Does.Contain("Context.Default"));
            });
        }

        [Test]
        public void ManagedServiceIdentityRetainsV3FormatOptions()
        {
            var values = new List<InputEnumTypeValue>();
            var identityType = new InputEnumType(
                "ManagedServiceIdentityType", "Azure.ResourceManager.Models",
                "Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType",
                "public", null, "", "", InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String, values, true);
            values.Add(InputFactory.EnumMember.String("SystemAssignedUserAssigned", "SystemAssigned,UserAssigned", identityType));
            var factory = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [identityType]).Object.TypeFactory;
            var expression = factory.DeserializeJsonValue(
                typeof(ManagedServiceIdentity),
                new VariableExpression(typeof(JsonElement), "element").As<JsonElement>(),
                new VariableExpression(typeof(BinaryData), "documentData").As<BinaryData>(),
                new VariableExpression(typeof(ModelReaderWriterOptions), "options").As<ModelReaderWriterOptions>(),
                SerializationFormat.Default).ToDisplayString();

            Assert.Multiple(() =>
            {
                Assert.That(expression, Does.Contain("element.GetUtf8Bytes()"));
                Assert.That(expression, Does.Contain("options.Format == \"W\""));
                Assert.That(expression, Does.Contain("ModelSerializationExtensions.WireV3Options"));
                Assert.That(expression, Does.Contain("ModelSerializationExtensions.JsonV3Options"));
                Assert.That(expression, Does.Contain("Context.Default"));
            });
        }
    }
}
