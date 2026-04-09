// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Providers;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
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
        private const string ToRequestContentMethodName = "ToRequestContent";
        private const string NameHintParameterName = "nameHint";
        private const string FromEnumerableMethodName = "FromEnumerable";
        private static readonly CSharpType IXmlSerializableType = typeof(IXmlSerializable);
        private static readonly CSharpType RequestContentType = typeof(RequestContent);
        private static readonly CSharpType ModelReaderWriterOptionsType = typeof(ModelReaderWriterOptions);
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
                        if (xmlElementName is not null)
                        {
                            UpdateToRequestContentMethod(serializationProvider, xmlElementName);
                        }
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
            else if (type is BinaryContentHelperDefinition)
            {
                UpdateFromEnumerableMethod(type);
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

            ParameterProvider? nameHintParam = writeObjectValueMethod.Signature.Parameters.FirstOrDefault(p => p.Name == NameHintParameterName);
            if (nameHintParam is null)
            {
                return;
            }

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

        private static void UpdateFromEnumerableMethod(TypeProvider type)
        {
            // Find the existing FromEnumerable<T> method with 3 parameters (enumerable, rootNameHint, childNameHint)
            var fromEnumerableMethod = type.Methods
                .FirstOrDefault(m => m.Signature.Name == FromEnumerableMethodName &&
                                    m.Signature.GenericArguments?.Count == 1 &&
                                    m.Signature.Parameters.Count == 3 &&
                                    m.Signature.Parameters[0].Name == "enumerable" &&
                                    m.Signature.Parameters[1].Name == "rootNameHint" &&
                                    m.Signature.Parameters[2].Name == "childNameHint");

            if (fromEnumerableMethod is null)
            {
                return;
            }

            var enumerableParameter = fromEnumerableMethod.Signature.Parameters[0];
            var rootNameHintParameter = fromEnumerableMethod.Signature.Parameters[1];
            var childNameHintParameter = fromEnumerableMethod.Signature.Parameters[2];

            var body = new MethodBodyStatements(
            [
                Declare("content", typeof(XmlWriterContent), New.Instance(typeof(XmlWriterContent)), out var content),
                content.As<XmlWriterContent>().XmlWriter().Invoke(nameof(XmlWriter.WriteStartElement), [rootNameHintParameter]).Terminate(),
                new ForEachStatement("item", enumerableParameter.As(enumerableParameter.Type), out var itemVariable)
                {
                    content.As<XmlWriterContent>().XmlWriter().Invoke(WriteObjectValueMethodName, [itemVariable, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions"), childNameHintParameter]).Terminate()
                },
                content.As<XmlWriterContent>().XmlWriter().Invoke(nameof(XmlWriter.WriteEndElement), []).Terminate(),
                Return(content)
            ]);

            fromEnumerableMethod.Update(bodyStatements: body);
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
                .. RequestContentProvider.CreateXml(modelParameter, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions"), xmlElementName)
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

        private static void UpdateToRequestContentMethod(TypeProvider serializationProvider, string xmlElementName)
        {
            // Find the ToRequestContent(string format) method
            var toRequestContentMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == ToRequestContentMethodName &&
                                    m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                                    m.Signature.ReturnType?.Equals(RequestContentType) == true &&
                                    m.Signature.Parameters.Count == 1 &&
                                    m.Signature.Parameters[0].Type.Equals(typeof(string)));

            if (toRequestContentMethod is null)
            {
                return;
            }

            var formatParameter = toRequestContentMethod.Signature.Parameters[0];
            var newBody = new MethodBodyStatements(
            [
                Declare("options", ModelReaderWriterOptionsType, New.Instance(ModelReaderWriterOptionsType, formatParameter), out var optionsVar),
                new SwitchStatement(formatParameter,
                [
                    // case "X":
                    new SwitchCaseStatement(Literal("X"), new MethodBodyStatements(RequestContentProvider.CreateXml(This, optionsVar, xmlElementName))),
                    // case "J":
                    new SwitchCaseStatement(Literal("J"), new MethodBodyStatements(RequestContentProvider.Create(This, optionsVar))),
                    // default:
                    SwitchCaseStatement.Default(new MethodBodyStatements(
                    [
                        Return(Static(RequestContentType).Invoke(nameof(RequestContent.Create), [This, optionsVar]))
                    ]))
                ])
            ]);

            toRequestContentMethod.Update(bodyStatements: newBody);
        }
    }
}