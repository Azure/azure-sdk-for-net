// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that adds <see cref="ExperimentalAttribute"/> to generated public types that are not
    /// present in the stable-types baseline. This ensures that newly introduced generated types are
    /// automatically tagged as experimental until explicitly promoted.
    /// </summary>
    /// <remarks>
    /// This visitor mirrors the pattern established by the upstream OpenAI library's codegen plugin
    /// (ExperimentalAttributeVisitor), adapted for Azure.AI.Extensions.OpenAI conventions.
    /// </remarks>
    public class ExperimentalAttributeVisitor : ScmLibraryVisitor
    {
        private const string DiagnosticId = "AAIP001";

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);
        private readonly HashSet<string> _methodIDs = new(StringComparer.Ordinal);

        private static bool IsExternal(TypeSignatureModifiers modifiers) => modifiers.HasFlag(TypeSignatureModifiers.Public) || modifiers.HasFlag(TypeSignatureModifiers.Protected);
        private static bool IsExternal(MethodSignatureModifiers modifiers) => modifiers.HasFlag(MethodSignatureModifiers.Public) || modifiers.HasFlag(MethodSignatureModifiers.Protected);

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            if (IsExternal(type.DeclarationModifiers)
                && !SupportedPackages.IsStable(type.Type.FullyQualifiedName)
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }

            return base.VisitType(type);
        }

        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            // Do not mark internal methods as experimental.
            if (!IsExternal(method.Signature.Modifiers)
                || method.Signature.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                )
            {
                return base.VisitMethod(method);
            }

            // If enclising type is not stable, no need to mark its methods.
            string enclosingObjectId = method.EnclosingType.Type.FullyQualifiedName;
            if (!SupportedPackages.IsStable(enclosingObjectId))
            {
                return base.VisitMethod(method);
            }
            string methodId = method.Signature.Parameters
                .Select(x => x.Type.FullyQualifiedName)
                .Aggregate($"{enclosingObjectId}.{method.Signature.Name}->", (x, next) => string.Join(',', [x, next]));

            // If method takes in or return experimental class, mark it as experimental.
            if ((!SupportedPackages.IsStable(method.Signature.ReturnType?.FullyQualifiedName)
                || method.Signature.Parameters.Any(x => !SupportedPackages.IsStable(x.Type.FullyQualifiedName)))
                && _methodIDs.Add(methodId)
                )
            {
                method.Signature.Update(
                    attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                );
                return method;
            }

            return base.VisitMethod(method);
        }
    }
}
