// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Linq;
using System.Xml;

namespace Azure.Generator.Tests.Visitors
{
    public class XmlSerializableVisitorTests
    {
        [Test]
        public void AddsIXmlSerializableInterfaceWhenXmlUsagePresent()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);
            visitor.InvokePreVisitModel(inputModel, modelProvider);

            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var ixmlSerializableInterface = serializationProvider.Implements
                .FirstOrDefault(i => i.Name == nameof(IXmlSerializable));
            Assert.IsNotNull(ixmlSerializableInterface, "IXmlSerializable interface should be added");
        }

        [Test]
        public void DoesNotAddIXmlSerializableWhenXmlUsageAbsent()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestJsonModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);

            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var ixmlSerializableInterface = serializationProvider.Implements
                .FirstOrDefault(i => i.Name == nameof(IXmlSerializable));
            Assert.IsNull(ixmlSerializableInterface, "IXmlSerializable interface should not be added without Xml usage");
        }

        [Test]
        public void AddsWriteMethodWithCorrectSignature()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var writeMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "Write" &&
                                    m.Signature.ExplicitInterface?.Name == nameof(IXmlSerializable));
            Assert.IsNotNull(writeMethod, "IXmlSerializable.Write method should be added");
            Assert.AreEqual(2, writeMethod!.Signature.Parameters.Count, "Write method should have 2 parameters");
            Assert.AreEqual("writer", writeMethod.Signature.Parameters[0].Name);
            Assert.AreEqual("nameHint", writeMethod.Signature.Parameters[1].Name);
            Assert.IsNotNull(writeMethod.BodyExpression, "Write method should have expression body");
        }

        [Test]
        public void WriteMethodHasCorrectBody()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var writeMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "Write" &&
                                    m.Signature.ExplicitInterface?.Name == nameof(IXmlSerializable));
            Assert.IsNotNull(writeMethod);

            var bodyExpression = writeMethod!.BodyExpression!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), bodyExpression);
        }

        [Test]
        public void MultipleXmlModelsAllGetInterface()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel1 = InputFactory.Model(
                "XmlModel1",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            var inputModel2 = InputFactory.Model(
                "XmlModel2",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            var inputModel3 = InputFactory.Model(
                "JsonModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel1, inputModel2, inputModel3]);

            var modelProvider1 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel1);
            var modelProvider2 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel2);
            var modelProvider3 = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel3);

            visitor.InvokePreVisitModel(inputModel1, modelProvider1);
            visitor.InvokePreVisitModel(inputModel2, modelProvider2);
            visitor.InvokePreVisitModel(inputModel3, modelProvider3);

            var serialization1 = modelProvider1!.SerializationProviders[0];
            var serialization2 = modelProvider2!.SerializationProviders[0];
            var serialization3 = modelProvider3!.SerializationProviders[0];

            visitor.InvokeVisitType(serialization1);
            visitor.InvokeVisitType(serialization2);
            visitor.InvokeVisitType(serialization3);

            Assert.IsTrue(serialization1.Implements.Any(i => i.Name == nameof(IXmlSerializable)),
                "XmlModel1 should implement IXmlSerializable");
            Assert.IsTrue(serialization2.Implements.Any(i => i.Name == nameof(IXmlSerializable)),
                "XmlModel2 should implement IXmlSerializable");
            Assert.IsFalse(serialization3.Implements.Any(i => i.Name == nameof(IXmlSerializable)),
                "JsonModel should NOT implement IXmlSerializable");
        }

        [Test]
        public void AddsIXmlSerializableWhenModelHasBothXmlAndJsonUsage()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "DualFormatModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml | InputModelTypeUsage.Json);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var ixmlSerializableInterface = serializationProvider.Implements
                .FirstOrDefault(i => i.Name == nameof(IXmlSerializable));
            Assert.IsNotNull(ixmlSerializableInterface, "IXmlSerializable interface should be added for models with both Xml and Json usage");

            var writeMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "Write" &&
                                    m.Signature.ExplicitInterface?.Name == nameof(IXmlSerializable));
            Assert.IsNotNull(writeMethod, "IXmlSerializable.Write method should be added");
        }

        [Test]
        public void UpdatesWriteObjectValueMethodWithIXmlSerializableCase()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelSerializationExtensions = new ModelSerializationExtensionsDefinition();

            var writeObjectValueMethod = modelSerializationExtensions.Methods
                .FirstOrDefault(m => m.Signature.Name == "WriteObjectValue" &&
                                    m.Signature.Parameters.Count >= 2 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(XmlWriter)));
            Assert.IsNotNull(writeObjectValueMethod, "WriteObjectValue method for XmlWriter should exist");

            var bodyBefore = writeObjectValueMethod!.BodyStatements;
            Assert.IsNotNull(bodyBefore);

            visitor.InvokeVisitType(modelSerializationExtensions);

            var bodyAfter = writeObjectValueMethod.BodyStatements;
            Assert.IsNotNull(bodyAfter);

            var hasIXmlSerializableCase = ContainsIXmlSerializableCase(bodyAfter!);
            Assert.IsTrue(hasIXmlSerializableCase, "WriteObjectValue should have IXmlSerializable case after visitor");
        }

        [Test]
        public void WriteObjectValueIXmlSerializableCaseIsFirstInSwitch()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelSerializationExtensions = new ModelSerializationExtensionsDefinition();

            visitor.InvokeVisitType(modelSerializationExtensions);

            var writeObjectValueMethod = modelSerializationExtensions.Methods
                .FirstOrDefault(m => m.Signature.Name == "WriteObjectValue" &&
                                    m.Signature.Parameters.Count >= 2 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(XmlWriter)));
            Assert.IsNotNull(writeObjectValueMethod, "WriteObjectValue method for XmlWriter should exist");

            var body = writeObjectValueMethod!.BodyStatements;
            Assert.IsNotNull(body);

            var switchStatement = GetSwitchStatement(body!);
            Assert.IsNotNull(switchStatement, "Should have a switch statement");

            var cases = switchStatement!.Cases.ToList();
            Assert.IsTrue(cases.Count > 0, "Switch should have cases");

            var bodyString = body!.ToDisplayString();
            var ixmlSerializableIndex = bodyString.IndexOf("IXmlSerializable");
            var iPersistableModelIndex = bodyString.IndexOf("IPersistableModel");

            Assert.IsTrue(ixmlSerializableIndex >= 0, "Should contain IXmlSerializable case");
            Assert.IsTrue(iPersistableModelIndex >= 0, "Should contain IPersistableModel case");
            Assert.IsTrue(ixmlSerializableIndex < iPersistableModelIndex,
                "IXmlSerializable case should come before IPersistableModel case");
        }

        [Test]
        public void WriteObjectValueMethod_HasNameHintParameter()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "TestXmlModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelSerializationExtensions = new ModelSerializationExtensionsDefinition();

            var writeObjectValueMethod = modelSerializationExtensions.Methods
                .FirstOrDefault(m => m.Signature.Name == "WriteObjectValue" &&
                                    m.Signature.Parameters.Count >= 2 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(XmlWriter)));
            Assert.IsNotNull(writeObjectValueMethod, "WriteObjectValue method for XmlWriter should exist");

            var initialParamCount = writeObjectValueMethod!.Signature.Parameters.Count;

            visitor.InvokeVisitType(modelSerializationExtensions);

            Assert.AreEqual(initialParamCount + 1, writeObjectValueMethod.Signature.Parameters.Count,
                "nameHint parameter should be added");

            var nameHintParam = writeObjectValueMethod.Signature.Parameters.LastOrDefault();
            Assert.IsNotNull(nameHintParam);
            Assert.AreEqual("nameHint", nameHintParam!.Name);
            Assert.IsTrue(nameHintParam.Type.IsNullable, "nameHint should be nullable");
            Assert.AreEqual(typeof(string), nameHintParam.Type.FrameworkType);
        }

        [Test]
        public void JsonOnlyModel_DoesNotChangeImplicitOperator()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "JsonOnlyModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            var serializationProvider = modelProvider!.SerializationProviders[0];

            var implicitOperatorBefore = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            var bodyBefore = implicitOperatorBefore?.BodyStatements?.ToDisplayString();

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            visitor.InvokeVisitType(serializationProvider);

            var implicitOperatorAfter = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            var bodyAfter = implicitOperatorAfter?.BodyStatements?.ToDisplayString();

            Assert.AreEqual(bodyBefore, bodyAfter,
                "JSON-only model implicit operator should not be modified by the visitor");
        }

        [Test]
        public void JsonAndXmlModel_ImplicitOperatorUsesRequestContentCreate()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "DualFormatModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml | InputModelTypeUsage.Json);
            var bodyParam = InputFactory.BodyParameter("body", inputModel);
            var methodParam = InputFactory.MethodParameter("body", inputModel);
            var operation = InputFactory.Operation("testOp", parameters: [bodyParam]);
            var serviceMethod = InputFactory.BasicServiceMethod("testOp", operation, parameters: [methodParam]);
            var client = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var implicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            Assert.IsNotNull(implicitOperator, "Implicit RequestContent operator should be generated");

            var bodyString = implicitOperator!.BodyStatements?.ToDisplayString();
            Assert.IsNotNull(bodyString);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), bodyString);
        }

        [Test]
        public void XmlOnlyModel_ImplicitOperatorUsesXmlWriterContent()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "XmlOnlyModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml,
                serializationOptions: new InputSerializationOptions(
                    json: null,
                    xml: new InputXmlSerializationOptions("TestElement", false, null)));
            var bodyParam = InputFactory.BodyParameter("body", inputModel);
            var methodParam = InputFactory.MethodParameter("body", inputModel);
            var operation = InputFactory.Operation("testOp", parameters: [bodyParam]);
            var serviceMethod = InputFactory.BasicServiceMethod("testOp", operation, parameters: [methodParam]);
            var client = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var implicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            Assert.IsNotNull(implicitOperator, "Implicit RequestContent operator should be generated");

            var bodyString = implicitOperator!.BodyStatements?.ToDisplayString();
            Assert.IsNotNull(bodyString);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), bodyString);
        }

        [Test]
        public void XmlOnlyModel_WithoutElementName_DoesNotChangeImplicitOperator()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "XmlOnlyModelNoElementName",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            var serializationProvider = modelProvider!.SerializationProviders[0];

            var implicitOperatorBefore = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            var bodyBefore = implicitOperatorBefore?.BodyStatements?.ToDisplayString();

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            visitor.InvokeVisitType(serializationProvider);

            var implicitOperatorAfter = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true);
            var bodyAfter = implicitOperatorAfter?.BodyStatements?.ToDisplayString();

            Assert.AreEqual(bodyBefore, bodyAfter,
                "XML-only model without element name should not have operator modified");
        }

        [Test]
        public void JsonAndXmlModel_ToRequestContentMethodUpdatedWithSwitch()
        {
            var visitor = new TestXmlSerializableVisitor();
            var inputModel = InputFactory.Model(
                "DualFormatModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Xml | InputModelTypeUsage.Json,
                serializationOptions: new InputSerializationOptions(
                    json: null,
                    xml: new InputXmlSerializationOptions("TestElement", false, null)));
            var bodyParam = InputFactory.BodyParameter("body", inputModel);
            var methodParam = InputFactory.MethodParameter("body", inputModel);
            var operation = InputFactory.Operation("testOp", parameters: [bodyParam]);
            var serviceMethod = InputFactory.BasicServiceMethod("testOp", operation, parameters: [methodParam]);
            var client = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var modelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            Assert.IsNotNull(modelProvider);

            visitor.InvokePreVisitModel(inputModel, modelProvider);
            var serializationProvider = modelProvider!.SerializationProviders[0];
            visitor.InvokeVisitType(serializationProvider);

            var toRequestContentMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "ToRequestContent" &&
                                    m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                                    m.Signature.ReturnType?.Equals(typeof(RequestContent)) == true &&
                                    m.Signature.Parameters.Count == 1 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(string)));
            Assert.IsNotNull(toRequestContentMethod, "ToRequestContent method should exist");

            var bodyString = toRequestContentMethod!.BodyStatements?.ToDisplayString();
            Assert.IsNotNull(bodyString);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), bodyString);
        }

        private static bool ContainsIXmlSerializableCase(MethodBodyStatement body)
        {
            return body.ToDisplayString().Contains(nameof(IXmlSerializable));
        }

        private static SwitchStatement? GetSwitchStatement(MethodBodyStatement body)
        {
            if (body is MethodBodyStatements statements)
            {
                foreach (var statement in statements.Statements)
                {
                    if (statement is SwitchStatement switchStatement)
                    {
                        return switchStatement;
                    }
                }
            }
            else if (body is SwitchStatement switchStatement)
            {
                return switchStatement;
            }

            return null;
        }

        private class TestXmlSerializableVisitor : XmlSerializableVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }

            public TypeProvider? InvokeVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }
        }
    }
}
