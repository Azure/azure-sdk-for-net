// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.StubLibrary
{
    internal class AzureStubVisitor : ScmLibraryVisitor
    {
        private readonly ValueExpression _throwNull = ThrowExpression(Null);
        private readonly XmlDocProvider _emptyDocs = new();

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (!type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) &&
                !type.Name.StartsWith("Unknown", StringComparison.Ordinal) &&
                !type.Name.Equals("MultiPartFormDataBinaryContent", StringComparison.Ordinal))
                return null;

            type.Update(xmlDocs: _emptyDocs);
            return type;
        }

        protected override TypeProvider? PostVisitType(TypeProvider type)
        {
            if (type is RestClientProvider &&
                type.Methods.Count == 0 &&
                type.Constructors.Count == 0 &&
                type.Properties.Count == 0 &&
                type.Fields.Count == 0)
            {
                return null;
            }

            return type;
        }

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            if (!IsCallingBaseCtor(constructor) &&
                !IsEffectivelyPublic(constructor.Signature.Modifiers) &&
                !IsParameterlessInternalCtorOnMrwSerializationType(constructor) &&
                (constructor.EnclosingType is not ModelProvider model || model.DerivedModels.Count == 0))
                return null;

            constructor.Update(
                bodyStatements: null,
                bodyExpression: _throwNull,
                xmlDocs: _emptyDocs);

            return constructor;
        }

        private static bool IsParameterlessInternalCtorOnMrwSerializationType(ConstructorProvider constructor)
        {
            if (constructor.Signature.Parameters.Count != 0)
                return false;

            if (!constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal))
                return false;

            return constructor.EnclosingType is MrwSerializationTypeDefinition;
        }

        private static bool IsCallingBaseCtor(ConstructorProvider constructor)
        {
            return constructor.Signature.Initializer is not null &&
                constructor.Signature.Initializer.IsBase &&
                constructor.Signature.Initializer.Arguments.Count > 0;
        }

        protected override FieldProvider? VisitField(FieldProvider field)
        {
            // For ClientOptions, keep the non-public field as this currently represents the latest service version for a client.
            return field.Modifiers.HasFlag(FieldModifiers.Public) || field.EnclosingType.BaseType?.Equals(typeof(ClientOptions)) == true
                ? field
                : null;
        }

        protected override MethodProvider? VisitMethod(MethodProvider method)
        {
            if (method.Signature.ExplicitInterface is null && !IsEffectivelyPublic(method.Signature.Modifiers))
                return null;

            method.Signature.Update(modifiers: method.Signature.Modifiers & ~MethodSignatureModifiers.Async);
            var docs = method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Implicit)
                ? method.XmlDocs
                : _emptyDocs;
            method.Update(
                bodyStatements: null,
                bodyExpression: _throwNull,
                xmlDocProvider: docs);

            return method;
        }

        protected override PropertyProvider? VisitProperty(PropertyProvider property)
        {
            if (!property.IsDiscriminator && !IsEffectivelyPublic(property.Modifiers))
                return null;

            var propertyBody = new ExpressionPropertyBody(_throwNull, property.Body.HasSetter ? _throwNull : null);

            property.Update(
                body: propertyBody,
                xmlDocs: _emptyDocs);

            return property;
        }

        private bool IsEffectivelyPublic(MethodSignatureModifiers modifiers)
        {
            if (modifiers.HasFlag(MethodSignatureModifiers.Public))
                return true;

            if (modifiers.HasFlag(MethodSignatureModifiers.Protected) && !modifiers.HasFlag(MethodSignatureModifiers.Private))
                return true;

            return false;
        }
    }
}
