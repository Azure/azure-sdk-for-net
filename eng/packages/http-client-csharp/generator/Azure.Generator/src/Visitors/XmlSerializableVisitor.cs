// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Snippets;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that adds <see cref="IXmlSerializable"/> interface implementation to models that support XML serialization.
    /// </summary>
    /// <remarks>
    /// This visitor performs the following modifications:
    /// <list type="number">
    ///   <item>
    ///     <description>
    ///       For models with <see cref="InputModelTypeUsage.Xml"/> usage, adds the <see cref="IXmlSerializable"/> interface
    ///       and implements the explicit <c>void IXmlSerializable.Write(XmlWriter writer, string nameHint)</c> method.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       Updates the <c>WriteObjectValue</c> extension method in <see cref="ModelSerializationExtensionsDefinition"/>
    ///       to add a case for <see cref="IXmlSerializable"/> in the switch statement.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       For models that ONLY support XML serialization (not JSON), updates the implicit <c>RequestContent</c> operator
    ///       to use <see cref="XmlWriterContent"/>.
    ///     </description>
    ///   </item>
    /// </list>
    /// </remarks>
    internal class XmlSerializableVisitor : ScmLibraryVisitor
    {
        private const string IXmlSerializableWriteMethodName = nameof(IXmlSerializable.Write);
        private const string WriteMethodName = "WriteXml";
        private const string WriteObjectValueMethodName = "WriteObjectValue";
        private static readonly CSharpType IXmlSerializableType = typeof(IXmlSerializable);
        private static readonly CSharpType RequestContentType = typeof(RequestContent);
        private readonly Dictionary<TypeProvider, InputModelType> _xmlSerializationProviders = [];

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (model.Usage.HasFlag(InputModelTypeUsage.Xml) && type is not null)
            {
                foreach (var serializationProvider in type.SerializationProviders)
                {
                    _xmlSerializationProviders.TryAdd(serializationProvider, model);
                }
            }

            return type;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is MrwSerializationTypeDefinition serializationProvider)
            {
                if (_xmlSerializationProviders.TryGetValue(serializationProvider, out var inputModel))
                {
                    AddIXmlSerializableImplementation(serializationProvider);

                    string? xmlElementName = inputModel.SerializationOptions?.Xml?.Name;
                    if (inputModel.Usage.HasFlag(InputModelTypeUsage.Json))
                    {
                        UpdateImplicitRequestContentOperatorForJsonAndXml(serializationProvider);
                    }
                    else if (xmlElementName is not null)
                    {
                        UpdateImplicitRequestContentOperatorForXmlOnly(serializationProvider, xmlElementName);
                    }
                }
            }
            else if (type is ModelSerializationExtensionsDefinition modelSerializationExtensions)
            {
                UpdateWriteObjectValueMethod(modelSerializationExtensions);
            }

            return type;
        }

        private static void AddIXmlSerializableImplementation(TypeProvider serializationProvider)
        {
            var writerParameter = new ParameterProvider("writer", $"The XML writer.", typeof(XmlWriter));
            var nameHintParameter = new ParameterProvider("nameHint", $"An optional name hint.", new CSharpType(typeof(string)));

            var methodSignature = new MethodSignature(
                IXmlSerializableWriteMethodName,
                null,
                MethodSignatureModifiers.None,
                null,
                null,
                [writerParameter, nameHintParameter],
                ExplicitInterface: IXmlSerializableType);

            var bodyExpression = This.Invoke(
                WriteMethodName,
                [writerParameter, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions"), nameHintParameter]);

            var ixmlSerializableWriteMethod = new MethodProvider(methodSignature, bodyExpression, serializationProvider);

            // Update the serialization provider with the new interface and method
            var updatedImplements = new List<CSharpType>(serializationProvider.Implements) { IXmlSerializableType };
            serializationProvider.Update(
                implements: updatedImplements,
                methods: [.. serializationProvider.Methods, ixmlSerializableWriteMethod]);
        }

        private static void UpdateWriteObjectValueMethod(ModelSerializationExtensionsDefinition type)
        {
            var writeObjectValueMethod = type.Methods
                .FirstOrDefault(m => m.Signature.Name == WriteObjectValueMethodName &&
                                    m.Signature.Parameters.Count >= 2 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(XmlWriter)));

            if (writeObjectValueMethod is null)
            {
                return;
            }

            var existingBody = writeObjectValueMethod.BodyStatements;
            if (existingBody is null)
            {
                return;
            }

            // Add nameHint parameter to the method signature
            var nameHintParam = new ParameterProvider(
                "nameHint",
                $"An optional name hint.",
                new CSharpType(typeof(string),
                isNullable: true),
                DefaultOf(new CSharpType(typeof(string),
                isNullable: true)));
            var updatedParams = new List<ParameterProvider>(writeObjectValueMethod.Signature.Parameters) { nameHintParam };
            writeObjectValueMethod.Signature.Update(parameters: updatedParams);

            var writerParam = writeObjectValueMethod.Signature.Parameters[0];
            var caseMatch = new DeclarationExpression(IXmlSerializableType, "xmlSerializable", out var xmlSerializableVar);
            var caseBody = new MethodBodyStatements(
            [
                xmlSerializableVar.Invoke(IXmlSerializableWriteMethodName, [writerParam, nameHintParam]).Terminate(),
                Break
            ]);
            var ixmlSerializableCase = new SwitchCaseStatement(
                caseMatch,
                caseBody);

            List<MethodBodyStatement> newBodyStatements = [];
            bool caseAdded = false;

            // Handle different body statement structures
            IEnumerable<MethodBodyStatement> statements = existingBody switch
            {
                MethodBodyStatements methodBodyStatements => methodBodyStatements.Statements,
                _ => [existingBody]
            };

            foreach (var statement in statements)
            {
                if (statement is SwitchStatement switchStatement && !caseAdded)
                {
                    var newCases = new List<SwitchCaseStatement> { ixmlSerializableCase };
                    newCases.AddRange(switchStatement.Cases);

                    var newSwitchStatement = new SwitchStatement(switchStatement.MatchExpression, [.. newCases]);
                    newBodyStatements.Add(newSwitchStatement);
                    caseAdded = true;
                }
                else
                {
                    newBodyStatements.Add(statement);
                }
            }

            if (caseAdded)
            {
                writeObjectValueMethod.Update(bodyStatements: newBodyStatements);
            }
        }

        private static void UpdateImplicitRequestContentOperatorForXmlOnly(TypeProvider serializationProvider, string xmlElementName)
        {
            var implicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(RequestContentType) == true &&
                                    m.Signature.Parameters.Count == 1);

            if (implicitOperator is null)
            {
                return;
            }

            var modelParameter = implicitOperator.Signature.Parameters[0];

            // Build new method body:
            // if (model == null) { return null; }
            // var content = new XmlWriterContent();
            // content.XmlWriter.WriteObjectValue(model, ModelSerializationExtensions.WireOptions, "XmlElementName");
            // return content;
            var newBody = new MethodBodyStatements(
            [
                new IfStatement(modelParameter.Equal(Null))
                {
                    Return(Null)
                },
                Declare("content", typeof(XmlWriterContent), New.Instance(typeof(XmlWriterContent)), out var contentVar),
                contentVar.As<XmlWriterContent>().XmlWriter().Invoke(
                    WriteObjectValueMethodName,
                    [modelParameter, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions"), Literal(xmlElementName)]).Terminate(),
                Return(contentVar)
            ]);

            implicitOperator.Update(bodyStatements: newBody);
        }

        private static void UpdateImplicitRequestContentOperatorForJsonAndXml(TypeProvider serializationProvider)
        {
            // Find the implicit operator RequestContent method
            var implicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit) &&
                                    m.Signature.ReturnType?.Equals(RequestContentType) == true &&
                                    m.Signature.Parameters.Count == 1);

            if (implicitOperator is null)
            {
                return;
            }

            var modelParameter = implicitOperator.Signature.Parameters[0];
            var modelSerializationExtensions = Static<ModelSerializationExtensionsDefinition>();

            var newBody = new MethodBodyStatements(
            [
                new IfStatement(modelParameter.Equal(Null))
                {
                    Return(Null)
                },
                Return(Static(RequestContentType).Invoke(nameof(RequestContent.Create), [modelParameter, modelSerializationExtensions.Property("WireOptions")]))
            ]);

            implicitOperator.Update(bodyStatements: newBody);
        }
    }
}
