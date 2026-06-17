// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

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

        private static bool HasExperimentalAncestor(CSharpType theType)
        {
            if (theType.BaseType is null)
            {
                return false;
            }
            return ( !SupportedPackages.IsStable(theType.BaseType.FullyQualifiedName)) || HasExperimentalAncestor(theType.BaseType);
        }

        public static bool IsStable(CSharpType theType)
        {
            if (theType is null)
            {
                return true;
            }
            theType = theType.GetNestedElementType();
            if (!SupportedPackages.IsStable(theType.FullyQualifiedName))
            {
                return false;
            }
            if (theType.IsGenericType)
            {
                foreach (CSharpType generic in theType.Arguments)
                {
                    if (!IsStable(generic))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            //if (string.Equals(type.Type.Name, "AgentReference"))
            //{
            //    throw new InvalidOperationException($"{type.Type.FullyQualifiedName}={SupportedPackages.IsStable(type.Type.FullyQualifiedName)} {type.Constructors.Where(x => x.Signature.Parameters.Any(x => !IsStable(x.Type))).Select(x => x.Signature.Parameters.Where(x => !IsStable(x.Type)).Select(x => x.Name)).FirstOrDefault()}==");
            //}
            if ((IsExternal(type.DeclarationModifiers) || HasExperimentalAncestor(type.Type))
                && !SupportedPackages.IsStable(type.Type.FullyQualifiedName)
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }
            if (!SupportedPackages.IsStable(type.Type.FullyQualifiedName))
            {
                foreach (ConstructorProvider constructor in type.Constructors)
                {
                    if (IsExternal(constructor.Signature.Modifiers) && constructor.Signature.Parameters.Any(x => !IsStable(x.Type)))
                    {
                        type.Update(
                        attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                        return type;
                    }
                }
            }
            return base.VisitType(type);
        }

        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            //if (string.Equals(method.Signature.Name, "JsonModelCreateCore") && string.Equals(method.EnclosingType.Name, "FileCitationBody"))
            //{
            //    throw new InvalidOperationException($"Method: {method.Signature.Name} Parameters Are stable: {method.Signature.Parameters.All(x => IsStable(x.Type))} Return Type: {IsStable(method.Signature.ReturnType)} IsStable: {method.Signature.ReturnType.FullyQualifiedName}: {SupportedPackages.IsStable(method.Signature.ReturnType.FullyQualifiedName)}==");
            //}
            // First we need to suppress warnings in the mrthods, from the exclusion list.
            if (IgnoredMethods.IsIgnored(method))
            {
                List<MethodBodyStatement> statements = method.BodyStatements?.ToList() ?? [];
                statements.Insert(0, new PragmaWarningDisableStatement(new LiteralExpression("AAIP001"), "The method returns both experimental an non experimental types."));
                statements.Add(new PragmaWarningRestoreStatement(new LiteralExpression("AAIP001"), "The method returns both experimental an non experimental types."));
                method.Update(bodyStatements: statements);
                return method;
            }
            // If enclising type is not stable and is external, no need to mark its methods.
            if (IsExternal(method.EnclosingType.DeclarationModifiers) && !SupportedPackages.IsStable(method.EnclosingType.Type.FullyQualifiedName))
            {
                return base.VisitMethod(method);
            }

            // If method takes in or return experimental class, mark it as experimental.
            if (!IsStable(method.Signature.ReturnType)
                || method.Signature.Parameters.Any(x => !IsStable(x.Type))
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
