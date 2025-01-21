// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.StubLibrary
{
    internal class AzureStubVisitor : ScmLibraryVisitor
    {
        private readonly ValueExpression _throwNull = ThrowExpression(Null);

        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (!type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) &&
                !type.Name.StartsWith("Unknown", StringComparison.Ordinal) &&
                !type.Name.Equals("MultiPartFormDataBinaryContent", StringComparison.Ordinal))
                return null;

            return type;
        }

        protected override TypeProvider? PostVisit(TypeProvider type)
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

        protected override ConstructorProvider? Visit(ConstructorProvider constructor)
        {
            if (!IsCallingBaseCtor(constructor) &&
                !IsEffectivelyPublic(constructor.Signature.Modifiers) &&
                (constructor.EnclosingType is not ModelProvider model || model.DerivedModels.Count == 0))
                return null;

            constructor.Update(
                bodyStatements: null,
                bodyExpression: _throwNull);

            return constructor;
        }

        private static bool IsCallingBaseCtor(ConstructorProvider constructor)
        {
            return constructor.Signature.Initializer is not null &&
                constructor.Signature.Initializer.IsBase &&
                constructor.Signature.Initializer.Arguments.Count > 0;
        }

        protected override FieldProvider? Visit(FieldProvider field)
        {
            // For ClientOptions, keep the non-public field as this currently represents the latest service version for a client.
            return (field.Modifiers.HasFlag(FieldModifiers.Public) || field.EnclosingType.Implements.Any(i => i.Equals(typeof(ClientPipelineOptions))))
                ? field
                : null;
        }

        protected override MethodProvider? Visit(MethodProvider method)
        {
            if (method.Signature.ExplicitInterface is null && !IsEffectivelyPublic(method.Signature.Modifiers))
                return null;

            method.Signature.Update(modifiers: method.Signature.Modifiers & ~MethodSignatureModifiers.Async);

            method.Update(
                bodyStatements: null,
                bodyExpression: _throwNull);

            return method;
        }

        protected override PropertyProvider? Visit(PropertyProvider property)
        {
            if (!property.IsDiscriminator && !IsEffectivelyPublic(property.Modifiers))
                return null;

            var propertyBody = new ExpressionPropertyBody(_throwNull, property.Body.HasSetter ? _throwNull : null);

            property.Update(
                body: propertyBody);

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
